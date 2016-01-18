/* ------------------------------------
  作者：冯自立
  日期：2011/2/18
------------------------------------ */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Web;
using System.Data.SqlClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TxHumor.Common
{
    /// <summary>
    /// Object类型的扩展方法。
    /// </summary>
    public static class ObjectExtension
    {
        #region 对象比较

        public static bool IsNull(this object value)
        {
            return value == null;
        }

        public static bool IsNotNull(this object value)
        {
            return value != null;
        }

       

        #endregion

        #region 初始化赋值扩展

        /// <summary>
        /// 遍历当前简单对象的所有属性，将符合过滤条件的属性都赋予默认的defaultValue，不支持索引。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="propertyFilter">属性过滤器</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static T EnsurePropertyValue<T, TProperty>(this T obj, Func<TProperty, bool> propertyFilter, TProperty defaultValue)
        {
            if (obj == null || propertyFilter == null)
            {
                return obj;
            }
            Type typ = obj.GetType();
            Type typProperty = typeof(TProperty);
            foreach (PropertyInfo pif in typ.GetProperties())
            {
                if (pif.CanWrite == false || pif.CanRead == false)
                {
                    continue;
                }
                if (pif.PropertyType == typProperty)
                {
                    if (propertyFilter((TProperty)pif.GetValue(obj, null)))
                    {
                        pif.SetValue(obj, defaultValue, null);
                    }
                }
            }
            return obj;
        }

        #endregion

        #region Try式编程支援 20130220 Added by fengzili

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="caller">扩展语法糖参数，不参与函数内部运算</param>
        /// <param name="action"></param>
        /// <param name="value"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        internal static bool TryThis<T>(this object caller, Func<T> action, out T value, out Exception error)
        {
            return ObjectExtension.TryThis<T>(action, out value, out error);
        }

        internal static bool TryThis<T>(Func<T> action, out T value, out Exception error)
        {
            try
            {
                value = action();
                error = null;
                return true;
            }
            catch (Exception expError)
            {
                error = expError;
                value = default(T);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caller">扩展语法糖参数，不参与函数内部运算</param>
        /// <param name="action"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        internal static bool TryThis(this object caller, Action action, out Exception error)
        {
            return ObjectExtension.TryThis(action, out error);
        }

        internal static bool TryThis(Action action, out Exception error)
        {
            try
            {
                action();
                error = null;
                return true;
            }
            catch (Exception expError)
            {
                error = expError;
                return false;
            }
        }

        #endregion

        #region 扩展bool

        public static bool Then(this bool value, Action action)
        {
            if (value && action != null)
            {
                action();
            }
            return value;
        }

        public static bool Else(this bool value, Action action)
        {
            if (value == false && action != null)
            {
                action();
            }
            return value;
        }

        public static T Then<T>(this bool value, Func<T> function)
        {
            if (function == null)
            {
                return default(T);
            }
            if (value)
            {
                return function();
            }
            return default(T);
        }

        public static T Then<T>(this bool value, T emptyValue, Func<T> function)
        {
            if (function == null)
            {
                return emptyValue;
            }
            if (value)
            {
                return function();
            }
            return emptyValue;
        }

        public static T Return<T>(this bool value, T trueValue, T falseValue)
        {
            if (value)
            {
                return trueValue;
            }
            return falseValue;
        }


        #endregion

        #region 类型转换

        #region 对象合并

        /// <summary>
        /// 执行额外动作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static T DoAction<T>(this T value, Action<T> action)
        {
            if (action == null)
            {
                return value;
            }
            action(value);
            return value;
        }

        
        /// <summary>
        /// 从源对象source中找对应的属性值，Map到当前对象value中。效果等价于：value.Property1=source.Property1;value.Property2=source.Property2;...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T MergeProperty<T>(this T value, object source)
        {
            Type typValue = source.GetType();
            foreach (PropertyInfo pfiTarget in typeof(T).GetProperties())
            {
                if (pfiTarget.GetSetMethod() == null)
                {
                    continue;
                }
                PropertyInfo pfiSource = typValue.GetProperty(pfiTarget.Name);
                if (pfiSource == null)
                {
                    continue;
                }
                object objValue = pfiSource.GetValue(source, null);
                if (pfiTarget.PropertyType == pfiSource.PropertyType)
                {
                    pfiTarget.SetValue(value, objValue, null);
                    continue;
                }
                if (objValue == null || objValue == DBNull.Value)
                {
                    continue;
                }
                if (pfiTarget.PropertyType.BaseType == typeof(Enum))
                {
                    objValue = Enum.Parse(pfiTarget.PropertyType, objValue.ToString());
                }
                else if (pfiTarget.PropertyType.IsGenericType)
                {
                    Type typParameter = pfiTarget.PropertyType.GetGenericArguments()[0];
                    if (typParameter.BaseType == typeof(Enum))
                    {
                        objValue = Enum.Parse(typParameter, objValue.SafeToString());
                    }
                    else
                    {
                        objValue = Convert.ChangeType(objValue, typParameter);
                    }
                    pfiTarget.SetValue(value, objValue, null);
                    continue;
                }
                pfiTarget.SetValue(value, Convert.ChangeType(objValue, pfiTarget.PropertyType), null);
            }
            return value;
        }




        #endregion


        /// <summary>
        /// 对象转换：通过属性名称来映射生成一个新的目标对象。如果源对象value为null，则返回defaultValue。效果等价于：T t=new T();t.Property1=source.Property1;t.Property2=source.Property2;...return t;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultVaue"></param>
        /// <returns>如果源对象value为null，则返回defaultValue。</returns>
        public static T PropertySimpleMap<T>(this object value, T defaultVaue)
        {
            if (value == null)
            {
                return defaultVaue;
            }
            T tReturn = Activator.CreateInstance<T>();
            tReturn.MergeProperty(value);
            return tReturn;
        }

        /// <summary>
        /// 批量转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <param name="emptyVaue"></param>
        /// <returns></returns>
        public static IEnumerable<T> BatchPropertySimpleMap<T>(this IEnumerable values, T emptyVaue)
        {
            if (values.IsNullOrEmpty())
            {
                yield break;
            }
            foreach (object objItem in values)
            {
                yield return objItem.PropertySimpleMap<T>(emptyVaue);
            }
        }


        #endregion

        /// <summary>
        /// 对象非空的时候执行指定的逻辑。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="value"></param>
        /// <param name="emptyValue"></param>
        /// <param name="logic"></param>
        /// <returns></returns>
        public static TReturn SafeFetch<T, TReturn>(this T value, TReturn emptyValue, Func<T, TReturn> logic)
        {
            if (value == null || logic == null)
            {
                return emptyValue;
            }
            return logic(value);
        }

        /// <summary>
        /// 更加安全的调用对象的ToString方法，如果是null，返回string.Empty；其它情况调用实际的ToString。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SafeToString(this object value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            return value.ToString();
        }

        private static readonly Type ValueTypeType = typeof(ValueType);
        /// <summary>
        /// 当前对象转换成特定类型，如果转换失败或者对象为null，返回defaultValue。
        /// 如果传入的是可空类型：会试着转换成其真正类型后返回。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue">转换出错或者对象为空的时候的返回值</param>
        /// <returns></returns>
        public static T ToSimpleT<T>(this object value, T defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }
            else if (value is T)
            {
                return (T)value;
            }
            try
            {
                if (typeof(T).BaseType == typeof(Enum))
                {
                    object objValue = Enum.Parse(typeof(T), value.ToString());
                    return (T)objValue;
                }
                Type typ = typeof(T);
                if (typ.BaseType == ObjectExtension.ValueTypeType && typ.IsGenericType)//可空泛型
                {
                    Type[] typs = typ.GetGenericArguments();
                    return (T)Convert.ChangeType(value, typs[0]);
                }
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return defaultValue;
            }
        }

        public static object ToSimpleT(this object value, Type targetType, object defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }
            Type typValueTemp = value.GetType();
            Type typObject = typeof(object);
            do
            {
                if (typValueTemp == targetType)
                {
                    return value;
                }
                typValueTemp = typValueTemp.BaseType;
            }
            while (typValueTemp != typObject);
            try
            {
                if (targetType == typeof(Enum))
                {
                    object objValue = Enum.Parse(targetType, value.ToString());
                    return objValue;
                }
                Type typ = targetType;
                if (typ.BaseType == ObjectExtension.ValueTypeType && typ.IsGenericType)//可空泛型
                {
                    Type[] typs = typ.GetGenericArguments();
                    return Convert.ChangeType(value, typs[0]);
                }
                return Convert.ChangeType(value, targetType);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static T FillProperty<T>(this T value, IDictionary propertyValueCollection)
        {
            if (value == null || propertyValueCollection == null)
            {
                return value;
            }
            foreach (PropertyInfo pif in value.GetType().GetProperties())
            {
                if (propertyValueCollection.Contains(pif.Name) == false)
                {
                    continue;
                }
                object objCurrentPropertyValue = propertyValueCollection[pif.Name];
                if (objCurrentPropertyValue == null)
                {
                    continue;
                }
                pif.SetValue(value, objCurrentPropertyValue.ToSimpleT(pif.PropertyType, null), null);
            }
            return value;
        }

        public static T FillProperty<T>(this T value, IDictionary<string, object> propertyValueCollection)
        {
            if (value == null || propertyValueCollection == null)
            {
                return value;
            }
            foreach (PropertyInfo pif in value.GetType().GetProperties())
            {
                if (propertyValueCollection.ContainsKey(pif.Name) == false)
                {
                    continue;
                }
                object objCurrentPropertyValue = propertyValueCollection[pif.Name];
                if (objCurrentPropertyValue == null)
                {
                    continue;
                }
                pif.SetValue(value, objCurrentPropertyValue.ToSimpleT(pif.PropertyType, null), null);
            }
            return value;
        }

        #region DataTable Extension

        public static bool IsNotNullOrEmpty(this DataTable table)
        {
            return table.IsNullOrEmpty() == false;
        }

        public static bool IsNullOrEmpty(this DataTable table)
        {
            if (table == null)
            {
                return true;
            }
            return table.Rows.Count == 0;
        }

        public static IList<T> ToList<T>(this DataTable table)
        {
            return table.ToList<T>(null);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="value">不参与运算，语法糖</param>
        /// <param name="bindLogic"></param>
        /// <returns></returns>
        public static T DoFunction<T, T1>(this T value, T1 t1Value, Action<T, T1> bindLogic)
        {
            if (bindLogic == null)
            {
                return value;
            }
            bindLogic(value, t1Value);
            return value;
        }

        public static T DoFunction<T>(this T value, Action<T> bindLogic)
        {
            if (bindLogic == null)
            {
                return value;
            }
            bindLogic(value);
            return value;
        }

        /// <summary>
        /// 转换DataTable到IList强类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="bindLogic">绑定逻辑</param>
        /// <returns></returns>
        public static IList<T> ToList<T>(this DataTable table, Action<T, DataRow> bindLogic)
        {
            if (table.IsNullOrEmpty())
            {
                return new List<T>(0);
            }
            return (from DataRow row in table.Rows select row.ToT<T>().DoFunction<T, DataRow>(row, bindLogic)).ToList();
        }

        #endregion

        public static bool IsNotNullOrEmpty(this IEnumerable collection)
        {
            return collection.IsNullOrEmpty() == false;
        }

        public static bool IsNullOrEmpty(this IEnumerable collection)
        {
            if (collection == null)
            {
                return true;
            }
            foreach (object o in collection)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 把集合的值全都拼起来。如果集合为空，返回一个空的StringBuilder对象（非null）。
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="splitString"></param>
        /// <param name="initializeStringCount">预估大概有多少个字符串，不传递的时候默认200</param>
        /// <returns></returns>
        public static StringBuilder ConcatValue(this IEnumerable collection, string splitString, int? initializeStringCount = null)
        {
            if (collection.IsNullOrEmpty())
            {
                return new StringBuilder(1);//Avoid 8
            }
            StringBuilder sbContainer = new StringBuilder(initializeStringCount == null ? 200 : initializeStringCount.Value);
            foreach (object objValue in collection)
            {
                sbContainer.Append(objValue).Append(splitString);
            }
            sbContainer.RemoveLastChars(splitString.SafeLength());
            return sbContainer;
        }

        /// <summary>
        /// 把集合的值全都拼起来。如果集合为空，返回一个空的StringBuilder对象（非null）。
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="splitString"></param>
        /// <param name="initializeStringCount">预估大概有多少个字符串，不传递的时候默认200</param>
        /// <returns></returns>
        public static StringBuilder ConcatValue<T>(this IEnumerable<T> collection, string splitString, int? initializeStringCount, Func<T, string> toStringMethod)
        {
            if (collection.IsNullOrEmpty())
            {
                return new StringBuilder(1);//Avoid 8
            }
            StringBuilder sbContainer = new StringBuilder(initializeStringCount == null ? 200 : initializeStringCount.Value);
            foreach (T objValue in collection)
            {
                sbContainer.Append(toStringMethod(objValue)).Append(splitString);
            }
            sbContainer.RemoveLastChars(splitString.SafeLength());
            return sbContainer;
        }

        public static int SafeLength(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            return value.Length;
        }




        public static void RemoveLastChar(this StringBuilder builder)
        {
            if (builder == null || builder.Length == 0)
            {
                return;
            }
            builder.Remove(builder.Length - 1, 1);
        }

        /// <summary>
        /// 通过列名跟属性对比来赋值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T ToT<T>(this DataRow row)
        {
            if (row == null)
            {
                return default(T);
            }
            T tReturn = Activator.CreateInstance<T>();
            foreach (PropertyInfo pfi in typeof(T).GetProperties())
            {
                if (row.Table.Columns.Contains(pfi.Name))
                {
                    object objValue = row[pfi.Name];
                    if (objValue == null || objValue == DBNull.Value)
                    {
                        continue;
                    }
                    if (pfi.PropertyType.BaseType == typeof(Enum))
                    {
                        objValue = Enum.Parse(pfi.PropertyType, objValue.ToString());
                    }
                    else if (pfi.PropertyType.IsGenericType)
                    {
                        Type typParameter = pfi.PropertyType.GetGenericArguments()[0];
                        if (typParameter.BaseType == typeof(Enum))
                        {
                            objValue = Enum.Parse(typParameter, objValue.SafeToString());
                        }
                        else
                        {
                            objValue = Convert.ChangeType(objValue, typParameter);
                        }
                        pfi.SetValue(tReturn, objValue, null);
                        continue;
                    }
                    pfi.SetValue(tReturn, Convert.ChangeType(objValue, pfi.PropertyType), null);
                }
            }
            return tReturn;
        }

        /// <summary>
        /// 初始化类的属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T InitT<T>(this object value, T defaultValue)
        {
            Type t = value.GetType();
            foreach (PropertyInfo p in t.GetProperties())
            {
                switch (p.GetType().ToString())
                {
                    case "System.Int32":
                        p.SetValue(value, 0, null);
                        break;
                    case "System.String":
                        p.SetValue(value, string.Empty, null);
                        break;
                    case "System.Decimal":
                        p.SetValue(value, 0m, null);
                        break;
                    case "System.DateTime":
                        p.SetValue(value, DateTime.MinValue, null);
                        break;
                    case "System.Single":
                        p.SetValue(value, 0f, null);
                        break;
                    case "System.Byte":
                        p.SetValue(value, 0, null);
                        break;
                    case "System.Int64":
                        p.SetValue(value, 0, null);
                        break;
                    default:
                        break;
                }
            }

            if (value is T)
            {
                return (T)value;
            }
            else
            {
                return defaultValue;
            }
        }


        public static StringBuilder RemoveLastChars(this StringBuilder builder, int length)
        {
            if (builder == null || builder.Length == 0)
            {
                return builder;
            }
            if (length > builder.Length)
            {
                builder.Clear();
                return builder;
            }
            builder.Remove(builder.Length - length, length);
            return builder;
        }

        /// <summary>
        /// 是否包含某一列
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static bool HasColumn(this DataRow row, string columnName)
        {
            if (row == null || columnName.IsNullOrEmpty())
            {
                return false;
            }
            return row.Table.HasColumn(columnName);
        }

        /// <summary>
        /// 是否包含某一列
        /// </summary>
        /// <param name="table"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static bool HasColumn(this DataTable table, string columnName)
        {
            if (table == null || columnName.IsNullOrEmpty())
            {
                return false;
            }
            foreach (DataColumn dcm in table.Columns)
            {
                if (string.Equals(dcm.ColumnName, columnName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 如果Table为空，返回一个空的List<T>对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="rowName"></param>
        /// <param name="emptyValue"></param>
        /// <returns></returns>
        public static List<T> ColumnToList<T>(this DataTable table, string columnName, T emptyValue)
        {
            if (table.Columns.Contains(columnName) == false)
            {
                throw new ArgumentOutOfRangeException("不存在的列名", columnName);
            }
            if (table.IsNullOrEmpty())
            {
                return new List<T>(0);
            }
            List<T> lstReturn = new List<T>(table.Rows.Count);
            foreach (DataRow drw in table.Rows)
            {
                lstReturn.Add(drw[columnName].ToSimpleT<T>(emptyValue));
            }
            return lstReturn;
        }

        public static Dictionary<TKey, TValue> RowToDictionary<TKey, TValue>(this DataTable table, string keyColumnName, string valueColumnName, TKey emptyKey, TValue emptyValue)
        {
            return ObjectExtension.RowToDictionary<TKey, TValue>(table, keyColumnName, valueColumnName, emptyKey, emptyValue, false);
        }

        /// <summary>
        /// 将一个DataTaboe中指定的两列转换成一个字典。
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="table"></param>
        /// <param name="keyColumnName"></param>
        /// <param name="valueColumnName"></param>
        /// <param name="emptyKey"></param>
        /// <param name="emptyValue"></param>
        /// <param name="ignoreExistKey">是否避免Key冲突（如果为false，但是指定key列中有两个key相同，引发Dictionary的Key值重复的错误）。</param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> RowToDictionary<TKey, TValue>(this DataTable table, string keyColumnName, string valueColumnName, TKey emptyKey, TValue emptyValue, bool ignoreExistKey)
        {
            if (table.Columns.Contains(keyColumnName) == false || table.Columns.Contains(valueColumnName) == false)
            {
                throw new ArgumentOutOfRangeException("不存在的列名", string.Concat(keyColumnName, "或者", valueColumnName));
            }
            if (table.IsNullOrEmpty())
            {
                return new Dictionary<TKey, TValue>(0);
            }
            Dictionary<TKey, TValue> lstReturn = new Dictionary<TKey, TValue>(table.Rows.Count);
            foreach (DataRow drw in table.Rows)
            {
                TKey tk = drw[keyColumnName].ToSimpleT<TKey>(emptyKey);
                if (ignoreExistKey && lstReturn.ContainsKey(tk))
                {
                    continue;
                }
                lstReturn.Add(tk, drw[valueColumnName].ToSimpleT<TValue>(emptyValue));
            }
            return lstReturn;
        }

        /// <summary>
        /// 从QueryString当中获取指定值，并进行安全的类型转换。如果获取不到，返回指定的defaultValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="parameterName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetValueFromQueryString<T>(this HttpContext context, string parameterName, T defaultValue)
        {
            string strValue = context.Request.QueryString[parameterName];
            if (string.IsNullOrEmpty(strValue))
            {
                return defaultValue;
            }
            return strValue.ToSimpleT<T>(defaultValue);

        }

        /// <summary>
        /// 从Request当中获取指定值，并进行安全的类型转换。如果获取不到，返回指定的defaultValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="parameterName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetValueFromRequest<T>(this HttpContext context, string parameterName, T defaultValue)
        {
            string strValue = context.Request[parameterName];
            if (string.IsNullOrEmpty(strValue))
            {
                return defaultValue;
            }
            return strValue.ToSimpleT<T>(defaultValue);

        }

        #region Sql Condition

        /// <summary>
        /// 示例：  StartTime.AppendNullableDateTimeAsSqlCondition(sbWhereCondition, " AND T.AddDate >", "@StartDate", lstParameters, true, false);  如果value不为null则往sbWhereCondition当中 and AND T.AddDate >@StartDate ，并且往lstParameter当中加一个参数。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sqlContainer"></param>
        /// <param name="conditionText"></param>
        /// <param name="parameterName"></param>
        /// <param name="parameterContainer"></param>
        /// <param name="isStart"></param>
        /// <param name="isEnd"></param>
        public static void AppendNullableDateTimeAsSqlCondition(this DateTime? value, StringBuilder sqlContainer, string conditionText, string parameterName, List<SqlParameter> parameterContainer, bool isStart, bool isEnd)
        {
            if (value == null || value.Value <= new DateTime(1970, 1, 1))
            {
                return;
            }
            sqlContainer.Append(conditionText).Append(" ").Append(parameterName).Append(" ");
            if (isStart)
            {
                parameterContainer.Add(new SqlParameter(parameterName, new DateTime(value.Value.Year, value.Value.Month, value.Value.Day)));
                return;
            }
            if (isEnd)
            {
                DateTime dtValue = value.Value.AddDays(1);
                parameterContainer.Add(new SqlParameter(parameterName, new DateTime(dtValue.Year, dtValue.Month, dtValue.Day)));
                return;
            }
            parameterContainer.Add(new SqlParameter(parameterName, value));
        }

        /// <summary>
        /// 将当前字符串作为一个value追加为Sql语句的条件，如果value为null或者Empty，不追加。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sqlContainer"></param>
        /// <param name="conditionText"></param>
        /// <param name="parameterName"></param>
        /// <param name="parameterContainer"></param>
        public static void AppendStringAsSqlCondition(this string value, StringBuilder sqlContainer, string conditionText, string parameterName, List<SqlParameter> parameterContainer)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }
            sqlContainer.Append(conditionText).Append(" ").Append(parameterName).Append(" ");
            parameterContainer.Add(new SqlParameter(parameterName, value));
        }


        /// <summary>
        /// 将当前字符串作为一个value追加为Sql语句的条件，如果value为null或者Empty，不追加。后面的两个参数如果都传递%的话可用做like查询。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sqlContainer"></param>
        /// <param name="conditionText"></param>
        /// <param name="parameterName"></param>
        /// <param name="parameterContainer"></param>
        /// <param name="appendix">生成parameter的时候要在value后追加的字符</param>
        /// <param name="prefix">生成parameter的时候要在value前追加的字符</param>
        public static void AppendStringAsSqlCondition(this string value, StringBuilder sqlContainer, string conditionText, string parameterName, List<SqlParameter> parameterContainer, string prefix, string appendix)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }
            sqlContainer.Append(conditionText).Append(" ").Append(parameterName).Append(" ");
            parameterContainer.Add(new SqlParameter(parameterName, string.Concat(prefix, value, appendix)));
        }

        /// <summary>
        /// 除了某些状态，追加sql语句
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sqlContainer"></param>
        /// <param name="conditionText"></param>
        /// <param name="exceptedValues"></param>
        public static void AppendIntAsSqlConditionExcept(this int value, StringBuilder sqlContainer, string conditionText, params int[] exceptedValues)
        {
            if (exceptedValues.Contains(value))
            {
                return;
            }
            sqlContainer.Append(conditionText).Append(value);
        }

        /// <summary>
        /// 除了某些状态，追加sql语句
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sqlContainer"></param>
        /// <param name="conditionText"></param>
        /// <param name="exceptedValues"></param>
        public static void AppendIntAsSqlConditionExcept(this Enum value, StringBuilder sqlContainer, string conditionText, params Enum[] exceptedValues)
        {
            if (exceptedValues.Contains(value))
            {
                return;
            }
            sqlContainer.Append(conditionText).Append(Convert.ToInt32(value));
        }

        /// <summary>
        /// 如果符合某些状态，追加sql语句
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sqlContainer"></param>
        /// <param name="conditionText"></param>
        /// <param name="expectedValues"></param>
        public static void AppendIntAsSqlConditionWhen(this int value, StringBuilder sqlContainer, string conditionText, params int[] expectedValues)
        {
            if (expectedValues.Contains(value) == false)
            {
                return;
            }
            sqlContainer.Append(conditionText).Append(value);
        }



        /// <summary>
        /// 追加一个可空类型到SQL语句中（当它不为空的时候），参数中的输出结果：And SuitId=3
        /// </summary>
        /// <param name="value">3?</param>
        /// <param name="sqlContainer"></param>
        /// <param name="conditionText">And SuitId=</param>
        public static void AppendNullableNumericAsSqlConditionWhenNotNull<T>(this T? value, StringBuilder sqlContainer, string conditionText) where T : struct
        {
            if (value == null)
            {
                return;
            }
            sqlContainer.Append(conditionText).Append(value.Value);
        }

        /// <summary>
        /// 如果符合某些状态，追加sql语句
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sqlContainer"></param>
        /// <param name="conditionText"></param>
        /// <param name="expectedValues"></param>
        public static void AppendIntAsSqlConditionWhen(this Enum value, StringBuilder sqlContainer, string conditionText, params Enum[] expectedValues)
        {
            if (expectedValues.Contains(value) == false)
            {
                return;
            }
            sqlContainer.Append(conditionText).Append(Convert.ToInt32(value));
        }

        #endregion

        #region Sql Helper

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <param name="nullValueReplacement">When value is null ,use this.</param>
        /// <returns></returns>
        public static SqlParameter ToSqlParameter(this object value, string parameterName, object nullValueReplacement)
        {
            if (value == null)
            {
                return new SqlParameter(parameterName, nullValueReplacement);
            }
            return new SqlParameter(parameterName, value);
        }

        #endregion


        /// <summary>
        /// 格式化，如果是null，返回string.Empty
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string FormatToString(this DateTime? value, string format)
        {
            if (value == null)
            {
                return string.Empty;
            }
            return value.Value.ToString(format);
        }

        /// <summary>
        /// 将decimal的值格式化成货币格式的字符。
        /// </summary>
        /// <param name="value">System.Decimal</param>
        /// <returns>货币格式的字符</returns>
        public static string ToCurrency(this decimal value)
        {
            return value.ToString("#,##0.00");
        }

        /// <summary>
        /// 将decimal的值格式化成货币格式的字符。
        /// </summary>
        /// <param name="value">System.Object</param>
        /// <returns>货币格式的字符</returns>
        /// <exception cref="System.InvalidCastException ">转换成decimal失败。</exception>
        public static string ToCurrency(this object value)
        {
            if (value == null)
                return "0.00";
            try
            {
                return ((decimal)value).ToString("#,##0.00");
            }
            catch
            {
                return "0.00";
            }
        }

        #region 序列化与反序列化

        /// <summary>
        /// 微软的默认序列化
        /// </summary>
        /// <param name="value">要序列化的对象</param>
        /// <param name="capacity">预计容量，默认1024</param>
        /// <returns>序列化后的字节数组</returns>
        public static byte[] BinarySerialize(this object value, int capacity = 1024)
        {
            using (Stream srm = new MemoryStream(capacity))
            {
                var bfmProvider = new BinaryFormatter();
                bfmProvider.Serialize(srm, value);
                byte[] bytContent = new byte[srm.Length];
                srm.Seek(0, SeekOrigin.Begin);
                srm.Read(bytContent, 0, bytContent.Length);
                return bytContent;
            }
        }

        /// <summary>
        /// 微软的默认反序列化；字节流为空或者反序列化出错的时候返回emptyValue。
        /// </summary>
        /// <param name="binaryData">要反序列化的字节流</param>
        /// <param name="emptyValue">空序列</param>
        /// <returns>反序列化后的对象</returns>
        public static T BinaryDeserialize<T>(this byte[] binaryData, T emptyValue)
        {
            if (binaryData.IsNullOrEmpty())
            {
                return emptyValue;
            }
            try
            {
                return binaryData.BinaryDeserialize<T>();
            }
            catch
            {
                return emptyValue;
            }
        }

        /// <summary>
        /// 微软的默认反序列化
        /// </summary>
        /// <param name="binaryData">要反序列化的字节流</param>
        /// <returns>反序列化后的对象</returns>
        public static T BinaryDeserialize<T>(this byte[] binaryData)
        {
            if (binaryData.IsNullOrEmpty())
            {
                throw new ArgumentNullException("序列不能为空。");
            }
            using (Stream srm = new MemoryStream(binaryData.Count()))
            {
                srm.Write(binaryData, 0, binaryData.Length);
                srm.Seek(0, SeekOrigin.Begin);
                var bfmProvider = new BinaryFormatter();
                object objValue = bfmProvider.Deserialize(srm);
                return (T)objValue;
            }
        }


        #endregion

    }
}
