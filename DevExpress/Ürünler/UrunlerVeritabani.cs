using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DevExpress
{
    public class UrunlerVeritabani
    {
        Veritabani veritabani = new Veritabani();

        /// <summary>
        /// VeritabaninaEkleme İşlemi Yapan Metot
        /// </summary>
        /// <param name="urun">Urun Objesi</param>
        public bool UrunEkle(Urunler urun)
        {

            try
            {
                string sorgu = "INSERT INTO TBL_URUNLER(URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) VALUES(@Ad,@Marka,@Model,@Yil,@Adet,@AlisFiyat,@SatisFiyat,@Detay)";

                SqlCommand sqlKomut = new SqlCommand(sorgu, veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@Ad", urun.UrunAdi);
                sqlKomut.Parameters.AddWithValue("@Marka", urun.MarkaAdi);
                sqlKomut.Parameters.AddWithValue("@Model", urun.ModelAdi);
                sqlKomut.Parameters.AddWithValue("@Yil", urun.Yili);
                sqlKomut.Parameters.AddWithValue("@Adet", urun.AdetSayisi);
                sqlKomut.Parameters.AddWithValue("@AlisFiyat", urun.AlisFiyati);
                sqlKomut.Parameters.AddWithValue("@SatisFiyat", urun.SatisFiyati);
                sqlKomut.Parameters.AddWithValue("@Detay", urun.Detaylandirma);

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

            string sorgu = String.Format("SELECT * FROM TBL_URUNLER");

            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, veritabani.BaglantiAc());

            sqlData.Fill(dataTable);

            return dataTable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Urunler UrunOku(int id)
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("Select * FROM TBL_URUNLER WHERE ID=@ID", veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@ID", id);
                SqlDataReader sqlRead = sqlKomut.ExecuteReader();
                Urunler urunler = new Urunler();
                if (sqlRead.HasRows)
                {
                    while (sqlRead.Read())
                    {
                        urunler.ProductID = int.Parse(sqlRead["ID"].ToString());
                        urunler.UrunAdi = sqlRead["URUNAD"].ToString();
                        urunler.MarkaAdi = sqlRead["MARKA"].ToString();
                        urunler.ModelAdi = sqlRead["MODEL"].ToString();
                        urunler.Yili = sqlRead["YIL"].ToString();
                        urunler.AdetSayisi = int.Parse(sqlRead["ADET"].ToString());
                        urunler.AlisFiyati = decimal.Parse(sqlRead["ALISFIYAT"].ToString());
                        urunler.SatisFiyati = decimal.Parse(sqlRead["SATISFIYAT"].ToString());
                        urunler.Detaylandirma = sqlRead["DETAY"].ToString();
                    }
                }

                return urunler;
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
        public bool UrunSil(int id)
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("DELETE FROM TBL_URUNLER WHERE ID=@ID", veritabani.BaglantiAc());
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
        public bool UrunGuncelle(Urunler urun)
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("UPDATE TBL_URUNLER SET URUNAD=@urunad,MARKA=@marka,MODEL=@model,YIL=@yil,ADET=@adet,ALISFIYAT=@alisfiyat,SATISFIYAT=@satisfiyat,DETAY=@detay WHERE ID=@id",veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@urunad", urun.UrunAdi);
                sqlKomut.Parameters.AddWithValue("@marka", urun.MarkaAdi);
                sqlKomut.Parameters.AddWithValue("@model", urun.ModelAdi);
                sqlKomut.Parameters.AddWithValue("@yil", urun.Yili);
                sqlKomut.Parameters.AddWithValue("@adet", urun.AdetSayisi);
                sqlKomut.Parameters.AddWithValue("@alisfiyat", urun.AlisFiyati);
                sqlKomut.Parameters.AddWithValue("@satisfiyat", urun.SatisFiyati);
                sqlKomut.Parameters.AddWithValue("@detay", urun.Detaylandirma);
                sqlKomut.Parameters.AddWithValue("@id", urun.ProductID);

                sqlKomut.ExecuteNonQuery();

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
