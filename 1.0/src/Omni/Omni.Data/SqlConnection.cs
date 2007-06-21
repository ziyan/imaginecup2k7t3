using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Data
{
    /// <summary>
    /// Represents a SqlConnection that connects to the Omni database
    /// This object should be created once per connection
    /// </summary>
    public class SqlConnection
    {
        internal System.Data.SqlClient.SqlConnection cn = null;
        /// <summary>
        /// Initialize a connected sql connection
        /// </summary>
        public SqlConnection()
        {
            cn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlDb"].ConnectionString);
            cn.Open();
        }

        /// <summary>
        /// Close the sql connection
        /// </summary>
        public void Close()
        {
            cn.Close();
            cn.Dispose();
            cn = null;
        }
    }
}
