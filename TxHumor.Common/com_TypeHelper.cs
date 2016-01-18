using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TxHumor.Common
{
    public static class com_TypeHelper
    {
        static com_TypeHelper() { ;}
        /// <summary>
        /// 判断是否是集合
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsCollection(this Type t)
        {
            return ((!t.Equals(typeof(string)))
                && (t.IsArray
                    || (t.GetInterface("IEnumerable") != null
                        && t.GetInterface("IEnumerable").IsAssignableFrom(t)
                )));
        }
    }
}
