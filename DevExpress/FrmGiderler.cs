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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }

        GiderlerVeritabani giderlerVt = new GiderlerVeritabani();
        Giderler gider = new Giderler();

        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            gider.GiderElektrik = decimal.Parse(TxtElektrik.Text);
            gider.GiderSu = decimal.Parse(TxtSu.Text);
            gider.GiderDogalGaz = decimal.Parse(TxtDogalGaz.Text);
            gider.GiderInternet = decimal.Parse(TxtInternet.Text);
            gider.GiderMaas = decimal.Parse(TxtMaas.Text);
            gider.GiderEkstra = decimal.Parse(TxtEkstra.Text);
            gider.NotBilgisi = RchNot.Text;
            gider.AyBilgisi = CmbAy.Text;
            gider.YilBilgisi = CmbYil.Text;


            if (giderlerVt.GiderEkle(gider) == true)
            {
                LblBilgi.Text = String.Format("Ekleme İşlemi Başarıyla Kaydedildi");

                Listele();

                Temizle();
            }
            else
            {
                LblBilgi.Text = "Ekleme İşleminde bir sorun oluştu";
            }
        
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (giderlerVt.GiderSil(int.Parse(TxtId.Text)) == true)
            {
                LblBilgi.Text = "Veritabanindan Silme İşlemi Başarıyla Gerçekleşti";

                Listele();
            }
            else
            {
                LblBilgi.Text = "Veritabanindan Silme İşleminde Sorun Oluştu";
            }
        
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            gider.GiderID = int.Parse(TxtId.Text);
            gider.GiderElektrik = decimal.Parse(TxtElektrik.Text);
            gider.GiderSu = decimal.Parse(TxtSu.Text);
            gider.GiderDogalGaz = decimal.Parse(TxtDogalGaz.Text);
            gider.GiderInternet = decimal.Parse(TxtInternet.Text);
            gider.GiderMaas = decimal.Parse(TxtMaas.Text);
            gider.GiderEkstra = decimal.Parse(TxtEkstra.Text);
            gider.NotBilgisi = RchNot.Text;
            gider.AyBilgisi = CmbAy.Text;
            gider.YilBilgisi = CmbYil.Text;


            if (giderlerVt.GiderGuncelle(gider) == true)
            {
                LblBilgi.Text = String.Format("Güncelleme İşlemi Başarıyla Kaydedildi");

                Listele();

                Temizle();
            }
            else
            {
                LblBilgi.Text = "Güncelleme İşleminde bir sorun oluştu";
            }
        
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                TxtId.Text = dr["ID"].ToString();
                CmbAy.Text = dr["AY"].ToString();
                CmbYil.Text = dr["YIL"].ToString();
                TxtElektrik.Text = dr["ELEKTRIK"].ToString();
                TxtSu.Text = dr["SU"].ToString();
                TxtDogalGaz.Text = dr["DOGALGAZ"].ToString();
                TxtInternet.Text = dr["INTERNET"].ToString();
                TxtMaas.Text = dr["MAASLAR"].ToString();
                TxtEkstra.Text = dr["EKSTRA"].ToString();
                RchNot.Text = dr["NOTLAR"].ToString();
                
            }
        
        }

        public void Temizle()
        {
            TxtId.Text = "";
            TxtElektrik.Text = "";
            TxtDogalGaz.Text = "";
            TxtEkstra.Text = "";
            TxtSu.Text = "";
            TxtInternet.Text = "";
            TxtMaas.Text = "";
            RchNot.Text = "";
            CmbAy.Text = "";
            CmbYil.Text = "";

        }

        public void Listele()
        {
            DataTable dtaTable = giderlerVt.Listele();

            gridControl1.DataSource = dtaTable;

        }
    }
}
