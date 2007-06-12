using System;
using System.Collections.Generic;
using System.Text;

namespace Omni.Data
{
    public static class StoredProcedure
    {
        public static int UserRegister(string username, string password, string email, string name, string description, short timezone, SqlConnection cn)
        {
            if (cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_register";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar);
            cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar);
            cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar);
            cmd.Parameters.Add("@description", System.Data.SqlDbType.NText);
            cmd.Parameters.Add("@timezone", System.Data.SqlDbType.TinyInt);
            cmd.Parameters[0].Value = username;
            cmd.Parameters[1].Value = password;
            cmd.Parameters[2].Value = email;
            cmd.Parameters[3].Value = name;
            cmd.Parameters[4].Value = description;
            cmd.Parameters[5].Value = timezone;
            object result = cmd.ExecuteScalar();
            return result == null ? 0 : (int)result;
        }
    }
}
