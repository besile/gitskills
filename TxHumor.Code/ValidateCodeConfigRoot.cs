using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TxHumor.Code
{
    public class ValidateCodeConfigRoot : ConfigurationElement
    {
        [ConfigurationProperty("DefaultValidatecodeName")]
        public string DefaultValidatecodeName
        {
            get
            {
                return (string)this["DefaultValidatecodeName"];
            }
            set
            {
                this["DefaultValidatecodeName"] = value;
            }
        }

        [ConfigurationProperty("Validatecodes")]
        public ValidatecodesConfig ValidateCodes
        {
            get
            { return (ValidatecodesConfig)this["Validatecodes"]; }
            set
            { this["Validatecodes"] = value; }
        }
    }
}