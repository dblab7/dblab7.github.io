using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class scheduleDB : controlDB
    {
        string insertScheduleSQL;
        int length;

        string selectScheduleSQL;

        private int chat_num;

        public scheduleDB()
        {
        }

        public scheduleDB(int chat_num)
        {
            this.chat_num = chat_num;
        }

        public string getInsertSQL()
        {
            return insertScheduleSQL;
        }

        public string getSelectSQL()
        {
            return selectScheduleSQL;
        }

        public void setInsertSQL(String myid, String EventText, String EventContent, String EventDate, String EventLength, int chat_num)
        {
            length = int.Parse(EventLength) - 1;
            insertScheduleSQL = "insert into schedule(user_id, start_date, end_date, sc_title, sc_content, chat_num) values('" + myid + "', '" + EventDate + "', adddate( '" + EventDate + "', interval '" + length + "' day), '" + EventText + "', '" + EventContent + "', " + chat_num + ")";
        }

        public void setSelectSQL()
        {
            //string[] array = new string[10];
            //scheduleLength = "select count(*) from schedule";
            //Array.Resize<string>(ref array, Int32.Parse(scheduleLength));
            selectScheduleSQL = "select * from schedule where chat_num = " + chat_num;
        }
    }
}
