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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _21300031063_Ahmet_Utan
{
    public partial class Form5 : Form
    {
        public Form2 frm2;

        
        SqlCommand cmd;
        SqlDataAdapter da;        //SqlConnection, SqlDataAdapter,SqlCommand ve Dataset
        DataSet ds;

        static string bağ = "Data Source=DESKTOP-9UTNM4A\\SQLEXPRESS01 ; Initial Catalog=dbLogin;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(bağ);
        public Form5()
        {
            InitializeComponent();
        }

        void griddoldur()
        {
            con = new SqlConnection("Data Source=DESKTOP-9UTNM4A\\SQLEXPRESS01 ; Initial Catalog=dbLogin;Integrated Security=SSPI");
            da = new SqlDataAdapter("Select * From ogr_not", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "ogr_not");
            dataGridView1.DataSource = ds.Tables["ogr_not"];
            con.Close();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            griddoldur();
        }
        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            

            con.Open();
            string kayıt =  "Update ogr_not set vize=@vize,final=@final,ort=@ort,harf_notu=@harf_notu where okul_no=@okul_no";
            SqlCommand cmd = new SqlCommand(kayıt, con);

            cmd.Parameters.AddWithValue("@vize", textBox1.Text);
            cmd.Parameters.AddWithValue("@final", textBox2.Text);
            cmd.Parameters.AddWithValue("@ort", label5.Text);
            cmd.Parameters.AddWithValue("@harf_notu", label6.Text);
            cmd.Parameters.AddWithValue("@okul_no",dataGridView1.Rows[i].Cells[0].Value);


            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Eklendi");
            griddoldur();


        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            label5.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            label6.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int vize, final;
            double ort;
            vize = Convert.ToInt32(textBox1.Text);
            if (vize <= 0 || vize >= 100)
            {
                MessageBox.Show("lütfen 0-100 arası vize notu giriniz");
                textBox1.Text = "";
                return;
            }
            final = Convert.ToInt32(textBox2.Text);
            if (final <= 0 || final >= 100)
            {
                MessageBox.Show("lütfen 0-100 arası vize notu giriniz");
                textBox2.Text = "";
                return;
            }
            ort = vize * 0.4 + final * 0.6;
            label5.Text = ((int)ort).ToString();
            if (ort <= 30)
            {
                label6.Text = "FF";
            }
            else if (ort <= 50)
            {
                label6.Text =  "FD";
            }
            else if (ort <= 55)
            {
                label6.Text =  "DC";
            }
            else if (ort <= 64)
            {
                label6.Text =  "CC";
            }
            else if (ort <= 70)
            {
                label6.Text =  "CB";
            }
            else if (ort <= 76)
            {
                label6.Text =  "BB";
            }
            else if (ort <= 88)
            {
                label6.Text = "BA";
            }
            else if (ort <= 100)
            {
                label6.Text = "AA";
            }
            else
                MessageBox.Show("lütfen düzgün giriniz");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string kayit = "select * from ogrencikayıt Where okul_no=@okul_no or ogr_ad=@ogr_ad";
            SqlCommand komut = new SqlCommand(kayit, con);
            con.Open();

            komut.Parameters.AddWithValue("@okul_no", textBox3.Text);
            komut.Parameters.AddWithValue("@ogr_ad", textBox4.Text);

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
