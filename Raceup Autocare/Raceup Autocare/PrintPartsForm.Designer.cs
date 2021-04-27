using System.Runtime.CompilerServices;

namespace Raceup_Autocare
{
    partial class PrintPartsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintPartsForm));
            this.RepairOrder_Query1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ROnumberLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Customer_ProfileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.RepairOrder_Query1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_ProfileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ROnumberLabel
            // 
            this.ROnumberLabel.BackColor = System.Drawing.Color.Transparent;
            this.ROnumberLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROnumberLabel.ForeColor = System.Drawing.Color.Lime;
            this.ROnumberLabel.Location = new System.Drawing.Point(26, 12);
            this.ROnumberLabel.Name = "ROnumberLabel";
            this.ROnumberLabel.Size = new System.Drawing.Size(78, 34);
            this.ROnumberLabel.TabIndex = 188;
            this.ROnumberLabel.Text = "Result";
            this.ROnumberLabel.Click += new System.EventHandler(this.ROnumberLabel_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Raceup_Autocare.ReportOrderParts.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(26, 52);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(834, 465);
            this.reportViewer1.TabIndex = 189;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // PrintPartsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 547);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.ROnumberLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrintPartsForm";
            this.Text = "PrintForm";
            this.Load += new System.EventHandler(this.PrintForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RepairOrder_Query1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_ProfileBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource RepairOrder_Query1BindingSource;
        public Guna.UI2.WinForms.Guna2HtmlLabel ROnumberLabel;
        private System.Windows.Forms.BindingSource Customer_ProfileBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}