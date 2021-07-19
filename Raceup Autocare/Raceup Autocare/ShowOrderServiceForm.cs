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
using Raceup_Autocare.Properties;

namespace Raceup_Autocare
{
    public partial class ShowOrderServiceForm : Form
    {
        Employee emp = new Employee();
        DBConnection dbcon = null;
        OleDbDataReader ServiceReader = null;
        OleDbDataReader ServiceReader2 = null;
        OleDbDataReader ServiceReader3 = null;
        OleDbDataReader ServiceReader4 = null;
        OleDbDataReader customerReader = null;
        string sqlQuery = "";
        
        public ShowOrderServiceForm()
        {
            InitializeComponent();
            checkEmployeeRole();
        }

        private void ShowOrderServiceForm_Load(object sender, EventArgs e)
        {
            //populateRoList();
            dbcon = new DBConnection();
            dbcon.openConnection();


            using (dbcon.openConnection())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT DISTINCT CustomerProfile.Plate_Number,RepairOrder.RO_Number, RepairOrder.Created_By, RepairOrder.Date_Created FROM(CustomerProfile INNER JOIN RepairOrder ON CustomerProfile.Plate_Number = RepairOrder.Plate_Number) INNER JOIN RepairOrderService ON RepairOrder.RO_Number = RepairOrderService.RO_Number WHERE RepairOrderService.Status = 'Pending'", dbcon.openConnection());
                //https://support.microsoft.com/en-us/office/type-conversion-functions-8ebb0e94-2d43-4975-bb13-87ac8d1a2202 reference for converting data from access to compare to int or text(label or textbox)
                DataTable dt = new DataTable();
                da.Fill(dt);

                guna2DataGridView1.DataSource = dt;
                //guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Sort(this.guna2DataGridView1.Columns[2], ListSortDirection.Descending);
            }
            dbcon.CloseConnection();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "Close")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to close this repair order number?", "Closing RO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    CheckRole();
                }
                if (dialogResult == DialogResult.No)
                {
                    //Won't Close RO
                }
            }
            else if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "View")
            {
                ShowListofOrderServiceForm serviceFormInfo = new ShowListofOrderServiceForm();
                serviceFormInfo.ROnumberLabel.Text = this.guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                serviceFormInfo.croPlateNoTextbox.Text = this.guna2DataGridView1.CurrentRow.Cells[1].Value.ToString(); 
                serviceFormInfo.ShowDialog();
            }
        }

        private void checkEmployeeRole()
        {
            dbcon = new DBConnection();
            Boolean found = false;
            string userSql = "SELECT * FROM Employee";
            OleDbDataReader userReader = dbcon.ConnectToOleDB(userSql);
            while (userReader.Read())
            {
                if (userReader["Employee_ID"].ToString().Equals(LoginForm.id))
                {
                    found = true;
                    emp = new Employee(userReader["Username"].ToString(), userReader["emp_pass"].ToString(), userReader["Employee_ID"].ToString(),
                       (bool)userReader["Active"], userReader["First_Name"].ToString(), userReader["Last_Name"].ToString(), userReader["Empoyee_Email"].ToString(),
                       userReader["Role"].ToString(), (DateTime)userReader["Date_Updated"], userReader["Updated_By"].ToString(), (DateTime)userReader["Date_Created"], userReader["Created_By"].ToString());
                    break;
                }

            }

            if (!found)
            {
                userReader.Close();
                dbcon.CloseConnection();
            }
        }

        private void CheckRole()
        {
            if (!emp.Role.ToString().Equals("JobControl") || !emp.Role.ToString().Equals("Admin"))
            {
                MessageBox.Show("Only Admin/Job Control can close this Repair Order", "Can't Close Repair Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                dbcon = new DBConnection();
                string selectquery = "SELECT RO_Number,Check_Parts FROM RepairOrderParts Where CStr(RO_Number) ='" + this.guna2DataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                customerReader = dbcon.ConnectToOleDB(selectquery);
                Boolean found = false;
                while (customerReader.Read())
                {
                    if (customerReader["RO_Number"].ToString().Equals(this.guna2DataGridView1.CurrentRow.Cells[0].Value.ToString(), StringComparison.InvariantCultureIgnoreCase) && customerReader["Check_Parts"].ToString().Equals("Checked", StringComparison.InvariantCultureIgnoreCase))
                    {
                        string sqlQuery2 = "Update RepairOrderService Set Status ='Completed'  Where CStr(RO_Number) ='" + this.guna2DataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";

                        string sqlQuery3 = "Update RepairOrderParts Set Status ='Completed'  Where CStr(RO_Number) ='" + this.guna2DataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";

                        string sqlQuery4 = "Update RepairOrder Set Status ='Completed'  Where CStr(RO_Number) ='" + this.guna2DataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";

                        string sqlQuery5 = "UPDATE Parts INNER JOIN RepairOrderParts ON Parts.Item_Code = RepairOrderParts.Item_Code Set Parts.Quantity = Parts.Quantity - RepairOrderParts.Parts_Quantity Where CStr(RepairOrderParts.RO_Number) ='" + this.guna2DataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";

                        ServiceReader = dbcon.ConnectToOleDB(sqlQuery2);
                        ServiceReader2 = dbcon.ConnectToOleDB(sqlQuery3);
                        ServiceReader3 = dbcon.ConnectToOleDB(sqlQuery4);
                        ServiceReader4 = dbcon.ConnectToOleDB(sqlQuery5);

                        guna2DataGridView1.Rows.RemoveAt(guna2DataGridView1.CurrentRow.Index);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    customerReader.Close();
                    dbcon.CloseConnection();
                    MessageBox.Show("Please check the parts item first.", "Please Check Availability", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void SearchItem(string srchitem)
        {
            dbcon.openConnection();
            sqlQuery = "SELECT RepairOrder.RO_Number, RepairOrder.Plate_Number, RepairOrder.Created_By, RepairOrder.Date_Created FROM RepairOrder Where RepairOrder.RO_Number like '%" + srchitem + "%' AND Status ='Pending'";
            using (dbcon.openConnection())
            {
                OleDbDataAdapter da = new OleDbDataAdapter(sqlQuery, dbcon.openConnection());
                DataTable dt = new DataTable();
                da.Fill(dt);

                guna2DataGridView1.DataSource = dt;
                //PartsDataGrid.AutoGenerateColumns = false;
            }
            dbcon.CloseConnection();
        }

        private void SearchPrtsTextBox_TextChanged_1(object sender, EventArgs e)
        {
            SearchItem(SearchPrtsTextBox.Text);
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
