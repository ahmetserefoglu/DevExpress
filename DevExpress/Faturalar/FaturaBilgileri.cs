using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress
{
    public class FaturaBilgileri
    {
        private int ftrBlgId;

        public int FaturaBilgiId
        {
            get { return ftrBlgId; }
            set { ftrBlgId = value; }
        }

        private string seri;

        public string SeriNo
        {
            get { return seri; }
            set { seri = value; }
        }

        private string sira;

        public string SiraNo
        {
            get { return sira; }
            set { sira = value; }
        }

        private string tarihi;

        public string Tarih
        {
            get { return tarihi; }
            set { tarihi = value; }
        }

        private string saati;

        public string Saat
        {
            get { return saati; }
            set { saati = value; }
        }

        private string vrgDaire;

        public string VergiDaire
        {
            get { return vrgDaire; }
            set { vrgDaire = value; }
        }

        private string alci;

        public string Alici
        {
            get { return alci; }
            set { alci = value; }
        }

        private string tslmEden;

        public string TeslimEden
        {
            get { return tslmEden; }
            set { tslmEden = value; }
        }

        private string tslmAlan;

        public string TeslimAlan
        {
            get { return tslmAlan; }
            set { tslmAlan = value; }
        }

        public FaturaBilgileri()
        {
            try
            {
                Veritabani veritabani = new Veritabani();
                SqlCommand sqlKomut = new SqlCommand("SELECT * FROM TBL_FATURABILGI", veritabani.BaglantiAc());
                SqlDataReader dataReader = sqlKomut.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        FaturaBilgiId = int.Parse(dataReader["FATURABILGIID"].ToString());
                        SeriNo = dataReader["SERI"].ToString();
                        SiraNo = dataReader["SIRANO"].ToString();
                        Tarih = dataReader["TARIH"].ToString();
                        Saat = dataReader["SAAT"].ToString();
                        VergiDaire = dataReader["VERGIDAIRE"].ToString();
                        Alici = dataReader["ALICI"].ToString();
                        TeslimEden = dataReader["TESLIMEDEN"].ToString();
                        TeslimAlan = dataReader["TESLIMALAN"].ToString();
                        
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
