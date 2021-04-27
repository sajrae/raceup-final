using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raceup_Autocare
{
    public partial class Message_Reset : Form
    {
        public Message_Reset()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm obj = (MenuForm)Application.OpenForms["MenuForm"];
            obj.Close();
            OpenLoginForm();
        }
        private void OpenLoginForm()
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
