using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raceup_Autocare
{
    //DBConnection dbcon = null;
   
    public partial class MenuForm : Form
    {
        Employee emp = new Employee();
        String warningTitle = "Warning";
        String role = "";
        DBConnection dbcon = null;
        private Form currentChildForm;       

        public MenuForm()
        {
            InitializeComponent();
            customizeDesign();
            SidePanel.Visible = false;
            SidePanel2.Visible = false;
            pictureBox2.BringToFront();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
           
            dbcon = new DBConnection();
           
            Boolean found = false;
            string userSql = "SELECT * FROM Employee";
            OleDbDataReader userReader = dbcon.ConnectToOleDB(userSql);
            while (userReader.Read())
            {
                if (userReader["Employee_ID"].ToString().Equals(LoginForm.id))
                {

                    found = true;
                    emp = new Employee(userReader["Username"].ToString(), userReader["emp_pass"].ToString(), userReader["Employee_ID"].ToString(),
                       (bool)userReader["Active"], userReader["First_Name"].ToString(), userReader["Last_Name"].ToString(), userReader["Empoyee_Email"].ToString(),
                       userReader["Role"].ToString(), (DateTime)userReader["Date_Updated"], userReader["Updated_By"].ToString(), (DateTime)userReader["Date_Created"], userReader["Created_By"].ToString());
                    manageRole();
                    break;
                }

            }

            if (!found)
            {
                userReader.Close();
                dbcon.CloseConnection();
            }

            // setUserLoginStatus(true);

            account.Text = "Hi " + emp.Lname.ToString();
            roleOfUser.Text ="Role :"+ emp.Role.ToString();
        }
       
        private void manageRole()
        {
            if (emp.Role.ToString().Equals("Admin"))
            {
                PartsBtn.Visible = true;
                SearchItemBTN.Visible = true;
                OrderBtn.Visible = true;
                CreateROBtn.Visible = true;
                CreateCustProfileBtn.Visible = true;
                ServiceROBTN.Visible = true;
                guna2Button1.Visible = true;
                guna2Button2.Visible = true;
                guna2Button3.Visible = true;
            }
            else if (emp.Role.ToString().Equals("ServiceAdvisor") || emp.Role.ToString().Equals("ServiceAdmin"))
            {
                OrderBtn.Visible = true;
                CreateROBtn.Visible = true;
                CreateCustProfileBtn.Visible = true;
                editRepairOrderButton.Visible = true;
                PartsBtn.Visible = true;
                SearchItemBTN.Visible = true;
                guna2Button1.Visible = false;
                guna2Button2.Visible = false;
                guna2Button3.Visible = true;
            }
            else if (emp.Role.ToString().Equals("PartsAdvisor") || emp.Role.ToString().Equals("PartsAdmin"))
            {
                OrderBtn.Visible = true;
                editRepairOrderButton.Visible = true;
                CreateROBtn.Visible = false;
                CreateCustProfileBtn.Visible = false;
                ServiceROBTN.Visible = false;
                guna2Button1.Visible = true;
                guna2Button2.Visible = true;
                guna2Button3.Visible = true;
            }
            else
            {
                PartsBtn.Visible = false; ;
                SearchItemBTN.Visible = false;
                OrderBtn.Visible = false;
                CreateROBtn.Visible = false;
                CreateCustProfileBtn.Visible = false;
                ServiceROBTN.Visible = false;
                guna2Button1.Visible = false;
                guna2Button2.Visible = false;
                guna2Button3.Visible = false;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            
        }
       
        private void guna2Button1_Click(object sender, EventArgs e)
        { 
            SidePanel.Height = OrderBtn.Height;
            SidePanel.Top = OrderBtn.Top;
            SidePanel.Visible = true;
            //orderProcessingForm1.Show();
            // orderProcessingForm1.BringToFront();
            showSubMenu(SubMenuORPanel);

            //OrderForm order = new OrderForm();

            //if (emp.Role.Equals("Receptionist") || emp.Role.Equals("Manager"))
            //{
            //    order.ShowDialog();
            //}
            //else
            //    OrderBtn.Enabled = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //Draging Form using Title Bar

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            setUserLoginStatus(false);
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void customizeDesign()
        {
            SubMenuORPanel.Visible = false;
        }      

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                //hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void resetPassword_Click_1(object sender, EventArgs e)
        {
            SidePanel.Height = resetPassword.Height;
            SidePanel.Top = resetPassword.Top;
            SidePanel.Visible = true;
            if (role.Equals("Admin1"))
            {
                MessageBox.Show("You are an Admin no need to reset Password", warningTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                resetForm reset = new resetForm();

                reset.ShowDialog();
            }
        }

        private void logout_Click_1(object sender, EventArgs e)
        {
            SidePanel.Height = logout.Height;
            SidePanel.Top = logout.Top;
            SidePanel.Visible = true;
            LoginForm login = new LoginForm();
            setUserLoginStatus(false);
            this.Hide();
            login.ShowDialog();
            this.Close();
           
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            SidePanel.Visible = false;
            SidePanel2.Visible = false;
        }       

        private void OrderBtn_MouseHover(object sender, EventArgs e)
        {
            //orderProsHoverButton.Visible = true;
        }

        private void OrderBtn_MouseLeave(object sender, EventArgs e)
        {
            OrderBtn.ForeColor = Color.LightGray;
        }                            

        private void resetPassword_MouseHover(object sender, EventArgs e)
        {
            //resetPassHoverButton.Visible = true;
        }

        private void resetPassword_MouseLeave(object sender, EventArgs e)
        {
           // resetPassHoverButton.Visible = false;
        }

        private void logout_MouseHover(object sender, EventArgs e)
        {
           // logoutHoverButton.Visible = true;
        }

        private void logout_MouseLeave(object sender, EventArgs e)
        {
           // logoutHoverButton.Visible = false;
        }

        private void guna2Button2_MouseHover(object sender, EventArgs e)
        {
           // partsHoverButton.Visible = true;
        }

        private void guna2Button2_MouseLeave(object sender, EventArgs e)
        {
          //  partsHoverButton.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = PartsBtn.Height;
            SidePanel.Top = PartsBtn.Top;
            SidePanel.Visible = true;
            SidePanel2.Visible = false;
            showSubMenu(SubMenuORPanel2);
            //if (currentChildForm != null)
            //{
            //    currentChildForm.Close();
            //}
        }

        private void CreateROBtn_Click_1(object sender, EventArgs e)
        {
            SidePanel2.Height = CreateROBtn.Height;
            SidePanel2.Top = CreateROBtn.Top;
            SidePanel2.Visible = true;
            OpenChildForm(new CreateROform());
        }

        private void CreateCustProfileBtn_Click(object sender, EventArgs e)
        {
            SidePanel2.Height = CreateCustProfileBtn.Height;
            SidePanel2.Top = CreateCustProfileBtn.Top;
            SidePanel2.Visible = true;
            SidePanel2.BringToFront();
            OpenChildForm(new CreateCustProfForm());
        }

        private void panelDesktop_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void CreateROBtn_MouseLeave_1(object sender, EventArgs e)
        {
            //CreateROBtn.ForeColor = Color.LightGray;
        }

        private void CreateCustProfileBtn_MouseLeave_1(object sender, EventArgs e)
        {

        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SearchItemBTN_Click(object sender, EventArgs e)
        {
            SidePanel2.Height = SearchItemBTN.Height;
            SidePanel2.Top = SearchItemBTN.Top;
            SidePanel2.Visible = true;
            OpenChildForm(new SearchItemForm());
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            SidePanel2.Height = ServiceROBTN.Height;
            SidePanel2.Top = ServiceROBTN.Top;
            SidePanel2.Visible = true;
            SidePanel2.BringToFront();
            OpenChildForm(new ShowOrderServiceForm());
        }       

        private void guna2Button1_Click_2(object sender, EventArgs e)
        {
            SidePanel2.Height = guna2Button1.Height;
            SidePanel2.Top = guna2Button1.Top;
            SidePanel2.Visible = true;
            OpenChildForm(new PartsForm());
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            SidePanel2.Height = guna2Button2.Height;
            SidePanel2.Top = guna2Button2.Top;
            SidePanel2.Visible = true;
            OpenChildForm(new PartsFormChecked());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SidePanel2.Height = guna2Button3.Height;
            SidePanel2.Top = guna2Button3.Top;
            SidePanel2.Visible = true;
            OpenChildForm(new SearchItemForm());
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            setUserLoginStatus(false);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            SidePanel.Height = guna2Button4.Height;
            SidePanel.Top = guna2Button4.Top;
            SidePanel.Visible = true;
            OpenChildForm(new RepairOrderForm());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            SidePanel2.Height = editRepairOrderButton.Height;
            SidePanel2.Top = editRepairOrderButton.Top;
            SidePanel2.Visible = true;
            SidePanel2.BringToFront();
            OpenChildForm(new EditRepairOrderForm());
        }
    }
}
