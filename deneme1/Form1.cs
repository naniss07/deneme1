using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deneme1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Color buttonColor = Color.White;
        private bool butonaTiklandiMi1 = false;
        private bool butonaTiklandiMi2 = false;
        public void button1_Click(object sender, EventArgs e)
        {
            butonaTiklandiMi2 = false;
            butonaTiklandiMi1 = true;

            // Birinci butonun rengini  değiştir
            button1.BackColor = Color.GreenYellow;
            // İkinci butonun rengini eski renge döndür
            button2.BackColor = buttonColor;
            button4.BackColor = Color.GreenYellow;


        }
        public void button2_Click(object sender, EventArgs e)
        {
            butonaTiklandiMi1 = false;
            butonaTiklandiMi2 = true;

            // Birinci butonun rengini rastgele değiştir
            button2.BackColor = Color.GreenYellow;
            // İkinci butonun rengini eski renge döndür
            button1.BackColor = buttonColor;
            button4.BackColor = Color.GreenYellow;


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loginEkranı giris = new loginEkranı();
            giris.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(butonaTiklandiMi1==true)
            {
                Form3 form3= new Form3();
                form3.Show();
                this.Hide();
            }
            else if(butonaTiklandiMi2==true)
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
           
        }
    }
}
