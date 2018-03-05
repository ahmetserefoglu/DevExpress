using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress
{
    class PersonelVeritabani
    {
        Veritabani veritabani = new Veritabani();

        /// <summary>
        /// Veritabanina PErsonel Ekleme İşlemi Yapan Metot
        /// </summary>
        /// <param name="personel">Musteri Objesi</param>
        public bool PersonelEkle(Personel personel)
        {

            try
            {
                string sorgu = "INSERT INTO TBL_PERSONELLER(AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) VALUES(@Ad,@Soyad,@Telefon,@Tc,@Mail,@Il,@Ilce,@Adres,@Gorev)";

                SqlCommand sqlKomut = new SqlCommand(sorgu, veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@Ad", personel.PersonelAdi);
                sqlKomut.Parameters.AddWithValue("@Soyad", personel.PersonelSoyadi);
                sqlKomut.Parameters.AddWithValue("@Telefon", personel.PersonelTelefon);
                sqlKomut.Parameters.AddWithValue("@Tc", personel.KimlikNumarasi);
                sqlKomut.Parameters.AddWithValue("@Mail", personel.MailAdresi);
                sqlKomut.Parameters.AddWithValue("@Il", personel.ILi);
                sqlKomut.Parameters.AddWithValue("@Ilce", personel.Ilce);
                sqlKomut.Parameters.AddWithValue("@Adres", personel.Adresi);
                sqlKomut.Parameters.AddWithValue("@Gorev", personel.Gorevi);

                sqlKomut.ExecuteNonQuery();

                veritabani.BaglantiAc().Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
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

            string sorgu = String.Format("SELECT * FROM TBL_PERSONELLER");

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
        public bool PersonelSil(int id)
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("DELETE FROM TBL_PERSONELLER WHERE ID=@ID", veritabani.BaglantiAc());
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
        public bool PersonelGuncelle(Personel personel)
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("UPDATE TBL_PERSONELLER SET AD=@ad,SOYAD=@soyad,TELEFON=@telefon,TC=@tc,MAIL=@mail,IL=@il,ILCE=@ilce,ADRES=@adres,GOREV=@gorev WHERE ID=@id", veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@ad", personel.PersonelAdi);
                sqlKomut.Parameters.AddWithValue("@soyad", personel.PersonelSoyadi);
                sqlKomut.Parameters.AddWithValue("@telefon", personel.PersonelTelefon);
                sqlKomut.Parameters.AddWithValue("@tc", personel.KimlikNumarasi);
                sqlKomut.Parameters.AddWithValue("@mail", personel.MailAdresi);
                sqlKomut.Parameters.AddWithValue("@il", personel.ILi);
                sqlKomut.Parameters.AddWithValue("@ilce", personel.Ilce);
                sqlKomut.Parameters.AddWithValue("@adres", personel.Adresi);
                sqlKomut.Parameters.AddWithValue("@gorev", personel.Gorevi);
                sqlKomut.Parameters.AddWithValue("@id", personel.PersonelID);

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
    }
}
