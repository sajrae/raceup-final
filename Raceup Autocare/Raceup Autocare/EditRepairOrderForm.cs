﻿using System;
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
    public partial class EditRepairOrderForm : Form
    {
        public EditRepairOrderForm()
        {
            InitializeComponent();
        }

        private void uroSearchPlateNoTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {                
            }
        }
    }
}
