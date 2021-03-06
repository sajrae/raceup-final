namespace Raceup_Autocare
{
    partial class PrintCopiesForm
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
            this.CustORBTN = new Guna.UI2.WinForms.Guna2Button();
            this.textBoxRONumber = new System.Windows.Forms.TextBox();
            this.TechROBTN = new Guna.UI2.WinForms.Guna2Button();
            this.ModeOfPaymentGroupBox = new Guna.UI2.WinForms.Guna2GroupBox();
            this.JobORBTN = new Guna.UI2.WinForms.Guna2Button();
            this.ModeOfPaymentGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CustORBTN
            // 
            this.CustORBTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CustORBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.CustORBTN.BorderRadius = 13;
            this.CustORBTN.CheckedState.Parent = this.CustORBTN;
            this.CustORBTN.CustomImages.Parent = this.CustORBTN;
            this.CustORBTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(186)))), ((int)(((byte)(58)))));
            this.CustORBTN.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustORBTN.ForeColor = System.Drawing.Color.White;
            this.CustORBTN.HoverState.Parent = this.CustORBTN;
            this.CustORBTN.Location = new System.Drawing.Point(19, 108);
            this.CustORBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CustORBTN.Name = "CustORBTN";
            this.CustORBTN.ShadowDecoration.Parent = this.CustORBTN;
            this.CustORBTN.Size = new System.Drawing.Size(215, 59);
            this.CustORBTN.TabIndex = 12;
            this.CustORBTN.Text = "Customer\'s Copy";
            this.CustORBTN.Click += new System.EventHandler(this.JobORBTN_Click);
            // 
            // textBoxRONumber
            // 
            this.textBoxRONumber.Location = new System.Drawing.Point(3, 4);
            this.textBoxRONumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRONumber.Name = "textBoxRONumber";
            this.textBoxRONumber.Size = new System.Drawing.Size(191, 22);
            this.textBoxRONumber.TabIndex = 13;
            this.textBoxRONumber.Text = "RO Number";
            // 
            // TechROBTN
            // 
            this.TechROBTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TechROBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.TechROBTN.BorderRadius = 13;
            this.TechROBTN.CheckedState.Parent = this.TechROBTN;
            this.TechROBTN.CustomImages.Parent = this.TechROBTN;
            this.TechROBTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(186)))), ((int)(((byte)(58)))));
            this.TechROBTN.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TechROBTN.ForeColor = System.Drawing.Color.White;
            this.TechROBTN.HoverState.Parent = this.TechROBTN;
            this.TechROBTN.Location = new System.Drawing.Point(464, 108);
            this.TechROBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TechROBTN.Name = "TechROBTN";
            this.TechROBTN.ShadowDecoration.Parent = this.TechROBTN;
            this.TechROBTN.Size = new System.Drawing.Size(215, 59);
            this.TechROBTN.TabIndex = 15;
            this.TechROBTN.Text = "Technician";
            this.TechROBTN.Click += new System.EventHandler(this.TechROBTN_Click);
            // 
            // ModeOfPaymentGroupBox
            // 
            this.ModeOfPaymentGroupBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ModeOfPaymentGroupBox.BorderThickness = 2;
            this.ModeOfPaymentGroupBox.Controls.Add(this.JobORBTN);
            this.ModeOfPaymentGroupBox.Controls.Add(this.TechROBTN);
            this.ModeOfPaymentGroupBox.Controls.Add(this.CustORBTN);
            this.ModeOfPaymentGroupBox.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ModeOfPaymentGroupBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ModeOfPaymentGroupBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeOfPaymentGroupBox.ForeColor = System.Drawing.Color.White;
            this.ModeOfPaymentGroupBox.Location = new System.Drawing.Point(57, 15);
            this.ModeOfPaymentGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ModeOfPaymentGroupBox.Name = "ModeOfPaymentGroupBox";
            this.ModeOfPaymentGroupBox.ShadowDecoration.Parent = this.ModeOfPaymentGroupBox;
            this.ModeOfPaymentGroupBox.Size = new System.Drawing.Size(699, 220);
            this.ModeOfPaymentGroupBox.TabIndex = 138;
            this.ModeOfPaymentGroupBox.Text = "Click the button for the copies";
            this.ModeOfPaymentGroupBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ModeOfPaymentGroupBox.Click += new System.EventHandler(this.ModeOfPaymentGroupBox_Click);
            // 
            // JobORBTN
            // 
            this.JobORBTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.JobORBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.JobORBTN.BorderRadius = 13;
            this.JobORBTN.CheckedState.Parent = this.JobORBTN;
            this.JobORBTN.CustomImages.Parent = this.JobORBTN;
            this.JobORBTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(186)))), ((int)(((byte)(58)))));
            this.JobORBTN.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JobORBTN.ForeColor = System.Drawing.Color.White;
            this.JobORBTN.HoverState.Parent = this.JobORBTN;
            this.JobORBTN.Location = new System.Drawing.Point(241, 108);
            this.JobORBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.JobORBTN.Name = "JobORBTN";
            this.JobORBTN.ShadowDecoration.Parent = this.JobORBTN;
            this.JobORBTN.Size = new System.Drawing.Size(215, 59);
            this.JobORBTN.TabIndex = 14;
            this.JobORBTN.Text = "Job Order";
            this.JobORBTN.Click += new System.EventHandler(this.JobORBTN_Click_1);
            // 
            // PrintCopiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(815, 271);
            this.Controls.Add(this.ModeOfPaymentGroupBox);
            this.Controls.Add(this.textBoxRONumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PrintCopiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Copies Form";
            this.Load += new System.EventHandler(this.PrintCopiesForm_Load);
            this.ModeOfPaymentGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button CustORBTN;
        private Guna.UI2.WinForms.Guna2Button TechROBTN;
        private Guna.UI2.WinForms.Guna2GroupBox ModeOfPaymentGroupBox;
        public System.Windows.Forms.TextBox textBoxRONumber;
        private Guna.UI2.WinForms.Guna2Button JobORBTN;
    }
}