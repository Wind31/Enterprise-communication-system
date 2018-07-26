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

namespace Enterprise_communication
{
    /// <summary>
    /// SelectGroupUser.xaml 的交互逻辑
    /// </summary>
    public partial class SelectGroupUser : Window
    {
        public SelectGroupUser(MainWindow m)
        {
            InitializeComponent();
            double workHeight = SystemParameters.WorkArea.Height;
            double workWidth = SystemParameters.WorkArea.Width;
            this.Top = (workHeight - this.Height) / 2;
            this.Left = (workWidth - this.Width) / 2;
            this.departmentTree.ItemsSource = m.GetTrees(0, m.GetNodes());//数据绑定
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
