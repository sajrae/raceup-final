using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raceup_Autocare
{
    public partial class EditRepairOrderForm : Form
    {
        string sqlQuery = "";
        private static String filenamePath;

        List<List<String>> serviceDataList = new List<List<String>>();
        List<String> partsData = new List<String>();
        List<List<String>> partsDataList = new List<List<String>>();
        CreateROProperties roProperties;
        double grandTotal = 0.0;
        String qnNumber = "";
        String roNumber = "";
        int partsDataGridRowCountUponLoading;

        public EditRepairOrderForm()
        {
            InitializeComponent();
            roProperties = new CreateROProperties();
            roProperties.ServiceDescription = new List<string>();
            roProperties.ServiceHours = new List<int>();
            roProperties.ServicePrice = new List<double>();
            roProperties.ServiceTotalPrice = new List<double>();
            roProperties.ItemCode = new List<String>();
            roProperties.ItemName = new List<String>();
            roProperties.ItemQuantity = new List<int>(); ;
            roProperties.ItemPrice = new List<double>();
            roProperties.ItemTotalPrice = new List<double>();
            checkUserRole();
        }

        private void uroSearchRONumberTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                searchRONumber();
            }
        }

        private void searchRONumber()
        {
            DBConnection dbcon = new DBConnection();
            sqlQuery = "SELECT * FROM RepairOrder WHERE RO_Number='" + uroSearchRONumberTextbox.Text.ToString() + "'";
            OleDbDataReader roReader = dbcon.ConnectToOleDB(sqlQuery);
            bool quotationExists = false;

            while (roReader.Read())
            {
                if (roReader["RO_Number"].ToString().Equals(uroSearchRONumberTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    roProperties.RoNumber = roReader["RO_Number"].ToString();
                    roProperties.FName = roReader["First_Name"].ToString();
                    roProperties.LName = roReader["Last_Name"].ToString();
                    roProperties.Address = roReader["Address"].ToString();
                    roProperties.ContactNum = roReader["Contact_Number"].ToString();
                    roProperties.PlateNo = roReader["Plate_Number"].ToString();
                    roProperties.CarBrand = roReader["Car_Brand"].ToString();
                    roProperties.CardModel = roReader["Car_Model"].ToString();
                    roProperties.ChasisNo = roReader["Chasis_Number"].ToString();
                    roProperties.EngineNo = roReader["Engine_Number"].ToString();
                    roProperties.PaymentMethod = roReader["Payment_Method"].ToString();
                    roProperties.CustomerRequest = roReader["Customer_Request"].ToString();
                    roProperties.GrandTotal = roReader["GrandTotal"].ToString();
                    roProperties.MileAge = roReader["MileAge"].ToString();
                    //new fields
                    roProperties.ColorCar = roReader["color_car"].ToString();
                    roProperties.EmailAdd = roReader["email_address"].ToString();
                    roProperties.Promise = roReader["promise_time"].ToString();
                    roProperties.Drivers = roReader["drivers_name"].ToString();
                    quotationExists = true;
                }
            }

            if (quotationExists)
            {
                //Get data from service
                sqlQuery = "SELECT * FROM RepairOrderService WHERE RO_Number='" + uroSearchRONumberTextbox.Text.ToString() + "'";
                roReader = dbcon.ConnectToOleDB(sqlQuery);

                while (roReader.Read())
                {
                    if (roReader["RO_Number"].ToString().Equals(uroSearchRONumberTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        roProperties.ServiceDescription.Add(roReader["Service_Description"].ToString());
                        roProperties.ServiceHours.Add(int.Parse(roReader["Service_Quantity"].ToString()));
                        roProperties.ServicePrice.Add(int.Parse(roReader["Service_Price"].ToString()));
                        roProperties.ServiceTotalPrice.Add(int.Parse(roReader["Total_Price"].ToString()));
                    }
                }

                //Get data from parts 
                sqlQuery = "SELECT * FROM RepairOrderParts WHERE RO_Number='" + uroSearchRONumberTextbox.Text.ToString() + "'";
                roReader = dbcon.ConnectToOleDB(sqlQuery);

                while (roReader.Read())
                {
                    if (roReader["RO_Number"].ToString().Equals(uroSearchRONumberTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        roProperties.ItemCode.Add(roReader["Item_Code"].ToString());
                        roProperties.ItemName.Add(roReader["Item_Name"].ToString());
                        roProperties.ItemPrice.Add(int.Parse(roReader["Unit_Price"].ToString()));
                        roProperties.ItemQuantity.Add(int.Parse(roReader["Parts_Quantity"].ToString()));
                        roProperties.ItemTotalPrice.Add(int.Parse(roReader["Total_Price_Parts"].ToString()));
                    }
                }

                populateROFields();
                partsDataGridRowCountUponLoading = PartsDataGrid.Rows.Count - 1;
            }
            else
            {
                MessageBox.Show("Repair Order number does not exists.");
            }

            roReader.Close();
            dbcon.CloseConnection();
        }

        public void populateROFields()
        {

            serviceDataGridView.Rows.Clear();
            PartsDataGrid.Rows.Clear();

            croRONumberTextbox.Text = roProperties.RoNumber;
            croNameTextbox.Text = roProperties.FName + " " + roProperties.LName;
            croContactNumberTextbox.Text = roProperties.ContactNum;
            croAddressTextbox.Text = roProperties.Address;
            croPlateNoTextbox.Text = roProperties.PlateNo;
            croCarBrandTextBox.Text = roProperties.CarBrand;
            croCarModelTextbox.Text = roProperties.CardModel;
            croChasisNo.Text = roProperties.ChasisNo;
            croEngineNo.Text = roProperties.EngineNo;
            customerRequestTextbox.Text = roProperties.CustomerRequest;
            croMileage.Text = roProperties.MileAge;
            croGrandTotal.Text = roProperties.GrandTotal;
            //new fields
            ColorTxtBox.Text = roProperties.ColorCar;
            EmailAddTxtBox.Text = roProperties.EmailAdd;
            PromiseTxtBox.Text = roProperties.Promise;
            DriversTxtBox.Text = roProperties.Drivers;

            string[] paymentMethods = { "Cash", "GCash", "Master Card", "Credit Card" };
            RadioButton[] paymentRadioButton = { cashRadioButton, gcashRadioButton, masterCardRadioButton, creditCardRadioButton };

            for (int i = 0; i < paymentMethods.Length; i++)
            {
                if (roProperties.PaymentMethod.Equals(paymentMethods[i]))
                {
                    paymentRadioButton[i].Checked = true;
                }
            }

            for (int i = 0; i < roProperties.ServiceDescription.Count; i++)
            {
                //Populate Service datagird                     
                var serviceList = new[] { roProperties.ServiceDescription[i], roProperties.ServiceHours[i].ToString(), roProperties.ServicePrice[i].ToString(), roProperties.ServiceTotalPrice[i].ToString() };
                serviceDataGridView.Rows.Add(serviceList);
            }


            //Populate Parts datagird
            for (int i = 0; i < roProperties.ItemCode.Count; i++)
            {
                var partsList = new[] { roProperties.ItemCode[i], roProperties.ItemName[i], roProperties.ItemQuantity[i].ToString(), roProperties.ItemPrice[i].ToString(), roProperties.ItemTotalPrice[i].ToString() };
                PartsDataGrid.Rows.Add(partsList);
            }

            //Clear Parts and service list.
            clearQuoPropertiesList();
        }

        private void clearQuoPropertiesList()
        {
            //Clear list of Parts
            roProperties.ItemCode.Clear();
            roProperties.ItemName.Clear();
            roProperties.ItemPrice.Clear();
            roProperties.ItemQuantity.Clear();
            roProperties.ItemTotalPrice.Clear();

            //Clear list of service.
            roProperties.ServiceDescription.Clear();
            roProperties.ServiceHours.Clear();
            roProperties.ServicePrice.Clear();
            roProperties.ServiceTotalPrice.Clear();
        }

        private void checkUserRole()
        {
            DBConnection dbcon = new DBConnection();
            sqlQuery = "SELECT * FROM Employee WHERE Employee_ID='" + LoginForm.id + "'";
            OleDbDataReader empReader = dbcon.ConnectToOleDB(sqlQuery);
            bool employeeExist = false;

            while (empReader.Read())
            {
                if (empReader["Employee_ID"].ToString().Equals(LoginForm.id, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (empReader["Role"].ToString().Equals("ServiceAdvisor", StringComparison.InvariantCultureIgnoreCase))
                    {
                        croServiceDescription.Enabled = true;
                        croServiceHourTextbox.Enabled = true;
                        croServicePrice.Enabled = true;
                        addServiceBuutton.Enabled = true;
                        serviceRemoveButton.Enabled = false;
                        ModeOfPaymentGroupBox.Enabled = true;
                        customerRequestTextbox.Enabled = true;
                        updateButton.Enabled = true;
                        PartsDataGrid.Enabled = true;
                        croPartsNameTextBox.Enabled = true;
                        croPartsQuantityTextbox.Enabled = true;
                        croPartsUnitPriceTextbox.Enabled = true;
                        partsAddButton.Enabled = true;
                        removeBTN.Enabled = false;

                    }
                    if (empReader["Role"].ToString().Equals("ServiceAdmin", StringComparison.InvariantCultureIgnoreCase))
                    {
                        croServiceDescription.Enabled = true;
                        croServiceHourTextbox.Enabled = true;
                        croServicePrice.Enabled = true;
                        addServiceBuutton.Enabled = true;
                        serviceRemoveButton.Enabled = true;
                        ModeOfPaymentGroupBox.Enabled = true;
                        customerRequestTextbox.Enabled = true;
                        updateButton.Enabled = true;
                        PartsDataGrid.Enabled = true;
                        croPartsNameTextBox.Enabled = true;
                        croPartsQuantityTextbox.Enabled = true;
                        croPartsUnitPriceTextbox.Enabled = true;
                        partsAddButton.Enabled = true;
                        removeBTN.Enabled = true;

                    }
                    if (empReader["Role"].ToString().Equals("Admin", StringComparison.InvariantCultureIgnoreCase))
                    {
                        croServiceDescription.Enabled = true;
                        croServiceHourTextbox.Enabled = true;
                        croServicePrice.Enabled = true;
                        addServiceBuutton.Enabled = true;
                        serviceRemoveButton.Enabled = true;
                        ModeOfPaymentGroupBox.Enabled = true;
                        customerRequestTextbox.Enabled = true;
                        updateButton.Enabled = true;
                        PartsDataGrid.Enabled = true;
                        croPartsNameTextBox.Enabled = true;
                        croPartsQuantityTextbox.Enabled = true;
                        croPartsUnitPriceTextbox.Enabled = true;
                        partsAddButton.Enabled = true;
                        removeBTN.Enabled = true;

                    }
                }
            }
        }

        AutoCompleteStringCollection roAutoCompletion = new AutoCompleteStringCollection();
        public void AutoCompleteRepairOrder()
        {
            DBConnection dbcon = new DBConnection();
            sqlQuery = "SELECT RO_Number FROM RepairOrder";
            OleDbDataReader roReader = dbcon.ConnectToOleDB(sqlQuery);

            while (roReader.Read())
            {
                roAutoCompletion.Add(roReader["RO_Number"].ToString());
            }

            uroSearchRONumberTextbox.AutoCompleteMode = AutoCompleteMode.Suggest;
            uroSearchRONumberTextbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            uroSearchRONumberTextbox.AutoCompleteCustomSource = roAutoCompletion;

            roReader.Close();
            dbcon.CloseConnection();

        }

        private void EditRepairOrderForm_Load(object sender, EventArgs e)
        {
            AutoCompleteRepairOrder();
            Auto();
            AutoCompleteService();
            panel2.HorizontalScroll.Maximum = 0;
            panel2.AutoScroll = false;
            panel2.VerticalScroll.Visible = false;
            panel2.AutoScroll = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            updateRO();
        }

        private void updateRO()
        {

            DBConnection dbcon = new DBConnection();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            bool isROExist = false;



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

            if (isROExist)
            {
                cmd.CommandText = "UPDATE RepairOrder SET [Plate_Number] = ? , [Created_By] = ? , [Updated_By] = ? , [Date_Updated] = ? , [Payment_Method] = ? , [Customer_Request] = ? ," +
                    "[GrandTotal] = ? , [Status] = ? , [Discount] = ? , [First_Name] = ? , [Last_Name] = ? , [Address] = ? , [Contact_Number] = ? , [Mileage] = ? , " +
                    "[Car_Brand] = ? , [Car_Model] = ? , [Chasis_Number] = ? , [Engine_Number] = ?, [color_car] = ? , [email_address] = ? , [promise_time] = ? , [drivers_name] = ?" +
                    "WHERE RO_Number ='" + croRONumberTextbox.Text.ToString() + "'";

                cmd.Parameters.Add("@Plate_Number", OleDbType.VarChar).Value = croPlateNoTextbox.Text.ToString();
                cmd.Parameters.Add("@Created_By", OleDbType.VarChar).Value = LoginForm.fname + " " + LoginForm.lname;
                cmd.Parameters.Add("@Updated_By", OleDbType.VarChar).Value = LoginForm.lname;
                cmd.Parameters.Add("@Date_Updated", OleDbType.Date).Value = getDateToday();
                cmd.Parameters.Add("@Payment_Method", OleDbType.VarChar).Value = getPaymentMethod();
                cmd.Parameters.Add("@Customer_Request", OleDbType.VarChar).Value = customerRequestTextbox.Text.ToString();
                cmd.Parameters.Add("@GrandTotal", OleDbType.Integer).Value = int.Parse(croGrandTotal.Text.ToString());
                cmd.Parameters.Add("@Status", OleDbType.VarChar).Value = "Pending";
                cmd.Parameters.Add("@Discount", OleDbType.Integer).Value = int.Parse(croDiscountTextbox.Text.ToString());

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
                //new fields
                cmd.Parameters.Add("@color_car", OleDbType.VarChar).Value = ColorTxtBox.Text.ToString();
                cmd.Parameters.Add("@email_address", OleDbType.VarChar).Value = EmailAddTxtBox.Text.ToString();
                cmd.Parameters.Add("@promise_time", OleDbType.VarChar).Value = PromiseTxtBox.Text.ToString();
                cmd.Parameters.Add("@drivers_name", OleDbType.VarChar).Value = DriversTxtBox.Text.ToString();

                cmd.Connection = dbcon.openConnection();
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM RepairOrderParts";
                cmd.Connection = dbcon.openConnection();
                cmd.ExecuteNonQuery();

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

                // Updating Service
                cmd.Parameters.Clear();
                cmd.CommandText = "DELETE FROM RepairOrderService";
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

                repairOrder.Close();
                dbcon.CloseConnection();
                MessageBox.Show("RO is sucessfully Updated.");
                this.Hide();
                this.Close();

            }


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

        private void uroSearchRONumberTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchRONumber();
            }
        }

        private void croPartsNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PopulatePartsWithoutPackages();
            }
        }

        private void PopulatePartsWithoutPackages()
        {
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

        private void partsAddButton_Click(object sender, EventArgs e)
        {
            FillPartsGridWithoutPackage();
            computeGrandTotal();
            croPartsQuantityTextbox.Clear();
            croPartsNameTextBox.Clear();
            croPartsUnitPriceTextbox.Clear();
        }

        private void computeGrandTotal()
        {
            grandTotal = 0.0;
            grandTotal = computeTotal() - getDiscount();
            croGrandTotal.Text = grandTotal.ToString();
        }

        private int getDiscount()
        {
            int discount = 0;
            if (!String.IsNullOrEmpty(croDiscountTextbox.Text))
            {
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

        public bool isPartsFieldValidWithoutPackage()
        {
            Boolean isValid = true;
            if (String.IsNullOrEmpty(croPartsQuantityTextbox.Text))
            {
                isValid = false;
                errorProvider.SetError(croPartsQuantityTextbox, "This field is required.");
            }
            if (String.IsNullOrEmpty(croPartsUnitPriceTextbox.Text))
            {
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

        private void FillPartsGridWithoutPackage()
        {
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
            }

        }

        private void clearPartsTextbox()
        {
            croPartsNameTextBox.Text = "";
            croPartsQuantityTextbox.Text = "";
            croPartsUnitPriceTextbox.Text = "";

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
      

        private void removeBTN_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this selected item?", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


            DBConnection dbcon = new DBConnection();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;

            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in PartsDataGrid.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "DELETE FROM RepairOrderParts " +
                                          "WHERE [RO_Number] = '" + croRONumberTextbox.Text.ToString() +
                                          "'AND [Item_Code] = '" + PartsDataGrid.Rows[PartsDataGrid.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";
                        cmd.Connection = dbcon.openConnection();
                        cmd.ExecuteNonQuery();
                        PartsDataGrid.Rows.Remove(row);
                    }
                }

                croPartsNameTextBox.Text = "";
                croPartsQuantityTextbox.Text = "";
                croPartsUnitPriceTextbox.Text = "";
                computeGrandTotal();
            }
            else if (dialogResult == DialogResult.No)
            {
                //Won't remove any item if cancel
            }
        }

        private void croServiceDescription_KeyDown(object sender, KeyEventArgs e)
        {
            
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
            else
            {
                computeGrandTotal();
            }

            partsReader.Close();
            dbcon.CloseConnection();

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

        private void addServiceBuutton_Click(object sender, EventArgs e)
        {
            FillServiceGridWithoutPackage();
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

        private void FillServiceGridWithoutPackage()
        {
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

        private void clearServiceTextbox()
        {
            croServiceDescription.Text = "";
            croServiceHourTextbox.Text = "";
            croServicePrice.Text = "";

        }

        public bool isServiceFieldValidWitoutPackage()
        {
            Boolean isValid = true;

            if (String.IsNullOrEmpty(croServiceDescription.Text))
            {
                isValid = false;
                errorProvider.SetError(croServiceDescription, "This field is required.");
            }
            if (String.IsNullOrEmpty(croServiceHourTextbox.Text))
            {
                isValid = false;
                errorProvider.SetError(croServiceHourTextbox, "This field is required.");
            }
            if (String.IsNullOrEmpty(croServicePrice.Text))
            {
                isValid = false;
                errorProvider.SetError(croServicePrice, "This field is required.");
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(croServiceHourTextbox.Text, "^[0-9]([.,][0-9]{1,3})?$") || String.IsNullOrEmpty(croServiceHourTextbox.Text))
            {
                isValid = false;
                errorProvider.SetError(croServiceHourTextbox, "This field only accepts numeric value.");
            }
            else
                errorProvider.SetError(croServiceHourTextbox, "");

            if (!System.Text.RegularExpressions.Regex.IsMatch(croServicePrice.Text, "^[0-9]([.,][0-9]{1,3})?$") || String.IsNullOrEmpty(croServicePrice.Text))
            {
                isValid = false;
                errorProvider.SetError(croServicePrice, "This field only accepts numeric value.");
            }
            else
                errorProvider.SetError(croServicePrice, "");



            return isValid;
        }

        private void croServiceDescription_KeyDown_1(object sender, KeyEventArgs e)
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
                        isPackageAdded = true;
                    }
                }

                if (!isPackageAdded)
                {
                    PopulateServicePackages();
                    croServiceDescription.Clear();
                }

            }
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

        private void serviceRemoveButton_Click(object sender, EventArgs e)
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

        private void addServiceBuutton_Click_1(object sender, EventArgs e)
        {
            FillServiceGridWithoutPackage();
        }

        private void partsAddButton_Click_1(object sender, EventArgs e)
        {
            FillPartsGridWithoutPackage();
            computeGrandTotal();
            croPartsQuantityTextbox.Clear();
            croPartsNameTextBox.Clear();
            croPartsUnitPriceTextbox.Clear();
        }

        private void removeBTN_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this selected item?", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


            DBConnection dbcon = new DBConnection();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;

            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in PartsDataGrid.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "DELETE FROM RepairOrderParts " +
                                          "WHERE [RO_Number] = '" + croRONumberTextbox.Text.ToString() +
                                          "'AND [Item_Code] = '" + PartsDataGrid.Rows[PartsDataGrid.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'";
                        cmd.Connection = dbcon.openConnection();
                        cmd.ExecuteNonQuery();
                        PartsDataGrid.Rows.Remove(row);
                    }
                }

                croPartsNameTextBox.Text = "";
                croPartsQuantityTextbox.Text = "";
                croPartsUnitPriceTextbox.Text = "";
                computeGrandTotal();
            }
            else if (dialogResult == DialogResult.No)
            {
                //Won't remove any item if cancel
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            updateRO();
        }

        private void croPartsNameTextBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PopulatePartsWithoutPackages();
            }
        }

        private void croContactNumberTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void croRONumberTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void CroSearchButton_Click(object sender, EventArgs e)
        {

        }

        private void uroSearchRONumberTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

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

        public void clearPartsErrorFields()
        {
            errorProvider.SetError(croPartsQuantityTextbox, "");
            errorProvider.SetError(croPartsNameTextBox, "");
            errorProvider.SetError(croPartsUnitPriceTextbox, "");
            errorProvider.SetError(serviceDataGridView, "");
            errorProvider.SetError(PartsDataGrid, "");
        }
    }

}
