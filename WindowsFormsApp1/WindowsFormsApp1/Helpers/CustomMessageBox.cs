using System.Drawing;
using System.Windows.Forms;

public static class CustomMessageBox
{
    public static void Show(string message, string title = "Xəta", MessageBoxIcon icon = MessageBoxIcon.None)
    {
        Form msgForm = new Form();
        msgForm.StartPosition = FormStartPosition.CenterScreen;
        msgForm.Size = new Size(350, 180);
        msgForm.BackColor = Color.FromArgb(18, 18, 18);
        msgForm.FormBorderStyle = FormBorderStyle.FixedDialog;
        msgForm.MaximizeBox = false;
        msgForm.MinimizeBox = false;
        msgForm.ShowIcon = false;
        msgForm.ShowInTaskbar = false;
        msgForm.Text = title;

        Label messageLabel = new Label()
        {
            Text = message,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Segoe UI", 10),
            ForeColor = Color.White
        };
        msgForm.Controls.Add(messageLabel);

        Button okButton = new Button()
        {
            Text = "OK",
            Dock = DockStyle.Bottom,
            Height = 30,
            BackColor = Color.FromArgb(35, 59, 85),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };
        okButton.FlatAppearance.BorderSize = 0;
        okButton.Click += (s, e) => msgForm.Close();

        msgForm.Controls.Add(okButton);

        if (icon != MessageBoxIcon.None)
        {
            PictureBox iconBox = new PictureBox()
            {
                Size = new Size(48, 48),
                Location = new Point(20, 20)
            };

            switch (icon)
            {
                case MessageBoxIcon.Warning:
                    iconBox.Image = SystemIcons.Warning.ToBitmap();
                    break;
                case MessageBoxIcon.Error:
                    iconBox.Image = SystemIcons.Error.ToBitmap();
                    break;
                case MessageBoxIcon.Information:
                    iconBox.Image = SystemIcons.Information.ToBitmap();
                    break;
                case MessageBoxIcon.Question:
                    iconBox.Image = SystemIcons.Question.ToBitmap();
                    break;
            }

            msgForm.Controls.Add(iconBox);
            messageLabel.Padding = new Padding(80, 20, 10, 10);
            messageLabel.TextAlign = ContentAlignment.TopLeft;
        }

        msgForm.ShowDialog();
    }

}
