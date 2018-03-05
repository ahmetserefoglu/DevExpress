using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress
{
    public class Bankalar
    {
        private int ID;

        public int BankaID
        {
            get { return ID; }
            set { ID = value; }
        }

        private string BankaAd;

        public string BankaAdi
        {
            get { return BankaAd; }
            set { BankaAd = value; }
        }

        private string Ili;

        public string BankaIli
        {
            get { return Ili; }
            set { Ili = value; }
        }

        private string Ilce;

        public string BankaIlce
        {
            get { return Ilce; }
            set { Ilce = value; }
        }

        private string Sube;

        public string BankaSube
        {
            get { return Sube; }
            set { Sube = value; }
        }

        private string Iban;

        public string IbanNumarasi
        {
            get { return Iban; }
            set { Iban = value; }
        }

        private string HesapNo;

        public string HesapNumarasi
        {
            get { return HesapNo; }
            set { HesapNo = value; }
        }

        private string Yetkili;

        public string BankaYetkilisi
        {
            get { return Yetkili; }
            set { Yetkili = value; }
        }

        private string Telefon;

        public string BankaTelefon
        {
            get { return Telefon; }
            set { Telefon = value; }
        }

        private string Tarih;

        public string KayitTarihi
        {
            get { return Tarih; }
            set { Tarih = value; }
        }

        private string HesapTur;

        public string HesapTuru
        {
            get { return HesapTur; }
            set { HesapTur = value; }
        }

        private string frmAd;

        public string FirmaAdi
        {
            get { return frmAd; }
            set { frmAd = value; }
        }

        public Bankalar()
        {
            try
            {
                Veritabani veritabani = new Veritabani();
                SqlCommand sqlKomut = new SqlCommand("Execute BankaBilgileri", veritabani.BaglantiAc());
                SqlDataReader dataReader = sqlKomut.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        BankaID = int.Parse(dataReader["ID"].ToString());
                        BankaAdi = dataReader["BANKAADI"].ToString();
                        BankaIli = dataReader["IL"].ToString();
                        BankaIlce = dataReader["ILCE"].ToString();
                        BankaSube = dataReader["SUBE"].ToString();
                        IbanNumarasi = dataReader["IBAN"].ToString();
                        HesapNumarasi = dataReader["HESAPNO"].ToString();
                        BankaYetkilisi = dataReader["YETKILI"].ToString();
                        Telefon = dataReader["TELEFON"].ToString();
                        KayitTarihi = dataReader["TARIH"].ToString();
                        HesapTuru = dataReader["HESAPTURU"].ToString();
                        FirmaAdi = dataReader["AD"].ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
