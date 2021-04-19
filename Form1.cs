using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (username == "" && password =="")
            {
                this.Hide();
                Dashboard ds = new Dashboard();
                ds.Show();
            }
            else
                MessageBox.Show("Wrong username or password");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
