using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Teretana
{
    class Konekcija
    {
        public static SqlConnection KreirajKonekciju()
        {
            SqlConnectionStringBuilder ccnSb = new SqlConnectionStringBuilder();
            ccnSb.DataSource = @"DESKTOP-3CFQ1MT";
            ccnSb.InitialCatalog = "Teretana";
            ccnSb.IntegratedSecurity = true;

            string con = ccnSb.ToString();

            SqlConnection konekcija = new SqlConnection(con);
            return konekcija;
        }
    }
}
