using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TxHumor.Code
{
    public class ValidatecodeConfig : ConfigurationElement
    {

        public ValidatecodeConfig()
        {

        }

        public ValidatecodeConfig(string elementName)
        {
            Name = elementName;
        }

        [ConfigurationProperty("ValidatecodeName", IsRequired = true, IsKey = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{};'\"|\\", MinLength = 0, MaxLength = 600)]
        public string Name
        {
            get
            {
                return (string)this["ValidatecodeName"];
            }
            set
            {
                this["ValidatecodeName"] = value;
            }
        }

        [ConfigurationProperty("Width")]
        //[IntegerValidator(MinValue=20)]
        public int Width
        {
            get
            {
                return (int)this["Width"];
            }
            set
            {
                this["Width"] = value;
            }
        }

        [ConfigurationProperty("Height")]
        //[IntegerValidator(MinValue = 15)]
        public int Height
        {
            get
            {
                return (int)this["Height"];
            }
            set
            {
                this["Height"] = value;
            }
        }

        [ConfigurationProperty("FontName", IsRequired = true, IsKey = true)]
        //[StringValidator(InvalidCharacters = "~!@#$%^&*()[]{};'\"|\\", MinLength = 3, MaxLength = 60)]
        public string FontName
        {
            get
            {
                return (string)this["FontName"];
            }
            set
            {
                this["FontName"] = value;
            }
        }

        [ConfigurationProperty("FontSize")]
        //[IntegerValidator(MinValue = 5)]
        public int FontSize
        {
            get
            {
                return (int)this["FontSize"];
            }
            set
            {
                this["FontSize"] = value;
            }
        }

        [ConfigurationProperty("IsDrawNoise", DefaultValue = "false")]
        public bool IsDrawNoise
        {
            get
            {
                return (bool)this["IsDrawNoise"];
            }
            set
            {
                this["IsDrawNoise"] = value;
            }
        }

        [ConfigurationProperty("CharCount")]
        //[IntegerValidator(MinValue = 4)]
        public int CharCount
        {
            get
            {
                return (int)this["CharCount"];
            }
            set
            {
                this["CharCount"] = value;
            }
        }

        [ConfigurationProperty("IsUseNumber")]
        public bool IsUseNumber
        {
            get
            {
                return (bool)this["IsUseNumber"];
            }
            set
            {
                this["IsUseNumber"] = value;
            }
        }

        [ConfigurationProperty("IsDistorted", DefaultValue = true)]
        public bool IsDistorted
        {
            get
            {
                return (bool)this["IsDistorted"];
            }
            set
            {
                this["IsDistorted"] = value;
            }
        }

    }

    public class ValidatecodesConfig : ConfigurationElementCollection
    {
        public ValidatecodesConfig()
        {
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ValidatecodeConfig();
        }


        protected override ConfigurationElement CreateNewElement(
            string elementName)
        {
            return new ValidatecodeConfig(elementName);
        }


        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((ValidatecodeConfig)element).Name;
        }


        public new string AddElementName
        {
            get
            { return base.AddElementName; }

            set
            { base.AddElementName = value; }

        }

        public new string ClearElementName
        {
            get
            { return base.ClearElementName; }

            set
            { base.AddElementName = value; }

        }

        public new string RemoveElementName
        {
            get
            { return base.RemoveElementName; }


        }

        public new int Count
        {

            get { return base.Count; }

        }


        public ValidatecodeConfig this[int index]
        {
            get
            {
                return (ValidatecodeConfig)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public ValidatecodeConfig this[string Name]
        {
            get
            {
                return (ValidatecodeConfig)BaseGet(Name);
            }
        }

        public int IndexOf(ValidatecodeConfig assembly)
        {
            return BaseIndexOf(assembly);
        }

        public void Add(ValidatecodeConfig assembly)
        {
            BaseAdd(assembly);

            // Add custom code here.
        }

        protected override void
            BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
            // Add custom code here.
        }

        public void Remove(ValidatecodeConfig assembly)
        {
            if (BaseIndexOf(assembly) >= 0)
                BaseRemove(assembly.Name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
            // Add custom code here.
        }

    }
}