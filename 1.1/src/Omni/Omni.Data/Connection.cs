using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Omni.Data
{
    public class Connection : IDisposable
    {
        internal SqlConnection sqlcn = null;
        public Connection()
        {
            sqlcn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[0].ConnectionString);
            sqlcn.Open();
        }

        public void Dispose()
        {
            sqlcn.Close();
            sqlcn.Dispose();
            sqlcn = null;
        }
    }
}
