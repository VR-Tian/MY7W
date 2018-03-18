using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MY7W.ADONET
{
    public class SQLHelper
    {
        private string ConnectionAddressKey;
        public SQLHelper(string ConfigName)
        {
            ConnectionAddressKey = ConfigurationManager.AppSettings[ConfigName];
        }
        public int ExecuteNonQuery(string sqlStr,System.Data.CommandType type,params SqlParameter[] param)
        {
            using (SqlConnection conn=new SqlConnection(ConnectionAddressKey))
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    conn.Open();
                    comm.CommandType = type;
                    comm.CommandText = sqlStr;
                    comm.Parameters.AddRange(param);
                    return comm.ExecuteNonQuery();
                }
            }
        }

        public DataSet ExecuteQueryAll(string sqlStr, System.Data.CommandType type, params SqlParameter[] param)
        {
            DataSet set = new DataSet();
            using(SqlDataAdapter adpater=new SqlDataAdapter(sqlStr, ConnectionAddressKey))
            {
                adpater.SelectCommand.CommandText = sqlStr;
                adpater.SelectCommand.CommandType = type;
                adpater.SelectCommand.Parameters.AddRange(param);
                adpater.Fill(set);
            }
            return set;
        }
    }
}
