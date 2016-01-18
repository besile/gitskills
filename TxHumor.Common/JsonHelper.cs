using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace TxHumor.Common
{
    public class JsonHelper
    {
        /// <summary>
        /// 生成Json格式
        /// </summary>
        /// <param name="obj">待转换的类型</param>
        /// <returns></returns>
        public static string Serialize<T>(T obj)
        {
            JavaScriptSerializer Serializer = new JavaScriptSerializer();
            return Serializer.Serialize(obj);
        }
    }
}
