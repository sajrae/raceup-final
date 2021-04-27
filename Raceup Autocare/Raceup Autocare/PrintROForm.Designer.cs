namespace Raceup_Autocare
{
    partial class PrintROForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintROForm));
            this.QTNROInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QTNRODataSet = new Raceup_Autocare.QTNRODataSet();
            this.ROLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.RONumberLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.QTNROInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QTNRODataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // QTNROInfoBindingSource
            // 
            this.QTNROInfoBindingSource.DataSource = this.QTNRODataSet;
            this.QTNROInfoBindingSource.Position = 0;
            // 
            // QTNRODataSet
            // 
            this.QTNRODataSet.DataSetName = "QTNRODataSet";
            this.QTNRODataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ROLabel
            // 
            this.ROLabel.BackColor = System.Drawing.Color.Transparent;
            this.ROLabel.Location = new System.Drawing.Point(0, 0);
            this.ROLabel.Name = "ROLabel";
            this.ROLabel.Size = new System.Drawing.Size(0, 0);
            this.ROLabel.TabIndex = 192;
            this.ROLabel.Text = null;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "QTNROAllInfo";
            reportDataSource1.Value = this.QTNROInfoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Raceup_Autocare.ReportRO.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(26, 52);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(834, 465);
            this.reportViewer1.TabIndex = 191;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // RONumberLabel
            // 
            this.RONumberLabel.AutoSize = true;
            this.RONumberLabel.Location = new System.Drawing.Point(23, 19);
            this.RONumberLabel.Name = "RONumberLabel";
            this.RONumberLabel.Size = new System.Drawing.Size(49, 13);
            this.RONumberLabel.TabIndex = 193;
            this.RONumberLabel.Text = "ROLabel";
            // 
            // PrintROForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 547);
            this.Controls.Add(this.RONumberLabel);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.ROLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrintROForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintROForm";
            this.Load += new System.EventHandler(this.PrintROForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QTNROInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QTNRODataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2HtmlLabel ROLabel;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource QTNROInfoBindingSource;
        private QTNRODataSet QTNRODataSet;
        private System.Windows.Forms.Label RONumberLabel;
    }
}