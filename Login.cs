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

namespace Oto_Servis_Programı
{
    public partial class Login : Form
    {
        public static string tc, ad, soyad;
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = ALI\\SQLEXPRESS; Initial Catalog = OtoServis; Integrated Security = True"); // bağlantıt oluşturma   
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM Login WHERE kullanıcıAdı='" + txt_kAdi.Text + "' AND sifre='" + txt_Sifre.Text + "'", con);
            /* veri tabanında olan kullanıcı adı ve şifreleri Login ekranındaki girilen belgelerle karşılaştırıyor.Doğru ise PersenolForm'a gönderiyor. */
            DataTable dt = new DataTable(); //sanal tablo oluşturur  
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                //Eğer işlem çalışırsa yapılacak olan formlar arası geçiş işlemi//
                this.Hide();
                new Menu().Show();
            }
            else
                MessageBox.Show("Kullanıcı Bulunamadı");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string a = txt_Sifre.Text;
                txt_Sifre.PasswordChar = '\0';
            }
            else
            {
                txt_Sifre.PasswordChar = '*';
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
