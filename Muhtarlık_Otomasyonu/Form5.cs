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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=muhtarlik.mdb");
        OleDbCommand komut = new OleDbCommand();
        public string cinsiyet(string kelime)// GELEN KİŞİNİN CİNSİYETİ BELİRLEYEN FONKSİYON
        {
            string cinsiyeti; // EĞER EVLENMEDEN ÖNCEKİ SOYADI BOŞ İSE 'ERKEK' DOLU İSE 'KADIN' CİNSİYETİNİ VERİR.
            if (kelime == "")
            {
                cinsiyeti = "Erkek";
            }
            else
            {
                cinsiyeti = "Kadın";
            }
            return cinsiyeti;
        }

        public void verilerigoster() // VERİLERİ DATAGRİDVİEW DA GÖSTEREN (FONKSİYON)...
        {
            baglanti.Open();
            DataSet ds = new DataSet();
            DataTable tablo = new DataTable();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from kisibilgiler", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
            dataGridView1.Columns[0].Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)// GEREKSİZ
        {
        }

        private void Form5_Load(object sender, EventArgs e)// FORM5 YÜKLEME OLAYI
        {
            ToolTip aciklama = new ToolTip();
            aciklama.SetToolTip(button1, "Değişiklikleri Kaydetmek İçin Tıklayın");
            aciklama.SetToolTip(button2, "TC KİMLİK NUMARASI GİRİLEN KİŞİYİ SİLMEK İÇİN TIKLAYIN");
            aciklama.SetToolTip(button4, "RESİM EKLEME/ÇIKARMA İÇİN TIKLAYIN");
            aciklama.SetToolTip(textBox36, "Silinecek Kişinin TC KİMLİK Numarasını Girin.(ZORUNLU)");
            verilerigoster();  // FORM5 AÇILDIĞI AN DATAGRİDVİEW VERİ İLE DOLDURULUR...
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)// DATAGRİDVİEW TIKLAMA OLAYI
        {
            // DATAGRİDVİEW DA TIKLANILAN HERHANGİ BİR YERİ ALT TARAFTAKİ TEXTBOXLARA DOLDURAN BÖLÜM...
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            textBox10.Text = dataGridView1.Rows[secilen].Cells[9].Value.ToString();
            textBox11.Text = dataGridView1.Rows[secilen].Cells[10].Value.ToString();
            textBox12.Text = dataGridView1.Rows[secilen].Cells[11].Value.ToString();
            textBox13.Text = dataGridView1.Rows[secilen].Cells[12].Value.ToString();
            textBox14.Text = dataGridView1.Rows[secilen].Cells[13].Value.ToString();
            textBox15.Text = dataGridView1.Rows[secilen].Cells[14].Value.ToString();
            textBox16.Text = dataGridView1.Rows[secilen].Cells[15].Value.ToString();
            textBox17.Text = dataGridView1.Rows[secilen].Cells[16].Value.ToString();
            textBox18.Text = dataGridView1.Rows[secilen].Cells[17].Value.ToString();
            textBox19.Text = dataGridView1.Rows[secilen].Cells[18].Value.ToString();
            textBox20.Text = dataGridView1.Rows[secilen].Cells[19].Value.ToString();
            textBox33.Text = dataGridView1.Rows[secilen].Cells[20].Value.ToString();
            textBox34.Text = dataGridView1.Rows[secilen].Cells[21].Value.ToString();
            textBox21.Text = dataGridView1.Rows[secilen].Cells[22].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[secilen].Cells[23].Value.ToString();
            textBox22.Text = dataGridView1.Rows[secilen].Cells[24].Value.ToString();
            textBox23.Text = dataGridView1.Rows[secilen].Cells[25].Value.ToString();
            textBox24.Text = dataGridView1.Rows[secilen].Cells[26].Value.ToString();
            textBox25.Text = dataGridView1.Rows[secilen].Cells[27].Value.ToString();
            //dateTimePicker1.Text = dataGridView1.Rows[secilen].Cells[28].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[secilen].Cells[29].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[secilen].Cells[30].Value.ToString();
            comboBox5.Text = dataGridView1.Rows[secilen].Cells[31].Value.ToString();
            comboBox6.Text = dataGridView1.Rows[secilen].Cells[32].Value.ToString();
            textBox26.Text = dataGridView1.Rows[secilen].Cells[33].Value.ToString();
            textBox28.Text = dataGridView1.Rows[secilen].Cells[34].Value.ToString();
            textBox27.Text = dataGridView1.Rows[secilen].Cells[35].Value.ToString();
            comboBox7.Text = dataGridView1.Rows[secilen].Cells[36].Value.ToString();
            textBox29.Text = dataGridView1.Rows[secilen].Cells[37].Value.ToString();
            textBox30.Text = dataGridView1.Rows[secilen].Cells[38].Value.ToString();
            comboBox8.Text = dataGridView1.Rows[secilen].Cells[39].Value.ToString();
            comboBox9.Text = dataGridView1.Rows[secilen].Cells[40].Value.ToString();
            comboBox10.Text = dataGridView1.Rows[secilen].Cells[41].Value.ToString();
            textBox31.Text = dataGridView1.Rows[secilen].Cells[42].Value.ToString();
            textBox32.Text = dataGridView1.Rows[secilen].Cells[43].Value.ToString();
            textBox35.Text = dataGridView1.Rows[secilen].Cells[44].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.Rows[secilen].Cells[44].Value.ToString(); // PİCTUREBOX AKTARIM BÖLÜMÜ
            label2.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e) // RESİM YENİLEME VEYA EKLEME OLAYI 
        {
            DialogResult basılan; // DIALOGRESULTUN GERCEKLESTIRECEGI ISLEMLER...
            basılan = MessageBox.Show("Resmi değişmek istediğinize emin misiniz?", "STOP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pictureBox1.Image == null)
            {
                openFileDialog1.ShowDialog();
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                textBox35.Text = openFileDialog1.FileName;
                label26.Text = "Resim ekle";
            }

            if (basılan == DialogResult.Yes)
            {
                openFileDialog1.ShowDialog();
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                textBox35.Text = openFileDialog1.FileName;
            }
            else { }
        }

        private void button1_Click(object sender, EventArgs e)// KAYDETME(GÜNCELLEME) BUTONU
        {
            baglanti.Open();
            komut = new OleDbCommand("update kisibilgiler set " +
                "SOYADI = '" + textBox3.Text.ToString() + "', " +
                "ADI= '" + textBox4.Text + "', " +
                "BABA_ADI= '" + textBox5.Text + "', " +
                "ANA_ADI= '" + textBox6.Text + "', " +
                "DOGUM_YERI= '" + textBox7.Text + "', " +
                "DOGUM_TARIHI= '" + textBox8.Text + "'," +
                " MEDENI_HALI= '" + textBox9.Text + "', " +
                "DINI= '" + textBox10.Text + "', " +
                "KAN_GRUBU= '" + textBox11.Text + "', " +
                "ILI= '" + textBox12.Text + "', " +
                "ILCESI= '" + textBox13.Text + "'," +
                "MAHALLE_KOY='" + textBox14.Text + "', " +
                "CILT_NO='" + textBox15.Text + "', " +
                "AILESIRA_NO='" + textBox16.Text + "', " +
                "SIRA_NO='" + textBox17.Text + "', " +
                "VERILDIGI_YER='" + textBox18.Text + "', " +
                "VERILIS_NEDENI='" + textBox19.Text + "', " +
                "KAYIT_NO='" + textBox20.Text + "', " +
                "VERILIS_TARIHI = '" + textBox33.Text + "', " +
                "ONCEKI_SOYADI='" + textBox34.Text + "', " +
                "MESLEGI='" + textBox21.Text + "', " +
                "OGRENIM_DURUMU='" + comboBox2.Text + "', " +
                "ASKKAYIT_NO='" + textBox22.Text + "', " +
                "CEP_TEL='" + textBox23.Text + "', " +
                "VERGI_NO='" + textBox24.Text + "', " +
                "VERGI_DAIRESI='" + textBox25.Text + "', " +
                "KAYIT_TARIHI='" + dateTimePicker1.Value.ToString() + "', " +
                "SEMT_MAH='" + comboBox3.Text + "', " +
                "CADDE='" + comboBox4.Text + "', " +
                "SOKAK='" + comboBox5.Text + "', " +
                "SITE='" + comboBox6.Text + "', " +
                "APT_ADI='" + textBox26.Text + "', " +
                "BINA_NO='" + textBox28.Text + "', " +
                "DAIRE_NO='" + textBox27.Text + "', " +
                "IL='" + comboBox7.Text + "', " +
                "ILCE='" + textBox29.Text + "', " +
                "BUCAK_KOY='" + textBox30.Text + "', " +
                "OTURDUGU_EV='" + comboBox8.Text + "', " +
                "FAKIRLIK_DERECE='" + comboBox9.Text + "', " +
                "KONUT_TURU='" + comboBox10.Text + "', " +
                "ODA_SAYISI='" + textBox31.Text + "', " +
                "M2='" + textBox32.Text + "', " +
                "RESIM_ADRESI='" + textBox35.Text + "' where TC_NO='" + textBox2.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigoster();
        }

        private void button2_Click(object sender, EventArgs e)//KİŞİ SİLME BUTONU..
        {
            if (textBox36.Text == "")
            {
                MessageBox.Show("Kişi silmek için lütfen TC Kimlik numarasını belirtilen alana yazıp işleminizi tekrar gerçekleştirin.", "Kişi Silme Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult cevap;
                cevap = MessageBox.Show(textBox36.Text + " TC Kimlik Numaralı Kişiyi Silmek İstediğinize Emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (cevap == DialogResult.Yes)
                {
                    baglanti.Open();
                    komut = new OleDbCommand("Delete from kisibilgiler where TC_NO = '" + textBox2.Text + "'", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    verilerigoster();
                }
                else { }
            }
        }

        private void button5_Click(object sender, EventArgs e) // YAZDIRMA İŞLEMLERİ BUTONU 2 satırlık TANIMLAMA BÖLÜMÜ
        {
            if (radioButton4.Checked && textBox37.Text != "" && textBox2.Text != "")// İKAMETGAH İLMUHABERİ KONTROLÜ (RADİOBUTTON4)
            {
                printPreviewDialog1.Document = printDocument1;//İKAMETGAH   'textBox2.Text' üzerinde 'TC KİMLİK NO' bulunduğu için boş geçilemeyeceğini kontrol ettik
                printPreviewDialog1.ShowDialog();
            }
            else if (radioButton5.Checked && textBox2.Text != "")//FAKİRLİK BELGESİ
            {
                printPreviewDialog2.Document = printDocument2;
                printPreviewDialog2.ShowDialog();
            }
            else if (radioButton6.Checked && textBox2.Text != "")// NÜFUS CÜZDAN ÖRNEĞİ
            {
                printPreviewDialog3.Document = printDocument3;
                printPreviewDialog3.ShowDialog();
            }
            else if (radioButton7.Checked && textBox2.Text != "" && textBox38.Text != "")// ÖLÜM BELGESİ
            {
                DialogResult cevap;
                cevap = MessageBox.Show("Ölüm belgesi yazılacak kişi aynı zamanda silinecektir onaylıyor musunuz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    baglanti.Open();
                    komut = new OleDbCommand("insert into kisiolum(tc,ad,soyad,dogum_tarihi,olum_tarihi,fotograf) " +
                        "values(" +
                        "'" + textBox2.Text + "'," +
                        "'" + textBox4.Text + "', " +
                        "'" + textBox3.Text + "'," +
                        "'" + textBox8.Text + "', " +
                        "'" + textBox38.Text + "', " +
                        "'" + textBox35.Text + "') ", baglanti);
                    komut.ExecuteNonQuery();
                    komut = new OleDbCommand("Delete from kisibilgiler where TC_NO = '" + textBox2.Text + "'", baglanti);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    verilerigoster();
                    printPreviewDialog4.Document = printDocument4;
                    printPreviewDialog4.ShowDialog();
                }
                else { }
            }
            else
            {
                MessageBox.Show("Birşeyler Yolunda Gitmedi.", "BELGE YAZDIRMA SORUNU", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)// İKAMETGAH BELGESİ
        {
            e.Graphics.DrawImage(pictureBox3.Image, new Point(10, 10));
            e.Graphics.DrawString("İKAMETGAH İLMUHABERİ", new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(230, 100));
            e.Graphics.DrawString("T.C.", new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(380, 140));
            e.Graphics.DrawString(label28.Text, new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(0, 180));
            if (pictureBox1.Image == null) // FOTOĞRAŞ BOŞ OLURSA HATA VERMEMESİNİ SAĞLAR
            {

            }
            else
            {
                e.Graphics.DrawImage(pictureBox1.Image, new Point(650, 230));
            }
            e.Graphics.DrawString("İli            :" + comboBox7.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 220));
            e.Graphics.DrawString("İlçesi      :" + textBox29.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 260));
            e.Graphics.DrawString("Mahalle   :" + comboBox3.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 300));
            e.Graphics.DrawString("Vatandaşlık No:" + textBox2.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 340));
            e.Graphics.DrawString("Adı Soyadı   :" + textBox4.Text + "  " + textBox3.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 380));
            e.Graphics.DrawString("Baba Adı   :" + textBox5.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 420));
            e.Graphics.DrawString("Ana Adı   :" + textBox6.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 460));
            e.Graphics.DrawString("Doğum Yeri ve Tarihi   :" + textBox7.Text + "   " + textBox8.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 500));
            e.Graphics.DrawString("Medeni Hali   :" + textBox9.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 540));
            e.Graphics.DrawString("Ne İçin Verildiği   :" + textBox37.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 580));
            e.Graphics.DrawString("İkametgah Adresi   :\n\n-" + comboBox3.Text + "" +
                "\n-" + comboBox4.Text + "" +
                "\n-" + comboBox5.Text + "" +
                "\n-" + comboBox6.Text + "" +
                "\n-" + textBox26.Text + "" +
                "\n-" + textBox28.Text + "/" + textBox27.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 620));
            e.Graphics.DrawString("    " +
                "Hüviyetimin ve İkametgahımın hakkımda düzenlenen " +
                "bu belgedeki\nbilgilerin doğru olduğunu ve tarafıma " +
                "yapılacak herhangi bir yasal\ntebligatı kabul edeceğimi " +
                "bildiren ikametgah ilmuhaberidir.", new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 840));
            e.Graphics.DrawString("İMZA", new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(540, 950));
            e.Graphics.DrawString("Yukarıda Fotoğraflı/Fotoğrafsız olarak tanzim edilen ve tasdik edilen", new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 1000));
            e.Graphics.DrawString("MUHTAR", new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(540, 1050));
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)// FAKİRLİK BELGESİ
        {
            e.Graphics.DrawImage(pictureBox3.Image, new Point(10, 10));
            e.Graphics.DrawString("FAKİRLİK BELGESİ", new Font("Times New Roman", 20, FontStyle.Underline), Brushes.Black, new Point(275, 100));
            e.Graphics.DrawString("T.C.", new Font("Times New Roman", 20, FontStyle.Underline), Brushes.Black, new Point(380, 140));
            e.Graphics.DrawString(label28.Text, new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(0, 180));
            if (pictureBox1.Image == null) // FOTOĞRAF BOŞ OLURSA HATA VERMEMESİNİ SAĞLAR
            {

            }
            else
            {
                e.Graphics.DrawImage(pictureBox1.Image, new Point(650, 230));
            }
            e.Graphics.DrawString("Nüfus Cüzdan Cilt-No            :" + textBox15.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 220));
            e.Graphics.DrawString("Baba Adı      :" + textBox5.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 260));
            e.Graphics.DrawString("Ana Adı   :" + textBox6.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 300));
            e.Graphics.DrawString("Vatandaşlık No:" + textBox2.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 340));
            e.Graphics.DrawString("Doğum Yeri ve Tarihi   :" + textBox7.Text + " / " + textBox8.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 380));
            e.Graphics.DrawString("Medeni Hali   :" + textBox9.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 420));
            e.Graphics.DrawString("Nüfusa Kayıtlı Olduğu   :", new Font("Times New Roman", 15, FontStyle.Underline), Brushes.Black, new Point(100, 460));
            e.Graphics.DrawString("İl   :" + textBox12.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 500));
            e.Graphics.DrawString("İlçe   :" + textBox13.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 540));
            e.Graphics.DrawString("Mahalle Köy   :" + textBox14.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 580));
            e.Graphics.DrawString("Aile Sıra-No   :" + textBox16.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 620));
            e.Graphics.DrawString("Oturduğu Adres   :\n-" + comboBox3.Text + "" +
                "\n-" + comboBox4.Text + "" +
                "\n-" + comboBox5.Text + "" +
                "\n-" + comboBox6.Text + "" +
                "\n-" + textBox26.Text + "-" + textBox28.Text + "/" + textBox27.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 680));
            e.Graphics.DrawString("    Mahallemiz sakinlerinden yukarıda bahsi geçen kişinin, " +
                "\nbağlı maaşı bulunmadığını,ancak.................... suretle geçindiğini, " +
                "\naynı zamanda fakir veyardıma muhtaç olduğunu bildirmek üzere," +
                "\n işbu belge isteği üzerine kendisine verilmiştir.", new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 900));
            e.Graphics.DrawString(".../.../20...", new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(540, 1000));
            e.Graphics.DrawString("................... Muhtarı\n.........................................", new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(520, 1050));
        }

        private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)//Nüfus Cüzdanı Sureti
        {
            e.Graphics.DrawImage(pictureBox3.Image, new Point(10, 10));
            e.Graphics.DrawString("NÜFUS CÜZDANI SURETİ", new Font("Times New Roman", 20, FontStyle.Underline), Brushes.Black, new Point(250, 100));
            e.Graphics.DrawString("T.C.", new Font("Times New Roman", 20, FontStyle.Underline), Brushes.Black, new Point(380, 140));
            e.Graphics.DrawString(label28.Text, new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(0, 180));
            if (pictureBox1.Image == null)// EĞER PİCTUREBOX BOŞ OLURSA RESMİ KOYMAMAYI SAĞLIYOR...
            {
            }
            else
            {
                e.Graphics.DrawImage(pictureBox1.Image, new Point(650, 230));
            }
            e.Graphics.DrawString("TC Kimlik-No:" + textBox2.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 220));
            e.Graphics.DrawString("Soyadı:" + textBox3.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 260));
            e.Graphics.DrawString("Adı:" + textBox4.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 300));
            e.Graphics.DrawString("Baba Adı:" + textBox5.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 340));
            e.Graphics.DrawString("Ana Adı:" + textBox6.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 380));
            e.Graphics.DrawString("Doğum Yeri:" + textBox7.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 420));
            e.Graphics.DrawString("Doğum Tarihi:" + textBox8.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 460));
            e.Graphics.DrawString("Medeni Hali:" + textBox9.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 500));
            e.Graphics.DrawString("İl:" + textBox12.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 540));
            e.Graphics.DrawString("İlçe:" + textBox13.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 580));
            e.Graphics.DrawString("Mahalle Köy:" + textBox14.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 620));
            e.Graphics.DrawString("Veriliş Yeri:" + textBox18.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 660));
            e.Graphics.DrawString("Veriliş Nedeni:" + textBox19.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 700));
            e.Graphics.DrawString("Veriliş Tarihi" + textBox33.Text, new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 740));
            e.Graphics.DrawString("ONAYLAYANIN", new Font("Times New Roman", 19, FontStyle.Underline), Brushes.Black, new Point(100, 850));
            e.Graphics.DrawString("Adı,Soyadı,Ünvanı:", new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 880));
            e.Graphics.DrawString("Tarih:", new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 910));
            e.Graphics.DrawString("İMZA:", new Font("Times New Roman", 15, FontStyle.Regular), Brushes.Black, new Point(100, 950));
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)//İKAMETGAH VERİLECEĞİ ZAMAN VERİLİŞ NEDENINI KONTROL EDEN KOŞULLAR
        {
            if (radioButton4.Checked)
            {
                textBox37.Visible = true;
                label29.Visible = true;
                label30.Visible = true;
            }
            else
            {
                textBox37.Visible = false;
                label29.Visible = false;
                label30.Visible = false;
            }
        }

        private void printDocument4_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)// ÖLÜM BELGESİ
        {
            e.Graphics.DrawImage(pictureBox3.Image, new Point(10, 10));
            if (pictureBox1.Image == null)
            {

            }
            else
            {
                e.Graphics.DrawImage(pictureBox1.Image, new Point(660, 10));

            }
            e.Graphics.DrawString("ÖLÜM BELGESİ", new Font("Times New Roman", 14, FontStyle.Underline), Brushes.Black, new Point(330, 100));
            e.Graphics.DrawString("T.C.", new Font("Times New Roman", 14, FontStyle.Underline), Brushes.Black, new Point(385, 140));
            e.Graphics.DrawString(label28.Text, new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new Point(0, 180));
            e.Graphics.DrawString("-İli:............................. ", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(25, 210));
            e.Graphics.DrawString("-İlçesi:........................ ", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(25, 230));
            e.Graphics.DrawString("-Belde Yada Köy.............................. ", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(550, 210));
            e.Graphics.DrawString("-Kurum Adı....................................... ", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(550, 230));
            e.Graphics.DrawString(label28.Text, new Font("Times New Roman", 20, FontStyle.Regular), Brushes.Black, new Point(0, 250));
            e.Graphics.DrawString("(A)Ölen Kişinin Bilgileri", new Font("Times New Roman", 14, FontStyle.Underline), Brushes.Black, new Point(25, 290));// ÖLEN KİŞİ BİLGİLERİ
            e.Graphics.DrawString("-Kimlik Numarası:  " + textBox2.Text, new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(25, 310));
            e.Graphics.DrawString("-Adı Soyadı:  " + textBox4.Text + " " + textBox3.Text, new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(25, 330));
            e.Graphics.DrawString("-Baba Adı:  " + textBox5.Text, new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(25, 350));
            e.Graphics.DrawString("-Doğum Tarihi:  " + textBox8.Text, new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(25, 370));
            e.Graphics.DrawString("-Nüfusa Kyıtlı Olduğu İlçe:  " + textBox13.Text, new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(25, 390));
            e.Graphics.DrawString("-Cilt No:  " + textBox15.Text, new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(25, 410));
            e.Graphics.DrawString("-Aile Sıra No:  " + textBox16.Text, new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(25, 430));
            e.Graphics.DrawString("-Sıra No:  " + textBox17.Text, new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(25, 450));
            e.Graphics.DrawString("-Cinsiyeti:  " + cinsiyet(textBox34.Text), new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(25, 470)); // CİNSİYETİ FONKSİYONA GÖNDERİYOR 
            e.Graphics.DrawString("-Öğrenim Durumu:  " + comboBox2.Text, new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(25, 490));
            e.Graphics.DrawString("-İl:  " + textBox12.Text, new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(25, 510));
            e.Graphics.DrawString("-İlçe:  " + textBox13.Text, new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(25, 530));
            e.Graphics.DrawString("-Belde/Köy:  " + textBox14.Text, new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(25, 550));
            e.Graphics.DrawString("(B)-Ölüm Şekli:", new Font("Times New Roman", 14, FontStyle.Underline), Brushes.Black, new Point(430, 290));// ÖLÜM ŞEKLİ BAŞLIĞI
            e.Graphics.DrawString("-Doğal Ölüm: [ ]", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(530, 310));
            e.Graphics.DrawString("-İntihar: [ ]", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(530, 330));
            e.Graphics.DrawString("-Cinayet: [ ]", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(530, 350));
            e.Graphics.DrawString("-Trafik Kazası: [ ]", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(650, 310));
            e.Graphics.DrawString("-İş Kazası: [ ]", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(650, 330));
            e.Graphics.DrawString("-Diğer Kazalar: [ ]", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(650, 350));
            e.Graphics.DrawString("(C)-Ölüm Yaralanma Sonucu mu Gerçekleşti?", new Font("Times New Roman", 14, FontStyle.Underline), Brushes.Black, new Point(430, 390));
            e.Graphics.DrawString("-EVET: [ ]", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(530, 430));
            e.Graphics.DrawString("-HAYIR: [ ]---> Bölüm D'ye Geçin", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(530, 450));
            e.Graphics.DrawString("-Tarih: [  ][  ] / [  ][  ] / [  ][  ][  ][  ]", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(530, 470));
            e.Graphics.DrawString("-Yaralanma Yeri", new Font("Times New Roman", 14, FontStyle.Underline), Brushes.Black, new Point(430, 500));
            e.Graphics.DrawString("-Evde [ ]", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(530, 520));
            e.Graphics.DrawString("-Kırsal Alanda(çiftlik) [ ]", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(530, 540));
            e.Graphics.DrawString("-Sanayi veya İnş Yeri [ ]", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(530, 560));
            e.Graphics.DrawString("-Spor Alanı [ ]", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(530, 580));
            e.Graphics.DrawString("-Cadde ve Otoyol [ ]", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(530, 600));
            e.Graphics.DrawString("-Ticaret ve Hizmet Alanı [ ]", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(530, 620));
            e.Graphics.DrawString("-Okul,Diğer Kuruluş [ ]", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(530, 640));
            e.Graphics.DrawString("-Diğer:.....................", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(530, 660));
            e.Graphics.DrawString("(D)Otopsi Yapıldı mı? ", new Font("Times New Roman", 14, FontStyle.Underline), Brushes.Black, new Point(430, 690));
            e.Graphics.DrawString("-EVET [  ] ", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(530, 710));
            e.Graphics.DrawString("-HAYIR [  ] ", new Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new Point(530, 730));
            e.Graphics.DrawString("Ölüm Tarihi: [  ][  ] / [  ][  ] / [  ][  ][  ][  ] ", new Font("Times New Roman", 15, FontStyle.Underline), Brushes.Black, new Point(200, 750));
            e.Graphics.DrawString("Bilgiyi Veren", new Font("Times New Roman", 14, FontStyle.Underline), Brushes.Black, new Point(25, 790));
            e.Graphics.DrawString("Adı Soyadı..................................", new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(25, 820));
            e.Graphics.DrawString("Telefon:........................................", new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(25, 850));
            e.Graphics.DrawString("Yakınlık Derecesi:......................", new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(25, 880));
            e.Graphics.DrawString("İmzası:...........................................", new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(25, 910));
            e.Graphics.DrawString("Forumu Dolduran Hekim ", new Font("Times New Roman", 14, FontStyle.Underline), Brushes.Black, new Point(470, 790));
            e.Graphics.DrawString("Adı Soyadı...................... ", new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(470, 820));
            e.Graphics.DrawString("Ünvanı.............................. ", new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(470, 850));
            e.Graphics.DrawString("Tarih................................ ", new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(470, 880));
            e.Graphics.DrawString("İmza.................................. ", new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(470, 910));
            e.Graphics.DrawString("Kaşe..................................", new Font("Times New Roman", 11, FontStyle.Regular), Brushes.Black, new Point(470, 940));

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//KİŞİ ARARKEN DATAGRİDVİEW İN ANLIK DEĞİŞMESİ
        {
            if (radioButton1.Checked) // tc ile arama
            {
                if (textBox1.Text.Trim() == "")
                {
                    verilerigoster();
                }
                else
                {
                    OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from kisibilgiler where TC_NO like'" + textBox1.Text + "%'", baglanti);
                    DataTable tablo = new DataTable();
                    adtr.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                }
            }
            else if (radioButton2.Checked)//isim ile arama
            {
                if (textBox1.Text.Trim() == "")
                {
                    verilerigoster();
                }
                else
                {
                    OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from kisibilgiler where ADI like'" + textBox1.Text + "%'", baglanti);
                    DataTable tablo = new DataTable();
                    adtr.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                }

            }
            else if (radioButton3.Checked)//telefon ile arama
            {
                if (textBox1.Text.Trim() == "")
                {
                    verilerigoster();
                }
                else
                {
                    OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from kisibilgiler where CEP_TEL like'" + textBox1.Text + "%'", baglanti);
                    DataTable tablo = new DataTable();
                    adtr.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                }
            }
            else
            {
                verilerigoster();
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e) // ÖLÜM BELGESİNDE ZORUNLU ÖLÜM TARİHİ GİRİLMESİ YERİ
        {
            if (radioButton7.Checked)
            {
                textBox38.Visible = true;
                label31.Visible = true;
                label32.Visible = true;
            }
            else
            {
                textBox38.Visible = false;
                label31.Visible = false;
                label32.Visible = false;
            }
        }
    }
}
