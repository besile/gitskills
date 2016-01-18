using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TxHumor.Common.Attr;

namespace TxHumor.Common
{
    public class com_RequestParameterHelper
    {
        /// <summary>
        /// 填充请求参数值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public static void ToFillByRequest<T>(T obj)
        {

            Type type = obj.GetType();
            PropertyInfo[] pis= type.GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                object[] attrs=pi.GetCustomAttributes(typeof (Attr_RequestParameterAttribute), false);
                if (attrs.Length == 0)
                {
                    continue;
                }
                foreach (Attr_RequestParameterAttribute attr in attrs)
                {
                    if (attr != null)
                    {
                        string requestValue = RequestHelper.GetString(attr.Key);
                        if (requestValue == null || requestValue.Length == 0)
                        {
                            SetProperty(obj, pi, attr.Default);
                        }
                        else
                        {
                            SetProperty(obj,pi,requestValue);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="pi"></param>
        /// <param name="defaultValue"></param>
        private static void SetProperty(object instance,PropertyInfo pi, object defaultValue)
        {
            if (instance == null || pi == null)
            {
                return;
            }
            if (defaultValue == null)
            {
                return;
            }
            Type type = pi.PropertyType;
            //判断属性的类型
            if (type.IsEnum)
            {
                //Enum.IsDefined判断枚举值是否存在
                if (Enum.IsDefined(type, defaultValue))
                {
                    pi.SetValue(instance,Enum.Parse(type,defaultValue.ToString()),null);
                    return;
                }
            }
            //是否是泛型
            else if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof (Nullable<>)))
            {
                Type[] typeArray = type.GetGenericArguments();
                pi.SetValue(instance,Convert.ChangeType(defaultValue,typeArray[0]),null);
                return;
            }
            else
            {
                pi.SetValue(instance, Convert.ChangeType(defaultValue, type), null);
            }
        }
    }
}
