using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Data.SqlClient;

namespace winDapper
{
    public partial class Form1 : Form
    {
        SqlConnection con;

        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection("Data Source=10.10.22.199;Initial Catalog=NORTHWND2;User ID=test;Password=test");            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var categories = con.Query<Categories>("Select * from Categories");
            comboBox1.DataSource = categories;
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryID";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                var product = con.Query<Products>("Select * from Products where CategoryID = @CategoryID", comboBox1.SelectedItem);
                listBox1.DataSource = product;
                listBox1.DisplayMember = "ProductName";
                listBox1.ValueMember = "ProductID";
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {                   
            try
            {
                var gg = con.Query<UrunSiparis>("UrunSiparisleri", new { productId = ((winDapper.Products)listBox1.SelectedItem).ProductID }, commandType: CommandType.StoredProcedure);
                dataGridView1.DataSource = gg;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            var id = dataGridView1.CurrentRow.Cells[1].Value;
            var a = con.Query<OrderDetail>("select * from [Order Details] where OrderId=@OrderID",new { OrderID=id});
            dataGridView2.DataSource = a;

        }
    }
}
