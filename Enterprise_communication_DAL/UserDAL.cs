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
    public class UserDAL
    {
        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public int AddUser(User user)
        {
            //sql语句
            String sql = "INSERT INTO en_user(e_deptid, e_worknum, e_name, e_username, e_password, e_gender, e_phone, e_position, e_state, e_control, e_ipaddress, e_check, e_avatar)  " +
                "VALUES(@deptid, @worknum, @name, @username, @password, @gender, @phone, @position, @state, @control, @ipaddress, @check, @avatar)";
            //参数列表
            MySqlParameter[] param = {
                                       new MySqlParameter("@deptid",MySqlDbType.Int32),
                                       new MySqlParameter("@worknum",MySqlDbType.Int32),
                                       new MySqlParameter("@name",MySqlDbType.VarChar),
                                       new MySqlParameter("@username",MySqlDbType.VarChar),
                                       new MySqlParameter("@password",MySqlDbType.VarChar),
                                       new MySqlParameter("@gender",MySqlDbType.Int16),
                                       new MySqlParameter("@phone",MySqlDbType.VarChar),
                                       new MySqlParameter("@position",MySqlDbType.VarChar),
                                       new MySqlParameter("@state",MySqlDbType.Int16),
                                       new MySqlParameter("@control",MySqlDbType.Int16),
                                       new MySqlParameter("@ipaddress",MySqlDbType.VarChar),
                                       new MySqlParameter("@check",MySqlDbType.Int16),
                                       new MySqlParameter("@avatar",MySqlDbType.MediumBlob)
                                   };

            //参数赋值
            param[0].Value = user.Deptid;
            param[1].Value = user.Worknum;
            param[2].Value = user.Name;
            param[3].Value = user.Username;
            param[4].Value = user.Password;
            param[5].Value = user.Gender;
            param[6].Value = user.Phone;
            param[7].Value = user.Position;
            param[8].Value = user.State;
            param[9].Value = user.Control;
            param[10].Value = user.Ipaddress;
            param[11].Value = user.Check;
            param[12].Value = user.Avatar;
            MySqlDbHelper db = new MySqlDbHelper();
            return db.ExecuteNonQuery(sql, CommandType.Text, param);
        }

        /// <summary>
        /// 根据用户名查找用户
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public User GetUserByLoginName(string Name)
        {
            //1 sql语句
            string sql = "SELECT * FROM en_user WHERE e_username=@username_";
            MySqlParameter[] param = {
                                        new MySqlParameter("@username_",MySqlDbType.VarChar)
                                   };
            param[0].Value = Name;
            //2 执行sql语句
            MySqlDbHelper db = new MySqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql, CommandType.Text,param);
            //3 关系--》对象     orm --》 ef  nhibernate
            User user = null;
            if (dt.Rows.Count > 0)
            {

                DataRow dr = dt.Rows[0];
                user = DataRowToUser(dr);
            }
            return user;
        }
        /// <summary>
        /// 封装成User对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private User DataRowToUser(DataRow dr)
        {
            User user = new User();
            user.Id = Convert.ToInt32(dr["e_id"]);
            user.Username = Convert.ToString(dr["e_username"]);
            user.Password = Convert.ToString(dr["e_password"]);
            user.Name = Convert.ToString(dr["e_name"]);
            user.Worknum = Convert.ToInt32(dr["e_worknum"]);
            user.Avatar = (byte[])dr["e_avatar"];
            user.Deptid = Convert.ToInt32(dr["e_deptid"]);
            user.Gender = Convert.ToInt32(dr["e_gender"]);
            user.Phone = Convert.ToString(dr["e_phone"]);
            user.Position = Convert.ToString(dr["e_position"]);
            user.Control = Convert.ToInt32(dr["e_control"]);
            user.Ipaddress = Convert.ToString(dr["e_ipaddress"]);
            user.Check = Convert.ToInt32(dr["e_check"]);
            user.State = Convert.ToInt32(dr["e_state"]);
            return user;
        }
    }
}
