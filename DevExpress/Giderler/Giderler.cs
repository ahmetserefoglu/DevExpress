using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress
{
    public class Giderler
    {
        private int ID;

        public int GiderID
        {
            get { return ID; }
            set { ID = value; }
        }

        private decimal Elktrik;

        public decimal GiderElektrik
        {
            get { return Elktrik; }
            set { Elktrik = value; }
        }

        private decimal Su;

        public decimal GiderSu
        {
            get { return Su; }
            set { Su = value; }
        }

        private decimal DogalGaz;

        public decimal GiderDogalGaz
        {
            get { return DogalGaz; }
            set { DogalGaz = value; }
        }

        private decimal Internet;

        public decimal GiderInternet
        {
            get { return Internet; }
            set { Internet = value; }
        }

        private decimal Maas;

        public decimal GiderMaas
        {
            get { return Maas; }
            set { Maas = value; }
        }

        private decimal Ekstralar;

        public decimal GiderEkstra
        {
            get { return Ekstralar; }
            set { Ekstralar = value; }
        }

        private string Not;

        public string NotBilgisi
        {
            get { return Not; }
            set { Not = value; }
        }

        private string Ay;

        public string AyBilgisi
        {
            get { return Ay; }
            set { Ay = value; }
        }

        private string Yil;

        public string YilBilgisi
        {
            get { return Yil; }
            set { Yil = value; }
        }


        public Giderler()
        {
            try
            {
                Veritabani veritabani = new Veritabani();
                SqlCommand sqlKomut = new SqlCommand("SELECT * FROM TBL_GIDERLER", veritabani.BaglantiAc());
                SqlDataReader dataReader = sqlKomut.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        GiderID = int.Parse(dataReader["ID"].ToString());
                        GiderElektrik = decimal.Parse(dataReader["ELEKTRIK"].ToString());
                        GiderSu = decimal.Parse(dataReader["SU"].ToString());
                        GiderDogalGaz = decimal.Parse(dataReader["DOGALGAZ"].ToString());
                        GiderInternet = decimal.Parse(dataReader["INTERNET"].ToString());
                        GiderMaas = decimal.Parse(dataReader["MAASLAR"].ToString());
                        GiderEkstra = decimal.Parse(dataReader["EKSTRA"].ToString());
                        NotBilgisi = dataReader["NOTLAR"].ToString();
                        AyBilgisi = dataReader["AY"].ToString();
                        YilBilgisi = dataReader["YIL"].ToString();

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
    }
}
