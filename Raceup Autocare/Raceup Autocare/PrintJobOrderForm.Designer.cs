namespace Raceup_Autocare
{
    partial class PrintJobOrderForm
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
            this.RONumberLabel = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // RONumberLabel
            // 
            this.RONumberLabel.AutoSize = true;
            this.RONumberLabel.Location = new System.Drawing.Point(21, 19);
            this.RONumberLabel.Name = "RONumberLabel";
            this.RONumberLabel.Size = new System.Drawing.Size(49, 13);
            this.RONumberLabel.TabIndex = 195;
            this.RONumberLabel.Text = "ROLabel";
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Raceup_Autocare.ReportJobOrderRO.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(24, 52);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(834, 465);
            this.reportViewer1.TabIndex = 194;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load_1);
            // 
            // PrintJobOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 547);
            this.Controls.Add(this.RONumberLabel);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PrintJobOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintJobOrderForm";
            this.Load += new System.EventHandler(this.PrintJobOrderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RONumberLabel;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}