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

namespace JoinApp
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        DataTable tbl;
        SqlDataAdapter adp;

        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbl = new DataTable();
            adp = new SqlDataAdapter("Select CategoryID, CategoryName from Categories order by CategoryId", con);
            adp.Fill(tbl);

            comboBox1.DataSource = tbl;
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryId";          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                adp = new SqlDataAdapter("Select ProductId,ProductName from Products where CategoryId=@id", con);

                adp.SelectCommand.Parameters.AddWithValue("@id", Convert.ToInt32(comboBox1.SelectedValue));

                tbl = new DataTable();
                adp.Fill(tbl);

                listBox1.DataSource = tbl;
                listBox1.DisplayMember = "ProductName";
                listBox1.ValueMember = "ProductId";
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                adp = new SqlDataAdapter("UrunSiparisleri", con);
                adp.SelectCommand.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand.Parameters.AddWithValue("@productId", listBox1.SelectedValue);

                tbl = new DataTable();
                adp.Fill(tbl);
                dataGridView1.DataSource = tbl;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
