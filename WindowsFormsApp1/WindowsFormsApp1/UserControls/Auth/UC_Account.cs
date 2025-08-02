using System;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApp1.Entities.Auth;

namespace WindowsFormsApp1.UserControls
{
    public partial class UC_Account : UserControl
    {
        private RegisterEntity _currentUser;
        private UC_UpdateAccount _updateAccountControl;

        public UC_Account()
        {
            InitializeComponent();
        }

        public void SetUserData(RegisterEntity user)
        {
            _currentUser = user;
            DisplayUserData();
        }

        private void DisplayUserData()
        {
            if (_currentUser != null)
            {
                username.Text = $"İstifadəçi Adı: {_currentUser.Username}";
                userEmail.Text = $"Email: {_currentUser.Email}";
                userRole.Text = $"Rol: {_currentUser.Role}";
                createDate.Text = $"Qeydiyyat Tarixi: {_currentUser.SavedAt.ToShortDateString()}";

                if (!string.IsNullOrEmpty(_currentUser.ImagePath) && File.Exists(_currentUser.ImagePath))
                {
                    try
                    {
                        using (var stream = new FileStream(_currentUser.ImagePath, FileMode.Open, FileAccess.Read))
                        {
                            userPhoto.SizeMode = PictureBoxSizeMode.Zoom;
                            userPhoto.Image = (System.Drawing.Image)System.Drawing.Image.FromStream(stream).Clone();
                        }
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show($"Profil şəkli yüklənərkən xəta: {ex.Message}", "Xəta", MessageBoxIcon.Error);
                        userPhoto.Image = null;
                    }
                }
                else
                {
                    userPhoto.Image = null;
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CustomMessageBox.Show("Çıxış edildi. MainForm-da Logout məntiqini tətbiq edin.", "Məlumat", MessageBoxIcon.Information);
        }

        private void btnUpdateUserAccount_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                CustomMessageBox.Show("İstifadəçi məlumatları yüklənməyib. Update səhifəsi açıla bilməz.", "Xəta", MessageBoxIcon.Error);
                return;
            }
            if (_updateAccountControl != null)
            {
                this.Controls.Remove(_updateAccountControl);
                _updateAccountControl.Dispose();
            }

            _updateAccountControl = new UC_UpdateAccount(_currentUser);
            _updateAccountControl.Dock = DockStyle.Fill;
            _updateAccountControl.UpdateCompleted += UcUpdateAccount_UpdateCompleted;
            this.Controls.Add(_updateAccountControl);
            _updateAccountControl.BringToFront();
        }

        private void UcUpdateAccount_UpdateCompleted(object sender, UC_UpdateAccount.UpdateAccountCompletedEventArgs e)
        {
            if (_updateAccountControl != null)
            {
                this.Controls.Remove(_updateAccountControl);
                _updateAccountControl.Dispose();
                _updateAccountControl = null;
            }

            if (e.Result == DialogResult.OK)
            {
                _currentUser = e.UpdatedUser;
                DisplayUserData();
                CustomMessageBox.Show("Hesab məlumatları uğurla yeniləndi.", "Uğurlu", MessageBoxIcon.Information);
            }
            else if (e.Result == DialogResult.Cancel)
            {
                CustomMessageBox.Show("Məlumat yenilənməsi ləğv edildi.", "Məlumat", MessageBoxIcon.Information);
            }
            else if (e.Result == DialogResult.Abort)
            {
                CustomMessageBox.Show("Hesab məlumatları yüklənərkən xəta baş verdi.", "Xəta", MessageBoxIcon.Error);
            }
        }
    }
}
