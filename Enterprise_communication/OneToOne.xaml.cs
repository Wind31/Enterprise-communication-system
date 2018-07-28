﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Enterprise_communication_model;
using Enterprise_communication_BLL;
using System.Net.Sockets;

namespace Enterprise_communication
{
    /// <summary>
    /// OneToOne.xaml 的交互逻辑
    /// </summary>
    public partial class OneToOne : Window
    {
        public User msgsender = new User();
        public User msgreceiver =new User();
        int n = 0;
        MessageBLL bll = new MessageBLL();
        List<Message> messages = new List<Message>();
        Socket clientSocket;
        public OneToOne(User user1,User user2,Socket socket)
        {
            InitializeComponent();
            msgsender = user1;
            msgreceiver = user2;
            clientSocket = socket;
            this.Topmost = true;
            chattingname.Content = msgreceiver.Name;
            RefreshMessage();
        }
        public void RefreshMessage()
        {
            ShowMessage.Text = "";
            n += 10;
            messages.Clear();
            messages = bll.GetSomeMessages(msgsender, msgreceiver, n);
            foreach (Message m in messages)
            {
                UserBLL userBLL = new UserBLL();
                User temp = null;
                userBLL.GetUserByID(m.Userid, out temp);
                string msg = "\n" + temp.Name + "    " + m.Sendtime.ToString() + "\n" + m.Content + "\n";
                ShowMessage.AppendText(msg);
            }
            ShowMessage.ScrollToEnd();
            msgscroll.ScrollToEnd();
        }
        private void btnSendFile_Click(object sender, RoutedEventArgs e) //发送文件
        {

        }

        private void btnVidio_Click(object sender, RoutedEventArgs e) //视频
        {

        }

        private void btnSendMessage_Click(object sender, RoutedEventArgs e) //发送消息
        {
            if (sendmsg.Text == string.Empty)
            {
                MessageBox.Show("消息不能为空");
                return;
            }
            Message message = new Message();
            message.Content = sendmsg.Text;
            message.Userid = msgsender.Id;
            message.Receiverid = msgreceiver.Id;
            message.Sendtype = 1;
            message.Sendtime = DateTime.Now;
            MessageBLL bLL = new MessageBLL();
            if (!bLL.SendMessage(message))
            {
                MessageBox.Show("服务器异常");
            }
            else
            {
                string msg = "\n"+msgsender.Name + "    " + message.Sendtime.ToString() + "\n" + message.Content+"\n";
                ShowMessage.AppendText(msg);
                sendmsg.Text = "";
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e) //返回主界面
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            App.list.Remove(this);
        }

        private void btnCheckRe_Click(object sender, RoutedEventArgs e)
        {
            RefreshMessage();
        }
    }
}
