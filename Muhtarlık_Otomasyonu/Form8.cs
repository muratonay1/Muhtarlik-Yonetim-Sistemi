using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Muhtarlık_Otomasyonu
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=muhtarlik.mdb"); // BAGLANTI SAGLAMA
        OleDbCommand komut = new OleDbCommand();
        Random rnd = new Random();
        public int bot_kontrol;
        private void button12_Click(object sender, EventArgs e) // MİSAFİR GİRİŞ YAP BUTONU
        {

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from misafir_kayit where misafir_ad='" + textBox1.Text + "' and misafir_sifre='" + textBox2.Text + "'", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            if (dr.Read() && textBox3.Text == label1.Text)
            {
                baglanti.Close();
                MessageBox.Show("Doğrulama Sağlandı", "MESAJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label4.Visible = false; // 2. TAB SAYFASI LABELLERİN GÖRÜNÜRLÜĞÜ
                label5.Visible = true;

                pictureBox1.Visible = true;
                button14.Visible = true;
                label8.Visible = true;

            }
            else
            {
                MessageBox.Show("HATA İLE KARŞILAŞILDI", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();

            }
 
        }
        private void Form8_Load(object sender, EventArgs e)// FORM8 LOAD RANDOM BOT KONTROL
                {
                    bot_kontrol= rnd.Next(10000, 99999);
                    label1.Text = bot_kontrol.ToString();

                }
        private void button1_Click(object sender, EventArgs e) // 1 TUŞU
                {
                    textBox3.Text = textBox3.Text + 1.ToString();

                }
        private void button2_Click(object sender, EventArgs e)// 2 TUŞU
                {
                    textBox3.Text = textBox3.Text + 2.ToString();
                }
        private void button3_Click(object sender, EventArgs e)// 3 TUŞU
                {
                    textBox3.Text = textBox3.Text + 3.ToString();
                }
        private void button4_Click(object sender, EventArgs e)// 4 TUŞU
                {
                    textBox3.Text = textBox3.Text + 4.ToString();
                }
        private void button5_Click(object sender, EventArgs e)// 5 TUŞU
                {
                    textBox3.Text = textBox3.Text + 5.ToString();
                }
        private void button6_Click(object sender, EventArgs e)// 6 TUŞU
                {
                    textBox3.Text = textBox3.Text + 6.ToString();
                }
        private void button7_Click(object sender, EventArgs e)// 7 TUŞU
                {
                    textBox3.Text = textBox3.Text + 7.ToString();
                }
        private void button8_Click(object sender, EventArgs e)// 8 TUŞU
                {
                    textBox3.Text = textBox3.Text + 8.ToString();
                }
        private void button9_Click(object sender, EventArgs e)// 9 TUŞU
                {
                    textBox3.Text = textBox3.Text + 9.ToString();
                }
        private void button10_Click(object sender, EventArgs e)// 0 TUŞU
                {
                    textBox3.Text = textBox3.Text + 0.ToString();
                }
        private void button13_Click(object sender, EventArgs e)// KOD TEMİZLEME BUTONU
                {
                    textBox3.Clear();
                }
        private void button11_Click(object sender, EventArgs e)// BOT KONTROLÜ DOĞRULAMA BUTONU
                {
                    if(bot_kontrol.ToString() == textBox3.Text)
                    {
                        MessageBox.Show("BOT KONTROL SAĞLANDI", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("DOĞRULAMA KODLARI UYUŞMADI!", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
        private void button14_Click(object sender, EventArgs e)// MİSAFİR GİRİŞİ YAPILTAN SONRAKİ 2. TAB(EXİT BUTONU) İŞLEVİ
                {
                    label4.Visible = true; // 2. TAB SAYFASI LABELLERİN GÖRÜNÜRLÜĞÜ
                    label5.Visible = false;
                  
                    pictureBox1.Visible = false;
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    button14.Visible = false;
                    label8.Visible = false;

                    bot_kontrol = rnd.Next(10000, 99999);
                    label1.Text = bot_kontrol.ToString();
                }
    }
}
