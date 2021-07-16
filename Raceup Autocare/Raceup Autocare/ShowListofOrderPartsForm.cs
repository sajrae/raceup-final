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
using DevExpress.XtraReports.UI;

namespace Raceup_Autocare
{
    public partial class ShowListofOrderPartsForm : Form
    {
        DBConnection dbcon = null;        
        OleDbDataReader customerReader = null;
        string sqlQuery = "";

        public ShowListofOrderPartsForm()
        {
            InitializeComponent();
        }

        private void ShowListofOrderPartsForm_Load(object sender, EventArgs e)
        {
            dbcon = new DBConnection();
            dbcon.openConnection();

            using (dbcon.openConnection())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("Select Item_Code,Item_Name,Parts_Quantity,Unit_Price,Total_Price_Parts from RepairOrderParts Where CStr(RO_Number)  = '" + ROnumberLabel.Text + "' Order by Item_Code", dbcon.openConnection());
                //https://support.microsoft.com/en-us/office/type-conversion-functions-8ebb0e94-2d43-4975-bb13-87ac8d1a2202 reference for converting data from access to compare to int or text(label or textbox)
                DataTable dt = new DataTable();
                da.Fill(dt);

                guna2DataGridView1.DataSource = dt;
            }

            //Customer's info
            sqlQuery = "SELECT * FROM CustomerProfile";
            customerReader = dbcon.ConnectToOleDB(sqlQuery);

            while (customerReader.Read())
            {
                if (customerReader["Plate_Number"].ToString().Equals(croPlateNoTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
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
                }
            }
        }

        private void printButton_Click_1(object sender, EventArgs e)
        {
            PrintPartsForm prtform = new PrintPartsForm(this);

            prtform.ShowDialog();
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CheckpartsBTN_Click(object sender, EventArgs e)
        {
            CheckAvailability();
        }

        private void CheckAvailability()
        {
            Boolean flag = false;
            for (int i = 0; i < guna2DataGridView1.Rows.Count; i++)
            {
                string selectquery = "SELECT Quantity FROM Parts Where CStr(Item_Code) ='" + guna2DataGridView1.Rows[i].Cells[0].Value + "'";
                customerReader = dbcon.ConnectToOleDB(selectquery);

                while (customerReader.Read())
                {
                    if (Convert.ToInt32(customerReader["Quantity"].ToString()) > 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        MessageBox.Show("No Available Stock for Item Code:'" + guna2DataGridView1.Rows[i].Cells[0].Value + "', '"+ guna2DataGridView1.Rows[i].Cells[1].Value + "'", "No Available Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            if (flag)
            {
                MessageBox.Show("All Items are Available", "Items Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            CheckpartsBTN.Enabled = false;
            DisableCheckBTN();
        }

        private void DisableCheckBTN()
        {
            string selectquery = "SELECT * FROM RepairORderParts Where CStr(RO_Number) ='" + ROnumberLabel.Text.ToString() + "'";
            customerReader = dbcon.ConnectToOleDB(selectquery);

                while (customerReader.Read())
                {
                    if (customerReader["RO_Number"].ToString().Equals(ROnumberLabel.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                    dbcon.openConnection();
                        string sqlQuery2 = "Update RepairOrderParts Set Check_Parts = 'Checked' Where CStr(RO_Number) ='" + ROnumberLabel.Text.ToString() + "'";
                        OleDbCommand cmd = new OleDbCommand(sqlQuery2, dbcon.openConnection());
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    dbcon.CloseConnection();
                }
                }
            printButton.Enabled = true;
        }
        private void ROnumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void croContactNumberTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void printpartsButton_Click(object sender, EventArgs e)
        {
            
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
