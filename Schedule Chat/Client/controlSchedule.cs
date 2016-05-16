using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Client
{

    class controlSchedule
    {
        scheduleDB schedule;
        private DataTable dt;
        private int chat_num;

        public controlSchedule()
        {

        }

        public controlSchedule(int chat_num)
        {
            this.chat_num = chat_num;
        }

        public void updateRegister(String myid, String EventText, String EventContent, String EventDate, String EventLength, int chat_num)
        {
            schedule = new scheduleDB();
            schedule.setInsertSQL(myid, EventText, EventContent, EventDate, EventLength, chat_num);
            try
            {
                schedule.openDB();
                schedule.ExecuteSQL(schedule.getInsertSQL().ToString());
            }
            catch (Exception ex)
            {
                schedule.closeDB();
            }
            Console.ReadLine();
        }

        public DataTable returnSchedule()
        {
            schedule = new scheduleDB(this.chat_num);
            this.dt = new DataTable();
            DataRow row = null;
            try
            {
                schedule.setSelectSQL();
                schedule.openDB();
                var Reader = schedule.ExecuteReader(schedule.getSelectSQL().ToString());

                dt.Clear();

                dt.Columns.Add("idx", typeof(int));

                dt.Columns.Add("user_id", typeof(string));

                dt.Columns.Add("start_date", typeof(DateTime));

                dt.Columns.Add("end_date", typeof(DateTime));

                dt.Columns.Add("sc_title", typeof(string));

                dt.Columns.Add("sc_content", typeof(string));

                dt.Columns.Add("chat_num", typeof(int));

                dt.AcceptChanges();

                while (Reader.Read())
                {
                    row = dt.NewRow(); //행 추가      
                    row["idx"] = Reader[0].ToString();
                    row["user_id"] = Reader[1].ToString();
                    row["start_date"] = Reader[2].ToString();//"2015-12-03";
                    row["end_date"] = Reader[3].ToString();
                    row["sc_title"] = Reader[4].ToString();
                    row["sc_content"] = Reader[5].ToString();
                    row["chat_num"] = Reader[6].ToString();

                    dt.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                schedule.closeDB();
            }
            Console.ReadLine();

            return this.dt;
        }
    }
}
