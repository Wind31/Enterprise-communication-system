﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Enterprise_communication_Server
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        // 创建一个和客户端通信的套接字
        public static TcpListener tcpListener = null;
        public static Hashtable userTable = new Hashtable();
        public MainWindow()
        {
            InitializeComponent();
            IPAddress[] ipArray;
            ipArray = Dns.GetHostAddresses(Dns.GetHostName());
            IPAddress localip = ipArray.First(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            Localip.Text = localip.ToString();
        }

        //监听客户端发来的请求  
        public void ListenClientConnect()
        {
            while (true)
            {
                Socket clientSocket = tcpListener.AcceptSocket();

                //为接受数据创建一个线程
                Thread receiveThread = new Thread(ReceiveMessage);
                receiveThread.Start(clientSocket);
            }
        }
        public void ReceiveMessage(object clientSocket)
        {
            Socket connection = (Socket)clientSocket;
            while (true)
            {
                try
                {
                    byte[] result = new byte[1024];
                    //通过clientSocket接收数据  
                    int receiveNumber = connection.Receive(result);
                    //把接受的数据从字节类型转化为字符类型
                    String recStr = Encoding.UTF8.GetString(result, 0, receiveNumber);
                    ///以###分隔字符串，StrArr[0]是接收者ID，[1]是发送内容,[2]是消息类型,[3]是发送者ID
                    string[] StrArr = Regex.Split(recStr, "###");

                    //获取当前客户端的ip地址
                    IPAddress clientIP = (connection.RemoteEndPoint as IPEndPoint).Address;
                    if (StrArr[2] == "0")
                    {
                        if (userTable.Contains(StrArr[0]))
                            userTable.Remove(StrArr[0]);
                        userTable.Add(StrArr[0], connection);
                    }
                    //获取客户端端口
                    int clientPort = (connection.RemoteEndPoint as IPEndPoint).Port;
                    //接收消息格式 [0]发送者ID [1]发送内容 [2]消息类型
                    //群 [0]群ID [1] 内容 [2]类型
                    String sendStr = StrArr[3] + "###" + StrArr[1] + "###" + StrArr[2];
                    if(StrArr[2] != "0")
                    {
                        if (StrArr[2] != "4" && StrArr[2] != "5" && StrArr[2] != "6")
                        {
                            Socket receiverSocket = userTable[StrArr[0]] as Socket;
                            receiverSocket.Send(Encoding.UTF8.GetBytes(sendStr));
                        }
                        else
                        {
                            foreach (string item in userTable.Keys)
                            {
                                if (item != StrArr[3])
                                {
                                    Socket receiver = userTable[item] as Socket;
                                    receiver.Send(Encoding.UTF8.GetBytes(sendStr + "###" + StrArr[0]));
                                }

                            }
                        }
                    }
                    

                    //显示内容
                    text1.Dispatcher.BeginInvoke(

                            new Action(() => { text1.Text += "\r\n" + sendStr; }), null);

                }
                catch (Exception ex)
                {

                    connection.Shutdown(SocketShutdown.Both);
                    connection.Close();
                    break;
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            tcpListener = new TcpListener(IPAddress.Parse(Localip.Text), Convert.ToInt32(Localport.Text));
            tcpListener.Start();
            Start.Content = "监听中";
            Start.IsEnabled = false;
            Localip.IsEnabled = false;
            Localport.IsEnabled = false;
            Thread myThread = new Thread(ListenClientConnect);
            myThread.Start();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (tcpListener != null)
                tcpListener.Stop();
            if (userTable.Count != 0)
            {
                foreach (Socket Session in userTable.Values)
                {
                    Session.Shutdown(SocketShutdown.Both);
                }
                userTable.Clear();
                userTable = null;
            }
            Environment.Exit(0);
            App.Current.Shutdown();
        }
    }
}
