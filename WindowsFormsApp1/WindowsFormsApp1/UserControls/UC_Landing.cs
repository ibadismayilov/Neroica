using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Entities.Auth;

namespace WindowsFormsApp1.UserControls
{
    public partial class UC_Landing : UserControl
    {
        private RegisterEntity _currentUser;

        public UC_Landing()
        {
            InitializeComponent();

            if (lblWelcomeMessage != null)
            {
                lblWelcomeMessage.Text = "Loading...";
                lblWelcomeMessage.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold);
                lblWelcomeMessage.TextAlign = ContentAlignment.MiddleCenter;
                lblWelcomeMessage.Dock = DockStyle.Fill;
                lblWelcomeMessage.ForeColor = Color.White;
            }
        }

        public void SetUserData(RegisterEntity user)
        {
            _currentUser = user;
            DisplayWelcomeMessage();
        }

        private void DisplayWelcomeMessage()
        {
            if (lblWelcomeMessage != null && _currentUser != null)
            {
                lblWelcomeMessage.Text = $"👋 Xoş Gəlmisiniz, {_currentUser.Username}! Bu platforma üz tanıma və şəkil axtarışı kimi qabaqcıl AI funksiyalarını bir araya gətirir. 🚀";
            }
            else if (lblWelcomeMessage != null)
            {
                lblWelcomeMessage.Text = "👋 Xoş Gəlmisiniz! Bu platforma üz tanıma və şəkil axtarışı kimi qabaqcıl AI funksiyalarını bir araya gətirir. Daxil olun və ya qeydiyyatdan keçin! 🚀";
            }
        }
    }
}
