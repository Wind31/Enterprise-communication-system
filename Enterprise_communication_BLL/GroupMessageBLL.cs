﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise_communication_model;
using Enterprise_communication_DAL;
using System.Net;
using System.Net.Sockets;

namespace Enterprise_communication_BLL
{
    public class GroupMessageBLL
    {

        public bool SendMessage(GroupMessage message)
        {
            Group group = new Group();
            GroupDAL groupDAL = new GroupDAL();
            group = groupDAL.GetGroupById(message.Groupid);
            message.State = 1;
            //发送消息到服务端
            IPAddress ip = IPAddress.Parse("192.168.103.75");
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            String text = group.Id + "###" + message.Content + "###" + message.Sendtype.ToString() + "###" + message.Userid;
            //设定服务器IP地址  
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, 6002)); //配置服务器IP与端口  

            }
            catch
            {
                message.State = 0;
                return false;
            }
            clientSocket.Send(Encoding.ASCII.GetBytes(text));
            GroupMessageDAL groupmessageDAL = new GroupMessageDAL();
            groupmessageDAL.AddMessage(message);
            return true;
        }

        public List<GroupMessage> GetSomeMessages(Group group, int n)
        {
            GroupMessageDAL dal = new GroupMessageDAL();
            return dal.GetSomeMessage(group, n);
        }
    }
}