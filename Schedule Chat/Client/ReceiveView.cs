using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    public partial class ReceiveView : Form
    {
        Clients form1;
        private string[] Smsg;
        private TcpClient client;
        private StreamWriter myWrite;
        private NetworkStream myStream;
        private string myID, frid;
        private string chat_num;

        public ReceiveView(Clients obj)
        {
            InitializeComponent();
            form1 = obj;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string msg = form1.messages();
            Smsg = msg.Split('&');
            frid = Smsg[0];

            var t_comm = Smsg[1].Split('\n');
            for (int i = 0; i < t_comm.Length; i++)
            {
                this.tx_com.AppendText(t_comm[i] + "\r\n");
            }
            this.Text = Smsg[0] + "님 께서 보내신 메시지입니다.";
            this.s_time.Text = Smsg[2];
            if (Smsg[4] == "2")
            {
                this.bt_ok.Visible = true;
                this.tx_com.AppendText("\r\n\r\n\r\n" + Smsg[0] + "님께서 1:1 대화를 신청하셨습니다.");
            }

        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_resend_Click(object sender, EventArgs e)
        {
            ReSendShow();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.tx_com.Clear();
        }
        public string friendip()
        {
            return Smsg[3];
        }
        public string myid()
        {
            return form1.myid();
        }
        public string frID()
        {
            return this.frid;
        }

        private void tx_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt)
            {
                if (e.KeyCode == Keys.R)
                {
                    ReSendShow();
                }
            }
        }
        private void ReSendShow()
        {
            try
            {
                var frm5 = new ReplyView(this);
                frm5.ShowDialog();
                this.Close();

            }
            catch { MessageBox.Show("왜안열려", "접속오류", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }
        /*수락 받는 순간 발생 이벤트
              * 2015-1208 02:13 한대호가 수정
              * 수락 받는 순간 처음 채팅하는지 아닌지 판별 기능 */
        private void bt_ok_Click(object sender, EventArgs e)
        {
            myID = myid();
            controlChatting ch = new controlChatting();
            chat_num = ch.informChat(myID, frid);
            ReceiverChatView form7 = new ReceiverChatView(this);
            form7.ShowDialog();
            this.Close();
        }
        public string chatNum()
        {
            return this.chat_num;
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!(myWrite == null))
                {
                    myWrite.Close();
                }
                if (!(myStream == null))
                {
                    myStream.Close();
                }
                if (!(client == null))
                {
                    client.Close();
                }
            }
            catch
            {
                return;
            }
        }
    }
}