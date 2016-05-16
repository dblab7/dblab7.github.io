using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class loginDB : controlDB
    {
        String loginSQL;

        public string getSQL()
        {
            return loginSQL;
        }

        public void setSelectSQL(string inputID)
        {
            loginSQL = "select id, pwd, onout from userlist where id ='" + inputID + "'";
        }

        public void setUpdateSQL(string inputID)
        {
            loginSQL = "update userlist set onout = 'on' where id = '" + inputID + "'";
        }

        public void setIPSQL(string inputID)
        {
            IPHostEntry host = Dns.Resolve(Dns.GetHostName());
            string myip = host.AddressList[0].ToString();

            loginSQL = "update userlist set address = '" + myip + "', onout = 'on' where id='" + inputID + "'";
        }

    }
}
