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
using Enterprise_communication_BLL;
using Enterprise_communication_model;

namespace Enterprise_communication
{
    /// <summary>
    /// AlterUserInf_U.xaml 的交互逻辑
    /// </summary>
    public partial class AlterUserInf_U : Window
    {
        private UserBLL bll = new UserBLL();
        //编辑或者增加
        public bool isAdd { get; set; }

        public AlterUserInf_U()
        {
            InitializeComponent();
            //this.cbType.ItemsSource = Common.getTypes();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //if (isAdd)
            //{
            // 部门！！！
            User user = new User();
            user.Name = tbName.Text;
            //user.Deptid
            user.Position = tbPosition.Text;
            user.Phone = tbPhone.Text;
            gridUser.DataContext = user;
        }

        private void btnSave_Click1(object sender, RoutedEventArgs e)
        {
            User user = (User)gridUser.DataContext;
            if (isAdd)
            {
                if (bll.AddUser(user))
                    MessageBox.Show("添加成功！");

            }
            else
            {
                if (bll.UpdateUser(user))
                    MessageBox.Show("修改成功！");
            }
            this.Close();
        }

        private void btnCancel_Click2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
