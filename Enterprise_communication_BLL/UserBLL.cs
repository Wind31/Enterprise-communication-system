using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise_communication_model;
using Enterprise_communication_DAL;
using System.Net;
using System.Net.Sockets;

namespace Enterprise_communication_BLL
{
    public class UserBLL
    {
        public bool Register(User user)
        {
            UserDAL dal = new UserDAL();
            if (dal.GetUserByLoginName(user.Username) == null)
            {
                dal.AddUser(user);
                return true;
            }
            return false;
        }
        public void GetUserByUsername(string name,out User user)
        {
            UserDAL dal = new UserDAL();
            user = dal.GetUserByLoginName(name);
        }
        public bool Login(string name, string pwd, out User user)
        {
            bool result = false; //假设登录失败
            UserDAL dal = new UserDAL();
            user = dal.GetUserByLoginName(name);
            if (user != null)
            {
                if (user.Password == pwd)
                {
                    user.Ipaddress = GetLocalIp();
                    user.State = 1;
                    dal.UpdateUser(user);
                    result = true;

                }
            }
            return result;
        }
        public void Logout(User user)
        {
            user.Ipaddress = "0.0.0.0";
            user.State = 0;
            UserDAL dal = new UserDAL();
            dal.UpdateUser(user);
        }
        public static string GetLocalIp()
        {
            IPAddress localIp = null;

            try
            {
                IPAddress[] ipArray;
                ipArray = Dns.GetHostAddresses(Dns.GetHostName());
                localIp = ipArray.First(ip => ip.AddressFamily == AddressFamily.InterNetwork);

            }
            catch (Exception ex)
            {
            }
            if (localIp == null)
            {
                localIp = IPAddress.Parse("127.0.0.1");
            }
            return localIp.ToString();
        }
        public List<User> GetUsersList()
        {
            List<User> list = new List<User>();
            UserDAL dal = new UserDAL();
            list = dal.GetAllUsers();
            return list;
        }

    }
}
