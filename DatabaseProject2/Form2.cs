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

namespace DatabaseProject2
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet.Customer' table. You can move, or remove it, as needed.
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                string connectionString = "Data Source = DESKTOP-3JOG73P;Initial Catalog = Project;Integrated Security = True";
                string fname, mname, lname, username;
                int password,phone;
                fname = textBox1.Text; mname = textBox2.Text; lname = textBox3.Text;
                username = textBox4.Text; phone = int.Parse(textBox5.Text); password =int.Parse(textBox6.Text);
                int reenteredpassword = int.Parse(textBox7.Text);
                
                SqlConnection connection = new SqlConnection(connectionString);
                if (password == reenteredpassword)
                {
                    SqlCommand command = new SqlCommand($"insert into customer " +
                  "(cust_fname,cust_mname,cust_lname,cust_username,cust_phone,cust_password)" +
                  "values('" + fname + "','" + mname + "','" + lname + "','" + username + "','" + phone + "','" + password + "')", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.Close();
                }
              
            }
            catch (Exception)
            {
                MessageBox.Show("Process failed sucessfuly ");
                this.Close();
            }
           
           
        }
    }
}
