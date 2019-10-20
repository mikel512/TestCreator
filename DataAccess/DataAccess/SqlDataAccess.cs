using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.DataAccess
{
    class SqlDataAccess
    {
        public string GetConnectionString()
        {
            var conn = new AppConfiguration();
            return conn.ConnectionString;
        }
    }
}
