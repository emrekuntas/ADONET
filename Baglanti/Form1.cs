using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baglanti
{
    public partial class Form1 : Form
    {
        SqlConnection con;     

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString);
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                MessageBox.Show("Database Open");
            }
            else
            {
                MessageBox.Show("Connection Close");
                con.Open();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
                MessageBox.Show("Database Closed");
            }
            else if (con.State == ConnectionState.Closed)
            {
                MessageBox.Show("Database Closed");
            }

        }
    }
}
