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

namespace _21300031063_Ahmet_Utan
{
    public partial class Form4 : Form
    {
        public Form2 frm2;
                              // global değişkenleri tanımladık
        SqlCommand cmd;
        SqlDataAdapter da;        //SqlConnection, SqlDataAdapter,SqlCommand ve Dataset
        DataSet ds;

        static string bağ = "Data Source=DESKTOP-9UTNM4A\\SQLEXPRESS01 ; Initial Catalog=dbLogin;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(bağ);

        public Form4()
        {
            InitializeComponent();
        }
        void griddoldur()
        {
            con = new SqlConnection("Data Source=DESKTOP-9UTNM4A\\SQLEXPRESS01 ; Initial Catalog=dbLogin;Integrated Security=SSPI");
            da = new SqlDataAdapter("Select * From ogrencikayıt", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "ogrencikayıt");
            dataGridView1.DataSource = ds.Tables["ogrencikayıt"];
            con.Close();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            griddoldur(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kayit = "select * from ogrencikayıt Where okul_no=@okul_no or ogr_ad=@ogr_ad";
            SqlCommand komut = new SqlCommand(kayit,con);
            con.Open();

            komut.Parameters.AddWithValue("@okul_no", textBox1.Text);
            komut.Parameters.AddWithValue("@ogr_ad", textBox2 .Text);

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable(); 
            da.Fill(dt); 
            dataGridView1.DataSource=dt;
            con.Close() ; 

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frm2.Show();
        }
    }
}
