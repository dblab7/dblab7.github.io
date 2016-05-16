using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class controlLogout
    {
        private logoutDB lg;

        public void logOut(string inputID)
        {
            lg = new logoutDB();
            lg.openDB();
            lg.setUpdateSQL(inputID);
            lg.ExecuteSQL(lg.getSQL().ToString());
            lg.closeDB();
        }
    }
}
