using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TxHumor.Common.Attr
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class Attr_AddSolrAttribute:Attribute
    {
        /// <summary>
        /// 传递参数的位置
        /// </summary>
        public int PramIndex { get; set; }

        public string Key { get; set; }

        public Attr_AddSolrAttribute(int pramIndex, string key)
        {
            this.PramIndex = pramIndex;
            this.Key = key;

        }
    }
}
