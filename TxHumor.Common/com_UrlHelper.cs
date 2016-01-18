using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TxHumor.Common
{
    public class com_UrlHelper
    {
        private com_UrlHelper() { ;}


        public static string GetRelUrl(object o, string separator)
        {
            string[] array = combine(o);
            return string.Join(separator, array);
        }

        public static string GetAbsUrl(string hostName, object o, string separator, string anchor)
        {
            string relUrl = GetRelUrl(o, separator);
            return string.Concat(hostName, "/", relUrl, "/", anchor ?? string.Empty);
        }

        private static string[] combine(object o)
        {
            if (o == null) return null;
            PropertyInfo[] pis = o.GetType().GetProperties();
            if (pis == null || pis.Length == 0) return null;
            List<string> list = new List<string>();
            foreach (PropertyInfo item in pis)
            {
                var value = item.GetValue(o, null);
                if (value == null) continue;
                string s = value.ToString();
                list.Add(s);
            }
            return list.ToArray();
        }
    }
}
