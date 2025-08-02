using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.UserControls;
using WindowsFormsApp1.Entities.Auth;
using WindowsFormsApp1.Helpers;
using WindowsFormsApp1.Contexts;
using System.Data.Entity;
using static WindowsFormsApp1.Enums.AuthFormInitialPages;

namespace WindowsFormsApp1
{
    public partial class AuthForm : Form
    {

        private UC_Login currentLoginControl;
        private UC_RegisterUser currentRegisterControl;
        private UC_Account currentAccountControl;

        private RegisterEntity _initialUserForAccountPage;

        public AuthForm()
        {
            InitializeComponent();
        }

        public AuthForm(AuthFormInitialPage initialPage, RegisterEntity user = null)
        {
            InitializeComponent();
            _initialUserForAccountPage = user;

            switch (initialPage)
            {
                case AuthFormInitialPage.Login:
                    ShowLoginPage();
                    break;
                case AuthFormInitialPage.Register:
                    ShowRegisterPage();
                    break;
                case AuthFormInitialPage.Account:
                    ShowAccountPageOnAuthForm();
                    break;
                default:
                    ShowLoginPage();
                    break;
            }
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void ShowLoginPage()
        {
            if (currentLoginControl != null)
            {
                currentLoginControl.Dispose();
            }

            currentLoginControl = new UC_Login();
            currentLoginControl.LoginSuccess += UcLogin1_LoginSuccess;
            currentLoginControl.BackToMainPageRequested += LoginControl_BackToMainPageRequested;
            addUserControl(currentLoginControl);
        }

        private void ShowRegisterPage()
        {
            if (currentRegisterControl != null)
            {
                currentRegisterControl.Dispose();
            }

            currentRegisterControl = new UC_RegisterUser();
            currentRegisterControl.RegistrationSuccess += RegisterUser_RegistrationSuccess;
            currentRegisterControl.BackToMainPageRequested += RegisterControl_BackToMainPageRequested;
            addUserControl(currentRegisterControl);
        }

        private void ShowAccountPageOnAuthForm()
        {
            if (_initialUserForAccountPage == null)
            {
                CustomMessageBox.Show("Hesab məlumatları tapılmadı. Zəhmət olmasa daxil olun.", "Xəta", MessageBoxIcon.Error);
                ShowLoginPage();
                return;
            }

            if (currentAccountControl != null)
            {
                currentAccountControl.Dispose();
            }

            currentAccountControl = new UC_Account();
            currentAccountControl.Dock = DockStyle.Fill;
            currentAccountControl.SetUserData(_initialUserForAccountPage);

            addUserControl(currentAccountControl);
        }

        private void registerPageButton_Click_1(object sender, EventArgs e)
        {
            ShowRegisterPage();
        }

        private void RegisterUser_RegistrationSuccess(object sender, EventArgs e)
        {
            ShowLoginPage();
        }

        private void loginPageButton_Click(object sender, EventArgs e)
        {
            ShowLoginPage();
        }

        private async void UcLogin1_LoginSuccess(object sender, string username)
        {
            CustomMessageBox.Show($"Giriş uğurludur! Xoş gəldin, {username}!", "Uğur", MessageBoxIcon.Information);

            if (currentLoginControl != null)
            {
                currentLoginControl.Dispose();
            }

            RegisterEntity loggedInUser;
            using (var context = new AppDbContext())
            {
                loggedInUser = await context.RegisterEntities.FirstOrDefaultAsync(u => u.Username == username);
            }

            if (loggedInUser != null)
            {
                MainForm mainForm = new MainForm(loggedInUser);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                CustomMessageBox.Show("Giriş uğurlu oldu, lakin istifadəçi məlumatları bazada tapılmadı. Zəhmət olmasa yenidən cəhd edin.", "Xəta", MessageBoxIcon.Error);
            }
        }

        private void LoginControl_BackToMainPageRequested(object sender, EventArgs e)
        {
            ShowRegisterPage();
        }

        private void RegisterControl_BackToMainPageRequested(object sender, EventArgs e)
        {
            ShowLoginPage();
        }
    }
}
