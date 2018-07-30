using Enterprise_communication_BLL;
using Enterprise_communication_model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.IO;

namespace Enterprise_communication
{
    /// <summary>
    /// AddUser.xaml 的交互逻辑
    /// </summary>
    public partial class AddUser : Window
    {
        private UserBLL bll = new UserBLL();
        public AddUser()
        {
            InitializeComponent();
            DeptBLL bll = new DeptBLL();
            List<Department> departments = new List<Department>();
            departments = bll.GetDepartmentsList();
            departments.Insert(0, new Department(0, "--请选择分类--"));
            depName.ItemsSource = departments;
            depName.DisplayMemberPath = "Name";
            depName.SelectedIndex = 0;
        }
        public bool isAdd { get; set; }

        private void btnSave_Click1(object sender, RoutedEventArgs e)
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
            if (tbPassword.Password != tbSurePassword.Password)
            {
                MessageBox.Show("两次输入的密码不一致");
                return;
            }

            User user = new User();
            byte[] img = File.ReadAllBytes(AvatarPath.Text);
            user.Username = tbUserName.Text;
            user.Name = tbName.Text;
            user.Password = tbSurePassword.Password;
            user.Position = tbPosition.Text;
            user.Phone = tbPhone.Text;
            user.Worknum = Convert.ToInt32(tbWorknum.Text);
            user.Deptid = Convert.ToInt32(depName.SelectedIndex);

            user.Gender = (boy.IsChecked == true) ? 1 : 0;
            user.Control = (Admin.IsChecked == true) ? 1 : 0;
            user.State = 0;
            user.Check = 1;
            user.Avatar = img;
            user.Ipaddress = "0.0.0.0";

            if (bll.AddUser(user))
                MessageBox.Show("添加成功！");
            this.Close();

        }

        private void btnCancel_Click2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void chooseImage_Click3(object sender, RoutedEventArgs e)
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
    }
}
