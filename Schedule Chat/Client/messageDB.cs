using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class messageDB : controlDB
    {
        string msgSQL;

        public string getSQL()
        {
            return msgSQL;
        }

        public void setSelectSQL(string inputFriend)
        {
            msgSQL = "select address, onout from userlist where id='" + inputFriend + "'";
        }
    }
}
