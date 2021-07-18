using System;
using System.Collections;
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
    public partial class CreateCustProfForm : Form
    {
       
        public static String roles = "";
        public static String id = "";
        public static String lname = "";
        public static String password = "";
        string sqlQuery = "";
        

        public CreateCustProfForm()
        {
            InitializeComponent();
            

        }
        private DateTime getDateToday()
        {
            DateTime dateTimeToday = DateTime.Today;
            return dateTimeToday;
        }
        private void Click_SaveButton(object sender, EventArgs e)
        {
            OleDbDataReader customerReader = null;
            //DateTime dateTimeToday = DateTime.Today;
            //sqlQuery = "INSERT INTO CustomerProfile (first_name, last_name, Address, contact_number, Plate_Number, created_by, date_created, updated_by, date_updated, car_brand, car_model, chasis_number, engine_number)" +
            //            "VALUES('" + customerFirstNameTxtbox.Text + "','" + customerLastNameTxtbox.Text + "', '" + customerAddressTxtbox.Text + "', '" + customerTelephoneNumTxtbox.Text + "', '" + customerPlateNoTxtbox.Text + "', '" + LoginForm.lname + "', '" + dateTimeToday + "', '" + LoginForm.lname + "', '" + dateTimeToday + "' , '" + customerCarBrand.Text + "' , '" + customerCarModelTxtbox.Text + "' , '" + customerChasisNoTxtbox.Text + "' , '" + customerEngineNumberTxtbox.Text + "'); ";
            if (ValidateFields())
            {
                              
                DBConnection dbcon = new DBConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = @"INSERT INTO CustomerProfile([first_name], [last_name], [Address], [contact_number], [Plate_Number], [active], [created_by], [date_created], [updated_by], [date_updated], [car_brand], [car_model], [chasis_number], [engine_number], [Mileage], [drivers_name], [color_car], [email_address], [promise_time]) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";
                cmd.Parameters.Add("@first_name", OleDbType.VarChar).Value = customerFirstNameTxtbox.Text.ToString();
                cmd.Parameters.Add("@last_name", OleDbType.VarChar).Value = customerLastNameTxtbox.Text.ToString();
                cmd.Parameters.Add("@Address", OleDbType.VarChar).Value = customerAddressTxtbox.Text.ToString();
                cmd.Parameters.Add("@contact_number", OleDbType.VarChar).Value = customerTelephoneNumTxtbox.Text.ToString();
                cmd.Parameters.Add("@Plate_Number", OleDbType.VarChar).Value = customerPlateNoTxtbox.Text.ToString();
                cmd.Parameters.Add("@active", OleDbType.Boolean).Value = true;
                cmd.Parameters.Add("@created_by", OleDbType.VarChar).Value = LoginForm.lname;
                cmd.Parameters.Add("@date_created", OleDbType.Date).Value = getDateToday();
                cmd.Parameters.Add("@updated_by", OleDbType.VarChar).Value = LoginForm.lname;
                cmd.Parameters.Add("@date_updated", OleDbType.Date).Value = getDateToday();
                cmd.Parameters.Add("@car_brand", OleDbType.VarChar).Value = customerCarBrand.Text.ToString();
                cmd.Parameters.Add("@car_model", OleDbType.VarChar).Value = customerCarModelTxtbox.Text.ToString();
                cmd.Parameters.Add("@chasis_number", OleDbType.VarChar).Value = customerChasisNoTxtbox.Text.ToString();
                cmd.Parameters.Add("@engine_number", OleDbType.VarChar).Value = customerEngineNumberTxtbox.Text.ToString();
                cmd.Parameters.Add("@Mileage", OleDbType.Integer).Value = int.Parse(customerMileageTextbox.Text.ToString());
                cmd.Parameters.Add("@drivers_name", OleDbType.VarChar).Value = DriversNameTextBox.Text.ToString();
                cmd.Parameters.Add("@color_car", OleDbType.VarChar).Value = ColorTextBox.Text.ToString();
                cmd.Parameters.Add("@email_address", OleDbType.VarChar).Value = EmailAddTextBox.Text.ToString();
                cmd.Parameters.Add("@promise_time", OleDbType.VarChar).Value = PromiseTimeTextBox.Text.ToString();
                cmd.Connection = dbcon.openConnection();


                if (!isPlateNumberExist())
                {
                    if (ValidateFields())
                    {
                        cmd.ExecuteNonQuery();
                        customerReader = dbcon.ConnectToOleDB(sqlQuery);
                        MessageBox.Show("Customer information is successfullyy saved.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        customerReader.Close();
                        ClearTextBoxes(this.Controls);
                        clearErrorProvider();
                        
                    }
                }
                else
                {
                    MessageBox.Show("Plate number already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MileageErrorProvider.SetError(customerMileageTextbox, "");
                dbcon.CloseConnection();
            }
        }

        public bool ValidateFields()
        {
            var controls = new[] { customerFirstNameTxtbox, customerAddressTxtbox, customerTelephoneNumTxtbox, customerPlateNoTxtbox, customerCarModelTxtbox, customerMileageTextbox };
     
            Boolean isValid = true;
            if (String.IsNullOrEmpty(customerMileageTextbox.Text))
            {
                isValid = false;
                MileageErrorProvider.SetError(customerMileageTextbox, "Please input mileage.");
            }
            if (String.IsNullOrEmpty(customerTelephoneNumTxtbox.Text))
            {
                isValid = false;
                TelephoneErrorProvider.SetError(customerTelephoneNumTxtbox, "Please input contact number.");
            }
            if (String.IsNullOrEmpty(customerFirstNameTxtbox.Text))
            {
                isValid = false;
                nameErrorProvider.SetError(customerFirstNameTxtbox, "Please input first name.");
            }
            if (String.IsNullOrEmpty(customerLastNameTxtbox.Text))
            {
                isValid = false;
                nameErrorProvider.SetError(customerLastNameTxtbox, "Please input last name.");
            }
            if (String.IsNullOrEmpty(customerAddressTxtbox.Text))
            {
                isValid = false;
                AddressErrorProvider.SetError(customerAddressTxtbox, "Please input address.");
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(customerTelephoneNumTxtbox.Text, "^[0-9]*$"))
            {
                isValid = false;
                TelephoneErrorProvider.SetError(customerTelephoneNumTxtbox, "This field only accepts numeric value.");
            }
            if (String.IsNullOrEmpty(customerPlateNoTxtbox.Text))
            {
                isValid = false;
                PlateNoErrorProvider.SetError(customerPlateNoTxtbox, "Please input plate number.");
            }
            if (String.IsNullOrEmpty(customerCarBrand.Text))
            {
                isValid = false;
                CarBrandErrorProvider.SetError(customerCarBrand, "Please select car brand.");
            }
            if (String.IsNullOrEmpty(customerCarModelTxtbox.Text))
            {
                isValid = false;
                CarModelErrorProvider.SetError(customerCarModelTxtbox, "Please input car model.");
            }

            //New Fields
            if (String.IsNullOrEmpty(DriversNameTextBox.Text))
            {
                isValid = false;
                DriverNameProvider.SetError(DriversNameTextBox, "Please input plate number.");
            }
            if (String.IsNullOrEmpty(EmailAddTextBox.Text))
            {
                isValid = false;
                EmailAddProvider.SetError(EmailAddTextBox, "Please input plate number.");
            }
            if (String.IsNullOrEmpty(ColorTextBox.Text))
            {
                isValid = false;
                ColorProvider.SetError(ColorTextBox, "Please input Car Color.");
            }
            if (String.IsNullOrEmpty(PromiseTimeTextBox.Text))
            {
                isValid = false;
                PromiseTime.SetError(PromiseTimeTextBox, "Please input promside time and date.");
            }



            if (!System.Text.RegularExpressions.Regex.IsMatch(customerMileageTextbox.Text, "^[0-9]*$"))
            {
                isValid = false;
                MileageErrorProvider.SetError(customerMileageTextbox, "This field only accepts numeric value.");
            }

            return isValid;
        }

        private void searchPlateNoTxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                searchButton_Click(sender, e);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            PleaseCreateNewCustProf msg = new PleaseCreateNewCustProf();
            DBConnection dbcon = new DBConnection();
            Boolean plateNoExist = false;
            sqlQuery = "SELECT * FROM CustomerProfile";
            OleDbDataReader customerReader = dbcon.ConnectToOleDB(sqlQuery);

            while (customerReader.Read())
            {
              if (customerReader["Plate_Number"].ToString().Equals(searchPlateNoTxtbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    customerFirstNameTxtbox.Text = customerReader["first_name"].ToString();
                    customerLastNameTxtbox.Text = customerReader["last_name"].ToString();
                    customerAddressTxtbox.Text = customerReader["Address"].ToString();
                    customerTelephoneNumTxtbox.Text = customerReader["contact_number"].ToString();
                    customerPlateNoTxtbox.Text = customerReader["Plate_Number"].ToString();
                    customerCarBrand.Text = customerReader["car_brand"].ToString(); 
                    customerCarModelTxtbox.Text = customerReader["car_model"].ToString();
                    customerChasisNoTxtbox.Text = customerReader["chasis_number"].ToString();
                    customerEngineNumberTxtbox.Text = customerReader["engine_number"].ToString();
                    customerMileageTextbox.Text = customerReader["Mileage"].ToString();
                    //
                    DriversNameTextBox.Text = customerReader["drivers_name"].ToString();
                    ColorTextBox.Text = customerReader["color_car"].ToString();
                    EmailAddTextBox.Text = customerReader["email_address"].ToString();
                    PromiseTimeTextBox.Text = customerReader["promise_time"].ToString();

                    plateNoExist = true;
                    customerPlateNoTxtbox.Enabled = false;
                    updateButton.Enabled = true;
                }
            }

            if (!plateNoExist) {
                msg.TopMost = true;
                msg.Show();
                //MessageBox.Show("Plate number does not exist in our database.");
                updateButton.Enabled = false;
                clearTextboxFields();
            }

            customerReader.Close();
            dbcon.CloseConnection();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            DBConnection dbcon = new DBConnection();
            OleDbDataReader customerReader = null;
            DateTime dateTimeToday = DateTime.Today;           
            sqlQuery = "UPDATE CustomerProfile SET first_name = '"+ customerFirstNameTxtbox.Text + "',last_name = '" + customerLastNameTxtbox.Text + "', Address = '" + customerAddressTxtbox.Text +
                "', Plate_Number ='" + customerPlateNoTxtbox.Text + "', updated_by='"+ LoginForm.lname  + "', date_updated='"+ dateTimeToday + 
                "', car_brand = '"+ customerCarBrand.Text  + "', car_model = '"+ customerCarModelTxtbox.Text  + "', chasis_number='" + 
                customerChasisNoTxtbox.Text  + "', engine_number='"+ customerEngineNumberTxtbox.Text + "', Mileage='" + customerMileageTextbox.Text + "', drivers_name = '" + DriversNameTextBox.Text + "', color_car='" +
                ColorTextBox.Text + "', email_address='" + EmailAddTextBox.Text + "', promise_time='" + PromiseTimeTextBox.Text + "' WHERE Plate_Number = '" + 
                searchPlateNoTxtbox.Text.ToString() + "';";

            if (ValidateFields())
            {
                customerReader = dbcon.ConnectToOleDB(sqlQuery);
                MessageBox.Show("Customer information is successfullyy updated.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearTextboxFields();
                clearErrorProvider();
                customerReader.Close();
            }

           
            dbcon.CloseConnection();
            MileageErrorProvider.SetError(customerMileageTextbox, "");

        }

        public void clearTextboxFields() {
            var controls = new[] { customerFirstNameTxtbox, customerLastNameTxtbox, customerAddressTxtbox, customerTelephoneNumTxtbox, customerPlateNoTxtbox, customerCarModelTxtbox, customerChasisNoTxtbox, customerEngineNumberTxtbox, customerMileageTextbox, DriversNameTextBox, ColorTextBox, EmailAddTextBox, PromiseTimeTextBox };

            foreach (var control in controls) {
                control.Clear();
            }

            customerCarBrand.Text = "";
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
            updateButton.Enabled = false;
            customerPlateNoTxtbox.Enabled = true;
            clearErrorProvider();
        }

        private void clearErrorProvider() {
            MileageErrorProvider.SetError(customerMileageTextbox, "");            
            TelephoneErrorProvider.SetError(customerTelephoneNumTxtbox, "");
            EnginerErrorProvider.SetError(customerEngineNumberTxtbox, "");
            ChasisErrorProvider.SetError(customerChasisNoTxtbox, "");
            CarModelErrorProvider.SetError(customerCarModelTxtbox, "");
            CarBrandErrorProvider.SetError(customerCarBrand, "");
            PlateNoErrorProvider.SetError(customerPlateNoTxtbox, "");
            AddressErrorProvider.SetError(customerAddressTxtbox, "");
            nameErrorProvider.SetError(customerLastNameTxtbox, "");
            nameErrorProvider.SetError(customerFirstNameTxtbox, "");
            DriverNameProvider.SetError(customerPlateNoTxtbox, "");
            EmailAddProvider.SetError(customerAddressTxtbox, "");
            ColorProvider.SetError(customerLastNameTxtbox, "");
            PromiseTime.SetError(customerFirstNameTxtbox, "");
        }

        private void customerNameTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void customerCarModelTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        public Boolean isPlateNumberExist()
        {
            DBConnection dbcon = new DBConnection();
            Boolean plateNoExist = false;
            sqlQuery = "SELECT * FROM CustomerProfile";
            OleDbDataReader customerReader = dbcon.ConnectToOleDB(sqlQuery);

            while (customerReader.Read())
            {
                if (customerReader["Plate_Number"].ToString().Equals(customerPlateNoTxtbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    plateNoExist = true;
                }
            }

            customerReader.Close();
            dbcon.CloseConnection();

            return plateNoExist;
        }

        private void CreateCustProfForm_Load(object sender, EventArgs e)
        {
            AutoCompleteService();
        }

        AutoCompleteStringCollection carBrandAutoCompleteCollection = new AutoCompleteStringCollection();

        public void AutoCompleteService()
        {
            string[] carBrands = new string[] { "Toyota", "Honda", "Mitsubishi", "Nissan", "Hyundai"};
            carBrandAutoCompleteCollection.AddRange(carBrands);
            customerCarBrand.AutoCompleteMode = AutoCompleteMode.Suggest;
            customerCarBrand.AutoCompleteSource = AutoCompleteSource.CustomSource;
            customerCarBrand.AutoCompleteCustomSource = carBrandAutoCompleteCollection;
        

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }

}
