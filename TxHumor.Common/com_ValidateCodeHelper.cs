﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using TxHumor.Code;

namespace TxHumor.Common
{
    public class com_ValidateCodeHelper : IHttpHandler
    {

        public static bool CheckCode(string code)
        {
            code = code.Trim().ToLower();
            string ip = RequestHelper.GetIP();
            var obj = com_MemcacheCacheManager.Get(ip);
            return (obj != null && code == obj.ToString());
        }
        private void RecordVc(string code)
        {
            string ip = RequestHelper.GetIP();
            code.Trim().ToLower();
            com_MemcacheCacheManager.Add(ip, code, 5000);
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AppendHeader("P3P", @"CP=""CAO PSA OUR""");
            context.Response.AppendHeader("Cache-Control", @"no-cache");
            context.Response.AppendHeader("Pragma", @"no-cache");
            context.Response.AppendHeader("Expires", @"-1");
            string validatecodeName = context.Request["ValidatecodeName"];
            Action<string> ac = RecordVc;
            if (string.IsNullOrEmpty(validatecodeName))
            {
                ValidatecodeTool.OutputImageByAction(ac);
            }
            else
            {
                ValidatecodeTool.OutputImageByAction(validatecodeName, ac);
            }
            context.Response.End();
        }
    }
}
