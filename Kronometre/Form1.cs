using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kronometre
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1; // hız
            timer2.Interval = 1;
            timer4.Interval = 1;
            timer3.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

            button1.Text = "Başlat";
            button1.Enabled = false;

            button4.Left = 19; // yer değiştirme
            button4.Top = 173;

            button3.Visible = true;
            listBox1.Visible = true;
            label15.Visible = true;
            button1.Text = "Devam Et";
        }

        int saat = 0, dakika = 0, saniye = 0, salise = 0;

        private void button4_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (salise > 0)
            {
                salise--;
            }

            if (salise == 0)
            {
                saniye--;
                salise = 59;
            }

            if (saniye == 0)
            {
                saniye = 59;
                dakika--;
            }

            if (dakika == 0)
            {
                dakika = 59;
                saat--;
            }

            label5.Text = saat.ToString();
            label6.Text = dakika.ToString();
            label7.Text = saniye.ToString();
            label8.Text = salise.ToString();

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label16.Text = DateTime.Now.ToLongDateString();
            label17.Text = DateTime.Now.ToLongTimeString();
        }
    

        private void button5_Click(object sender, EventArgs e)
        {
            timer4.Start();

            salise = Convert.ToInt16(comboBox4.Text);
            saniye = Convert.ToInt16(comboBox3.Text);
            dakika = Convert.ToInt16(comboBox2.Text);
            saat = Convert.ToInt16(comboBox1.Text);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (salise > 0)
            {
                salise--;
            }

            if (salise == 0)
            {
                saniye--;
                salise = 59;
            }

            if (saniye == 0)
            {
                saniye = 59;
                dakika--;
            }

            if (dakika == 0)
            {
                dakika = 59;
                saat--;
            }

            label5.Text = saat.ToString();
            label6.Text = dakika.ToString();
            label7.Text = saniye.ToString();
            label8.Text = salise.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {

            timer1.Enabled = false;
            button1.Enabled = true;

            listBox1.Items.Add(saat + "    :    " + dakika + "    :    " + saniye + "    .    " + salise);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bitirmek / Sıfırlamak istediğinize emin misiniz? ", "Son Kararın Mı?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                timer1.Stop();
                timer2.Stop();

                salise = 0;
                saniye = 0;
                dakika = 0;
                saat = 0;

                label5.Text = saat.ToString();
                label6.Text = dakika.ToString();
                label7.Text = saniye.ToString();
                label8.Text = salise.ToString();

                listBox1.Items.Clear();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            salise++;
            while (salise == 60)
            {
                salise = 0;
                saniye++;
            }

            while (saniye == 60)
            {
                saniye = 0;
                dakika++;
            }

            while (dakika == 60)
            {
                dakika = 0;
                saat++;
            }
            /*
            salise++;

            if (salise == 60)
            {
                salise = 0;
                saniye++;

            }

            if (saniye == 60)
            {
                saniye = 0;
                dakika++;
            }

            if (dakika == 60)
            {
                dakika = 0;
                saat++;
            }
*/
            label5.Text = saat.ToString();
            label6.Text = dakika.ToString();
            label7.Text = saniye.ToString();
            label8.Text = salise.ToString();
        }
    }
}
