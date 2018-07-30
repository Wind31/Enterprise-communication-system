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
using Enterprise_communication_BLL;
using Enterprise_communication_model;

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


        private Department DataRowToDepartment(DataRow dr)
        {
            Department department = new Department();
            department.Id = Convert.ToInt32(dr["e_id"]);
            department.Name = Convert.ToString(dr["e_name"]);
            return department;
        }
        public void getUserInfor(User user)
        {
            lbUsername.Content = user.Username;
            lbName.Content = user.Name;
            if (user.Gender == 1)
                lbGender.Content = "男";
            else lbGender.Content = "女";

            //获取部门名称 
            
            DeptBLL bll = new DeptBLL();
            lbDep.Content = bll.GetDepartmentsById(user.Deptid).Name;
            lbWorknum.Content = Convert.ToString(user.Worknum);
            lbPhone.Content = user.Phone;
            lbPosition.Content = user.Position;
            if (user.Control == 0)
                lbControl.Content = "用户";
            else lbControl.Content = "管理员";
        }


    }
}
