using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using Enterprise_communication_model;
using Enterprise_communication_BLL;

namespace Enterprise_communication
{
    /// <summary>
    /// RegisterWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            DeptBLL bll = new DeptBLL();
            List<Department> departments = new List<Department>();
            departments = bll.GetDepartmentsList();
            departments.Insert(0,new Department(0, "--请选择分类--"));
            depName.ItemsSource = departments;
            depName.DisplayMemberPath = "Name";
            depName.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e) //注册取消返回登录界面
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void Choose_Avatar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "图片|*.jpg;*.png;*.gif;*.bmp;*.jpeg";
            Nullable<bool> result = op.ShowDialog();
            if (result == true)
            {
                string file = op.FileName;
                AvatarPath.Text = file;
                BitmapImage image = new BitmapImage(new Uri(file));
                userAvatar.Source = image;

            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if(depName.SelectedIndex == 0)
            {
                MessageBox.Show("请选择部门");
                return;
            }
            if(boy.IsChecked==false&&girl.IsChecked==false)
            {
                MessageBox.Show("请选择性别");
                return;
            }
            if (pbPwd.Password!= surepbPwd.Password)
            {
                MessageBox.Show("两次输入的密码不一致");
                return;
            }
            User user = new User();
            byte[] img = File.ReadAllBytes(AvatarPath.Text);
            user.Id = 0;
            user.Deptid=Convert.ToInt32(depName.SelectedIndex);
            user.Worknum = Convert.ToInt32(numName.Text);
            user.Name = realName.Text;
            user.Username=userName.Text;
            user.Password=surepbPwd.Password;
            user.Gender=(boy.IsChecked==true)?1:0;
            user.Phone= pbPhone.Text;
            user.Position= posiName.Text;
            user.State=0;
            user.Control=0;
            user.Ipaddress="0.0.0.0";
            user.Check=0;
            user.Avatar=img;
            UserBLL bll = new UserBLL();
            if(bll.Register(user))
            {
                MessageBox.Show("注册成功，等待管理员审核");
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("注册失败，用户名已存在");
                userName.Focus();
            }
        }
    }
}
