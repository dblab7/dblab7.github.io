using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Calendar.NET;
using MySql.Data.MySqlClient;

namespace Client
{
    public partial class ScheduleWindow : Form
    {
        private DataTable dt;
        private controlSchedule schedule;
        private CustomEvent[,] ce;
        private Calendar.NET.Calendar calendar;
        private int chat_num;
        private string myid;
        private string frid;

        [CustomRecurringFunction("RehabDates", "Calculates which days I should be getting Rehab")]
        private bool RehabDays(IEvent evnt, DateTime day)
        {
            if (day.DayOfWeek == DayOfWeek.Monday || day.DayOfWeek == DayOfWeek.Friday)
            {
                if (day.Ticks >= (new DateTime(2012, 7, 1)).Ticks)
                    return false;
                return true;
            }
            return false;
        }

        public ScheduleWindow(string chatNum, string myID, string frID)
        {
            InitializeComponent();
            this.chat_num = Int32.Parse(chatNum);
            this.myid = myID;
            this.frid = frID;
            dt = new DataTable();
            schedule = new controlSchedule(chat_num);
            dt = schedule.returnSchedule();
            ce = new CustomEvent[dt.Rows.Count, 20];
            myBox.BackColor = Color.FromArgb(255, 224, 140);
            frBox.BackColor = Color.FromArgb(178, 204, 255);
            calendar = this.viewSchedule();
            //calender.RemoveEvent(ce[0, 0]);
            //calender.RemoveEvent(ce[0, 1]);
            //clearSchedule(calender);
        }

        private void clearSchedule(Calendar.NET.Calendar calendar)
        {
            for (int i = 0; i < dt.Rows.Count; i++) //4까지 총 4행
            {
                var date_start = System.DateTime.Parse(dt.Rows[i][2].ToString());
                var date_end = System.DateTime.Parse(dt.Rows[i][3].ToString());
                var date_sub = date_end - date_start;
                TimeSpan ts = date_end - date_start;
                int length_date_a = ts.Days + 1;
                var year = Int32.Parse(date_start.ToString("yyyy"));
                var month = Int32.Parse(date_start.ToString("MM"));
                var date1 = Int32.Parse(date_start.ToString("dd"));
                var date2 = Int32.Parse(date_end.ToString("dd"));
                var length_date = date2 - date1 + 1;

                var user_id = dt.Rows[i]["user_id"].ToString();

                for (int j = 0; j < length_date; j++)
                {

                    calendar.RemoveEvent(ce[i, j]);
                }

            }
        }

        private Calendar.NET.Calendar viewSchedule()
        {
            dt = new DataTable();
            schedule = new controlSchedule(chat_num);
            //schedule = new controlRegister();
            dt = schedule.returnSchedule();
            ce = new CustomEvent[dt.Rows.Count, 20];

            //textBox1.AppendText(dt.Rows[1]["start_date"].ToString());
            //int todayYear = Int32.Parse(System.DateTime.Now.ToString("yyyy"));
            //int todayMonth = Int32.Parse(System.DateTime.Now.ToString("mm"));
            for (int i = 0; i < dt.Rows.Count; i++) 
            {
                var date_start = System.DateTime.Parse(dt.Rows[i][2].ToString());
                var date_end = System.DateTime.Parse(dt.Rows[i][3].ToString());
                var date_sub = date_end - date_start;
                TimeSpan ts = date_end - date_start;
                int length_date_a = ts.Days + 1;
                var year = Int32.Parse(date_start.ToString("yyyy"));
                var month = Int32.Parse(date_start.ToString("MM"));
                var date1 = Int32.Parse(date_start.ToString("dd"));
                var date2 = Int32.Parse(date_end.ToString("dd"));
                var length_date = date2 - date1 + 1;
                var user_id = dt.Rows[i]["user_id"].ToString();


                if (user_id == this.myid)
                {
                    for (int j = 0; j < length_date; j++)
                    {
                        ce[i, j] = new CustomEvent
                        {
                            IgnoreTimeComponent = false,
                            EventText = dt.Rows[i]["sc_title"].ToString(),
                            Date = new DateTime(year, month, date1 + j, 0, 0, 0),
                            EventLengthInHours = 2f,
                            RecurringFrequency = RecurringFrequencies.None,
                            EventFont = new Font("Verdana", 12, FontStyle.Regular),
                            Enabled = true,
                            EventColor = Color.FromArgb(255, 224, 140),
                            EventTextColor = Color.Black,
                            ThisDayForwardOnly = true
                        };
                        calendar1.AddEvent(ce[i, j]);
                        //calendar1.RemoveEvent(ce[i, j]);
                    }
                }
                else if(user_id == this.frid) { 
                    for (int j = 0; j < length_date; j++)
                    {
                        ce[i, j] = new CustomEvent
                        {
                            IgnoreTimeComponent = false,
                            EventText = dt.Rows[i]["sc_title"].ToString(),
                            Date = new DateTime(year, month, date1 + j, 0, 0, 0),
                            EventLengthInHours = 2f,
                            RecurringFrequency = RecurringFrequencies.None,
                            EventFont = new Font("Verdana", 12, FontStyle.Regular),
                            Enabled = true,
                            EventColor = Color.FromArgb(178, 204, 255),
                            EventTextColor = Color.Black,
                            ThisDayForwardOnly = true
                        };
                        calendar1.AddEvent(ce[i, j]);
                        //calendar1.RemoveEvent(ce[i, j]);
                    }
                }

                /*
                for (int j = 0; j < length_date ; j++) { 
                ce[i, j] = new CustomEvent
                {
                    IgnoreTimeComponent = false,
                    EventText = dt.Rows[i]["sc_title"].ToString(),
                    Date = new DateTime(year, month, date1 + j, 18, 0, 0),
                    EventLengthInHours = 2f,
                    RecurringFrequency = RecurringFrequencies.None,
                    EventFont = new Font("Verdana", 12, FontStyle.Regular),
                    Enabled = true,
                    EventColor = Color.FromArgb(120, 255, 120),
                    EventTextColor = Color.Black,
                    ThisDayForwardOnly = true
                };
                calendar1.AddEvent(ce[i, j]);
                }
                */

            }




            calendar1.CalendarDate = new DateTime(2015, 12, 2, 0, 0, 0);
            calendar1.CalendarView = CalendarViews.Month;
            calendar1.AllowEditingEvents = true;

            var groundhogEvent = new HolidayEvent
            {
                Date = new DateTime(2012, 2, 2),
                EventText = "Groundhog Day",
                RecurringFrequency = RecurringFrequencies.Yearly
            };

            calendar1.AddEvent(groundhogEvent);

            var exerciseEvent = new CustomEvent
            {
                Date = DateTime.Now,
                RecurringFrequency = RecurringFrequencies.EveryMonWedFri,
                EventLengthInHours = 1,
                EventText = "Time for Exercise!"
            };


            //calendar1.AddEvent(exerciseEvent);


            var rehabEvent = new CustomEvent
            {
                Date = DateTime.Now,
                RecurringFrequency = RecurringFrequencies.Custom,
                EventText = "Rehab Therapy",
                Rank = 3,
                CustomRecurringFunction = RehabDays
            };

            calendar1.AddEvent(rehabEvent);



            return calendar1;
        }

        [CustomRecurringFunction("Get Monday and Wednesday", "Selects the Monday and Wednesday of each month")]
        public bool GetMondayAndWednesday(IEvent evnt, DateTime dt)
        {
            if (dt.DayOfWeek == DayOfWeek.Monday || dt.DayOfWeek == DayOfWeek.Wednesday)
                return true;
            return false;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            this.clearSchedule(calendar);
            this.viewSchedule();
        }

        private void register_Click(object sender, EventArgs e)
        {
            var Form2 = new ScheduleDelete(this.myid, this.chat_num);
            //Form Form2 = new Form();
            //Form2.Owner = this;
            Form2.Text = "Modal Form";
            Form2.Width = 376;
            Form2.Height = 494;
            Form2.ShowDialog();

            if (Form2.DialogResult == DialogResult.Cancel)
            {
                Form2.Dispose();

                this.clearSchedule(calendar);
                this.viewSchedule();
            }
        }
    }
}
