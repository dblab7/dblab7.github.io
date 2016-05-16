using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;//텍스트 창 띄우기 위함
using MySql.Data.MySqlClient;

namespace Client
{
    class chattingDB : controlDB
    {
        private string chatSQL;

        public string getSQL()
        {
            return chatSQL;
        }

        public void setInsertSQL(String inputID, String inputMSG)
        {
            chatSQL = "insert into chat(uname, content, date) values('" + inputID + "', '" + inputMSG + "', now())";
        }

        public void setSelectCheckSQL(String inputUser1, String inputUser2) // 처음 개설 되는 채팅방인지 확인하는 SQL
        {
            chatSQL = "select count(*) CNT from chatlist where (user1 = '" + inputUser1 + "' and user2 = '" + inputUser2 + "') or (user2 = '" + inputUser1 + "' and user1 = '" + inputUser2 + "')";
        }

        public void setInsertCheckSQL(String inputUser1, String inputUser2) // 처음 개설 확인되면 정보를 넣는 SQL
        {
            chatSQL = "insert into chatlist (user1, user2) values ('" + inputUser1 + "', '" + inputUser2 + "')";
        }

        public void setSelectExistSQL(String inputUser1, String inputUser2) // 존재하는 채팅방 번호 불러오는 SQL
        {
            chatSQL = "select chat_num from chatlist where (user1 = '" + inputUser1 + "' and user2 = '" + inputUser2 + "') or (user2 = '" + inputUser1 + "' and user1 = '" + inputUser2 + "')";
        }
    }
}
