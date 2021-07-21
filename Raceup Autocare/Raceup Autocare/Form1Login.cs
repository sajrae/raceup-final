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

namespace Raceup_Autocare
{
    public partial class LoginForm : Form
    {
        readonly String expiredPasswordMsg = "Account has been expired, Please reset password.";
        readonly String warningTitle = "Warning";
        readonly String remainingNumberOfDaysMsg = "Your account will be expired after ";
        public static String roles = "";
        public static String id = "";
        public static String lname = "";
        public static String fname = "";
        public static String password = "";
        private Employee emp;
        string userSql = "";
        Boolean userExist = false;
        Boolean isTrialExpired = false;

        public LoginForm()
        {
            InitializeComponent();
            pictureBox1.BringToFront();
        }

        private void UserTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PassTxt.Focus();
            }
        }
        private void PassTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoginBtn_Click(sender, e);
            }
        }


        private void LoginBtn_Click(object sender, EventArgs e)
        {
            DateTime dateTimeToday = DateTime.Today;
            DateTime dateUpdated;
            DBConnection dbcon = new DBConnection();

            userSql = "SELECT * FROM Employee";
            OleDbDataReader userReader = dbcon.ConnectToOleDB(userSql);
            Boolean accountExpired = false;

            while (userReader.Read())
            {
                if (userReader["Username"].ToString() == UserTxt.Text.ToString().Trim() && userReader["emp_pass"].ToString() == PassTxt.Text.ToString().Trim())
                {
                    userExist = true;


                    emp = new Employee(userReader["Username"].ToString(), userReader["emp_pass"].ToString(), userReader["Employee_ID"].ToString(),
                       (bool)userReader["Active"], userReader["First_Name"].ToString(), userReader["Last_Name"].ToString(), userReader["Empoyee_Email"].ToString(),
                       userReader["Role"].ToString(), (DateTime)userReader["Date_Updated"], userReader["Updated_By"].ToString(), (DateTime)userReader["Date_Created"], userReader["Created_By"].ToString());
                    dateUpdated = Convert.ToDateTime(emp.Updated);
                    double totalActiveDays = (dateTimeToday - dateUpdated).TotalDays;

                    userSql = "UPDATE Employee SET Active=True WHERE Username='" + UserTxt.Text.ToString().Trim() + "'";
                    userReader = dbcon.ConnectToOleDB(userSql);

                    //To pass data from forms
                    id = emp.Id;
                    lname = emp.Lname;
                    fname = emp.Fname;

                    // Check if user account is expired.
                    // If expired set active to false.
                    if (totalActiveDays > 60)
                    {
                        MessageBox.Show(expiredPasswordMsg, warningTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        userSql = "UPDATE Employee SET Active=False WHERE Username='" + UserTxt.Text.ToString().Trim() + "'";
                        userReader = dbcon.ConnectToOleDB(userSql);
                        accountExpired = true;
                        break;

                    }
                    // Display number of days remaining after being active for 30 days or more. eg 30 days, 25 days, 20 days remaining.
                    else if (totalActiveDays > 30 && (totalActiveDays % 5) == 0)
                    {
                        double expirationDay = 60 - totalActiveDays;
                        MessageBox.Show(remainingNumberOfDaysMsg + expirationDay + " days.", warningTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MenuForm menu = new MenuForm();
                        menu.Show();
                        break;
                    }


                }
                continue;
            }

            if (!userExist)
            {
                MessageBox.Show("User not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (isUserCurrentlyLogin())
            {
                MessageBox.Show("User Already Login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (userExist && !isUserCurrentlyLogin()  /*&& !checkTestAccount()*/ && !accountExpired)
            {

                //Hide login UI
                this.Hide();
                this.Visible = false;

                //Open Menu;
                MenuForm menu = new MenuForm();
                menu.Show();
                setUserLoginStatus(true);
            }

            userReader.Close();
            dbcon.CloseConnection();

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

            userReader.Close();
            dbcon.CloseConnection();
        }

        private bool isUserCurrentlyLogin()
        {
            DBConnection dbcon = new DBConnection();
            bool isCurrentlyLogin = false;
            userSql = "SELECT * FROM Employee";
            OleDbDataReader userReader = dbcon.ConnectToOleDB(userSql);

            while (userReader.Read())
            {
                if (userReader["Username"].ToString() == UserTxt.Text.ToString().Trim() && userReader["emp_pass"].ToString() == PassTxt.Text.ToString().Trim())
                {
                    isCurrentlyLogin = (bool)userReader["Signin"];
                }
            }

            userReader.Close();
            dbcon.CloseConnection();

            return isCurrentlyLogin;
        }

        private void Username_Click(object sender, EventArgs e)
        {
            //UserTxt.SelectionStart = 0;
            //UserTxt.SelectionLength = UserTxt.Text.Length;
        }

        private void Password_Click(object sender, EventArgs e)
        {
            //PassTxt.SelectionStart = 0;
            //PassTxt.SelectionLength = PassTxt.Text.Length;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserTxt_TextChanged(object sender, EventArgs e)
        {


        }

        private void UserTxt_Enter(object sender, EventArgs e)
        {
            if (UserTxt.Text == "Username")
            {
                UserTxt.Text = null;
            }
        }

        private void UserTxt_Leave(object sender, EventArgs e)
        {
            if (UserTxt.Text == "")
            {
                UserTxt.Text = "Username";
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private Boolean checkTestAccount()
        {
            DBConnection dbcon = new DBConnection();
            userSql = "SELECT * FROM Employee";

            OleDbDataReader userReader = dbcon.ConnectToOleDB(userSql);
            DateTime dateUpdated;

            while (userReader.Read())
            {
                if (UserTxt.Text.ToString().Trim() == "test")
                {
                    if (userReader["Username"].ToString() == "test")
                    {
                        dateUpdated = Convert.ToDateTime(userReader["Date_Updated"].ToString());
                        checkIfTrialExpired(dateUpdated);
                    }

                }
                else {
                    if (UserTxt.Text.ToString().Trim() == "Juan")
                    {
                        if (userReader["Username"].ToString() == "Juan")
                        {
                            dateUpdated = Convert.ToDateTime(userReader["Date_Updated"].ToString());
                            checkIfTrialExpired(dateUpdated);
                        }

                    }
                }
            }

            userReader.Close();
            dbcon.CloseConnection();

            return isTrialExpired;
        }

        private void checkIfTrialExpired(DateTime dateUpdated)
        {
            DateTime dateTimeToday = DateTime.Today;
            DateTime dateExpire;

            dateExpire = dateUpdated.AddDays(10);
            double remainingNumOfDays = (dateExpire - dateTimeToday).TotalDays;

            if (dateTimeToday > dateExpire)
            {
                isTrialExpired = true;
                MessageBox.Show("Your trial version has come to and end.", warningTitle);
            }
            else
            {
                MessageBox.Show("You have " + remainingNumOfDays + " days remaining on your trial version.", warningTitle);
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {           
        }

        public Employee GetEmployee() {
            return emp;
        }

        private void PassTxt_Enter(object sender, EventArgs e)
        {
            if (PassTxt.Text == "PASSWORD")
            {
                PassTxt.Text = null;
            }
        }

        private void PassTxt_Leave(object sender, EventArgs e)
        {
            if (PassTxt.Text == "")
            {
                PassTxt.Text = "PASSWORD";
            }
        }
    }   
}