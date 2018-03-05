using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevExpress
{
    public partial class FrmFaturaUrunDuzenleme : Form
    {
        public FrmFaturaUrunDuzenleme()
        {
            InitializeComponent();
        }

        FaturalarVeritabani faturalarVt = new FaturalarVeritabani();
        FaturaDetaylari faturaDetaylari = new FaturaDetaylari();
        public string faturaUrunId;

        private void FrmFaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            Listele();
            //FaturaDetaylari
        }

        public void Listele()
        {
            DataTable dataTable = faturalarVt.ListeleFaturaDetaylariDuzenleme(faturaUrunId);
            //DataRow dr =dataTable.Rows[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
			{
                TxtUrunID.Text = dataTable.Rows[i]["FATURAURUNID"].ToString();
                TxtUrunAd.Text = dataTable.Rows[i]["URUNAD"].ToString();
                TxtMiktar.Text = dataTable.Rows[i]["MIKTAR"].ToString();
                TxtFiyat.Text = dataTable.Rows[i]["FIYAT"].ToString();
                TxtTutar.Text = dataTable.Rows[i]["TUTAR"].ToString();
                TxtFaturaId.Text = dataTable.Rows[i]["FATURAID"].ToString(); 
			}
            

        }

        public void FaturaDetaylari()
        {
            try
            {
                Veritabani veritabani = new Veritabani();
                SqlCommand sqlKomut = new SqlCommand("SELECT * FROM TBL_FATURADETAYI WHERE FATURAURUNID=@faturaurunid", veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@faturaurunid", faturaUrunId);
                SqlDataReader dataReader = sqlKomut.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        faturaDetaylari.FaturaUrunId = int.Parse(dataReader["FATURAURUNID"].ToString());
                        faturaDetaylari.UrunAdi = dataReader["URUNAD"].ToString();
                        faturaDetaylari.Miktari = int.Parse(dataReader["MIKTAR"].ToString());
                        faturaDetaylari. Fiyati = decimal.Parse(dataReader["FIYAT"].ToString());
                        faturaDetaylari.Tutari = decimal.Parse(dataReader["TUTAR"].ToString());
                        faturaDetaylari.FaturaUrunId = int.Parse(dataReader["FATURAID"].ToString());

                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            double miktar, tutar, fiyat;
            fiyat = Convert.ToDouble(TxtFiyat.Text);
            miktar = Convert.ToDouble(TxtFiyat.Text);
            tutar = miktar * fiyat;
            TxtTutar.Text = tutar.ToString();

            faturaDetaylari.UrunAdi = TxtUrunAd.Text;
            faturaDetaylari.Miktari = int.Parse(TxtMiktar.Text);
            faturaDetaylari.Fiyati = decimal.Parse(TxtFiyat.Text);
            faturaDetaylari.Tutari = decimal.Parse(TxtTutar.Text);
            faturaDetaylari.FaturaID = int.Parse(TxtFaturaId.Text);
            faturaDetaylari.FaturaUrunId = int.Parse(TxtUrunID.Text);

            if (faturalarVt.FaturaDetayiGuncelle(faturaDetaylari) == true)
            {
                LblBilgi.Text = "Veritabanina Güncelleme İşlemi Yapıldı";

                Listele();
            }
            else
            {
                LblBilgi.Text = "Veritabanina Güncelleme İşleminde Hata Oluştu";
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (faturalarVt.FaturaDetayiSil(TxtUrunID.Text) == true)
            {
                LblBilgi.Text = "Veritabaninda Silme İşlemi Gerçekleşti";

                Listele();

                Temizle();
            }
            else
            {
                LblBilgi.Text = "Veritabaninda Silme Hata Oluştu";
            }

        }

        public void Temizle()
        {
            TxtMiktar.Text = "";
            TxtTutar.Text = "";
            TxtFaturaId.Text = "";
            TxtFiyat.Text = "";
            TxtFaturaId.Text = "";
            TxtUrunAd.Text = "";
            TxtUrunID.Text = "";
        }
    }
}
