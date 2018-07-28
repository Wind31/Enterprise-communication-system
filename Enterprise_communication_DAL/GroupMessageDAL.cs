using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise_communication_model;
using MySql.Data.MySqlClient;

namespace Enterprise_communication_DAL
{
    public class GroupMessageDAL
    {
        public int AddMessage(GroupMessage message)
        {
            //sql语句
            String sql = "INSERT INTO en_groupmsg(e_groupid,e_userid,e_sendtype,e_sendtime,e_msgstate,e_content) " +
                "VALUES(@groupid,@userid,@sendtype,@sendtime,@msgstate,@content)";
            //参数列表
            MySqlParameter[] param = { new MySqlParameter("@groupid", MySqlDbType.Int32),
            new MySqlParameter("@userid", MySqlDbType.Int32),
            new MySqlParameter("@sendtype", MySqlDbType.Int16),
            new MySqlParameter("@sendtime", MySqlDbType.DateTime),
            new MySqlParameter("@msgstate", MySqlDbType.Int16),
            new MySqlParameter("@content", MySqlDbType.VarChar)
            };

            //参数赋值
            param[0].Value = message.Groupid;
            param[1].Value = message.Userid;
            param[2].Value = message.Sendtype;
            param[3].Value = message.Sendtime;
            param[4].Value = message.State;
            param[5].Value = message.Content;
            MySqlDbHelper db = new MySqlDbHelper();
            return db.ExecuteNonQuery(sql, CommandType.Text, param);
        }
        public List<GroupMessage> GetSomeMessage(Group group, int n)
        {
            string sql = "SELECT * FROM en_groupmsg where e_groupid=@groupid"
                + " order by e_sendtime desc limit " + n.ToString();
            MySqlParameter[] param = {
                                        new MySqlParameter("@groupid",MySqlDbType.Int32),
                                   };
            param[0].Value = group.Id;
            //2 执行
            MySqlDbHelper db = new MySqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql, CommandType.Text, param);
            //3 关系--》对象
            List<GroupMessage> msgs = new List<GroupMessage>();
            foreach (DataRow dr in dt.Rows)
            {
                msgs.Add(DataRowToGroupMessage(dr));
            }
            msgs.Reverse();
            return msgs;
        }
        private GroupMessage DataRowToGroupMessage(DataRow dr)
        {
            GroupMessage message = new GroupMessage();
            message.Id = Convert.ToInt32(dr["e_id"]);
            message.Userid = Convert.ToInt32(dr["e_userId"]);
            message.Groupid = Convert.ToInt32(dr["e_groupid"]);
            message.Content = Convert.ToString(dr["e_content"]);
            message.Sendtime = Convert.ToDateTime(dr["e_sendtime"]);
            message.State = Convert.ToInt32(dr["e_msgstate"]);
            message.Sendtype = Convert.ToInt32(dr["e_sendtype"]);
            return message;
        }

    }
}
