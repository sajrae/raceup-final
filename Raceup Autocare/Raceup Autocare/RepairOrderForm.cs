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
            TotalROText.Visible = false;
            OpenClosedRO.Visible = false;
        }

        private void RepairOrderForm_Load(object sender, EventArgs e)
        {
            TotalCreatedRO();
        }

        private void TotalCreatedRO()
        {
            dbcon = new DBConnection();
            dbcon.openConnection();

            using (dbcon.openConnection())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT RO_Number, Plate_Number, Created_By, Date_Created FROM RepairOrder Where Status='Pending' OR Status='Completed'", dbcon.openConnection());
                //https://support.microsoft.com/en-us/office/type-conversion-functions-8ebb0e94-2d43-4975-bb13-87ac8d1a2202 reference for converting data from access to compare to int or text(label or textbox)
                DataTable dt = new DataTable();
                da.Fill(dt);

                RepairOrderDGV.DataSource = dt;
                //guna2DataGridView1.AutoGenerateColumns = false;
                this.RepairOrderDGV.Sort(this.RepairOrderDGV.Columns[2], ListSortDirection.Descending);
                OnRowNumberChanged();
                TotalROText.Visible = true;
            }
            dbcon.CloseConnection();
        }

        private void OpenRO()
        {
            dbcon.openConnection();


            using (dbcon.openConnection())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT RO_Number, Plate_Number, Created_By, Date_Created FROM RepairOrder Where Status='Pending'", dbcon.openConnection());
                //https://support.microsoft.com/en-us/office/type-conversion-functions-8ebb0e94-2d43-4975-bb13-87ac8d1a2202 reference for converting data from access to compare to int or text(label or textbox)
                DataTable dt = new DataTable();
                da.Fill(dt);

                RepairOrderDGV.DataSource = dt;
                //guna2DataGridView1.AutoGenerateColumns = false;
                this.RepairOrderDGV.Sort(this.RepairOrderDGV.Columns[2], ListSortDirection.Descending);
                OnRowNumberChanged();
                TotalROText.Visible = true;
                OpenClosedRO.Text = "For Open RO";
                OpenClosedRO.Visible = true;
            }
            dbcon.CloseConnection();
        }

        private void ClosedRO()
        {
            dbcon.openConnection();


            using (dbcon.openConnection())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT RO_Number, Plate_Number, Created_By, Date_Created FROM RepairOrder Where Status='Completed'", dbcon.openConnection());
                //https://support.microsoft.com/en-us/office/type-conversion-functions-8ebb0e94-2d43-4975-bb13-87ac8d1a2202 reference for converting data from access to compare to int or text(label or textbox)
                DataTable dt = new DataTable();
                da.Fill(dt);

                RepairOrderDGV.DataSource = dt;
                //guna2DataGridView1.AutoGenerateColumns = false;
                this.RepairOrderDGV.Sort(this.RepairOrderDGV.Columns[2], ListSortDirection.Descending);
                OnRowNumberChanged();
                TotalROText.Visible = true;
                OpenClosedRO.Text = "For Closed RO";
                OpenClosedRO.Visible = true;
            }
            dbcon.CloseConnection();
        }

        private void SearchItem(string srchitem)
        {
            dbcon = new DBConnection();
            dbcon.openConnection();

            using (dbcon.openConnection())
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT RO_Number, Plate_Number, Created_By, Date_Created FROM RepairOrder Where RO_Number like '%" + srchitem + "%' OR Plate_Number like '%" + srchitem + "%' Order by RO_Number ASC",dbcon.openConnection());
                DataTable dt = new DataTable();
                da.Fill(dt);

                RepairOrderDGV.DataSource = dt;
                //PartsDataGrid.AutoGenerateColumns = false;

            }
            dbcon.CloseConnection();
        }

        private void OnRowNumberChanged()
        {
            TotalROText.Text = RepairOrderDGV.Rows.Count.ToString();
        }


        private void SearchPrtsTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchItem(SearchPrtsTextBox.Text);
        }

        private void CroSearchButton_Click(object sender, EventArgs e)
        {
            if (OpenRORadioButton.Checked == true)
            {
                OpenRO();
                return;
            }
            else if (ClosedRORadioButton.Checked == true)
            {
                ClosedRO();
                return;
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            TotalCreatedRO();
            ClosedRORadioButton.Checked = false;
            OpenRORadioButton.Checked = false;
            OnRowNumberChanged();
            SearchPrtsTextBox.Text = "";
            TotalROText.Visible = true;
            OpenClosedRO.Visible = false;
        }

        private void RepairOrderDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RepairOrderDGV.Columns[e.ColumnIndex].Name == "View")
            {
                ShowListofOrderServiceForm serviceFormInfo = new ShowListofOrderServiceForm();
                serviceFormInfo.ROnumberLabel.Text = this.RepairOrderDGV.CurrentRow.Cells[0].Value.ToString();
                serviceFormInfo.croPlateNoTextbox.Text = this.RepairOrderDGV.CurrentRow.Cells[1].Value.ToString();
                serviceFormInfo.ShowDialog();
                serviceFormInfo.label7.Text = "Repair Order Info";
            }
        }
    }
}
