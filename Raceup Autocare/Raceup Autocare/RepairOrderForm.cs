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
    public partial class RepairOrderForm : Form
    {
        DBConnection dbcon = null;

        public RepairOrderForm()
        {
            InitializeComponent();
        }

        private void RepairOrderForm_Load(object sender, EventArgs e)
        {
            dbcon = new DBConnection();
            dbcon.openConnection();
            using (dbcon.openConnection())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("Select Item_Code, Item_Description , Quantity, Unit_Price From Parts Order by Item_Code ASC ", dbcon.openConnection());
                DataTable dt = new DataTable();
                da.Fill(dt);

                RepairOrderDGV.DataSource = dt;
                //PartsDataGrid.AutoGenerateColumns = false;
            }
            dbcon.CloseConnection();
        }
    }
}
