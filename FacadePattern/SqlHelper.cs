using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    public abstract class Sqlhelper
    {
        //读取配置文件连接字符串
        private static readonly string connStr = System.Configuration.ConfigurationManager.AppSettings["connStr"].ToString();

        protected static int ExecuteNonQuery(string cmdText, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = cmdText;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        protected static object ExecuteScalar(string cmdText, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = cmdText;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        protected static DataTable ExecuteDataTable(string cmdText, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = cmdText;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.AddRange(parameters);
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        protected static DataSet ExecuteDataSet(string cmdText, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = cmdText;
                    cmd.CommandTimeout = 3000;
                    cmd.Parameters.AddRange(parameters);
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        DataSet dt = new DataSet();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        protected static OleDbDataReader ExecuteDataReader(string cmdText, params OleDbParameter[] parameters)
        {
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            using (OleDbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = cmdText;
                cmd.CommandTimeout = 3000;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
    }
}
