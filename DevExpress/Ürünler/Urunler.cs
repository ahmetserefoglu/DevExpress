using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress
{
    public class Urunler
    {
        private int ID;

        public int ProductID
        {
            get { return ID; }
            set { ID = value; }
        }

        private string UrunAd;

        public string UrunAdi
        {
            get { return UrunAd; }
            set { UrunAd = value; }
        }

        private string Marka;

        public string MarkaAdi
        {
            get { return Marka; }
            set { Marka = value; }
        }

        private string Model;

        public string ModelAdi
        {
            get { return Model; }
            set { Model = value; }
        }

        private string Yil;

        public string Yili
        {
            get { return Yil; }
            set { Yil = value; }
        }

        private int Adet;

        public int AdetSayisi
        {
            get { return Adet; }
            set { Adet = value; }
        }

        private decimal AlisFiyat;

        public decimal AlisFiyati
        {
            get { return AlisFiyat; }
            set { AlisFiyat = value; }
        }

        private decimal SatisFiyat;

        public decimal SatisFiyati
        {
            get { return SatisFiyat; }
            set { SatisFiyat = value; }
        }

        private string Detay;

        public string Detaylandirma
        {
            get { return Detay; }
            set { Detay = value; }
        }

        public Urunler()
        {
            Veritabani veritabani = new Veritabani();
            SqlCommand sqlKomut = new SqlCommand("Select * FROM TBL_URUNLER", veritabani.BaglantiAc());
            SqlDataReader sqlRead = sqlKomut.ExecuteReader();
            //Urunler urunler = new Urunler();
            if (sqlRead.HasRows)
            {
                while (sqlRead.Read())
                {

                    ProductID = int.Parse(sqlRead["ID"].ToString());
                    UrunAdi = sqlRead["URUNAD"].ToString();
                    MarkaAdi = sqlRead["MARKA"].ToString();
                    ModelAdi = sqlRead["MODEL"].ToString();
                    Yili = sqlRead["YIL"].ToString();
                    AdetSayisi = int.Parse(sqlRead["ADET"].ToString());
                    AlisFiyati = decimal.Parse(sqlRead["ALISFIYAT"].ToString());
                    SatisFiyati = decimal.Parse(sqlRead["SATISFIYAT"].ToString());
                    Detaylandirma = sqlRead["DETAY"].ToString();
                }
            }
        }

        public Urunler(int Id)
        {
            Veritabani veritabani = new Veritabani();
            SqlCommand sqlKomut = new SqlCommand("Select * FROM TBL_URUNLER WHERE ID=@ID", veritabani.BaglantiAc());
            sqlKomut.Parameters.AddWithValue("@ID", Id);
            SqlDataReader sqlRead = sqlKomut.ExecuteReader();
            //Urunler urunler = new Urunler();
            if (sqlRead.HasRows)
            {
                while (sqlRead.Read())
                {

                    ProductID = int.Parse(sqlRead["ID"].ToString());
                    UrunAdi = sqlRead["URUNAD"].ToString();
                    MarkaAdi = sqlRead["MARKA"].ToString();
                    ModelAdi = sqlRead["MODEL"].ToString();
                    Yili = sqlRead["YIL"].ToString();
                    AdetSayisi = int.Parse(sqlRead["ADET"].ToString());
                    AlisFiyati = decimal.Parse(sqlRead["ALISFIYAT"].ToString());
                    SatisFiyati = decimal.Parse(sqlRead["SATISFIYAT"].ToString());
                    Detaylandirma = sqlRead["DETAY"].ToString();
                }
            }
        }
    }
}
