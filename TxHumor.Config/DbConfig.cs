using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace TxHumor.Config
{
    public static class DbConfig
    {
        static DbConfig() { ;}

        public static string GetDb(string dbKey)
        {
            return ConfigurationManager.ConnectionStrings[dbKey].ConnectionString;
        }
    }
}
