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

namespace Siparisler
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataAdapter adp;
        DataSet ds;
        DataTable tbl;

        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=10.10.22.199;Initial Catalog=NORTHWND2;User ID=test;Password=test");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbl = new DataTable();
            adp = new SqlDataAdapter("Select CustomerID, CompanyName from Customers order by CompanyName;", con);
            adp.Fill(tbl);

            listBox1.DataSource = tbl;
            listBox1.DisplayMember = "CompanyName";
            listBox1.ValueMember = "CustomerID";

            tbl = new DataTable();
            adp = new SqlDataAdapter("Select ShipperID, CompanyName from Shippers order by CompanyName", con);
            adp.Fill(tbl);

            comboBox1.DataSource = tbl;
            comboBox1.DisplayMember = "CompanyName";
            comboBox1.ValueMember = "ShipperID";
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            try
            {
                adp = new SqlDataAdapter("Select CONVERT(nvarchar(10), OrderID) + '      ' +  CONVERT(nvarchar(20), OrderDate,10) as 'ORDERS' from Orders where ShipVia= @Sid and CustomerID = @Cid", con);

                adp.SelectCommand.Parameters.AddWithValue("@Sid", comboBox1.SelectedValue);
                adp.SelectCommand.Parameters.AddWithValue("@Cid", listBox1.SelectedValue);

                tbl = new DataTable();
                adp.Fill(tbl);
                
                listBox2.DataSource = tbl;
                if (tbl.Rows.Count == 0)
                {
                    tbl.Rows.Add("SİPARİŞ YOK");
                }
                listBox2.DisplayMember = "ORDERS";
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }       
}
