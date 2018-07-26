using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_communication_model
{
    /// <summary>
    /// 私聊消息实体
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 消息标识符
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 接收用户ID
        /// </summary>
        public int Receiverid { get; set; }
        /// <summary>
        /// 发送用户ID
        /// </summary>
        public int Userid { get; set; }
        /// <summary>
        /// 消息类型，文本=1，图片=2，其它文件=3
        /// </summary>
        public int Sendtype { get; set; }
        /// <summary>
        /// 消息发送时间
        /// </summary>
        public DateTime Sendtime { get; set; }
        /// <summary>
        /// 消息发送状态，是否成功发送
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; }
    }
}
