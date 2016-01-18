using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TxHumor.Code
{
    public class CommonPlatformConfiurationSectionHandler : ConfigurationSection
    {
        [ConfigurationProperty("CommonConfig")]
        public CommonConfig CommonConfig
        {
            get
            {
                return (CommonConfig)this["CommonConfig"];
            }
            set
            {
                this["CommonConfig"] = value;
            }
        }
    }
}