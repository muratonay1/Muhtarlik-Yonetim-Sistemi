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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=muhtarlik.mdb");
        public void verilerigoster() // VERİLERİ DATAGRİDVİEW DA GÖSTEREN (FONKSİYON)...
        {
            baglanti.Open();
            DataSet ds = new DataSet();
            DataTable tablo = new DataTable();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from fatura", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
            dataGridView1.Columns[0].Visible = false;
        }
        public void temizle()
        {
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
        }
        public void endeksleri_goster()
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select kw_gunduz,kw_puant,kw_gece,dagitim_birim,per_birim,psh_birim,psh_toplam,enerji_toplam,trt_toplam,elek_toplam,elek_kdv,bkm_bedel,cevre_vergi,su_kdv,su_birim from fatura_endeks ", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                textBox19.Text = dr["kw_gunduz"].ToString();
                textBox20.Text = dr["kw_puant"].ToString();
                textBox21.Text = dr["kw_gece"].ToString();
                textBox22.Text = dr["dagitim_birim"].ToString();
                textBox23.Text = dr["per_birim"].ToString();
                textBox24.Text = dr["psh_birim"].ToString();
                textBox25.Text = dr["psh_toplam"].ToString();
                textBox26.Text = dr["enerji_toplam"].ToString();
                textBox27.Text = dr["trt_toplam"].ToString();
                textBox28.Text = dr["elek_toplam"].ToString();
                textBox29.Text = dr["elek_kdv"].ToString();
                textBox16.Text = dr["bkm_bedel"].ToString();
                textBox17.Text = dr["cevre_vergi"].ToString();
                textBox18.Text = dr["su_kdv"].ToString();
                textBox6.Text = dr["su_birim"].ToString();
            }
            baglanti.Close();
        }
        private void Form7_Load(object sender, EventArgs e)// FATURA FORMU
        {
            verilerigoster();
            endeksleri_goster();
        }
        private void button1_Click(object sender, EventArgs e)// ELEKTRİK HESAPLA BUTONU
                {
                    if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                    {
                        float sayı1, sayı2, sayı3, a1, a2, a3;
                        sayı1 = Convert.ToSingle(textBox19.Text);
                        sayı2 = Convert.ToSingle(textBox20.Text);
                        sayı3 = Convert.ToSingle(textBox21.Text);
                        a1 = Convert.ToSingle(textBox22.Text);
                        a2 = Convert.ToSingle(textBox23.Text);
                        a3 = Convert.ToSingle(textBox24.Text);
                        label12.Text = textBox1.Text;
                        label13.Text = textBox2.Text;
                        label14.Text = textBox3.Text;
                        float toplam = Convert.ToSingle(textBox1.Text) + Convert.ToSingle(textBox2.Text) + Convert.ToSingle(textBox3.Text);
                        a1 = a1 * toplam;
                        a2 = a2 * toplam;
                        a3 = a3 * toplam;
                        sayı1 = sayı1 * Convert.ToSingle(textBox1.Text);
                        sayı2 = sayı2 * Convert.ToSingle(textBox2.Text);
                        sayı3 = sayı3 * Convert.ToSingle(textBox3.Text);
                        float toplam_sonuc = sayı1 + sayı2 + sayı3 + a1 + a2 + a3 + Convert.ToSingle(textBox25.Text) + Convert.ToSingle(textBox26.Text) + Convert.ToSingle(textBox27.Text) + Convert.ToSingle(textBox28.Text);
                        float kdv = (toplam_sonuc * Convert.ToSingle(textBox29.Text)) / 100;
                        float toplam_kdvli = toplam_sonuc + kdv;
                        label15.Text = sayı1.ToString();
                        label16.Text = sayı2.ToString();
                        label17.Text = sayı3.ToString();
                        label11.Text = toplam.ToString() + "Kw";
                        label30.Visible = true;
                        label31.Visible = true;
                        label33.Visible = true;
                        label30.Text = a1.ToString();
                        label31.Text = a2.ToString();
                        label33.Text = a3.ToString();
                        label40.Text = toplam_sonuc.ToString() + "TL";
                        label41.Text = kdv.ToString() + "TL";
                        label42.Text = toplam_kdvli.ToString() + "TL";
                    }
                    else
                    {
                        MessageBox.Show("Doldurulmayan Alanlar Mevcut!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
        private void button2_Click(object sender, EventArgs e)//TEMİZLE BUTONU
                {
                    label11.Text = "";
                    label12.Text = "";
                    label13.Text = "";
                    label14.Text = "";
                    label15.Text = "";
                    label16.Text = "";
                    label17.Text = "";
                    label30.Text = "";
                    label31.Text = "";
                    label33.Text = "";
                    label40.Text = "";
                    label41.Text = "";
                    label42.Text = "";
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                }
        private void button5_Click(object sender, EventArgs e)//SU HESAPLA BUTONU
                {
                    if(textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
                    {
                        float sayı1, sayı2, sayı3;
                        sayı1 = Convert.ToSingle(textBox7.Text) - Convert.ToInt32(textBox8.Text);
                        sayı2 = sayı1 * Convert.ToSingle(textBox6.Text);
                        float kdv = (sayı2 * Convert.ToInt32(textBox18.Text)) / 100;
                        float kdvli_fiyat = kdv + sayı2;
                        float toplam_fatura = kdvli_fiyat + Convert.ToSingle(textBox16.Text) + Convert.ToSingle(textBox17.Text);
                        label56.Text = sayı2.ToString() + "TL";
                        label59.Text = kdv.ToString() + "TL";
                        label60.Text = toplam_fatura.ToString() + "TL";
                    }
                    else
                    {
                        MessageBox.Show("DOLDURULMAYAN ALANLAR MEVCUT", "HATA", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
        private void button4_Click(object sender, EventArgs e)//ÖDEME BUTONU
                {
                    if(textBox4.Text != "" && textBox5.Text != "" && textBox9.Text != "")
                    {
                        DialogResult cevap;
                        cevap = MessageBox.Show(label42.Text + " ve " + label60.Text + " tutarlı 2 adet fatura ödemek üzeresiniz Onaylıyor musunuz? ", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (cevap == DialogResult.Yes)
                        {
                            baglanti.Open();
                            OleDbCommand komut = new OleDbCommand("insert into fatura(tcno,el_aboneno,el_odenen,el_odemetarihi,su_aboneno,su_odenen,su_odemetarihi) values('" + textBox5.Text + "', '" + textBox4.Text + "', '" + label42.Text + "', '" + dateTimePicker1.Value.ToString() + "', '" + textBox9.Text + "', '" +label60.Text + "', '" + dateTimePicker2.Value.ToString() + "')", baglanti);
                            komut.ExecuteNonQuery();
                            baglanti.Close();
                            MessageBox.Show("Ödeme Tamamlandı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             verilerigoster();
                        }
                        else
                        {
                            MessageBox.Show("Ödeme İptal Edildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Abone Numaraları veya Tc Kimlik Numarası Girilmemiş", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
        private void textBox10_TextChanged(object sender, EventArgs e)// DATAGRİD VERİ ARAMA
                {
                    baglanti.Open();
                    OleDbDataAdapter da = new OleDbDataAdapter("Select * from fatura where tcno like '%" + textBox10.Text + "%'", baglanti);
                    DataTable tablo = new DataTable();
                    da.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    baglanti.Close();
                }
        private void button6_Click(object sender, EventArgs e)// SU FATURASI TEMİZLE BUTONU
                {
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    label56.Text = "";
                    label59.Text = "";
                    label60.Text = "";
                }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)// DATAGRİDVİEW DEN TIKLAMA OLAYI
                {
                    int secilen = dataGridView1.SelectedCells[0].RowIndex;
                    textBox11.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();// su odenen
                    textBox12.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();//elektrik odenen
                    textBox13.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();//su odeme tarihi
                    textBox14.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();//elektrik odeme tarihi
                    textBox15.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();//tc no
                }
        private void button3_Click(object sender, EventArgs e)// SU FATURASI BUTONU
                {
                    if(textBox12.Text != "" && textBox13.Text != "" && textBox14.Text != "" && textBox15.Text != "")
                    {
                        printPreviewDialog1.Document = printDocument1;
                        printPreviewDialog1.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("İşleminizi Gerçekleştirilemiyor\n(KİŞİ BULUNAMADI)", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)//SU FATURASI YAZDIRMA
                {
                    int secilen = dataGridView1.SelectedCells[0].RowIndex;
                    e.Graphics.DrawString("Su Tahsilat Makbuzu", new Font("Times New Roman", 25, FontStyle.Underline), Brushes.Black, new Point(260, 120));
                    e.Graphics.DrawString("T.C.", new Font("Times New Roman", 25, FontStyle.Underline), Brushes.Black, new Point(380, 180));
                    e.Graphics.DrawString(label71.Text, new Font("Times New Roman", 25, FontStyle.Regular), Brushes.Black, new Point(0,230 ));
                    e.Graphics.DrawString("İşlem Tarihi: "+textBox13.Text, new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(120, 300));
                    e.Graphics.DrawString("Fatura         : "+"Su Faturası", new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(120, 350));
                    e.Graphics.DrawString("Kurum        :"+" Elazığ Su ve Kanalizasyon İdaresi", new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(120, 400));
                    e.Graphics.DrawString("Fatura No   :" + dataGridView1.Rows[secilen].Cells[4].Value.ToString(), new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(120, 450));
                    e.Graphics.DrawString("Abone Tc No :" + textBox15.Text, new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(120, 500));
                    e.Graphics.DrawString("Tutar          :" + textBox11.Text, new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(120, 550));
                    e.Graphics.DrawString("Muhtar :" + "...............................", new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(120, 750));
                    e.Graphics.DrawString("Kaşe :", new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(120, 830));
                }
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)// ELEKTRİK FATURASI YAZDIRMA
                {
                    int secilen = dataGridView1.SelectedCells[0].RowIndex;
                    e.Graphics.DrawString("Elektrik Tahsilat Makbuzu", new Font("Times New Roman", 25, FontStyle.Underline), Brushes.Black, new Point(260, 120));
                    e.Graphics.DrawString("T.C.", new Font("Times New Roman", 25, FontStyle.Underline), Brushes.Black, new Point(380, 180));
                    e.Graphics.DrawString(label71.Text, new Font("Times New Roman", 25, FontStyle.Regular), Brushes.Black, new Point(0, 230));
                    e.Graphics.DrawString("İşlem Tarihi: " + textBox14.Text, new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(120, 300));
                    e.Graphics.DrawString("Fatura         : " + "Elektrik Faturası", new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(120, 350));
                    e.Graphics.DrawString("Kurum        :" + " FIRAT ELEKTRİK. PERAKENDE SATIŞ A.Ş.", new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(120, 400));
                    e.Graphics.DrawString("Fatura No   :" + dataGridView1.Rows[secilen].Cells[2].Value.ToString(), new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(120, 450));
                    e.Graphics.DrawString("Abone Tc No :" + textBox15.Text, new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(120, 500));
                    e.Graphics.DrawString("Tutar          :" + textBox12.Text, new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(120, 550));
                    e.Graphics.DrawString("Muhtar :" + "...............................", new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(120, 750));
                    e.Graphics.DrawString("Kaşe :", new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(120, 830));
                }
        private void button7_Click(object sender, EventArgs e)// ELEKTRİK FATURASI BUTONU
                {
                    if (textBox12.Text != "" && textBox13.Text != "" && textBox14.Text != "" && textBox15.Text != "")
                    {
                        printPreviewDialog2.Document = printDocument2;
                        printPreviewDialog2.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("İşleminizi Gerçekleştirilemiyor\n(KİŞİ BULUNAMADI)", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar)==false && e.KeyChar!=(char) 08 && e.KeyChar!=(char) 46)
            {
                e.Handled = true;
            }
        }
        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox26_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox27_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox28_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox29_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("update fatura_endeks set kw_gunduz='" + textBox19.Text + "', kw_puant='" + textBox20.Text + "', kw_gece='" + textBox21.Text + "', dagitim_birim='" + textBox22.Text + "', per_birim='" + textBox23.Text + "', psh_birim='" + textBox24.Text + "', psh_toplam='" + textBox25.Text + "', enerji_toplam='" + textBox26.Text + "', trt_toplam='" + textBox27.Text + "', elek_toplam='" + textBox28.Text + "', elek_kdv='" + textBox29.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Güncelleme İşlemi Başarılı.");
            baglanti.Close();
            endeksleri_goster();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("update fatura_endeks set bkm_bedel='" + textBox16.Text + "', cevre_vergi='" + textBox17.Text + "', su_kdv='" + textBox18.Text + "', su_birim='" + textBox16.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Güncelleme İşlemi Başarılı.");
            baglanti.Close();
            endeksleri_goster();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show(textBox15.Text + " TC Kimlik Numaralı Kişiyi Silmek İstediğinize Emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(cevap==DialogResult.Yes)
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("Delete from fatura where tcno = '" + textBox15.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt Silindi.");
                temizle();
                baglanti.Close();
                verilerigoster();
            }
            else if(cevap==DialogResult.No)
            {
                //Birşey Yapma
            }
        }
    }
}
