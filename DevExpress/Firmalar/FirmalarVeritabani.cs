using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress
{
    public class FirmalarVeritabani
    {
        Veritabani veritabani = new Veritabani();

        /// <summary>
        /// Veritabanina Firma Ekleme İşlemi Yapan Metot
        /// </summary>
        /// <param name="firma">Firma Objesi</param>
        public bool FirmaEkle(Firmalar firma)
        {

            try
            {
                string sorgu = "INSERT INTO TBL_FIRMALAR (AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) VALUES(@Ad,@YetkiliStatu,@YetkiliAdS,@YetkiliTc,@Sektor,@Telefon1,@Telefon2,@Telefon3,@Mail,@Fax,@Il,@Ilce,@VergiDaire,@Adres,@OzlKd1,@OzlKd2,@OzlKd3)";

                SqlCommand sqlKomut = new SqlCommand(sorgu, veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@Ad", firma.FirmaAdi);
                sqlKomut.Parameters.AddWithValue("@YetkiliStatu", firma.YetkiliStatu);
                sqlKomut.Parameters.AddWithValue("@YetkiliAdS", firma.YetkiliAdSoyad);
                sqlKomut.Parameters.AddWithValue("@YetkiliTc", firma.YetkiliKimlikNo);
                sqlKomut.Parameters.AddWithValue("@Sektor", firma.FirmaSektor);
                sqlKomut.Parameters.AddWithValue("@Telefon1", firma.FirmaTelefon1);
                sqlKomut.Parameters.AddWithValue("@Telefon2", firma.FirmaTelefon2);
                sqlKomut.Parameters.AddWithValue("@Telefon3", firma.FirmaTelefon3);
                sqlKomut.Parameters.AddWithValue("@Mail", firma.MailAdresi);
                sqlKomut.Parameters.AddWithValue("@Fax", firma.MusteriFax);
                sqlKomut.Parameters.AddWithValue("@Il", firma.ILi);
                sqlKomut.Parameters.AddWithValue("@Ilce", firma.Ilce);
                sqlKomut.Parameters.AddWithValue("@VergiDaire", firma.VergiDairesi);
                sqlKomut.Parameters.AddWithValue("@Adres", firma.Adresi);
                sqlKomut.Parameters.AddWithValue("@OzlKd1", firma.OzelKod1);
                sqlKomut.Parameters.AddWithValue("@OzlKd2", firma.OzelKod2);
                sqlKomut.Parameters.AddWithValue("@OzlKd3", firma.OzelKod3);

                sqlKomut.ExecuteNonQuery();

                veritabani.BaglantiAc().Close();

                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
                return false;
            }

        }

        /// <summary>
        /// Datatable sorguyu çekip Datatable listesine doldurmak
        /// </summary>
        /// <param name="tabloIsmi">sorguda kullanılacak olan tablo ismi</param>
        /// <returns>Datatable bağlantısı</returns>
        public DataTable Listele()
        {
            DataTable dataTable = new DataTable();

            string sorgu = String.Format("SELECT * FROM TBL_FIRMALAR");

            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, veritabani.BaglantiAc());

            sqlData.Fill(dataTable);

            return dataTable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> IllerOku()
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("Select * FROM TBL_ILLER", veritabani.BaglantiAc());
                SqlDataReader sqlRead = sqlKomut.ExecuteReader();
                List<string> iller = new List<string>();
                if (sqlRead.HasRows)
                {
                    while (sqlRead.Read())
                    {
                        iller.Add(sqlRead["SEHIR"].ToString());
                    }
                }

                return iller;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;                
            }
        }
        /// <summary>
        /// Urunleri veritabnaindan silen metot
        /// </summary>
        /// <param name="id">ürün idsi</param>
        /// <returns></returns>
        public bool FirmaSil(int ID)
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("DELETE FROM TBL_FIRMALAR WHERE ID=@ID", veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@ID", ID);
                sqlKomut.ExecuteNonQuery();

                veritabani.BaglantiAc().Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        /// <summary>
        /// Urunleri Veritabanindan Güncelle
        /// </summary>
        /// <param name="firma"></param>
        /// <returns>return true or false</returns>
        public bool FirmaGuncelle(Firmalar firma)
        {
            try
            {
                //SqlCommand sqlKomut = new SqlCommand("UPDATE TBL_FIRMALAR SET AD=@ad,SOYAD=@soyad,TELEFON=@telefon1,TELEFON2=@telefon2,TC=@tc,MAIL=@mail,IL=@il,ILCE=@ilce,ADRES=@adres,VERGIDAIRE=@vergidairesi WHERE ID=@id", veritabani.BaglantiAc());
                string sorgu = "UPDATE TBL_FIRMALAR SET AD=@Ad,YETKILISTATU=@YetkiliStatu,YETKILIADSOYAD=@YetkiliAds,YETKILITC=@YetkiliTc,SEKTOR=@Sektor,TELEFON1=@Telefon1,TELEFON2=@Telefon2,TELEFON3=@Telefon3,"
                + "MAIL=@Mail,FAX=@Fax,IL=@Il,ILCE=@Ilce,VERGIDAIRE=@VergiDaire,ADRES=@Adres,OZELKOD1=@OzlKd1,OZELKOD2=@OzlKd2,OZELKOD3=@OzlKd3 WHERE ID=@Id";
                SqlCommand sqlKomut = new SqlCommand(sorgu, veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@Ad", firma.FirmaAdi);
                sqlKomut.Parameters.AddWithValue("@YetkiliStatu", firma.YetkiliStatu);
                sqlKomut.Parameters.AddWithValue("@YetkiliAds", firma.YetkiliAdSoyad);
                sqlKomut.Parameters.AddWithValue("@YetkiliTc", firma.YetkiliKimlikNo);
                sqlKomut.Parameters.AddWithValue("@Sektor", firma.FirmaSektor);
                sqlKomut.Parameters.AddWithValue("@Telefon1", firma.FirmaTelefon1);
                sqlKomut.Parameters.AddWithValue("@Telefon2", firma.FirmaTelefon2);
                sqlKomut.Parameters.AddWithValue("@Telefon3", firma.FirmaTelefon3);
                sqlKomut.Parameters.AddWithValue("@Mail", firma.MailAdresi);
                sqlKomut.Parameters.AddWithValue("@Fax", firma.MusteriFax);
                sqlKomut.Parameters.AddWithValue("@Il", firma.ILi);
                sqlKomut.Parameters.AddWithValue("@Ilce", firma.Ilce);
                sqlKomut.Parameters.AddWithValue("@VergiDaire", firma.VergiDairesi);
                sqlKomut.Parameters.AddWithValue("@Adres", firma.Adresi);
                sqlKomut.Parameters.AddWithValue("@OzlKd1", firma.OzelKod1);
                sqlKomut.Parameters.AddWithValue("@OzlKd2", firma.OzelKod2);
                sqlKomut.Parameters.AddWithValue("@OzlKd3", firma.OzelKod3);
                sqlKomut.Parameters.AddWithValue("@Id", firma.FirmaID);

                sqlKomut.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void OzelKodlarListele()
        {
            SqlCommand sqlKomut = new SqlCommand("SELECT * FROM TBL_KODLAR", veritabani.BaglantiAc());
            SqlDataReader dataReader = sqlKomut.ExecuteReader();
            while (dataReader.Read())
            {
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable FirmalarRehber()
        {
            DataTable dataTable = new DataTable();

            string sorgu = String.Format("SELECT AD,YETKILIADSOYAD,SEKTOR,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX FROM TBL_FIRMALAR");

            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, veritabani.BaglantiAc());

            sqlData.Fill(dataTable);

            return dataTable;
        }

        public string FirmaAdi(int id)
        {
            string firmaAdi = "";

            SqlCommand sqlKomut = new SqlCommand("SELECT AD FROM TBL_FIRMALAR WHERE ID=@FirmaID", veritabani.BaglantiAc());
            sqlKomut.Parameters.AddWithValue("@FirmaID", id);
            SqlDataReader dataReader = sqlKomut.ExecuteReader();
            while (dataReader.Read())
            {
                firmaAdi = dataReader["AD"].ToString();
            }

            return firmaAdi;
        }

        public int FirmaID(string firmaAdi)
        {
            //int firmaId=0;
            int asd=0;
            SqlCommand sqlKomut = new SqlCommand("SELECT ID FROM TBL_FIRMALAR WHERE AD=@FirmaAdi", veritabani.BaglantiAc());
            sqlKomut.Parameters.AddWithValue("@FirmaAdi", firmaAdi);
            SqlDataReader dataReader = sqlKomut.ExecuteReader();
            while (dataReader.Read())
            {
                asd = int.Parse(dataReader["ID"].ToString());
            }
            

            return asd;
            //return firmaId;
        }
    }
}
