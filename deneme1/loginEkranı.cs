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
using System.Security.Cryptography;

namespace deneme1
{
    public partial class loginEkranı : Form
    {

        public static SqlConnection baglantı = new SqlConnection("Data Source = TULPAR\\SQLEXPRESS; Initial Catalog =freework; Integrated Security = True");
        
        
        

        public loginEkranı()
        {
            InitializeComponent();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtEposta.Text == "" || txtParola.Text == "")
            {
                label5.Text = "Lütfen boş alan bırakmayınız.";
            }
            else
            {
                string eposta = txtEposta.Text;
                string parola = txtParola.Text;
                string sifreliParola = EncryptPassword(txtParola.Text);


                baglantı.Open();
                SqlCommand cmd = new SqlCommand("Select * from hesap", baglantı);
                SqlDataReader read = cmd.ExecuteReader();

                bool dogruBilgiler = false;

                while (read.Read())
                {
                    if (txtEposta.Text == read["Email"].ToString().TrimEnd() && sifreliParola == read["Parola"].ToString().TrimEnd()) {

                        dogruBilgiler = true;
                        anaSayfa anaSayfa = new anaSayfa();
                        anaSayfa.ShowDialog();
                        this.Hide();

                        label5.Text = "";
                        
                        break;
                    }
                }
                baglantı.Close();

                if (!dogruBilgiler)
                {
                    label5.Text = "Hesap bilgileri hatalı. Lütfen tekrar deneyin.";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void loginEkranı_Load(object sender, EventArgs e)
        {

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


        }
}
