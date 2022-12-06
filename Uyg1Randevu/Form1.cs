using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uyg1Randevu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tckimlikNo = textBox1.Text;
            string adi=textBox2.Text;
            string soyadi=textBox3.Text;
            string klinik = comboBox1.SelectedItem.ToString();
            string tarih = dateTimePicker1.Value.ToShortDateString(); // sadece tarih kismini tutmak icin 
            string saat=comboBox2.SelectedItem.ToString();

            string satir = tckimlikNo + "*" + adi + "*" + soyadi + "*" + klinik + "*" + tarih + "*" + saat;
            //textBox4.Text += satir+Environment.NewLine;// her bir satir ekledikten sonra alt satira gecmek icin envireoment.newline giriyoruz
            try
            {
                if (Randevu.randevuVarMi(klinik, tarih, saat) == true)
                    MessageBox.Show("Sectiginiz Bolumden Sectiginiz Tarih ve Saat Dolu");
                else
                Randevu.Ekle(satir);// metod static oldugu icin sinif ismi uzerinden cagiriyoruz
               
            }
            catch
            {
                MessageBox.Show("Eklenemedi");
            }
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ricerik = Randevu.tumRandevular();
            textBox4.Text = ricerik;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tarih = dateTimePicker1.Value.ToShortDateString();
            string polikinlik = ComboBox1
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            Form1 form1 = new Form1();
            form1.Hide();
        }
    }
}
