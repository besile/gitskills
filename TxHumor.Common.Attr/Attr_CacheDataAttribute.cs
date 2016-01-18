using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TxHumor.Common.Attr
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class Attr_CacheDataAttribute:Attribute
    {
        public Attr_CacheDataAttribute()
        {
        }

        public string WhatCase { get; set; }

        public Attr_CacheDataAttribute(string whatCase) : this()
        {
            this.WhatCase = whatCase;
        }
    }
}
