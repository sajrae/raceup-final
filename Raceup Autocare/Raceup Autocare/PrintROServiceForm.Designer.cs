namespace Raceup_Autocare
{
    partial class PrintROServiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintROServiceForm));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ROLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Raceup_Autocare.ReportROService.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(41, 59);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(834, 465);
            this.reportViewer1.TabIndex = 193;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // ROLabel
            // 
            this.ROLabel.BackColor = System.Drawing.Color.Transparent;
            this.ROLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROLabel.ForeColor = System.Drawing.Color.Lime;
            this.ROLabel.Location = new System.Drawing.Point(69, 19);
            this.ROLabel.Name = "ROLabel";
            this.ROLabel.Size = new System.Drawing.Size(78, 34);
            this.ROLabel.TabIndex = 192;
            this.ROLabel.Text = "Result";
            // 
            // PrintROServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 547);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.ROLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrintROServiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintROServiceForm";
            this.Load += new System.EventHandler(this.PrintROServiceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public Guna.UI2.WinForms.Guna2HtmlLabel ROLabel;
    }
}