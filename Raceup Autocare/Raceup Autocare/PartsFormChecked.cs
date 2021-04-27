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
    public partial class PartsFormChecked : Form
    {
        DBConnection dbcon = null;        
        string sqlQuery = "";

        public PartsFormChecked()
        {
            InitializeComponent();
        }

        private void PartsFormChecked_Load(object sender, EventArgs e)
        {
            dbcon = new DBConnection();
            dbcon.openConnection();

            
            using (dbcon.openConnection())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT DISTINCT RepairOrderParts.RO_Number, RepairOrder.Plate_Number, RepairOrder.Created_By, RepairOrder.Date_Created FROM RepairOrder INNER JOIN RepairOrderParts ON RepairOrder.RO_Number = RepairOrderParts.RO_Number WHERE RepairOrderParts.Status = 'Pending' AND RepairOrderParts.Check_Parts ='Checked'", dbcon.openConnection());
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
                partsFormInfo.CheckpartsBTN.Visible = false;
                partsFormInfo.printButton.Enabled = true;
                partsFormInfo.printpartsButton.Enabled = true;
                partsFormInfo.printButton.Location = new Point(256, 634);
                partsFormInfo.printButton.Size = new Size(266, 52);
                partsFormInfo.printpartsButton.Location = new Point(595, 634);
                partsFormInfo.printpartsButton.Size = new Size(266, 52);
                partsFormInfo.label7.Text = "List of Checked Parts";
                partsFormInfo.ShowDialog();
            }
        }
        private void SearchItem(string srchitem)
        {
            dbcon.openConnection();
            sqlQuery = "SELECT DISTINCT RepairOrderParts.RO_Number, RepairOrder.Plate_Number, RepairOrder.Created_By, RepairOrder.Date_Created FROM RepairOrder INNER JOIN RepairOrderParts ON RepairOrder.RO_Number = RepairOrderParts.RO_Number Where RepairOrderParts.RO_Number like '%" + srchitem + "%' AND RepairOrderParts.Status = 'Pending' AND RepairOrderParts.Check_Parts = 'Checked'";
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

        private void SearchPrtsTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchItem(SearchPrtsTextBox.Text);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
