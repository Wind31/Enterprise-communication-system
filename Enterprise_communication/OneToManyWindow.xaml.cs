using System;
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
using Microsoft.Win32;

namespace Enterprise_communication
{
    /// <summary>
    /// OneToManyWindow.xaml 的交互逻辑
    /// </summary>
    public partial class OneToManyWindow : Window
    {
        public Group group;
        User msgsender;
        public int n = 0;
        GroupMessageBLL groupmessagebll = new GroupMessageBLL();
        List<GroupMessage> groupmessages = new List<GroupMessage>();
        public OneToManyWindow(Group group,User msgsender)
        {
            InitializeComponent();
            this.group = group;
            this.msgsender = msgsender;
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
            RefreshGroupMessage();
           // memberlist.Items.Add(list);
        }
        public void RefreshGroupMessage()
        {
            ShowMessage.Text = "";
            n = n + 10;
            groupmessages.Clear();
            groupmessages = groupmessagebll.GetSomeMessages(group,n);
            foreach (GroupMessage m in groupmessages)
            {
                UserBLL userBLL = new UserBLL();
                User temp = null;
                userBLL.GetUserByID(m.Userid, out temp);
                if (m.Sendtype == 6)
                {
                    string strArr = m.Content.Substring(m.Content.LastIndexOf('\\') + 1);
                    string filename = ".\\groupfile\\" + strArr;
                    string msg = "\n" + temp.Name + "    " + m.Sendtime.ToString() + "\n" + "文件:" + filename + "\n";
                    ShowMessage.AppendText(msg);
                    if (!Directory.Exists(".\\groupfile\\"))
                    {
                        Directory.CreateDirectory(".\\groupfile\\");
                    }
                    if (!File.Exists(filename))
                    {
                        FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                        fs.Write(m.Sendfile, 0, m.Sendfile.Length);
                        fs.Close();
                    }
                }
                else
                {
                    string msg = "\n" + temp.Name + "    " + m.Sendtime.ToString() + "\n" + m.Content + "\n";
                    ShowMessage.AppendText(msg);
                }
            }
            ShowMessage.ScrollToEnd();
            msgscroll.ScrollToEnd();
        }

        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        
       private void btnCheckRe_Click(object sender, RoutedEventArgs e) //查看历史消息
       {
            RefreshGroupMessage();
       }

       private void btnSendFile_Click(object sender, RoutedEventArgs e) //发送群文件
       {
            OpenFileDialog op = new OpenFileDialog();
            Nullable<bool> result = op.ShowDialog();
            if (result == true)
            {
                string filename = op.FileName;
                sendmsg.Text = filename;
                FileStream fs = new FileStream(@filename, FileMode.Open, FileAccess.Read);
                long FileSize = fs.Length;
                byte[] rawData = new byte[FileSize];
                fs.Read(rawData, 0, (int)FileSize);
                fs.Close();
                GroupMessage message = new GroupMessage();
                message.Content = sendmsg.Text;
                message.Userid = msgsender.Id;
                message.Groupid = group.Id;
                message.Sendtype = 6;
                message.Sendtime = DateTime.Now;
                message.Sendfile = rawData;
                GroupMessageBLL bLL = new GroupMessageBLL();
                if (!bLL.SendMessage(message))
                {
                    MessageBox.Show("服务器异常");
                }
                else
                {
                    string strArr = message.Content.Substring(message.Content.LastIndexOf('\\') + 1);
                    string fname = ".\\groupfile\\" + strArr;
                    string msg = "\n" + msgsender.Name + "    " + message.Sendtime.ToString() + "\n" + "文件: " + fname + "\n";
                    ShowMessage.AppendText(msg);
                    sendmsg.Text = "";
                    ShowMessage.ScrollToEnd();
                    msgscroll.ScrollToEnd();
                }
            }
        }

       private void btnSendMessage_Click(object sender, RoutedEventArgs e) //发送消息
       {
            if (sendmsg.Text == string.Empty)
            {
                MessageBox.Show("消息不能为空");
                return;
            }
            GroupMessage message = new GroupMessage();
            message.Content = sendmsg.Text;
            message.Userid = msgsender.Id;
            message.Groupid = group.Id;
            message.Sendtype = 4;
            message.Sendtime = DateTime.Now;
            message.Sendfile = null;
            GroupMessageBLL bLL = new GroupMessageBLL();
            if (!bLL.SendMessage(message))
            {
                MessageBox.Show("服务器异常");
            }
            else
            {
                string msg = "\n" + msgsender.Name + "    " + message.Sendtime.ToString() + "\n" + message.Content + "\n";
                ShowMessage.AppendText(msg);
                sendmsg.Text = "";
                ShowMessage.ScrollToEnd();
                msgscroll.ScrollToEnd();
            }
        }

       private void btnBack_Click(object sender, RoutedEventArgs e) //返回主界面
       {

       }

        private void Window_Closed(object sender, EventArgs e)
        {
            App.list2.Remove(this);
        }
    }
}