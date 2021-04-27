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
    public partial class PrintPartsForm : Form
    {
        string DatabaseLocation = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\192.168.1.201\c$\database\raceup_db_new3.accdb";
        ShowListofOrderPartsForm LR2;
        public PrintPartsForm(ShowListofOrderPartsForm showListofOrder)
        {
            InitializeComponent();
            this.LR2 = showListofOrder;
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            ROnumberLabel.Text = LR2.ROnumberLabel.Text;
            ROnumberLabel.Visible = false;

            ShowROServiceInfo();
            PartsTable();
            
        }

        private void ROnumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void PartsTable()
        {
            RODataSet showtable = new RODataSet();
            OleDbConnection connection2 = new OleDbConnection(DatabaseLocation);

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT RO_Number, Item_Code, Parts_Quantity, Item_Name, Unit_Price, Total_Price_Parts FROM RepairOrderParts Where CStr(RO_Number)  = '" + ROnumberLabel.Text + "'", connection2);
            dataAdapter.Fill(showtable, showtable.Tables[0].TableName);
            ReportDataSource reportData = new ReportDataSource("ROTableParts", showtable.Tables[0]);

            this.reportViewer1.LocalReport.DataSources.Add(reportData);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
        private void ShowROServiceInfo()
        {
            RODataSet customerProfile = new RODataSet();
            OleDbConnection connection2 = new OleDbConnection(DatabaseLocation);

            OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter("SELECT CustomerProfile.customer_id, RepairOrder.Plate_Number, RepairOrder.Date_Created, RepairOrder.Payment_Method, RepairOrder.Customer_Request, RepairOrderParts.Item_Code, RepairOrderParts.Item_Name, RepairOrderParts.Parts_Quantity, RepairOrderParts.Unit_Price, RepairOrderParts.Total_Price_Parts, RepairOrderService.Service_Description, RepairOrderService.Service_Quantity, RepairOrderService.Service_Price, RepairOrderService.Total_Price, CustomerProfile.first_name, CustomerProfile.last_name, CustomerProfile.Address, CustomerProfile.contact_number, CustomerProfile.Plate_Number AS Expr1, CustomerProfile.car_brand, CustomerProfile.car_model, CustomerProfile.chasis_number, CustomerProfile.engine_number, CustomerProfile.Mileage FROM(((CustomerProfile INNER JOIN RepairOrder ON CustomerProfile.Plate_Number = RepairOrder.Plate_Number) INNER JOIN RepairOrderParts ON RepairOrder.RO_Number = RepairOrderParts.RO_Number) INNER JOIN RepairOrderService ON RepairOrder.RO_Number = RepairOrderService.RO_Number) Where CStr(RepairOrderService.RO_Number)  = '" + ROnumberLabel.Text + "'", connection2);
            dataAdapter2.Fill(customerProfile, customerProfile.Tables[0].TableName);
            ReportDataSource reportData2 = new ReportDataSource("ROAllInfo", customerProfile.Tables[0]);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportData2);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("ReportParameter_RO_Number", LR2.ROnumberLabel.Text));

            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
        }

        public static List<string> GetText(string text, int width)
        {
            string[] palabras = text.Split(' ');
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            int length = palabras.Length;
            List<string> resultado = new List<string>();
            for (int i = 0; i < length; i++)
            {
                sb1.AppendFormat("{0} ", palabras[i]);
                if (sb1.ToString().Length > width)
                {
                    resultado.Add(sb2.ToString());
                    sb1 = new StringBuilder();
                    sb2 = new StringBuilder();
                    i--;
                }
                else
                {
                    sb2.AppendFormat("{0} ", palabras[i]);
                }
            }
            resultado.Add(sb2.ToString());

            List<string> resultado2 = new List<string>();
            string temp;

            int index1, index2, salto;
            string target;
            int limite = resultado.Count;
            foreach (var item in resultado)
            {
                target = " ";
                temp = item.ToString().Trim();
                index1 = 0; index2 = 0; salto = 2;

                if (limite <= 1)
                {
                    resultado2.Add(temp);
                    break;
                }
                while (temp.Length <= width)
                {
                    if (temp.IndexOf(target, index2) < 0)
                    {
                        index1 = 0; index2 = 0;
                        target = target + " ";
                        salto++;
                    }
                    index1 = temp.IndexOf(target, index2);
                    temp = temp.Insert(temp.IndexOf(target, index2), " ");
                    index2 = index1 + salto;

                }
                limite--;
                resultado2.Add(temp);
            }
            return resultado2;
        }
    }
}
