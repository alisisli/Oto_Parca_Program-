using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oto_Servis_Programı
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnAracBilgileri_Click(object sender, EventArgs e)
        {
            this.Hide();
            YeniIslem islemEkle = new YeniIslem();
            islemEkle.Show();
        }

        private void btnAracİslemleri_Click(object sender, EventArgs e)
        {
            this.Hide();
            GecmisIslemler islmeGecmisi = new GecmisIslemler();
            islmeGecmisi.Show();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnMusteriİslemleri_Click(object sender, EventArgs e)
        {
            this.Hide();
            Musteri musteriForm = new Musteri();
            musteriForm.Show();
        }

        private void btnOturmuKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ayarlar ayarlar = new Ayarlar();
            ayarlar.Show();
        }

        private void btnAracSatis_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stok goStok = new Stok();
            goStok.Show();
        }
    }
}
