using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TxHumor.Model
{
    public class m_CommentXml
    {
        /// <summary>
        /// 引用的评论ID
        /// </summary>
        public int ReplyId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 楼层
        /// </summary>
        public int Floor { get; set; }
    }
}
