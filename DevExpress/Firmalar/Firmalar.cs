using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress
{
    public class Firmalar
    {
        private int ID;

        public int FirmaID
        {
            get { return ID; }
            set { ID = value; }
        }

        private string AD;

        public string FirmaAdi
        {
            get { return AD; }
            set { AD = value; }
        }

        private string YetkiliS;

        public string YetkiliStatu
        {
            get { return YetkiliS; }
            set { YetkiliS = value; }
        }

        private string YetkiliAdS;

        public string YetkiliAdSoyad
        {
            get { return YetkiliAdS; }
            set { YetkiliAdS = value; }
        }

        private string TELEFON1;

        public string FirmaTelefon1
        {
            get { return TELEFON1; }
            set { TELEFON1 = value; }
        }

        private string TELEFON2;

        public string FirmaTelefon2
        {
            get { return TELEFON2; }
            set { TELEFON2 = value; }
        }

        private string TELEFON3;

        public string FirmaTelefon3
        {
            get { return TELEFON3; }
            set { TELEFON3 = value; }
        }

        private string MAIL;

        public string MailAdresi
        {
            get { return MAIL; }
            set { MAIL = value; }
        }

        private string Fax;

        public string MusteriFax
        {
            get { return Fax; }
            set { Fax = value; }
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

        private string VERGIDAIRE;

        public string VergiDairesi
        {
            get { return VERGIDAIRE; }
            set { VERGIDAIRE = value; }
        }

        private string ADRES;

        public string Adresi
        {
            get { return ADRES; }
            set { ADRES = value; }
        }

        private string YetkiliTC;

        public string YetkiliKimlikNo
        {
            get { return YetkiliTC; }
            set { YetkiliTC = value; }
        }

        private string OzelKd1;

        public string OzelKod1
        {
            get { return OzelKd1; }
            set { OzelKd1 = value; }
        }

        private string OzelKd2;

        public string OzelKod2
        {
            get { return OzelKd2; }
            set { OzelKd2 = value; }
        }

        private string OzelKd3;

        public string OzelKod3
        {
            get { return OzelKd3; }
            set { OzelKd3 = value; }
        }

        private string SEKTOR;

        public string FirmaSektor
        {
            get { return SEKTOR; }
            set { SEKTOR = value; }
        }

        public Firmalar()
        {
            try
            {
                Veritabani veritabani = new Veritabani();
                SqlCommand sqlKomut = new SqlCommand("SELECT * FROM TBL_FIRMALAR", veritabani.BaglantiAc());
                SqlDataReader dataReader = sqlKomut.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        FirmaID = int.Parse(dataReader["ID"].ToString());
                        FirmaAdi = dataReader["AD"].ToString();
                        YetkiliStatu = dataReader["YETKILISTATU"].ToString();
                        YetkiliAdSoyad = dataReader["YETKILIADSOYAD"].ToString();
                        YetkiliKimlikNo = dataReader["YETKILITC"].ToString();
                        FirmaSektor = dataReader["SEKTOR"].ToString();
                        FirmaTelefon1 = dataReader["TELEFON1"].ToString();
                        FirmaTelefon2 = dataReader["TELEFON2"].ToString();
                        FirmaTelefon3 = dataReader["TELEFON3"].ToString();
                        MailAdresi = dataReader["MAIL"].ToString();
                        MusteriFax = dataReader["FAX"].ToString();
                        ILi = dataReader["IL"].ToString();
                        Ilce = dataReader["ILCE"].ToString();
                        VergiDairesi = dataReader["VERGIDAIRE"].ToString();
                        Adresi = dataReader["ADRES"].ToString();
                        OzelKod1 = dataReader["OZELKOD1"].ToString();
                        OzelKod2 = dataReader["OZELKOD2"].ToString();
                        OzelKod3 = dataReader["OZELKOD3"].ToString();
                        

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
