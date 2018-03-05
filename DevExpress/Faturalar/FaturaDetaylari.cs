using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress
{
    public class FaturaDetaylari
    {
        private int FtrUrnId;

        public int FaturaUrunId
        {
            get { return FtrUrnId; }
            set { FtrUrnId = value; }
        }

        private string UrunAd;

        public string UrunAdi
        {
            get { return UrunAd; }
            set { UrunAd = value; }
        }

        private int miktar;

        public int Miktari
        {
            get { return miktar; }
            set { miktar = value; }
        }

        private decimal fiyat;

        public decimal Fiyati
        {
            get { return fiyat; }
            set { fiyat = value; }
        }

        private decimal tutar;

        public decimal Tutari
        {
            get { return tutar; }
            set { tutar = value; }
        }

        private int ftrId;

        public int FaturaID
        {
            get { return ftrId; }
            set { ftrId = value; }
        }

        public FaturaDetaylari()
        {
            try
            {
                Veritabani veritabani = new Veritabani();
                SqlCommand sqlKomut = new SqlCommand("SELECT * FROM TBL_FATURADETAYI", veritabani.BaglantiAc());
                SqlDataReader dataReader = sqlKomut.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        FaturaUrunId = int.Parse(dataReader["FATURAURUNID"].ToString());
                        UrunAdi = dataReader["URUNAD"].ToString();
                        Miktari = int.Parse(dataReader["MIKTAR"].ToString());
                        Fiyati = decimal.Parse(dataReader["FIYAT"].ToString());
                        Tutari = decimal.Parse(dataReader["TUTAR"].ToString());
                        FaturaUrunId = int.Parse(dataReader["FATURAID"].ToString());

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
