using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress
{
    class NotlarVeritabani
    {
        Veritabani veritabani = new Veritabani();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notlar"></param>
        /// <returns></returns>
        public bool EkleNot(Notlar notlar)
        {

            try
            {
                string sorgu = "INSERT INTO TBL_NOTLAR(TARIH,SAAT,BASLIK,DETAY,OLUSTURAN,HITAP) VALUES(@tarih,@saat,@baslik,@detay,@olusturan,@hitap)";

                SqlCommand sqlKomut = new SqlCommand(sorgu, veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@tarih", notlar.NotTarihi);
                sqlKomut.Parameters.AddWithValue("@saat", notlar.NotSaati);
                sqlKomut.Parameters.AddWithValue("@baslik", notlar.NotBaslik);
                sqlKomut.Parameters.AddWithValue("@detay", notlar.NotDetay);
                sqlKomut.Parameters.AddWithValue("@olusturan", notlar.NotOlusturan);
                sqlKomut.Parameters.AddWithValue("@hitap", notlar.NotHitap);

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
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable Listele()
        {
            DataTable dataTable = new DataTable();

            string sorgu = String.Format("SELECT * FROM TBL_NOTLAR");

            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, veritabani.BaglantiAc());

            sqlData.Fill(dataTable);

            return dataTable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool NotSil(string id)
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("DELETE FROM TBL_NOTLAR WHERE ID=@ID", veritabani.BaglantiAc());
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
        /// 
        /// </summary>
        /// <param name="notlar"></param>
        /// <returns></returns>
        public bool GuncelleNot(Notlar notlar)
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("UPDATE TBL_NOTLAR SET TARIH=@tarih,SAAT=@saat,BASLIK=@baslik,DETAY=@detay,OLUSTURAN=@olusturan,HITAP=@hitap WHERE ID=@id", veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@tarih", notlar.NotTarihi);
                sqlKomut.Parameters.AddWithValue("@saat", notlar.NotSaati);
                sqlKomut.Parameters.AddWithValue("@baslik", notlar.NotBaslik);
                sqlKomut.Parameters.AddWithValue("@detay", notlar.NotDetay);
                sqlKomut.Parameters.AddWithValue("@olusturan", notlar.NotOlusturan);
                sqlKomut.Parameters.AddWithValue("@hitap", notlar.NotHitap);
                sqlKomut.Parameters.AddWithValue("@id", notlar.NotId);

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
