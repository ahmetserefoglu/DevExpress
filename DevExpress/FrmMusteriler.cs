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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        MusterilerVeritabani musterilerVt = new MusterilerVeritabani();

        Musteriler musteriler = new Musteriler();

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            Listele();

            IllerOku();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            musteriler.MusteriAdi= TxtAd.Text;
            musteriler.MusteriSoyadi = TxtSoyad.Text;
            musteriler.MusteriTelefon1 = MskTlfn1.Text;
            musteriler.MusteriTelefon2 = MskTlfn2.Text;
            musteriler.KimlikNumarasi = MskTc.Text;
            musteriler.MailAdresi = TxtMail.Text;
            musteriler.ILi = CmbIl.SelectedText;
            musteriler.Ilce = CmbIlce.SelectedText;
            musteriler.Adresi = RchAdres.Text;
            musteriler.VergiDairesi = TxtVergiDaire.Text;


            if (musterilerVt.MusteriEkle(musteriler) == true)
            {
                LblBilgi.Text = String.Format("Ekleme İşlemi Başarıyla Kaydedildi");

                Listele();
            }
            else
            {
                LblBilgi.Text = "Ekleme İşleminde bir sorun oluştu";
            }

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (musterilerVt.MusteriSil(int.Parse(TxtId.Text)) == true)
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
            musteriler.MusteriID = int.Parse(TxtId.Text);
            musteriler.MusteriAdi = TxtAd.Text;
            musteriler.MusteriSoyadi = TxtSoyad.Text;
            musteriler.MusteriTelefon1 = MskTlfn1.Text;
            musteriler.MusteriTelefon2 = MskTlfn2.Text;
            musteriler.KimlikNumarasi = MskTc.Text;
            musteriler.MailAdresi = TxtMail.Text;
            musteriler.ILi = CmbIl.SelectedText;
            musteriler.Ilce = CmbIlce.SelectedText;
            musteriler.Adresi = RchAdres.Text;
            musteriler.VergiDairesi = TxtVergiDaire.Text;

            if (musterilerVt.MusteriGuncelle(musteriler) == true)
            {
                LblBilgi.Text = "Musteri Başarıyla Güncellendi";
                //MessageBox.Show("Müşteri Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();

                //Temizle();
            }
            else
            {
                LblBilgi.Text = "Musteri Güncellenemedi";
            }
        }

        private void gridView1_FocusedRowChanged(object sender, XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if(dr!=null)
            {
                TxtId.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString();
                TxtSoyad.Text = dr["SOYAD"].ToString();
                MskTlfn1.Text = dr["TELEFON"].ToString();
                MskTlfn2.Text = dr["TELEFON2"].ToString();
                MskTc.Text = dr["TC"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                CmbIl.Text = dr["IL"].ToString();
                CmbIlce.Text = dr["ILCE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                TxtVergiDaire.Text = dr["VERGIDAIRE"].ToString();
            }
            

        }

        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbIlce.Properties.Items.Clear();
            CmbIlce.Text = "";
            IlcelerOku();
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
            TxtVergiDaire.Text = "";
            MskTlfn1.Text = "";
            MskTlfn2.Text = "";
            MskTc.Text = "";
            TxtSoyad.Text = "";
            TxtMail.Text = "";
            CmbIl.Text = "";
            CmbIlce.Text = "";
            RchAdres.Text = "";
        }

        public void Listele()
        {
            DataTable dtaTable = musterilerVt.Listele();

            gridControl1.DataSource = dtaTable;
        }

        public void IllerOku()
        {
            try
            {
                Veritabani veritabani = new Veritabani();
                SqlCommand sqlKomut = new SqlCommand("Select SEHIR FROM TBL_ILLER", veritabani.BaglantiAc());
                SqlDataReader sqlRead = sqlKomut.ExecuteReader();

                if (sqlRead.HasRows)
                {
                    while (sqlRead.Read())
                    {
                        CmbIl.Properties.Items.Add(sqlRead[0]);
                    }
                    veritabani.BaglantiAc().Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void IlcelerOku()
        {
            try
            {
                Veritabani veritabani = new Veritabani();
                SqlCommand sqlKomut = new SqlCommand("Select ILCE FROM TBL_ILCELER WHERE SEHIR=@sehir", veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@sehir", CmbIl.SelectedIndex + 1);
                SqlDataReader sqlRead = sqlKomut.ExecuteReader();

                if (sqlRead.HasRows)
                {
                    while (sqlRead.Read())
                    {
                        CmbIlce.Properties.Items.Add(sqlRead[0]);
                    }
                    veritabani.BaglantiAc().Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
