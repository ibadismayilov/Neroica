namespace WindowsFormsApp1.UserControls
{
    partial class UC_VerifyEmailOTP
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.txtOtpCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.btnVerify = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnResendOtp = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnCancel = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.Controls.Add(this.btnCancel);
            this.guna2GradientPanel1.Controls.Add(this.btnResendOtp);
            this.guna2GradientPanel1.Controls.Add(this.btnVerify);
            this.guna2GradientPanel1.Controls.Add(this.txtOtpCode);
            this.guna2GradientPanel1.Controls.Add(this.lblInstruction);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(59)))), ((int)(((byte)(85)))));
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(550, 750);
            this.guna2GradientPanel1.TabIndex = 5;
            // 
            // txtOtpCode
            // 
            this.txtOtpCode.BorderRadius = 6;
            this.txtOtpCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOtpCode.DefaultText = "";
            this.txtOtpCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOtpCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOtpCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOtpCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOtpCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOtpCode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtOtpCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOtpCode.Location = new System.Drawing.Point(114, 296);
            this.txtOtpCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOtpCode.Name = "txtOtpCode";
            this.txtOtpCode.PlaceholderText = "";
            this.txtOtpCode.SelectedText = "";
            this.txtOtpCode.Size = new System.Drawing.Size(322, 48);
            this.txtOtpCode.TabIndex = 6;
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.ForeColor = System.Drawing.Color.White;
            this.lblInstruction.Location = new System.Drawing.Point(35, 232);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(481, 19);
            this.lblInstruction.TabIndex = 5;
            this.lblInstruction.Text = "Email ünvanınıza göndərilən 6 rəqəmli doğrulama kodunu daxil edin:";
            // 
            // btnVerify
            // 
            this.btnVerify.BackColor = System.Drawing.Color.Transparent;
            this.btnVerify.BorderRadius = 18;
            this.btnVerify.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnVerify.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnVerify.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnVerify.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnVerify.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnVerify.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(59)))), ((int)(((byte)(85)))));
            this.btnVerify.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnVerify.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.ForeColor = System.Drawing.Color.White;
            this.btnVerify.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnVerify.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnVerify.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnVerify.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(18)))));
            this.btnVerify.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(62)))), ((int)(((byte)(85)))));
            this.btnVerify.Location = new System.Drawing.Point(39, 388);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(180, 45);
            this.btnVerify.TabIndex = 16;
            this.btnVerify.Text = "Təstiqlə";
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnResendOtp
            // 
            this.btnResendOtp.BackColor = System.Drawing.Color.Transparent;
            this.btnResendOtp.BorderRadius = 18;
            this.btnResendOtp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnResendOtp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnResendOtp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnResendOtp.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnResendOtp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnResendOtp.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(59)))), ((int)(((byte)(85)))));
            this.btnResendOtp.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnResendOtp.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResendOtp.ForeColor = System.Drawing.Color.White;
            this.btnResendOtp.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnResendOtp.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnResendOtp.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnResendOtp.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(18)))));
            this.btnResendOtp.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(62)))), ((int)(((byte)(85)))));
            this.btnResendOtp.Location = new System.Drawing.Point(336, 388);
            this.btnResendOtp.Name = "btnResendOtp";
            this.btnResendOtp.Size = new System.Drawing.Size(180, 45);
            this.btnResendOtp.TabIndex = 17;
            this.btnResendOtp.Text = "Yenidən göndər";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderRadius = 18;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(59)))), ((int)(((byte)(85)))));
            this.btnCancel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnCancel.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(18)))));
            this.btnCancel.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(62)))), ((int)(((byte)(85)))));
            this.btnCancel.Location = new System.Drawing.Point(171, 474);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 45);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Ləğv et";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // UC_VerifyEmailOTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "UC_VerifyEmailOTP";
            this.Size = new System.Drawing.Size(550, 750);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2TextBox txtOtpCode;
        private System.Windows.Forms.Label lblInstruction;
        private Guna.UI2.WinForms.Guna2GradientButton btnVerify;
        private Guna.UI2.WinForms.Guna2GradientButton btnCancel;
        private Guna.UI2.WinForms.Guna2GradientButton btnResendOtp;
    }
}
