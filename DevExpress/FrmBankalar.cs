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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }

        BankalarVeritabani bankalarVt = new BankalarVeritabani();

        FirmalarVeritabani firmalarVt = new FirmalarVeritabani();
        
        Bankalar bankalar = new Bankalar();

        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            Listele();

            IllerOku();

            FirmalarOku();

            ///Temizle();
            
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //bankalar.BankaID=int.Parse(TxtId.Text);
            bankalar.BankaAdi = TxtBankaAd.Text;
            bankalar.BankaIli = CmbIl.Text;
            bankalar.BankaIlce = CmbIlce.Text;
            bankalar.BankaSube = TxtSube.Text;
            bankalar.IbanNumarasi = TxtIban.Text;
            bankalar.HesapNumarasi = TxtHesapNo.Text;
            bankalar.BankaYetkilisi = TxtYetkili.Text;
            bankalar.BankaTelefon = MskTelefon.Text;
            bankalar.KayitTarihi = MskTarih.Text;
            bankalar.HesapTuru = TxtHesapTuru.Text;
            bankalar.FirmaAdi =  LookFirma.EditValue.ToString();

            if (bankalarVt.BankaEkle(bankalar) == true)
            {
                LblBilgi.Text = "Veritabanina Ekleme İşlemi Yapildi";

                Listele();

                Temizle();
            }
            else
            {
                LblBilgi.Text = "Veritabanina Ekleme İşleminde Hata Oluştu";
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (bankalarVt.BankaSil(int.Parse(TxtId.Text)) == true)
            {
                LblBilgi.Text = "Veritabanindan Silme İşlemi Başarıyla Gerçekleşti";
                
                Listele();
                
                Temizle();
            }
            else
            {
                LblBilgi.Text = "Veritabanindan Silme İşleminde Hata Oluştu";
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            bankalar.BankaID = int.Parse(TxtId.Text);
            bankalar.BankaAdi = TxtBankaAd.Text;
            bankalar.BankaIli = CmbIl.Text;
            bankalar.BankaIlce = CmbIlce.Text;
            bankalar.BankaSube = TxtSube.Text;
            bankalar.IbanNumarasi = TxtIban.Text;
            bankalar.HesapNumarasi = TxtHesapNo.Text;
            bankalar.BankaYetkilisi = TxtYetkili.Text;
            bankalar.BankaTelefon = MskTelefon.Text;
            bankalar.KayitTarihi = MskTarih.Text;
            bankalar.HesapTuru = TxtHesapTuru.Text;
            bankalar.FirmaAdi = LookFirma.EditValue.ToString();

            if (bankalarVt.BankaGuncelle(bankalar) == true)
            {
                LblBilgi.Text = "Veritabaninda Güncelleme İşlemi Yapıldı";

                Listele();

                Temizle();
            }
            else
            {
                LblBilgi.Text = "Veritabaninda Güncelleme İşleminde Sorun Oluştu";
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
                TxtBankaAd.Text = dr["BANKAADI"].ToString();
                CmbIl.Text = dr["IL"].ToString();
                CmbIlce.Text = dr["ILCE"].ToString();
                TxtSube.Text = dr["SUBE"].ToString();
                TxtIban.Text = dr["IBAN"].ToString();
                TxtHesapNo.Text = dr["HESAPNO"].ToString();
                TxtYetkili.Text = dr["YETKILI"].ToString();
                MskTelefon.Text = dr["TELEFON"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                TxtHesapTuru.Text = dr["HESAPTURU"].ToString();
                LookFirma.Text = dr["AD"].ToString();
            }

        }

        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbIlce.Properties.Items.Clear();
            CmbIlce.Text = "";
            IlcelerOku();
        }

        /// <summary>
        /// Girilen Değerleri Ekleme ve Güncellemeden Sonra Temizle
        /// </summary>
        public void Temizle()
        {
            TxtId.Text = "";
            TxtBankaAd.Text = "";
            LookFirma.Text = "";
            TxtHesapNo.Text = "";
            TxtHesapTuru.Text = "";
            TxtIban.Text = "";
            TxtSube.Text = "";
            TxtYetkili.Text = "";
            MskTarih.Text = "";
            MskTelefon.Text = "";
            CmbIl.Text = "";
            CmbIlce.Text = "";
        }

        public void Listele()
        {
            DataTable dtaTable = bankalarVt.Listele();

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

        public void FirmalarOku()
        {
            try
            {
                Veritabani veritabani = new Veritabani();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT ID,AD FROM TBL_FIRMALAR", veritabani.BaglantiAc());
                da.Fill(dt);
                LookFirma.Properties.ValueMember = "ID";
                LookFirma.Properties.DisplayMember = "AD";
                LookFirma.Properties.DataSource = dt;
                veritabani.BaglantiAc().Close();
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
