using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class controlJoin
    {
        private joinDB join;

        public void joinUser(string inputID, string inputPWD)
        {
            join = new joinDB();
            join.setInsertSQL(inputID, inputPWD);
            join.openDB();
            join.ExecuteSQL(join.getSQL().ToString());
            join.closeDB();
        }

        public int checkJoin(String inputID, String inputPWD, String inputPWD2) // 1 : success join, 2 : re-confirm password, 3: non input password, 4 : exist id
        {

            join = new joinDB();
            join.setSelectSQL(inputID);
            join.openDB();
            var myRead = join.ExecuteReader(join.getSQL().ToString());
            myRead.Read();
            //String empty = myRead["id"].ToString();

            join.closeDB();
            if (!(myRead.HasRows))//&& (empty != inputID))
            {
                if (!(inputPWD == "" || inputPWD2 == ""))
                {
                    if (inputPWD == inputPWD2)
                    {
                        this.joinUser(inputID, inputPWD);
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    return 3;
                }
                join.closeDB();
            }
            else
            {
                return 4;
            }
            return 5;

        }

    }
}
