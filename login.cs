using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Employee_Management_Systwm
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=WARUNA-ITD-PROG\MSSQLSERVER01;Initial Catalog=ems;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            string username = textBox1.Text;
            string pass = textBox2.Text;

            string query_string = "SELECT * FROM login WHERE Username='" + username + "' AND password = '" + pass + "'";
            SqlCommand cmnd = new SqlCommand(query_string, con);
            SqlDataReader row = cmnd.ExecuteReader();


            if (row.HasRows)
            {

                this.Hide();
                Registration obj = new Registration();
                obj.Show();


            }
            else
            {
                MessageBox.Show("Invaild Login Credentials, please check Username & Password and try again !", "Invaild Login Details", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you Sure, Do you really want exit....?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
