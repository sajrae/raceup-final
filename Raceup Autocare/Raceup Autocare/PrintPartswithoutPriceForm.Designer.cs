namespace Raceup_Autocare
{
    partial class PrintPartswithoutPriceForm
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ROnumberLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Raceup_Autocare.ReportOrderPartsWithoutPrice.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(26, 52);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(834, 465);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load_1);
            // 
            // ROnumberLabel
            // 
            this.ROnumberLabel.BackColor = System.Drawing.Color.Transparent;
            this.ROnumberLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROnumberLabel.ForeColor = System.Drawing.Color.Lime;
            this.ROnumberLabel.Location = new System.Drawing.Point(26, 12);
            this.ROnumberLabel.Name = "ROnumberLabel";
            this.ROnumberLabel.Size = new System.Drawing.Size(78, 34);
            this.ROnumberLabel.TabIndex = 189;
            this.ROnumberLabel.Text = "Result";
            // 
            // PrintPartswithoutPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 547);
            this.Controls.Add(this.ROnumberLabel);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PrintPartswithoutPriceForm";
            this.Text = "PrintPartswithoutPriceForm";
            this.Load += new System.EventHandler(this.PrintPartswithoutPriceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public Guna.UI2.WinForms.Guna2HtmlLabel ROnumberLabel;
    }
}