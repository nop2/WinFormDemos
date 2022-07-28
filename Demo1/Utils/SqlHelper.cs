using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Utils
{
    internal class SqlHelper
    {
        public static string ConStr { get; set; }

        /// <summary>
        /// 查询数据库
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns>数据表</returns>
        public static DataTable ExecuteTable(string cmdText)
        {
            using var sqlConnection = new SqlConnection(ConStr);
            sqlConnection.Open();
            var sqlCommand = new SqlCommand(cmdText,sqlConnection);
            var sda = new SqlDataAdapter(sqlCommand);
            var dataSet = new DataSet();
            sda.Fill(dataSet);
            return dataSet.Tables[0];
        }

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns>受影响行数</returns>
        /// <exception cref="Exception"></exception>
        public static int ExecuteNonQuery(string cmdText)
        {
            using var sqlConnection = new SqlConnection(ConStr);
            sqlConnection.Open();
            var sqlCommand = new SqlCommand(cmdText, sqlConnection);
            var rows = sqlCommand.ExecuteNonQuery();
            if (rows <= 0)
            {
                throw new Exception("数据库操作失败");
            }
            return rows;
        }

    }
}
