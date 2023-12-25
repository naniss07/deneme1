using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Numerics;
using System.Net.Mail;
using System.Security.Cryptography;

namespace deneme1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            InitializeComboBoxFromTextFile("ulke.txt");
        }
        SqlConnection connectionn = loginEkranı.baglantı;

        private void InitializeComboBoxFromTextFile(string filePath)
        {
            try
            {
                // Dosyadan tüm satırları oku
                string[] lines = File.ReadAllLines(filePath);

                // ComboBox kontrolüne öğeleri ekle
                comboBox1.Items.AddRange(lines);

                
               

            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya okuma hatası: " + ex.Message);
            }
        }





        private void button3_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            loginEkranı giris = new loginEkranı();
            giris.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginEkranı giris = new loginEkranı();
            giris.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = comboBox1.SelectedItem.ToString();
            

        }
    }
}
