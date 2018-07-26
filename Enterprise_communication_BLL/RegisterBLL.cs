using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise_communication_model;
using Enterprise_communication_DAL;

namespace Enterprise_communication_BLL
{
    public class RegisterBLL
    {
        User user;
        public RegisterBLL(User user)
        {
            this.user = user;
        }
        public bool Register()
        {
            UserDAL dal= new UserDAL();
            if(dal.GetUserByLoginName(user.Username)==null)
            {
                dal.AddUser(user);
                return true;
            }
            return false;
        }
    }
}
