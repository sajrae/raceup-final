using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raceup_Autocare
{
    public partial class SearchItemForm : Form
    {
        string sqlQuery = "";
        DBConnection dbcon = null;
        OleDbDataReader customerReader = null;
        public SearchItemForm()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void SearchItemForm_Load(object sender, EventArgs e)
        {
            dbcon = new DBConnection();
            dbcon.openConnection();

            using (dbcon.openConnection())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("Select Item_Code, Item_Description , Quantity, Unit_Price From Parts Order by Item_Code ASC ", dbcon.openConnection());
                DataTable dt = new DataTable();
                da.Fill(dt);

                PartsDataGrid.DataSource = dt;
                //PartsDataGrid.AutoGenerateColumns = false;
            }
            dbcon.CloseConnection();
        }

        private void SearchPrtsTextBox_TextChanged_1(object sender, EventArgs e)
        {
            SearchItem(SearchPrtsTextBox.Text);
        }

        private void SearchItem(string srchitem)
        {
            dbcon.openConnection();
            sqlQuery = "Select Item_Code, Item_Description , Quantity, Unit_Price From Parts Where Item_Code like '%" + srchitem + "%' OR Item_Description like '%" + srchitem + "%' Order by Item_Code ASC";
            using (dbcon.openConnection())
            {
                OleDbDataAdapter da = new OleDbDataAdapter(sqlQuery, dbcon.openConnection());
                DataTable dt = new DataTable();
                da.Fill(dt);

                PartsDataGrid.DataSource = dt;
                //PartsDataGrid.AutoGenerateColumns = false;
            }
            dbcon.CloseConnection();
        }

        private void PartsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
