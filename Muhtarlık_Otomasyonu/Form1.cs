using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;                            //Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\murat\Desktop\Otomasyon_Database.mdb
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Muhtarlık_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int bot_kontrol;
        Random rnd = new Random();
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=muhtarlik.mdb");
        private void Form1_Load(object sender, EventArgs e)//FORM1 LOAD BOT KONTROL VE TOOLTİPLER
        {
            textBox4.Text = "";
            textBox1.Text = Properties.Settings.Default.K_adi;
            textBox2.Text = Properties.Settings.Default.Sifre;
            textBox3.Text = "Kodu Girin...";
            bot_kontrol = rnd.Next(10000, 95000);
            label4.Text = bot_kontrol.ToString();
            ToolTip aciklama = new ToolTip();
            aciklama.SetToolTip(button1, "GİRİŞ YAPMAK İÇİN TIKLAYIN");
            aciklama.SetToolTip(button2, "ÇIKIŞ YAPMAK İÇİN TIKLAYIN");
            aciklama.SetToolTip(button3, "ONAY KODUNU YENİLEMEK İÇİN TIKLAYIN");
            aciklama.SetToolTip(button4, "YENİ KAYIT EKLEMEK İÇİN TIKLAYIN");
            aciklama.SetToolTip(button15, "EKRAN KLAVYESİNİ AÇAR");
            aciklama.SetToolTip(button16, "EKRAN KLAVYESİNİ KAPATIR");
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }
        private void textBox3_Leave(object sender, EventArgs e)//GEREKSİZ BLOK
        {
        }
        private void button3_Click_1(object sender, EventArgs e)// KOD YENİLE BUTONU
        {
            textBox3.Text = "";
            bot_kontrol = rnd.Next(10000, 95000);
            label4.Text = bot_kontrol.ToString();
        }
        private void button1_Click(object sender, EventArgs e)//ADMIN GİRİŞİ BÖLÜMÜ...
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select * from admin_girisi where admin_kullaniciadi='" + textBox1.Text + "' and admin_sifre='" + textBox2.Text + "'",baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            if(dr.Read() && textBox3.Text == label4.Text)
            {
                baglanti.Close();
                MessageBox.Show("Doğrulama Sağlandı", "MESAJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form2 frm2 = new Form2();
                this.Hide();
                frm2.ShowDialog();
            }
            else
            {
                MessageBox.Show("HATA İLE KARŞILAŞILDI");
                baglanti.Close();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                Properties.Settings.Default.K_adi = textBox1.Text;
                Properties.Settings.Default.Sifre = textBox2.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.K_adi = null;
                Properties.Settings.Default.Sifre = null;
                Properties.Settings.Default.Save();
            }
        }
        private void button4_Click(object sender, EventArgs e)  //YENI KAYIT PENCERESİ BUTONU
        {
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)  //X BUTONU
        {
            Application.Exit();
        }
        private void button13_Click(object sender, EventArgs e) //9 SAYISI
        {
            textBox3.Text = textBox3.Text + 9.ToString();
        }
        private void button5_Click(object sender, EventArgs e)  //1 SAYISI
                {
                    textBox3.Text = textBox3.Text + 1.ToString();
                }
        private void button6_Click(object sender, EventArgs e)  //2 SAYISI
                {
                    textBox3.Text = textBox3.Text + 2.ToString();
                }
        private void button7_Click(object sender, EventArgs e)  //3 SAYISI
                {
                    textBox3.Text = textBox3.Text + 3.ToString();
                }
        private void button8_Click(object sender, EventArgs e)  //4 SAYISI
        {
                    textBox3.Text = textBox3.Text + 4.ToString();
                }
        private void button9_Click(object sender, EventArgs e)  //5 SAYISI
        {
                    textBox3.Text = textBox3.Text + 5.ToString();
                }
        private void button10_Click(object sender, EventArgs e) //6 SAYISI
        {
                    textBox3.Text = textBox3.Text + 6.ToString();
                }
        private void button11_Click(object sender, EventArgs e) //7 SAYISI
        {
                    textBox3.Text = textBox3.Text + 7.ToString();
                }
        private void button12_Click(object sender, EventArgs e) //8 SAYISI
        {
                    textBox3.Text = textBox3.Text + 8.ToString();
                }
        private void button14_Click(object sender, EventArgs e) //0 SAYISI
        {
                    textBox3.Text = textBox3.Text + 0.ToString();
                }
        private void button15_Click(object sender, EventArgs e) //EKRAN KLAVYESİ GÖSTERME BUTONU
                {
                    groupBox1.Visible = true;
                    textBox3.Enabled = false;
                }
        private void button16_Click(object sender, EventArgs e) //EKRAN KLAVYESİ GİZLEME BUTONU
                {
                    groupBox1.Visible = false;
                    textBox3.Enabled = true;
                }
        private void button17_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }
        private void label7_Click(object sender, EventArgs e)
        {
            if(groupBox2.Visible==false)
            {
                groupBox2.Visible = true;
            }
            else
            {
                groupBox2.Visible = false;
            }
        }
        private void button18_Click(object sender, EventArgs e)//admin şifre sıfırla butonu
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select admin_tc from admin_girisi", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                if (textBox4.Text == dr["admin_tc"].ToString())
                {
                    label11.Visible = false;
                    MessageBox.Show("Ayarlardan şifrenizi değiştirmeyi unutmayın.");
                    Form2 frm2 = new Form2();
                    this.Hide();
                    frm2.ShowDialog();
                }
                else if (textBox4.Text != dr["admin_tc"].ToString())
                {
                    MessageBox.Show("Böyle bir TC Kimlik numarası bulunamadı.");
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Bu Alan Boş Bırakılamaz");
                }
            }
            baglanti.Close();
        }
    }
}
