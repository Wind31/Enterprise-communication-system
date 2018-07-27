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
    /// UserInf_U.xaml 的交互逻辑
    /// </summary>
    public partial class UserInfo : Window
    {
        User user;
        DeptBLL deptbll = new DeptBLL();
        UserBLL userbll = new UserBLL();
        public UserInfo(User user)
        {
            InitializeComponent();
            this.Topmost = true;
            MemoryStream buf = new MemoryStream(user.Avatar);
            this.user = user;
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = buf;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            buf.Dispose();
            userAvatar.Source = bitmapImage;
            userName.Text = user.Username;
            numName.Text = user.Worknum.ToString();
            realName.Text = user.Name;
            deptname.Text= deptbll.GetDepartmentsById(user.Deptid).Name;
            posiName.Text = user.Position;
            pbPhone.Text = user.Phone;
            if(user.Gender == 1)
            {
                sex.Text = "男";
                boy.IsChecked = true;
            }
            else
            {
                sex.Text = "女";
                boy.IsChecked = false;
            }
            surepbPwd.Password = user.Password;
            pbPwd.Password = user.Password;

            userName.IsEnabled = false;
            numName.IsEnabled = false;
            realName.IsEnabled = false;
            deptname.IsEnabled = false;
            posiName.IsEnabled = false;
            pbPhone.IsEnabled = false;
            sex.IsEnabled = false;


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


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChangeInfo_Click(object sender, RoutedEventArgs e)
        {

            ChooseAvatar.Visibility = Visibility.Visible;
            numName.IsEnabled = true;
            realName.IsEnabled = true;
            deptname.Visibility = Visibility.Collapsed;
            depName.Visibility = Visibility.Visible;
            posiName.IsEnabled = true;
            pbPhone.IsEnabled = true;
            sex.Visibility = Visibility.Collapsed;
            radio.Visibility = Visibility.Visible;
            blPassword.Visibility = Visibility.Visible;
            pbPwd.Visibility = Visibility.Visible;
            sureblPassword.Visibility = Visibility.Visible;
            surepbPwd.Visibility = Visibility.Visible;
            ChangeInfo.Visibility = Visibility.Collapsed;
            Confirm.Visibility = Visibility.Visible;
            List<Department> departments = new List<Department>();
            departments = deptbll.GetDepartmentsList();
            departments.Insert(0, new Department(0, "--请选择分类--"));
            depName.ItemsSource = departments;
            depName.DisplayMemberPath = "Name";
            depName.SelectedIndex = user.Deptid;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (depName.SelectedIndex == 0)
            {
                MessageBox.Show("请选择部门");
                return;
            }
            if (boy.IsChecked == false && girl.IsChecked == false)
            {
                MessageBox.Show("请选择性别");
                return;
            }
            if (pbPwd.Password != surepbPwd.Password)
            {
                MessageBox.Show("两次输入的密码不一致");
                return;
            }
            if (AvatarPath.Text != string.Empty)
            {
                byte[] img = File.ReadAllBytes(AvatarPath.Text);
                user.Avatar = img;
            }
            
            user.Deptid = Convert.ToInt32(depName.SelectedIndex);
            user.Worknum = Convert.ToInt32(numName.Text);
            user.Name = realName.Text;
            user.Password = surepbPwd.Password;
            user.Gender = (boy.IsChecked == true) ? 1 : 0;
            user.Phone = pbPhone.Text;
            user.Position = posiName.Text;
            if (userbll.UpdateUser(user))
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败");
            }
            
        }
    }
}
