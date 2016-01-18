using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TxHumor.Common.Attr;
using TxHumor.UpdateSolr.Service.bll;

namespace TxHumor.UpdateSolr.Service
{
    public class srv_UpdateSolr
    {
        /// <summary>
        /// 添加solr
        /// </summary>
        /// <param name="mi"></param>
        /// <param name="prams"></param>
        public static void AddSolr(MethodInfo mi, object[] prams)
        {
            object[] attrs = mi.GetCustomAttributes(typeof (Attr_AddSolrAttribute), false);
            foreach (Attr_AddSolrAttribute attr in attrs)
            {
                if (attr == null)
                {
                    continue;
                }
                int index = attr.PramIndex;
                if (index >= 0 && index < prams.Length)
                {
                    //直接是传过来参数
                    if (string.IsNullOrWhiteSpace(attr.Key))
                    {
                        string humorId = prams[index].ToString();
                        srv_SolrHumor.AddSolrHumor(humorId);
                    }
                    else
                    {
                        Type type = attr.Key.GetType();
                        PropertyInfo pi = type.GetProperty(attr.Key);
                        var humorId=pi.GetValue(prams[index], null);
                        srv_SolrHumor.AddSolrHumor(humorId.ToString());
                    }
                }
            }
        }
    }
}
