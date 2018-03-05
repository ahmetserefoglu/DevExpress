using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress
{
    public class GiderlerVeritabani
    {
        Veritabani veritabani = new Veritabani();

        /// <summary>
        /// Veritabanina Giderler Ekleme İşlemi Yapan Metot
        /// </summary>
        /// <param name="gider">Musteri Objesi</param>
        public bool GiderEkle(Giderler gider)
        {

            try
            {
                string sorgu = "INSERT INTO TBL_GIDERLER(AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR)" +
                    "VALUES(@Ay,@Yil,@Elektrik,@Su,@Dogalgaz,@Internet,@Maas,@Ekstra,@Not)";

                SqlCommand sqlKomut = new SqlCommand(sorgu, veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@Elektrik", gider.GiderElektrik);
                sqlKomut.Parameters.AddWithValue("@Su", gider.GiderSu);
                sqlKomut.Parameters.AddWithValue("@Dogalgaz", gider.GiderDogalGaz);
                sqlKomut.Parameters.AddWithValue("@Internet", gider.GiderInternet);
                sqlKomut.Parameters.AddWithValue("@Maas", gider.GiderMaas);
                sqlKomut.Parameters.AddWithValue("@Ekstra", gider.GiderEkstra);
                sqlKomut.Parameters.AddWithValue("@Not", gider.NotBilgisi);
                sqlKomut.Parameters.AddWithValue("@Ay", gider.AyBilgisi);
                sqlKomut.Parameters.AddWithValue("@Yil", gider.YilBilgisi);

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

            string sorgu = String.Format("SELECT * FROM TBL_GIDERLER ORDER BY ID ASC");

            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, veritabani.BaglantiAc());

            sqlData.Fill(dataTable);

            return dataTable;
        }

        /// <summary>
        /// Giderleri veritabanindan silen metot
        /// </summary>
        /// <param name="id">ürün idsi</param>
        /// <returns></returns>
        public bool GiderSil(int id)
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("DELETE FROM TBL_GIDERLER WHERE ID=@ID", veritabani.BaglantiAc());
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
        /// Giderleri Veritabanindan Güncelle
        /// </summary>
        /// <param name="gider"></param>
        /// <returns></returns>
        public bool GiderGuncelle(Giderler gider)
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("UPDATE TBL_GIDERLER SET AY=@ay,YIL=@yil,ELEKTRIK=@elektrik,SU=@su,DOGALGAZ=@dogalgaz,INTERNET=@internet,MAASLAR=@maas,EKSTRA=@ekstra,NOTLAR=@not WHERE ID=@id", veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@ay", gider.AyBilgisi);
                sqlKomut.Parameters.AddWithValue("@yil", gider.YilBilgisi);
                sqlKomut.Parameters.AddWithValue("@elektrik", gider.GiderElektrik);
                sqlKomut.Parameters.AddWithValue("@su", gider.GiderSu);
                sqlKomut.Parameters.AddWithValue("@dogalgaz", gider.GiderDogalGaz);
                sqlKomut.Parameters.AddWithValue("@internet", gider.GiderInternet);
                sqlKomut.Parameters.AddWithValue("@maas", gider.GiderMaas);
                sqlKomut.Parameters.AddWithValue("@ekstra", gider.GiderEkstra);
                sqlKomut.Parameters.AddWithValue("@not", gider.NotBilgisi);
                sqlKomut.Parameters.AddWithValue("@id", gider.GiderID);

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
