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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Contexts;

namespace WindowsFormsApp1
{
    public partial class UC_Login : UserControl
    {
        private Capture camera;
        private HaarCascade faceDetector;
        private System.Drawing.Image currentFrame;

        private readonly string awsAccessKeyId = ConfigurationManager.AppSettings["AwsAccessKeyId"];
        private readonly string awsSecretAccessKey = ConfigurationManager.AppSettings["AwsSecretAccessKey"];
        private readonly RegionEndpoint awsRegion = RegionEndpoint.USEast1;

        private const string RekognitionCollectionId = "MyUserFaces";

        public event EventHandler<string> LoginSuccess;
        public event EventHandler BackToMainPageRequested;

        public UC_Login()
        {
            InitializeComponent();
            LoadDefaultImage();
            faceDetector = new HaarCascade("haarcascade_frontalface_default.xml");
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
                CustomMessageBox.Show("Default.jpg şəkli 'RegisterFaces' qovluğunda tapılmadı. Zəhmət olmasa bir şəkil əlavə edin.", "Məlumat", MessageBoxIcon.Information);
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
            var grayFrame = frame.Convert<Gray, byte>();

            var faces = grayFrame.DetectHaarCascade(faceDetector, 1.05, 4,
                HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

            foreach (var face in faces[0])
                frame.Draw(face.rect, new Bgr(Color.Green), 2);

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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            bool isTraditionalInputProvided = !string.IsNullOrWhiteSpace(txtEmail.Text) || !string.IsNullOrWhiteSpace(txtPassword.Text);
            bool isFaceRecognitionAttempted = (currentFrame != null && camera != null);

            if (isTraditionalInputProvided && isFaceRecognitionAttempted)
            {
                CustomMessageBox.Show("Zəhmət olmasa ya istifadəçi adı/şifrəni daxil edin, ya da kameranı işə salıb üzünüzü göstərin. Hər ikisini eyni anda istifadə etməyin.", "Giriş Xətası", MessageBoxIcon.Warning);
                return;
            }
            else if (isTraditionalInputProvided)
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    CustomMessageBox.Show("Zəhmət olmasa istifadəçi adı və şifrəni daxil edin.");
                    return;
                }

                var username = txtEmail.Text.Trim();
                var password = txtPassword.Text;
                var hashedPassword = HashPassword(password);

                using (var context = new AppDbContext())
                {
                    var user = await context.RegisterEntities.FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == hashedPassword);

                    if (user != null)
                    {
                        CustomMessageBox.Show($"Giriş uğurludur! Xoş gəldin, {user.Username}!", "Giriş Uğurlu", MessageBoxIcon.Information);
                        LoginSuccess?.Invoke(this, user.Username);
                        StopCameraAndResetUI();
                    }
                    else
                    {
                        CustomMessageBox.Show("İstifadəçi adı və ya şifrə yanlışdır.", "Giriş Xətası", MessageBoxIcon.Warning);
                    }
                }
            }
            else if (isFaceRecognitionAttempted)
            {
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
                byte[] faceBytes = ImageToByteArray(faceImg.ToBitmap());

                try
                {
                    string recognizedUserId = await SearchFaceInRekognitionAsync(faceBytes);

                    if (!string.IsNullOrEmpty(recognizedUserId))
                    {
                        using (var context = new AppDbContext())
                        {
                            var recognizedUser = await context.RegisterEntities.FirstOrDefaultAsync(u => u.Id.ToString() == recognizedUserId);

                            if (recognizedUser != null && recognizedUser.IsActive)
                            {
                                CustomMessageBox.Show($"Giriş uğurludur! İstifadəçi: {recognizedUser.Username}", "Giriş Uğurlu", MessageBoxIcon.Information);
                                LoginSuccess?.Invoke(this, recognizedUser.Username);
                                StopCameraAndResetUI();
                            }
                            else if (recognizedUser != null && !recognizedUser.IsActive)
                            {
                                CustomMessageBox.Show("Bu üz tanındı, lakin istifadəçi üz tanıma ilə qeydiyyatdan keçməyib. Zəhmət olmasa istifadəçi adı və şifrə ilə daxil olun.", "Null", MessageBoxIcon.Information);
                            }
                            else
                            {
                                CustomMessageBox.Show("Tanınan üzə uyğun istifadəçi bazada tapılmadı.", "Xəta", MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        CustomMessageBox.Show("Üz tanınmadı. Zəhmət olmasa yenidən cəhd edin.", "Tanınmadı", MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Giriş zamanı xəta: " + ex.Message, "Xəta", MessageBoxIcon.Error);
                }
            }
            else
            {
                CustomMessageBox.Show("Giriş üçün istifadəçi adı/şifrəni daxil edin və ya kameranı işə salıb üzünüzü göstərin.", "Giriş Tələb Olunur", MessageBoxIcon.Information);
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

        private async Task<string> SearchFaceInRekognitionAsync(byte[] imageBytes)
        {
            using (var rekognitionClient = new AmazonRekognitionClient(awsAccessKeyId, awsSecretAccessKey, awsRegion))
            {
                try
                {
                    var request = new SearchFacesByImageRequest
                    {
                        CollectionId = RekognitionCollectionId,
                        Image = new Amazon.Rekognition.Model.Image { Bytes = new MemoryStream(imageBytes) },
                        FaceMatchThreshold = 80,
                        MaxFaces = 1
                    };

                    var response = await rekognitionClient.SearchFacesByImageAsync(request);

                    if (response.FaceMatches.Count > 0)
                    {
                        var faceMatch = response.FaceMatches[0];
                        Console.WriteLine($"Üz tanındı. ExternalImageId: {faceMatch.Face.ExternalImageId}, Confidence: {faceMatch.Similarity:F2}");
                        return faceMatch.Face.ExternalImageId;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show($"Rekognition üzü axtararkən xəta: {ex.Message}", "Rekognition Xətası", MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        private void backLoginPage_Click_1(object sender, EventArgs e)
        {
            StopCameraAndResetUI();
            BackToMainPageRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}