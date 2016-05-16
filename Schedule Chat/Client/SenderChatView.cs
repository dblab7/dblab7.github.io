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


namespace Client
{
    public partial class SenderChatView : Form
    {
        SendView form3;        
        private TcpListener Server;
        private TcpClient SerClient, client;
        private NetworkStream myStream;
        private StreamReader myRead;
        private StreamWriter myWrite;
        private Boolean Start = false;
        private Boolean ClientCon = false;
        private Thread myReader, myServer;

        private string myid, ip, content;
        private string chat_num, frid;

        private delegate void AddTextDelgate(string strText);
        private AddTextDelgate AddText = null;

        public SenderChatView(SendView obj)
        {
            InitializeComponent();
            form3 = obj;
        }
        /* 
        public string s_chatNum()
        {
            return this.chat_num;
        }
        public string s_myID()
        {
            return this.myid;
        }
        public string frID()
        {
            return this.frid;
        }
        */
        private void Form6_Load(object sender, EventArgs e)
        {
            AddText = new AddTextDelgate(MessageView);
            this.myid = form3.myid();         
                if (!(this.Start))
                {
                    try
                    {
                        var addr = new IPAddress(0);
                        Server = new TcpListener(addr, 2009);
                        Server.Start();
                        this.Start = true;

                        myServer = new Thread(ServerStart);
                        myServer.Start();
                    }
                    catch { }
                }
                else
                {
                    ServerStop();
                }       
            
        }
        private void MessageView(string strText)
        {
            this.rc_txt.AppendText(strText + "\r\n");
            this.rc_txt.Focus();
            this.rc_txt.ScrollToCaret();
            this.tx_com.Focus();
        }
        private void ServerStart()
        {
            while (Start)
            {
                try
                {
                    SerClient = Server.AcceptTcpClient();
                    myStream = SerClient.GetStream();

                    myRead = new StreamReader(myStream);
                    myWrite = new StreamWriter(myStream);
                    this.ClientCon = true;

                    myReader = new Thread(Receive);
                    myReader.Start();
                }
                catch { }
            }
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
                        var Smsg = msg.Split('&');
                        this.frid = Smsg[0];
                        
                        if (msg.Length > 0)
                        {
                            Invoke(AddText, Smsg[0] + " : " + Smsg[1]);
                        }
                        this.statusStrip1.Text = "마지막으로 받은 시각 : " + Smsg[2];
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
                    if (this.SerClient.Connected)
                    {
                        var dt = Convert.ToString(DateTime.Now);
                        myWrite.WriteLine(this.myid + "&" + "채팅이 종료되었습니다." + "&" + dt);
                        myWrite.Flush();
                    }         
                
            }
            catch { }
            this.Close();
        }

        private void 도움말ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlChatting ch = new controlChatting();
            chat_num = ch.informChat(myid, frid);
            var Schedule = new ScheduleWindow(chat_num, myid, frid);
            Schedule.ShowDialog();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            myWrite.WriteLine("1");
            myWrite.Flush();
            ServerStop();
           
        }
        private void ServerStop()
        {
            this.Start = false;
            this.tx_com.Clear();
            this.ClientCon = false;

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
            if (!(SerClient == null))
            {
                SerClient.Close();
            }
            if (!(Server == null))
            {
                Server.Stop();
            }
            if (!(myReader == null))
            {
                myReader.Abort();
            }
            if (!(myServer == null))
            {
                myServer.Abort();
            }    
        }

        private void bt_exit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SerClient.Connected)
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
