using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TxHumor.Common.Attr
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class Attr_CachePrimaryKeyAttribute:Attribute
    {
        public Attr_CachePrimaryKeyAttribute()
        {

        }
    }
}
