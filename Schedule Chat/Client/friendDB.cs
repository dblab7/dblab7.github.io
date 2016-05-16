using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class friendDB : controlDB
    {
        private string friendSQL;

        public string getSQL()
        {
            return friendSQL;
        }

        public void setSelectFriendSQL(string inputID)
        {
            friendSQL = "select friend from userlist where id ='" + inputID + "'";
        }

        public void setSelectIdSQL(string inputID)
        {
            friendSQL = "select id from userlist where id ='" + inputID + "'";
        }

        public void setUpdateSQL(string inputID, string friendList)
        {
            friendSQL = "update userlist set friend = '" + friendList + "' where id='" + inputID + "'";
        }


    }
}
