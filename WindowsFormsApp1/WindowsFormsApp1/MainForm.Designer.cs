namespace WindowsFormsApp1
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.userAccount = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.minizimeTab = new Guna.UI2.WinForms.Guna2ControlBox();
            this.closeTab = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.sideMenuPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.btnShowHistory = new Guna.UI2.WinForms.Guna2Button();
            this.btnSearchPhoto = new Guna.UI2.WinForms.Guna2Button();
            this.mainContextPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAccount)).BeginInit();
            this.sideMenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 34);
            this.label1.TabIndex = 4;
            this.label1.Text = "NEORİCA";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.userAccount);
            this.guna2Panel2.Controls.Add(this.minizimeTab);
            this.guna2Panel2.Controls.Add(this.closeTab);
            this.guna2Panel2.Controls.Add(this.label1);
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1100, 54);
            this.guna2Panel2.TabIndex = 5;
            // 
            // userAccount
            // 
            this.userAccount.ImageRotate = 0F;
            this.userAccount.Location = new System.Drawing.Point(954, 7);
            this.userAccount.Name = "userAccount";
            this.userAccount.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.userAccount.Size = new System.Drawing.Size(40, 40);
            this.userAccount.TabIndex = 18;
            this.userAccount.TabStop = false;
            this.userAccount.Click += new System.EventHandler(this.userAccount_Click_1);
            // 
            // minizimeTab
            // 
            this.minizimeTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minizimeTab.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.minizimeTab.FillColor = System.Drawing.Color.Transparent;
            this.minizimeTab.IconColor = System.Drawing.Color.White;
            this.minizimeTab.Location = new System.Drawing.Point(1005, 10);
            this.minizimeTab.Name = "minizimeTab";
            this.minizimeTab.Size = new System.Drawing.Size(45, 29);
            this.minizimeTab.TabIndex = 6;
            // 
            // closeTab
            // 
            this.closeTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeTab.FillColor = System.Drawing.Color.Transparent;
            this.closeTab.HoverState.FillColor = System.Drawing.Color.Red;
            this.closeTab.IconColor = System.Drawing.Color.White;
            this.closeTab.Location = new System.Drawing.Point(1043, 10);
            this.closeTab.Name = "closeTab";
            this.closeTab.Size = new System.Drawing.Size(45, 29);
            this.closeTab.TabIndex = 5;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.guna2Panel2;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // sideMenuPanel
            // 
            this.sideMenuPanel.BackColor = System.Drawing.Color.Transparent;
            this.sideMenuPanel.BorderColor = System.Drawing.Color.Transparent;
            this.sideMenuPanel.BorderRadius = 15;
            this.sideMenuPanel.Controls.Add(this.btnShowHistory);
            this.sideMenuPanel.Controls.Add(this.btnSearchPhoto);
            this.sideMenuPanel.FillColor = System.Drawing.Color.Transparent;
            this.sideMenuPanel.Location = new System.Drawing.Point(12, 150);
            this.sideMenuPanel.Name = "sideMenuPanel";
            this.sideMenuPanel.Size = new System.Drawing.Size(68, 352);
            this.sideMenuPanel.TabIndex = 0;
            // 
            // btnShowHistory
            // 
            this.btnShowHistory.BorderRadius = 20;
            this.btnShowHistory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShowHistory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShowHistory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShowHistory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShowHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShowHistory.ForeColor = System.Drawing.Color.White;
            this.btnShowHistory.Image = global::WindowsFormsApp1.Properties.Resources.writing;
            this.btnShowHistory.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnShowHistory.Location = new System.Drawing.Point(14, 194);
            this.btnShowHistory.Name = "btnShowHistory";
            this.btnShowHistory.Size = new System.Drawing.Size(40, 40);
            this.btnShowHistory.TabIndex = 16;
            this.btnShowHistory.Click += new System.EventHandler(this.btnShowHistory_Click);
            // 
            // btnSearchPhoto
            // 
            this.btnSearchPhoto.BorderRadius = 20;
            this.btnSearchPhoto.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchPhoto.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearchPhoto.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearchPhoto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearchPhoto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSearchPhoto.ForeColor = System.Drawing.Color.White;
            this.btnSearchPhoto.Image = global::WindowsFormsApp1.Properties.Resources.icons8_ai_48;
            this.btnSearchPhoto.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSearchPhoto.Location = new System.Drawing.Point(14, 118);
            this.btnSearchPhoto.Name = "btnSearchPhoto";
            this.btnSearchPhoto.Size = new System.Drawing.Size(40, 40);
            this.btnSearchPhoto.TabIndex = 15;
            this.btnSearchPhoto.Click += new System.EventHandler(this.btnSearchPhoto_Click_1);
            // 
            // mainContextPanel
            // 
            this.mainContextPanel.Location = new System.Drawing.Point(117, 81);
            this.mainContextPanel.Name = "mainContextPanel";
            this.mainContextPanel.Size = new System.Drawing.Size(943, 491);
            this.mainContextPanel.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.mainContextPanel);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.sideMenuPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userAccount)).EndInit();
            this.sideMenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2ControlBox minizimeTab;
        private Guna.UI2.WinForms.Guna2ControlBox closeTab;
        private Guna.UI2.WinForms.Guna2Panel sideMenuPanel;
        private Guna.UI2.WinForms.Guna2Button btnSearchPhoto;
        private Guna.UI2.WinForms.Guna2Panel mainContextPanel;
        private Guna.UI2.WinForms.Guna2CirclePictureBox userAccount;
        private Guna.UI2.WinForms.Guna2Button btnShowHistory;
    }
}