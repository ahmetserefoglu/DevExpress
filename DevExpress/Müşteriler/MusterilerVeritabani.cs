using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DevExpress
{
    public class MusterilerVeritabani
    {
        Veritabani veritabani = new Veritabani();

        /// <summary>
        /// Veritabanina Musteri Ekleme İşlemi Yapan Metot
        /// </summary>
        /// <param name="musteri">Musteri Objesi</param>
        public bool MusteriEkle(Musteriler musteri)
        {

            try
            {
                string sorgu = "INSERT INTO TBL_MUSTERILER(AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) VALUES(@Ad,@Soyad,@Telefon,@Telefon2,@Tc,@Mail,@Il,@Ilce,@Adres,@VergiDaire)";

                SqlCommand sqlKomut = new SqlCommand(sorgu, veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@Ad", musteri.MusteriAdi);
                sqlKomut.Parameters.AddWithValue("@Soyad", musteri.MusteriSoyadi );
                sqlKomut.Parameters.AddWithValue("@Telefon",musteri.MusteriTelefon1 );
                sqlKomut.Parameters.AddWithValue("@Telefon2", musteri.MusteriTelefon2);
                sqlKomut.Parameters.AddWithValue("@Tc", musteri.KimlikNumarasi);
                sqlKomut.Parameters.AddWithValue("@Mail", musteri.MailAdresi);
                sqlKomut.Parameters.AddWithValue("@Il", musteri.ILi);
                sqlKomut.Parameters.AddWithValue("@Ilce", musteri.Ilce);
                sqlKomut.Parameters.AddWithValue("@Adres", musteri.Adresi);
                sqlKomut.Parameters.AddWithValue("@VergiDaire", musteri.VergiDairesi);

                sqlKomut.ExecuteNonQuery();

                veritabani.BaglantiAc().Close();

                return true;
            }
            catch (Exception)
            {

                throw;
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

            string sorgu = String.Format("SELECT * FROM TBL_MUSTERILER");

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
        public bool MusteriSil(int id)
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("DELETE FROM TBL_MUSTERILER WHERE ID=@ID", veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@ID", id);
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
        /// <param name="urun"></param>
        /// <returns></returns>
        public bool MusteriGuncelle(Musteriler musteri)
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("UPDATE TBL_MUSTERILER SET AD=@ad,SOYAD=@soyad,TELEFON=@telefon1,TELEFON2=@telefon2,TC=@tc,MAIL=@mail,IL=@il,ILCE=@ilce,ADRES=@adres,VERGIDAIRE=@vergidairesi WHERE ID=@id", veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@ad", musteri.MusteriAdi);
                sqlKomut.Parameters.AddWithValue("@soyad", musteri.MusteriSoyadi);
                sqlKomut.Parameters.AddWithValue("@telefon1", musteri.MusteriTelefon1);
                sqlKomut.Parameters.AddWithValue("@telefon2", musteri.MusteriTelefon2);
                sqlKomut.Parameters.AddWithValue("@tc", musteri.KimlikNumarasi);
                sqlKomut.Parameters.AddWithValue("@mail", musteri.MailAdresi);
                sqlKomut.Parameters.AddWithValue("@il", musteri.ILi);
                sqlKomut.Parameters.AddWithValue("@ilce", musteri.Ilce);
                sqlKomut.Parameters.AddWithValue("@adres", musteri.Adresi);
                sqlKomut.Parameters.AddWithValue("@vergidairesi", musteri.VergiDairesi);
                sqlKomut.Parameters.AddWithValue("@id", musteri.MusteriID);

                sqlKomut.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public DataTable MusterilerRehber()
        {
            DataTable dataTable = new DataTable();

            string sorgu = String.Format("SELECT AD,SOYAD,TELEFON,TELEFON2,MAIL FROM TBL_MUSTERILER");

            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, veritabani.BaglantiAc());

            sqlData.Fill(dataTable);

            return dataTable;
        }
    }
}
