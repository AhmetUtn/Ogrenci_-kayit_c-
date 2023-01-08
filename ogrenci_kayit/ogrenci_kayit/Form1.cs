using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // sql bağlıyoruz

namespace _21300031063_Ahmet_Utan
{
    public partial class Form1 : Form
    {

          // global değişkenleri tanımladık
        SqlCommand cmd;
        SqlDataReader dr;

        static string bağ = "Data Source=DESKTOP-9UTNM4A\\SQLEXPRESS01 ; Initial Catalog=dbLogin;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(bağ);

        Form2 frm2 = new Form2();
        public Form1()
        {
            InitializeComponent();
            frm2= new Form2();
            frm2.frm1 = this;

        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { // Giriş Butonu

            string sorgu = "SELECT * FROM tblUser where usr=@user AND pwd=@pass";
            con = new SqlConnection("server=DESKTOP-9UTNM4A\\SQLEXPRESS01 ; Initial Catalog=dbLogin;Integrated Security=SSPI");
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                frm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
                textBox1.Focus();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
