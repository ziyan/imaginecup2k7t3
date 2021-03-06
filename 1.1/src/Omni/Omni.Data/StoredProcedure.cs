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
            if (!cmd.Parameters.Contains(name))
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
                user = new User((int)reader["id"], reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), reader["sn_network"].ToString(), reader["sn_screenname"].ToString(), Convert.ToDateTime(reader["reg_date"]), reader["log_date"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(reader["log_date"]), Convert.ToSingle(reader["user_rating"]));
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
        public static int UserUpdateInterests(int userid, int[] ids, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_interest_delete_all", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, userid);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < ids.Length; i++)
            {
                cmd = GetStoredProcedure("omni_user_interest_add_by_id", connection);
                SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, userid);
                SetStoredProcedureParameter(cmd, "@interest_id", SqlDbType.Int, ids[i]);
                cmd.ExecuteNonQuery();
            }

            return 0;
        }
        public static int UserUpdateLanguages(int userid, int[] ids, int[] skills, Connection connection)
        {
            if (ids.Length != skills.Length) return -1;

            SqlCommand cmd = GetStoredProcedure("omni_user_lang_delete_all", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, userid);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < ids.Length; i++)
            {
                cmd = GetStoredProcedure("omni_user_lang_set_by_id", connection);
                SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, userid);
                SetStoredProcedureParameter(cmd, "@lang_id", SqlDbType.Int, ids[i]);
                SetStoredProcedureParameter(cmd, "@self_rating", SqlDbType.Int, skills[i]);
                cmd.ExecuteNonQuery();
            }

            return 0;
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
                user = new User((int)reader["id"], reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), reader["sn_network"].ToString(), reader["sn_screenname"].ToString(), Convert.ToDateTime(reader["reg_date"]), DateTime.Now, Convert.ToSingle(reader["user_rating"]));
            reader.Close();
            reader.Dispose();

            if (profile_user_id != cur_user_id)
            {
                cmd = GetStoredProcedure("omni_user_favor_check_pair", connection);
                SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, profile_user_id);
                SetStoredProcedureParameter(cmd, "@favor_user_id", SqlDbType.Int, cur_user_id);
                object result = cmd.ExecuteScalar();
                int result2 = (result == null) ? -1 : Convert.ToInt32(result);
                if (result2 != 1)
                {
                    // Not the profile user's friend, remove contact info
                    user.email = "";
                    user.sn_network = "";
                    user.sn_screenname = "";
                }
            }

            return user;
        }
        public static string UserUsernameById(int user_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_username_get_by_id", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
            SqlDataReader reader = cmd.ExecuteReader();
            string username = "";
            if (reader.Read())
                username = reader["username"].ToString();
            reader.Close();
            reader.Dispose();
            return username;
        }
        public static UserLanguage[] UserLanguages(int user_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_lang_list_by_id", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
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
        public static UserSummary UserSummary(int user_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_get_summary", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
            UserSummary user = null;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                user = new UserSummary(user_id, Convert.ToInt32(reader["has_updated_profile"]), Convert.ToInt32(reader["unread_msgs"]), Convert.ToInt32(reader["open_personal_trans_req"]), Convert.ToInt32(reader["trans_req_to_approve"]), Convert.ToInt32(reader["open_global_trans_req"]));
            reader.Close();
            reader.Dispose();
            return user;
        }

        #endregion

        #region Friends
        public static User[] FriendsList(int user_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_favor_user_list_by_id", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
            List<User> users = new List<User>();
            SqlDataReader reader = cmd.ExecuteReader();
            // Don't need their login date
            while (reader.Read())
                users.Add(new User((int)reader["id"], reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), reader["sn_network"].ToString(), reader["sn_screenname"].ToString(), Convert.ToDateTime(reader["reg_date"]), DateTime.Now, Convert.ToSingle(reader["user_rating"])));
            reader.Close();
            reader.Dispose();

            foreach (User u in users)
            {
                if (u.id != user_id)
                {
                    if (FriendsCheckFriendPair(u.id, user_id, connection) == 0)
                    {
                        // Not the profile user's friend, remove contact info
                        u.email = "";
                        u.sn_network = "";
                        u.sn_screenname = "";
                    }
                }
            }

            return users.ToArray();
        }
        public static int FriendsCheckFriendPair(int user_id, int friend_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_favor_check_pair", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
            SetStoredProcedureParameter(cmd, "@favor_user_id", SqlDbType.Int, friend_id);
            object result = cmd.ExecuteScalar();
            int intResult = (result == null) ? 0 : Convert.ToInt32(result);
            return (intResult == 1) ? 1 : 0;
        }
        public static int FriendsAdd(int user_id, int friend_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_favor_user_add_by_id", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
            SetStoredProcedureParameter(cmd, "@favor_user_id", SqlDbType.Int, friend_id);
            object result = cmd.ExecuteScalar();
            return (result == null) ? 0 : Convert.ToInt32(result);
        }
        public static int FriendsRemove(int user_id, int friend_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_favor_user_delete_by_id", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
            SetStoredProcedureParameter(cmd, "@favor_user_id", SqlDbType.Int, friend_id);
            object result = cmd.ExecuteScalar();
            return (result == null) ? 0 : Convert.ToInt32(result);
        }
        public static User[] FriendsSearchUsers(int user_id, string search, int maxresults, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_search", connection);
            SetStoredProcedureParameter(cmd, "@keyword", SqlDbType.NVarChar, search);

            List<User> users = new List<User>();
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            // Don't need their login date
            while (reader.Read() && i < maxresults)
            {
                users.Add(new User((int)reader["id"], reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), reader["sn_network"].ToString(), reader["sn_screenname"].ToString(), Convert.ToDateTime(reader["reg_date"]), DateTime.Now, Convert.ToSingle(reader["user_rating"])));
                i++;
            }
            reader.Close();
            reader.Dispose();

            foreach (User u in users)
            {
                if (u.id != user_id)
                {
                    if (FriendsCheckFriendPair(u.id, user_id, connection) == 0)
                    {
                        // Not the profile user's friend, remove contact info
                        u.email = "";
                        u.sn_network = "";
                        u.sn_screenname = "";
                    }
                }
            }

            return users.ToArray();
        }
        public static UserSimil[] FriendsGetIntroduced(int user_id, int lang_id, int maxresults, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_intro_by_id", connection);
            SetStoredProcedureParameter(cmd, "@id", SqlDbType.Int, user_id);
            SetStoredProcedureParameter(cmd, "@lang_id", SqlDbType.Int, lang_id);

            List<UserSimil> users = new List<UserSimil>();
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            // Don't need their login date
            while (reader.Read() && i < maxresults)
            {
                User u = new User((int)reader["id"], reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), reader["sn_network"].ToString(), reader["sn_screenname"].ToString(), Convert.ToDateTime(reader["reg_date"]), DateTime.Now, Convert.ToSingle(reader["user_rating"]));
                users.Add(new UserSimil(u, Convert.ToInt16(reader["self_rating"]), Convert.ToSingle(reader["net_rating"]), Convert.ToDouble(reader["simil"])));
                i++;
            }
            reader.Close();
            reader.Dispose();

            foreach (UserSimil us in users)
            {
                if (us.user.id != user_id)
                {
                    if (FriendsCheckFriendPair(us.user.id, user_id, connection) == 0)
                    {
                        // Not the profile user's friend, remove contact info
                        us.user.email = "";
                        us.user.sn_network = "";
                        us.user.sn_screenname = "";
                    }
                }
            }

            return users.ToArray();
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

        #region Translations
        public static Translation[] TranslationSearch(string keyword, int src_lang_id, int dst_lang_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_trans_search", connection);
            SetStoredProcedureParameter(cmd, "@keyword", SqlDbType.NVarChar, keyword);
            SetStoredProcedureParameter(cmd, "@src_lang_id", SqlDbType.Int, src_lang_id);
            SetStoredProcedureParameter(cmd, "@dst_lang_id", SqlDbType.Int, dst_lang_id);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Translation> result = new List<Translation>();
            while (reader.Read())
            {
                result.Add(new Translation(Convert.ToInt32(reader["id"]),
                                        0, "",
                                        Convert.ToInt32(reader["src_lang_id"]),
                                        Convert.ToInt32(reader["dst_lang_id"]),
                                        0, 0, "",
                                        Convert.ToString(reader["subject"]),
                                        "", Convert.ToDateTime(reader["date"]), true));
            }
            reader.Close();
            reader.Dispose();

            return result.ToArray();
        }
        public static Translation[] TranslationGetUnapprovedForUser(int user_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_trans_get_unapp_by_user", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Translation> result = new List<Translation>();
            while (reader.Read())
            {
                result.Add(new Translation(Convert.ToInt32(reader["id"]),
                                        Convert.ToInt32(reader["user_id"]), "",
                                        Convert.ToInt32(reader["src_lang_id"]),
                                        Convert.ToInt32(reader["dst_lang_id"]),
                                        Convert.ToInt32(reader["dst_id"]),
                                        (TransDstType)Convert.ToInt32(reader["dst_type"]),
                                        "",
                                        Convert.ToString(reader["subject"]),
                                        "", Convert.ToDateTime(reader["date"]), false));
            }
            reader.Close();
            reader.Dispose();

            return result.ToArray();
        }
        public static Translation[] TranslationGetNonPendingApprovalForUser(int user_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_trans_get_non_unapp_by_user", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Translation> result = new List<Translation>();
            while (reader.Read())
            {
                result.Add(new Translation(Convert.ToInt32(reader["id"]),
                                        Convert.ToInt32(reader["user_id"]), "",
                                        Convert.ToInt32(reader["src_lang_id"]),
                                        Convert.ToInt32(reader["dst_lang_id"]),
                                        Convert.ToInt32(reader["dst_id"]),
                                        (TransDstType)Convert.ToInt32(reader["dst_type"]),
                                        "",
                                        Convert.ToString(reader["subject"]),
                                        "", Convert.ToDateTime(reader["date"]),
                                        Convert.ToBoolean(reader["completed"])));
            }
            reader.Close();
            reader.Dispose();

            return result.ToArray();
        }
        public static Translation[] TranslationGetRequestsForUser(int user_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_trans_req_get_for_user", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Translation> result = new List<Translation>();
            while (reader.Read())
            {
                result.Add(new Translation(Convert.ToInt32(reader["id"]),
                                        Convert.ToInt32(reader["user_id"]), "",
                                        Convert.ToInt32(reader["src_lang_id"]),
                                        Convert.ToInt32(reader["dst_lang_id"]),
                                        Convert.ToInt32(reader["dst_id"]),
                                        (TransDstType)Convert.ToInt32(reader["dst_type"]),
                                        "",
                                        Convert.ToString(reader["subject"]),
                                        "", Convert.ToDateTime(reader["date"]),
                                        Convert.ToBoolean(reader["completed"])));
            }
            reader.Close();
            reader.Dispose();

            return result.ToArray();
        }
        public static Translation[] TranslationFindGlobalRequestsForUser(int user_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_trans_req_find_global_for_user", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Translation> result = new List<Translation>();
            while (reader.Read())
            {
                result.Add(new Translation(Convert.ToInt32(reader["id"]),
                                        Convert.ToInt32(reader["user_id"]), "",
                                        Convert.ToInt32(reader["src_lang_id"]),
                                        Convert.ToInt32(reader["dst_lang_id"]),
                                        Convert.ToInt32(reader["dst_id"]),
                                        (TransDstType)Convert.ToInt32(reader["dst_type"]),
                                        "",
                                        Convert.ToString(reader["subject"]),
                                        "", Convert.ToDateTime(reader["date"]),
                                        Convert.ToBoolean(reader["completed"])));
            }
            reader.Close();
            reader.Dispose();

            return result.ToArray();
        }

        public static Translation TranslationRequestGetById(int req_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_trans_req_get_by_id", connection);
            SetStoredProcedureParameter(cmd, "@req_id", SqlDbType.Int, req_id);
            SqlDataReader reader = cmd.ExecuteReader();
            Translation result = null;
            if (reader.Read())
            {
                result = new Translation(Convert.ToInt32(reader["id"]),
                                        Convert.ToInt32(reader["user_id"]), "",
                                        Convert.ToInt32(reader["src_lang_id"]),
                                        Convert.ToInt32(reader["dst_lang_id"]),
                                        Convert.ToInt32(reader["dst_id"]),
                                        (TransDstType)Convert.ToInt32(reader["dst_type"]),
                                        "",
                                        Convert.ToString(reader["subject"]),
                                        Convert.ToString(reader["message"]),
                                        Convert.ToDateTime(reader["date"]),
                                        Convert.ToBoolean(reader["completed"]));
            }
            reader.Close();
            reader.Dispose();

            return result;
        }
        public static Translation[] TranslationAnswersGetByReqId(int user_id, int req_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_trans_get_by_req_id", connection);
            SetStoredProcedureParameter(cmd, "@req_id", SqlDbType.Int, req_id);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Translation> results = new List<Translation>();
            while (reader.Read())
            {
                results.Add(new Translation(req_id,
                                        Convert.ToInt32(reader["user_id"]), "",
                                        Convert.ToInt32(reader["src_lang_id"]),
                                        Convert.ToInt32(reader["dst_lang_id"]),
                                        Convert.ToInt32(reader["dst_id"]),
                                        (TransDstType)Convert.ToInt32(reader["dst_type"]), "",
                                        Convert.ToString(reader["subject"]),
                                        Convert.ToString(reader["message"]),
                                        Convert.ToDateTime(reader["date"]),
                                        Convert.ToBoolean(reader["completed"]),
                                        Convert.ToInt32(reader["ans_id"]),
                                        Convert.ToString(reader["trans_message"]),
                                        Convert.ToInt32(reader["rating"]),
                                        Convert.ToDateTime(reader["ans_date"]),
                                        Convert.ToInt32(reader["ans_user_id"]), "", 0));
            }
            reader.Close();
            reader.Dispose();

            foreach (Translation t in results)
            {
                cmd = GetStoredProcedure("omni_trans_ans_rate_get_by_id", connection);
                SetStoredProcedureParameter(cmd, "@ans_id", SqlDbType.Int, t.trans_id);
                SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
                object result = cmd.ExecuteScalar();
                t.user_rating = (result == null) ? 0 : Convert.ToInt32(result);
            }

            return results.ToArray();
        }

        public static int TranslationAnswerAdd(int user_id, int req_id, string message, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_trans_ans_add", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
            SetStoredProcedureParameter(cmd, "@req_id", SqlDbType.Int, req_id);
            SetStoredProcedureParameter(cmd, "@message", SqlDbType.NText, message);
            object result = cmd.ExecuteScalar();
            return (result == null) ? 0 : Convert.ToInt32(result);
        }

        public static int TranslationRequestAdd(int user_id, int src_lang_id, int dst_lang_id, string subject, string message, int dst_id, TransDstType dst_type, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_trans_req_add", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
            SetStoredProcedureParameter(cmd, "@src_lang_id", SqlDbType.Int, src_lang_id);
            SetStoredProcedureParameter(cmd, "@dst_lang_id", SqlDbType.Int, dst_lang_id);
            SetStoredProcedureParameter(cmd, "@subject", SqlDbType.NVarChar, subject);
            SetStoredProcedureParameter(cmd, "@message", SqlDbType.NText, message);
            SetStoredProcedureParameter(cmd, "@dst_id", SqlDbType.Int, dst_id);
            SetStoredProcedureParameter(cmd, "@dst_type", SqlDbType.TinyInt, dst_type);
            object result = cmd.ExecuteScalar();
            return (result == null) ? 0 : Convert.ToInt32(result);
        }

        public static int TranslationAnswerRate(int user_id, int trans_ans_id, int rating, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_trans_ans_rate_by_id", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
            SetStoredProcedureParameter(cmd, "@trans_ans_id", SqlDbType.Int, trans_ans_id);
            SetStoredProcedureParameter(cmd, "@rating", SqlDbType.Int, rating);
            object result = cmd.ExecuteScalar();
            return (result == null) ? 0 : Convert.ToInt32(result);
        }

        public static int TranslationRequestClose(int user_id, int req_id, int ans_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_trans_req_close", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
            SetStoredProcedureParameter(cmd, "@req_id", SqlDbType.Int, req_id);
            SetStoredProcedureParameter(cmd, "@ans_id", SqlDbType.Int, ans_id);
            object result = cmd.ExecuteScalar();
            return (result == null) ? 0 : Convert.ToInt32(result);
        }
        #endregion

        #region Hall of Fame

        public static UserRank[] HallOfFameByQuantity(int user_id, float interval, int maxresults, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_rank_by_quantity", connection);
            SetStoredProcedureParameter(cmd, "@interval", SqlDbType.Float, interval);

            List<UserRank> users = new List<UserRank>();
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            // Don't need their login date
            while (reader.Read() && i < maxresults)
            {
                User u = new User((int)reader["id"], reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), reader["sn_network"].ToString(), reader["sn_screenname"].ToString(), Convert.ToDateTime(reader["reg_date"]), DateTime.Now, Convert.ToSingle(reader["user_rating"]));
                users.Add(new UserRank(u, Convert.ToSingle(reader["quantity"])));
                i++;
            }
            reader.Close();
            reader.Dispose();

            foreach (UserRank us in users)
            {
                if (user_id == 0)
                {
                    us.user.email = "";
                    us.user.sn_network = "";
                    us.user.sn_screenname = "";
                    us.user.description = "";
                }
                else if (us.user.id != user_id)
                {
                    if (FriendsCheckFriendPair(us.user.id, user_id, connection) == 0)
                    {
                        // Not the profile user's friend, remove contact info
                        us.user.email = "";
                        us.user.sn_network = "";
                        us.user.sn_screenname = "";
                    }
                }
            }

            return users.ToArray();
        }

        public static UserRank[] HallOfFameByRating(int user_id, int maxresults, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_user_rank_by_rating", connection);

            List<UserRank> users = new List<UserRank>();
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            // Don't need their login date
            while (reader.Read() && i < maxresults)
            {
                User u = new User((int)reader["id"], reader["username"].ToString(), reader["name"].ToString(), reader["email"].ToString(), reader["description"].ToString(), reader["sn_network"].ToString(), reader["sn_screenname"].ToString(), Convert.ToDateTime(reader["reg_date"]), DateTime.Now, Convert.ToSingle(reader["user_rating"]));
                users.Add(new UserRank(u, Convert.ToSingle(reader["user_rating"])));
                i++;
            }
            reader.Close();
            reader.Dispose();

            foreach (UserRank us in users)
            {
                if (user_id == 0)
                {
                    us.user.email = "";
                    us.user.sn_network = "";
                    us.user.sn_screenname = "";
                    us.user.description = "";
                }
                else if (us.user.id != user_id)
                {
                    if (FriendsCheckFriendPair(us.user.id, user_id, connection) == 0)
                    {
                        // Not the profile user's friend, remove contact info
                        us.user.email = "";
                        us.user.sn_network = "";
                        us.user.sn_screenname = "";
                    }
                }
            }
            return users.ToArray();
        }

        #endregion

        #region Message
        public static Message[] MessageGetReceivedForUser(int user_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_message_recv_by_user", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Message> result = new List<Message>();
            while (reader.Read())
            {
                result.Add(new Message(Convert.ToInt32(reader["id"]),
                                        Convert.ToInt32(reader["src_id"]), "",
                                        Convert.ToInt32(reader["dst_id"]), "",
                                        (MsgDstType)Convert.ToInt32(reader["dst_type"]),
                                        Convert.ToString(reader["subject"]),
                                        "",
                                        Convert.ToDateTime(reader["date"]),
                                        Convert.ToBoolean(reader["unread"])));
            }
            reader.Close();
            reader.Dispose();

            return result.ToArray();
        }
        public static Message[] MessageGetSentForUser(int user_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_message_sent_by_user", connection);
            SetStoredProcedureParameter(cmd, "@user_id", SqlDbType.Int, user_id);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Message> result = new List<Message>();
            while (reader.Read())
            {
                result.Add(new Message(Convert.ToInt32(reader["id"]),
                                        Convert.ToInt32(reader["src_id"]), "",
                                        Convert.ToInt32(reader["dst_id"]), "",
                                        (MsgDstType)Convert.ToInt32(reader["dst_type"]),
                                        Convert.ToString(reader["subject"]),
                                        "",
                                        Convert.ToDateTime(reader["date"]),
                                        Convert.ToBoolean(reader["unread"])));
            }
            reader.Close();
            reader.Dispose();

            return result.ToArray();
        }

        public static Message MessageGetById(int msg_id, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_message_get_by_id", connection);
            SetStoredProcedureParameter(cmd, "@msg_id", SqlDbType.Int, msg_id);
            SqlDataReader reader = cmd.ExecuteReader();
            Message result = null;
            if (reader.Read())
            {
                result = (new Message(Convert.ToInt32(reader["id"]),
                                        Convert.ToInt32(reader["src_id"]), "",
                                        Convert.ToInt32(reader["dst_id"]), "",
                                        (MsgDstType)Convert.ToInt32(reader["dst_type"]),
                                        Convert.ToString(reader["subject"]),
                                        Convert.ToString(reader["body"]),
                                        Convert.ToDateTime(reader["date"]),
                                        Convert.ToBoolean(reader["unread"])));
            }
            reader.Close();
            reader.Dispose();

            return result;
        }

        public static int MessageSend(int user_id, int dst_id, MsgDstType dst_type, string subject, string body, Connection connection)
        {
            SqlCommand cmd = GetStoredProcedure("omni_message_send_user", connection);
            SetStoredProcedureParameter(cmd, "@src_id", SqlDbType.Int, user_id);
            SetStoredProcedureParameter(cmd, "@dst_id", SqlDbType.Int, dst_id);
            SetStoredProcedureParameter(cmd, "@dst_type", SqlDbType.Int, dst_type);
            SetStoredProcedureParameter(cmd, "@subject", SqlDbType.NVarChar, subject);
            SetStoredProcedureParameter(cmd, "@body", SqlDbType.NText, body);
            object result = cmd.ExecuteScalar();
            return (result == null) ? 0 : Convert.ToInt32(result);
        }

        #endregion


    }
}
