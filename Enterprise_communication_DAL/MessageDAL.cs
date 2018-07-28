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
    public class MessageDAL
    {
        public int AddMessage(Message message)
        {
            //sql语句
            String sql = "INSERT INTO en_message(e_userid,e_receiverid,e_content,e_sendtime,e_msgstate,e_sendtype) " +
                "VALUES(@userid,@receiverid,@content,@sendtime,@msgstate,@sendtype)";
            //参数列表
            MySqlParameter[] param = { new MySqlParameter("@userid", MySqlDbType.Int32),
            new MySqlParameter("@receiverid", MySqlDbType.Int32),
            new MySqlParameter("@content", MySqlDbType.VarChar),
            new MySqlParameter("@sendtime", MySqlDbType.DateTime),
            new MySqlParameter("@msgstate", MySqlDbType.Int16),
            new MySqlParameter("@sendtype", MySqlDbType.Int16)
            };

            //参数赋值
            param[0].Value = message.Userid;
            param[1].Value = message.Receiverid;
            param[2].Value = message.Content;
            param[3].Value = message.Sendtime;
            param[4].Value = message.State;
            param[5].Value = message.Sendtype;
            MySqlDbHelper db = new MySqlDbHelper();
            return db.ExecuteNonQuery(sql, CommandType.Text, param);
        }
        public List<Message> GetSomeMessage(User sender,User receiver, int id)
        {
            string sql = "SELECT * FROM en_message where e_userid=@userid and e_receiverid=@receiverid or e_userid=@receiverid and e_receiverid=@userid"
                + " order by e_sendtime desc limit " + id.ToString();
            MySqlParameter[] param = {
                                        new MySqlParameter("@userid",MySqlDbType.Int32),
                                        new MySqlParameter("@receiverid",MySqlDbType.Int32)
                                   };
            param[0].Value = sender.Id;
            param[1].Value = receiver.Id;
            //2 执行
            MySqlDbHelper db = new MySqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql, CommandType.Text, param);
            //3 关系--》对象
            List<Message> msgs = new List<Message>();
            foreach (DataRow dr in dt.Rows)
            {
                msgs.Add(DataRowToMessage(dr));
            }
            msgs.Reverse();
            return msgs;
        }
        private Message DataRowToMessage(DataRow dr)
        {
            Message message = new Message();
            message.Id = Convert.ToInt32(dr["e_id"]);
            message.Userid = Convert.ToInt32(dr["e_userId"]);
            message.Receiverid = Convert.ToInt32(dr["e_receiverId"]);
            message.Content = Convert.ToString(dr["e_content"]);
            message.Sendtime = Convert.ToDateTime(dr["e_sendtime"]);
            message.State = Convert.ToInt32(dr["e_msgstate"]);
            message.Sendtype = Convert.ToInt32(dr["e_sendtype"]);
            return message;
        }

    }
}
