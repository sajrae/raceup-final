namespace Raceup_Autocare
{
    partial class RepairOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepairOrderForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OpenRORadioButton = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.TotalROText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ClearBtn = new Guna.UI2.WinForms.Guna2Button();
            this.CroSearchButton = new Guna.UI2.WinForms.Guna2Button();
            this.ModeOfPaymentGroupBox = new Guna.UI2.WinForms.Guna2GroupBox();
            this.ClosedRORadioButton = new System.Windows.Forms.RadioButton();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.SearchPrtsTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.RepairOrderDGV = new Guna.UI2.WinForms.Guna2DataGridView();
            this.View = new System.Windows.Forms.DataGridViewButtonColumn();
            this.OpenClosedRO = new System.Windows.Forms.Label();
            this.rONumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plateNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RepairOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelDesktop.SuspendLayout();
            this.ModeOfPaymentGroupBox.SuspendLayout();
            this.guna2ShadowPanel1.SuspendLayout();
            this.guna2GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RepairOrderDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepairOrderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenRORadioButton
            // 
            this.OpenRORadioButton.AutoSize = true;
            this.OpenRORadioButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenRORadioButton.Location = new System.Drawing.Point(22, 55);
            this.OpenRORadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.OpenRORadioButton.Name = "OpenRORadioButton";
            this.OpenRORadioButton.Size = new System.Drawing.Size(101, 25);
            this.OpenRORadioButton.TabIndex = 132;
            this.OpenRORadioButton.TabStop = true;
            this.OpenRORadioButton.Text = "Open RO";
            this.OpenRORadioButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1284, 75);
            this.panel2.TabIndex = 147;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(22)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 58);
            this.panel1.TabIndex = 113;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(198, 36);
            this.label7.TabIndex = 0;
            this.label7.Text = "Repair Order";
            // 
            // panelDesktop
            // 
            this.panelDesktop.AutoScroll = true;
            this.panelDesktop.Controls.Add(this.OpenClosedRO);
            this.panelDesktop.Controls.Add(this.TotalROText);
            this.panelDesktop.Controls.Add(this.label1);
            this.panelDesktop.Controls.Add(this.ClearBtn);
            this.panelDesktop.Controls.Add(this.CroSearchButton);
            this.panelDesktop.Controls.Add(this.ModeOfPaymentGroupBox);
            this.panelDesktop.Controls.Add(this.guna2ShadowPanel1);
            this.panelDesktop.Controls.Add(this.guna2GroupBox2);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(0, 75);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1284, 628);
            this.panelDesktop.TabIndex = 149;
            // 
            // TotalROText
            // 
            this.TotalROText.AutoSize = true;
            this.TotalROText.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalROText.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TotalROText.Location = new System.Drawing.Point(208, 86);
            this.TotalROText.Name = "TotalROText";
            this.TotalROText.Size = new System.Drawing.Size(47, 45);
            this.TotalROText.TabIndex = 1;
            this.TotalROText.Text = "#";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(25, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Count:";
            // 
            // ClearBtn
            // 
            this.ClearBtn.BorderRadius = 5;
            this.ClearBtn.CheckedState.Parent = this.ClearBtn;
            this.ClearBtn.CustomImages.Parent = this.ClearBtn;
            this.ClearBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(45)))), ((int)(((byte)(71)))));
            this.ClearBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.ForeColor = System.Drawing.Color.White;
            this.ClearBtn.HoverState.Parent = this.ClearBtn;
            this.ClearBtn.Location = new System.Drawing.Point(770, 13);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.ShadowDecoration.Parent = this.ClearBtn;
            this.ClearBtn.Size = new System.Drawing.Size(94, 59);
            this.ClearBtn.TabIndex = 164;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // CroSearchButton
            // 
            this.CroSearchButton.BorderRadius = 5;
            this.CroSearchButton.CheckedState.Parent = this.CroSearchButton;
            this.CroSearchButton.CustomImages.Parent = this.CroSearchButton;
            this.CroSearchButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(45)))), ((int)(((byte)(71)))));
            this.CroSearchButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CroSearchButton.ForeColor = System.Drawing.Color.White;
            this.CroSearchButton.HoverState.Parent = this.CroSearchButton;
            this.CroSearchButton.Location = new System.Drawing.Point(679, 13);
            this.CroSearchButton.Name = "CroSearchButton";
            this.CroSearchButton.ShadowDecoration.Parent = this.CroSearchButton;
            this.CroSearchButton.Size = new System.Drawing.Size(85, 59);
            this.CroSearchButton.TabIndex = 163;
            this.CroSearchButton.Text = "Search";
            this.CroSearchButton.Click += new System.EventHandler(this.CroSearchButton_Click);
            // 
            // ModeOfPaymentGroupBox
            // 
            this.ModeOfPaymentGroupBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ModeOfPaymentGroupBox.BorderThickness = 2;
            this.ModeOfPaymentGroupBox.Controls.Add(this.ClosedRORadioButton);
            this.ModeOfPaymentGroupBox.Controls.Add(this.OpenRORadioButton);
            this.ModeOfPaymentGroupBox.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ModeOfPaymentGroupBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ModeOfPaymentGroupBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeOfPaymentGroupBox.ForeColor = System.Drawing.Color.White;
            this.ModeOfPaymentGroupBox.Location = new System.Drawing.Point(870, 6);
            this.ModeOfPaymentGroupBox.Name = "ModeOfPaymentGroupBox";
            this.ModeOfPaymentGroupBox.ShadowDecoration.Parent = this.ModeOfPaymentGroupBox;
            this.ModeOfPaymentGroupBox.Size = new System.Drawing.Size(174, 133);
            this.ModeOfPaymentGroupBox.TabIndex = 148;
            this.ModeOfPaymentGroupBox.Text = "Choose a status";
            // 
            // ClosedRORadioButton
            // 
            this.ClosedRORadioButton.AutoSize = true;
            this.ClosedRORadioButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClosedRORadioButton.Location = new System.Drawing.Point(22, 84);
            this.ClosedRORadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.ClosedRORadioButton.Name = "ClosedRORadioButton";
            this.ClosedRORadioButton.Size = new System.Drawing.Size(109, 25);
            this.ClosedRORadioButton.TabIndex = 134;
            this.ClosedRORadioButton.TabStop = true;
            this.ClosedRORadioButton.Text = "Closed RO";
            this.ClosedRORadioButton.UseVisualStyleBackColor = true;
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.SearchPrtsTextBox);
            this.guna2ShadowPanel1.Controls.Add(this.guna2CircleButton1);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(12, 13);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Padding = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.guna2ShadowPanel1.Radius = 16;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.ShadowDepth = 40;
            this.guna2ShadowPanel1.ShadowShift = 2;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(653, 59);
            this.guna2ShadowPanel1.TabIndex = 147;
            // 
            // SearchPrtsTextBox
            // 
            this.SearchPrtsTextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.SearchPrtsTextBox.BorderRadius = 12;
            this.SearchPrtsTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchPrtsTextBox.DefaultText = "";
            this.SearchPrtsTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.SearchPrtsTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.SearchPrtsTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SearchPrtsTextBox.DisabledState.Parent = this.SearchPrtsTextBox;
            this.SearchPrtsTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SearchPrtsTextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.SearchPrtsTextBox.FocusedState.BorderColor = System.Drawing.Color.Gray;
            this.SearchPrtsTextBox.FocusedState.ForeColor = System.Drawing.Color.White;
            this.SearchPrtsTextBox.FocusedState.Parent = this.SearchPrtsTextBox;
            this.SearchPrtsTextBox.FocusedState.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.SearchPrtsTextBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchPrtsTextBox.ForeColor = System.Drawing.Color.White;
            this.SearchPrtsTextBox.HoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.SearchPrtsTextBox.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.SearchPrtsTextBox.HoverState.ForeColor = System.Drawing.Color.White;
            this.SearchPrtsTextBox.HoverState.Parent = this.SearchPrtsTextBox;
            this.SearchPrtsTextBox.HoverState.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.SearchPrtsTextBox.Location = new System.Drawing.Point(71, 9);
            this.SearchPrtsTextBox.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.SearchPrtsTextBox.Name = "SearchPrtsTextBox";
            this.SearchPrtsTextBox.PasswordChar = '\0';
            this.SearchPrtsTextBox.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.SearchPrtsTextBox.PlaceholderText = "Search RO Number or Plate Number";
            this.SearchPrtsTextBox.SelectedText = "";
            this.SearchPrtsTextBox.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.SearchPrtsTextBox.ShadowDecoration.Parent = this.SearchPrtsTextBox;
            this.SearchPrtsTextBox.Size = new System.Drawing.Size(549, 39);
            this.SearchPrtsTextBox.TabIndex = 115;
            this.SearchPrtsTextBox.TextChanged += new System.EventHandler(this.SearchPrtsTextBox_TextChanged);
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.CheckedState.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.CustomImages.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.HoverState.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CircleButton1.Image")));
            this.guna2CircleButton1.Location = new System.Drawing.Point(19, 6);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.ShadowDecoration.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.Size = new System.Drawing.Size(48, 44);
            this.guna2CircleButton1.TabIndex = 115;
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2GroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.guna2GroupBox2.BorderThickness = 2;
            this.guna2GroupBox2.Controls.Add(this.RepairOrderDGV);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.guna2GroupBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.guna2GroupBox2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox2.Location = new System.Drawing.Point(22, 145);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.ShadowDecoration.Parent = this.guna2GroupBox2;
            this.guna2GroupBox2.Size = new System.Drawing.Size(1223, 443);
            this.guna2GroupBox2.TabIndex = 139;
            this.guna2GroupBox2.Text = "List of Repair Order";
            this.guna2GroupBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RepairOrderDGV
            // 
            this.RepairOrderDGV.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.RepairOrderDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.RepairOrderDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RepairOrderDGV.AutoGenerateColumns = false;
            this.RepairOrderDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RepairOrderDGV.BackgroundColor = System.Drawing.Color.White;
            this.RepairOrderDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RepairOrderDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.RepairOrderDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RepairOrderDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.RepairOrderDGV.ColumnHeadersHeight = 50;
            this.RepairOrderDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rONumberDataGridViewTextBoxColumn,
            this.plateNumberDataGridViewTextBoxColumn,
            this.dateCreatedDataGridViewTextBoxColumn,
            this.createdByDataGridViewTextBoxColumn,
            this.View});
            this.RepairOrderDGV.DataSource = this.RepairOrderBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RepairOrderDGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.RepairOrderDGV.EnableHeadersVisualStyles = false;
            this.RepairOrderDGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.RepairOrderDGV.Location = new System.Drawing.Point(12, 63);
            this.RepairOrderDGV.Name = "RepairOrderDGV";
            this.RepairOrderDGV.ReadOnly = true;
            this.RepairOrderDGV.RowHeadersVisible = false;
            this.RepairOrderDGV.RowTemplate.Height = 50;
            this.RepairOrderDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RepairOrderDGV.Size = new System.Drawing.Size(1196, 370);
            this.RepairOrderDGV.TabIndex = 0;
            this.RepairOrderDGV.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            this.RepairOrderDGV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.RepairOrderDGV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.RepairOrderDGV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.RepairOrderDGV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.RepairOrderDGV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.RepairOrderDGV.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.RepairOrderDGV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.RepairOrderDGV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.RepairOrderDGV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.RepairOrderDGV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepairOrderDGV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.RepairOrderDGV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.RepairOrderDGV.ThemeStyle.HeaderStyle.Height = 50;
            this.RepairOrderDGV.ThemeStyle.ReadOnly = true;
            this.RepairOrderDGV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.RepairOrderDGV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.RepairOrderDGV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepairOrderDGV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.RepairOrderDGV.ThemeStyle.RowsStyle.Height = 50;
            this.RepairOrderDGV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            this.RepairOrderDGV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.RepairOrderDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RepairOrderDGV_CellContentClick);
            // 
            // View
            // 
            this.View.FillWeight = 80.78281F;
            this.View.HeaderText = "";
            this.View.Name = "View";
            this.View.ReadOnly = true;
            this.View.Text = "View";
            this.View.UseColumnTextForButtonValue = true;
            // 
            // OpenClosedRO
            // 
            this.OpenClosedRO.AutoSize = true;
            this.OpenClosedRO.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenClosedRO.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.OpenClosedRO.Location = new System.Drawing.Point(260, 90);
            this.OpenClosedRO.Name = "OpenClosedRO";
            this.OpenClosedRO.Size = new System.Drawing.Size(291, 36);
            this.OpenClosedRO.TabIndex = 1;
            this.OpenClosedRO.Text = "(For Open Or close)";
            // 
            // rONumberDataGridViewTextBoxColumn
            // 
            this.rONumberDataGridViewTextBoxColumn.DataPropertyName = "RO_Number";
            this.rONumberDataGridViewTextBoxColumn.FillWeight = 150F;
            this.rONumberDataGridViewTextBoxColumn.HeaderText = "Repair Order Number";
            this.rONumberDataGridViewTextBoxColumn.Name = "rONumberDataGridViewTextBoxColumn";
            this.rONumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // plateNumberDataGridViewTextBoxColumn
            // 
            this.plateNumberDataGridViewTextBoxColumn.DataPropertyName = "Plate_Number";
            this.plateNumberDataGridViewTextBoxColumn.FillWeight = 115F;
            this.plateNumberDataGridViewTextBoxColumn.HeaderText = "Plate Number";
            this.plateNumberDataGridViewTextBoxColumn.Name = "plateNumberDataGridViewTextBoxColumn";
            this.plateNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateCreatedDataGridViewTextBoxColumn
            // 
            this.dateCreatedDataGridViewTextBoxColumn.DataPropertyName = "Date_Created";
            this.dateCreatedDataGridViewTextBoxColumn.HeaderText = "Date Created";
            this.dateCreatedDataGridViewTextBoxColumn.Name = "dateCreatedDataGridViewTextBoxColumn";
            this.dateCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdByDataGridViewTextBoxColumn
            // 
            this.createdByDataGridViewTextBoxColumn.DataPropertyName = "Created_By";
            this.createdByDataGridViewTextBoxColumn.HeaderText = "Created By";
            this.createdByDataGridViewTextBoxColumn.Name = "createdByDataGridViewTextBoxColumn";
            this.createdByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // RepairOrderBindingSource
            // 
            this.RepairOrderBindingSource.DataSource = typeof(Raceup_Autocare.RONotification);
            // 
            // RepairOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(1284, 703);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panel2);
            this.Name = "RepairOrderForm";
            this.Text = "RepairOrderForm";
            this.Load += new System.EventHandler(this.RepairOrderForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDesktop.ResumeLayout(false);
            this.panelDesktop.PerformLayout();
            this.ModeOfPaymentGroupBox.ResumeLayout(false);
            this.ModeOfPaymentGroupBox.PerformLayout();
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RepairOrderDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepairOrderBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelDesktop;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2TextBox SearchPrtsTextBox;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Guna.UI2.WinForms.Guna2DataGridView RepairOrderDGV;
        private Guna.UI2.WinForms.Guna2GroupBox ModeOfPaymentGroupBox;
        private System.Windows.Forms.RadioButton ClosedRORadioButton;
        private Guna.UI2.WinForms.Guna2Button ClearBtn;
        private Guna.UI2.WinForms.Guna2Button CroSearchButton;
        private System.Windows.Forms.BindingSource RepairOrderBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn rONumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plateNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn View;
        private System.Windows.Forms.RadioButton OpenRORadioButton;
        private System.Windows.Forms.Label TotalROText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label OpenClosedRO;
    }
}