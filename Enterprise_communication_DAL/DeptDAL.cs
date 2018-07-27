using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise_communication_model;

namespace Enterprise_communication_DAL
{
    public class DeptDAL
    {
        public List<Department> GetAllDepartment()
        {
            string sql = "SELECT * FROM en_department";
            //2 执行
            MySqlDbHelper db = new MySqlDbHelper();
            DataTable dt = db.ExecuteDataTable(sql);
            //3 关系--》对象
            List<Department> departments = new List<Department>();
            foreach (DataRow dr in dt.Rows)
            {
                //行转化成对象
                Department department = DataRowToDepartment(dr);
                departments.Add(department);
            }
            return departments;
        }
        private Department DataRowToDepartment(DataRow dr)
        {
            Department department = new Department();
            department.Id = Convert.ToInt32(dr["e_id"]);
            department.Name = Convert.ToString(dr["e_name"]);
            return department;
        }
    }
}
