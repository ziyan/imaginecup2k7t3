using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Omni.Data
{
    public static class StoredProcedure
    {
        public static int UserRegister(string username, string password, string email, string name, string description, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_register";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar);
            cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar);
            cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar);
            cmd.Parameters.Add("@description", System.Data.SqlDbType.NText);
            cmd.Parameters[0].Value = username;
            cmd.Parameters[1].Value = password;
            cmd.Parameters[2].Value = email;
            cmd.Parameters[3].Value = name;
            cmd.Parameters[4].Value = description;
            object result = cmd.ExecuteScalar();
            return result == null ? 0 : (int)result;
        }
        public static string UserAuthorizeByUsername(string username, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_authorize_by_username";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar);
            cmd.Parameters[0].Value = username;
            object result = cmd.ExecuteScalar();
            return result == null ? "" : result.ToString();
        }
        public static User UserPostAuthorizeByUsername(string username, SqlConnection cn)
        {
            if (cn==null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_post_authorize_by_username";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar);
            cmd.Parameters[0].Value = username;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                User user = new User((int)reader["id"], reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), Convert.ToDateTime(reader["reg_date"]), reader["log_date"] == null ? DateTime.Now : Convert.ToDateTime(reader["log_date"]));
                reader.Close();
                reader.Dispose();
                return user;
            }
            reader.Close();
            reader.Dispose();
            return null;
        }
        public static Language[] LangList(SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_lang_list";
            cmd.Connection = cn.cn;
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
        public static string LangLangQueryById(int lang_id, int dst_lang_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_lang_lang_query_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@lang_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@dst_lang_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = lang_id;
            cmd.Parameters[1].Value = dst_lang_id;
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                string name = reader["name"].ToString();
                reader.Close();
                reader.Dispose();
                return name;
            }
            reader.Close();
            reader.Dispose();
            return "";
        }
        public static Interest[] InterestList(int parent_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_interest_list";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@parent_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = parent_id;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Interest> result = new List<Interest>();
            while (reader.Read())
            {
                result.Add(new Interest(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["parent_id"]),"",0));
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }

        public static Interest[] InterestLangList(int parent_id, int lang_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_interest_lang_list";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@parent_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@lang_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = parent_id;
            cmd.Parameters[1].Value = lang_id;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Interest> result = new List<Interest>();
            while (reader.Read())
            {
                result.Add(new Interest(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["parent_id"]), reader["name"].ToString(), lang_id));
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }
        public static string InterestLangQueryById(int interest_id, int lang_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_interest_lang_query_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@interest_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@lang_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = interest_id;
            cmd.Parameters[1].Value = lang_id;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string name = reader["name"].ToString();
                reader.Close();
                reader.Dispose();
                return name;
            }
            reader.Close();
            reader.Dispose();
            return "";
        }
        public static Interest[] UserInterestListById(int user_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_interest_list_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Interest> result = new List<Interest>();
            while (reader.Read())
            {
                result.Add(new Interest(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["parent_id"]),"",0));
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }
        public static int UserInterestAddById(int user_id, int interest_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_interest_add_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@interest_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            cmd.Parameters[1].Value = interest_id;
            return cmd.ExecuteNonQuery();
        }
        public static int UserInterestDeleteById(int user_id, int interest_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_interest_delete_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@interest_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            cmd.Parameters[1].Value = interest_id;
            return cmd.ExecuteNonQuery();
        }
        public static int TransAnsRateById(int user_id, int trans_ans_id, int rating, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_trans_ans_rate_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@trans_ans_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@rating", System.Data.SqlDbType.TinyInt);
            cmd.Parameters[0].Value = user_id;
            cmd.Parameters[1].Value = trans_ans_id;
            cmd.Parameters[2].Value = rating;
            return cmd.ExecuteNonQuery();
        }
    }
}
