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
        public int CreatGroup(List<string> users, string name)
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
            int groupid = groupdal.AddGroup(name);
            foreach (int id in userid)
            {
                if(groupdal.AddUserToGroup(id, groupid)<0)
                    return -1;
            }
            return groupid;
        }
        public void GetGroupByID(int id, out Group group)
        {
            GroupDAL dal = new GroupDAL();
            group = dal.GetGroupById(id);
        }
        public List<Group> GetGroupListByUserId(int userid)
        {
            List<Group> list = new List<Group>();
            GroupDAL dal = new GroupDAL();
            list = dal.GetGroupsByUserid(userid);
            return list;
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
