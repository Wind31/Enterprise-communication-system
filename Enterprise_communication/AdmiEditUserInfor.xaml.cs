using Enterprise_communication_BLL;
using Enterprise_communication_model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Enterprise_communication
{
    /// <summary>
    /// AdmiEditUserInfor.xaml 的交互逻辑
    /// </summary>
    public partial class AdmiEditUserInfor : Window
    {
        User user1 = new User();
        bool flag = false;
        private UserBLL bll = new UserBLL();
        public AdmiEditUserInfor(User user)
        {
            user1 = user;
            InitializeComponent();
            DeptBLL bll = new DeptBLL();
            List<Department> departments = new List<Department>();
            departments = bll.GetDepartmentsList();
            departments.Insert(0, new Department(0, "--请选择部门-"));
            depName.ItemsSource = departments;
            depName.DisplayMemberPath = "Name";
            depName.SelectedIndex = user.Deptid;
            getUserInfor(user);
        }

        public void getUserInfor(User user)
        {
            tbUserName.Text = user.Username;
            tbName.Text = user.Name;
            if (user.Gender == 1)
                boy.IsChecked = true;
            else
                girl.IsChecked = true;
            tbPassword.Password = user.Password;
            tbSurePassword.Password = user.Password;
            tbPhone.Text = user.Phone;
            tbPosition.Text = user.Position;
            if (user.Control == 1)
                Admin.IsChecked = true;
            else
                ComUser.IsChecked = true;

        }
        private void btnSave_Click1(object sender, RoutedEventArgs e)
        {
            user1.Username = tbUserName.Text;
            user1.Name = tbName.Text;
            user1.Password = tbSurePassword.Password;
            user1.Position = tbPosition.Text;
            user1.Phone = tbPhone.Text;
            user1.Deptid = Convert.ToInt32(depName.SelectedIndex);
            user1.Gender = (boy.IsChecked == true) ? 1 : 0;
            user1.Control = (Admin.IsChecked == true) ? 1 : 0;
            user1.State = 0;
            user1.Check = 1;
            if (bll.UpdateUser(user1))
                MessageBox.Show("修改成功！");
            else
                MessageBox.Show("修改失败！");
            this.Close();
        }

        private void btnCancel_Click2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void chooseImage_Click(object sender, RoutedEventArgs e)
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
            byte[] img = File.ReadAllBytes(AvatarPath.Text);
            user1.Avatar = img;
        }
    }
}
