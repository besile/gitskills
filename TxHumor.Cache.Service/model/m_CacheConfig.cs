﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TxHumor.Cache.Service.model
{
    public class m_CacheConfig
    {
        public string ID { get; set; }
        public string AssemblyPath { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public int ExpTime { get; set; }
        public string Pre { get; set; }
    }
}
