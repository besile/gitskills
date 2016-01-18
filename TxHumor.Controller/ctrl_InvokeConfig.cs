using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using TxHumor.Common;
using TxHumor.Config;
using TxHumor.Controller.model;

namespace TxHumor.Controller
{
    public class ctrl_InvokeConfig
    {
        /// <summary>
        /// 从配置文件中获取数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static m_InvokeConfig GetConfig(string key)
        {
            string _cacheConfigFilePath = AppConfig.GetConfigFilePath(
                    AppConfig.GetApp("GetCaseFilePath"));
            XElement xmlConfig = com_XmlLoad.LoadXmlConfig(_cacheConfigFilePath);
            var config =
                xmlConfig.Elements("KeyItem")
                    .Where(m => m.Attribute("ID").Value == key)
                    .Select(c => new m_InvokeConfig()
                    {
                        ID = key,
                        AssemblyPath =
                            c.Element("AssemblyPath") == null ? string.Empty : c.Element("AssemblyPath").Value,
                        ClassName = c.Element("ClassName") == null ? string.Empty : c.Element("ClassName").Value,
                        MethodName = c.Element("MethodName") == null ? string.Empty : c.Element("MethodName").Value,
                    });
            m_InvokeConfig invokeConfig = config.First();
            return invokeConfig;
        }
        /// <summary>
        /// 从配置文件中更新数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static m_InvokeConfig UpdateConfig(string key)
        {
            string _cacheConfigFilePath = AppConfig.GetConfigFilePath(
                    AppConfig.GetApp("UpdateCaseFilePath"));
            XElement xmlConfig = com_XmlLoad.LoadXmlConfig(_cacheConfigFilePath);
            var config =
                xmlConfig.Elements("KeyItem")
                    .Where(m => m.Attribute("ID").Value == key)
                    .Select(c => new m_InvokeConfig()
                    {
                        ID = key,
                        AssemblyPath =
                            c.Element("AssemblyPath") == null ? string.Empty : c.Element("AssemblyPath").Value,
                        ClassName = c.Element("ClassName") == null ? string.Empty : c.Element("ClassName").Value,
                        MethodName = c.Element("MethodName") == null ? string.Empty : c.Element("MethodName").Value,
                    });
            m_InvokeConfig invokeConfig = config.First();
            return invokeConfig;
        }
    }
}
