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

namespace Enterprise_communication
{
    /// <summary>
    /// OneToOne.xaml 的交互逻辑
    /// </summary>
    public partial class OneToOne : Window
    {
        User sender,receiver;
        public OneToOne(User user1,User user2)
        {
            InitializeComponent();
            sender = user1;
            receiver = user2;
            this.Topmost = true;
        }

        private void btnSendFile_Click(object sender, RoutedEventArgs e) //发送文件
        {

        }

        private void btnVidio_Click(object sender, RoutedEventArgs e) //视频
        {

        }

        private void btnSendMessage_Click(object sender, RoutedEventArgs e) //发送消息
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e) //返回主界面
        {

        }
    }
}