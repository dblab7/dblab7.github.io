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

    public partial class ReplyView : Form
    {
        ReceiveView form2;
        private TcpClient client;
        private string comm;
        private StreamWriter myWrite;
        private NetworkStream myStream;

        private string sfriend, id;
        private string myip;
        IPHostEntry host;

        public ReplyView(ReceiveView obj)
        {
            InitializeComponent();
            form2 = obj;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.sfriend = form2.friendip();
            this.id = form2.myid();
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            MessageSend();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
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
                ctrlchat.sendChat(host, client, comm, id, true);
                //---------------
            }
            catch { MessageBox.Show("상대방이 오프라인 상태입니다!", "전송실패", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            this.Close();
        }
    }
}
