using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TicariOtomasyon
{
    class sqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-MN3O9G6\SQLEXPRESS;Initial Catalog=dbTicariOtomasyon;User ID=sa;Password=M10zxcvb.");
            baglan.Open();
            return baglan;
        }
    }
}
