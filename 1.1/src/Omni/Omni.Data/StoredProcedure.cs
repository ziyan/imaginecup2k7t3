using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Omni.Data
{
    public static class StoredProcedure
    {
        private static SqlCommand GetStoredProcedure(string name, Connection connection)
        {
            if (connection == null || connection.sqlcn == null)
                throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = name;
            cmd.Connection = connection.sqlcn;
            return cmd;
        }
        private static void SetStoredProcedureParameter(SqlCommand cmd, string name, SqlDbType type, object value)
        {
            if(!cmd.Parameters.Contains(name))
                cmd.Parameters.Add(name, type);
            cmd.Parameters[name].SqlDbType = type;
            cmd.Parameters[name].Value = value;
        }
    }
}
