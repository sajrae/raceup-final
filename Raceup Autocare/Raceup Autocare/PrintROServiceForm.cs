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
using Microsoft.Reporting.WinForms;

namespace Raceup_Autocare
{
    public partial class PrintROServiceForm : Form
    {
        DBConnection dbcon = null;
        ShowListofOrderServiceForm LR5;
        public PrintROServiceForm(ShowListofOrderServiceForm showROServiceInfo)
        {
            InitializeComponent();
            this.LR5 = showROServiceInfo;

        }

        private void PrintROServiceForm_Load(object sender, EventArgs e)
        {
            dbcon = new DBConnection();
            ROLabel.Text = LR5.ROnumberLabel.Text;
            ROLabel.Visible = false;
            CreateROform fordiscount = new CreateROform();
            fordiscount.croDiscountTextbox.Text = LR5.DiscountTextBox.Text;

            ShowROServiceInfo();
            PartsTable();
            ShowServiceTable();
        }
        private void ShowServiceTable()
        {
            dbcon.openConnection();

            using (dbcon.openConnection())
            {
                RODataSet showtableservice = new RODataSet();
                OleDbDataAdapter dataAdapte3 = new OleDbDataAdapter("SELECT RO_Number, Service_Description, Service_Quantity, Service_Price, Total_Price FROM RepairOrderService Where CStr(RO_Number)  = '" + ROLabel.Text + "'", dbcon.openConnection());
                dataAdapte3.Fill(showtableservice, showtableservice.Tables[0].TableName);
                ReportDataSource reportData3 = new ReportDataSource("RODataSetTableService", showtableservice.Tables[0]);

                this.reportViewer1.LocalReport.DataSources.Add(reportData3);
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            dbcon.CloseConnection();
        }
        private void PartsTable()
        {
            
            dbcon.openConnection();

            using (dbcon.openConnection())
            {
                RODataSet showtable = new RODataSet();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT RO_Number, Item_Code, Parts_Quantity, Item_Name, Unit_Price, Total_Price_Parts FROM RepairOrderParts Where CStr(RO_Number)  = '" + ROLabel.Text + "'", dbcon.openConnection());
                dataAdapter.Fill(showtable, showtable.Tables[0].TableName);
                ReportDataSource reportData = new ReportDataSource("ROTableParts", showtable.Tables[0]);

                this.reportViewer1.LocalReport.DataSources.Add(reportData);
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            dbcon.CloseConnection();
        }
        private void ShowROServiceInfo()
        {
            using (dbcon.openConnection())
            {
                RODataSet customerProfile = new RODataSet();

                OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter("SELECT CustomerProfile.customer_id, RepairOrder.Plate_Number, RepairOrder.Created_By, RepairOrder.drivers_name, RepairOrder.promise_time, RepairOrder.email_address, RepairOrder.color_car, RepairOrder.Created_By, RepairOrder.drivers_name, RepairOrder.promise_time, RepairOrder.email_address, RepairOrder.color_car, RepairOrder.Date_Created, RepairOrder.Payment_Method, RepairOrder.Customer_Request, RepairOrderParts.Item_Code, RepairOrderParts.Item_Name, RepairOrderParts.Parts_Quantity, RepairOrderParts.Unit_Price, RepairOrderParts.Total_Price_Parts, RepairOrderService.Service_Description, RepairOrderService.Service_Quantity, RepairOrderService.Service_Price, RepairOrderService.Total_Price, CustomerProfile.first_name, CustomerProfile.last_name, CustomerProfile.Address, CustomerProfile.contact_number, CustomerProfile.Plate_Number AS Expr1, CustomerProfile.car_brand, CustomerProfile.car_model, CustomerProfile.chasis_number, CustomerProfile.engine_number, CustomerProfile.Mileage FROM(((CustomerProfile INNER JOIN RepairOrder ON CustomerProfile.Plate_Number = RepairOrder.Plate_Number) INNER JOIN RepairOrderParts ON RepairOrder.RO_Number = RepairOrderParts.RO_Number) INNER JOIN RepairOrderService ON RepairOrder.RO_Number = RepairOrderService.RO_Number) Where CStr(RepairOrderService.RO_Number)  = '" + ROLabel.Text + "'", dbcon.openConnection());
                dataAdapter2.Fill(customerProfile, customerProfile.Tables[0].TableName);
                ReportDataSource reportData2 = new ReportDataSource("ROAllInfo", customerProfile.Tables[0]);

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportData2);
                this.reportViewer1.LocalReport.Refresh();
                this.reportViewer1.RefreshReport();
            }
            dbcon.CloseConnection();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("ReportParameter_GRNDTotal", LR5.GRNTotalTextBox.Text));
            reportParameters.Add(new ReportParameter("ReportParameter_Discount", LR5.DiscountTextBox.Text));
            reportParameters.Add(new ReportParameter("ReportParameter_RO_Number", LR5.ROnumberLabel.Text));
            
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
