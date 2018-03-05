using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress
{
    public class Personel
    {
        private int ID;

        public int PersonelID
        {
            get { return ID; }
            set { ID = value; }
        }

        private string AD;

        public string PersonelAdi
        {
            get { return AD; }
            set { AD = value; }
        }

        private string SOYAD;

        public string PersonelSoyadi
        {
            get { return SOYAD; }
            set { SOYAD = value; }
        }

        private string TELEFON1;

        public string PersonelTelefon
        {
            get { return TELEFON1; }
            set { TELEFON1 = value; }
        }

        private string TC;

        public string KimlikNumarasi
        {
            get { return TC; }
            set { TC = value; }
        }

        private string MAIL;

        public string MailAdresi
        {
            get { return MAIL; }
            set { MAIL = value; }
        }

        private string IL;

        public string ILi
        {
            get { return IL; }
            set { IL = value; }
        }

        private string ILCE;

        public string Ilce
        {
            get { return ILCE; }
            set { ILCE = value; }
        }

        private string ADRES;

        public string Adresi
        {
            get { return ADRES; }
            set { ADRES = value; }
        }

        private string GOREV;

        public string Gorevi
        {
            get { return GOREV; }
            set { GOREV = value; }
        }


        public Personel()
        {
            try
            {
                Veritabani veritabani = new Veritabani();
                SqlCommand sqlKomut = new SqlCommand("SELECT * FROM TBL_PERSONELLER", veritabani.BaglantiAc());
                SqlDataReader dataReader = sqlKomut.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        PersonelID = int.Parse(dataReader["ID"].ToString());
                        PersonelAdi = dataReader["AD"].ToString();
                        PersonelSoyadi = dataReader["SOYAD"].ToString();
                        PersonelTelefon = dataReader["TELEFON"].ToString();
                        KimlikNumarasi = dataReader["TC"].ToString();
                        MailAdresi = dataReader["MAIL"].ToString();
                        ILi = dataReader["IL"].ToString();
                        Ilce = dataReader["ILCE"].ToString();
                        Adresi = dataReader["ADRES"].ToString();
                        Gorevi = dataReader["GOREV"].ToString();

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
