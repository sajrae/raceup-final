using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Raceup_Autocare.Properties;
namespace Raceup_Autocare
{
    public partial class PartsForm : Form
    {
        DBConnection dbcon = null;
        string sqlQuery = "";
        public PartsForm()
        {
            InitializeComponent();
        }
        private void PartsForm_Load(object sender, EventArgs e)
        {
            dbcon = new DBConnection();
            dbcon.openConnection();


            using (dbcon.openConnection())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT DISTINCT RepairOrderParts.RO_Number, RepairOrder.Plate_Number, RepairOrder.Created_By, RepairOrder.Date_Created FROM RepairOrder INNER JOIN RepairOrderParts ON RepairOrder.RO_Number = RepairOrderParts.RO_Number WHERE RepairOrderParts.Status = 'Pending' AND RepairOrderParts.Check_Parts ='Pending'", dbcon.openConnection());
                //https://support.microsoft.com/en-us/office/type-conversion-functions-8ebb0e94-2d43-4975-bb13-87ac8d1a2202 reference for converting data from access to compare to int or text(label or textbox)
                DataTable dt = new DataTable();
                da.Fill(dt);
                guna2DataGridView1.DataSource = dt;
                //guna2DataGridView1.AutoGenerateColumns = false;
                this.guna2DataGridView1.Sort(this.guna2DataGridView1.Columns[2], ListSortDirection.Descending);
            }
            
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "View")
            {
                ShowListofOrderPartsForm partsFormInfo = new ShowListofOrderPartsForm();
                partsFormInfo.ROnumberLabel.Text = this.guna2DataGridView1.CurrentRow.Cells[0].Value.ToString();
                partsFormInfo.croPlateNoTextbox.Text = this.guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
                partsFormInfo.printButton.Visible = false;
                partsFormInfo.CheckpartsBTN.Enabled = true;
                partsFormInfo.printpartsButton.Visible = false;
                partsFormInfo.CheckpartsBTN.Location = new Point(395, 634);
                partsFormInfo.CheckpartsBTN.Size = new Size(328, 52);
                partsFormInfo.ShowDialog();
            }
        }

        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
        private void SearchItem(string srchitem)
        {
            dbcon.openConnection();
            sqlQuery = "SELECT DISTINCT RepairOrderParts.RO_Number, RepairOrder.Plate_Number, RepairOrder.Created_By, RepairOrder.Date_Created FROM RepairOrder INNER JOIN RepairOrderParts ON RepairOrder.RO_Number = RepairOrderParts.RO_Number Where RepairOrderParts.RO_Number like '%" + srchitem + "%' AND RepairOrderParts.Status = 'Pending' AND RepairOrderParts.Check_Parts = 'Pending'";
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

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
