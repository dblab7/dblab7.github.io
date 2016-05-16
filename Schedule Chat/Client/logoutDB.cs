using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class logoutDB : controlDB
    {
        private String logoutSQL;

        public string getSQL()
        {
            return logoutSQL;
        }

        public void setSelectSQL(string inputID)
        {
            logoutSQL = "select id, pwd from userlist where id ='" + inputID + "'";
        }

        public void setUpdateSQL(string inputID)
        {
            logoutSQL = "update userlist set onout = 'out' where id = '" + inputID + "'";
        }
    }
}
