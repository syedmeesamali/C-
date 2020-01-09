using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ExceltoSQL.General
{
    public class ConnectionSettings
    {
        public static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["db_con"].ConnectionString;
        }
    }
}