using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TxHumor.Common.Attr
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = false,Inherited = false)]
    public class Attr_MatchFieldAttribute:Attribute
    {
        public string Key { get; set; }
        /// <summary>
        /// 初始化key
        /// </summary>
        /// <param name="key"></param>
        public Attr_MatchFieldAttribute(string key)
        {
            this.Key = key;
        }
    }
}
