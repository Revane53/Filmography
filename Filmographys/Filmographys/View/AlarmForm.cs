using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filmographys.View
{
    public partial class AlarmForm : Form
    {
        public AlarmForm()
        {
            InitializeComponent();
            Accept_Button.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                Accept_Button.Enabled = true;
            else
                Accept_Button.Enabled = false;
        }

        private void Accept_Button_Click(object sender, EventArgs e)
        {
           DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
