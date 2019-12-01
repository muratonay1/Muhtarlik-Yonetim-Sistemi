using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace Muhtarlık_Otomasyonu
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=muhtarlik.mdb"); // BAGLANTI SAGLAMA
        OleDbCommand komut = new OleDbCommand();
       
        private void Form3_Load(object sender, EventArgs e)// AÇIKLAMA TOOLTİPLER
        {
            label6.Visible = false;
            ToolTip aciklama = new ToolTip();
            aciklama.SetToolTip(button1, "KAYIT OLMAK İÇİN TIKLAYIN");
            aciklama.SetToolTip(button2, "ÇIKIŞ YAPMAK İÇİN TIKLAYIN");

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {

            Form8 frm8 = new Form8();
            frm8.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)// MİSAFİR GİRİŞİ KAYIT BUTONU
        {
            DateTime dt = DateTime.Now;
            try
            {

                baglanti.Open();
                komut = new OleDbCommand("insert into misafir_kayit(misafir_ad,misafir_sifre,misafir_email,misafir_telefon,misafir_ktar) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "', '"+dt.ToLongDateString()+" / "+dt.ToLongTimeString()+"')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                label6.Visible = true;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata + "meydana geldi");
            }

        }
    }
}
