using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class joinDB : controlDB
    {
        private string joinSQL;

        public string getSQL()
        {
            return joinSQL;
        }

        public void setSelectSQL(string inputID)
        {
            joinSQL = "select id from userlist where id = '" + inputID + "'";
        }

        public void setInsertSQL(string inputID, string inputPWD)
        {
            joinSQL = "insert into userlist(id, pwd) values('" + inputID + "', '" + inputPWD + "')";
        }

    }
}
