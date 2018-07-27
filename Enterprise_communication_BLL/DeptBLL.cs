using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enterprise_communication_model;
using Enterprise_communication_DAL;

namespace Enterprise_communication_BLL
{
    public class DeptBLL
    {
        public List<Department> GetDepartmentsList()
        {
            List<Department> list = new List<Department>();
            DeptDAL dal = new DeptDAL();
            list = dal.GetAllDepartment();
            return list;
        }
    }
}
