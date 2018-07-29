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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Enterprise_communication_model;
using Enterprise_communication_BLL;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Enterprise_communication
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public User user = new User();
        DeptBLL deptbll = new DeptBLL();
        UserBLL userbll = new UserBLL();
        List<Department> DepartmentsList = new List<Department>();
        List<User> UserList = new List<User>();
        List<Group> GroupsList = new List<Group>();
        Socket clientSocket;
        public MainWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            double workHeight = SystemParameters.WorkArea.Height;
            double workWidth = SystemParameters.WorkArea.Width;
            this.Top = (workHeight - this.Height) / 2;
            this.Left = (workWidth - this.Width) / 2;
            RefreshSelf();
            RefreshUser();
            RefreshGroup();
            ConnectToServer();
        }
        public void ConnectToServer()
        {
            IPAddress ip = IPAddress.Parse(IP.Ipaddress);
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(ip, IP.Port));
            String text = user.Id + "###" + "success" + "###" + "0" + "###" + user.Id;
            clientSocket.Send(Encoding.ASCII.GetBytes(text));
            Thread receiveThread = new Thread(ReceiveMessage);
            receiveThread.Start(clientSocket);
        }

        public void ReceiveMessage(object clientSocket)
        {
            Socket connection = (Socket)clientSocket;
            while (true)
            {
                try
                {
                    //接受数据
                    byte[] result = new byte[1024];
                    //通过clientSocket接收数据  
                    int receiveNumber = connection.Receive(result);
                    //把接受的数据从字节类型转化为字符类型
                    String recStr = Encoding.ASCII.GetString(result, 0, receiveNumber);
                    //[0]发送者ID [1]消息内容 [2]消息类型
                    string[] StrArr = System.Text.RegularExpressions.Regex.Split(recStr, "###");
                    if (recStr != string.Empty)
                    {
                        if (StrArr[2] != "4"&& StrArr[2] != "5"&&StrArr[2] != "6")
                        {
                            User chatuser = new User();
                            userbll.GetUserByID(Convert.ToInt32(StrArr[0]), out chatuser);
                            //MessageBox.Show("收到来自" + chatuser.Name + "的新消息");
                            this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                                (ThreadStart)delegate ()
                                {
                                    RefreshUser();
                                    int i;
                                    for (i = 0; i < App.list.Count; i++)
                                    {
                                        OneToOne o = App.list[i];
                                        if (o.msgreceiver.Name == chatuser.Name)
                                        {
                                            if (StrArr[2] == "3")
                                            {
                                                o.n = 0;
                                                o.RefreshMessage();
                                            }
                                            else
                                            {
                                                string msg = "\n" + chatuser.Name + "    " + DateTime.Now.ToString() + "\n" + StrArr[1] + "\n";
                                                o.ShowMessage.AppendText(msg);
                                                o.ShowMessage.ScrollToEnd();
                                                o.msgscroll.ScrollToEnd();
                                            }
                                            
                                            break;
                                        }
                                    }
                                    if (i >= App.list.Count)
                                    {
                                        OneToOne one = new OneToOne(user, chatuser, connection);
                                        App.list.Add(one);
                                        one.Show();
                                    }
                                });

                        }
                        else if(StrArr[3]!=user.Id.ToString())
                        {
                            GroupBLL groupBLL = new GroupBLL();
                            List<Group> groups = new List<Group>();
                            groups = groupBLL.GetGroupListByUserId(user.Id);
                            foreach (Group g in groups)
                            {
                                if (g.Id == Convert.ToInt32(StrArr[0]))
                                {
                                    //MessageBox.Show("收到来自" + g.Name + "的新消息");
                                    this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                                (ThreadStart)delegate ()
                                {
                                    RefreshUser();
                                    int i;
                                    for (i = 0; i < App.list2.Count; i++)
                                    {
                                        OneToManyWindow o = App.list2[i];
                                        if (o.group.Id == g.Id)
                                        {
                                            if(StrArr[2] == "6")
                                            {
                                                o.n = 0;
                                                o.RefreshGroupMessage();
                                            }
                                            else
                                            {
                                                UserBLL userBLL = new UserBLL();
                                                User temp = null;
                                                userBLL.GetUserByID(Convert.ToInt32(StrArr[3]), out temp);
                                                string msg = "\n" + temp.Name + "    " + DateTime.Now.ToString() + "\n" + StrArr[1] + "\n";
                                                o.ShowMessage.AppendText(msg);
                                                o.ShowMessage.ScrollToEnd();
                                                o.msgscroll.ScrollToEnd();
                                            }
                                            break;
                                        }
                                    }
                                    if (i >= App.list2.Count)
                                    {
                                        OneToManyWindow many = new OneToManyWindow(g, user);
                                        App.list2.Add(many);
                                        many.Show();
                                    }
                                });
                                    break;
                                }
                            }
                        }
                        ConnectToServer();
                    }

                    //    text2.Dispatcher.BeginInvoke(

                    //           new Action(() => { text2.Text += "\r\n" + recStr; }), null);

                    //
                }

                catch (Exception ex)
                {

                    //connection.Shutdown(SocketShutdown.Both);
                    //connection.Close();
                    break;
                }
            }

        }
        private void RefreshSelf()
        {
            MemoryStream buf = new MemoryStream(user.Avatar);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = buf;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            buf.Dispose();
            Avatar.Source = bitmapImage;
            Name.Content = user.Name;
        }
        private void RefreshUser()
        {
            departmentTree.Items.Clear();
            DepartmentsList = deptbll.GetDepartmentsList();
            UserList = userbll.GetUsersList();
            //this.departmentTree.ItemsSource = GetTrees(0, GetNodes());//数据绑定
            foreach (Department d in DepartmentsList)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = d.Name;
                foreach (User u in UserList)
                {
                    if (u.Deptid != d.Id || u.Id == user.Id)
                        continue;
                    Button button = new Button();
                    StackPanel stack1 = new StackPanel();
                    Image image = new Image();
                    StackPanel stack2 = new StackPanel();
                    Label label1 = new Label();
                    Label label2 = new Label();
                    label1.Content = u.Name;
                    label2.Content = u.State == 1 ? "在线" : "离线";
                    label1.FontSize = 20;
                    label2.FontSize = 20;
                    label1.Foreground = Brushes.Black;
                    label2.Foreground = Brushes.Black;
                    stack2.Children.Add(label1);
                    stack2.Children.Add(label2);
                    stack2.VerticalAlignment = VerticalAlignment.Center;
                    MemoryStream ms = new MemoryStream(u.Avatar);
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = ms;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    ms.Dispose();
                    image.Source = bitmap;
                    image.MaxHeight = 80;
                    image.MaxWidth = 80;
                    stack1.Children.Add(image);
                    stack1.Children.Add(stack2);
                    stack1.Orientation = Orientation.Horizontal;
                    button.Content = stack1;
                    button.Name = u.Username;
                    button.BorderThickness = new Thickness(0);
                    button.MinWidth = 60;
                    button.Background = Brushes.White;
                    button.Margin = new Thickness(5);
                    button.MouseDoubleClick += Chat_Click;
                    item.Items.Add(button);
                }
                departmentTree.Items.Add(item);
            }
        }
        private void RefreshGroup()
        {
            for (int i = GroupList.Items.Count - 1; i >= 1; i--)
            {
                GroupList.Items.RemoveAt(i);
            }

            GroupBLL groupbll = new GroupBLL();
            GroupsList = groupbll.GetGroupListByUserId(user.Id);
            foreach (Group p in GroupsList)
            {
                Image groupimage = new Image();
                groupimage.Source = new BitmapImage(new Uri("images\\214743981.jpg", UriKind.Relative));
                Label grouplabel = new Label();
                StackPanel groupstack = new StackPanel();
                groupimage.MaxHeight = 50;
                groupimage.MaxWidth = 50;
                grouplabel.VerticalContentAlignment = VerticalAlignment.Center;
                grouplabel.Content = p.Name;
                groupstack.Orientation = Orientation.Horizontal;
                groupstack.Children.Add(groupimage);
                groupstack.Children.Add(grouplabel);
                Button groupbutton = new Button();
                groupbutton.Background = Brushes.White;
                groupbutton.Content = groupstack;
                groupbutton.Margin = new Thickness(10);
                groupbutton.Name = "no_" + p.Id.ToString();
                groupbutton.BorderThickness = new Thickness(0);
                groupbutton.MouseDoubleClick += GroupChat_Click;
                GroupList.Items.Add(groupbutton);
            }
        }

        //public List<NodeModel> GetNodes()
        //{
        //    List<NodeModel> dplst = new List<NodeModel>();
        //    int i, j;
        //    for (i = 0; i < DepartmentsList.Count; i++)
        //        dplst.Add(new NodeModel() { Id = DepartmentsList[i].Id, Name = DepartmentsList[i].Name, ParentId = 0, Avatar = null, State = string.Empty, Visibility1 = "Visible", Visibility2 = "Collapsed" });
        //    for (j = 0; j < UserList.Count; j++)
        //    {
        //        if (UserList[j].Username == user.Username)
        //            continue;
        //        string state = UserList[j].State == 1 ? "在线" : "离线";
        //        MemoryStream buf = new MemoryStream(UserList[j].Avatar);
        //        BitmapImage bitmapImage = new BitmapImage();
        //        bitmapImage.BeginInit();
        //        bitmapImage.StreamSource = buf;
        //        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        //        bitmapImage.EndInit();
        //        buf.Dispose();
        //        dplst.Add(new NodeModel() { Id = UserList[j].Id, Name = UserList[j].Name, ParentId = UserList[j].Deptid, Avatar = bitmapImage, State = state, Visibility1 = "Collapsed", Visibility2 = "Visible" });
        //    }
        //    return dplst;
        //}

        /// <summary>
        /// 递归生成树形数据
        /// </summary>
        /// <param name="delst"></param>
        /// <returns></returns>
        //public List<NodeModel> GetTrees(int parentid, List<NodeModel> nodes)
        //{
        //    List<NodeModel> mainNodes = nodes.Where(x => x.ParentId == parentid).ToList<NodeModel>();
        //    List<NodeModel> otherNodes = nodes.Where(x => x.ParentId != parentid).ToList<NodeModel>();
        //    foreach (NodeModel dpt in mainNodes)
        //    {
        //        dpt.Nodes = GetTrees(dpt.Id, otherNodes);
        //    }
        //    return mainNodes;
        //}

        private void Create_Group_Click(object sender, RoutedEventArgs e)
        {
            SelectGroupUser s = new SelectGroupUser(this);
            s.ShowDialog();
            RefreshGroup();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            UserBLL bll = new UserBLL();
            bll.Logout(user);
            System.Environment.Exit(0);
            Application.Current.Shutdown();
        }

        private void TbxInput_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnSearch.Focus();
                BtnSearch_Click(null, null);
            }

        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (TreeViewItem b in departmentTree.Items)
            {
                foreach (var d in b.Items)
                    if (d is Button)
                    {
                        Button g = (Button)d;
                        if (TbxInput.Text == g.Name)
                        {
                            if (!b.IsExpanded)
                            {
                                b.IsExpanded = true;
                            }
                            g.Focus();
                            break;
                        }
                    }
            }
        }

        private void Chat_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            User user2 = null;
            UserBLL bll = new UserBLL();
            bll.GetUserByUsername(button.Name, out user2);
            if (user2 == null)
            {
                MessageBox.Show("此用户已被删除!");
                return;
            }
            OneToOne one = new OneToOne(user, user2, clientSocket);
            App.list.Add(one);
            one.Show();
        }
        private void GroupChat_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Group group = null;
            GroupBLL bll = new GroupBLL();
            bll.GetGroupByID(Convert.ToInt32(button.Name.Split('_')[1]), out group);
            if (group == null)
            {
                MessageBox.Show("此群已被删除!");
                return;
            }
            OneToManyWindow onetomany = new OneToManyWindow(group, user);
            App.list2.Add(onetomany);
            onetomany.Show();
        }


        private void SelfInfo_Click(object sender, RoutedEventArgs e)
        {
            UserInfo userInfo = new UserInfo(user);
            userInfo.ShowDialog();
            userbll.GetUserByUsername(user.Username, out user);
            RefreshSelf();
        }
    }
    //public class NodeModel
    //{
    //    public List<NodeModel> Nodes { get; set; }
    //    public NodeModel()
    //    {
    //        this.Nodes = new List<NodeModel>();
    //        this.ParentId = 0;//主节点的父id默认为0
    //    }
    //    public int Id { get; set; }//id
    //    public string Name { get; set; }//部门名称
    //    public int ParentId { get; set; }//父类id
    //    public BitmapImage Avatar { get; set; }
    //    public string State { get; set; }
    //    public string Visibility1 { get; set; } = "Visible";
    //    public string Visibility2 { get; set; } = "Collapsed";
    //}

}

