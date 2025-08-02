using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Contexts;
using WindowsFormsApp1.Entites;
using WindowsFormsApp1.UserControls;

namespace WindowsFormsApp1.Controllers
{
    public partial class UC_CreateUserTab : UserControl
    {
        private readonly HaarCascade faceDetector;
        private Capture videoCamera;

        private Image<Bgr, Byte> currentFrame;
        private Image<Gray, byte> detectedFaceRegion;
        private Image<Gray, byte> grayScaleFrame;

        private MCvFont displayFont = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.6d, 0.6d);

        private readonly List<Image<Gray, byte>> trainedFaces = new List<Image<Gray, byte>>();
        private readonly List<string> faceLabels = new List<string>();

        private int totalFaces;
        private string currentDetectedName;

        private EigenObjectRecognizer recognizer;

        public UC_CreateUserTab()
        {
            InitializeComponent();

            StartButton.Click += StartCameraFeed;
            faceDetector = new HaarCascade("haarcascade_frontalface_default.xml");

            string folderPath = Path.Combine(Application.StartupPath, "Faces");
            Directory.CreateDirectory(folderPath);

            totalFaces = Directory.GetFiles(folderPath, "*.bmp").Length;

            LoadTrainedFaces(folderPath);
            LoadDefaultImage();

            InitializeRecognizer();
        }

        private void LoadTrainedFaces(string folderPath)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var faces = context.FaceRecords.ToList();

                    foreach (var face in faces)
                    {
                        string imagePath = Path.Combine(folderPath, face.ImagePath);

                        if (File.Exists(imagePath))
                        {
                            using (var bmp = new Bitmap(imagePath))
                            {
                                var grayFace = new Image<Gray, byte>(bmp).Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                                trainedFaces.Add(grayFace);
                                faceLabels.Add(face.Name);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Database xətası:\n" + ex.Message);
            }
        }

        private void LoadDefaultImage()
        {
            string defaultImagePath = Path.Combine(Application.StartupPath, "Faces", "Default.jpg");

            if (File.Exists(defaultImagePath))
            {
                try
                {
                    var defaultImg = Image.FromFile(defaultImagePath);
                    cameraBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    cameraBox.Image = defaultImg;
                }
                catch
                {
                    cameraBox.Image = null;
                }
            }
            else
            {
                cameraBox.Image = null;
            }
        }

        private void InitializeRecognizer()
        {
            if (trainedFaces.Count > 0)
            {
                MCvTermCriteria termCriteria = new MCvTermCriteria(totalFaces, 0.001);
                recognizer = new EigenObjectRecognizer(trainedFaces.ToArray(), faceLabels.ToArray(), 1500, ref termCriteria);
            }
        }

        private async void StartCameraFeed(object sender, EventArgs e)
        {
            StartButton.Enabled = false;

            await Task.Run(() =>
            {
                videoCamera = new Capture(0);
                videoCamera.QueryFrame(); // Start camera
            });

            Application.Idle += ProcessFrame;
            StartButton.Enabled = true;
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            currentFrame = videoCamera?.QueryFrame();

            if (currentFrame == null)
                return;

            currentFrame = currentFrame.Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            grayScaleFrame = currentFrame.Convert<Gray, byte>();

            var detectedFaces = grayScaleFrame.DetectHaarCascade(faceDetector, 1.2, 10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

            foreach (var face in detectedFaces[0])
            {
                detectedFaceRegion = currentFrame.Copy(face.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                currentFrame.Draw(face.rect, new Bgr(Color.Green), 1);

                if (trainedFaces.Count > 0 && recognizer != null)
                {
                    currentDetectedName = recognizer.Recognize(detectedFaceRegion);
                    currentFrame.Draw(currentDetectedName, ref displayFont, new Point(face.rect.X - 2, face.rect.Y - 2), new Bgr(Color.Red));

                }
            }

            cameraBox.Image = currentFrame.ToBitmap();
        }

        private void resetInputButton_Click(object sender, EventArgs e)
        {
            textName.Clear();
            textSurname.Clear();
            dateTimePickerBirth.Value = DateTime.Today;
            textDescription.Clear();
            textWorkplace.Clear();
            textEducation.Clear();
            textPhone.Clear();
            textAddress.Clear();
            textIdentity.Clear();
            textAge.Clear();

            LoadDefaultImage();
        }

        private void showUserInformation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentDetectedName))
            {
                CustomMessageBox.Show("İstifadəçi tanınmayıb.");
                return;
            }

            using (var context = new AppDbContext())
            {
                var user = context.FaceRecords.FirstOrDefault(u => u.Name == currentDetectedName);
                if (user != null)
                {
                    UC_UserInfo infoForm = new UC_UserInfo(user);
                    infoForm.Show();
                }
                else
                {
                    CustomMessageBox.Show("İstifadəçi məlumatları tapılmadı.");
                }
            }
        }

        private void SaveFace_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(textAge.Text, out int age))
            {
                CustomMessageBox.Show("Yaşı düzgün daxil edin.");
                return;
            }

            if (!radioMale.Checked && !radioFemale.Checked)
            {
                CustomMessageBox.Show("Zəhmət olmasa cinsiyyəti seçin.");
                return;
            }

            grayScaleFrame = videoCamera.QueryGrayFrame()?.Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            if (grayScaleFrame == null)
            {
                CustomMessageBox.Show("Kamera görüntüsü alınmadı.");
                return;
            }

            var detectedFaces = grayScaleFrame.DetectHaarCascade(faceDetector, 1.2, 10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));

            detectedFaceRegion = null;
            foreach (var face in detectedFaces[0])
            {
                detectedFaceRegion = currentFrame.Copy(face.rect).Convert<Gray, byte>();
                break;
            }

            if (detectedFaceRegion == null)
            {
                CustomMessageBox.Show("Üz tanınmadı. Zəhmət olmasa kameraya baxın və yenidən cəhd edin.");
                return;
            }

            detectedFaceRegion = detectedFaceRegion.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            string folderPath = Path.Combine(Application.StartupPath, "Faces");
            Directory.CreateDirectory(folderPath);

            totalFaces++;
            string faceFileName = $"Face{totalFaces}.bmp";
            string fullPath = Path.Combine(folderPath, faceFileName);

            detectedFaceRegion.Save(fullPath);

            string gender = radioMale.Checked ? "Male" : "Female";

            using (var context = new AppDbContext())
            {
                var faceRecord = new FaceRecord
                {
                    Name = textName.Text,
                    Surname = textSurname.Text,
                    BirthDate = dateTimePickerBirth.Value,
                    Description = textDescription.Text,
                    ImagePath = faceFileName,
                    SavedAt = DateTime.Now,
                    DetectedBy = "Operator",
                    Gender = gender,
                    Age = age,
                    Workplace = textWorkplace.Text,
                    EducationLevel = textEducation.Text,
                    PhoneNumber = textPhone.Text,
                    Address = textAddress.Text,
                    IdentityNumber = textIdentity.Text
                };

                context.FaceRecords.Add(faceRecord);
                context.SaveChanges();
            }

            using (var bmp = new Bitmap(fullPath))
            {
                var grayFace = new Image<Gray, byte>(bmp).Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainedFaces.Add(grayFace);
                faceLabels.Add(textName.Text);
            }

            MCvTermCriteria termCriteria = new MCvTermCriteria(totalFaces, 0.001);
            recognizer = new EigenObjectRecognizer(trainedFaces.ToArray(), faceLabels.ToArray(), 1500, ref termCriteria);

            MessageBox.Show($"{textName.Text} uğurla əlavə edildi.");
        }
    }
}
