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
            return result == null ? 0 : Convert.ToInt32(result);
        }
        public static int UserUpdateById(int user_id, string email, string name, string description, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_update_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar);
            cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar);
            cmd.Parameters.Add("@description", System.Data.SqlDbType.NText);
            cmd.Parameters[0].Value = user_id;
            cmd.Parameters[1].Value = email;
            cmd.Parameters[2].Value = name;
            cmd.Parameters[3].Value = description;
            return cmd.ExecuteNonQuery();
        }
        public static string UserPasswordGetByUsername(string username, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_password_get_by_username";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar);
            cmd.Parameters[0].Value = username;
            object result = cmd.ExecuteScalar();
            return result == null ? "" : result.ToString();
        }
        public static string UserPasswordGetById(int user_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_password_get_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            object result = cmd.ExecuteScalar();
            return result == null ? "" : result.ToString();
        }
        public static int UserIdGetByUsername(string username, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_id_get_by_username";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar);
            cmd.Parameters[0].Value = username;
            object result = cmd.ExecuteScalar();
            return result == null ? 0 : Convert.ToInt32(result);
        }
        public static User UserAuthorizeByUsername(string username, SqlConnection cn)
        {
            if (cn==null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_authorize_by_username";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar);
            cmd.Parameters[0].Value = username;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                User user = new User((int)reader["id"], reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), Convert.ToDateTime(reader["reg_date"]), reader["log_date"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["log_date"]));
                reader.Close();
                reader.Dispose();
                return user;
            }
            reader.Close();
            reader.Dispose();
            return null;
        }
        public static User UserGetById(int user_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_get_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                User user = new User(user_id, reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), Convert.ToDateTime(reader["reg_date"]), reader["log_date"] == null ? DateTime.Now : Convert.ToDateTime(reader["log_date"]));
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
        public static UserLanguage[] UserLangListById(int user_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_lang_list_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            SqlDataReader reader = cmd.ExecuteReader();
            List<UserLanguage> result = new List<UserLanguage>();
            while (reader.Read())
            {
                result.Add(new UserLanguage(user_id, Convert.ToInt32(reader["lang_id"]), Convert.ToInt16(reader["self_rating"]), Convert.ToSingle(reader["net_rating"])));
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }
        public static User[] UserSearch(string keyword, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_search";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@keyword", System.Data.SqlDbType.NVarChar);
            cmd.Parameters[0].Value = keyword;
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                users.Add(new User(Convert.ToInt32(reader["id"]), reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), Convert.ToDateTime(reader["reg_date"]), reader["log_date"] == null ? DateTime.Now : Convert.ToDateTime(reader["log_date"])));
            }
            reader.Close();
            reader.Dispose();
            return users.ToArray();
        }
        public static int UserLangSetById(int user_id, int lang_id, short self_rating, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_lang_set_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@lang_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@self_rating", System.Data.SqlDbType.TinyInt);
            cmd.Parameters[0].Value = user_id;
            cmd.Parameters[1].Value = lang_id;
            cmd.Parameters[2].Value = self_rating;
            return cmd.ExecuteNonQuery();
        }
        public static int UserLangDeleteById(int user_id, int lang_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_lang_delete_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@lang_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            cmd.Parameters[1].Value = lang_id;
            return cmd.ExecuteNonQuery();
        }
        public static int UserPasswordUpdateById(int user_id, string password, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_password_update_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar);
            cmd.Parameters[0].Value = user_id;
            cmd.Parameters[1].Value = password;
            return cmd.ExecuteNonQuery();
        }

        public static User[] UserFavorUserListById(int user_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_favor_user_list_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            SqlDataReader reader = cmd.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                users.Add(new User(Convert.ToInt32(reader["id"]), reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), Convert.ToDateTime(reader["reg_date"]), reader["log_date"] == null ? DateTime.Now : Convert.ToDateTime(reader["log_date"])));
            }
            reader.Close();
            reader.Dispose();
            return users.ToArray();
        }
        public static UserSimil[] UserIntroById(int user_id, int lang_id, int limit, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_intro_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@lang_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            cmd.Parameters[1].Value = lang_id;
            SqlDataReader reader = cmd.ExecuteReader();
            List<UserSimil> users = new List<UserSimil>();
            int count = 0;
            while (reader.Read())
            {
                users.Add(new UserSimil(new User(Convert.ToInt32(reader["id"]), reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), Convert.ToDateTime(reader["reg_date"]), reader["log_date"] == null ? DateTime.Now : Convert.ToDateTime(reader["log_date"])), Convert.ToInt16(reader["self_rating"]), Convert.ToSingle(reader["net_rating"]), Convert.ToDouble(reader["simil"])));
                count++;
                if (count >= limit) break;
            }
            reader.Close();
            reader.Dispose();
            return users.ToArray();
        }
        public static int UserFavorUserAddById(int user_id, int favor_user_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_favor_user_add_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@favor_user_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            cmd.Parameters[1].Value = favor_user_id;
            return cmd.ExecuteNonQuery();
        }
        public static int UserFavorUserDeleteById(int user_id, int favor_user_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_favor_user_delete_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@favor_user_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            cmd.Parameters[1].Value = favor_user_id;
            return cmd.ExecuteNonQuery();
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
        public static int TransAnsRateById(int user_id, int trans_ans_id, short rating, SqlConnection cn)
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
        public static int MessageSend(int user_id, int dst_id, int dst_type, string subject, string body, bool pending_trans, int trans_req_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_message_send";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@src_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@dst_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@dst_type", System.Data.SqlDbType.TinyInt);
            cmd.Parameters.Add("@subject", System.Data.SqlDbType.NVarChar);
            cmd.Parameters.Add("@body", System.Data.SqlDbType.NText);
            cmd.Parameters.Add("@pending_trans", System.Data.SqlDbType.Bit);
            cmd.Parameters.Add("@trans_req_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            cmd.Parameters[1].Value = dst_id;
            cmd.Parameters[2].Value = dst_type;
            cmd.Parameters[3].Value = subject;
            cmd.Parameters[4].Value = body;
            cmd.Parameters[5].Value = pending_trans;
            cmd.Parameters[6].Value = trans_req_id;
            return cmd.ExecuteNonQuery();
        }
        public static Message[] MessageRecvByUser(int dst_id, MessageDestinationType dst_type, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_message_recv_by_user";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@dst_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@dst_type", System.Data.SqlDbType.TinyInt);
            cmd.Parameters[0].Value = dst_id;
            cmd.Parameters[1].Value = dst_type;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Message> result = new List<Message>();
            while (reader.Read())
            {
                result.Add(new Message(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["src_id"]), Convert.ToInt32(reader["dst_id"]), dst_type, Convert.ToString(reader["subject"]), "", Convert.ToDateTime(reader["date"]), Convert.ToBoolean(reader["unread"]), Convert.ToBoolean(reader["pending_trans"]), Convert.ToInt32(reader["trans_req_id"])));
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }
        public static Message[] MessageSentByUser( int user_id, SqlConnection cn )
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_message_sent_by_user";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Message> result = new List<Message>();
            while (reader.Read())
            {
                result.Add(new Message(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["src_id"]), Convert.ToInt32(reader["dst_id"]), (MessageDestinationType)Convert.ToInt32(reader["dst_type"]), Convert.ToString(reader["subject"]), "", Convert.ToDateTime(reader["date"]), false, Convert.ToBoolean(reader["pending_trans"]), Convert.ToInt32(reader["trans_req_id"])));
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }
        public static Message[] MessagePendingByUser(int user_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_message_pending_by_user";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Message> result = new List<Message>();
            while (reader.Read())
            {
                result.Add(new Message(Convert.ToInt32(reader["id"]), Convert.ToInt32(reader["src_id"]), Convert.ToInt32(reader["dst_id"]), (MessageDestinationType)Convert.ToInt32(reader["dst_type"]), Convert.ToString(reader["subject"]), "", Convert.ToDateTime(reader["date"]), false, Convert.ToBoolean(reader["pending_trans"]), Convert.ToInt32(reader["trans_req_id"])));
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }
        public static Message MessageGetById( int msg_id, SqlConnection cn )
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_message_get_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@msg_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = msg_id;
            SqlDataReader reader = cmd.ExecuteReader();
            Message result;
            if (reader.Read())
            {
                result = new Message(msg_id, Convert.ToInt32(reader["src_id"]), Convert.ToInt32(reader["dst_id"]), (MessageDestinationType)Convert.ToInt32(reader["dst_type"]), Convert.ToString(reader["subject"]), Convert.ToString(reader["body"]), Convert.ToDateTime(reader["date"]), false, Convert.ToBoolean(reader["pending_trans"]), Convert.ToInt32(reader["trans_req_id"]));
                reader.Close();
                reader.Dispose();
                return result;
            }
            else
            {
                reader.Close();
                reader.Dispose();
                return null;
            }
        }
        public static int TransAnsAdd( int req_id, int user_id, string message, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_trans_ans_add";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@req_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@message", System.Data.SqlDbType.NText);
            cmd.Parameters[0].Value = req_id;
            cmd.Parameters[1].Value = user_id;
            cmd.Parameters[2].Value = message;
            return cmd.ExecuteNonQuery();
        }
        public static Translation[] TransGetApprByUser(int user_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_trans_get_app_by_user";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Translation> result = new List<Translation>();
            while (reader.Read())
            {
                result.Add ( new Translation(Convert.ToInt32(reader["req_id"]),
                                        Convert.ToInt32(reader["src_lang_id"]),
                                        Convert.ToInt32(reader["dst_lang_id"]),
                                        Convert.ToInt32(reader["dst_id"]),
                                        (TranslationDestinationType)Convert.ToInt32(reader["dst_type"]),
                                        Convert.ToString(reader["subject"]),
                                        "", Convert.ToDateTime(reader["date"]),
                                        Convert.ToBoolean(reader["completed"]),
                                        Convert.ToInt32(reader["msg_id"]),
                                        user_id,
                                        Convert.ToInt32(reader["ans_id"]), "", 0,
                                        Convert.ToDateTime(reader["ans_date"]),
                                        Convert.ToInt32(reader["ans_user_id"])));
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }
        public static Translation TransGetByReqId(int req_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_trans_get_by_req_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@req_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = req_id;
            SqlDataReader reader = cmd.ExecuteReader();
            Translation result;
            if (reader.Read())
            {
                result = new Translation(req_id,
                                        Convert.ToInt32(reader["src_lang_id"]),
                                        Convert.ToInt32(reader["dst_lang_id"]),
                                        Convert.ToInt32(reader["dst_id"]),
                                        (TranslationDestinationType)Convert.ToInt32(reader["dst_type"]),
                                        Convert.ToString(reader["subject"]),
                                        Convert.ToString(reader["message"]),
                                        Convert.ToDateTime(reader["date"]),
                                        Convert.ToBoolean(reader["completed"]),
                                        Convert.ToInt32(reader["msg_id"]),
                                        Convert.ToInt32(reader["user_id"]),
                                        Convert.ToInt32(reader["ans_id"]),
                                        Convert.ToString(reader["trans_message"]),
                                        Convert.ToInt32(reader["rating"]),
                                        Convert.ToDateTime(reader["ans_date"]),
                                        Convert.ToInt32(reader["ans_user_id"]));
                reader.Close();
                reader.Dispose();
                return result;
            }
            else
            {
                reader.Close();
                reader.Dispose();
                return null;
            }
        }
        public static Translation[] TransGetPendingByUser(int user_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_trans_get_pending_by_user";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Translation> result = new List<Translation>();
            while (reader.Read())
            {
                result.Add(new Translation(Convert.ToInt32(reader["id"]),
                                        Convert.ToInt32(reader["src_lang_id"]),
                                        Convert.ToInt32(reader["dst_lang_id"]),
                                        Convert.ToInt32(reader["dst_id"]),
                                        (TranslationDestinationType)Convert.ToInt32(reader["dst_type"]),
                                        Convert.ToString(reader["subject"]),
                                        "", Convert.ToDateTime(reader["date"]), false,
                                        Convert.ToInt32(reader["msg_id"]),
                                        user_id ));
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }
        public static Translation[] TransGetUnApprByUser(int user_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_trans_get_unapp_by_user";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Translation> result = new List<Translation>();
            while (reader.Read())
            {
                result.Add(new Translation(Convert.ToInt32(reader["req_id"]),
                                        Convert.ToInt32(reader["src_lang_id"]),
                                        Convert.ToInt32(reader["dst_lang_id"]),
                                        Convert.ToInt32(reader["dst_id"]),
                                        (TranslationDestinationType)Convert.ToInt32(reader["dst_type"]),
                                        Convert.ToString(reader["subject"]),
                                        "", Convert.ToDateTime(reader["date"]),
                                        Convert.ToBoolean(reader["completed"]),
                                        Convert.ToInt32(reader["msg_id"]),
                                        user_id,
                                        Convert.ToInt32(reader["ans_id"]), "", 0,
                                        Convert.ToDateTime(reader["ans_date"]),
                                        Convert.ToInt32(reader["ans_user_id"])));
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }
        public static int TransReqAdd(int user_id, int src_lang_id, int dst_lang_id, string subject, string message, int dst_id, TranslationDestinationType dst_type, int msg_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_trans_req_add";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@src_lang_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@dst_lang_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@subject", System.Data.SqlDbType.NVarChar);
            cmd.Parameters.Add("@message", System.Data.SqlDbType.NText);
            cmd.Parameters.Add("@dst_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@dst_type", System.Data.SqlDbType.TinyInt);
            cmd.Parameters.Add("@msg_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            cmd.Parameters[1].Value = src_lang_id;
            cmd.Parameters[2].Value = dst_lang_id;
            cmd.Parameters[3].Value = subject;
            cmd.Parameters[4].Value = message;
            cmd.Parameters[5].Value = dst_id;
            cmd.Parameters[6].Value = dst_type;
            cmd.Parameters[7].Value = msg_id;
            return cmd.ExecuteNonQuery();
        }
        public static int TransReqClose(int req_id, int ans_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_trans_req_close";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@req_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@ans_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = req_id;
            cmd.Parameters[1].Value = ans_id;
            return cmd.ExecuteNonQuery();
        }
        public static Translation TransReqGetById(int req_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_trans_req_get_by_id";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@req_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = req_id;
            SqlDataReader reader = cmd.ExecuteReader();
            Translation result;
            if (reader.Read())
            {
                result = new Translation(req_id,
                                        Convert.ToInt32(reader["src_lang_id"]),
                                        Convert.ToInt32(reader["dst_lang_id"]),
                                        Convert.ToInt32(reader["dst_id"]),
                                        (TranslationDestinationType)Convert.ToInt32(reader["dst_type"]),
                                        Convert.ToString(reader["subject"]),
                                        Convert.ToString(reader["message"]),
                                        Convert.ToDateTime(reader["date"]),
                                        Convert.ToBoolean(reader["completed"]),
                                        Convert.ToInt32(reader["msg_id"]),
                                        Convert.ToInt32(reader["user_id"]));
                reader.Close();
                reader.Dispose();
                return result;
            }
            else
            {
                reader.Close();
                reader.Dispose();
                return null;
            }
        }
        public static Translation[] TransReqGetForUser(int user_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_trans_req_get_for_user";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Translation> result = new List<Translation>();
            while (reader.Read())
            {
                result.Add(new Translation(Convert.ToInt32(reader["id"]),
                                        Convert.ToInt32(reader["src_lang_id"]),
                                        Convert.ToInt32(reader["dst_lang_id"]),
                                        Convert.ToInt32(reader["dst_id"]),
                                        (TranslationDestinationType)Convert.ToInt32(reader["dst_type"]),
                                        Convert.ToString(reader["subject"]),
                                        "", Convert.ToDateTime(reader["date"]),
                                        Convert.ToBoolean(reader["completed"]),
                                        Convert.ToInt32(reader["msg_id"]),
                                        user_id ));
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }
        public static Translation[] TransReqFindGlobalForUser(int user_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_trans_req_find_global_for_user";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = user_id;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Translation> result = new List<Translation>();
            while (reader.Read())
            {
                result.Add(new Translation(Convert.ToInt32(reader["id"]),
                                        Convert.ToInt32(reader["src_lang_id"]),
                                        Convert.ToInt32(reader["dst_lang_id"]),
                                        Convert.ToInt32(reader["dst_id"]),
                                        (TranslationDestinationType)Convert.ToInt32(reader["dst_type"]),
                                        Convert.ToString(reader["subject"]),
                                        "", Convert.ToDateTime(reader["date"]), false,
                                        Convert.ToInt32(reader["msg_id"]),
                                        Convert.ToInt32(reader["user_id"])));
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }
        public static UserRankQuantity[] UserRankByQuantity(float interval, int limit, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_rank_by_quantity";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@interval", System.Data.SqlDbType.Float);
            cmd.Parameters[0].Value = interval;
            SqlDataReader reader = cmd.ExecuteReader();
            List<UserRankQuantity> result = new List<UserRankQuantity>();
            int count = 0;
            while (reader.Read())
            {
                result.Add(new UserRankQuantity(new User(Convert.ToInt32(reader["id"]), reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), Convert.ToDateTime(reader["reg_date"]), reader["log_date"] == null ? DateTime.Now : Convert.ToDateTime(reader["log_date"])),Convert.ToInt32(reader["quantity"])));
                count++;
                if (count >= limit) break;
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }
        public static UserRankRating[] UserRankByRating(int lang_id, int limit, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_user_rank_by_rating";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@lang_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = lang_id;
            SqlDataReader reader = cmd.ExecuteReader();
            List<UserRankRating> result = new List<UserRankRating>();
            int count = 0;
            while (reader.Read())
            {
                result.Add(new UserRankRating(new User(Convert.ToInt32(reader["id"]), reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), Convert.ToDateTime(reader["reg_date"]), reader["log_date"] == null ? DateTime.Now : Convert.ToDateTime(reader["log_date"])), Convert.ToInt32(reader["lang_id"]), Convert.ToSingle(reader["net_rating"])));
                count++;
                if (count >= limit) break;
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }
        public static Translation[] TransSearch(string keyword, int src_lang_id, int dst_lang_id, SqlConnection cn)
        {
            if (cn == null || cn.cn == null) throw new ArgumentException("Database connection not open!");
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "omni_trans_search";
            cmd.Connection = cn.cn;
            cmd.Parameters.Add("@keyword_id", System.Data.SqlDbType.NVarChar);
            cmd.Parameters.Add("@arc_lang_id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@dst_lang_id", System.Data.SqlDbType.Int);
            cmd.Parameters[0].Value = keyword;
            cmd.Parameters[1].Value = src_lang_id;
            cmd.Parameters[2].Value = dst_lang_id;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Translation> result = new List<Translation>();
            while (reader.Read())
            {
                result.Add(new Translation(Convert.ToInt32(reader["id"]),
                                        Convert.ToInt32(reader["src_lang_id"]),
                                        Convert.ToInt32(reader["dst_lang_id"]),
                                        0, 0,
                                        Convert.ToString(reader["subject"]),
                                        "", Convert.ToDateTime(reader["date"]), true,
                                        0, 0));
            }
            reader.Close();
            reader.Dispose();
            return result.ToArray();
        }
    }
}

