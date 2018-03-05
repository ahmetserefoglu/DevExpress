using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DevExpress
{
    public class Musteriler
    {
        private int ID;

        public int MusteriID
        {
            get { return ID; }
            set { ID = value; }
        }

        private string AD;

        public string MusteriAdi
        {
            get { return AD; }
            set { AD = value; }
        }

        private string SOYAD;

        public string MusteriSoyadi
        {
            get { return SOYAD; }
            set { SOYAD = value; }
        }

        private string TELEFON1;

        public string MusteriTelefon1
        {
            get { return TELEFON1; }
            set { TELEFON1 = value; }
        }

        private string TELEFON2;

        public string MusteriTelefon2
        {
            get { return TELEFON2; }
            set { TELEFON2 = value; }
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

        private string VERGIDAIRE;

        public string VergiDairesi
        {
            get { return VERGIDAIRE; }
            set { VERGIDAIRE = value; }
        }

        public Musteriler()
        {
            try
            {
                Veritabani veritabani = new Veritabani();
                SqlCommand sqlKomut = new SqlCommand("SELECT * FROM TBL_MUSTERILER", veritabani.BaglantiAc());
                SqlDataReader dataReader = sqlKomut.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        MusteriID = int.Parse(dataReader["ID"].ToString());
                        MusteriAdi = dataReader["AD"].ToString();
                        MusteriSoyadi = dataReader["SOYAD"].ToString();
                        MusteriTelefon1 = dataReader["TELEFON"].ToString();
                        MusteriTelefon2 = dataReader["TELEFON2"].ToString();
                        KimlikNumarasi = dataReader["TC"].ToString();
                        MailAdresi = dataReader["MAIL"].ToString();
                        ILi = dataReader["IL"].ToString();
                        Ilce = dataReader["ILCE"].ToString();
                        Adresi = dataReader["ADRES"].ToString();
                        VergiDairesi = dataReader["VERGIDAIRE"].ToString();

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
