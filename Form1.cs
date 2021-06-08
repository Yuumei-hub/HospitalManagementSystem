using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

            int authority;
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HospitalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Doctors where Username = @Username and Password=@Password", conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    //admin
                    if (Convert.ToInt32(reader["Authority"]) == 1)
                    {
                        this.Hide();
                        Dashboard ds = new Dashboard();
                        ds.Show();
                    }

                    //doktor
                    else if (Convert.ToInt32(reader["Authority"]) == 2)
                    {
                        this.Hide();
                        
                    }

                    else
                        MessageBox.Show("You do not have authority.");
                }

                else
                {
                    MessageBox.Show("Wrong password or username.");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
