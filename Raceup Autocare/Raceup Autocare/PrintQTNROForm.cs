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
    public partial class PrintQTNROForm : Form
    {
        string DatabaseLocation = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\SERVER\Users\SERVER\RaceUp-Autocare\raceup_db_new3.accdb";
        CreateROform LR4;
        public PrintQTNROForm(CreateROform showROInfo)
        {
            InitializeComponent();
            this.LR4 = showROInfo;
        }

        private void PrintQTNROForm_Load(object sender, EventArgs e)
        {
            ROLabel.Text = LR4.croRONumberTextbox.Text;
            ROLabel.Visible = false;


            ShowROInfo();
            ShowServiceTable();
            ShowPartsTable();
        }

        private void ShowServiceTable()
        {
            QTNRODataSet showtableservice = new QTNRODataSet();
            OleDbConnection con = new OleDbConnection(DatabaseLocation);
            showtableservice.EnforceConstraints = false;
            OleDbDataAdapter dataAdapter3 = new OleDbDataAdapter("SELECT * FROM QuotationService Where Quotation_Number  = '" + ROLabel.Text + "'", con);
            dataAdapter3.Fill(showtableservice, showtableservice.Tables[0].TableName);
            ReportDataSource reportData3 = new ReportDataSource("QuotationService", showtableservice.Tables[0]);

            this.reportViewer1.LocalReport.DataSources.Add(reportData3);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();

        }
        private void ShowPartsTable()
        {
            QTNRODataSet TablePArts = new QTNRODataSet();
            OleDbConnection connection = new OleDbConnection(DatabaseLocation);
            TablePArts.EnforceConstraints = false;
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT * FROM QuotationParts Where Quotation_Number  = '" + ROLabel.Text + "'", connection);
            dataAdapter.Fill(TablePArts, TablePArts.Tables[0].TableName);
            ReportDataSource reportData = new ReportDataSource("QuotationParts", TablePArts.Tables[0]);

            this.reportViewer1.LocalReport.DataSources.Add(reportData);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
        private void ShowROInfo()
        {
            
            QTNRODataSet customerProfile = new QTNRODataSet();
            OleDbConnection connection2 = new OleDbConnection(DatabaseLocation);
            connection2.Open();
            OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter("SELECT * FROM Quotation Where CStr(Quotation_Number)  = '" + ROLabel.Text + "'", connection2);
            dataAdapter2.Fill(customerProfile, customerProfile.Tables[0].TableName);
            ReportDataSource reportData2 = new ReportDataSource("QTNRODataSet", customerProfile.Tables[0]);

            reportViewer1.LocalReport.DataSources.Add(reportData2);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
            connection2.Close();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            ROLabel.Text = LR4.croRONumberTextbox.Text;
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("ReportParameter_RO_Number", ROLabel.Text));
            reportParameters.Add(new ReportParameter("ReportParameter_Discount", LR4.croDiscountTextbox.Text));
            reportParameters.Add(new ReportParameter("ReportParameter_GrandTotal", LR4.croGrandTotal.Text));


            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
