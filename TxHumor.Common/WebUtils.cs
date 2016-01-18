using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace TxHumor.Common
{
    public class WebUtils
    {
        ///  <summary> 
        ///  取得客户端真实IP。如果有代理则取第一个非内网地址
        ///  </summary> 
        public static string GetRequestIP()
        {
            IPAddress tempIP;

            string result = String.Empty;

            result = HttpContext.Current.Request.ServerVariables["HTTP_CDN_SRC_IP"];
            if (!string.IsNullOrEmpty(result))
            {
                if (IPAddress.TryParse(result, out tempIP) && result.Substring(0, 3) != "10."
                                    && result.Substring(0, 7) != "192.168"
                                    && result.Substring(0, 7) != "172.16.")  //代理即是IP格式  
                {
                    return result;
                }
            }


            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (result != null && result != String.Empty)
            {

                //可能有代理
                if (result.IndexOf(".") == -1)        //没有“.”肯定是非IPv4格式
                    result = null;
                else
                {
                    if (result.IndexOf(",") != -1)
                    {
                        //有“,”，估计多个代理。取第一个不是内网的IP。
                        result = result.Replace(" ", "").Replace("'", "").Replace("\"", "");
                        string[] temparyip = result.Split(",;".ToCharArray());
                        for (int i = 0; i < temparyip.Length; i++)
                        {

                            if (IPAddress.TryParse(temparyip[i], out tempIP)
                                    && temparyip[i].Substring(0, 3) != "10."
                                    && temparyip[i].Substring(0, 7) != "192.168"
                                    && temparyip[i].Substring(0, 7) != "172.16.")
                            {
                                return temparyip[i];        //找到不是内网的地址
                            }
                        }
                    }
                    else if (IPAddress.TryParse(result, out tempIP))  //代理即是IP格式
                        return result;
                    else
                        result = null;        //代理中的内容 非IP，取IP 
                }
            }

            if (null == result || result == String.Empty)
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (result == null || result == String.Empty)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }

            return result;
        }
    }
}
