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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=muhtarlik.mdb");
        OleDbCommand komut = new OleDbCommand();
        public void verilerigoster() // VERİLERİ DATAGRİDVİEW DA GÖSTEREN (FONKSİYON)...
        {
            baglanti.Open();
            DataSet ds = new DataSet();
            DataTable tablo = new DataTable();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from kisiolum", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
            dataGridView1.Columns[0].Visible = false;
        }
        private void label6_Click(object sender, EventArgs e)//GEREKSİZ AÇILAN PENCERE
        {
        }
        private void Form6_Load(object sender, EventArgs e)// FORM6 LOAD OLAYI
        {
            verilerigoster();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//DATAGRİDVİEW TIKLAMA OLAYI(VERİLERİ GÖSTERME)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox4.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label3.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }
        private void button1_Click(object sender, EventArgs e)//Ölüm Silme
        {
            baglanti.Open();
            komut = new OleDbCommand("Delete from kisiolum where tc='" + textBox4.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigoster();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if(textBox5.Text.Trim()=="")
            {
                verilerigoster();
            }
            else
            {
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from kisiolum where tc like'" + textBox5.Text + "%'", baglanti);
                DataTable tablo = new DataTable();
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
        }
    }
}
