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

namespace Enterprise_communication
{
    /// <summary>
    /// SelectGroupUser.xaml 的交互逻辑
    /// </summary>
    public partial class SelectGroupUser : Window
    {
        User user;
        string selfusername;
        bool Allchecked = false;
        List<Department> DepartmentsList = new List<Department>();
        List<User> UserList = new List<User>();
        public SelectGroupUser(MainWindow m)
        {
            InitializeComponent();
            double workHeight = SystemParameters.WorkArea.Height;
            double workWidth = SystemParameters.WorkArea.Width;
            this.Top = (workHeight - this.Height) / 2;
            this.Left = (workWidth - this.Width) / 2;
            this.user = m.user;
            //this.departmentTree.ItemsSource = m.GetTrees(0, m.GetNodes());//数据绑定
            selfusername = m.user.Username;
            DeptBLL deptbll = new DeptBLL();
            DepartmentsList = deptbll.GetDepartmentsList();
            UserBLL userbll = new UserBLL();
            UserList = userbll.GetUsersList();
            //this.departmentTree.ItemsSource = GetTrees(0, GetNodes());//数据绑定
            foreach (Department d in DepartmentsList)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = d.Name;
                foreach (User u in UserList)
                {
                    if (u.Deptid != d.Id || u.Id == m.user.Id)
                        continue;
                    CheckBox check = new CheckBox();
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
                    check.Content = stack1;
                    check.Name = u.Username;
                    check.MinWidth = 60;
                    check.Margin = new Thickness(5);
                    item.Items.Add(check);
                }
                departmentTree.Items.Add(item);
            }
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Complete_Click(object sender, RoutedEventArgs e)
        {
            List<string> users = new List<string>();
            foreach (TreeViewItem b in departmentTree.Items)
            {
                foreach (CheckBox d in b.Items)
                    if (d.IsChecked==true)
                        users.Add(d.Name);
            }
            users.Add(selfusername);
            GroupBLL bll = new GroupBLL();
            int id = bll.CreatGroup(users, GroupName.Text);
            Group group = null;
            bll.GetGroupByID(id, out group);
            if (group!=null)
            {
                OneToManyWindow onetomany = new OneToManyWindow(group,user);
                onetomany.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("系统异常，建群失败");
            }
        }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            Allchecked = !Allchecked;
            foreach (TreeViewItem b in departmentTree.Items)
            {
                foreach (CheckBox d in b.Items)
                    d.IsChecked = Allchecked;
            }
        }
    }
}
