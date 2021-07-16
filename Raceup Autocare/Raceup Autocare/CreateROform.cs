using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Font = System.Drawing.Font;
using DevExpress.Utils;
using DevExpress.Pdf.Native;

namespace Raceup_Autocare
{
    public partial class CreateROform : Form
    {    
        string sqlQuery = "";
        private static String filenamePath;
        
        List<List<String>> serviceDataList = new List<List<String>>();
        List<String> partsData = new List<String>();
        List<List<String>> partsDataList = new List<List<String>>();
        QuotationProperties quoProperties;
        double grandTotal = 0.0;
        String qnNumber = "";
        String roNumber = "";

        public CreateROform()
        {
            InitializeComponent();
            filenamePath = @"C:\database\" + LoginForm.lname + "RepairOrder.docx";
            quoProperties = new QuotationProperties();
            quoProperties.ServiceDescription = new List<string>();
            quoProperties.ServiceHours = new List<int>();
            quoProperties.ServicePrice = new List<double>();
            quoProperties.ServiceTotalPrice = new List<double>();
            quoProperties.ItemCode = new List<String>();
            quoProperties.ItemName = new List<String>();
            quoProperties.ItemPrice = new List<double>();
            quoProperties.ItemQuantity = new List<int>(); ;
            quoProperties.ItemTotalPrice = new List<double>();
            qnNumber = CreateQNNumber();
            roNumber = CreateRONumber();
        }

        private void CreateROform_Load(object sender, EventArgs e)
        {
            Auto();
            AutoCompleteService();
            panel2.HorizontalScroll.Maximum = 0;
            panel2.AutoScroll = false;
            panel2.VerticalScroll.Visible = false;
            panel2.AutoScroll = true;
        }

        private void CroSearchButton_Click(object sender, EventArgs e)
        {
            if (croSearchPlateNoTextbox.Text.Contains("QN"))
            {                
                SearchQuotation();
                
            }
            else
            {
                clearDatagrid();
                SearchPlateNo();
            }
        }

        public void SearchPlateNo()
        {
            PleaseCreateNewCustProf msg = new PleaseCreateNewCustProf();
            DBConnection dbcon = new DBConnection();
            Boolean plateNoExist = false;
            sqlQuery = "SELECT * FROM CustomerProfile";
            OleDbDataReader customerReader = dbcon.ConnectToOleDB(sqlQuery);

            while (customerReader.Read())
            {
                if (customerReader["Plate_Number"].ToString().Equals(croSearchPlateNoTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    croNameTextbox.Text = customerReader["first_name"].ToString() + " " + customerReader["last_name"].ToString();
                    croAddressTextbox.Text = customerReader["Address"].ToString();
                    croContactNumberTextbox.Text = customerReader["contact_number"].ToString();
                    croPlateNoTextbox.Text = customerReader["Plate_Number"].ToString();
                    croCarBrandTextBox.Text = customerReader["car_brand"].ToString();
                    croCarModelTextbox.Text = customerReader["car_model"].ToString();
                    croChasisNo.Text = customerReader["chasis_number"].ToString();
                    croEngineNo.Text = customerReader["engine_number"].ToString();
                    croMileage.Text = customerReader["Mileage"].ToString();
                    ColorTxtBox.Text = customerReader["color_car"].ToString();
                    EmailAddTxtBox.Text = customerReader["email_address"].ToString();
                    PromiseTxtBox.Text = customerReader["promise_time"].ToString();
                    DriversTxtBox.Text = customerReader["drivers_name"].ToString();
                    croRONumberTextbox.Text = roNumber;
                    plateNoExist = true;

                }
            }

            if (!plateNoExist)
            {
                msg.TopMost = true;
                msg.Show();
            }

            customerReader.Close();
            dbcon.CloseConnection();
        }

        private void CroSearchPlateNoTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (croSearchPlateNoTextbox.Text.Contains("QN"))
                {
                    SearchQuotation();
                }
                else
                {
                    SearchPlateNo();
                }
            }
        }

        public String CreateRONumber()
        {
            PleaseCreateNewCustProf msg = new PleaseCreateNewCustProf();
            DBConnection dbcon = new DBConnection();

            sqlQuery = "SELECT TOP 1 * FROM RepairOrder ORDER BY RO_Number Desc";
            OleDbDataReader customerReader = dbcon.ConnectToOleDB(sqlQuery);

            String lastRONumber = "0000000";
            while (customerReader.Read())
            {
                lastRONumber = customerReader["RO_Number"].ToString();
            }

            String strNewRONumber = lastRONumber.Substring(1, lastRONumber.Length - 1);
            int newRONumber = int.Parse(strNewRONumber);
            string value = "R" + String.Format("{0:D7}", (newRONumber + 1));

            return value;
        }

        public string CreateQNNumber()
        {

            PleaseCreateNewCustProf msg = new PleaseCreateNewCustProf();
            DBConnection dbcon = new DBConnection();

            sqlQuery = "SELECT TOP 1 * FROM Quotation ORDER BY Quotation_Number Desc";
            OleDbDataReader customerReader = dbcon.ConnectToOleDB(sqlQuery);

            String lastRONumber = "0000000";
            while (customerReader.Read())
            {
                lastRONumber = customerReader["Quotation_Number"].ToString();
            }
            
            String strNewRONumber = lastRONumber.Substring(2);            
            int newRONumber = int.Parse(strNewRONumber);
            string value = "QN" + String.Format("{0:D7}", (newRONumber + 1));

           
            return value;
        }

        private void AddServiceBuutton_Click(object sender, EventArgs e)
        {           
               FillServiceGridWithoutPackage();
        }

        private void croServicePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillServiceGridWithoutPackage();
            }
        }

        public bool isServiceFieldValidWitoutPackage()
        {
            Boolean isValid = true;

            if (String.IsNullOrEmpty(croServiceDescription.Text))
            {
                isValid = false;
                errorProvider.SetError(croServiceDescription, "This field is required.");
            }
            if (String.IsNullOrEmpty(croServiceHourTextbox.Text)) {
                isValid = false;
                errorProvider.SetError(croServiceHourTextbox, "This field is required.");                
            }
            if(String.IsNullOrEmpty(croServicePrice.Text))
            {
                isValid = false;
                errorProvider.SetError(croServicePrice, "This field is required.");                
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(croServiceHourTextbox.Text, "^[0-9]*$") || String.IsNullOrEmpty(croServiceHourTextbox.Text))
            {
                isValid = false;
                errorProvider.SetError(croServiceHourTextbox, "This field only accepts numeric value.");
            }else
                errorProvider.SetError(croServiceHourTextbox, "");

            if (!System.Text.RegularExpressions.Regex.IsMatch(croServicePrice.Text, "^[0-9]*$") || String.IsNullOrEmpty(croServicePrice.Text))
            {
                isValid = false;
                errorProvider.SetError(croServicePrice, "This field only accepts numeric value.");
            }else
                errorProvider.SetError(croServicePrice, "");

            

            return isValid;
        }

        private void FillServiceGridWithoutPackage() {
            if (isServiceFieldValidWitoutPackage())
            {
                string serviceDesc = croServiceDescription.Text;
                string serviceHour = croServiceHourTextbox.Text;
                string servicePrice = croServicePrice.Text;
                double totalPrice = double.Parse(serviceHour) * double.Parse(servicePrice);
                var list = new[] { serviceDesc, serviceHour, servicePrice, totalPrice.ToString() };

                for (int i = 0; i < serviceDataGridView.Rows.Count - 1; i++)
                {
                    if (serviceDesc == serviceDataGridView.Rows[i].Cells[0].Value.ToString())
                    {
                        serviceDataGridView.Rows[i].Cells[1].Value = int.Parse(serviceHour) + int.Parse(serviceDataGridView.Rows[i].Cells[1].Value.ToString());
                        double newTotalPrice = Double.Parse(serviceDataGridView.Rows[i].Cells[1].Value.ToString()) * Double.Parse(serviceDataGridView.Rows[i].Cells[2].Value.ToString());
                        serviceDataGridView.Rows[i].Cells[3].Value = newTotalPrice.ToString();
                        return;
                    }
                }

                serviceDataGridView.Rows.Add(list);
                computeGrandTotal();
                clearServiceTextbox();
            }
        }

        private void clearServiceTextbox() {
            croServiceDescription.Text = "";
            croServiceHourTextbox.Text = "";
            croServicePrice.Text = "";

        }
        private void croPartsUnitPriceTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillPartsGridWithoutPackage();
            }
        }

        private void FillPartsGridWithoutPackage()
        {
            //PartsDataGrid.Rows.Clear();
            if (isPartsFieldValidWithoutPackage())
            {
                string itemCode = getItemCode();
                string itemDesc = croPartsNameTextBox.Text;
                string itemQuantity = croPartsQuantityTextbox.Text;
                string itemPrice = croPartsUnitPriceTextbox.Text;
                double totalPrice = int.Parse(itemQuantity) * double.Parse(itemPrice);

                    for (int i = 0; i < PartsDataGrid.Rows.Count - 1; i++)
                    {
                        if (itemDesc == PartsDataGrid.Rows[i].Cells[1].Value.ToString())
                        {
                            PartsDataGrid.Rows[i].Cells[2].Value = int.Parse(itemQuantity) + int.Parse(PartsDataGrid.Rows[i].Cells[2].Value.ToString());
                            PartsDataGrid.Rows[i].Cells[4].Value = Double.Parse(PartsDataGrid.Rows[i].Cells[2].Value.ToString()) * Double.Parse(PartsDataGrid.Rows[i].Cells[3].Value.ToString());
                            PartsDataGrid.Columns[4].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("phi");
                            return;
                        }
                    }

                var list = new[] { itemCode, itemDesc, itemQuantity, itemPrice, totalPrice.ToString() };
                PartsDataGrid.Rows.Add(list);
                croPartsUnitPriceTextbox.Enabled = true;
                clearPartsTextbox();
                clearPartsErrorFields();
            }

        }
        private void clearPartsTextbox()
        {
            croPartsNameTextBox.Text = "";
            croPartsQuantityTextbox.Text = "";
            croPartsUnitPriceTextbox.Text = "";

        }

        private string getItemCode()
        {
            DBConnection dbcon = new DBConnection();
            sqlQuery = "SELECT Item_Code FROM Parts WHERE Item_Description='" + croPartsNameTextBox.Text + "'";
            OleDbDataReader partsReader = dbcon.ConnectToOleDB(sqlQuery);
            String itemCode = "";

            while (partsReader.Read())
            {
                itemCode = partsReader["Item_Code"].ToString();
            }
            return itemCode;
        }

        private void partsAddButton_Click(object sender, EventArgs e)
        {
            FillPartsGridWithoutPackage();
            computeGrandTotal();
            croPartsQuantityTextbox.Clear();
            croPartsNameTextBox.Clear();
            croPartsUnitPriceTextbox.Clear();
            //GrandTotalTextbox.Text = "P" + computeTotal() + ".00";
            // ClearTextBoxes(this.Controls);
        }

        public void clearPartsErrorFields() {
            errorProvider.SetError(croPartsQuantityTextbox, "");
            errorProvider.SetError(croPartsNameTextBox, "");
            errorProvider.SetError(croPartsUnitPriceTextbox, "");
            errorProvider.SetError(serviceDataGridView, "");
            errorProvider.SetError(PartsDataGrid, "");
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult2 = MessageBox.Show("Are you sure you want to save this information about the details of an order?", "Save receipt order", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            try
            {
                if (dialogResult2 == DialogResult.Yes)
                {
                    saveRO();
                }
                else if (dialogResult2 == DialogResult.No)
                {
                    //Won't remove any item if cancel
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Exception:" + ex.Message);
            }
        }

        public void printDocument()
        {
            PrintROForm prtform = new PrintROForm(this);
            prtform.ShowDialog();
            
        }
        public void printJobOrder()
        {
            PrintJobOrderForm jobform = new PrintJobOrderForm(this);
            jobform.ShowDialog();
        }     
        public void printTechnicianCopy()
        {
            PrintPartswithoutPriceForm techform = new PrintPartswithoutPriceForm(this);
            techform.ShowDialog();

        }
        private void saveRO()
        {
            //DialogResult dialogResult2 = MessageBox.Show("Are you sure you want to save this information about the details of an order?", "Save receipt order", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            DBConnection dbcon = new DBConnection();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            bool isROExist = false;

            if (!isCreateRoFieldsValid())
            {
                MessageBox.Show("Please input all necessary fields.");
            }

            else
            {
                cmd.CommandType = CommandType.Text;

                sqlQuery = "SELECT * FROM RepairOrder";
                OleDbDataReader repairOrder = dbcon.ConnectToOleDB(sqlQuery);

                while (repairOrder.Read())
                {
                    if (repairOrder["RO_Number"].ToString().Equals(croRONumberTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        isROExist = true;
                        break;
                    }
                }

                //if (dialogResult2 == DialogResult.Yes)
                //{
                    if (!isROExist)
                    {
                        // Insert into RepairOrder Table 
                        cmd.CommandText = @"INSERT INTO RepairOrder([RO_Number], [Plate_Number], [Created_By], [Date_Created], [Updated_By], [Date_Updated], [Payment_Method], [Customer_Request], [GrandTotal], [Status], [Discount], [First_Name], [Last_Name], [Address], [Contact_Number], [Mileage], [Car_Brand], [Car_Model], [Chasis_Number], [Engine_Number], [color_car], [email_address], [promise_time], [drivers_name]) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";
                        croRONumberTextbox.Text = roNumber;
                        cmd.Parameters.Add("@RO_Number", OleDbType.VarChar).Value = croRONumberTextbox.Text.ToString();
                        cmd.Parameters.Add("@Plate_Number", OleDbType.VarChar).Value = croPlateNoTextbox.Text.ToString();
                        cmd.Parameters.Add("@Created_By", OleDbType.VarChar).Value = LoginForm.fname +" "+ LoginForm.lname;
                        cmd.Parameters.Add("@Date_Created", OleDbType.Date).Value = getDateToday();
                        cmd.Parameters.Add("@Updated_By", OleDbType.VarChar).Value = LoginForm.lname;
                        cmd.Parameters.Add("@Date_Updated", OleDbType.Date).Value = getDateToday();
                        cmd.Parameters.Add("@Payment_Method", OleDbType.VarChar).Value = getPaymentMethod();
                        cmd.Parameters.Add("@Customer_Request", OleDbType.VarChar).Value = customerRequestTextbox.Text.ToString();                        
                        cmd.Parameters.Add("@GrandTotal", OleDbType.Integer).Value = int.Parse(croGrandTotal.Text.ToString());
                        cmd.Parameters.Add("@Status", OleDbType.VarChar).Value = "Pending";
                        cmd.Parameters.Add("@Discount", OleDbType.Integer).Value = int.Parse(croDiscountTextbox.Text.ToString());
                   
                        //newly added
                        string fullName = croNameTextbox.Text.ToString();
                        string[] stringSeparator = new string[] { " " };
                        var result = fullName.Split(stringSeparator, StringSplitOptions.None);
                               
                        cmd.Parameters.Add("@First_Name", OleDbType.VarChar).Value = result[0];
                        cmd.Parameters.Add("@Last_Name", OleDbType.VarChar).Value = result[1];
                        cmd.Parameters.Add("@Address", OleDbType.VarChar).Value = croAddressTextbox.Text.ToString();
                        cmd.Parameters.Add("@Contact_Number", OleDbType.VarChar).Value = croContactNumberTextbox.Text.ToString();
                        cmd.Parameters.Add("@Mileage", OleDbType.Integer).Value = int.Parse(croMileage.Text.ToString());
                        cmd.Parameters.Add("@Car_Brand", OleDbType.VarChar).Value = croCarBrandTextBox.Text.ToString();
                        cmd.Parameters.Add("@Car_Model", OleDbType.VarChar).Value = croCarModelTextbox.Text.ToString();
                        cmd.Parameters.Add("@Chasis_Number", OleDbType.VarChar).Value = croChasisNo.Text.ToString();
                        cmd.Parameters.Add("@Engine_Number", OleDbType.VarChar).Value = croEngineNo.Text.ToString();
                        //New Fields
                        cmd.Parameters.Add("@color_car", OleDbType.VarChar).Value = ColorTxtBox.Text.ToString();
                        cmd.Parameters.Add("@email_address", OleDbType.VarChar).Value = EmailAddTxtBox.Text.ToString();
                        cmd.Parameters.Add("@promise_time", OleDbType.VarChar).Value = PromiseTxtBox.Text.ToString();
                        cmd.Parameters.Add("@drivers_name", OleDbType.VarChar).Value = DriversTxtBox.Text.ToString();
                    //end of added

                    cmd.Connection = dbcon.openConnection();
                        cmd.ExecuteNonQuery();

                        // Insert into RepairOrderService Table
                        for (int i = 0; i < serviceDataGridView.Rows.Count - 1; i++)
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandText = @"INSERT INTO RepairOrderService([RO_Number], [Service_Description], [Service_Quantity], [Service_Price], [Total_Price], [Status]) VALUES (?, ?, ?, ?, ?, ?);";
                            cmd.Parameters.Add("@RO_Number", OleDbType.VarChar).Value = croRONumberTextbox.Text.ToString();
                            cmd.Parameters.Add("@Service_Description", OleDbType.VarChar).Value = serviceDataGridView.Rows[i].Cells[0].Value;
                            cmd.Parameters.Add("@Service_Quantity", OleDbType.Integer).Value = int.Parse(serviceDataGridView.Rows[i].Cells[1].Value.ToString());
                            cmd.Parameters.Add("@Service_Price", OleDbType.Integer).Value = int.Parse(serviceDataGridView.Rows[i].Cells[2].Value.ToString());
                            cmd.Parameters.Add("@Total_Price", OleDbType.Integer).Value = int.Parse(serviceDataGridView.Rows[i].Cells[3].Value.ToString());
                            cmd.Parameters.Add("@Status", OleDbType.VarChar).Value = "Pending";
                            cmd.ExecuteNonQuery();
                        }

                        // Insert into RepairOrderParts Table
                        for (int j = 0; j < PartsDataGrid.Rows.Count - 1; j++)
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandText = @"INSERT INTO RepairOrderParts([RO_Number], [Item_Code], [Item_Name], [Parts_Quantity], [Unit_Price], [Total_Price_Parts], [Status], [Check_Parts]) VALUES (?, ?, ?, ?, ?, ?, ?, ?);";
                            cmd.Parameters.Add("@RO_Number", OleDbType.VarChar).Value = croRONumberTextbox.Text.ToString();
                            cmd.Parameters.Add("@Item_Code", OleDbType.VarChar).Value = PartsDataGrid.Rows[j].Cells[0].Value.ToString();
                            cmd.Parameters.Add("@Item_Name", OleDbType.VarChar).Value = PartsDataGrid.Rows[j].Cells[1].Value.ToString();
                            cmd.Parameters.Add("@Parts_Quantity", OleDbType.Integer).Value = int.Parse(PartsDataGrid.Rows[j].Cells[2].Value.ToString());
                            cmd.Parameters.Add("@Unit_Price", OleDbType.Integer).Value = int.Parse(PartsDataGrid.Rows[j].Cells[3].Value.ToString());
                            cmd.Parameters.Add("@Total_Price_Parts", OleDbType.Integer).Value = int.Parse(PartsDataGrid.Rows[j].Cells[4].Value.ToString());
                            cmd.Parameters.Add("@Status", OleDbType.VarChar).Value = "Pending";
                            cmd.Parameters.Add("@Check_Parts", OleDbType.VarChar).Value = "Pending";
                            cmd.ExecuteNonQuery();

                        }

                        repairOrder.Close();
                        dbcon.CloseConnection();
                        MessageBox.Show("RO has been successfully saved.");
                        //printDocument();
                        PrintCopiesForm printCopies = new PrintCopiesForm(this);
                        printCopies.ShowDialog();
                        this.Hide();
                        this.Close();

                    }

                //}
                //else if (dialogResult2 == DialogResult.No)
                //{
                //    //Won't remove any item if cancel
                //}
            }

        }

        private void computeGrandTotal() {
            grandTotal = 0.0;
            grandTotal = computeTotal() - getDiscount();
            croGrandTotal.Text = grandTotal.ToString();
        }

        private int getDiscount() {
            int discount = 0;
            if (!String.IsNullOrEmpty(croDiscountTextbox.Text)) {
                discount = int.Parse(croDiscountTextbox.Text.ToString());
            }
            return discount;
        }

        private double computeTotal()
        {
            double totalParts = 0.0;
            double totalService = 0.0;

            for (int i = 0; i < PartsDataGrid.Rows.Count - 1; i++)
            {
                totalParts += double.Parse(PartsDataGrid.Rows[i].Cells[4].Value.ToString());
            }

            for (int i = 0; i < serviceDataGridView.Rows.Count - 1; i++)
            {
                totalService += double.Parse(serviceDataGridView.Rows[i].Cells[3].Value.ToString());
            }

            return totalParts + totalService;
        }

        private DateTime getDateToday()
        {
            DateTime dateTimeToday = DateTime.Today;
            return dateTimeToday;
        }

        private String getPaymentMethod()
        {
            var radioButtonList = new[] { cashRadioButton, gcashRadioButton, creditCardRadioButton, masterCardRadioButton };
            String paymentMethod = "";

            foreach (RadioButton rb in radioButtonList)
            {
                if (rb.Checked == true)
                {
                    paymentMethod = rb.Text;
                }
            }

            return paymentMethod;
        }

        AutoCompleteStringCollection partsAutoCompleteCollection = new AutoCompleteStringCollection();
        public void Auto()
        {
            DBConnection dbcon = new DBConnection();
            sqlQuery = "SELECT Item_Description, Package_Name FROM Parts ORDER BY Item_Description asc";
            OleDbDataReader partsReader = dbcon.ConnectToOleDB(sqlQuery);

            while (partsReader.Read())
            {
                partsAutoCompleteCollection.Add(partsReader["Item_Description"].ToString());
              //  partsAutoCompleteCollection.Add(partsReader["Package_Name"].ToString());
            }

            croPartsNameTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            croPartsNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            croPartsNameTextBox.AutoCompleteCustomSource = partsAutoCompleteCollection;

            partsReader.Close();
            dbcon.CloseConnection();

        }

        AutoCompleteStringCollection serviceAutoCompleteCollection = new AutoCompleteStringCollection();
        public void AutoCompleteService()
        {
            DBConnection dbcon = new DBConnection();
            sqlQuery = "SELECT Package_Name FROM Service ORDER BY Service_Description asc";
            OleDbDataReader partsReader = dbcon.ConnectToOleDB(sqlQuery);

            while (partsReader.Read())
            {
               // serviceAutoCompleteCollection.Add(partsReader["Service_Description"].ToString());
                serviceAutoCompleteCollection.Add(partsReader["Package_Name"].ToString());
            }

            croServiceDescription.AutoCompleteMode = AutoCompleteMode.Suggest;
            croServiceDescription.AutoCompleteSource = AutoCompleteSource.CustomSource;
            croServiceDescription.AutoCompleteCustomSource = serviceAutoCompleteCollection;

            partsReader.Close();
            dbcon.CloseConnection();

        }

        public bool isServiceFieldValid()
        {
            Boolean isValid = true;
            if (serviceDataGridView.Rows.Count == 1)
            {
                isValid = false;
                errorProvider.SetError(serviceDataGridView, "This field is required.");
            }

            return isValid;
        }

        public bool isPartsFieldValidWithoutPackage()
        {
            Boolean isValid = true;
            if (String.IsNullOrEmpty(croPartsQuantityTextbox.Text)) {
                isValid = false;
                errorProvider.SetError(croPartsQuantityTextbox, "This field is required.");
            }
            if (String.IsNullOrEmpty(croPartsUnitPriceTextbox.Text)) {
                isValid = false;
                errorProvider.SetError(croPartsUnitPriceTextbox, "This field is required.");
            }
            if (String.IsNullOrEmpty(croPartsNameTextBox.Text))
            {
                isValid = false;
                errorProvider.SetError(croPartsNameTextBox, "This field is required.");
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(croPartsQuantityTextbox.Text, "^[0-9]*$"))
            {
                isValid = false;
                errorProvider.SetError(croPartsQuantityTextbox, "This field only accepts numeric value.");
            }
           /* else
                errorProvider.SetError(croPartsQuantityTextbox, "");*/

            if (!System.Text.RegularExpressions.Regex.IsMatch(croPartsUnitPriceTextbox.Text, "^[0-9]*$"))
            {
                isValid = false;
                errorProvider.SetError(croPartsUnitPriceTextbox, "This field only accepts numeric value.");
            }
            else
                errorProvider.SetError(croServicePrice, "");
            return isValid;
        }

        public bool isPartsFieldValid()
        {
            Boolean isValid = true;
            if (PartsDataGrid.Rows.Count == 1)
            {
                isValid = false;
                errorProvider.SetError(PartsDataGrid, "This field is required.");
            }
            return isValid;
        }

        public bool isCreateRoFieldsValid()
        {
            bool isValid = true;

            //Validate if mode of payment is selected
            if (cashRadioButton.Checked == false && gcashRadioButton.Checked == false && creditCardRadioButton.Checked == false && masterCardRadioButton.Checked == false)
            {
                errorProvider.SetError(ModeOfPaymentGroupBox, "Please choose payment method");
                isValid = false;
            }

            //Validate service fields
            if (!isPartsFieldValid())
            {
                isValid = false;
            }

            if (!isServiceFieldValid())
            {
                isValid = false;
            }

            return isValid;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        public void ClearTextBoxes(Control.ControlCollection ctrlCollection)
        {
            foreach (Control ctrl in ctrlCollection)
            {
                if (ctrl is TextBoxBase)
                {
                    ctrl.Text = String.Empty;
                }
                else
                {
                    ClearTextBoxes(ctrl.Controls);
                }
            }
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(this.Controls);
            serviceDataGridView.Rows.Clear();
            PartsDataGrid.Rows.Clear();
            errorProvider.SetError(PartsDataGrid, "");
            errorProvider.SetError(croServiceDescription, "");
            errorProvider.SetError(croServiceHourTextbox, "");
            errorProvider.SetError(croServicePrice, "");
            clearPartsErrorFields();
            croDiscountTextbox.Text = "0";
            croGrandTotal.Text = "0";
        }

        public void clearDatagrid() {
            serviceDataGridView.Rows.Clear();
            PartsDataGrid.Rows.Clear();
            errorProvider.SetError(PartsDataGrid, "");
            errorProvider.SetError(croServiceDescription, "");
            errorProvider.SetError(croServiceHourTextbox, "");
            errorProvider.SetError(croServicePrice, "");
            clearPartsErrorFields();
            croDiscountTextbox.Text = "0";
            croGrandTotal.Text = "0";
            customerRequestTextbox.Text = "";
        }

        private void removeBTN_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this selected item?", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in PartsDataGrid.SelectedRows)
                    if (!row.IsNewRow) PartsDataGrid.Rows.Remove(row);
                croPartsNameTextBox.Text = "";
                croPartsQuantityTextbox.Text = "";
                croPartsUnitPriceTextbox.Text = "";
                computeGrandTotal();
                errorProvider.SetError(PartsDataGrid, "");
                clearPartsErrorFields();
            }
            else if (dialogResult == DialogResult.No)
            {
                //Won't remove any item if cancel
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this selected item?", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in serviceDataGridView.SelectedRows)
                    if (!row.IsNewRow) serviceDataGridView.Rows.Remove(row);
                croServiceDescription.Text = "";
                croServiceHourTextbox.Text = "";
                croServicePrice.Text = "";
                computeGrandTotal();
            }
            else if (dialogResult == DialogResult.No)
            {
                //Won't remove any item if cance
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Operations
                SaveQuotation();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Exception:" + ex.Message);
            }   

        }
        public void printQTNDocument()
        {

            PrintQTNROForm prtform = new PrintQTNROForm(this);
            prtform.ShowDialog();
        }

        private void SaveQuotation()
        {
            DialogResult dialogResult2 = MessageBox.Show("Are you sure you want to save this information about the details of an order?", "Save receipt order", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            DBConnection dbcon = new DBConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader repairOrder = null;
            cmd.CommandType = CommandType.Text;
            bool isROExist = false;

            if (!isCreateRoFieldsValid())
            {
                MessageBox.Show("Please input all necessary fields.");
            }

            else
            {
                cmd.CommandType = CommandType.Text;

                sqlQuery = "SELECT * FROM Quotation";
                repairOrder = dbcon.ConnectToOleDB(sqlQuery);

                while (repairOrder.Read())
                {
                    if (repairOrder["Quotation_Number"].ToString().Equals(croRONumberTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        isROExist = true;
                        break;
                    }
                }

                if (dialogResult2 == DialogResult.Yes)
                {
                    if (!isROExist)
                    {
                        string fullName = croNameTextbox.Text.ToString();
                        string[] stringSeparator = new string[] { " " };
                        var result = fullName.Split(stringSeparator, StringSplitOptions.None);
                       
                        // Insert into Quotation Table
                        cmd.CommandText = @"INSERT INTO Quotation([Quotation_Number], [First_Name], [Last_Name], [Address], [Contact_Number], [Plate_Number], [Car_Brand], [Car_Model], [Chasis_Number], [Engine_Number], [Payment_Method], [Customer_Request], [Grand_Total], [Date_Created] ,[Mileage]) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ? ,?);";
                        cmd.Parameters.Add("@Quotation_Number", OleDbType.VarChar).Value = qnNumber;// "QN" + croRONumberTextbox.Text.ToString();
                        cmd.Parameters.Add("@First_Name", OleDbType.VarChar).Value = result[0];
                        cmd.Parameters.Add("@Last_Name", OleDbType.VarChar).Value = result[1];
                        //New Fields
                        cmd.Parameters.Add("@color_car", OleDbType.VarChar).Value = ColorTxtBox.Text.ToString();
                        cmd.Parameters.Add("@email_address", OleDbType.VarChar).Value = EmailAddTxtBox.Text.ToString();
                        cmd.Parameters.Add("@promise_time", OleDbType.VarChar).Value = PromiseTxtBox.Text.ToString();
                        cmd.Parameters.Add("@drivers_name", OleDbType.VarChar).Value = DriversTxtBox.Text.ToString();

                        cmd.Parameters.Add("@Address", OleDbType.VarChar).Value = croAddressTextbox.Text;
                        cmd.Parameters.Add("@Contact_Number", OleDbType.VarChar).Value = croContactNumberTextbox.Text.ToString();
                        cmd.Parameters.Add("@Plate_Number", OleDbType.VarChar).Value = croPlateNoTextbox.Text.ToString();
                        cmd.Parameters.Add("@Car_Brand", OleDbType.VarChar).Value = croCarBrandTextBox.Text.ToString();
                        cmd.Parameters.Add("@Car_Model", OleDbType.VarChar).Value = croCarModelTextbox.Text.ToString();
                        cmd.Parameters.Add("@Chasis_Number", OleDbType.VarChar).Value = croChasisNo.Text.ToString();
                        cmd.Parameters.Add("@Engine_Number", OleDbType.VarChar).Value = croEngineNo.Text.ToString();
                        cmd.Parameters.Add("@Payment_Method", OleDbType.VarChar).Value = getPaymentMethod();
                        cmd.Parameters.Add("@Customer_Request", OleDbType.VarChar).Value = customerRequestTextbox.Text.ToString();                        
                        cmd.Parameters.Add("@Grand_Total", OleDbType.Integer).Value = int.Parse(croGrandTotal.Text.ToString());
                        cmd.Parameters.Add("@Date_Created", OleDbType.Date).Value = getDateToday();
                        cmd.Parameters.Add("@Mileage", OleDbType.Integer).Value = int.Parse(croMileage.Text.ToString());

                        cmd.Connection = dbcon.openConnection();
                        cmd.ExecuteNonQuery();

                        // Insert into RepairOrderService Table
                        for (int i = 0; i < serviceDataGridView.Rows.Count - 1; i++)
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandText = @"INSERT INTO QuotationService([Quotation_Number], [Quo_Service_Desc], [Quo_Service_Hrs], [Quo_Service_Price], [Quo_Service_Total_Price]) VALUES(?, ?, ?, ?, ?);";
                            cmd.Parameters.Add("@Quotation_Number", OleDbType.VarChar).Value = qnNumber; //"QN" + croRONumberTextbox.Text.ToString();
                            cmd.Parameters.Add("@Quo_Service_Desc", OleDbType.VarChar).Value = serviceDataGridView.Rows[i].Cells[0].Value;
                            cmd.Parameters.Add("@Quo_Service_Hrs", OleDbType.Integer).Value = int.Parse(serviceDataGridView.Rows[i].Cells[1].Value.ToString());
                            cmd.Parameters.Add("@Quo_Service_Price", OleDbType.Integer).Value = int.Parse(serviceDataGridView.Rows[i].Cells[2].Value.ToString());
                            cmd.Parameters.Add("@Quo_Service_Total_Price", OleDbType.Integer).Value = int.Parse(serviceDataGridView.Rows[i].Cells[3].Value.ToString());
                            cmd.ExecuteNonQuery();
                        }

                        // Insert into RepairOrderParts Table
                        for (int j = 0; j < PartsDataGrid.Rows.Count - 1; j++)
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandText = @"INSERT INTO QuotationParts([Quotation_Number], [Quotation_Item_Code], [Quotation_Item_Name], [Quotation_Item_Quantity], [Quotation_Item_Price], [Quotation_Item_Total_Price]) VALUES (?, ?, ?, ?, ?, ?);";
                            cmd.Parameters.Add("@Quotation_Number", OleDbType.VarChar).Value = qnNumber; //"QN" + croRONumberTextbox.Text.ToString();
                            cmd.Parameters.Add("@Quotation_Item_Code", OleDbType.VarChar).Value = PartsDataGrid.Rows[j].Cells[0].Value.ToString();
                            cmd.Parameters.Add("@Quotation_Item_Name", OleDbType.VarChar).Value = PartsDataGrid.Rows[j].Cells[1].Value.ToString();
                            cmd.Parameters.Add("@Quotation_Item_Quantity", OleDbType.Integer).Value = int.Parse(PartsDataGrid.Rows[j].Cells[2].Value.ToString());
                            cmd.Parameters.Add("@Quotation_Item_Price", OleDbType.Integer).Value = int.Parse(PartsDataGrid.Rows[j].Cells[3].Value.ToString());
                            cmd.Parameters.Add("@Quotation_Item_Total_Price", OleDbType.Integer).Value = int.Parse(PartsDataGrid.Rows[j].Cells[4].Value.ToString());
                            cmd.ExecuteNonQuery();

                        }
                       
                        croRONumberTextbox.Text = qnNumber;
                        MessageBox.Show("RONUMBNER:" + qnNumber);
                        dbcon.CloseConnection();
                        MessageBox.Show("Quotation Repair Order has been successfully saved.");

                        printQTNDocument();
                        this.Hide();
                        this.Close();
                    }

                }
                else if (dialogResult2 == DialogResult.No)
                {
                    //Won't remove any item if cancel
                }

            }

            repairOrder.Close();
            dbcon.CloseConnection();
        }                

        private void serviceDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void croPartsUnitPriceTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchQuotation()
        {
            DBConnection dbcon = new DBConnection();
            sqlQuery = "SELECT * FROM Quotation WHERE Quotation_Number='" + croSearchPlateNoTextbox.Text.ToString() + "'";
            OleDbDataReader quotationReader = dbcon.ConnectToOleDB(sqlQuery);
            bool quotationExists = false;

            while (quotationReader.Read())
            {
                if (quotationReader["Quotation_Number"].ToString().Equals(croSearchPlateNoTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    quoProperties.QuoNumber = quotationReader["Quotation_Number"].ToString();
                    quoProperties.FName = quotationReader["First_Name"].ToString();
                    quoProperties.LName = quotationReader["Last_Name"].ToString();
                    quoProperties.Address = quotationReader["Address"].ToString();
                    quoProperties.ContactNum = quotationReader["Contact_Number"].ToString();
                    quoProperties.PlateNo = quotationReader["Plate_Number"].ToString();
                    quoProperties.CarBrand = quotationReader["Car_Brand"].ToString();
                    quoProperties.CardModel = quotationReader["Car_Model"].ToString();
                    quoProperties.ChasisNo = quotationReader["Chasis_Number"].ToString();
                    quoProperties.EngineNo = quotationReader["Engine_Number"].ToString();
                    quoProperties.PaymentMethod = quotationReader["Payment_Method"].ToString();
                    quoProperties.CustomerRequest = quotationReader["Customer_Request"].ToString();
                    quoProperties.GrandTotal = quotationReader["Grand_Total"].ToString();
                    quoProperties.MileAge = quotationReader["MileAge"].ToString();
                    quoProperties.ColorCar = quotationReader["color_car"].ToString();
                    quoProperties.EmailAdd = quotationReader["email_address"].ToString();
                    quoProperties.Promise = quotationReader["promise_time"].ToString();
                    quoProperties.Drivers = quotationReader["drivers_name"].ToString();
                    quotationExists = true;                    
                }
            }

            if (quotationExists){
                //Get data from service
                sqlQuery = "SELECT * FROM QuotationService WHERE Quotation_Number='" + croSearchPlateNoTextbox.Text.ToString() + "'";
                quotationReader = dbcon.ConnectToOleDB(sqlQuery);

                while (quotationReader.Read())
                {
                    if (quotationReader["Quotation_Number"].ToString().Equals(croSearchPlateNoTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        quoProperties.ServiceDescription.Add(quotationReader["Quo_Service_Desc"].ToString());
                        quoProperties.ServiceHours.Add(int.Parse(quotationReader["Quo_Service_Hrs"].ToString()));
                        quoProperties.ServicePrice.Add(int.Parse(quotationReader["Quo_Service_Price"].ToString()));
                        quoProperties.ServiceTotalPrice.Add(int.Parse(quotationReader["Quo_Service_Total_Price"].ToString()));
                    }
                }

                //Get data from parts 
                sqlQuery = "SELECT * FROM QuotationParts WHERE Quotation_Number='" + croSearchPlateNoTextbox.Text.ToString() + "'";
                quotationReader = dbcon.ConnectToOleDB(sqlQuery);

                while (quotationReader.Read())
                {
                    if (quotationReader["Quotation_Number"].ToString().Equals(croSearchPlateNoTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        quoProperties.ItemCode.Add(quotationReader["Quotation_Item_Code"].ToString());
                        quoProperties.ItemName.Add(quotationReader["Quotation_Item_Name"].ToString());
                        quoProperties.ItemPrice.Add(int.Parse(quotationReader["Quotation_Item_Price"].ToString()));
                        quoProperties.ItemQuantity.Add(int.Parse(quotationReader["Quotation_Item_Quantity"].ToString()));
                        quoProperties.ItemTotalPrice.Add(int.Parse(quotationReader["Quotation_Item_Total_Price"].ToString()));
                    }
                }

                populateROFields();
            }
            else {
                MessageBox.Show("Quotation number does not exists.");
            }

            quotationReader.Close();
            dbcon.CloseConnection();

        }

        public void populateROFields()
        {

            serviceDataGridView.Rows.Clear();
            PartsDataGrid.Rows.Clear();

            if (croSearchPlateNoTextbox.Text.Contains("QN")) { 
                croRONumberTextbox.Text = quoProperties.QuoNumber;                
            }

            croNameTextbox.Text = quoProperties.FName + " " + quoProperties.LName;
            croContactNumberTextbox.Text = quoProperties.ContactNum;
            croAddressTextbox.Text = quoProperties.Address;
            croPlateNoTextbox.Text = quoProperties.PlateNo;
            croCarBrandTextBox.Text = quoProperties.CarBrand;
            croCarModelTextbox.Text = quoProperties.CardModel;
            croChasisNo.Text = quoProperties.ChasisNo;
            croEngineNo.Text = quoProperties.EngineNo;
            customerRequestTextbox.Text = quoProperties.CustomerRequest;            
            croMileage.Text = quoProperties.MileAge;
            croGrandTotal.Text = quoProperties.GrandTotal;
            //new fields
            ColorTxtBox.Text = quoProperties.ColorCar;
            EmailAddTxtBox.Text = quoProperties.EmailAdd;
            PromiseTxtBox.Text = quoProperties.Promise;
            DriversTxtBox.Text = quoProperties.Drivers;

            string[] paymentMethods = { "Cash", "GCash", "Master Card", "Credit Card" };
            RadioButton[] paymentRadioButton = { cashRadioButton, gcashRadioButton, masterCardRadioButton, creditCardRadioButton };

            for (int i = 0; i < paymentMethods.Length; i++)
            {
                if (quoProperties.PaymentMethod.Equals(paymentMethods[i]))
                {
                    paymentRadioButton[i].Checked = true;
                }
            }

            for (int i = 0; i < quoProperties.ServiceDescription.Count; i++)
            {
                //Populate Service datagird                     
                var serviceList = new[] { quoProperties.ServiceDescription[i], quoProperties.ServiceHours[i].ToString(), quoProperties.ServicePrice[i].ToString(), quoProperties.ServiceTotalPrice[i].ToString() };
                serviceDataGridView.Rows.Add(serviceList);
            }


            //Populate Parts datagird
            for (int i = 0; i < quoProperties.ItemCode.Count; i++)
            {
                var partsList = new[] { quoProperties.ItemCode[i], quoProperties.ItemName[i], quoProperties.ItemQuantity[i].ToString(), quoProperties.ItemPrice[i].ToString(), quoProperties.ItemTotalPrice[i].ToString() };
                PartsDataGrid.Rows.Add(partsList);
            }

            //Clear Parts and service list.
            clearQuoPropertiesList();
        }

        private void croServiceDescription_KeyDown(object sender, KeyEventArgs e)
        {
            bool isPackageAdded = false;
            if (e.KeyCode == Keys.Enter)
            {
                string serviceDesc = croServiceDescription.Text;
                for (int i = 0; i < serviceDataGridView.Rows.Count - 1; i++)
                {
                    if (serviceDesc == serviceDataGridView.Rows[i].Cells[0].Value.ToString())
                    {
                        MessageBox.Show(serviceDesc + " Package is already Added");
                        isPackageAdded= true;
                    }
                }

                if (!isPackageAdded) {
                    PopulateServicePackages();
                    croServiceDescription.Clear();
                }
                
            }
        }

        private void clearQuoPropertiesList()
        {
            //Clear list of Parts
            quoProperties.ItemCode.Clear();
            quoProperties.ItemName.Clear();
            quoProperties.ItemPrice.Clear();
            quoProperties.ItemQuantity.Clear();
            quoProperties.ItemTotalPrice.Clear();

            //Clear list of service.
            quoProperties.ServiceDescription.Clear();
            quoProperties.ServiceHours.Clear();
            quoProperties.ServicePrice.Clear();
            quoProperties.ServiceTotalPrice.Clear();
        }

        private void addServicePackage() 
        {
            // serviceDataGridView.Rows.Clear();
            DBConnection dbcon = new DBConnection();
            sqlQuery = "SELECT * FROM Packages WHERE Package_Name='" + croServiceDescription.Text.ToString() + "'";
            OleDbDataReader partsReader = dbcon.ConnectToOleDB(sqlQuery);
            CreateROProperties croProp = new CreateROProperties();
            Random rnd = new Random();
            bool packageFound = false;
            //int hours = 0;
            
            while (partsReader.Read())
            {
                if (partsReader["Package_Name"].ToString().Equals(croServiceDescription.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    //hours = rnd.Next(1, 5);
                    int hours = int.Parse(partsReader["Package_Hours_Work"].ToString());
                    double servicePrice = double.Parse(partsReader["Package_Price"].ToString());
                    double perhour;

                    perhour = servicePrice / hours;
                    var partsList = new[] { partsReader["Package_Name"].ToString(), partsReader["Package_Hours_Work"].ToString(), perhour.ToString(), partsReader["Package_Price"].ToString() };
                    serviceDataGridView.Rows.Add(partsList);
                    packageFound = true;
                }
            }
            if (!packageFound)
            {
               // MessageBox.Show("Package does not exists!");
                croServiceHourTextbox.Enabled = true;
                croServicePrice.Enabled = true;
            }
            partsReader.Close();
            dbcon.CloseConnection();           
        }       

        private void PopulateServicePackages()
        {
            //serviceDataGridView.Rows.Clear();

            addServicePackage();
            DBConnection dbcon = new DBConnection();
            sqlQuery = "SELECT * FROM Service WHERE Package_Name='" + croServiceDescription.Text.ToString() + "'";
            OleDbDataReader partsReader = dbcon.ConnectToOleDB(sqlQuery);
            CreateROProperties croProp = new CreateROProperties();            
            Random rnd = new Random();
            int quantity = 0;
            int hours = 0;

            bool packageFound = false;
            
            while (partsReader.Read())
            {
                if (partsReader["Package_Name"].ToString().Equals(croServiceDescription.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    hours = rnd.Next(1, 5);
                    var partsList = new[] { partsReader["Service_Description"].ToString(), hours.ToString(), quantity.ToString(), partsReader["Service_Price"].ToString() };
                    serviceDataGridView.Rows.Add(partsList);
                    //croServiceHourTextbox.Enabled = false;
                    //croServicePrice.Enabled = false;
                    //croServiceHourTextbox.BackColor = Color.DarkGray;
                    //croServicePrice.BackColor = Color.DarkGray;
                    packageFound = true;
                }
            }
            if (!packageFound)
            {
                MessageBox.Show("Package does not exists!");
                croServiceHourTextbox.Enabled = true;
                croServicePrice.Enabled = true;
                croServiceHourTextbox.BackColor = Color.White;
                croServicePrice.BackColor = Color.White;
            }
            else {
                computeGrandTotal();
            }

            partsReader.Close();
            dbcon.CloseConnection();

        }

        private void croPartsNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                /*string itemDesc = croPartsNameTextBox.Text;
                bool isPackageAdded = false;
                if (croPartsNameTextBox.Text.StartsWith("PMS"))
                {
                    PopulatePartsPackages();
                    croPartsNameTextBox.Select(croPartsNameTextBox.Text.Length, croPartsNameTextBox.Text.Length);

                }
                else {
                    PopulatePartsWithoutPackages();
                }*/
                PopulatePartsWithoutPackages();
                clearErrorProvider();
            }
        }

        private void clearErrorProvider() {
            errorProvider.SetError(croPartsQuantityTextbox, "");
            errorProvider.SetError(croPartsUnitPriceTextbox, "");
            errorProvider.SetError(croPartsNameTextBox, "");
            errorProvider.SetError(croServiceDescription, "");
            errorProvider.SetError(croServiceHourTextbox, "");
            errorProvider.SetError(croServicePrice, "");
            errorProvider.SetError(serviceDataGridView, "");
            errorProvider.SetError(PartsDataGrid, "");
        }        

        private void PopulatePartsWithoutPackages()
        {
            //PartsDataGrid.Rows.Clear();
            DBConnection dbcon = new DBConnection();
            sqlQuery = "SELECT * FROM Parts WHERE Item_Description='" + croPartsNameTextBox.Text.ToString() + "'Order by Item_Code";
            OleDbDataReader partsReader = dbcon.ConnectToOleDB(sqlQuery);
            CreateROProperties croProp = new CreateROProperties();

            while (partsReader.Read())
            {
                if (partsReader["Item_Description"].ToString().Equals(croPartsNameTextBox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    croPartsUnitPriceTextbox.Text = partsReader["Unit_Price"].ToString();
                    croPartsUnitPriceTextbox.Enabled = false;

                }
            }

            croPartsQuantityTextbox.Focus();
            partsReader.Close();
            dbcon.CloseConnection();

        }

        private void croDiscountTextbox_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(croDiscountTextbox.Text, "^[0-9]*$"))
            {
                computeGrandTotal();
                errorProvider.SetError(croDiscountTextbox, "");
            }
            else {
                errorProvider.SetError(croDiscountTextbox, "This field only accepts numeric value.");
            }

        }

        private void croServicePrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

		private void croPartsQuantityTextbox_KeyPress(object sender, KeyPressEventArgs e)
		{
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillPartsGridWithoutPackage();
                computeGrandTotal();
                croPartsQuantityTextbox.Clear();
                croPartsNameTextBox.Clear();
                croPartsUnitPriceTextbox.Clear();
            }
                
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void croEngineNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void JobORBTN_Click(object sender, EventArgs e)
        {
            //saveRO();
            PrintCopiesForm printCopies = new PrintCopiesForm(this);
            printCopies.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}
