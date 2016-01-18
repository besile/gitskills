using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TxHumor.Common.Attr;

namespace TxHumor.Model
{
    [Serializable]
    public class T_Humor_Comment
    {
        [Attr_CachePrimaryKey]
        [Attr_MatchField("Id")]
        public int Id { get; set; }
        /// <summary>
        /// 帖子ID
        /// </summary>
        [Attr_MatchField("HumorId")]
        public int HumorId { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        [Attr_MatchField("CommentContent")]
        public string CommentContent { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        [Attr_MatchField("CreateUserId")]
        public int CreateUserId { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Attr_MatchField("CreateUserName")]
        public string CreateUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Attr_MatchField("CreateTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 楼层
        /// </summary>
        [Attr_MatchField("Floor")]
        public int Floor { get; set; }
        /// <summary>
        /// ip地址
        /// </summary>
        [Attr_MatchField("IpAddress")]
        public string IpAddress { get; set; }
        /// <summary>
        /// 是否置顶
        /// </summary>
        [Attr_MatchField("IsTop")]
        public int IsTop { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Attr_MatchField("IsDeleted")]
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        [Attr_MatchField("DeleteTime")]
        public DateTime DeleteTime { get; set; }
        /// <summary>
        /// 删除用户ID
        /// </summary>
        [Attr_MatchField("DeleteUserId")]
        public int DeleteUserId { get; set; }
        /// <summary>
        /// 删除用户人名称
        /// </summary>
        [Attr_MatchField("DeleteUserName")]
        public string DeleteUserName { get; set; }
        /// <summary>
        /// 支持数
        /// </summary>
        [Attr_MatchField("SupportNum")]
        public int SupportNum { get; set; }
        /// <summary>
        /// 评论xml
        /// </summary>
        [Attr_MatchField("CommentXml")]
        public string CommentXml { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        [Attr_MatchField("IsShow")]
        public int IsShow { get; set; }
        /// <summary>
        /// 是否审核
        /// </summary>
        [Attr_MatchField("IsAudit")]
        public int IsAudit { get; set; }

        public m_CommentXml CommentXmlModel { get; set; }
    }
}
