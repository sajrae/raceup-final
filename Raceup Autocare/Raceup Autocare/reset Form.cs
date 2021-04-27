using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;
using DevExpress.CodeParser;

namespace Raceup_Autocare
{
	public partial class resetForm : Form
	{
		DBConnection dbcon = null;
		Employee emp;
		public resetForm()
		{
			InitializeComponent();

			label4.Text = "";
			label5.Text = "";
			label6.Text = "";

			dbcon = new DBConnection();
			//Boolean found = false;
			string userSql = "SELECT * FROM Employee";
			OleDbDataReader userReader = dbcon.ConnectToOleDB(userSql);
			while (userReader.Read())
			{
				if (userReader["Employee_ID"].ToString().Equals(LoginForm.id)) {

					//found = true;
					 emp = new Employee(userReader["Username"].ToString(), userReader["emp_pass"].ToString(), userReader["Employee_ID"].ToString(),
                        (bool)userReader["Active"],userReader["First_Name"].ToString(), userReader["Last_Name"].ToString(), userReader["Empoyee_Email"].ToString(), 
						userReader["Role"].ToString(), (DateTime)userReader["Date_Updated"], userReader["Updated_By"].ToString(), (DateTime)userReader["Date_Created"], userReader["Created_By"].ToString());
					break;
				}

			}

			
				userReader.Close();
				dbcon.CloseConnection();
				
		}

		private void resetForm_Load(object sender, EventArgs e)
		{

		}

        private void resetBtn_Click(object sender, EventArgs e)
        {
            bool confirm = false;
			bool confirmCurrent = false;

			dbcon = new DBConnection();				
			OleDbCommand cmd = new OleDbCommand();
			cmd.CommandType = CommandType.Text;

			if (currentPassword.Text.Equals(""))
			{
				label4.Text = "Current Password is Empty";
				label4.ForeColor = System.Drawing.Color.Lime;
				label4.Visible = true;
				confirmCurrent = false;
			}
			else if (!currentPassword.Text.Equals(emp.Password))
			{
				label4.Text = "Current Password is Incorrect";
				label4.ForeColor = System.Drawing.Color.Lime;
				label4.Visible = true;
				confirmCurrent = false;
			}
			else if (currentPassword.Text.Equals(emp.Password))
			{
                //Password is confirmed
                label4.Visible = false;
				confirmCurrent = true;

			}

			if (newPassword.Text.Equals("")) {
				label5.Text = "New Password is Empty";
				label5.ForeColor = System.Drawing.Color.Lime;
				label5.Visible = true;
				confirm = false;
			}
			else if (newPassword.Text.Equals(emp.Password)) {
				label5.Text = "Old password and New must not match";
				label5.ForeColor = System.Drawing.Color.Lime;
				label5.Visible = true;
				confirm = false;
			}
			else
			{
				label5.Visible = false;
				confirm = true;
			}
			
			if (confirmPassword.Text.Equals(""))
			{
				label6.Text = "Confirm Password is Empty";
				label6.ForeColor = System.Drawing.Color.Lime;
				label6.Visible = true;
				confirm = false;
			}
			else if (!confirmPassword.Text.Equals(newPassword.Text))
			{
				label6.Text = "Passwords does not match";
				label6.ForeColor = System.Drawing.Color.Lime;
				label6.Visible = true;
				confirm = false;

			}			
			else if(confirmPassword.Text.Equals(currentPassword.Text))
			{
				label6.Text = "Old password and new password should not be the same.";
				label6.ForeColor = System.Drawing.Color.Lime;
				label6.Visible = true;
				confirm = false;				
				
			}
			else if(!confirmPassword.Text.Equals(currentPassword.Text) && confirmPassword.Text.Equals(newPassword.Text) && !confirmPassword.Text.Equals(""))
			{
				label6.Visible = false;
				confirm = true;				
			}

			if (confirm && confirmCurrent) {
				/*//userSql = "UPDATE Employee SET Password= '1234' WHERE Username='" + emp.Username.ToString().Trim() + "'";
				userSql = "UPDATE Employee SET emp_pass='"+newPassword.Text.ToString().Trim() + "' WHERE Username='" + emp.Username.ToString().Trim() + "'";
				//userSql = "UPDATE Employee SET Password ='1234' WHERE Username='" + emp.Username.ToString().Trim() + "'";
				//userSql = "UPDATE Employee SET emp_pass='test12' WHERE Username='test1'";
				userReader = dbcon.ConnectToOleDB(userSql);
				userReader.Close();
				dbcon.CloseConnection();
				this.Close();*/
				cmd.CommandText = @"UPDATE Employee SET [emp_pass] = ? , [Updated_By] = ? , [Date_Updated] = ? WHERE [Username] = ?";
				cmd.Parameters.Add("@Password", OleDbType.VarChar).Value = newPassword.Text.ToString().Trim();
				cmd.Parameters.Add("@Updated_By", OleDbType.VarChar).Value = emp.Lname;
				cmd.Parameters.Add("@Date_Updated", OleDbType.Date).Value = getDateToday();
				cmd.Parameters.Add("@Username", OleDbType.VarChar).Value = emp.Username.ToString().Trim();
				cmd.Connection = dbcon.openConnection();
				cmd.ExecuteNonQuery();
				setUserLoginStatus(false);
				this.Close();
				Message_Reset msg = new Message_Reset();
				msg.TopMost = true;
				msg.Show();
			}
		}
		
		private DateTime getDateToday()
		{
			DateTime dateTimeToday = DateTime.Today;
			return dateTimeToday;
		}

		private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void confirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
			if (e.KeyChar == (char)Keys.Enter)
			{
				resetBtn_Click(sender, e);
			}
				

		}

		private void setUserLoginStatus(bool status)
		{
			DBConnection dbcon = new DBConnection();
			String userSql = "SELECT * FROM Employee";
			OleDbDataReader userReader = dbcon.ConnectToOleDB(userSql);
			while (userReader.Read())
			{
				if (userReader["Username"].ToString() == emp.Username && userReader["emp_pass"].ToString() == emp.Password)
				{
					userSql = "UPDATE Employee SET Signin=" + status + " WHERE Username='" + emp.Username + "'";
					userReader = dbcon.ConnectToOleDB(userSql);
					break;
				}
			}
		}
	}
}
