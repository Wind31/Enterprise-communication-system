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
    /// OneToManyWindow.xaml 的交互逻辑
    /// </summary>
    public partial class OneToManyWindow : Window
    {
        public OneToManyWindow()
        {
            InitializeComponent();
        }

        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        /*
       private void btnCheckRe_Click(object sender, RoutedEventArgs e) //查看历史消息
       {

       }

       private void btnSendFile_Click(object sender, RoutedEventArgs e) //发送群文件
       {

       }

       private void btnVidio_Click(object sender, RoutedEventArgs e) //多人视频
       {

       }

       private void btnSendMessage_Click_1(object sender, RoutedEventArgs e) //发送消息
       {

       }

       private void btnBack_Click(object sender, RoutedEventArgs e) //返回主界面
       {

       }*/
    }
}