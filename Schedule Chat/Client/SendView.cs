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

namespace Client
{

    public partial class SendView : Form
    {
        Clients form1;
        private TcpClient client;
        private string comm;
        private StreamWriter myWrite;
        private NetworkStream myStream;

        private string sfriend, id;
        private string myip;
        private IPHostEntry host;

        public SendView(Clients obj)
        {
            InitializeComponent();
            form1 = obj;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.sfriend = form1.form3_friendip();
            this.id = form1.myid();
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            MessageSend();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
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
        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tx_com_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Alt)
            {
                if (e.KeyCode == Keys.S)
                {
                    MessageSend();
                }
            }
        }
        private void MessageSend()
        {
            try
            {
                host = Dns.Resolve(Dns.GetHostName());
                client = new TcpClient(sfriend, 2008);
                comm = this.tx_com.Text;
                // -------------
                controlChatting ctrlchat = new controlChatting();
                if (this.checkBox1.Checked == true)
                {
                    ctrlchat.sendChat(host, client, comm, id, false);
                    SenderChatView form6 = new SenderChatView(this);
                    form6.Show();
                }
                else
                {
                    ctrlchat.sendChat(host, client, comm, id, true);
                }
                // --------------
                /*SenderChatView form6 = new SenderChatView(this);
                form6.Show();*/ // 위쪽의 if문 안으로 넣음.
            }
            catch { MessageBox.Show("상대방이 오프라인 상태입니다!", "전송실패", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            this.Close();
        }
        public string myid()
        {
            return this.id;
        }


    }
}
