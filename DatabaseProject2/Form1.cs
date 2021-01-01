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

namespace DatabaseProject2
{
    public partial class Form1 : Form
    {
        public static string currentUsername;

        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int p = int.Parse(password.Text);
            string connectionString = "Data Source = DESKTOP-3JOG73P;Initial Catalog = Project;Integrated Security = True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from customer where cust_username= '"+username.Text+"' and cust_password = '"+p+"';", connection);
            connection.Open();
            SqlDataReader d = cmd.ExecuteReader();
            if (d.Read())
            {

                currentUsername = username.Text;
                Form3 form3 = new Form3();
                form3.Show();
            }
            else
            {
                MessageBox.Show("please enter valid username and password");
            }
        }
    }
}
