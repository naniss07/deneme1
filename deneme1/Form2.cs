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
using System.Reflection.Emit;

namespace deneme1
{
    public partial class Form2 : Form
    {
        public Form2()
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
                txtCountry.Items.AddRange(lines);




            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya okuma hatası: " + ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }




        private void button2_Click(object sender, EventArgs e)
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


        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = txtCountry.SelectedItem.ToString();
        }

        private string selectedOption; // Sınıf içindeki değişken

        private void button1_Click(object sender, EventArgs e)
        {

            bool hataliMi = false;
            if (txtİsim.Text == "" || txtSoyİsim.Text == "" || txtEmail.Text == "" || txtPassword.Text == "" || txtCountry.Text == "")
            {
                label8.Text = "Lütfen boş alan bırakmayınız.";
            }
            else if (hatalar(hataliMi)) { }
            else
            {
              
                string şifre = txtPassword.Text;
                string isim = txtİsim.Text;
                string soyisim = txtSoyİsim.Text;
                string Eposta = txtEmail.Text;
                int KullanıcıTip= 0;
                DateTime kayitTarihi = DateTime.Now;
                string ulke = txtCountry.Text;



                string sifreliParola = EncryptPassword(txtPassword.Text);



                try
                {
                    connectionn.Open();


                    SqlCommand ekle = new SqlCommand("Insert into hesap (İsim,Soyisim,Email,Parola,Ulke,KayitTarihi,Durum) VALUES ('" + isim + "','" + soyisim + "','" + Eposta + "','" + sifreliParola + "','" + ulke + "','" + kayitTarihi + "','"+ KullanıcıTip + "')", connectionn);
                    ekle.ExecuteNonQuery();

                    label8.Text = "";
                    label9.Text = "Kaydınız Başarıyla Yapıldı";

                    

                }
                catch (System.Data.SqlClient.SqlException) { MessageBox.Show("Kayıt yapılamadı yeniden deneyin."); }
                finally { connectionn.Close(); }


                


            }

            

        }

        public static string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }




        private bool Email_Format_Kontrol(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return false;
            }
            catch
            {
                return true;
            }
        }

        private bool hatalar(bool hataliMi)
        {

            if (txtPassword.Text.Length < 5) { label8.Text = "Şifre 5 karakterden az olamaz."; hataliMi = true; }

            else if (txtCountry.Text == null) { label8.Text = "Ülkeyi seçmediniz."; hataliMi = true; }

            else if (Email_Format_Kontrol(txtEmail.Text)) { label8.Text = "Yanlış Email formatı."; hataliMi = true; }

            return hataliMi;
        }


    }
}
