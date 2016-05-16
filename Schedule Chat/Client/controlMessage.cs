using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class controlMessage
    {
        private messageDB msg;

        public int checkUser(string inputFriend)
        {
            msg = new messageDB();
            msg.setSelectSQL(inputFriend);
            msg.openDB();
            var myRead = msg.ExecuteReader(msg.getSQL().ToString());
            myRead.Read();
            string onout = myRead["onout"].ToString();
            msg.closeDB();
            if ("on" == onout)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public string checkIP(string inputFriend)
        {
            string ip;
            msg = new messageDB();
            msg.setSelectSQL(inputFriend);
            msg.openDB();
            var myRead = msg.ExecuteReader(msg.getSQL().ToString());
            myRead.Read();
            ip = myRead["address"].ToString();
            msg.closeDB();

            return ip;
        }
    }
}
