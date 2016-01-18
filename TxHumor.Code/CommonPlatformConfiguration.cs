using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TxHumor.Code
{
    public class CommonPlatformConfiguration 
    {
        /// <summary>
        /// 公用平台配置实例
        /// </summary>
        private static CommonPlatformConfiurationSectionHandler instance;

        /// <summary>
        /// 配置属性
        /// </summary>
        public static CommonPlatformConfiurationSectionHandler Instance
        {
            get
            {
                // Uses "Lazy initialization"
                if (instance == null)
                {
                    instance = (CommonPlatformConfiurationSectionHandler)ConfigurationManager.GetSection("BitAuto.Utils.CommonPlatformConfig");
                }
                return instance;
            }
        }

        /// <summary>
        /// 获得验证码配置
        /// </summary>
        /// <returns>验证码的配置对象</returns>
        public static ValidateCodeConfigRoot GetValidatecodeConfigRoot()
        {
            return Instance.CommonConfig.ValidateCodeConfigRoot;
        }

        /// <summary>
        /// 获得验证码配置
        /// </summary>
        /// <param name="configName"></param>
        /// <returns>验证码的配置对象</returns>
        public static ValidateCodeConfigRoot GetValidatecodeConfigRoot(string configName)
        {
            if (string.IsNullOrEmpty(configName))
            {
                return GetValidatecodeConfigRoot();
            }
            return (Instance.CommonConfig == null || Instance.CommonConfig.ValidateCodeConfigRoot == null) ?
                   GetValidatecodeConfigRoot() :
                   Instance.CommonConfig.ValidateCodeConfigRoot;
        }
    }
}