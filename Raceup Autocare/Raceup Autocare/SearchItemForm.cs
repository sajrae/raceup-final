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
        string connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\SERVER\Users\SERVER\RaceUp-Autocare\raceup_db_new3.accdb";
        string sqlQuery = "";
        DBConnection dbcon = null;
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

            using (OleDbConnection mscon = new OleDbConnection(connection))
            {
                OleDbDataAdapter da = new OleDbDataAdapter("Select Item_Code, Item_Description , Quantity, Unit_Price From Parts Order by Item_Code ASC ", mscon);
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
            using (OleDbConnection mscon = new OleDbConnection(connection))
            {
                OleDbDataAdapter da = new OleDbDataAdapter(sqlQuery, mscon);
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
