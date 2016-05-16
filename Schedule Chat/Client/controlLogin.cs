using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class controlLogin
    {
        private loginDB lg;

        public void ipupdate(string inputID)
        {
            lg = new loginDB();
            lg.setIPSQL(inputID);
            lg.openDB();
            lg.ExecuteSQL(lg.getSQL().ToString());
            lg.closeDB();

        }

        public int checkLogin(String inputID, String inputPWD) // 1: Success, 2: Already Login ID, 3: Wrong Password, 4: Wrong ID
        {
            lg = new loginDB();
            lg.setSelectSQL(inputID);
            lg.openDB();
            var myRead = lg.ExecuteReader(lg.getSQL().ToString());

            if (myRead.HasRows)
            {
                if (myRead.Read())
                {
                    if (myRead["pwd"].ToString() == inputPWD)
                    {
                        if (myRead["onout"].ToString() == "on")
                        {
                            return 2;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    else { return 3; }
                }
            }
            else
            { return 4; }
            lg.closeDB();
            return 0;
        }
    }

}
