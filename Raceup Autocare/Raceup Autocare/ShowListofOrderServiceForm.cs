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
    public partial class ShowListofOrderServiceForm : Form
    {
        string sqlQuery = "";
        string sqlQuery2 = "";
        OleDbDataReader customerReader = null;
        OleDbDataReader customerReader2 = null;
        DBConnection dbcon = null;

        public ShowListofOrderServiceForm()
        {
            InitializeComponent();
        }

        private void ShowListofOrderServiceForm_Load(object sender, EventArgs e)
        {
            dbcon = new DBConnection();
            dbcon.openConnection();
            using (dbcon.openConnection())
            {
                //table parts
                OleDbDataAdapter da = new OleDbDataAdapter("Select Item_Code,Item_Name,Parts_Quantity,Unit_Price,Total_Price_Parts from RepairOrderParts Where CStr(RO_Number)  = '" + ROnumberLabel.Text + "'", dbcon.openConnection());
                //https://support.microsoft.com/en-us/office/type-conversion-functions-8ebb0e94-2d43-4975-bb13-87ac8d1a2202 reference for converting data from access to compare to int or text(label or textbox)
                DataTable dt = new DataTable();
                da.Fill(dt);

                //table service
                OleDbDataAdapter da2 = new OleDbDataAdapter("SELECT Service_Description, Service_Quantity, Service_Price, Total_Price FROM RepairOrderService Where CStr(RO_Number)  = '" + ROnumberLabel.Text + "'", dbcon.openConnection());
                //https://support.microsoft.com/en-us/office/type-conversion-functions-8ebb0e94-2d43-4975-bb13-87ac8d1a2202 reference for converting data from access to compare to int or text(label or textbox)
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);

                DataGridViewParts.DataSource = dt;
                DataGridViewService.DataSource = dt2;
                //guna2DataGridView1.AutoGenerateColumns = false;
            }
            //Customer Info
            sqlQuery = "SELECT * FROM RepairOrder";
            customerReader = dbcon.ConnectToOleDB(sqlQuery);

            while (customerReader.Read())
            {
                if (customerReader["Plate_Number"].ToString().Equals(croPlateNoTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    croNameTextbox.Text = customerReader["First_Name"].ToString() + " " + customerReader["Last_Name"].ToString();
                    croAddressTextbox.Text = customerReader["Address"].ToString();
                    croContactNumberTextbox.Text = customerReader["Contact_Number"].ToString();
                    croPlateNoTextbox.Text = customerReader["Plate_Number"].ToString();
                    croCarBrandTextBox.Text = customerReader["Car_Brand"].ToString();
                    croCarModelTextbox.Text = customerReader["Car_Model"].ToString();
                    croChasisNo.Text = customerReader["Chasis_Number"].ToString();
                    croEngineNo.Text = customerReader["Engine_Number"].ToString();
                    GRNTotalTextBox.Text = customerReader["GrandTotal"].ToString();
                    croMileage.Text = customerReader["Mileage"].ToString();
                    ColorTxtBox.Text = customerReader["color_car"].ToString();
                    EmailAddTxtBox.Text = customerReader["email_address"].ToString();
                    PromiseTxtBox.Text = customerReader["promise_time"].ToString();
                    DriversTxtBox.Text = customerReader["drivers_name"].ToString();
                }
            }

            sqlQuery2 = "SELECT RO_Number,Discount FROM RepairOrder";
            customerReader2 = dbcon.ConnectToOleDB(sqlQuery2);

            while (customerReader2.Read())
            {
                if (customerReader2["RO_Number"].ToString().Equals(ROnumberLabel.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    DiscountTextBox.Text = customerReader2["Discount"].ToString();
                }
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            PrintROServiceForm printservice = new PrintROServiceForm(this);
            printservice.ShowDialog();
        }
        private void discount()
        {
            //For Discount

            sqlQuery2 = "SELECT RO_Number,Discount FROM RepairOrder";
            customerReader2 = dbcon.ConnectToOleDB(sqlQuery2);

            while (customerReader2.Read())
            {
                if (customerReader2["RO_Number"].ToString().Equals(ROnumberLabel.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    DiscountTextBox.Text = customerReader2["Discount"].ToString();
                }
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
