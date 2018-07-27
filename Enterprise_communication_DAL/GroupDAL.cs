using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise_communication_model;

namespace Enterprise_communication_DAL
{
    public class GroupDAL
    {
        public int AddGroup(string name)
        {
            //sql语句
            String sql = "INSERT INTO en_group(e_name) VALUES(@name)";
            //参数列表
            MySqlParameter[] param = {new MySqlParameter("@name", MySqlDbType.VarChar)};

            //参数赋值
            param[0].Value = name;
            MySqlDbHelper db = new MySqlDbHelper();
            db.ExecuteNonQuery(sql, CommandType.Text, param);
            sql = "SELECT LAST_INSERT_ID()";
            return db.ExecuteNonQuery(sql);
        }

        public int AddUserToGroup(int id,int groupid)
        {
            //sql语句
            String sql = "INSERT INTO en_usertogroup(e_userid,e_groupid) VALUES(@id,@group)";
            //参数列表
            MySqlParameter[] param = { new MySqlParameter("@id", MySqlDbType.Int32),
                new MySqlParameter("@group", MySqlDbType.Int32) };

            //参数赋值
            param[0].Value = id;
            param[1].Value = groupid;
            MySqlDbHelper db = new MySqlDbHelper();
            return db.ExecuteNonQuery(sql, CommandType.Text, param);
        }

        public Group GetGroupByName(string Name)
        {
            //1 sql语句
            string sql = "SELECT * FROM en_group WHERE e_name=@name";
            MySqlParameter[] param = {
                                        new MySqlParameter("@name",MySqlDbType.VarChar)
                                   };
            param[0].Value = Name;
            //2 执行sql语句
            MySqlDbHelper db = new MySqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql, CommandType.Text, param);
            //3 关系--》对象     orm --》 ef  nhibernate
            Group group = null;
            if (dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];
                group = DataRowToGroup(dr);
            }
            return group;
        }
        public List<Group> GetAllGroup()
        {
            string sql = "SELECT * FROM en_group";
            //2 执行
            MySqlDbHelper db = new MySqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql);
            //3 关系--》对象
            List<Group> groups = new List<Group>();
            foreach (DataRow dr in dt.Rows)
            {
                //行转化成对象
                Group group = DataRowToGroup(dr);
                groups.Add(group);
            }
            return groups;
        }
        private Group DataRowToGroup(DataRow dr)
        {
            Group group = new Group();
            group.Id = Convert.ToInt32(dr["e_id"]);
            group.Name = Convert.ToString(dr["e_name"]);
            return group;
        }
    }
}
