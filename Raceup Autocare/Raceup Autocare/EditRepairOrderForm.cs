using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
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

        private void searchRONumber() {
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

        private void checkUserRole() {
            DBConnection dbcon = new DBConnection();
            sqlQuery = "SELECT * FROM Employee WHERE Employee_ID='" + LoginForm.id + "'";
            OleDbDataReader empReader = dbcon.ConnectToOleDB(sqlQuery);
            bool employeeExist = false;

            while (empReader.Read())
            {
                if (empReader["Employee_ID"].ToString().Equals(LoginForm.id, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (empReader["Role"].ToString().Equals("ServiceAdvisor", StringComparison.InvariantCultureIgnoreCase)) {
                        croServiceDescription.Enabled = true;
                        croServiceHourTextbox.Enabled = true;
                        croServicePrice.Enabled = true;
                        addServiceBuutton.Enabled = true;
                        guna2Button2.Enabled = false;
                        ModeOfPaymentGroupBox.Enabled = true;
                        customerRequestTextbox.Enabled = true;
                        saveButton.Enabled = true;
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
                        guna2Button2.Enabled = true;
                        ModeOfPaymentGroupBox.Enabled = true;
                        customerRequestTextbox.Enabled = true;
                        saveButton.Enabled = true;
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
                        guna2Button2.Enabled = true;
                        ModeOfPaymentGroupBox.Enabled = true;
                        customerRequestTextbox.Enabled = true;
                        saveButton.Enabled = true;
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
            panel2.HorizontalScroll.Maximum = 0;
            panel2.AutoScroll = false;
            panel2.VerticalScroll.Visible = false;
            panel2.AutoScroll = true;
        }

        private void uroSearchPlateNoTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {                
            }
        }
    }

}
