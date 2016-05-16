using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Client
{
    class controlDB
    {
        private string strSQL = "Data Source=supreme2705.iptime.org;Database=chatting;UserId=root;Password=handaeho1";
        MySqlConnection conn;

        public void openDB()
        {
            conn = new MySqlConnection(strSQL);
            conn.Open();
        }

        public void closeDB()
        {
            conn.Close();
        }

        public void ExecuteSQL(string sql)
        {
            var cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        public MySqlDataReader ExecuteReader(string sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            return cmd.ExecuteReader();
        }
    }
}
