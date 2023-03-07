﻿using Filmographys.Class;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Auth.Verification(Login_TextBox.Text, Password_TextBox.Text))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Неверный логин или пароль");
        }
    }
}
