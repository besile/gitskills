using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TxHumor.Common.Attr;

namespace TxHumor.Cache.Service
{
    public static class srv_CacheKey
    {
        public static string ToPrimaryKey(this object obj)
        {
            PropertyInfo[] pis = obj.GetType().GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                object[] pk=pi.GetCustomAttributes(typeof (Attr_CachePrimaryKeyAttribute), false);
                if (pk.Length <= 0)
                {
                    continue;
                }
                foreach (Attr_CachePrimaryKeyAttribute o in pk)
                {
                    if (o != null)
                    {
                        var key = pi.GetValue(obj, null);
                        if (key == null) return string.Empty;
                        return key.ToString().ToUpper();
                    }
                }
            }
            return obj.ToString();
        }
    }
}
