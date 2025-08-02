using System;
using System.Configuration; 
using System.Data.Entity; 
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Contexts; 
using WindowsFormsApp1.Entities.Auth; 
using WindowsFormsApp1.Helpers; 

namespace WindowsFormsApp1.UserControls 
{
    public partial class UC_UpdateAccount : UserControl
    {
        private RegisterEntity _userToUpdate;

        private string _originalEmail; 
        private string _originalUsername; 
        private string _newEmailAttempt;
        private string _tempOtpCode;


        private readonly string smtpHost = ConfigurationManager.AppSettings["SmtpHost"];
        private readonly int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"] ?? "587");
        private readonly string smtpUsername = ConfigurationManager.AppSettings["SmtpUsername"];
        private readonly string smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];
        private readonly bool enableSsl = bool.Parse(ConfigurationManager.AppSettings["EnableSsl"] ?? "true");

        public class UpdateAccountCompletedEventArgs : EventArgs
        {
            public DialogResult Result { get; }
            public RegisterEntity UpdatedUser { get; }

            public UpdateAccountCompletedEventArgs(DialogResult result, RegisterEntity updatedUser = null)
            {
                Result = result;
                UpdatedUser = updatedUser;
            }
        }

        public event EventHandler<UpdateAccountCompletedEventArgs> UpdateCompleted;

        private UC_VerifyEmailOTP _verifyOtpControl;

        public UC_UpdateAccount(RegisterEntity user)
        {
            InitializeComponent();
            _userToUpdate = user;
            _originalEmail = user.Email; 
            _originalUsername = user.Username; 
            this.Load += UC_UpdateAccount_Load; 

            ShowUpdateUI();
        }

        private void UC_UpdateAccount_Load(object sender, EventArgs e)
        {
            if (_userToUpdate != null)
            {
                txtUsername.Text = _userToUpdate.Username;
                txtEmail.Text = _userToUpdate.Email;
                txtUsername.ReadOnly = false;

                txtCurrentPassword.Text = "";
                txtNewPassword.Text = ""; 
                txtConfirmNewPassword.Text = "";
            }
            else
            {
                CustomMessageBox.Show("Yenilənəcək istifadəçi məlumatları tapılmadı.", "Xəta", MessageBoxIcon.Error);
                UpdateCompleted?.Invoke(this, new UpdateAccountCompletedEventArgs(DialogResult.Abort));
                this.Visible = false;
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_userToUpdate == null) return;

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                CustomMessageBox.Show("İstifadəçi adı boş ola bilməz.", "Xəta", MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                CustomMessageBox.Show("E-poçt boş ola bilməz.", "Xəta", MessageBoxIcon.Warning);
                return;
            }
            if (!EmailHelper.IsEmailValid(txtEmail.Text.Trim()))
            {
                CustomMessageBox.Show("Düzgün e-poçt formatı daxil edin.", "Xəta", MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
            {
                CustomMessageBox.Show("Məlumatları yeniləmək üçün cari şifrəni daxil edin.", "Xəta", MessageBoxIcon.Warning);
                return;
            }

            string hashedCurrentPassword = HashPassword(txtCurrentPassword.Text);
            if (hashedCurrentPassword != _userToUpdate.PasswordHash)
            {
                CustomMessageBox.Show("Cari şifrə yanlışdır.", "Xəta", MessageBoxIcon.Warning);
                return;
            }

            if (_originalUsername != txtUsername.Text.Trim())
            {
                using (var context = new AppDbContext())
                {
                    bool usernameExists = await context.RegisterEntities.AnyAsync(u => u.Username == txtUsername.Text.Trim() && u.Id != _userToUpdate.Id);
                    if (usernameExists)
                    {
                        CustomMessageBox.Show("Bu istifadəçi adı artıq başqa istifadəçi tərəfindən istifadə olunur.", "Xəta", MessageBoxIcon.Warning);
                        return;
                    }
                }
                _userToUpdate.Username = txtUsername.Text.Trim();
            }

            bool passwordChanged = !string.IsNullOrWhiteSpace(txtNewPassword.Text) || !string.IsNullOrWhiteSpace(txtConfirmNewPassword.Text);
            if (passwordChanged)
            {
                if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
                {
                    CustomMessageBox.Show("Yeni şifrə boş ola bilməz.", "Xəta", MessageBoxIcon.Warning);
                    return;
                }
                if (txtNewPassword.Text != txtConfirmNewPassword.Text)
                {
                    CustomMessageBox.Show("Yeni şifrələr uyğun gəlmir.", "Xəta", MessageBoxIcon.Warning);
                    return;
                }
                _userToUpdate.PasswordHash = HashPassword(txtNewPassword.Text);
            }

            _newEmailAttempt = txtEmail.Text.Trim();

            if (_originalEmail != _newEmailAttempt)
            {
                using (var context = new AppDbContext())
                {
                    bool emailExists = await context.RegisterEntities.AnyAsync(u => u.Email == _newEmailAttempt && u.Id != _userToUpdate.Id);
                    if (emailExists)
                    {
                        CustomMessageBox.Show("Bu e-poçt artıq başqa istifadəçi tərəfindən istifadə olunur.", "Xəta", MessageBoxIcon.Warning);
                        return;
                    }
                }

                _tempOtpCode = GenerateVerificationCode();
                try
                {
                    await SendVerificationEmail(_newEmailAttempt, _tempOtpCode);
                    CustomMessageBox.Show("Yeni email ünvanınıza doğrulama kodu göndərildi. Zəhmət olmasa kodu daxil edin.", "Məlumat", MessageBoxIcon.Information);

                    HideUpdateUI();
                    ShowOtpVerificationControl();
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show($"Email göndərilərkən xəta: {ex.Message}", "Email Xətası", MessageBoxIcon.Error);
                    UpdateCompleted?.Invoke(this, new UpdateAccountCompletedEventArgs(DialogResult.Cancel));
                    this.Visible = false;
                }
            }
            else
            {
                await FinalizeUpdate();
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            UpdateCompleted?.Invoke(this, new UpdateAccountCompletedEventArgs(DialogResult.Cancel));
            this.Visible = false;
        }

        private void HideUpdateUI()
        {
            if (txtUsername != null) txtUsername.Visible = false;
            if (txtEmail != null) txtEmail.Visible = false;
            if (txtCurrentPassword != null) txtCurrentPassword.Visible = false;
            if (txtNewPassword != null) txtNewPassword.Visible = false;
            if (txtConfirmNewPassword != null) txtConfirmNewPassword.Visible = false;
        }

        private void ShowUpdateUI()
        {
            if (txtUsername != null) txtUsername.Visible = true;
            if (txtEmail != null) txtEmail.Visible = true;
            if (txtCurrentPassword != null) txtCurrentPassword.Visible = true;
            if (txtNewPassword != null) txtNewPassword.Visible = true; 
            if (txtConfirmNewPassword != null) txtConfirmNewPassword.Visible = true; 

            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmNewPassword.Text = "";
        }

        private void ShowOtpVerificationControl()
        {
            if (_verifyOtpControl != null)
            {
                _verifyOtpControl.Dispose();
            }

            _verifyOtpControl = new UC_VerifyEmailOTP(_userToUpdate, _tempOtpCode); 
            _verifyOtpControl.Dock = DockStyle.Fill;
            _verifyOtpControl.VerificationCompleted += UcVerifyEmailOtp_VerificationCompleted;

            this.Controls.Add(_verifyOtpControl);
            _verifyOtpControl.BringToFront();
        }

        private async void UcVerifyEmailOtp_VerificationCompleted(object sender, UC_VerifyEmailOTP.VerificationCompletedEventArgs e)
        {
            if (_verifyOtpControl != null)
            {
                this.Controls.Remove(_verifyOtpControl);
                _verifyOtpControl.Dispose();
                _verifyOtpControl = null;
            }

            if (e.Result == DialogResult.OK)
            {
                _userToUpdate.Email = _newEmailAttempt;
                await FinalizeUpdate();
            }
            else
            {
                CustomMessageBox.Show("Email doğrulama ləğv edildi və ya xəta baş verdi. Məlumatlar yenilənmədi.", "Məlumat", MessageBoxIcon.Information);

                UpdateCompleted?.Invoke(this, new UpdateAccountCompletedEventArgs(DialogResult.Cancel));
                this.Visible = false;
            }
        }


        private async Task FinalizeUpdate()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var userInDb = await context.RegisterEntities.FindAsync(_userToUpdate.Id);
                    if (userInDb != null)
                    {
                        userInDb.Username = _userToUpdate.Username; 
                        userInDb.Email = _userToUpdate.Email;
                        userInDb.PasswordHash = _userToUpdate.PasswordHash; 
                        userInDb.IsEmailVerified = true; 
                        userInDb.EmailVerificationCode = null; 

                        await context.SaveChangesAsync();
                        CustomMessageBox.Show("Məlumatlar uğurla yeniləndi!", "Uğurlu", MessageBoxIcon.Information);

                        UpdateCompleted?.Invoke(this, new UpdateAccountCompletedEventArgs(DialogResult.OK, userInDb));
                        this.Visible = false; 
                    }
                    else
                    {
                        CustomMessageBox.Show("İstifadəçi bazada tapılmadı.", "Xəta", MessageBoxIcon.Error);
                        UpdateCompleted?.Invoke(this, new UpdateAccountCompletedEventArgs(DialogResult.Cancel));
                        this.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Məlumatlar yenilənərkən xəta: " + ex.Message, "Xəta", MessageBoxIcon.Error);
                UpdateCompleted?.Invoke(this, new UpdateAccountCompletedEventArgs(DialogResult.Cancel));
                this.Visible = false;
            }
        }

        private string GenerateVerificationCode()
        {
            Random rand = new Random();
            return rand.Next(100000, 999999).ToString(); 
        }

        private async Task SendVerificationEmail(string recipientEmail, string verificationCode)
        {
            try
            {
                using (SmtpClient client = new SmtpClient(smtpHost, smtpPort))
                {
                    client.EnableSsl = enableSsl;
                    client.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(smtpUsername, "Neorica");
                    mail.To.Add(recipientEmail);
                    mail.Subject = "Email Doğrulama Kodu";
                    mail.Body = $"Hörmətli istifadəçi,\n\nEmail ünvanınızı təsdiqləmək üçün doğrulama kodunuz: {verificationCode}\n\nBu kodu tətbiqdəki müvafiq xanaya daxil edin.\n\nHörmətlə,\nNeorica Komandası";
                    mail.IsBodyHtml = false;

                    await client.SendMailAsync(mail);
                }
                return;
            }
            catch (SmtpException smtpEx)
            {
                CustomMessageBox.Show($"Email göndərilərkən SMTP xətası: {smtpEx.StatusCode} - {smtpEx.Message}", "Email Xətası", MessageBoxIcon.Error);
                throw new Exception("Email göndərilmədi.", smtpEx);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Email göndərilərkən xəta: {ex.Message}", "Email Xətası", MessageBoxIcon.Error);
                throw new Exception("Email göndərilmədi.", ex);
            }
        }
    }
}
