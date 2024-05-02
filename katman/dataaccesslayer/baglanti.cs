using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataaccesslayer
{
    internal class baglanti
    {
        public static MySqlConnection baglan = new MySqlConnection("server = localhost; uid = root; database= sirket");
    }
}
