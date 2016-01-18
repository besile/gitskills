using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TxHumor.Common.Attr
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class Attr_RequestParameterAttribute : Attribute
    {
        /// <summary>
        /// 键值
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public object Default { get; set; }

        public Attr_RequestParameterAttribute(string key, object defaultValue)
        {
            this.Key = key;
            this.Default = defaultValue;
        }
    }
}
