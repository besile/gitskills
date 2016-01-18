using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TxHumor.Cache.Service.model;
using TxHumor.Common;
using TxHumor.Config;

namespace TxHumor.Cache.Service
{
    public class srv_CacheConfig
    {
        public static m_CacheConfig GetConfig(string key)
        {
            string _cacheConfigFilePath = AppConfig.GetConfigFilePath(
                    AppConfig.GetApp("CacheCaseFilePath"));
            XElement xmlConfig = com_XmlLoad.LoadXmlConfig(_cacheConfigFilePath);
            var configs = xmlConfig.Elements("KeyItem").Where(m => m.Attribute("ID").Value == key).Select(
                c => new m_CacheConfig()
                {
                    ID = key,
                    AssemblyPath =
                        c.Element("AssemblyPath") == null ? string.Empty : c.Element("AssemblyPath").Value,
                    ClassName = c.Element("ClassName") == null ? string.Empty : c.Element("ClassName").Value,
                    MethodName = c.Element("MethodName") == null ? string.Empty : c.Element("MethodName").Value,
                    ExpTime = c.Element("ExpTime") == null ? 0 : int.Parse(c.Element("ExpTime").Value),
                    Pre = c.Element("Pre") == null ? string.Empty : c.Element("Pre").Value
                });
            m_CacheConfig cacheConfig = configs.FirstOrDefault();
            return cacheConfig;
        }
    }
}
