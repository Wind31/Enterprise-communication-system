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
    /// AdministratorWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AdministratorWindow : Window
    {
        private UserBLL bll = new UserBLL();
        private User user1 = new User();
        public AdministratorWindow(User user)
        {
            InitializeComponent();
            LoadData();
            user1 = user;
        }
        public void dataGrid1_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        private void LoadData()
        {
            this.dgUsers.ItemsSource = bll.GetAllUsers();
            dgUsers.LoadingRow += new System.EventHandler<DataGridRowEventArgs>(dataGrid1_LoadingRow); //加载行号
        }
        //查询
        private void btnLook_Click(object sender, RoutedEventArgs e)
        {
            int num = dgUsers.SelectedIndex;
            if (num < 0)
            {
                MessageBox.Show("请选择要查看的用户!");
            }
            else
            {
                //获取选中行
                User User = (User)dgUsers.SelectedValue;
                UserInf_U userInf_U = new UserInf_U();
                userInf_U.gridEdit.DataContext = User;
                userInf_U.getUserInfor(User);
                userInf_U.ShowDialog();
            }

        }
        //增加
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.isAdd = true;
            addUser.ShowDialog();
            //加载数据
            LoadData();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            //获取鼠标选择的索引
            int num = dgUsers.SelectedIndex;
            if (num < 0)
            {
                MessageBox.Show("请选择要修改用户!");
            }
            else
            {
                //获取选中行
                User User = (User)dgUsers.SelectedValue;
                ////打开编辑窗口
                AdmiEditUserInfor editUser = new AdmiEditUserInfor(User);
                editUser.gridUser.DataContext = User;
                //显示窗口
                editUser.ShowDialog();
                LoadData();
            }

        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            //获取鼠标选择的索引
            int num = dgUsers.SelectedIndex;
            if (num < 0)
            {
                MessageBox.Show("请选择要删除的用户!");
            }
            else
            {
                //获取选中行
                User User = (User)dgUsers.SelectedValue;
                if (MessageBox.Show("是否删除" + User.Name + "的信息", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    //删除数据
                    if (bll.Delete(User.Id))
                        MessageBox.Show("删除" + User.Name.Trim() + "成功");
                }
                //加载数据
                LoadData();
            }

        }

        private void btnCheckState_Click(object sender, RoutedEventArgs e)
        {
            //获取鼠标选择的索引
            int num = dgUsers.SelectedIndex;
            User User = (User)dgUsers.SelectedValue;
            if (num < 0)
            {
                MessageBox.Show("请选择要审核的用户!");
            }
            else
            {
                if (User.Check == 1)
                    MessageBox.Show("此用户已经审核通过!");
                else
                {
                    if (MessageBox.Show("是否同意此用户注册？", "管理员审核", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    {
                        User.Check = 1;
                        bll.UpdateUser(User);
                        MessageBox.Show("审核通过!");
                    }
                    else
                        MessageBox.Show("未审核通过!");
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定退出程序？", "管理员", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                user1.State = 0;
                Application.Current.Shutdown();
            }
        }
        private void btnChat_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(user1);
            mainWindow.Show();
        }

    }
}
