using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress
{
    class Notlar
    {
        private int id;

        public int NotId
        {
            get { return id; }
            set { id = value; }
        }

        private string tarih;

        public string NotTarihi
        {
            get { return tarih; }
            set { tarih = value; }
        }

        private string saat;

        public string NotSaati
        {
            get { return saat; }
            set { saat = value; }
        }

        private string baslik;

        public string NotBaslik
        {
            get { return baslik; }
            set { baslik = value; }
        }

        private string detay;

        public string NotDetay
        {
            get { return detay; }
            set { detay = value; }
        }

        private string olusturan;

        public string NotOlusturan
        {
            get { return olusturan; }
            set { olusturan = value; }
        }

        private string hitap;

        public string NotHitap
        {
            get { return hitap; }
            set { hitap = value; }
        }

        public Notlar()
        {
            Veritabani veritabani = new Veritabani();
            SqlCommand sqlKomut = new SqlCommand("SELECT * FROM TBL_NOTLAR", veritabani.BaglantiAc());
            SqlDataReader dataReader = sqlKomut.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    NotId = int.Parse(dataReader["ID"].ToString());
                    NotTarihi = dataReader["TARIH"].ToString();
                    NotSaati = dataReader["SAAT"].ToString();
                    NotBaslik = dataReader["BASLIK"].ToString();
                    NotDetay = dataReader["DETAY"].ToString();
                    NotOlusturan = dataReader["OLUSTURAN"].ToString();
                    NotHitap = dataReader["HITAP"].ToString();
                }
            }
        }
    }
}
