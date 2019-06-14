using DesignModelDemo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    class DatabaseOperationFacade
    {
        QueryForDictionary queryForDictionary;
        QueryForList queryForList;
        Update update;

        public DatabaseOperationFacade()
        {
            queryForDictionary = new QueryForDictionary();
            queryForList = new QueryForList();
            update = new Update();
        }

        public User queryForUser(string userName)
        {
            const string cmdText = "select * from user where user_account = @user_account";
            OleDbParameter[] parameters = {
                new OleDbParameter("@user_account", userName)
            };
            Dictionary<string, object> dic = queryForDictionary.queryForDictionary(cmdText, parameters);
            if (dic == null)
            {
                return null;
            }

            return new User(dic["user_account"].ToString(), dic["user_nickname"].ToString(),
                dic["user_password"].ToString(), (Image)dic["user_img"], dic["user_register_time"].ToString(),
                (int)dic["is_delete"]);
        }

        public List<SongInfo> queryForSongOfList(string tName)
        {
            const string cmdText = "select * from all_local_song inner join @tName on " +
                "all_local_song.pk_song_id = tName.pk_song_id and all_local_song.is_delete = tName.is_delete " +
                "where tName.is_delete = 0";
            OleDbParameter[] parameters = {
                new OleDbParameter("@tName", tName)
            };
            List<SongInfo> songs = new List<SongInfo>();
            List<Dictionary<string, object>> lResult = queryForList.queryForList(cmdText, parameters);
            foreach (Dictionary<string, object> dict in lResult)
            {
                songs.Add(new SongInfo(dict["pk_song_id"].ToString(), dict["song_file_path"].ToString(),
                    dict["lyric_path"].ToString()));
            }
            return songs;
        }

        public void createUserByObject(User user)
        {
            const string cmdText = "insert into user(pk_user_id, user_account, user_nickname, user_password, user_img," +
                "user_register_time, is_delete) values (@pk_user_id, @user_account, @user_nickname, @user_password, " +
                "@user_img, @user_register_time, @is_delete)";

            OleDbParameter[] parameters = {
                new OleDbParameter("@pk_user_id", user.Id),
                new OleDbParameter("@user_account", user.Account),
                new OleDbParameter("@user_nickname", user.Nickname),
                new OleDbParameter("@user_password", user.Password),
                new OleDbParameter("@user_img", user.Img),
                new OleDbParameter("@user_register_time", user.RegisterTime),
                new OleDbParameter("@is_delete", user.IsDelete)
            };
            update.update(cmdText, parameters);
        }

        /// <summary>
        /// 建立新的收藏表（每一个用户单独一个收藏表）
        /// </summary>
        /// <param name="tName"></param>
        /// <returns>返回数据受影响的行数</returns>
        public int createCollectTableByTableName(string tName)
        {
            const string cmdText = "create table @tName ([pk_song_id] text(33) primary key, [is_delete] int)";
            OleDbParameter[] parameters = {
                new OleDbParameter("@tName", tName)
            };
            return update.update(cmdText, parameters);
        }

        /// <summary>
        /// 往数据库中插入歌曲信息（单曲插入）
        /// </summary>
        /// <param name="song"></param>
        /// <param name="tName"></param>
        /// <returns>返回受影响的行数</returns>
        public int insertSongByObjectAndTableName(SongInfo song, string tName)
        {
            const string cmdText0 = "insert into all_local_song(pk_song_id, song_file_path, " +
                "lyric_path, is_delete) values (@pk_song_id, @song_file_path, @lyric_path, @isdelete)";

            const string cmdText1 = "insert into @tName (pk_song_id, is_delete) values " +
                "(@pk_song_id, @isdelete)";

            OleDbParameter[] parameters0 = {
                new OleDbParameter("@pk_song_id", song.Id),
                new OleDbParameter("@song_file_path", song.FilePath),
                new OleDbParameter("@lyric_path", song.LyricPath),
                new OleDbParameter("@is_delete", song.IsDelete)
            };

            OleDbParameter[] parameters1 = {
                new OleDbParameter("@tName", tName),
                new OleDbParameter("@pk_song_id", song.Id),
                new OleDbParameter("@is_delete", song.IsDelete)
            };

            if (tName.Equals("local_list"))
            {
                update.update(cmdText0, parameters0);
            }
            return update.update(cmdText1, parameters1);
        }

        /// <summary>
        /// 往数据库中插入歌曲信息（列表插入）
        /// </summary>
        /// <param name="songs"></param>
        /// <param name="tName"></param>
        /// <returns></returns>
        public void insertSongByListAndTableName(List<SongInfo> songs, string tName)
        {
            const string cmdText0 = "insert into all_local_song(pk_song_id, song_file_path, " +
               "lyric_path, is_delete) values (@pk_song_id, @song_file_path, @lyric_path, @isdelete)";

            const string cmdText1 = "insert into @tName (pk_song_id, is_delete) values " +
                "(@pk_song_id, @isdelete)";

            OleDbParameter[] parameters0 = {
                new OleDbParameter("@pk_song_id", OleDbType.VarWChar, 33),
                new OleDbParameter("@song_file_path", OleDbType.VarWChar),
                new OleDbParameter("@lyric_path", OleDbType.VarWChar),
                new OleDbParameter("@is_delete", OleDbType.Integer, 8)
            };

            OleDbParameter[] parameters1 = {
                new OleDbParameter("@tName", tName),
                new OleDbParameter("@pk_song_id", OleDbType.VarWChar, 33),
                new OleDbParameter("@is_delete", OleDbType.Integer, 8)
            };

            if (tName.Equals("local_list"))
            {
                foreach (SongInfo song in songs)
                {
                    parameters0[0].Value = song.Id;
                    parameters0[1].Value = song.FilePath;
                    parameters0[2].Value = song.LyricPath;
                    parameters0[3].Value = song.IsDelete;
                    update.update(cmdText0, parameters0);
                }
            }

            foreach (SongInfo song in songs)
            {
                parameters1[1].Value = song.Id;
                parameters1[2].Value = song.IsDelete;
                update.update(cmdText1, parameters1);
            }
        }

        public void removeSongByIdAndTableName(string id, string tName)
        {
            const string cmdText = "update @tName set is_delete = @is_delete where pk_song_id = @pk_song_id";

            OleDbParameter[] parameters = {
                    new OleDbParameter("@tName", tName),
                    new OleDbParameter("@is_delete", 1),
                    new OleDbParameter("@pk_song_id", id)
            };
            update.update(cmdText, parameters);
            if(tName.Equals("local_list"))
            {
                parameters[0].Value = "all_song_list";
                update.update(cmdText, parameters);
            }
        }

        public void deleteSongByIdAndTableName(string id, string tName)
        {
            const string cmdText = "delete form @tName where pk_song_id = @pk_song_id";
            OleDbParameter[] parameters = {
                    new OleDbParameter("@tName", tName),
                    new OleDbParameter("@is_delete", 1),
                    new OleDbParameter("@pk_song_id", id)
            };
            update.update(cmdText, parameters);
            if (tName.Equals("local_list"))
            {
                parameters[0].Value = "all_song_list";
                update.update(cmdText, parameters);
            }
        }

        public void updateSongInfoByObject(SongInfo song)
        {
            const string cmdText = "update all_local_song set lyric_path = @lyric_path where pk_song_id = @pk_song_id";
            OleDbParameter[] parameters = {
                    new OleDbParameter("@lyric_path", song.LyricPath),
                    new OleDbParameter("@pk_song_id", song.Id)
            };
            update.update(cmdText, parameters);
        }
    }

    class QueryForDictionary : Sqlhelper
    {
        public Dictionary<string, object> queryForDictionary(string cmdText, params OleDbParameter[] parameters)
        {
            Dictionary<string, object> dResult = null;
            OleDbDataReader dbReader = ExecuteDataReader(cmdText.ToString(), parameters);
            if(dbReader.Read())
            {
                dResult = new Dictionary<string, object>();
                for (int i = 0; i < dbReader.FieldCount; i++)
                {
                    dResult.Add(dbReader.GetName(i), dbReader.GetValue(i));
                }
                return dResult;
            }
            else
            {
                return null;
            }        
        }
    }

    class QueryForList : Sqlhelper
    {
        public List<Dictionary<string, object> > queryForList(string cmdText, params OleDbParameter[] parameters)
        {
            List<Dictionary<string, object>> lResult = null;
            Dictionary<string, object> dResult = null;
            OleDbDataReader dbReader = ExecuteDataReader(cmdText.ToString(), parameters);
            while(dbReader.Read())
            {
                lResult = new List<Dictionary<string, object>>();
                dResult = new Dictionary<string, object>();
                for (int i = 0; i < dbReader.FieldCount; i++)
                {
                    dResult.Add(dbReader.GetName(i), dbReader.GetValue(i));
                }
                lResult.Add(dResult);
            }
            return lResult;
        }
    }

    class Update : Sqlhelper
    {
        public int update(string cmdText, params OleDbParameter[] parameters)
        {
            int iResult = ExecuteNonQuery(cmdText, parameters);
            return iResult;
        }
    }
}
