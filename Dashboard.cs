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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Red;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label25.ForeColor = Color.Black;


            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;


        }

        private void btnAddDiagnosis_Click(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Red;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label25.ForeColor = Color.Black;


            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;


        }

        private void btnFullHistory_Click(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Red;
            label7.ForeColor = Color.Black;
            label25.ForeColor = Color.Black;


            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;


            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HospitalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM AddPatient INNER JOIN PatientMore ON AddPatient.PatientID = PatientMore.PatientID", conn);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            dataGridView2.DataSource = DS.Tables[0];
        }

        private void btnHospitalInfo_Click(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Red;
            label25.ForeColor = Color.Black;


            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //AddPatient'daki save butonu
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtPatientname.Text;
                string address = txtAddress.Text;
                Int64 number = Convert.ToInt64(txtContactnum.Text);
                int age = Convert.ToInt32(txtAge.Text);
                string gender = comboBox1.Text;
                string blood_type = txtBloodtype.Text;
                string disease = txtAny.Text;
                int pid = Convert.ToInt32(txtPid.Text);

                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HospitalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO AddPatient(Name,Address,Number,Age,Gender,BloodType,SufferedDisease,PatientID)" +
                " VALUES(@name,@address,@number,@age,@gender,@blood_type,@disease,@pid)", conn);
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("address", address);
                cmd.Parameters.AddWithValue("number", number);
                cmd.Parameters.AddWithValue("age", age);
                cmd.Parameters.AddWithValue("gender", gender);
                cmd.Parameters.AddWithValue("blood_type", blood_type);
                cmd.Parameters.AddWithValue("disease", disease);
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Invalid data format or invalid patient ID.");
            }

            MessageBox.Show("New patient has been recorded.");
            txtPatientname.Clear();
            txtAddress.Clear();
            txtContactnum.Clear();
            txtAge.Clear();
            txtBloodtype.Clear();
            txtAny.Clear();
            txtPid.Clear();
            comboBox1.ResetText();
            panel1.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int pid = Convert.ToInt32(textBox1.Text);

                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HospitalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select*from AddPatient where PatientID =" + pid + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            }
        }

        //Add Diagnosisdeki save butonu
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int pid = Convert.ToInt32(textBox1.Text);
                string symptoms = textBox5.Text;
                string diagnosis = textBox2.Text;
                string medicines = textBox4.Text;
                string ward = comboBox2.Text;
                string type_o_ward = comboBox3.Text;

                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HospitalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();


                SqlCommand cmd = new SqlCommand("INSERT INTO PatientMore(PatientID,Symptoms,Diagnosis,Medicines,Ward,WardType)" +
                    " VALUES(@pid,@symptoms,@diagnosis,@medicines,@ward,@type_o_ward)", conn);


                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("pid", pid);
                cmd.Parameters.AddWithValue("symptoms", symptoms);
                cmd.Parameters.AddWithValue("diagnosis", diagnosis);
                cmd.Parameters.AddWithValue("medicines", medicines);
                cmd.Parameters.AddWithValue("ward", ward);
                cmd.Parameters.AddWithValue("type_o_ward", type_o_ward);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Invalid data format or invalid patient id.");
            }

            MessageBox.Show("Data saved.");

            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox2.ResetText();
            comboBox3.ResetText();

            panel2.Visible=false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //User butonu
        private void User_Click(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label25.ForeColor = Color.Red;


            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HospitalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadOnly;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Doctors", conn);
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            dataGridView3.DataSource = DS.Tables[0];
        }
        private void deleteUserbtn_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            panel7.Visible = false;
        }
        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        //New user add
        private void button2_Click(object sender, EventArgs e)
        {
            string newusername = textBox3.Text;
            string newpassword = textBox6.Text;
            int newauthority;

            if (comboBox4.Text == "Doctor")
                newauthority = 2;
            else
                newauthority = 1;

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HospitalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();


            SqlCommand cmd = new SqlCommand("INSERT INTO Doctors(Username,Password,Authority)" +
                " VALUES(@username,@password,@authority)", conn);


            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("username", newusername);
            cmd.Parameters.AddWithValue("password", newpassword);
            cmd.Parameters.AddWithValue("authority", newauthority);
            cmd.ExecuteNonQuery();

            MessageBox.Show("New user has been added.");

            textBox3.Clear();
            textBox6.Clear();
            comboBox4.Text = "";
        }

        private void updateUsers_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel7.Visible = true;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HospitalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("DELETE from Doctors where Id=@Id", conn);
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("Id", textBox8.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
