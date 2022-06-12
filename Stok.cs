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
    public partial class Stok : Form
    {
        public Stok()
        {
            InitializeComponent();
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            string İslemEkleQry = "INSERT INTO Stok (İslem) VALUES (@İslem)";
            List<dbConnection.cmdParameterType> lstİslemEkle = new List<dbConnection.cmdParameterType>
            {
                new dbConnection.cmdParameterType("@İslem" , txtİslemAd.Text)
            };
            if(dbConnection.cmd_update_DB (İslemEkleQry , lstİslemEkle) > 0)
            {
                MessageBox.Show("İşlem Başarılı Bir Şekilde Eklendi");
                txtİslemAd.ResetText();
            }
            else
            {
                MessageBox.Show("Bir Hata Oluştu");
            }
        }

        private void Stok_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Menu backMenu = new Menu();
            backMenu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ParcaEkleQry = "INSERT INTO Stokk (Parca) VALUES (@Parca)";
            List<dbConnection.cmdParameterType> lstParcaEkle = new List<dbConnection.cmdParameterType>
            {
                new dbConnection.cmdParameterType("@Parca" , txtParcaAd.Text)
            };
            if (dbConnection.cmd_update_DB(ParcaEkleQry, lstParcaEkle) > 0)
            {
                MessageBox.Show("Parça Başarılı Bir Şekilde Eklendi");
                txtParcaAd.ResetText();
            }
            else
            {
                MessageBox.Show("Bir Hata Oluştu");
            }
        }

        private void Stok_Load(object sender, EventArgs e)
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
                    cmbİslemAd.ValueMember = "İslem";
                    cmbİslemAd.DataSource = d;
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
                    cmbParcaAd.ValueMember = "Parca";
                    cmbParcaAd.DataSource = d;
                    sqlcon.Close();
                }
            }
            catch (Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string İslemSilmeQry = "DELETE FROM Stok WHERE İslem = @İslem";
            List<dbConnection.cmdParameterType> lstİslemSil = new List<dbConnection.cmdParameterType>
            {
                new dbConnection.cmdParameterType("@İslem" , cmbİslemAd.Text)
            };
            if (dbConnection.cmd_update_DB(İslemSilmeQry, lstİslemSil) > 0)
            {
                MessageBox.Show("İşlem Başarılı Bir Şekilde Silindi");
                cmbİslemAd.ResetText();
                cmbİslemAd.Refresh();
            }
            else
            {
                MessageBox.Show("Bir Hata Oluştu");
            }
        }
    }
}
