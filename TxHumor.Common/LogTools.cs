using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TxHumor.Common
{
    public static class LogTools
    {
        public readonly static log4net.ILog Log;

        static LogTools()
        {
            log4net.Config.XmlConfigurator.Configure();
            //Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            Log = log4net.LogManager.GetLogger(string.Empty);
        }
    }
}
