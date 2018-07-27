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
using System.IO;

namespace Enterprise_communication
{
    /// <summary>
    /// OneToManyWindow.xaml 的交互逻辑
    /// </summary>
    public partial class OneToManyWindow : Window
    {
        Group group;
        public OneToManyWindow(Group group)
        {
            InitializeComponent();
            this.group = group;
            Chattingname.Content = group.Name;
            this.Topmost = true;

            List<User> groupmember = new List<User>();
            UserBLL bll = new UserBLL();
            groupmember = bll.GetGroupMeber(group.Id);
            ListBox list = new ListBox();
            Label label = new Label();
            label.Content = "成员列表";
            label.FontSize = 20;
            //list.Items.Add(label);
            memberlist.Items.Add(label);
            foreach (User member in groupmember)
            {
                Image image = new Image();
                MemoryStream ms = new MemoryStream(member.Avatar);
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = ms;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                ms.Dispose();
                image.Source = bitmap;
                Label membername = new Label();
                StackPanel stack = new StackPanel();
                image.MinHeight = 30;
                image.MinWidth = 30;
                image.MaxHeight = 60;
                image.MaxWidth = 60;
                membername.VerticalContentAlignment = VerticalAlignment.Center;
                membername.Content = member.Name;
                stack.Orientation = Orientation.Horizontal;
                stack.Children.Add(image);
                stack.Children.Add(membername);
                memberlist.Items.Add(stack);
                //list.Items.Add(stack);
            }
           // memberlist.Items.Add(list);
        }

        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        /*
       private void btnCheckRe_Click(object sender, RoutedEventArgs e) //查看历史消息
       {

       }

       private void btnSendFile_Click(object sender, RoutedEventArgs e) //发送群文件
       {

       }

       private void btnVidio_Click(object sender, RoutedEventArgs e) //多人视频
       {

       }

       private void btnSendMessage_Click_1(object sender, RoutedEventArgs e) //发送消息
       {

       }

       private void btnBack_Click(object sender, RoutedEventArgs e) //返回主界面
       {

       }*/
    }
}