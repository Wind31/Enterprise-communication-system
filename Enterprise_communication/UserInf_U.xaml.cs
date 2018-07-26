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

namespace Enterprise_communication
{
    /// <summary>
    /// UserInf_U.xaml 的交互逻辑
    /// </summary>
    public partial class UserInf_U : Window
    {
        public UserInf_U()
        {
            InitializeComponent();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            AlterUserInf_U AU = new AlterUserInf_U();
            AU.Show();
        }
    }
}
