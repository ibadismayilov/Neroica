using System;
using System.Windows.Forms;
using WindowsFormsApp1.Entities.Auth;
using WindowsFormsApp1.UserControls;
using WindowsFormsApp1.Helpers;
using System.IO; 
using System.Drawing;
using static WindowsFormsApp1.Enums.AuthFormInitialPages;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private RegisterEntity _loggedInUser;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(RegisterEntity user) : this()
        {
            _loggedInUser = user;
            this.Load += Main_Load;
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            mainContextPanel.Controls.Clear();

            UC_RegisterUser registerUserControl = new UC_RegisterUser();
            await registerUserControl.CreateRekognitionCollectionAsync("MyUserFaces");

            if (_loggedInUser != null)
            {
                UC_Landing uC_Landing = new UC_Landing();
                uC_Landing.SetUserData(_loggedInUser);
                addUserControl(uC_Landing);

                DisplayUserProfilePicture();
            }
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            mainContextPanel.Controls.Clear();
            mainContextPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void ShowAccountPage()
        {
            if (_loggedInUser == null)
            {
                CustomMessageBox.Show("Hesab məlumatlarını göstərmək üçün istifadəçi daxil olmalıdır.", "Məlumat", MessageBoxIcon.Information);
                return;
            }

            UC_Account accountControl = new UC_Account();
            accountControl.SetUserData(_loggedInUser);
            addUserControl(accountControl);

        }

        private void authButton_Click_1(object sender, EventArgs e)
        {
            AuthForm authForm = new AuthForm(AuthFormInitialPage.Login);
            authForm.ShowDialog();
        }

        private void userAccount_Click_1(object sender, EventArgs e)
        {
            AuthForm authForm;

            if (_loggedInUser == null)
            {
                CustomMessageBox.Show("Hesab məlumatlarını göstərmək üçün əvvəlcə daxil olun.", "Məlumat", MessageBoxIcon.Information);
                authForm = new AuthForm(AuthFormInitialPage.Login);
                authForm.ShowDialog();
                this.Show();
                mainContextPanel.Controls.Clear();
                return;
            }

            this.Hide();

            authForm = new AuthForm(AuthFormInitialPage.Account, _loggedInUser);
            authForm.ShowDialog();

            mainContextPanel.Controls.Clear();
            this.Show();
        }

        private void btnSearchPhoto_Click_1(object sender, EventArgs e)
        {
            if (_loggedInUser != null)
            {
                UC_SearchPhotoWIthAI uC_SearchPhotoWIthAI = new UC_SearchPhotoWIthAI(_loggedInUser.Id);
                addUserControl(uC_SearchPhotoWIthAI);
            }
            else
            {
                CustomMessageBox.Show("Şəkil axtarışı üçün əvvəlcə daxil olun.", "Məlumat", MessageBoxIcon.Information);
            }
        }

        private void DisplayUserProfilePicture()
        {
            if (_loggedInUser != null && !string.IsNullOrEmpty(_loggedInUser.ImagePath) && File.Exists(_loggedInUser.ImagePath))
            {
                try
                {
                    using (var stream = new FileStream(_loggedInUser.ImagePath, FileMode.Open, FileAccess.Read))
                    {
                        Image userImage = Image.FromStream(stream);
                        userAccount.Image = userImage;
                        userAccount.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show($"Profil şəkli yüklənərkən xəta: {ex.Message}", "Xəta", MessageBoxIcon.Error);
                    userAccount.Image = null;
                }
            }
            else
            {
                userAccount.Image = null;
            }
        }
        private void btnShowHistory_Click(object sender, EventArgs e)
        {
            if (_loggedInUser != null)
            {
                UC_SearchLog searchLogControl = new UC_SearchLog(_loggedInUser.Id);
                addUserControl(searchLogControl);
            }
            else
            {
                CustomMessageBox.Show("Axtarış tarixçəsini görmək üçün əvvəlcə daxil olun.", "Məlumat", MessageBoxIcon.Information);
            }
        }
    }
}
