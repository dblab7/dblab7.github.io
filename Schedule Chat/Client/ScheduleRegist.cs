using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Calendar.NET;

namespace Client
{
    public partial class ScheduleDelete : Form
    {
       
        private string EventText, EventContent, EventDate, EventLength;
        private string myid;
        private int chat_num;
        private DateTime nowDay = DateTime.Now;
        public ScheduleDelete(string myid, int chat_num)
        {
            InitializeComponent();
            this.myid = myid;
            this.chat_num = chat_num;

            dateTimePicker2.Value = nowDay;
            for (int i = 1; i <= 20; i++)
                lengthEvent.Items.Add(i);
        }
        
        private void btnModaless_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModal_Click(object sender, EventArgs e)
        {
            if (txtSampleText.Text == "" || textBox5.Text == "" || lengthEvent.Text == "")
            {
                MessageBox.Show("일정정보를 입력해주세요.", "등록오류", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtSampleText.Text = "";
                textBox5.Text = "";
                lengthEvent.Text = "";
            }
            else
            {
                this.EventText = txtSampleText.Text;
                this.EventContent = textBox5.Text;
                this.EventDate = dateTimePicker2.Value.ToString("yyyy-M-d");
                this.EventLength = lengthEvent.Text;



                controlSchedule schedule = new controlSchedule();
                schedule.updateRegister(this.myid, this.EventText, this.EventContent, this.EventDate, this.EventLength, this.chat_num);

                this.Close();
            }
        }
    }
}
