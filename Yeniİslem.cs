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
    public partial class YeniIslem : Form
    {
        public YeniIslem()
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
        private void YeniIslem_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(dbConnection.srConnectionString))
                {
                    sqlcon.Open();
                    SqlCommand sc = new SqlCommand("SELECT (AD) FROM Musteri", sqlcon);
                    SqlDataReader reader;
                    reader = sc.ExecuteReader();
                    DataTable d = new DataTable();
                    d.Columns.Add("AD", typeof(string));
                    d.Load(reader);
                    txtAd.ValueMember = "AD";
                    txtAd.DataSource = d;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string islemEkleQry = "INSERT INTO islem (Ad,Telefon,İslem,Parca,Adet,Ucret) VALUES (@Ad,@Telefon,@İslem,@Parca,@Adet,@Ucret)";
            List<dbConnection.cmdParameterType> lstParam = new List<dbConnection.cmdParameterType>
            {
                 new dbConnection.cmdParameterType("@Ad", txtAd.Text),
                new dbConnection.cmdParameterType("@Telefon" , mskdTelefon.Text),
                new dbConnection.cmdParameterType("@İslem" , cmbİslem.Text),
                new dbConnection.cmdParameterType("@Parca" , cmbParca.Text),
                new dbConnection.cmdParameterType("@Adet" , txtAdet.Text),
                new dbConnection.cmdParameterType("@Ucret" , txtUcret.Text)
            };
            if(dbConnection.cmd_update_DB (islemEkleQry , lstParam) > 0 )
            {
                MessageBox.Show("İşlem Başarıyla Kaydedildi");
                listele();
                this.Refresh();
                Clear();
            }
        }

        private void YeniIslem_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Login log = new Login();
            Menu menuDon = new Menu();
            menuDon.Show();
        }
    }
}
