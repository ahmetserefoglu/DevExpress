using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress
{
    class HareketlerVeritabani
    {
        Veritabani veritabani = new Veritabani();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable MusteriHareketListele()
        {
            DataTable dataTable = new DataTable();

            string sorgu = String.Format("Exec MusteriHareketler");

            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, veritabani.BaglantiAc());

            sqlData.Fill(dataTable);

            return dataTable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable FirmaHareketListele()
        {
            DataTable dataTable = new DataTable();

            string sorgu = String.Format("Exec FirmaHareketler");

            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, veritabani.BaglantiAc());

            sqlData.Fill(dataTable);

            return dataTable;
        }
    }
}
