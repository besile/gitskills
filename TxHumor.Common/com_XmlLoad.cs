using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TxHumor.Common
{
    public sealed class com_XmlLoad
    {
        private com_XmlLoad()
        {
        }

        private static XElement _instance = null;
        private static Hashtable hash = Hashtable.Synchronized(new Hashtable());
        private static readonly object sync = new object();

        public static XElement LoadXmlConfig(string filePath)
        {
            lock (sync)
            {
                _instance=hash.ContainsKey(filePath) ? hash[filePath] as XElement : null;
            }
            if (_instance == null)
            {
                lock (sync)
                {
                    if (_instance == null)
                    {
                        _instance = XElement.Load(filePath);
                        hash.Add(filePath,_instance);
                    }
                }
            }
            return _instance;
        }
    }
}
