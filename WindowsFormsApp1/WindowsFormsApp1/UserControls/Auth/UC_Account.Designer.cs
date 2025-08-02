namespace WindowsFormsApp1.UserControls
{
    partial class UC_Account
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
            this.components = new System.ComponentModel.Container();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pnlDisplayInfo = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnUpdateUserAccount = new Guna.UI2.WinForms.Guna2GradientButton();
            this.userRole = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.minizimeTab = new Guna.UI2.WinForms.Guna2ControlBox();
            this.closeTab = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.createDate = new System.Windows.Forms.Label();
            this.userEmail = new System.Windows.Forms.Label();
            this.userPhoto = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnlDisplayInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.pnlDisplayInfo;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // pnlDisplayInfo
            // 
            this.pnlDisplayInfo.Controls.Add(this.btnUpdateUserAccount);
            this.pnlDisplayInfo.Controls.Add(this.userRole);
            this.pnlDisplayInfo.Controls.Add(this.username);
            this.pnlDisplayInfo.Controls.Add(this.minizimeTab);
            this.pnlDisplayInfo.Controls.Add(this.closeTab);
            this.pnlDisplayInfo.Controls.Add(this.label1);
            this.pnlDisplayInfo.Controls.Add(this.createDate);
            this.pnlDisplayInfo.Controls.Add(this.userEmail);
            this.pnlDisplayInfo.Controls.Add(this.userPhoto);
            this.pnlDisplayInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDisplayInfo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.pnlDisplayInfo.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(59)))), ((int)(((byte)(85)))));
            this.pnlDisplayInfo.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.pnlDisplayInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlDisplayInfo.Name = "pnlDisplayInfo";
            this.pnlDisplayInfo.Size = new System.Drawing.Size(550, 750);
            this.pnlDisplayInfo.TabIndex = 4;
            // 
            // btnUpdateUserAccount
            // 
            this.btnUpdateUserAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdateUserAccount.BorderRadius = 18;
            this.btnUpdateUserAccount.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdateUserAccount.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdateUserAccount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdateUserAccount.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdateUserAccount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdateUserAccount.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(59)))), ((int)(((byte)(85)))));
            this.btnUpdateUserAccount.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.btnUpdateUserAccount.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateUserAccount.ForeColor = System.Drawing.Color.White;
            this.btnUpdateUserAccount.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.btnUpdateUserAccount.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btnUpdateUserAccount.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnUpdateUserAccount.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(18)))));
            this.btnUpdateUserAccount.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(62)))), ((int)(((byte)(85)))));
            this.btnUpdateUserAccount.Location = new System.Drawing.Point(56, 564);
            this.btnUpdateUserAccount.Name = "btnUpdateUserAccount";
            this.btnUpdateUserAccount.Size = new System.Drawing.Size(451, 45);
            this.btnUpdateUserAccount.TabIndex = 27;
            this.btnUpdateUserAccount.Text = "Update";
            this.btnUpdateUserAccount.Click += new System.EventHandler(this.btnUpdateUserAccount_Click);
            // 
            // userRole
            // 
            this.userRole.AutoSize = true;
            this.userRole.BackColor = System.Drawing.Color.Transparent;
            this.userRole.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userRole.ForeColor = System.Drawing.Color.White;
            this.userRole.Location = new System.Drawing.Point(52, 432);
            this.userRole.Name = "userRole";
            this.userRole.Size = new System.Drawing.Size(55, 21);
            this.userRole.TabIndex = 26;
            this.userRole.Text = "Role: ";
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.BackColor = System.Drawing.Color.Transparent;
            this.username.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.White;
            this.username.Location = new System.Drawing.Point(52, 339);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(103, 21);
            this.username.TabIndex = 25;
            this.username.Text = "Username: ";
            // 
            // minizimeTab
            // 
            this.minizimeTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minizimeTab.BackColor = System.Drawing.Color.Transparent;
            this.minizimeTab.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.minizimeTab.FillColor = System.Drawing.Color.Transparent;
            this.minizimeTab.IconColor = System.Drawing.Color.White;
            this.minizimeTab.Location = new System.Drawing.Point(449, 10);
            this.minizimeTab.Name = "minizimeTab";
            this.minizimeTab.Size = new System.Drawing.Size(45, 29);
            this.minizimeTab.TabIndex = 21;
            // 
            // closeTab
            // 
            this.closeTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeTab.BackColor = System.Drawing.Color.Transparent;
            this.closeTab.FillColor = System.Drawing.Color.Transparent;
            this.closeTab.HoverState.FillColor = System.Drawing.Color.Red;
            this.closeTab.HoverState.IconColor = System.Drawing.Color.White;
            this.closeTab.IconColor = System.Drawing.Color.White;
            this.closeTab.Location = new System.Drawing.Point(500, 10);
            this.closeTab.Name = "closeTab";
            this.closeTab.Size = new System.Drawing.Size(45, 29);
            this.closeTab.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 34);
            this.label1.TabIndex = 19;
            this.label1.Text = "NEORİCA";
            // 
            // createDate
            // 
            this.createDate.AutoSize = true;
            this.createDate.BackColor = System.Drawing.Color.Transparent;
            this.createDate.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createDate.ForeColor = System.Drawing.Color.White;
            this.createDate.Location = new System.Drawing.Point(52, 474);
            this.createDate.Name = "createDate";
            this.createDate.Size = new System.Drawing.Size(128, 21);
            this.createDate.TabIndex = 16;
            this.createDate.Text = "Create Date: ";
            // 
            // userEmail
            // 
            this.userEmail.AutoSize = true;
            this.userEmail.BackColor = System.Drawing.Color.Transparent;
            this.userEmail.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userEmail.ForeColor = System.Drawing.Color.White;
            this.userEmail.Location = new System.Drawing.Point(52, 386);
            this.userEmail.Name = "userEmail";
            this.userEmail.Size = new System.Drawing.Size(62, 21);
            this.userEmail.TabIndex = 14;
            this.userEmail.Text = "Email: ";
            // 
            // userPhoto
            // 
            this.userPhoto.BackColor = System.Drawing.Color.Transparent;
            this.userPhoto.ImageRotate = 0F;
            this.userPhoto.Location = new System.Drawing.Point(165, 52);
            this.userPhoto.Name = "userPhoto";
            this.userPhoto.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.userPhoto.Size = new System.Drawing.Size(220, 220);
            this.userPhoto.TabIndex = 10;
            this.userPhoto.TabStop = false;
            // 
            // UC_Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.pnlDisplayInfo);
            this.Name = "UC_Account";
            this.Size = new System.Drawing.Size(550, 750);
            this.pnlDisplayInfo.ResumeLayout(false);
            this.pnlDisplayInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlDisplayInfo;
        private System.Windows.Forms.Label username;
        private Guna.UI2.WinForms.Guna2ControlBox minizimeTab;
        private Guna.UI2.WinForms.Guna2ControlBox closeTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label createDate;
        private System.Windows.Forms.Label userEmail;
        private Guna.UI2.WinForms.Guna2CirclePictureBox userPhoto;
        private System.Windows.Forms.Label userRole;
        private Guna.UI2.WinForms.Guna2GradientButton btnUpdateUserAccount;
    }
}
