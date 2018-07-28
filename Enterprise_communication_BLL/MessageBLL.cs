using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise_communication_model;
using Enterprise_communication_DAL;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Enterprise_communication_BLL
{
    public class MessageBLL
    {


        public bool SendMessage(Message message)
        {
            User receiver = new User();
            UserDAL userDAL = new UserDAL();
            receiver = userDAL.GetUserByUserId(message.Receiverid);
            message.State = receiver.State;
            if (receiver.State == 1)
            {
            //发送消息到服务端
            IPAddress ip = IPAddress.Parse(IP.Ipaddress);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            String text = receiver.Id+"###"+message.Content+"###"+message.Sendtype.ToString()+"###"+message.Userid;
            //设定服务器IP地址  
            try
            {
            clientSocket.Connect(new IPEndPoint(ip, IP.Port)); //配置服务器IP与端口  

            }
            catch
            {
                message.State = 0;
                return false;
            }
            clientSocket.Send(Encoding.ASCII.GetBytes(text));
            }
            MessageDAL messageDAL = new MessageDAL();
            messageDAL.AddMessage(message);
            return true;
        }

        public List<Message> GetSomeMessages(User sender,User receiver,int n)
        {
            MessageDAL dal = new MessageDAL();
            return  dal.GetSomeMessage(sender, receiver, n);
        }

       

    }
}
