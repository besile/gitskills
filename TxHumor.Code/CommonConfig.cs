using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TxHumor.Code
{
    public class CommonConfig : ConfigurationElement
    {
        [ConfigurationProperty("ValidateCodeConfig")]
        public ValidateCodeConfigRoot ValidateCodeConfigRoot
        {
            get
            {
                return (ValidateCodeConfigRoot)this["ValidateCodeConfig"];
            }
            set
            {
                this["ValidateCodeConfig"] = value;
            }
        }
    }
}