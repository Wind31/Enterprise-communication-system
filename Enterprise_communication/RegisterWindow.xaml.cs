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
                //userAvatar.Width = image.Width;
                //userAvatar.Height = image.Height;
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (pbPwd.Password!= surepbPwd.Password)
            {
                MessageBox.Show("两次输入的密码不一致");
                return;
            }
            User user = new User();
            byte[] img = File.ReadAllBytes(AvatarPath.Text);
            //string fileName = System.IO.Path.GetFileNameWithoutExtension(AvatarPath.Text);
            user.Id = 0;
            user.Deptid=Convert.ToInt32(depName.Text);
            user.Worknum = Convert.ToInt32(numName.Text);
            user.Name = realName.Text;
            user.Username=userName.Text;
            user.Password=surepbPwd.Password;
            user.Gender=1;
            user.Phone="13700000000";
            user.Position= posiName.Text;
            user.State=0;
            user.Control=0;
            user.Ipaddress="0.0.0.0";
            user.Check=0;
            user.Avatar=img;
            RegisterBLL bll = new RegisterBLL(user);
            if(bll.Register())
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
