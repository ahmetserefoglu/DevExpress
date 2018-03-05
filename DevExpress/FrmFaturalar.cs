using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevExpress
{
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }

        FaturalarVeritabani faturalarVt = new FaturalarVeritabani();

        FaturaBilgileri faturaBilgileri = new FaturaBilgileri();

        FaturaDetaylari faturaDetaylari = new FaturaDetaylari();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            Listele();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Listele()
        {
            DataTable dtaTable = faturalarVt.ListeleFaturaBilgileri();

            gridControl1.DataSource = dtaTable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnKaydet_Click(object sender, EventArgs e)
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

            if (faturalarVt.FaturaDetaylariEkle(faturaDetaylari) == true)
            {
                LblBilgi.Text = "Veritabanina Ekleme İşlemi Yapıldı";

                Listele();
            }
            else
            {
                LblBilgi.Text = "Veritabanina Ekleme İşleminde Hata Oluştu";
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                TxtId.Text = dr["FATURABILGIID"].ToString();
                TxtSeri.Text = dr["SERI"].ToString();
                TxtSiraNo.Text = dr["SIRANO"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                MskSaat.Text = dr["SAAT"].ToString();
                TxtVergiDaire.Text = dr["VERGIDAIRE"].ToString();
                TxtAlici.Text = dr["ALICI"].ToString();
                TxtTeslimEden.Text = dr["TESLIMEDEN"].ToString();
                TxtTeslimAlan.Text = dr["TESLIMALAN"].ToString();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public void FaturaBilgiTemizle()
        {
            TxtId.Text = "";
            TxtSeri.Text = "";
            TxtSiraNo.Text = "";
            TxtTeslimAlan.Text = "";
            TxtTeslimEden.Text = "";
            MskSaat.Text = "";
            MskTarih.Text = "";
            TxtAlici.Text = "";
            TxtVergiDaire.Text = "";
        }

        /// <summary>
        /// 
        /// </summary>
        public void FaturaDetayiTemizle()
        {
            TxtMiktar.Text = "";
            TxtTutar.Text = "";
            TxtFaturaId.Text = "";
            TxtFiyat.Text = "";
            TxtFaturaId.Text = "";
            TxtUrunAd.Text = "";
            TxtUrunID.Text = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (faturalarVt.FaturaDetayiSil(TxtUrunID.Text) == true)
            {
                LblBilgi.Text = "Veritabaninda Silme İşlemi Gerçekleşti";

                Listele();
            }
            else
            {
                LblBilgi.Text = "Veritabaninda Silme Hata Oluştu";
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            FaturaDetayiTemizle();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFbKaydet_Click(object sender, EventArgs e)
        {
            //faturaBilgileri.FaturaBilgiId = int.Parse(TxtId.Text);
            faturaBilgileri.SeriNo = TxtSeri.Text;
            faturaBilgileri.SiraNo = TxtSiraNo.Text;
            faturaBilgileri.Tarih = MskTarih.Text;
            faturaBilgileri.Saat = MskSaat.Text;
            faturaBilgileri.VergiDaire = TxtVergiDaire.Text;
            faturaBilgileri.Alici = TxtAlici.Text;
            faturaBilgileri.TeslimAlan = TxtTeslimAlan.Text;
            faturaBilgileri.TeslimEden = TxtTeslimEden.Text;

            if (faturalarVt.FaturaBilgileriEkle(faturaBilgileri) == true)
            {
                LblBilgi.Text = "Veritabanina Ekleme İşlemi Yapıldı";

                Listele();
            }
            else
            {
                LblBilgi.Text = "Veritabanina Ekleme İşleminde Hata Oluştu";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFbSil_Click(object sender, EventArgs e)
        {
            if (faturalarVt.FaturaBilgiSil(TxtId.Text) == true)
            {
                LblBilgi.Text = "Veritabaninda Silme İşlemi Gerçekleşti";

                Listele();
            }
            else
            {
                LblBilgi.Text = "Veritabaninda Silme Hata Oluştu";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFbGuncelle_Click(object sender, EventArgs e)
        {
            faturaBilgileri.FaturaBilgiId = int.Parse(TxtId.Text);
            faturaBilgileri.SeriNo = TxtSeri.Text;
            faturaBilgileri.SiraNo = TxtSiraNo.Text;
            faturaBilgileri.Tarih = MskTarih.Text;
            faturaBilgileri.Saat = MskSaat.Text;
            faturaBilgileri.VergiDaire = TxtVergiDaire.Text;
            faturaBilgileri.Alici = TxtAlici.Text;
            faturaBilgileri.TeslimAlan = TxtTeslimAlan.Text;
            faturaBilgileri.TeslimEden = TxtTeslimEden.Text;

            if (faturalarVt.FaturaBilgiGuncelle(faturaBilgileri) == true)
            {
                LblBilgi.Text = "Veritabanina Güncelleme İşlemi Yapıldı";

                Listele();
            }
            else
            {
                LblBilgi.Text = "Veritabanina Güncelleme İşleminde Hata Oluştu";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFbTemizle_Click(object sender, EventArgs e)
        {
            FaturaBilgiTemizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDetay frmFaturaDetay = new FrmFaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                frmFaturaDetay.id = dr["FATURABILGIID"].ToString();
            }
            frmFaturaDetay.Show();
        }


    }
}
