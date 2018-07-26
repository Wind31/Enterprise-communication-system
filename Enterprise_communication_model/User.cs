using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_communication_model
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class User
    {
        /// <summary>
        /// 数据库中的标识符
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户名，即登陆帐号
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 用户真实姓名，显示在主窗口列表中
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户登陆密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 所属部门ID
        /// </summary>
        public int Deptid { get; set; }
        /// <summary>
        /// 用户头像路径
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }
        /// <summary>
        /// 用户工号
        /// </summary>
        public int Worknum { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 用户职位
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 用户是否是管理员
        /// </summary>
        public bool Control{get;set;}
        /// <summary>
        /// 动态获取用户IP地址
        /// </summary>
        public string Ipaddress { get; set; }
        /// <summary>
        /// 注册是否已经审核通过
        /// </summary>
        public bool Check { get; set; }
        /// <summary>
        /// 用户是否在线
        /// </summary>
        public bool State { get; set; }
    }
}
