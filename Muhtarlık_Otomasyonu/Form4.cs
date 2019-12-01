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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=muhtarlik.mdb"); // BAGLANTI SAGLAMA
        OleDbCommand komut = new OleDbCommand();

        private void button1_Click(object sender, EventArgs e)  // RESİM EKLEME BUTONU VE YAPACAĞI İŞLEMLER...
        {
            if(pictureBox2.Image == null) // EGER PICTUREBOX2(VESİKALIK FOTO) BOŞ İSE YAPILACAK İŞLEMLER...
            {
                openFileDialog1.ShowDialog();
                pictureBox2.ImageLocation = openFileDialog1.FileName;
                textBox33.Text = openFileDialog1.FileName;
                label1.Visible = false;
                label2.Text = "Resim Değiştir";

            }
            else // EĞER PİCTUREBOX TA BİR RESİM VAR İSE YAPILACAK İŞLEMLER..
            {
                DialogResult basılan; // DIALOGRESULTUN GERCEKLESTIRECEGI ISLEMLER...
                basılan = MessageBox.Show("Resmi değişmek istediğinize emin misiniz?", "STOP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (basılan == DialogResult.Yes)
                {
                    openFileDialog1.ShowDialog();
                    pictureBox2.ImageLocation = openFileDialog1.FileName;
                    textBox33.Text = openFileDialog1.FileName;
                }
                else { }                    
            }    
        }
        private void button2_Click(object sender, EventArgs e)  // KAYDET TUŞUNA BASILINCA GERÇEKLEŞECEK İŞLEMLER...
        {
            baglanti.Open();
            komut = new OleDbCommand("insert into kisibilgiler(TC_NO,SOYADI,ADI,BABA_ADI,ANA_ADI,DOGUM_YERI,DOGUM_TARIHI," +
                "MEDENI_HALI,DINI,KAN_GRUBU,ILI,ILCESI,MAHALLE_KOY,CILT_NO,AILESIRA_NO,SIRA_NO,VERILDIGI_YER,VERILIS_NEDENI," +
                "KAYIT_NO,VERILIS_TARIHI,ONCEKI_SOYADI,MESLEGI,OGRENIM_DURUMU,ASKKAYIT_NO,CEP_TEL,VERGI_NO,VERGI_DAIRESI,KAYIT_TARIHI," +
                "SEMT_MAH,CADDE,SOKAK,SITE,APT_ADI,BINA_NO,DAIRE_NO,IL,ILCE,BUCAK_KOY,OTURDUGU_EV,FAKIRLIK_DERECE,KONUT_TURU,ODA_SAYISI,M2,RESIM_ADRESI) " +
                "values('"+textBox1.Text.ToString()+"', '"+ textBox2.Text.ToString() + "', '"+ textBox3.Text.ToString() + "','"+ textBox4.Text.ToString() + "', " +
                "'"+ textBox5.Text.ToString() + "', '"+ textBox6.Text.ToString() + "', '"+ textBox11.Text.ToString() + "', '"+ comboBox1.Text.ToString() + "', " +
                "'"+ textBox8.Text.ToString() + "', '"+ textBox9.Text.ToString() + "', '"+ textBox10.Text.ToString() + "', '"+ textBox7.Text.ToString() + "', " +
                "'"+ textBox12.Text.ToString() + "', '"+ textBox13.Text.ToString() + "', '"+ textBox14.Text.ToString() + "', '"+ textBox15.Text.ToString() + "', '" +
                ""+ textBox16.Text.ToString() + "', '"+ textBox17.Text.ToString() + "', '"+ textBox18.Text.ToString() + "', '"+ textBox19.Text.ToString() + "', " +
                "'"+ textBox20.Text.ToString() + "', '"+ textBox21.Text.ToString() + "', '"+ comboBox2.Text.ToString() + "', '"+ textBox22.Text.ToString() + "', " +
                "'"+ maskedTextBox1.Text.ToString() + "', '"+ textBox24.Text.ToString() + "', '"+ textBox25.Text.ToString() + "', '"+ dateTimePicker1.Value.ToString() + "', " +
                "'"+ comboBox3.Text.ToString() + "', '"+ comboBox4.Text.ToString() + "', '"+ comboBox5.Text.ToString() + "', '"+textBox23.Text.ToString()+"', '"+textBox26.Text.ToString()+"', " +
                "'"+textBox28.Text.ToString()+"', '"+ textBox27.Text.ToString() + "', '"+ comboBox7.Text.ToString() + "', '"+ textBox29.Text.ToString() + "', '"+ textBox30.Text.ToString() + "', " +
                "'"+ comboBox8.Text.ToString() + "', '"+ comboBox9.Text.ToString() + "', '"+ comboBox10.Text.ToString() + "', '"+ textBox31.Text.ToString() + "', '"+ textBox32.Text.ToString() + "', " +
                "'"+ textBox33.Text.ToString() + "')",baglanti);
         
           
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("KAYIT BAŞARIYLA EKLENDİ", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear(); 
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox24.Clear();
            textBox25.Clear();
            textBox26.Clear();
            textBox27.Clear();
            textBox28.Clear();
            textBox29.Clear();
            textBox30.Clear();
            textBox31.Clear();
            textBox32.Clear();
            textBox33.Clear();

            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;
            comboBox4.Text = null;
            comboBox5.Text = null;
            comboBox7.Text = null;
            comboBox8.Text = null;
            comboBox9.Text = null;
            comboBox10.Text = null;

            maskedTextBox1.Clear();
            textBox1.Focus();
 
        }
    }
}
