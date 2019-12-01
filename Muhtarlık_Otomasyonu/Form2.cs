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

namespace Muhtarlık_Otomasyonu
{
    public partial class Form2 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=muhtarlik.mdb");
        OleDbCommand komut = new OleDbCommand();
        public Form2()
        {
            InitializeComponent();
            
        }
        public void verileri_guncelle()
        {
            baglanti.Open();
            komut = new OleDbCommand("Select admin_kullaniciadi,admin_sifre,admin_tc from admin_girisi", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textBox21.Text = dr["admin_kullaniciadi"].ToString();
                textBox22.Text = dr["admin_sifre"].ToString();
                textBox23.Text = dr["admin_tc"].ToString();

            }
            baglanti.Close();
        }
        private void Form2_Load_1(object sender, EventArgs e)// AÇIKLAYICI CÜMLECİKLER
        {
            ToolTip aciklama = new ToolTip();
            aciklama.SetToolTip(button4, "YENİ KİŞİ EKLEMEK İÇİN TIKLAYIN");
            aciklama.SetToolTip(button5, "KİŞİLERİ SORGULAMA/BELGELEME İÇİN TIKLAYIN");
            aciklama.SetToolTip(button6, "VEFAT İŞLEMLERİ İÇİN TIKLAYIN");
            aciklama.SetToolTip(button7, "FATURA İŞLEMLERİ İÇİN TIKLAYIN");
            verileri_guncelle();
            verilerigoster_misafir();


        }
        public void verilerigoster_misafir() // VERİLERİ DATAGRİDVİEW DA GÖSTEREN (FONKSİYON)...
        {
            baglanti.Open();
            DataSet ds = new DataSet();
            DataTable tablo = new DataTable();

            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from misafir_kayit", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
            dataGridView1.Columns[0].Visible = false;




        }
        private void timer1_Tick(object sender, EventArgs e)// TİMER
                {
                    DateTime dt = DateTime.Now;
                    label1.Text = dt.ToLongDateString();
                    label2.Text = dt.ToLongTimeString();
                }
        private void button4_Click(object sender, EventArgs e)// KİŞİ EKLEME BUTONU
                {
                    Form4 frm4 = new Form4();
                    frm4.ShowDialog();
                }
        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)//iptal olan buton(GEREKSİZ)
                {
                    
                }
        private void button5_Click(object sender, EventArgs e)// KİŞİ BUL BUTONU
                {
                    Form5 frm5 = new Form5();
                    frm5.ShowDialog();
                }
        private void button6_Click(object sender, EventArgs e)// VEFAT İŞLEMLERİ
                {
                    Form6 frm6 = new Form6();
                    frm6.ShowDialog();
            

                }
        private void button7_Click(object sender, EventArgs e)// FATURA İŞLEMLERİ
                {
                    Form7 frm7 = new Form7();
                    frm7.ShowDialog();

                }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)// FORM2 CLOSİNG OLAYI
                {
                    Application.Exit();
                }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            verilerigoster_misafir();
            verileri_guncelle();
            groupBox4.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            verileri_guncelle();
            groupBox4.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)//Değişiklikleri kaydet butonu
        {
            baglanti.Open();
            if(textBox23.Text == "")
            {
               
                komut = new OleDbCommand("update admin_girisi set admin_kullaniciadi='" + textBox21.Text + "', admin_sifre='" + textBox22.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Değişiklikler Kayıt Edildi.");
                baglanti.Close();
            }
            else if(textBox23.Text != "")
            {
                komut = new OleDbCommand("update admin_girisi set admin_kullaniciadi='" + textBox21.Text + "', admin_sifre='" + textBox22.Text + "', admin_tc='"+textBox23.Text+"'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Değişiklikler Kayıt Edildi.");
                baglanti.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox26.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox25.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox24.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox27.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox28.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult ds;
            ds = MessageBox.Show(textBox26.Text + " Kullanıcısını Silmek Üzeresiniz.","Misafir Yönetimi",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            if(ds==DialogResult.OK)
            {
                baglanti.Open();
                komut = new OleDbCommand("Delete from misafir_kayit where misafir_ad = '" + textBox26.Text + "' and misafir_telefon='" + textBox27.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Misafir Silindi.");
                baglanti.Close();
                verilerigoster_misafir();
                textBox26.Clear();
                textBox25.Clear();
                textBox24.Clear();
                textBox27.Clear();

            }
            else { }
           
        }
    }
}
