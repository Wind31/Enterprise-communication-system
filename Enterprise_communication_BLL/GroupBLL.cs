using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise_communication_model;
using Enterprise_communication_DAL;

namespace Enterprise_communication_BLL
{
    public class GroupBLL
    {
        public bool CreatGroup(List<string> users, string name)
        {
            UserDAL userdal = new UserDAL();
            List<int> userid = new List<int>();
            foreach (string username in users)
            {
                User tempuser = new User();
                tempuser = userdal.GetUserByLoginName(username);
                userid.Add(tempuser.Id);
            }
            GroupDAL groupdal = new GroupDAL();
            groupdal.AddGroup(name);
            Group group = groupdal.GetGroupByName(name);
            if (group != null)
            {
                foreach (int id in userid)
                {
                    groupdal.AddUserToGroup(id, group.Id);
                }
                return true;
            }
            return false;
        }
        public void GetGroupByID(int id, out Group group)
        {
            GroupDAL dal = new GroupDAL();
            group = dal.GetGroupByName();
        }
        public List<Group> GetGroupList()
        {
            List<Group> list = new List<Group>();
            GroupDAL dal = new GroupDAL();
            list = dal.GetAllGroup();
            return list;
        }
    }
}
