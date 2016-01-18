using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TxHumor.Common.Attr;

namespace TxHumor.Model
{
    public class T_User
    {
        [Attr_CachePrimaryKey]
        [Attr_MatchField("Id")]
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Attr_MatchField("UserName")]
        public string UserName { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        [Attr_MatchField("Face")]
        public string Face { get; set; }
        /// <summary>
        /// 发布帖子数
        /// </summary>
        [Attr_MatchField("PublicHumorNum")]
        public int PublicHumorNum { get; set; }
        /// <summary>
        /// 发表评论数
        /// </summary>
        [Attr_MatchField("PublicCommentNum")]
        public int PublicCommentNum { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Attr_MatchField("IsDelete")]
        public int IsDelete { get; set; }
        /// <summary>
        /// 用户支持数
        /// </summary>
        [Attr_MatchField("SmileNum")]
        public int SmileNum { get; set; }
        /// <summary>
        /// 用户积分
        /// </summary>
        [Attr_MatchField("Cent")]
        public int Cent { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [Attr_MatchField("Pwd")]
        public string Pwd { get; set; }
        /// <summary>
        /// 用户电子邮件
        /// </summary>
        [Attr_MatchField("Email")]
        public string Email { get; set; }
    }
}
