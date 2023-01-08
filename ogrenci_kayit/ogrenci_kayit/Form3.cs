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
    public partial class Form3 : Form
    {
        public Form2 frm2;

         // global değişkenleri tanımladık
        SqlCommand cmd;
        SqlDataAdapter da;        //SqlConnection, SqlDataAdapter,SqlCommand ve Dataset
        DataSet ds;

        static string bağ = "Data Source=DESKTOP-9UTNM4A\\SQLEXPRESS01 ; Initial Catalog=dbLogin;Integrated Security=SSPI";
        SqlConnection con = new SqlConnection(bağ);
        void griddoldur()
        {
            con = new SqlConnection("Data Source=DESKTOP-9UTNM4A\\SQLEXPRESS01 ; Initial Catalog=dbLogin;Integrated Security=SSPI");
            da = new SqlDataAdapter("Select *From ogrencikayıt", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "ogrencikayıt");
            dataGridView1.DataSource = ds.Tables["ogrencikayıt"];
            con.Close();
        }
        void verisil(int id)
        {
            con.Open();
            string sil = "Delete From ogrencikayıt where okul_no = @okul_no";
            SqlCommand cmd = new SqlCommand(sil, con);

            cmd.Parameters.AddWithValue("@okul_no", id);
            cmd.ExecuteNonQuery();
            con.Close() ;
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            frm2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {// kaydet or ekle
            try
            {

                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                    string kayıt = "insert into ogrencikayıt(okul_no,ogr_ad,ogr_soyad,ogr_sinif,ogr_alan,ogr_dogumyer,ogr_dgmtrh,ogr_adres,cep_tlf) values (@okul_no,@ogr_ad,@ogr_soyad,@ogr_sinif,@ogr_alan,@ogr_dogumyer,@ogr_dgmtrh,@ogr_adres,@cep_tlf) " +
                        "insert into ogr_not(okul_no,ogr_ad,ogr_soyad) values (@okul_no,@ogr_ad,@ogr_soyad)";
                    SqlCommand cmd = new SqlCommand(kayıt, con);

                    cmd.Parameters.AddWithValue("@okul_no", textBox1.Text);
                    cmd.Parameters.AddWithValue("@ogr_ad", textBox2.Text);
                    cmd.Parameters.AddWithValue("@ogr_soyad", textBox3.Text);
                    cmd.Parameters.AddWithValue("@ogr_sinif", textBox4.Text);
                    cmd.Parameters.AddWithValue("@ogr_alan", textBox5.Text);
                    cmd.Parameters.AddWithValue("@ogr_dogumyer", textBox6.Text);
                    cmd.Parameters.AddWithValue("@ogr_dgmtrh", maskedTextBox1.Text);
                    cmd.Parameters.AddWithValue("@ogr_adres", textBox8.Text);
                    cmd.Parameters.AddWithValue("@cep_tlf", maskedTextBox2.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kayıt Eklendi");
                    griddoldur();
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata oluştu"+hata.Message);
            }

        }
        int i=0; 
        private void button3_Click(object sender, EventArgs e)
        {// değştir
            con.Open();
            string güncelle = " Update ogrencikayıt set ogr_ad=@ogr_ad ,ogr_soyad= @ogr_soyad,ogr_sinif=@ogr_sinif,ogr_alan=@ogr_alan,ogr_dogumyer=@ogr_dogumyer,ogr_dgmtrh=@ogr_dgmtrh,ogr_adres=@ogr_adres,cep_tlf=@cep_tlf where okul_no=@okul_no";
            SqlCommand cmd = new SqlCommand(güncelle, con);

            cmd.Parameters.AddWithValue("@ogr_ad",textBox2.Text);
            cmd.Parameters.AddWithValue("@ogr_soyad", textBox3.Text);
            cmd.Parameters.AddWithValue("@ogr_sinif", textBox4.Text);
            cmd.Parameters.AddWithValue("@ogr_alan", textBox5.Text);
            cmd.Parameters.AddWithValue("@ogr_dogumyer", textBox6.Text);
            cmd.Parameters.AddWithValue("@ogr_dgmtrh", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@ogr_adres", textBox8.Text);
            cmd.Parameters.AddWithValue("@cep_tlf", maskedTextBox2.Text);
            cmd.Parameters.AddWithValue("@okul_no", dataGridView1.Rows[i].Cells[0].Value);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt değiştirildi");
            con.Close();
            griddoldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int id= Convert.ToInt32(drow.Cells[0].Value);
                verisil(id);
                MessageBox.Show("Kayıt silindi");
                griddoldur();
                

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            maskedTextBox2.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
        }
    }
}
