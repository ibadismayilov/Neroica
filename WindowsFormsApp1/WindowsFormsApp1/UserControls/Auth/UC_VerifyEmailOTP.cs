using System;
using System.Configuration;
using System.Data.Entity;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Contexts;
using WindowsFormsApp1.Entities.Auth;

namespace WindowsFormsApp1.UserControls
{
    public partial class UC_VerifyEmailOTP : UserControl
    {
        private RegisterEntity _userToVerify;
        private string _originalOtpCode; 

        private readonly string smtpHost = ConfigurationManager.AppSettings["SmtpHost"] ;
        private readonly int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);
        private readonly string smtpUsername = ConfigurationManager.AppSettings["SmtpUsername"];
        private readonly string smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];
        private readonly bool enableSsl = bool.Parse(ConfigurationManager.AppSettings["EnableSsl"] ?? "true");

        public event EventHandler<VerificationCompletedEventArgs> VerificationCompleted;

        public UC_VerifyEmailOTP(RegisterEntity user, string otpCode)
        {
            InitializeComponent();
            _userToVerify = user;
            _originalOtpCode = otpCode;
        }

        private async void btnVerify_Click(object sender, EventArgs e)
        {
            string enteredCode = txtOtpCode.Text.Trim();

            if (string.IsNullOrEmpty(enteredCode))
            {
                CustomMessageBox.Show("Zəhmət olmasa doğrulama kodunu daxil edin.", "Məlumat", MessageBoxIcon.Information);
                return;
            }

            if (enteredCode == _originalOtpCode)
            {
                try
                {
                    using (var context = new AppDbContext())
                    {
                        var userInDb = await context.RegisterEntities.FirstOrDefaultAsync(u => u.Id == _userToVerify.Id);
                        if (userInDb != null)
                        {
                            userInDb.IsEmailVerified = true;
                            await context.SaveChangesAsync();

                            CustomMessageBox.Show("Email uğurla təsdiqləndi!", "Uğurlu", MessageBoxIcon.Information);

                            VerificationCompleted?.Invoke(this, new VerificationCompletedEventArgs(DialogResult.OK, userInDb));
                        }
                        else
                        {
                            CustomMessageBox.Show("İstifadəçi bazada tapılmadı.", "Xəta", MessageBoxIcon.Error);
                            VerificationCompleted?.Invoke(this, new VerificationCompletedEventArgs(DialogResult.Abort));
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Email təsdiqlənərkən xəta: " + ex.Message, "Xəta", MessageBoxIcon.Error);
                    VerificationCompleted?.Invoke(this, new VerificationCompletedEventArgs(DialogResult.Abort));
                }
            }
            else
            {
                CustomMessageBox.Show("Yanlış doğrulama kodu. Zəhmət olmasa yenidən cəhd edin.", "Xəta", MessageBoxIcon.Warning);
            }
        }

        private async void btnResendOtp_Click_1(object sender, EventArgs e)
        {
            if (_userToVerify == null)
            {
                CustomMessageBox.Show("İstifadəçi məlumatları tapılmadı. Kodu yenidən göndərmək mümkün deyil.", "Xəta", MessageBoxIcon.Error);
                return;
            }

            _originalOtpCode = GenerateVerificationCode();
            _userToVerify.EmailVerificationCode = _originalOtpCode;

            try
            {
                using (var context = new AppDbContext())
                {
                    var userInDb = await context.RegisterEntities.FirstOrDefaultAsync(u => u.Id == _userToVerify.Id);
                    if (userInDb != null)
                    {
                        userInDb.EmailVerificationCode = _originalOtpCode;
                        await context.SaveChangesAsync();
                    }
                }

                await SendVerificationEmail(_userToVerify.Email, _originalOtpCode);
                CustomMessageBox.Show("Yeni doğrulama kodu email ünvanınıza göndərildi.", "Uğurlu", MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Kodu yenidən göndərərkən xəta: " + ex.Message, "Xəta", MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            VerificationCompleted?.Invoke(this, new VerificationCompletedEventArgs(DialogResult.Cancel));
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
                    client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(smtpUsername, "Neorica");
                    mail.To.Add(recipientEmail);
                    mail.Subject = "Email Doğrulama Kodu";
                    mail.Body = $"Hörmətli istifadəçi,\n\nEmail ünvanınızı təsdiqləmək üçün doğrulama kodunuz: {verificationCode}\n\nBu kodu tətbiqdəki müvafiq xanaya daxil edin.\n,\nHörmətlə, Neorica Komandası";
                    mail.IsBodyHtml = false;

                    await client.SendMailAsync(mail);
                }
            }
            catch (SmtpException smtpEx)
            {
                CustomMessageBox.Show($"Email göndərilərkən SMTP xətası: {smtpEx.StatusCode} - {smtpEx.Message}", "Email Xətası", MessageBoxIcon.Error);
                throw;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"Email göndərilərkən xəta: {ex.Message}", "Email Xətası", MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
