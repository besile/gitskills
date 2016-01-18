using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TxHumor.Common.Attr;

namespace TxHumor.Model
{
    [Serializable]
    public class T_Humor_Tags
    {
        [Attr_CachePrimaryKey]
        [Attr_MatchField("Id")]
        public int Id { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        [Attr_MatchField("TagName")]
        public string TagName { get; set; }
        /// <summary>
        /// 标签创建时间
        /// </summary>
        [Attr_MatchField("CreateTime")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Attr_MatchField("IsDelete")]
        public int IsDelete { get; set; }
        /// <summary>
        /// 标签类型
        /// </summary>
        [Attr_MatchField("TagType")]
        public int TagType { get; set; }
    }
}
