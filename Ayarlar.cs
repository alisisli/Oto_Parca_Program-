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
using OtoServis;

namespace Oto_Servis_Programı
{
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
        }

        void Clear()
        {
            mskTc.ResetText();
            txtAd.ResetText();
            txtSoyad.ResetText();
            cmbCinsiyet.ResetText();
            mskTel.ResetText();
            txtKullaniciAdi.ResetText();
            txtSifre.ResetText();
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {

        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            string kullanıcıEkleQry = "INSERT INTO Login (tc,ad,soyad,cinsiyet,telefon,kullanıcıAdı,sifre) VALUES (@tc,@ad,@soyad,@cinsiyet,@telefon,@kullanıcıAdı,@sifre)";
            List<dbConnection.cmdParameterType> lstKullanıcıEkle = new List<dbConnection.cmdParameterType>
            {
                new dbConnection.cmdParameterType("@tc" , mskTc.Text),
                new dbConnection.cmdParameterType("@ad" , txtAd.Text),
                new dbConnection.cmdParameterType("@soyad" , txtSoyad.Text),
                new dbConnection.cmdParameterType("@cinsiyet" , cmbCinsiyet.Text),
                new dbConnection.cmdParameterType("@telefon" , mskTel.Text),
                new dbConnection.cmdParameterType("@kullanıcıAdı" , txtKullaniciAdi.Text),
                new dbConnection.cmdParameterType("@sifre" , txtSifre.Text)
            };
            if (dbConnection.cmd_update_DB(kullanıcıEkleQry, lstKullanıcıEkle) > 0)
            {
                MessageBox.Show("Kullanıcı Başarıyla Eklendi !!");
                Clear();
            }
            else
            {
                MessageBox.Show("Bir Hata Oluştu");
            }
        }

        private void Ayarlar_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Menu backmenu = new Menu();
            backmenu.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                string a = txtSifre.Text;
                txtSifre.PasswordChar = '\0';
            }
            else
            {
                txtSifre.PasswordChar = '*';
            }
        }

        private void btnSilme_Click(object sender, EventArgs e)
        {
            string kullanıcıSilQry = "DELETE FROM Login WHERE kullanıcıAdı=@kullanıcıAdı AND sifre=@sifre";
            List<dbConnection.cmdParameterType> lstKullancıSil = new List<dbConnection.cmdParameterType>
            {
                new dbConnection.cmdParameterType("@tc" , mskTc.Text),
                new dbConnection.cmdParameterType("@ad" , txtAd.Text),
                new dbConnection.cmdParameterType("@soyad" , txtSoyad.Text),
                new dbConnection.cmdParameterType("@cinsiyet" , cmbCinsiyet.Text),
                new dbConnection.cmdParameterType("@telefon" , mskTel.Text),
                new dbConnection.cmdParameterType("@kullanıcıAdı" , txtSilmeKAdi.Text),
                new dbConnection.cmdParameterType("@sifre" , txtSilmeSifre.Text)
            };
            if (dbConnection.cmd_update_DB(kullanıcıSilQry, lstKullancıSil) > 0)
            {
                MessageBox.Show("!!! Kullanıcı Başarıyla Silindi !!!");
                txtSilmeKAdi.ResetText();
                txtSilmeSifre.ResetText();
            }
            else
            {
                MessageBox.Show("KULLANICI BULUNAMADI");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string sifreYenilemeQry = "UPDATE Login SET sifre=@sifre WHERE kullanıcıAdı=@kullanıcıAdı AND tc=@tc";
            List<dbConnection.cmdParameterType> lstUpdatePass = new List<dbConnection.cmdParameterType>
            {
                new dbConnection.cmdParameterType("@kullanıcıAdı" , txtDegistirmeKadi.Text),
                new dbConnection.cmdParameterType("@tc" , txtDegistirTC.Text),
                new dbConnection.cmdParameterType("@sifre" , txtDegistirmeSifre.Text)
            };
            if(dbConnection.cmd_update_DB (sifreYenilemeQry , lstUpdatePass) > 0)
            {
                MessageBox.Show("Şifre Başarılı Bir Şekilde Gerçekleştirildi");
                txtDegistirmeKadi.ResetText();
                txtDegistirmeSifre.ResetText();
                txtDegistirTC.ResetText();
            }
            else
            {
                MessageBox.Show("KULLANICI BULUNAMADI");
            }
        }
    }
}
