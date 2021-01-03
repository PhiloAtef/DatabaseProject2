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
    public partial class Form3 : Form
    {
        public static string currentUsername;
        public static string connectionString = "Data Source = DESKTOP-3JOG73P;Initial Catalog = Project;Integrated Security = True";
        SqlConnection connection = new SqlConnection(connectionString);
        
        SqlDataAdapter adapter;
        DataTable dataTable;
        public Form3()
        {
            InitializeComponent();
            showdata();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            currentUsername = Form1.currentUsername;
        }

        public void showdata()
        {
            adapter = new SqlDataAdapter("SELECT * FROM VideoGame", connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Cells[1].Value.ToString().Split(',').ToList().ForEach(r => listBox1.Items.Add(r.Trim()));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string city = textBox1.Text;
            string street = textBox2.Text;
            int bd = int.Parse(textBox3.Text);
            int an = int.Parse(textBox4.Text);

            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {

                SqlCommand cmd = new SqlCommand("update VideoGame set Quantity = Quantity -1 where GameName = '" + listBox1.Items[i] + "'", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            SqlCommand sq = new SqlCommand("SELECT COUNT(*)FROM Customer_Order;", connection);
            connection.Open();
            int no = (int)sq.ExecuteScalar() + 1;
            connection.Close();

            SqlCommand command = new SqlCommand($"insert into customer_order " +
                "(Order_Date, orderNumber, cust_apartment_no, cust_city, cust_street, cust_building_no)"
                + "values(GETDATE(),'" + no + "','" + an + "','" + city + "','" + street + "','" + bd + "')", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
