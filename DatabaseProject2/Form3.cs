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
    }
}
