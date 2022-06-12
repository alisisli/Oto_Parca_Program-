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
    public partial class GecmisIslemler : Form
    {
        public GecmisIslemler()
        {
            InitializeComponent();
        }
        void Clear()
        {
            txtAd.ResetText();
            mskdTelefon.ResetText();
            cmbİslem.ResetText();
            cmbParca.ResetText();
            txtAdet.ResetText();
            txtUcret.ResetText();
        }
        void listele()
        {
            using (SqlConnection sqlcon = new SqlConnection(dbConnection.srConnectionString))
            {
                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT Ad,Telefon,İslem,Parca,Adet,Ucret FROM islem", sqlcon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                dtg_islem.DataSource = dtbl;
            }
        }
        private void dtg_islem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAd.Text = dtg_islem.CurrentRow.Cells[0].Value.ToString();
            mskdTelefon.Text = dtg_islem.CurrentRow.Cells[1].Value.ToString();
            cmbİslem.Text = dtg_islem.CurrentRow.Cells[2].Value.ToString();
            cmbParca.Text = dtg_islem.CurrentRow.Cells[3].Value.ToString();
            txtAdet.Text = dtg_islem.CurrentRow.Cells[4].Value.ToString();
            txtUcret.Text = dtg_islem.CurrentRow.Cells[5].Value.ToString();
        }

        private void GecmisIslemler_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(dbConnection.srConnectionString))
                {
                    sqlcon.Open();
                    SqlCommand sc = new SqlCommand("SELECT (İslem) FROM Stok", sqlcon);
                    SqlDataReader reader;
                    reader = sc.ExecuteReader();
                    DataTable d = new DataTable();
                    d.Columns.Add("İslem", typeof(string));
                    d.Load(reader);
                    cmbİslem.ValueMember = "İslem";
                    cmbİslem.DataSource = d;
                    sqlcon.Close();
                }
            }
            catch (Exception)
            {

            }
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(dbConnection.srConnectionString))
                {
                    sqlcon.Open();
                    SqlCommand sc = new SqlCommand("SELECT (Parca) FROM Stokk", sqlcon);
                    SqlDataReader reader;
                    reader = sc.ExecuteReader();
                    DataTable d = new DataTable();
                    d.Columns.Add("Parca", typeof(string));
                    d.Load(reader);
                    cmbParca.ValueMember = "Parca";
                    cmbParca.DataSource = d;
                    sqlcon.Close();
                }
            }
            catch (Exception)
            {

            }
            listele();
        }

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menuDon = new Menu();
            menuDon.Show();
        }

        private void GecmisIslemler_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Menu menuDon = new Menu();
            menuDon.Show();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string islemSilQry = "DELETE FROM islem WHERE Ad = @Ad";
            List<dbConnection.cmdParameterType> lstDelete = new List<dbConnection.cmdParameterType>
            {
                new dbConnection.cmdParameterType("@Ad", txtAd.Text),
                new dbConnection.cmdParameterType("@Telefon" , mskdTelefon.Text),
                new dbConnection.cmdParameterType("@İslem" , cmbİslem.Text),
                new dbConnection.cmdParameterType("@Parca" , cmbParca.Text),
                new dbConnection.cmdParameterType("@Adet" , txtAdet.Text),
                new dbConnection.cmdParameterType("@Ucret" , txtUcret.Text)
            };
            if(dbConnection.cmd_update_DB(islemSilQry , lstDelete) > 0)
            {
                MessageBox.Show("İşlem Başarılı Bir Şekilde Silindi");
                listele();
                Clear();
            }
            else
            {
                MessageBox.Show("Bir Hata Oluştu");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string islemGuncelleQry = "UPDATE islem SET Ad=@Ad , Telefon=@Telefon , İslem=@İslem , Parca=@Parca , Adet=@Adet , Ucret=@Ucret WHERE Telefon=@Telefon";
            List<dbConnection.cmdParameterType> lstUpdte = new List<dbConnection.cmdParameterType>
            {
                new dbConnection.cmdParameterType("@Ad", txtAd.Text),
                new dbConnection.cmdParameterType("@Telefon" , mskdTelefon.Text),
                new dbConnection.cmdParameterType("@İslem" , cmbİslem.Text),
                new dbConnection.cmdParameterType("@Parca" , cmbParca.Text),
                new dbConnection.cmdParameterType("@Adet" , txtAdet.Text),
                new dbConnection.cmdParameterType("@Ucret" , txtUcret.Text)
            };
            if (dbConnection.cmd_update_DB(islemGuncelleQry, lstUpdte) > 0)
            {
                MessageBox.Show("İşlem Başarılı Bir Şekilde Güncellendi");
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
