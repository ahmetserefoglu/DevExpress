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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }

        Firmalar firma = new Firmalar();
        FirmalarVeritabani firmaVt = new FirmalarVeritabani();

        private void FrmFirmalar_Load(object sender, EventArgs e)
        {

            Listele();

            IllerOku();

            OzelKodlarListele();
        }

        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {
            firma.FirmaAdi = TxtAd.Text;
            firma.YetkiliStatu = TxtStatu.Text;
            firma.YetkiliAdSoyad = TxtYetkiliAdS.Text;
            firma.FirmaTelefon1 = MskTlfn1.Text;
            firma.FirmaTelefon2 = MskTlfn2.Text;
            firma.FirmaTelefon3 = MskTlfn3.Text;
            firma.MailAdresi = TxtMail.Text;
            firma.MusteriFax = MskFax.Text;
            firma.ILi = CmbIl.Text;
            firma.Ilce = CmbIlce.Text;
            firma.VergiDairesi = TxtVergiDaire.Text;
            firma.Adresi = RchAdres.Text;
            firma.YetkiliKimlikNo = MskTc.Text;
            firma.FirmaSektor = TxtSektor.Text;
            firma.OzelKod1 = TxtOzelKod1.Text;
            firma.OzelKod2 = TxtOzelKod2.Text;
            firma.OzelKod3 = TxtOzelKod3.Text;

            if (firmaVt.FirmaEkle(firma) == true)
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

        private void BtnSil_Click_1(object sender, EventArgs e)
        {
            if (firmaVt.FirmaSil(int.Parse(TxtId.Text)) == true)
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

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            firma.FirmaID = int.Parse(TxtId.Text);
            firma.FirmaAdi = TxtAd.Text;
            firma.YetkiliStatu = TxtStatu.Text;
            firma.YetkiliAdSoyad = TxtYetkiliAdS.Text;
            firma.FirmaTelefon1 = MskTlfn1.Text;
            firma.FirmaTelefon2 = MskTlfn2.Text;
            firma.FirmaTelefon3 = MskTlfn3.Text;
            firma.MailAdresi = TxtMail.Text;
            firma.MusteriFax = MskFax.Text;
            firma.ILi = CmbIl.Text;
            firma.Ilce = CmbIlce.Text;
            firma.VergiDairesi = TxtVergiDaire.Text;
            firma.Adresi = RchAdres.Text;
            firma.YetkiliKimlikNo = MskTc.Text;
            firma.FirmaSektor = TxtSektor.Text;
            firma.OzelKod1 = TxtOzelKod1.Text;
            firma.OzelKod2 = TxtOzelKod2.Text;
            firma.OzelKod3 = TxtOzelKod3.Text;

            if (firmaVt.FirmaGuncelle(firma) == true)
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

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbIlce.Properties.Items.Clear();
            CmbIlce.Text = "";
            IlcelerOku();
        }

        private void gridView1_FocusedRowChanged(object sender, XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                TxtId.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString();
                TxtStatu.Text = dr["YETKILISTATU"].ToString();
                TxtYetkiliAdS.Text = dr["YETKILIADSOYAD"].ToString();
                MskTlfn1.Text = dr["TELEFON1"].ToString();
                MskTlfn2.Text = dr["TELEFON2"].ToString();
                MskTlfn3.Text = dr["TELEFON3"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                MskFax.Text = dr["FAX"].ToString();
                CmbIl.Text = dr["IL"].ToString();
                CmbIlce.Text = dr["ILCE"].ToString();
                TxtVergiDaire.Text = dr["VERGIDAIRE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                MskTc.Text = dr["YETKILITC"].ToString();
                TxtSektor.Text = dr["SEKTOR"].ToString();
                TxtOzelKod1.Text = dr["OZELKOD1"].ToString();
                TxtOzelKod2.Text = dr["OZELKOD2"].ToString();
                TxtOzelKod3.Text = dr["OZELKOD3"].ToString();
            }
        }

        public void Temizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtMail.Text = "";
            TxtOzelKod1.Text = "";
            TxtOzelKod2.Text = "";
            TxtOzelKod3.Text = "";
            TxtSektor.Text = "";
            TxtStatu.Text = "";
            TxtVergiDaire.Text = "";
            TxtYetkiliAdS.Text = "";
            MskFax.Text = "";
            MskTc.Text = "";
            MskTlfn1.Text = "";
            MskTlfn2.Text = "";
            MskTlfn3.Text = "";
            CmbIl.Text = "";
            CmbIlce.Text = "";
            RchAdres.Text = "";
            RchOzelKod1.Text = "";
            RchOzelKod2.Text = "";
            RchOzelKod3.Text = "";
            TxtAd.Focus();
        }

        public void OzelKodlarListele()
        {
            Veritabani veritabani = new Veritabani();
            SqlCommand sqlKomut = new SqlCommand("SELECT * FROM TBL_KODLAR", veritabani.BaglantiAc());
            SqlDataReader dataReader = sqlKomut.ExecuteReader();
            while (dataReader.Read())
            {
                RchOzelKod1.Text = dataReader[0].ToString();
                RchOzelKod2.Text = dataReader[1].ToString();
                RchOzelKod3.Text = dataReader[2].ToString();
            }
        }

        public void Listele()
        {
            DataTable dtaTable = firmaVt.Listele();

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
