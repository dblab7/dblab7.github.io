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
    public partial class Clients : Form
    {
        private TcpListener Server;
        private TcpClient SerClient;
        private NetworkStream myStream;
        private StreamReader myRead;
        private StreamWriter myWrite;
        private Boolean Start = false;
        private Boolean ClientCon = false;
        private string id, psw, msg, friend, friendip;  //id = 자신의 아이디, psw = 비밀번호, friend = 친구리스트, friendip = 친구아이피주소

        private Thread myReader, myServer;

        public Clients()
        {
            InitializeComponent();
        }

  
        private void b_login_Click(object sender, EventArgs e) //로그인과정
        {

            this.id = this.tx_id.Text;
            this.psw = this.tx_psw.Text;

            if ((id == "") || (psw == ""))
            {
                MessageBox.Show("아이디나 패스워드를 입력하세요", "접속오류", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                controlLogin loginCheck = new controlLogin();
                int seperate = loginCheck.checkLogin(id, psw);
                if (seperate == 1)
                {
                    MessageBox.Show("로그인 성공");

                    loginCheck.ipupdate(id);
                    showMain(id);
                }
                else if (seperate == 2)
                {
                    MessageBox.Show("이미 접속중인 아이디입니다.", "접속오류", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (seperate == 3)
                {
                    MessageBox.Show("패스워드가 틀립니다!", "접속오류", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("일치하는 아이디가 없습니다!.", "접속오류", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }

        }

        public void showMain(string id)
        {
            controlFriend friendCheck = new controlFriend();
          
            this.p_login.Visible = false;
            this.p_join.Visible = false;
            this.로그아웃ToolStripMenuItem.Enabled = true;
            this.친구추가ToolStripMenuItem.Enabled = true;

            
            friend = friendCheck.showFriend(id);

            var friendl = friend.Split('&');

            for (int i = 0; i < friendl.Length; i++) // 친구목록을 트리리스트에 옮겨놓는과정
            {
                this.tree_friend.Nodes.Add(friendl[i]);
            }

            if (!(this.Start))
            {
                try
                {
                    var addr = new IPAddress(0);
                    Server = new TcpListener(addr, 2008);
                    Server.Start();
                    this.Start = true;

                    myServer = new Thread(ServerStart);
                    myServer.Start();
                }
                catch { }
            }
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

        private void Receive() //메시지를 받는 과정
        {
            try
            {

                while (this.ClientCon)
                {

                    if (myStream.CanRead)
                    {
                        msg = myRead.ReadToEnd();

                        var form2 = new ReceiveView(this);
                        msg += "&" + this.id;
                        form2.ShowDialog();
                        this.ClientCon = false;
                    }

                }

            }
            catch { }

        }

        private void ServerStop() //서버를 닫는 함수
        {
            controlLogout lgout = new controlLogout();
            lgout.logOut(this.id);

            this.Start = false;
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

        private void Cilent_FormClosing(object sender, FormClosingEventArgs e)
        {
            ServerStop();
        }

        private void tree_friend_DoubleClick(object sender, EventArgs e) //메시지를 보내기위한 준비과정
        {

            int sep;
            var sfriend = this.tree_friend.SelectedNode.Text;
            var frm3 = new SendView(this);

            controlMessage msg = new controlMessage();

            sep = msg.checkUser(sfriend);

            if (sep == 1)
            {
                friendip = msg.checkIP(sfriend);
                frm3.Show();
            }
            else { MessageBox.Show("상대가 로그아웃 상태입니다!", "알림", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.p_login.Visible = false;
        }

        private void bt_back_Click(object sender, EventArgs e)
        {
            this.p_login.Visible = true;
            this.tx_pwd2.Clear();
            this.tx_pwd1.Clear();
            this.tx_join.Clear();
        }

        private void bt_join_Click(object sender, EventArgs e) // 회원가입을 하는 과정
        {
            string id = this.tx_join.Text;
            string pwd = this.tx_pwd1.Text;
            string pwd2 = this.tx_pwd2.Text;
            int seperate;

            controlJoin join = new controlJoin();

            seperate = join.checkJoin(id, pwd, pwd2);

            if (seperate == 1)
            {
                MessageBox.Show("가입이 정상적으로 처리되었습니다!", "가입성공", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (seperate == 2)
            {
                MessageBox.Show("비밀번호를 재확인 해주세요!", "가입오류", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (seperate == 3)
            {
                MessageBox.Show("비밀번호를 입력하지 않으셨습니다!", "가입오류", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (seperate == 4)
            {
                MessageBox.Show("동일한 계정이 존재합니다!", "가입오류", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("다시 시도해 주십시요!", "가입오류", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            this.tx_pwd2.Clear();
            this.tx_pwd1.Clear();
            this.tx_join.Clear();
        }



        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e) //로그아웃하는 과정
        {

            if (MessageBox.Show("정말 로그아웃 하시겠습니까?", "로그아웃 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.ServerStop();
                logout();
            }

        }

        private void logout()
        {
            this.p_join.Visible = true;
            this.p_login.Visible = true;
            this.로그아웃ToolStripMenuItem.Enabled = false;
            this.친구삭제ToolStripMenuItem.Enabled = false;
            this.친구추가ToolStripMenuItem.Enabled = false;
            this.tree_friend.Nodes.Clear();
            this.tx_psw.Clear();
        }


        private void tree_friend_Click(object sender, EventArgs e) //친구를 클릭했을때의 '친구삭제'컨트롤 활성화과정
        {
            this.친구삭제ToolStripMenuItem.Enabled = true;

        }

        private void 친구삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            var node = this.tree_friend.SelectedNode;
            string friend = node.Text;
            this.tree_friend.Nodes.Remove(node);
            int sep;

            controlFriend delFriend = new controlFriend();
            sep = delFriend.deleteFriend(this.id, friend);

            if (sep == 1)
            { MessageBox.Show("친구가 정상적으로 삭제되었습니다!", "삭제성공", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            else
            { MessageBox.Show("친구가 삭제되지 않았습니다!", "삭제오류", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }
       
        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 친구추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlFriend fr = new controlFriend();
            friend = fr.showFriend(this.id);

            AddFriendView frm4 = new AddFriendView(this);

            frm4.readfriend += new AddFriendView.appfriend(frm4_readfriend);
            frm4.ShowDialog();

        }
        private void frm4_readfriend(string friend) // 아래 문장을 적어줍니다. Form2에서 날라온 추가된 친구를 부모폼(Form1)의 트리노드에 추가합니다.
        {
            this.tree_friend.Nodes.Add(friend);

        }
        public string frm4_friendlist() //친구리스트 레퍼런스 Form4 넘겨주기
        {
            return friend;
        }
        public string myid()  //자신의 아이디를 레퍼런스로 Form4, Form3에 넘겨주기
        {
            return this.id;
        }
        public string form3_friendip() //상대방 아이피주소를 레퍼런스로 Form3에 넘겨주기
        {
            return this.friendip;
        }
        public string messages() //레퍼런스로 Form2에 메시지 전달하기
        {
            return msg;
        }

        private void bt_reset_Click(object sender, EventArgs e)
        {
            this.tx_pwd2.Clear();
            this.tx_pwd1.Clear();
            this.tx_join.Clear();
        }
    }
}