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


namespace Employee_Management_Systwm
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=WARUNA-ITD-PROG\MSSQLSERVER01;Initial Catalog=ems;Integrated Security=True");
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string empNo = comboBox1.Text;
                string firstName = textBox1.Text;
                string lastName =  textBox2.Text;
                dateTimePicker1.Format = dateTimePicker1.Format;
                dateTimePicker1.CustomFormat = "yyyy/mm/dd";
                DateTime date= Convert.ToDateTime(dateTimePicker1.Text);
                string gender;
                if (radioButton1.Checked)
                {
                    gender = "male";
                }

                else
                {
                    gender = "female";
                }
                string address = richTextBox1.Text;
                string email = textBox3.Text;
                int mobilePhone = int.Parse(textBox4.Text);
                int homePhone = int.Parse(textBox5.Text);
                string departmentName = textBox6.Text;
                string designation = textBox7.Text;
                string employeeType = textBox8.Text;
                string query_insert = "insert into employee values('"+empNo+"','" + firstName + "','" + lastName + "','" + date + "','" + gender + "','" + address + "','" + email + "','" + mobilePhone + "','" + homePhone + "','" + departmentName + "','" + designation + "','" + employeeType + "')";
                if (Con.State == ConnectionState.Closed)
                {
                     Con.Open();
                }
               
                SqlCommand cmnd = new SqlCommand(query_insert,Con);

                cmnd.ExecuteNonQuery();
                Con.Close();
                MessageBox.Show("Record Added Successfully!", "Registered Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                string msg = "Insert.error";
                msg += ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string no = comboBox1.Text;

            if (no != "New Register")
            {
                string firstName = textBox1.Text;
                string lastName = textBox2.Text;
                dateTimePicker1.Format = dateTimePicker1.Format;
                dateTimePicker1.CustomFormat = "yyyy/mm/dd";
                DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
                string gender;
                if (radioButton1.Checked)
                {
                    gender = "male";
                }

                else
                {
                    gender = "female";
                }
                string address = richTextBox1.Text;
                string email = textBox3.Text;
                int mobilePhone = int.Parse(textBox4.Text);
                int homePhone = int.Parse(textBox5.Text);
                string departmentName = textBox6.Text;
                string designation = textBox7.Text;
                string employeeType = textBox8.Text;

                string query_insert = "UPDATE employee SET firstName ='" + firstName + "',lastName = '" + lastName + "',dateOfBirth ='" + date + "',gender ='" + gender + "',address ='" + address + "',emaii ='" + email + "',mobilePhone ='" + mobilePhone + "',homePhone = '" + homePhone + "',departmentName = '" + departmentName + "',designation = '" + designation + "',employeeType = '" + employeeType + " WHERE empNo = " + no;


                Con.Open();
                SqlCommand cmnd = new SqlCommand(query_insert, Con);

                cmnd.ExecuteNonQuery();
                Con.Close();
            }
            MessageBox.Show("Record Updated Successfully", "Update Employed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            radioButton1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            DateTime thisDay = DateTime.Today;
            dateTimePicker1.Text = thisDay.ToString();

            radioButton1.Checked = false;
            radioButton2.Checked = false;

            richTextBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you Sure, Do you want Delete this record ....?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string no = comboBox1.Text;
                string query_insert = "DELETE FROM employee where empNo = " + no + "";
                Con.Open();
                SqlCommand cmnd = new SqlCommand(query_insert, Con);
                cmnd.ExecuteNonQuery();
                Con.Close();
                MessageBox.Show("Record Deleted Successfully!", "Deleted Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var resulit = MessageBox.Show("Are you sure, Do you really want to exit ....?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (resulit == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (resulit == DialogResult.No)
            {
                this.Close();
            }
        }
    }
}
