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

namespace DevExpress
{
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }

        UrunlerVeritabani urunlerVt = new UrunlerVeritabani();

        Urunler urun = new Urunler();

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            Listele();
        }

        /// <summary>
        /// Verileri Kaydetmek İçin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
           // urun.ProductID = Convert.ToInt32(TxtId.Text);
            urun.UrunAdi = TxtAd.Text;
            urun.MarkaAdi = TxtMarka.Text;
            urun.ModelAdi = TxtModel.Text;
            urun.Yili = MskYıl.Text;
            urun.AdetSayisi = int.Parse(NmrcAdet.Value.ToString());
            urun.AlisFiyati = Decimal.Parse(TxtAlis.Text);
            urun.SatisFiyati = decimal.Parse(TxtSatis.Text);
            urun.Detaylandirma = RchDetay.Text;

            if (urunlerVt.UrunEkle(urun) == true)
            {
                LblBilgi.Text = String.Format("Ekleme İşlemi Başarıyla Kaydedildi");
                
                Listele();
                
                //Temizle();
            }
            else
            {
                LblBilgi.Text = "Ekleme İşleminde bir sorun oluştu";
            }

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (urunlerVt.UrunSil(int.Parse(TxtId.Text)) == true)
            {
                LblBilgi.Text = "Veritabanindan Silme İşlemi Başarıyla Gerçekleşti";

                Listele();

                //Temizle();
            }
            else
            {
                LblBilgi.Text = "Veritabanindan Silme İşleminde Sorun Oluştu";
            }
        }

        private void gridView1_FocusedRowChanged(object sender, XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TxtId.Text = dr["ID"].ToString();
            TxtAd.Text = dr["URUNAD"].ToString();
            TxtMarka.Text = dr["MARKA"].ToString();
            TxtModel.Text = dr["MODEL"].ToString();
            MskYıl.Text = dr["YIL"].ToString();
            NmrcAdet.Value = int.Parse(dr["ADET"].ToString());
            TxtAlis.Text = dr["ALISFIYAT"].ToString();
            TxtSatis.Text = dr["SATISFIYAT"].ToString();
            RchDetay.Text = dr["DETAY"].ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            Urunler urun = new Urunler();
            urun.ProductID = int.Parse(TxtId.Text);
            urun.UrunAdi = TxtAd.Text;
            urun.MarkaAdi = TxtMarka.Text;
            urun.ModelAdi = TxtModel.Text;
            urun.Yili = MskYıl.Text;
            urun.AdetSayisi = int.Parse(NmrcAdet.Value.ToString());
            urun.AlisFiyati = Decimal.Parse(TxtAlis.Text);
            urun.SatisFiyati = Decimal.Parse(TxtSatis.Text);
            urun.Detaylandirma = RchDetay.Text;

            if (urunlerVt.UrunGuncelle(urun) == true)
            {
                LblBilgi.Text = "Urun Başarıyla Güncellendi";

                Listele();

                //Temizle();
            }
            else
            {
                LblBilgi.Text = "Urun Güncellenemedi";
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }        

        /// <summary>
        /// Girilen Değerleri Ekleme ve Güncellemeden Sonra Temizle
        /// </summary>
        public void Temizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtAlis.Text = "";
            TxtSatis.Text = "";
            RchDetay.Text = "";
            TxtMarka.Text = "";
            TxtModel.Text = "";
            NmrcAdet.Value = 0;
            MskYıl.Text = "";
        }
 
        public void Listele()
        {
            DataTable dtaTable = urunlerVt.Listele();

            gridControl1.DataSource = dtaTable;
        }
    }
}
