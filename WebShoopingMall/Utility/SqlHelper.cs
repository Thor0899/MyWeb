using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebShoopingMall.Utility
{
    public class SqlHelper
    {
        public static string ConStr { get; set; }

        public static DataTable ExecuteTable(string comText, params SqlParameter[] sqlParameters)
        {
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(comText, conn);
                cmd.Parameters.AddRange(sqlParameters);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                return ds.Tables[0];
            }
        }
    }
}
