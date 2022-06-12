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
    public partial class Musteri : Form
    {
        public Musteri()
        {
            InitializeComponent();
        }

        void listele()
        {
            using (SqlConnection sqlcon = new SqlConnection(dbConnection.srConnectionString))
            {
                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT TC,AD,CİNSİYET,TELEFON,DTARİHİ,FİRMA FROM Musteri", sqlcon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dtgMusteri.DataSource = dtbl;
            }
        }

        void Clear()
        {
            mskTc.ResetText();
            txtAd.ResetText();
            cmbCinsiyet.ResetText();
            mskTel.ResetText();
            dtpDTarihi.ResetText();
            txtFirma.ResetText();
        }

        private void Musteri_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Menu backMenu = new Menu();
            backMenu.Show();
        }


        private void Musteri_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            string MusteriEkleQry = "INSERT INTO Musteri (TC,AD,CİNSİYET,TELEFON,DTARİHİ,FİRMA) VALUES (@TC,@AD,@CİNSİYET,@TELEFON,@DTARİHİ,@FİRMA)";
            List<dbConnection.cmdParameterType> lstParam = new List<dbConnection.cmdParameterType>
            {
                new dbConnection.cmdParameterType("@TC" , mskTc.Text),
                new dbConnection.cmdParameterType("@AD" , txtAd.Text),
                new dbConnection.cmdParameterType("@CİNSİYET" , cmbCinsiyet.Text),
                new dbConnection.cmdParameterType("@TELEFON" , mskTel.Text),
                new dbConnection.cmdParameterType("@DTARİHİ" , dtpDTarihi.Text),
                new dbConnection.cmdParameterType("@FİRMA" , txtFirma.Text)
            };
            if(dbConnection.cmd_update_DB (MusteriEkleQry , lstParam) > 0)
            {
                MessageBox.Show("Müşteri Başarılı Bir Şekilde Eklendi");
                listele();
                Clear();
            }
            else
            {
                MessageBox.Show("Bir Hata Oluştu");
            }
        }

        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            string MusteriSilQry = "DELETE FROM Musteri WHERE TC=@TC";
            List<dbConnection.cmdParameterType> lstDelete = new List<dbConnection.cmdParameterType>
            {
                new dbConnection.cmdParameterType("@TC", mskTc.Text),
                new dbConnection.cmdParameterType("@AD", txtAd.Text),
                new dbConnection.cmdParameterType("@CİNSİYET", cmbCinsiyet.Text),
                new dbConnection.cmdParameterType("@TELEFON", mskTel.Text),
                new dbConnection.cmdParameterType("@DTARİHİ", dtpDTarihi.Text),
                new dbConnection.cmdParameterType("@FİRMA", txtFirma.Text)
             };
            if (dbConnection.cmd_update_DB(MusteriSilQry, lstDelete) > 0)
            {
                MessageBox.Show("Müşteri Başarılı Bir Şekilde Silidni");
                listele();
                Clear();
            }
            else
            {
                MessageBox.Show("Bir Hata Oluştu");
            }
        }

        private void dtgMusteri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            mskTc.Text = dtgMusteri.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dtgMusteri.CurrentRow.Cells[1].Value.ToString();
            cmbCinsiyet.Text = dtgMusteri.CurrentRow.Cells[2].Value.ToString();
            mskTel.Text = dtgMusteri.CurrentRow.Cells[3].Value.ToString();
            dtpDTarihi.Value = Convert.ToDateTime(dtgMusteri.CurrentRow.Cells[4].Value);
            txtFirma.Text = dtgMusteri.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            string MusteriGuncelleQry = "UPDATE Musteri SET TC=@TC , AD=@AD , CİNSİYET = @CİNSİYET , TELEFON=@TELEFON, DTARİHİ=@DTARİHİ , FİRMA = @FİRMA WHERE TC=@TC";
            List<dbConnection.cmdParameterType> lstUpdte = new List<dbConnection.cmdParameterType>
            {
                new dbConnection.cmdParameterType("@TC", mskTc.Text),
                new dbConnection.cmdParameterType("@AD", txtAd.Text),
                new dbConnection.cmdParameterType("@CİNSİYET", cmbCinsiyet.Text),
                new dbConnection.cmdParameterType("@TELEFON", mskTel.Text),
                new dbConnection.cmdParameterType("@DTARİHİ", dtpDTarihi.Text),
                new dbConnection.cmdParameterType("@FİRMA", txtFirma.Text)
             };
            if (dbConnection.cmd_update_DB(MusteriGuncelleQry, lstUpdte) > 0)
            {
                MessageBox.Show("Bilgiler Başarılı Bir Şekilde Değiştirildi");
                listele();
                Clear();
            }
            else
            {
                MessageBox.Show("Bir Hata Oluştu");
            }
        }
    }
}
