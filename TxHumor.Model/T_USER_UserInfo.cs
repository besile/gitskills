using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TxHumor.Common.Attr;

namespace TxHumor.Model
{
    [Serializable]
    public class T_USER_UserInfo
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
        /// 头像是否审核
        /// </summary>
        [Attr_MatchField("HeadIsAudit")]
        public bool HeadIsAudit { get; set; }
        /// <summary>
        /// 用户头像是否删除
        /// </summary>
        [Attr_MatchField("HeadIsDelete")]
        public int HeadIsDelete { get; set; }
        /// <summary>
        /// 头像审核时间
        /// </summary>
        [Attr_MatchField("HeadAuditTime")]
        public DateTime HeadAuditTime { get; set; }
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
        /// 删除用户ID
        /// </summary>
        [Attr_MatchField("DeleteUserId")]
        public int DeleteUserId { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        [Attr_MatchField("DeleteTime")]
        public DateTime DeleteTime { get; set; }
        /// <summary>
        /// qq分享我的发帖
        /// </summary>
        [Attr_MatchField("QQShareMyPublish")]
        public bool QQShareMyPublish { get; set; }
        /// <summary>
        /// qq分享我的支持
        /// </summary>
        [Attr_MatchField("QQShareMySmile")]
        public bool QQShareMySmile { get; set; }
        /// <summary>
        /// sina分享我的发帖
        /// </summary>
        [Attr_MatchField("SinaShareMyPublish")]
        public bool SinaShareMyPublish { get; set; }
        /// <summary>
        /// sina分享我的支持
        /// </summary>
        [Attr_MatchField("SinaShareMySmile")]
        public bool SinaShareMySmile { get; set; }
        /// <summary>
        /// QQOpenId
        /// </summary>
        [Attr_MatchField("QQOpenId")]
        public string QQOpenId { get; set; }
        /// <summary>
        /// SinaOpenId
        /// </summary>
        [Attr_MatchField("SinaOpenId")]
        public string SinaOpenId { get; set; }
        /// <summary>
        /// QQAccessToken
        /// </summary>
        [Attr_MatchField("QQAccessToken")]
        public string QQAccessToken { get; set; }
        /// <summary>
        /// QQAccessTokenSecret
        /// </summary>
        [Attr_MatchField("QQAccessTokenSecret")]
        public string QQAccessTokenSecret { get; set; }
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
        /// 用户签名
        /// </summary>
        [Attr_MatchField("Signature")]
        public string Signature { get; set; }
        /// <summary>
        /// 签名是否审核
        /// </summary>
        [Attr_MatchField("SignIsAudit")]
        public bool SignIsAudit { get; set; }
        /// <summary>
        /// 签名是否删除
        /// </summary>
        [Attr_MatchField("SignIsDelete")]
        public bool SignIsDelete { get; set; }
        /// <summary>
        /// 签名审核时间
        /// </summary>
        [Attr_MatchField("SignAuditTime")]
        public DateTime SignAuditTime { get; set; }
        /// <summary>
        /// 签名审核人ID
        /// </summary>
        [Attr_MatchField("SignAuditUserId")]
        public int SignAuditUserId { get; set; }
        /// <summary>
        /// 签名审核人
        /// </summary>
        [Attr_MatchField("SignAuditUserName")]
        public string SignAuditUserName { get; set; }
        /// <summary>
        /// 个人中心背景
        /// </summary>
        [Attr_MatchField("BackgroundImgs")]
        public string BackgroundImgs { get; set; }
    }
}
