namespace WindowsFormsApp1
{
    partial class AuthForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.contentPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.loginPageButton = new Guna.UI2.WinForms.Guna2GradientButton();
            this.minizimeTab = new Guna.UI2.WinForms.Guna2ControlBox();
            this.closeTab = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.registerPageButton = new Guna.UI2.WinForms.Guna2GradientButton();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.contentPanel;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.loginPageButton);
            this.contentPanel.Controls.Add(this.minizimeTab);
            this.contentPanel.Controls.Add(this.closeTab);
            this.contentPanel.Controls.Add(this.label1);
            this.contentPanel.Controls.Add(this.guna2CirclePictureBox1);
            this.contentPanel.Controls.Add(this.registerPageButton);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.contentPanel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(59)))), ((int)(((byte)(85)))));
            this.contentPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.contentPanel.Location = new System.Drawing.Point(0, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(550, 750);
            this.contentPanel.TabIndex = 13;
            // 
            // loginPageButton
            // 
            this.loginPageButton.BackColor = System.Drawing.Color.Transparent;
            this.loginPageButton.BorderRadius = 18;
            this.loginPageButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.loginPageButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.loginPageButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.loginPageButton.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.loginPageButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.loginPageButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(59)))), ((int)(((byte)(85)))));
            this.loginPageButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.loginPageButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginPageButton.ForeColor = System.Drawing.Color.White;
            this.loginPageButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.loginPageButton.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.loginPageButton.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.loginPageButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(18)))));
            this.loginPageButton.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(62)))), ((int)(((byte)(85)))));
            this.loginPageButton.Location = new System.Drawing.Point(77, 493);
            this.loginPageButton.Name = "loginPageButton";
            this.loginPageButton.Size = new System.Drawing.Size(396, 45);
            this.loginPageButton.TabIndex = 15;
            this.loginPageButton.Text = "Login";
            this.loginPageButton.Click += new System.EventHandler(this.loginPageButton_Click);
            // 
            // minizimeTab
            // 
            this.minizimeTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minizimeTab.BackColor = System.Drawing.Color.Transparent;
            this.minizimeTab.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.minizimeTab.FillColor = System.Drawing.Color.Transparent;
            this.minizimeTab.IconColor = System.Drawing.Color.White;
            this.minizimeTab.Location = new System.Drawing.Point(449, 8);
            this.minizimeTab.Name = "minizimeTab";
            this.minizimeTab.Size = new System.Drawing.Size(45, 29);
            this.minizimeTab.TabIndex = 14;
            // 
            // closeTab
            // 
            this.closeTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeTab.BackColor = System.Drawing.Color.Transparent;
            this.closeTab.FillColor = System.Drawing.Color.Transparent;
            this.closeTab.HoverState.FillColor = System.Drawing.Color.Red;
            this.closeTab.HoverState.IconColor = System.Drawing.Color.White;
            this.closeTab.IconColor = System.Drawing.Color.White;
            this.closeTab.Location = new System.Drawing.Point(500, 8);
            this.closeTab.Name = "closeTab";
            this.closeTab.Size = new System.Drawing.Size(45, 29);
            this.closeTab.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 34);
            this.label1.TabIndex = 12;
            this.label1.Text = "NEORİCA";
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.ErrorImage = global::WindowsFormsApp1.Properties.Resources.errorImage;
            this.guna2CirclePictureBox1.Image = global::WindowsFormsApp1.Properties.Resources._224356241;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(150, 143);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(250, 250);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 5;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // registerPageButton
            // 
            this.registerPageButton.BackColor = System.Drawing.Color.Transparent;
            this.registerPageButton.BorderRadius = 18;
            this.registerPageButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.registerPageButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.registerPageButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.registerPageButton.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.registerPageButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.registerPageButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(59)))), ((int)(((byte)(85)))));
            this.registerPageButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.registerPageButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerPageButton.ForeColor = System.Drawing.Color.White;
            this.registerPageButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.registerPageButton.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.registerPageButton.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.registerPageButton.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(18)))));
            this.registerPageButton.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(62)))), ((int)(((byte)(85)))));
            this.registerPageButton.Location = new System.Drawing.Point(77, 563);
            this.registerPageButton.Name = "registerPageButton";
            this.registerPageButton.Size = new System.Drawing.Size(396, 45);
            this.registerPageButton.TabIndex = 3;
            this.registerPageButton.Text = "Register";
            this.registerPageButton.Click += new System.EventHandler(this.registerPageButton_Click_1);
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(550, 750);
            this.Controls.Add(this.contentPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuthForm";
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2GradientPanel contentPanel;
        private Guna.UI2.WinForms.Guna2GradientButton loginPageButton;
        private Guna.UI2.WinForms.Guna2ControlBox minizimeTab;
        private Guna.UI2.WinForms.Guna2ControlBox closeTab;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2GradientButton registerPageButton;
    }
}