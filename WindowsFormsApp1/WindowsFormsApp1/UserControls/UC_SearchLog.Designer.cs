namespace WindowsFormsApp1.UserControls
{
    partial class UC_SearchLog
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
            this.listViewSearchLogs = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listViewSearchLogs
            // 
            this.listViewSearchLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSearchLogs.HideSelection = false;
            this.listViewSearchLogs.Location = new System.Drawing.Point(0, 0);
            this.listViewSearchLogs.Name = "listViewSearchLogs";
            this.listViewSearchLogs.Size = new System.Drawing.Size(1100, 600);
            this.listViewSearchLogs.TabIndex = 0;
            this.listViewSearchLogs.UseCompatibleStateImageBehavior = false;
            // 
            // UC_SearchLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewSearchLogs);
            this.Name = "UC_SearchLog";
            this.Size = new System.Drawing.Size(1100, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewSearchLogs;
    }
}
