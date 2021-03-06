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
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        User user = new User();
        public LoginWindow()
        {
            InitializeComponent();
            ServerIp.Text = "127.0.0.1";
            ServerPort.Text = "6002";
        }
        //注册
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Hide();
        }
        //取消
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //登录
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string name = UserName.Text;
            string password = passWord.Password; //获取输入的用户名和密码
            ServerIp.IsEnabled = false;
            ServerPort.IsEnabled = false;
            IP.Ipaddress = ServerIp.Text;
            IP.Port = Convert.ToInt32(ServerPort.Text);
            User user = null;
            UserBLL bll = new UserBLL();
            bool flag = false;
            flag = bll.Login(name, password, out user);
            if (flag)
            {
                //不把密码保存在内存中
                //user.Password = null;
                //登录成功记录登录者的信息
                //Common.user = user;
                //登录成功
                //MessageBox.Show("登录成功!");

                if (user.Control == 1) //管理员
                {
                    AdministratorWindow administratorWindow = new AdministratorWindow(user);
                    administratorWindow.Show();
                    this.Hide();
                }
                else
                {
                    if (user.Check == 1) //普通用户且已经审核
                    {
                        MainWindow mainWindow = new MainWindow(user);
                        mainWindow.Show();
                        this.Hide();
                    }
                    else
                    {
                        bll.Logout(user);
                        MessageBox.Show("请等待管理员审核");
                    }
                        
                }

            }
            else
            {
                //登录失败
                MessageBox.Show("用户已登录 或 用户名或密码错误!");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

