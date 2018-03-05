using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DevExpress
{
    /// <summary>
    /// Veritabani Bağlantısının Yapıldığı Sınıf
    /// </summary>
    public class Veritabani
    {
        /// <summary>
        /// Baglantı Adresi kaynağı
        /// </summary>
        private string baglantiAdresi="Data Source=SAMSUNG-PC;Initial Catalog=DbTicariOtomasyon;Integrated Security=True";
        SqlConnection baglan;
        /// <summary>
        /// SqlConnection Bağlantı açma metodu
        /// </summary>
        /// <returns>SqlConnection bağlantısı</returns>

        public SqlConnection BaglantiAc()
        {
            baglan = new SqlConnection(@baglantiAdresi);
            baglan.Open();
            return baglan;
        }


        public void BaglantiKapat()
        {
             baglan.Close();
        }


        public bool Ekle(SqlCommand sqlKomut)
        {
            try
            {
                sqlKomut = new SqlCommand();

                sqlKomut.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                
                throw;
            }

            //return false;
        }

        public bool GirisYap(string kullaniciAd, string sifre)
        {
            SqlCommand sqlKomut = new SqlCommand("SELECT *  FROM TBL_ADMIN WHERE KullaniciAd=@kullaniciAd and Sifre=@sifre", BaglantiAc());
            sqlKomut.Parameters.AddWithValue("@kullaniciAd", kullaniciAd);
            sqlKomut.Parameters.AddWithValue("@sifre", sifre);
            SqlDataReader dr = sqlKomut.ExecuteReader();
            if (dr.Read())
            {
                return true;

            }
            else
            {
                return false;
            }
        }

    }
}
