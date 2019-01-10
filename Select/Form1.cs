using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Select
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        string str;
        SqlDataAdapter adp;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString);
        }//sql

        private void btnShow_Click(object sender, EventArgs e)
        {////
            /////
            try
            {
                ///
                str = "Select FirstName, LastName, BirthDate from Employees";
                adp = new SqlDataAdapter(str, con);
                ds = new DataSet();
                adp.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

    }
}
