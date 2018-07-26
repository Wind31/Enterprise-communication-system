using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_communication_model
{
    /// <summary>
    /// 用户-群实体
    /// </summary>
    public class UserToGroup
    {
        /// <summary>
        /// 实体标识符
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Userid { get; set; }
        /// <summary>
        /// 群ID
        /// </summary>
        public int Groupid { get; set; }
    }
}
