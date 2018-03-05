using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress
{
    public class FaturalarVeritabani
    {
        Veritabani veritabani = new Veritabani();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ListeleFaturaBilgileri()
        {
            DataTable dataTable = new DataTable();

            string sorgu = String.Format("SELECT * FROM TBL_FATURABILGI");

            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, veritabani.BaglantiAc());

            sqlData.Fill(dataTable);

            return dataTable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable ListeleFaturaDetaylari(string faturaid)
        {
            DataTable dataTable = new DataTable();

            string sorgu = String.Format("SELECT * FROM TBL_FATURADETAYI WHERE FATURAID={0}",faturaid);
            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, veritabani.BaglantiAc());

            sqlData.Fill(dataTable);

            return dataTable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="faturaid"></param>
        /// <returns></returns>
        public DataTable ListeleFaturaDetaylariDuzenleme(string faturaid)
        {
            DataTable dataTable = new DataTable();

            string sorgu = String.Format("SELECT * FROM TBL_FATURADETAYI WHERE FATURAURUNID={0}", faturaid);
            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, veritabani.BaglantiAc());

            sqlData.Fill(dataTable);

            return dataTable;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="faturaBilgi"></param>
        /// <returns></returns>
        public bool FaturaBilgileriEkle(FaturaBilgileri faturaBilgi)
        {
            try
            {
                string sorgu = "INSERT INTO TBL_FATURABILGI(SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN)" +
                    " VALUES(@seri,@sirano,@tarih,@saat,@vergidaire,@alici,@teslimeden,@teslimalan)";

                SqlCommand sqlKomut = new SqlCommand(sorgu, veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@seri", faturaBilgi.SeriNo);
                sqlKomut.Parameters.AddWithValue("@sirano", faturaBilgi.SiraNo);
                sqlKomut.Parameters.AddWithValue("@tarih", faturaBilgi.Tarih);
                sqlKomut.Parameters.AddWithValue("@saat", faturaBilgi.Saat);
                sqlKomut.Parameters.AddWithValue("@vergidaire", faturaBilgi.VergiDaire);
                sqlKomut.Parameters.AddWithValue("@alici", faturaBilgi.Alici);
                sqlKomut.Parameters.AddWithValue("@teslimeden", faturaBilgi.TeslimEden);
                sqlKomut.Parameters.AddWithValue("@teslimalan", faturaBilgi.TeslimAlan);

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
        /// 
        /// </summary>
        /// <param name="faturaDetayi"></param>
        /// <returns></returns>
        public bool FaturaDetaylariEkle(FaturaDetaylari faturaDetayi)
        {
            try
            {
                string sorgu = "INSERT INTO TBL_FATURADETAYI(URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID)" +
                    " VALUES(@urunad,@miktar,@fiyat,@tutar,@faturaid)";

                SqlCommand sqlKomut = new SqlCommand(sorgu, veritabani.BaglantiAc());
                sqlKomut.Parameters.AddWithValue("@urunad", faturaDetayi.UrunAdi);
                sqlKomut.Parameters.AddWithValue("@miktar", faturaDetayi.Miktari);
                sqlKomut.Parameters.AddWithValue("@fiyat", faturaDetayi.Fiyati);
                sqlKomut.Parameters.AddWithValue("@tutar", faturaDetayi.Tutari);
                sqlKomut.Parameters.AddWithValue("@faturaid", faturaDetayi.FaturaID);

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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool FaturaBilgiSil(string id)
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("DELETE FROM TBL_FATURABILGI WHERE FATURABILGIID=@ID", veritabani.BaglantiAc());
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
        /// <param name="id"></param>
        /// <returns></returns>
        public bool FaturaDetayiSil(string id)
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("DELETE FROM TBL_FATURADETAYI WHERE FATURAURUNID=@ID", veritabani.BaglantiAc());
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
        /// <param name="faturaBilgi"></param>
        /// <returns></returns>
        public bool FaturaBilgiGuncelle(FaturaBilgileri faturaBilgi)
        {
            try
            {
                SqlCommand sqlKomut = new SqlCommand("UPDATE TBL_FATURABILGI SET SERI=@seri,SIRANO=@sirano,TARIH=@tarih,SAAT=@saat,VERGIDAIRE=@vergidaire,ALICI=@alici," +
                    "TESLIMEDEN=@teslimeden,TESLIMALAN=@teslimalan WHERE FATURABILGIID=@id", veritabani.BaglantiAc());
                
                sqlKomut.Parameters.AddWithValue("@seri", faturaBilgi.SeriNo);
                sqlKomut.Parameters.AddWithValue("@sirano", faturaBilgi.SiraNo);
                sqlKomut.Parameters.AddWithValue("@tarih", faturaBilgi.Tarih);
                sqlKomut.Parameters.AddWithValue("@saat", faturaBilgi.Saat);
                sqlKomut.Parameters.AddWithValue("@vergidaire", faturaBilgi.VergiDaire);
                sqlKomut.Parameters.AddWithValue("@alici", faturaBilgi.Alici);
                sqlKomut.Parameters.AddWithValue("@teslimeden", faturaBilgi.TeslimEden);
                sqlKomut.Parameters.AddWithValue("@teslimalan", faturaBilgi.TeslimAlan);
                sqlKomut.Parameters.AddWithValue("@id", faturaBilgi.FaturaBilgiId);

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
        /// <param name="faturaDetayi"></param>
        /// <returns></returns>
        public bool FaturaDetayiGuncelle(FaturaDetaylari faturaDetayi)
        {
            try
            {

                SqlCommand sqlKomut = new SqlCommand("UPDATE TBL_FATURADETAYI SET URUNAD=@urunad,MIKTAR=@miktar,FIYAT=@fiyat,TUTAR=@tutar,FATURAID=@faturaid" +
                    " WHERE FATURAURUNID=@faturaurunid", veritabani.BaglantiAc());

                sqlKomut.Parameters.AddWithValue("@urunad", faturaDetayi.UrunAdi);
                sqlKomut.Parameters.AddWithValue("@miktar", faturaDetayi.Miktari);
                sqlKomut.Parameters.AddWithValue("@fiyat", faturaDetayi.Fiyati);
                sqlKomut.Parameters.AddWithValue("@tutar", faturaDetayi.Tutari);
                sqlKomut.Parameters.AddWithValue("@faturaid", faturaDetayi.FaturaID);
                sqlKomut.Parameters.AddWithValue("@faturaurunid", faturaDetayi.FaturaID);

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
