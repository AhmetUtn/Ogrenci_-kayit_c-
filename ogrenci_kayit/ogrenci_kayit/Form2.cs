using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21300031063_Ahmet_Utan
{
    public partial class Form2 : Form
    {
        public Form1 frm1;
        Form3 frm3 = new Form3();
        Form4 frm4 = new Form4();
        Form5 frm5= new Form5();
        public Form2()
        {
            InitializeComponent();
            frm3 = new Form3();
            frm3.frm2 = this;

            frm4 = new Form4();
            frm4.frm2 = this;

            frm5= new Form5();
            frm5.frm2= this;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {// öğrenci kayıt butonu
            frm3.Show();
            this.Hide();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void button6_Click(object sender, EventArgs e)
        {   // öğrenci sorgulama

            frm4.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm5.Show();
            this.Hide();
        }
    }
}
