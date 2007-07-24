using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;

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
            return result == null ? "000000000000000000000000000000000000000000" : result.ToString();
        }
        public static User UserAuthorizeByUsername(string username, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_authorize_by_username", connection);
            SetStoredProcedureParameter(cmd, "@username", SqlDbType.VarChar, username);
            User user = null;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                user = new User((int)reader["id"], reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), reader["sn_network"].ToString(), reader["sn_screenname"].ToString(), Convert.ToDateTime(reader["reg_date"]), reader["log_date"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["log_date"]));
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
        public static int UserUpdate(int userid, string name, string email, string description, string sn_network, string sn_screenname, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_update_by_id", connection);
            SetStoredProcedureParameter(cmd, "@id", SqlDbType.Int, userid);
            SetStoredProcedureParameter(cmd, "@name", SqlDbType.NVarChar, name);
            SetStoredProcedureParameter(cmd, "@email", SqlDbType.VarChar, email);
            SetStoredProcedureParameter(cmd, "@description", SqlDbType.NVarChar, description);
            SetStoredProcedureParameter(cmd, "@sn_network", SqlDbType.NVarChar, sn_network);
            SetStoredProcedureParameter(cmd, "@sn_screenname", SqlDbType.NVarChar, sn_screenname);
            object result = cmd.ExecuteScalar();
            return (result == null) ? 1 : Convert.ToInt32(result);
        }
        public static Interest[] UserInterests(int user_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_interest_list_by_id", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Interest> result = new List<Interest>();
            while (reader.Read())
            {
                result.Add(new Interest(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["parent_id"]), reader["name"].ToString()));
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }
        public static User UserProfile(int cur_user_id, int profile_user_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_get_by_id", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, profile_user_id);
            User user = null;
            SqlDataReader reader = cmd.ExecuteReader();
            // Don't need their login date
            if (reader.Read())
                user = new User((int)reader["id"], reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), reader["sn_network"].ToString(), reader["sn_screenname"].ToString(), Convert.ToDateTime(reader["reg_date"]), DateTime.Now);
            reader.Close();
            reader.Dispose();

            cmd = GetStoredProcedure("omni_user_favor_check_pair", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, profile_user_id);
            SetStoredProcedureParameter(cmd, "@favor_user_id", SqlDbType.Int, cur_user_id);
            object result = cmd.ExecuteScalar();
            int result2 = (result == null) ? -1 : Convert.ToInt32(result);
            if (result2 != 1 && user != null)
            {
                // Not the profile user's friend, remove contact info
                user.email = "";
                user.sn_network = "";
                user.sn_screenname = "";
            }

            return user;
        }
        #endregion

        #region Interest
        public static Interest[] InterestList(Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_interest_list", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Interest> result = new List<Interest>();
            while (reader.Read())
            {
                result.Add(new Interest(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["parent_id"]), reader["name"].ToString()));
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }
        #endregion

        #region Language
        public static Language[] LanguageList(Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_lang_list", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Language> result = new List<Language>();
            while (reader.Read())
            {
                result.Add(new Language(Convert.ToInt32(reader["id"]), reader["code"].ToString()));
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }
        #endregion


    }
}
