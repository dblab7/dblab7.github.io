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
using System.Threading;
using System.IO;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
//using Calendar.NETDemo;

namespace Client
{
    public partial class ReceiverChatView : Form
    {
        ReceiveView form2;

        private TcpClient client;
        private NetworkStream myStream;
        private StreamReader myRead;
        private StreamWriter myWrite;
        private Boolean ClientCon = false;
        private Thread myReader;
        private string myid, ip, content, frid, chat_num;

        private delegate void AddTextDelgate(string strText);
        private AddTextDelgate AddText = null;

        public ReceiverChatView(ReceiveView obj)
        {
            InitializeComponent();
            form2 = obj;
        }
        public string chatNum()
        {
            return form2.chatNum();
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            AddText = new AddTextDelgate(MessageView);
            myid = form2.myid();
            ip = form2.friendip();
            chat_num = chatNum();
            if (!(this.ClientCon))
            {

                try
                {
                    client = new TcpClient(this.ip, 2009);
                    Invoke(AddText, "1:1 대화를 시작합니다.");
                    myStream = client.GetStream();

                    myRead = new StreamReader(myStream);
                    myWrite = new StreamWriter(myStream);
                    this.ClientCon = true;

                    myReader = new Thread(Receive);
                    myReader.Start();
                    connectMsg_send();
                }
                catch { }

            }
        }
        private void MessageView(string strText)
        {
            this.rc_txt.AppendText(strText + "\r\n");
            this.rc_txt.Focus();
            this.rc_txt.ScrollToCaret();
            this.tx_com.Focus();
        }
        private void Receive()
        {
            try
            {

                while (this.ClientCon)
                {

                    if (myStream.CanRead)
                    {
                        var msg = myRead.ReadLine();
                        if (msg == "1")
                        {
                            Invoke(AddText, "상대방이 대화를 중지하였습니다.");
                            ClientCon = false;
                        }
                        else
                        {
                            var Smsg = msg.Split('&');
                            if (msg.Length > 0)
                            {
                                Invoke(AddText, Smsg[0] + " : " + Smsg[1]);     //Smsg[0] 상대방 ID
                            }
                            this.statusStrip1.Text = "마지막으로 받은 시각 : " + Smsg[2];
                        }
                    }

                }

            }
            catch { }
        }

        private void tx_com_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (this.tx_com.Text == "")
                {
                    this.tx_com.Focus();
                }
                else
                {
                    Msg_send();
                }
            }
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            if (this.tx_com.Text == "")
            {
                this.tx_com.Focus();
            }
            else
            {
                Msg_send();
            }
        }
        private void connectMsg_send()
        {
            content = this.tx_com.Text;
            try
            {
                var dt = Convert.ToString(DateTime.Now);
                myWrite.WriteLine(this.myid + "&" + this.myid + " 와 연결되었습니다." + "&" + dt + "&" + this.chat_num);
                myWrite.Flush();
                //MessageView(this.myid + " : " + this.tx_com.Text);
                controlChatting chat = new controlChatting();
                chat.updateChat(this.myid, this.content);
                this.tx_com.Clear();
            }
            catch
            {
                Invoke(AddText, "데이터를 보내는 동안 오류가 발생하였습니다");
                this.tx_com.Clear();
            }
        }
        private void Msg_send()
        {
            content = this.tx_com.Text;
            try
            {
                var dt = Convert.ToString(DateTime.Now);
                myWrite.WriteLine(this.myid + "&" + this.tx_com.Text + "&" + dt);
                myWrite.Flush();
                MessageView(this.myid + " : " + this.tx_com.Text);
                controlChatting chat = new controlChatting();
                chat.updateChat(this.myid, this.content);
                this.tx_com.Clear();
            }
            catch
            {
                Invoke(AddText, "데이터를 보내는 동안 오류가 발생하였습니다");
                this.tx_com.Clear();
            }
        }

        private void 닫기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.client.Connected)
                {
                    var dt = Convert.ToString(DateTime.Now);
                    myWrite.WriteLine(this.myid + "&" + "채팅이 종료되었습니다." + "&" + dt);
                    myWrite.Flush();
                }
            }
            catch { }
            this.Close();
        }
        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnection();
        }
        private void Disconnection()
        {
            this.ClientCon = false;
            try
            {
                if (!(myRead == null))
                {
                    myRead.Close();
                }
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
                if (!(myReader == null))
                {
                    myReader.Abort();
                }
            }
            catch
            {
                return;
            }
        }

        private void 도움말ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frid = form2.frID();
            var Schedule = new ScheduleWindow(chat_num, myid, frid);
            Schedule.ShowDialog();
        }


        private void bt_exit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.client.Connected)
                {
                    var dt = Convert.ToString(DateTime.Now);
                    myWrite.WriteLine(this.myid + "&" + "채팅이 종료되었습니다." + "&" + dt);
                    myWrite.Flush();
                }
            }
            catch { }
            this.Close();
        }

    }
}