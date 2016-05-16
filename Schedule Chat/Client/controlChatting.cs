using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Client
{

    class controlChatting
    {
        private TcpClient client;
        private string comm;
        private StreamWriter myWrite;
        private NetworkStream myStream;
        private string sfriend, id;
        private string myip;


        chattingDB chat;
        public void sendChat(IPHostEntry host, TcpClient client, string comm, string id, Boolean isMsg)
        {
            myip = host.AddressList[0].ToString();
            myStream = client.GetStream();
            myWrite = new StreamWriter(myStream);
            var dt = Convert.ToString(DateTime.Now);

            if (isMsg)
            {
                myWrite.Write(id + "&" + comm + "&" + dt + "&" + myip + "&1");
            }
            else
            {
                myWrite.Write(id + "&" + comm + "&" + dt + "&" + myip + "&2");
            }
            myWrite.Flush();

        }
        public void updateChat(String inputID, String Content)
        {
            chat = new chattingDB();
            chat.setInsertSQL(inputID, Content);

            chat.openDB();
            chat.ExecuteSQL(chat.getSQL().ToString());
            chat.closeDB();
        }
        public string checkInitChat(String inputUser1, String inputUser2)
        {
            string result;
            chat = new chattingDB();
            chat.setSelectCheckSQL(inputUser1, inputUser2);
            chat.openDB();
            var myRead = chat.ExecuteReader(chat.getSQL().ToString());
            myRead.Read();
            result = myRead["CNT"].ToString();
            chat.closeDB();

            return result;
        }

        public string informChat(String inputUser1, String inputUser2)
        {
            string result;
            chat = new chattingDB();

            if (this.checkInitChat(inputUser1, inputUser2) == "1")
            {
                chat.setSelectExistSQL(inputUser1, inputUser2);
                chat.openDB();
                var myRead = chat.ExecuteReader(chat.getSQL().ToString());
                myRead.Read();
                result = myRead["chat_num"].ToString();
                chat.closeDB();

                return result;
            }
            else
            {
                chat.setInsertCheckSQL(inputUser1, inputUser2);
                chat.openDB();
                chat.ExecuteSQL(chat.getSQL().ToString());
                chat.setSelectExistSQL(inputUser1, inputUser2);
                var myRead = chat.ExecuteReader(chat.getSQL().ToString());
                myRead.Read();
                result = myRead["chat_num"].ToString();
                chat.closeDB();

                return result;
            }
        }
    }
}
