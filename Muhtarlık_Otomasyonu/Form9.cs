using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muhtarlık_Otomasyonu
{
    public partial class Form9 : Form
    {
        private int tmr2;
        private int _ticks;
        public Form9()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)// FORM1 E GEÇİŞ ŞARTLARI
        {
            _ticks++;
            textBox1.Text = _ticks.ToString();
            if(_ticks == 260)
            {
                timer1.Stop();
                Form1 frm1 = new Form1();
                this.Hide();
                frm1.ShowDialog();

            }

        }

        private void Form9_Load(object sender, EventArgs e)//MEDİA OYNATMA 
        {
            timer2.Enabled = true;
            timer2.Start();
            string path = Application.StartupPath.ToString();
            textBox2.Text = path.ToString()+"\\video\\intro.mp4";
            axWindowsMediaPlayer1.URL = textBox2.Text;
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            tmr2++;
            if(tmr2 == 2)
            {
                button1.ForeColor = Color.Red;

            }
            if(tmr2 == 4)
            {
                button1.ForeColor = Color.Green;
            }
            if (tmr2 == 6)
            {
                button1.ForeColor = Color.Blue;
            }
            if (tmr2 == 8)
            {
                button1.ForeColor = Color.Purple;
            }
            if (tmr2 == 10)
            {
                button1.ForeColor = Color.Cyan;
                tmr2 = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            tmr2 = 0;
            timer1.Stop();
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.ShowDialog();
            

        }
    }
}
