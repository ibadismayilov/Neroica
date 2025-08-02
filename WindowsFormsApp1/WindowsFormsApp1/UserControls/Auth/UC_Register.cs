using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Contexts;
using WindowsFormsApp1.Entities.Auth;
using WindowsFormsApp1.FluentValidations;
using WindowsFormsApp1.Helpers;
using WindowsFormsApp1.UserControls;

namespace WindowsFormsApp1
{
    public partial class UC_RegisterUser : UserControl
    {
        private Capture camera;
        private HaarCascade faceDetector;
        private System.Drawing.Image currentFrame;

        private readonly string awsAccessKeyId = ConfigurationManager.AppSettings["AwsAccessKeyId"];
        private readonly string awsSecretAccessKey = ConfigurationManager.AppSettings["AwsSecretAccessKey"];
        private readonly RegionEndpoint awsRegion = RegionEndpoint.USEast1;
        private const string RekognitionCollectionId = "MyUserFaces";
         
        private readonly string smtpHost = ConfigurationManager.AppSettings["SmtpHost"];
        private readonly int smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"] ?? "587");
        private readonly string smtpUsername = ConfigurationManager.AppSettings["SmtpUsername"];
        private readonly string smtpPassword = ConfigurationManager.AppSettings["SmtpPassword"];
        private readonly bool enableSsl = bool.Parse(ConfigurationManager.AppSettings["EnableSsl"] ?? "true");

        private RegisterEntity _newUserBeingRegistered;
        private UC_VerifyEmailOTP _verifyOtpControl;

        private Bitmap _capturedFaceBitmap;
        private byte[] _capturedFaceBytes;

        public event EventHandler RegistrationSuccess;
        public event EventHandler BackToMainPageRequested;

        public UC_RegisterUser()
        {
            InitializeComponent();
            LoadDefaultImage();
            faceDetector = new HaarCascade("haarcascade_frontalface_default.xml");

            ShowRegistrationUI();
        }

        private void LoadDefaultImage()
        {
            string defaultImagePath = Path.Combine(Application.StartupPath, "RegisterFaces", "Default.jpg");

            if (!Directory.Exists(Path.Combine(Application.StartupPath, "RegisterFaces")))
            {
                Directory.CreateDirectory(Path.Combine(Application.StartupPath, "RegisterFaces"));
            }

            if (File.Exists(defaultImagePath))
            {
                try
                {
                    using (var stream = new FileStream(defaultImagePath, FileMode.Open, FileAccess.Read))
                    {
                        var defaultImg = System.Drawing.Image.FromStream(stream);
                        cameraBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        cameraBox.Image = (System.Drawing.Image)defaultImg.Clone();
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show($"Default şəkil yüklənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxIcon.Error);
                    cameraBox.Image = null;
                }
            }
            else
            {
                cameraBox.Image = null;
            }
        }

        private void btnStartCamera_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (camera == null)
                {
                    camera = new Capture();
                    Application.Idle += ProcessFrame;
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Kamera açılmadı: " + ex.Message, "Kamera Xətası", MessageBoxIcon.Error);
            }
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            Emgu.CV.Image<Bgr, byte> frame = camera?.QueryFrame();

            if (frame == null)
                return;

            frame = frame.Resize(320, 240, INTER.CV_INTER_CUBIC);
            var grayScaleFrame = frame.Convert<Gray, byte>();

            var detectedFaces = grayScaleFrame.DetectHaarCascade(faceDetector, 1.05, 4,
                HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

            foreach (var face in detectedFaces[0])
            {
                frame.Draw(face.rect, new Bgr(Color.Green), 2);
            }

            currentFrame = frame.ToBitmap();
            cameraBox.Image = currentFrame;
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

        private async void btnRegister_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                CustomMessageBox.Show("Zəhmət olmasa bütün xanaları doldurun.", "Məlumat", MessageBoxIcon.Information);
                return;
            }

            var username = txtUsername.Text.Trim();
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;
            var hashedPassword = HashPassword(password);

            using (var context = new AppDbContext())
            {
                bool userExists = await context.RegisterEntities.AnyAsync(u => u.Username == username || u.Email == email);
                if (userExists)
                {
                    CustomMessageBox.Show("Bu istifadəçi adı və ya email artıq mövcuddur.", "Xəta", MessageBoxIcon.Warning);
                    return;
                }
            }

            var checkEmail = EmailHelper.IsEmailValid(email);
            if (!checkEmail)
            {
                CustomMessageBox.Show("Email domeni mövcud deyil və ya düzgün deyil.", "Xəta", MessageBoxIcon.Warning);
                return;
            }

            if (currentFrame == null)
            {
                CustomMessageBox.Show("Kamera aktiv deyil və ya heç bir şəkil çəkilməyib. Zəhmət olmasa kameranı işə salın və üzünüzü göstərin.");
                return;
            }

            Emgu.CV.Image<Bgr, byte> emguImage = new Emgu.CV.Image<Bgr, byte>((Bitmap)currentFrame);
            var gray = emguImage.Convert<Gray, byte>();
            var faces = gray.DetectHaarCascade(faceDetector, 1.05, 4,
                HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

            if (faces[0].Length == 0)
            {
                CustomMessageBox.Show("Üz tapılmadı, zəhmət olmasa üzünüzü kamera qarşısında saxlayın.");
                return;
            }

            var faceRect = faces[0][0].rect;
            var faceImg = emguImage.Copy(faceRect).Resize(100, 100, INTER.CV_INTER_CUBIC);

            _capturedFaceBitmap = faceImg.ToBitmap();
            _capturedFaceBytes = ImageToByteArray(_capturedFaceBitmap);

            _newUserBeingRegistered = new RegisterEntity
            {
                Username = username,
                Email = email,
                PasswordHash = hashedPassword,
                SavedAt = DateTime.Now,
                Role = "User",
                IsEmailVerified = false, 
                EmailVerificationCode = GenerateVerificationCode(), 
                HasFaceRegistered = true, 
                ImagePath = Path.Combine("RegisterFaces", $"{username}.bmp")
            };

            var validator = new RegisterEntityValidator();
            var result = validator.Validate(_newUserBeingRegistered);

            if (!result.IsValid)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    sb.AppendLine(error.ErrorMessage);
                }
                CustomMessageBox.Show(sb.ToString(), "Doğrulama Xətası", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string fullFolderPath = Path.Combine(Application.StartupPath, "RegisterFaces");
                if (!Directory.Exists(fullFolderPath))
                {
                    Directory.CreateDirectory(fullFolderPath);
                }
                var imageFilePath = Path.Combine(fullFolderPath, $"{username}.bmp");
                _capturedFaceBitmap.Save(imageFilePath); 

                using (var context = new AppDbContext())
                {
                    context.RegisterEntities.Add(_newUserBeingRegistered);
                    await context.SaveChangesAsync();
                }

                await SendVerificationEmail(_newUserBeingRegistered.Email, _newUserBeingRegistered.EmailVerificationCode);
                CustomMessageBox.Show("Qeydiyyat uğurludur! Email ünvanınıza doğrulama kodu göndərildi. Zəhmət olmasa kodu daxil edin.", "Uğurlu", MessageBoxIcon.Information);

                HideRegistrationUI();
                ShowVerifyEmailOTPControl();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Qeydiyyat zamanı xəta: " + ex.Message, "Xəta", MessageBoxIcon.Error);
                DeleteUnverifiedUserAndImage(_newUserBeingRegistered);
            }
        }

        private void StopCameraAndResetUI()
        {
            if (camera != null)
            {
                Application.Idle -= ProcessFrame;
                camera.Dispose();
                camera = null;
                cameraBox.Image = null;
                LoadDefaultImage();
            }
        }

        private byte[] ImageToByteArray(Bitmap image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        public async Task CreateRekognitionCollectionAsync(string collectionId)
        {
            using (var rekognitionClient = new AmazonRekognitionClient(awsAccessKeyId, awsSecretAccessKey, awsRegion))
            {
                try
                {
                    var request = new CreateCollectionRequest
                    {
                        CollectionId = collectionId.Trim()
                    };
                    var response = await rekognitionClient.CreateCollectionAsync(request);
                    if (response.StatusCode.HasValue && (HttpStatusCode)response.StatusCode.Value == HttpStatusCode.OK)
                    {
                        Console.WriteLine($"Rekognition kolleksiyası '{collectionId}' uğurla yaradıldı.");
                    }
                }
                catch (ResourceAlreadyExistsException)
                {
                    Console.WriteLine($"Rekognition kolleksiyası '{collectionId}' artıq mövcuddur.");
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show($"Kolleksiya yaradılarkən xəta: {ex.Message}", "Xəta", MessageBoxIcon.Error);
                }
            }
        }

        private async Task<bool> IndexFaceToRekognitionAsync(byte[] imageBytes, string externalImageId)
        {
            using (var rekognitionClient = new AmazonRekognitionClient(awsAccessKeyId, awsSecretAccessKey, awsRegion))
            {
                try
                {
                    var request = new IndexFacesRequest
                    {
                        CollectionId = RekognitionCollectionId,
                        Image = new Amazon.Rekognition.Model.Image { Bytes = new MemoryStream(imageBytes) },
                        ExternalImageId = externalImageId,
                        DetectionAttributes = new System.Collections.Generic.List<string> { "DEFAULT" }
                    };

                    var response = await rekognitionClient.IndexFacesAsync(request);

                    if (response.FaceRecords.Count > 0)
                    {
                        Console.WriteLine($"Üz Rekognition-a əlavə edildi. FaceId: {response.FaceRecords[0].Face.FaceId}");
                        return true;
                    }
                    else
                    {
                        CustomMessageBox.Show("Rekognition üzü indeksləyə bilmədi. Şəkildə üz tapılmadı və ya keyfiyyət aşağıdır.", "Rekognition Xətası", MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show($"Rekognition üzü indekslərkən xəta: {ex.Message}", "Rekognition Xətası", MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void backLoginPage_Click(object sender, EventArgs e)
        {
            StopCameraAndResetUI();
            BackToMainPageRequested?.Invoke(this, EventArgs.Empty);
        }

        private void HideRegistrationUI()
        {
            if (txtUsername != null) txtUsername.Visible = false;
            if (txtPassword != null) txtPassword.Visible = false;
            if (txtEmail != null) txtEmail.Visible = false;
            if (btnRegister != null) btnRegister.Visible = false;
            if (backLoginPage != null) backLoginPage.Visible = false;
            if (btnStartCamera != null) btnStartCamera.Visible = false;
            if (cameraBox != null) cameraBox.Visible = false;
        }


        private void ShowRegistrationUI()
        {
            if (txtUsername != null) txtUsername.Visible = true;
            if (txtPassword != null) txtPassword.Visible = true;
            if (txtEmail != null) txtEmail.Visible = true;
            if (btnRegister != null) btnRegister.Visible = true;
            if (backLoginPage != null) backLoginPage.Visible = true;
            if (btnStartCamera != null) btnStartCamera.Visible = true;
            if (cameraBox != null) cameraBox.Visible = true;

            txtUsername.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
        }

        private void ShowVerifyEmailOTPControl()
        {
            if (_verifyOtpControl != null)
            {
                _verifyOtpControl.Dispose();
            }

            _verifyOtpControl = new UC_VerifyEmailOTP(_newUserBeingRegistered, _newUserBeingRegistered.EmailVerificationCode);
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

            ShowRegistrationUI();

            if (e.Result == DialogResult.OK)
            {
                CustomMessageBox.Show("Email uğurla təsdiqləndi!", "Uğurlu", MessageBoxIcon.Information);

                if (_newUserBeingRegistered.HasFaceRegistered && _capturedFaceBytes != null)
                {
                    bool faceIndexed = await IndexFaceToRekognitionAsync(_capturedFaceBytes, _newUserBeingRegistered.Id.ToString());
                    if (!faceIndexed)
                    {
                        CustomMessageBox.Show("Üz Rekognition-a əlavə edilmədi. Zəhmət olmasa hesab səhifəsindən yenidən cəhd edin.", "Xəta", MessageBoxIcon.Error);
                    }
                }
                RegistrationSuccess?.Invoke(this, EventArgs.Empty);
            }
            else if (e.Result == DialogResult.Cancel || e.Result == DialogResult.Abort)
            {
                CustomMessageBox.Show("Email doğrulama ləğv edildi və ya xəta baş verdi. Qeydiyyat tamamlanmadı.", "Məlumat", MessageBoxIcon.Information);
                DeleteUnverifiedUserAndImage(_newUserBeingRegistered);
                BackToMainPageRequested?.Invoke(this, EventArgs.Empty);
            }

            StopCameraAndResetUI();
        }

        private async void DeleteUnverifiedUserAndImage(RegisterEntity user)
        {
            if (user == null) return;

            try
            {
                using (var context = new AppDbContext())
                {
                    var userInDb = await context.RegisterEntities.FirstOrDefaultAsync(u => u.Id == user.Id);
                    if (userInDb != null)
                    {
                        context.RegisterEntities.Remove(userInDb);
                        await context.SaveChangesAsync();
                        Console.WriteLine($"İstifadəçi {user.Username} bazadan silindi.");
                    }
                }

                if (user.HasFaceRegistered && !string.IsNullOrEmpty(user.ImagePath))
                {
                    string fullImagePath = Path.Combine(Application.StartupPath, user.ImagePath);
                    if (File.Exists(fullImagePath))
                    {
                        File.Delete(fullImagePath);
                        Console.WriteLine($"Şəkil {fullImagePath} silindi.");
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show($"İstifadəçi və ya şəkil silinərkən xəta: {ex.Message}", "Xəta", MessageBoxIcon.Error);
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
                    client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(smtpUsername, "Neorica");
                    mail.To.Add(recipientEmail);
                    mail.Subject = "Email Doğrulama Kodu";
                    mail.Body = $"Hörmətli istifadəçi,\n\nEmail ünvanınızı təsdiqləmək üçün doğrulama kodunuz: {verificationCode}\n\nBu kodu tətbiqdəki müvafiq xanaya daxil edin.\n\nHörmətlə,\nNeorica";
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