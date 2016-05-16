using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Client
{
    public partial class AddFriendView : Form
    {
        Clients form1;
        private string friend, friendlist, id;
        public delegate void appfriend(string friend);    // string을 반환값으로 같는 대리자를 선언합니다.
        public event appfriend readfriend;          // 대리자 타입의 이벤트 처리기를 설정합니다. 
        
        public AddFriendView(Clients obj)
        {
            InitializeComponent();
            form1 = obj;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.friendlist = form1.frm4_friendlist();
            this.id = form1.myid();
        }

        private void bt_insert_Click(object sender, EventArgs e)
        {
            int sep;
            friend = tx_friend.Text;
            controlFriend fFriend = new controlFriend();
            sep = fFriend.isFriend(friend, id);

            if (sep == 1) { updatefriend(); }
            else if (sep == 2) { MessageBox.Show("자신은 등록할 수 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            else if (sep == 3) { MessageBox.Show("이미 등록 된 사용자입니다.!", "알림", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            else if (sep == 4) { MessageBox.Show("찾고자 하는 사용자가 존재하지 않습니다!", "알림", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }            
        }

        private void updatefriend()
        {
            int sep;
            controlFriend adFriend = new controlFriend();
            sep = adFriend.addFriend(this.id, friend, friendlist);

            if (sep == 1)
            {
                readfriend(tx_friend.Text); 
                MessageBox.Show("친구가 정상적으로 추가 되었습니다!", "추가성공", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Dispose();
            }
            else
            {
                MessageBox.Show("친구가 추가되지 않았습니다!", "추가오류", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
          
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
