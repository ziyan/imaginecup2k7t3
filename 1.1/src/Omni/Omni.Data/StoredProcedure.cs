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

        #region Configuration
        /// <summary>
        /// Read the configuration from database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lang_id"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static string ConfigGetByName(string name, int lang_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_config_get_by_name", connection);
            SetStoredProcedureParameter(cmd, "@name", SqlDbType.VarChar, name);
            SetStoredProcedureParameter(cmd, "@lang_id", SqlDbType.Int, lang_id);
            object result = cmd.ExecuteScalar();
            return result == null ? null : result.ToString();
        }
        #endregion

        #region User
        public static string UserPasswordGetByUsername(string username, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_password_get_by_username", connection);
            SetStoredProcedureParameter(cmd, "@username", SqlDbType.VarChar, username);
            object result = cmd.ExecuteScalar();
            return result == null ? "" : result.ToString();
        }
        public static User UserAuthorizeByUsername(string username, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_authorize_by_username", connection);
            SetStoredProcedureParameter(cmd, "@username", SqlDbType.VarChar, username);
            User user = null;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                user = new User((int)reader["id"], reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), Convert.ToDateTime(reader["reg_date"]), reader["log_date"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["log_date"]));
            reader.Close();
            reader.Dispose();
            return user;
        }
        public static int UserRegister(string username, string password, string email, string name, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_register", connection);
            SetStoredProcedureParameter(cmd, "@username", SqlDbType.VarChar, username);
            SetStoredProcedureParameter(cmd, "@password", SqlDbType.VarChar, password);
            SetStoredProcedureParameter(cmd, "@email", SqlDbType.VarChar, email);
            SetStoredProcedureParameter(cmd, "@name", SqlDbType.NVarChar, name);
            object result = cmd.ExecuteScalar();
            return result == null ? 0 : Convert.ToInt32(result);
        }
        #endregion

        #region Interest
        #endregion


    }
}
