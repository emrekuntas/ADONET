using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App2
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

        private void button1_Click(object sender, EventArgs e)
        {                      
            try
            {
                string sql = "";
                sql += "insert into Categories(CategoryName, Description) ";
                sql += $"Values('{textBox1.Text}', '{textBox2.Text}');";
                sql += " SELECT @@IDENTITY;";
                SqlCommand cmd = new SqlCommand(sql, con);
                /*
                 SELECT @@IDENTITY Açılmış olan bağlantıda son üretilen identity değerini döndürür. @@IDENTITY tablo ve scope bakmaksızın, connection’da üretilen son identity’yi verir. Dikkat : Eğer Insert yaptığınız tablo’da Trigger varsa, yanlış identity alabilirsiniz.

                SELECT SCOPE_IDENTITY() Açılmış olan bağlantıda ve sorgunun çalıştığı scope’ta son üretilen identity’yi döndürür. Trigger kullanılan tablolarda @@IDENTITY yerine SCOPE_IDENTITY() kullanılması tavsiye edilir.

                 SELECT IDENT_CURRENT(tablename) Bağlantı ve scope bakmaksızın, parametre olarak verilen tabloda üretilen son identity değerini döndürür. 
                 * /

                SqlCommand cmd = new SqlCommand(sql, con);

                /************************************************************
                * cmd.ExecuteNonQuery Etkilenen Kayit sayisini geri verir   *
                * cmd.ExecuteReader DataReader Nesnesi geri verir           *          
                * cmd.ExecuteScalar Tek bir değer geri verir                *
                *************************************************************/

                con.Open();
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                if (id > 0)
                {
                    MessageBox.Show(id.ToString() + " Id'li Kayit Eklendi");
                }
                else
                {
                    MessageBox.Show("Olmadı Bidaha!!!");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DEkleCat", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@description", textBox2.Text);
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Eklendi");
                }
                else
                {
                    MessageBox.Show("Olmadı Bidaha!!!");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                sql = $"Delete from Categories where CategoryName = '{textBox1.Text}' ";

                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Silindi");
                }
                else
                {
                    MessageBox.Show("Olmadı Bidaha!!!");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
