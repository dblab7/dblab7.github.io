using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Client
{
    class controlFriend
    {
        private friendDB fr;

        public String showFriend(String inputID) // 1: Success, 2: Already Login ID, 3: Wrong Password, 4: Wrong ID
        {
            string result;

            fr = new friendDB();
            fr.setSelectFriendSQL(inputID);
            fr.openDB();
            var myRead = fr.ExecuteReader(fr.getSQL().ToString());
            myRead.Read();
            result = myRead["friend"].ToString();
            fr.closeDB();

            return result;
        }

        public int isFriend(String friendID, String myID) // 1. 친구추가 성공 / 2. 자기 자신 등록 / 3. 중복 등록 / 4. 친구추가 실패
        {

            // 이미 등록된 사용자를 찾아봄
            fr = new friendDB();
            fr.setSelectFriendSQL(myID);
            fr.openDB();
            var myRead = fr.ExecuteReader(fr.getSQL().ToString());
            myRead.Read();

            var friends = myRead["friend"].ToString();
            var friendl = friends.Split('&');

            for (int j = 0; j < friendl.Length; j++)
            {
                if (friendID == myID)
                    return 2;
                if (friendl[j] == friendID)
                    return 3;
            }
            //////////////////
            fr.closeDB();

            fr.setSelectIdSQL(friendID);
            fr.openDB();
            myRead = fr.ExecuteReader(fr.getSQL().ToString());
            if (myRead.HasRows)
            { // 없는 친구도 등록됨 << 수정해야함
                fr.closeDB();
                return 1;
            }

            fr.closeDB();
            return 4;
        }

        public void updateFriend(String inputID, String friendList)
        {
            fr = new friendDB();
            fr.setUpdateSQL(inputID, friendList);
            fr.openDB();
            fr.ExecuteSQL(fr.getSQL().ToString());
            fr.closeDB();
        }

        public int deleteFriend(string inputID, string friend)
        {
            int del = 0;
            string delfriend = "";
            fr = new friendDB();
            fr.setSelectFriendSQL(inputID);
            fr.openDB();
            var myRead = fr.ExecuteReader(fr.getSQL().ToString());
            if (myRead.Read())
            {
                var friends = myRead["friend"].ToString();
                var friendl = friends.Split('&');

                for (int j = 0; j < friendl.Length; j++) //지우는 배열 번지수 알아내는 구문
                {

                    if (friendl[j] == friend)
                    {
                        del = j;
                    }
                }
                if (del == 0) //첫번째 친구가 삭제대상일때
                {
                    if (friendl.Length == 1)
                    {
                        delfriend = "";
                    }
                    else
                    {
                        delfriend += friendl[1];
                        for (int j = 2; j < friendl.Length; j++)
                        {
                            delfriend += "&" + friendl[j];
                        }
                    }
                }
                else if (del == friendl.Length - 1) // 마지막 친구가 삭제대상일때
                {
                    for (int j = 0; j < friendl.Length - 2; j++)
                    {
                        delfriend += friendl[j] + "&";
                    }
                    delfriend += friendl[friendl.Length - 2];
                }
                else //그외 대상일때
                {
                    delfriend += friendl[0];
                    for (int j = 1; j < friendl.Length; j++)
                    {
                        if (!(del == j))
                        {
                            delfriend += "&" + friendl[j];
                        }
                    }
                }
                this.updateFriend(inputID, delfriend);
            }
            fr.closeDB();
            return 1;
        }

        public int addFriend(string inputID, string friend, string friendlist)
        {


            fr = new friendDB();
            fr.setSelectFriendSQL(inputID);
            fr.openDB();
            var myRead = fr.ExecuteReader(fr.getSQL().ToString());
            myRead.Read();
            if (!(null == myRead["friend"].ToString()))
            {
                friendlist += "&" + friend;
            }
            else
            {
                friendlist += friend;
            }
            fr.closeDB();
            this.updateFriend(inputID, friendlist);

            return 1;
        }


    }
}
