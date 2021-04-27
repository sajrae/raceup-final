namespace Raceup_Autocare
{
    partial class PrintQTNROForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintQTNROForm));
            this.ROLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // ROLabel
            // 
            this.ROLabel.BackColor = System.Drawing.Color.Transparent;
            this.ROLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROLabel.ForeColor = System.Drawing.Color.Lime;
            this.ROLabel.Location = new System.Drawing.Point(55, 12);
            this.ROLabel.Name = "ROLabel";
            this.ROLabel.Size = new System.Drawing.Size(78, 34);
            this.ROLabel.TabIndex = 191;
            this.ROLabel.Text = "Result";
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Raceup_Autocare.ReportQTNRO.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(46, 52);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(834, 465);
            this.reportViewer1.TabIndex = 192;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // PrintQTNROForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 547);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.ROLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrintQTNROForm";
            this.Text = "PrintQTNROForm";
            this.Load += new System.EventHandler(this.PrintQTNROForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2HtmlLabel ROLabel;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}