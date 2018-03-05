using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress
{
    class FirmaHareketler
    {
        private int HareketId;

        public int FirmaHareketId
        {
            get { return HareketId; }
            set { HareketId = value; }
        }

        private string urunAd;

        public string UrunAdi
        {
            get { return urunAd; }
            set { urunAd = value; }
        }

        private int adet;

        public int UrunAdeti
        {
            get { return adet; }
            set { adet = value; }
        }

        private string personel;

        public string PersonelBilgi
        {
            get { return personel; }
            set { personel = value; }
        }

        private string firmaAd;

        public string FirmaBilgi
        {
            get { return firmaAd; }
            set { firmaAd = value; }
        }

        private decimal fiyat;

        public decimal FiyatBilgi
        {
            get { return fiyat; }
            set { fiyat = value; }
        }

        private decimal toplam;

        public decimal ToplamBilgi
        {
            get { return toplam; }
            set { toplam = value; }
        }

        private int fatura;

        public int FaturaId
        {
            get { return fatura; }
            set { fatura = value; }
        }

        private string tarih;

        public string TarihBilgi
        {
            get { return tarih; }
            set { tarih = value; }
        }

        private string Not;

        public string NotBilgi
        {
            get { return Not; }
            set { Not = value; }
        }

        public FirmaHareketler()
        {
            try
            {
                Veritabani veritabani = new Veritabani();
                SqlCommand sqlKomut = new SqlCommand("Execute FirmaHareketler", veritabani.BaglantiAc());
                SqlDataReader dataReader = sqlKomut.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        HareketId = int.Parse(dataReader["HAREKETID"].ToString());
                        UrunAdi = dataReader["URUNAD"].ToString();
                        UrunAdeti = int.Parse(dataReader["ADET"].ToString());
                        PersonelBilgi = dataReader["AD SOYAD"].ToString();
                        FirmaBilgi = dataReader["Firma"].ToString();
                        FiyatBilgi = int.Parse(dataReader["FIYAT"].ToString());
                        ToplamBilgi = int.Parse(dataReader["TOPLAM"].ToString());
                        TarihBilgi = dataReader["TARIH"].ToString();
                        NotBilgi = dataReader["NOTLAR"].ToString();
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
