using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Data
{
    public static class StoredProcedure
    {
        /// <summary>
        /// This is a StoredProcedure demo
        /// Returns a configuration value from configuration table
        /// </summary>
        /// <param name="key">key for the configuration</param>
        /// <param name="cn">database connection</param>
        /// <returns>the value associated with the key</returns>
        public static string GetConfiguration(string key, SqlConnection cn)
        {
            if (key == null || key == "" || cn == null) throw new ArgumentNullException();
            if (cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_configuration_get";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@key", System.Data.SqlDbType.NVarChar);
            cmd.Parameters[0] = key;
            object result = cmd.ExecuteScalar();
            return result == null ? "" : result.ToString();
        }
    }
}
