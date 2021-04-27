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
    public partial class PrintCopiesForm : Form
    {

        CreateROform LR1;
        public PrintCopiesForm(CreateROform createROform)
        {
            InitializeComponent();
            this.LR1 = createROform;
        }

        private void PrintCopiesForm_Load(object sender, EventArgs e)
        {
            textBoxRONumber.Text = LR1.croRONumberTextbox.Text;
            textBoxRONumber.Visible = false;
        }

        private void JobORBTN_Click(object sender, EventArgs e)
        {
            LR1.printDocument();
        }

        private void ModeOfPaymentGroupBox_Click(object sender, EventArgs e)
        {

        }

        private void TechROBTN_Click(object sender, EventArgs e)
        {
            LR1.printTechnicianCopy();
        }

        private void JobORBTN_Click_1(object sender, EventArgs e)
        {
            LR1.printJobOrder();
        }
    }
}
