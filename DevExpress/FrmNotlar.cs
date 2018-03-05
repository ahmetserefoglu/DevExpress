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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }

        Notlar notlar = new Notlar();

        NotlarVeritabani notlarVt = new NotlarVeritabani();

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            Listele();
        }

        public void Listele()
        {
            DataTable dataTable = notlarVt.Listele();

            gridControl1.DataSource = dataTable;
        }

        private void gridView1_FocusedRowChanged(object sender, XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                TxtId.Text = dr["ID"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                MskSaat.Text = dr["SAAT"].ToString();
                TxtBaslik.Text = dr["BASLIK"].ToString();
                RchDetay.Text = dr["DETAY"].ToString();
                TxtOlusturan.Text = dr["OLUSTURAN"].ToString();
                TxtHitap.Text = dr["HITAP"].ToString();
            }
        }

        public void Temizle()
        {
            TxtId.Text = "";
            MskTarih.Text = "";
            MskSaat.Text = "";
            TxtBaslik.Text = "";
            RchDetay.Text = "";
            TxtOlusturan.Text ="";
            TxtHitap.Text = "";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            notlar.NotTarihi = MskTarih.Text;
            notlar.NotSaati = MskSaat.Text;
            notlar.NotBaslik = TxtBaslik.Text;
            notlar.NotDetay = RchDetay.Text;
            notlar.NotHitap = TxtHitap.Text;
            notlar.NotOlusturan = TxtOlusturan.Text;

            if (notlarVt.EkleNot(notlar) == true)
            {
                LblBilgi.Text = "Veritabanina Ekleme Yapildi";

                Listele();

                Temizle();
            }
            else
            {
                LblBilgi.Text = "Veritabanina Ekleme Yapilmadi";
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (notlarVt.NotSil(TxtId.Text) == true)
            {
                LblBilgi.Text = "Veritabanindan Silme Yapildi";

                Listele();

                Temizle();
            }
            else
            {
                LblBilgi.Text = "Veritabanindan Silme Yapilmadi";
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            notlar.NotId = int.Parse(TxtId.Text);
            notlar.NotTarihi = MskTarih.Text;
            notlar.NotSaati = MskSaat.Text;
            notlar.NotBaslik = TxtBaslik.Text;
            notlar.NotDetay = RchDetay.Text;
            notlar.NotHitap = TxtHitap.Text;
            notlar.NotOlusturan = TxtOlusturan.Text;

            if (notlarVt.GuncelleNot(notlar) == true)
            {
                LblBilgi.Text = "Veritabanina Guncelleme Yapildi";

                Listele();

                Temizle();
            }
            else
            {
                LblBilgi.Text = "Veritabanina Guncelleme Yapilmadi";
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }


        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmNotDetay frmNotDetay = new FrmNotDetay();
            
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frmNotDetay.NotDetay = dr["DETAY"].ToString();
            }

            frmNotDetay.Show();
        }


    }
}
