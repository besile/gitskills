using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using TxHumor.BLL;
using TxHumor.Common;
using TxHumor.Model;

namespace TxHumor.Tool.Humor
{
    public class AddPengFuHumor
    {
        public static T_Humor_HumorInfo GetHumorInfo(string html)
        {
            /*
             <div id="fiddencontent_1266911" class="humordatacontent" style="display: none"></div>
             */

            string regTitle = @"<a  href=""javascript:;"" >(.+)?</a>
                        <!--版主导航条开始-->
";
            string regContent = @"<!--编辑导航条开始-->
                    </div>
                    <div class=""imgbox"">
                        (.+)?
                    </div>
";
            string regGood = @"<em class=""sicon"" id=""span_SupportNum[^""]+?""></em>\s*<span>(\d+)?</span>";
            string regBad = @"<em class=""xicon"" id=""span_OpposeNum[^""]+?""></em>\s*<span>(\d+)?</span>";
            string regCommentNum = @"<span class=""plFont"">(\d+)?</span>";
            string commentNum = Regex.Match(html, regCommentNum).Groups[1].Value;
            var match = Regex.Match(html, regTitle);
            if (!match.Success)
            {
                return null;
            }
            string title = match.Groups[1].Value;
            var contentMatch = Regex.Match(html, regContent);
            string content = contentMatch.Groups[1].Value;
            int supportNum = Regex.Match(html, regGood).Groups[1].Value.ToSimpleT(0);
            int opposeNum = Regex.Match(html, regBad).Groups[1].Value.ToSimpleT(0);
            string regUserInfo = @"<a href=""/u/([^""]+)?"" target=""_blank""><img src=""([^""]+)?"" width=""35"" height=""35"" /></a>
";
            string regTags = @"<p id=""em_[^""]+?"">

                                        <a target=""_blank"" href='/tag_\d+?_1.html'>(.+)?</a>
";
            Match matchUser = Regex.Match(html, regUserInfo);
            string face = "http://www.jiongshibaike.com/Data/Static/face/default.png";
            int userId = 0;
            string userName = "匿名";
            if (matchUser.Success)
            {
                face = matchUser.Groups[2].Value;
                userId = Convert.ToInt32(matchUser.Groups[1].Value);
            }
            var matchs = Regex.Matches(html, regTags);
            string tags = string.Empty;
            foreach (Match m in matchs)
            {
                string tag = m.Groups[1].Value;
                tags += HttpUtility.UrlDecode(tag) + ",";
            }
            T_Humor_HumorInfo humorInfo = new T_Humor_HumorInfo()
            {
                HumorTitle = title,
                HumorContent = content,
                CreateUserId = userId,
                CreateUserName = userName,
                SupportNum = supportNum,
                OpposeNum = opposeNum,
                TagIds = tags,
                HumorUbbContent = "",
                HumorType = GetHumorType(content),
                IpAddress = "127.0.0.1",
                CommentNum = commentNum.ToSimpleT(0)
            };
            return humorInfo;
        }
        public static int GetHumorType(string content)
        {
            if (content.Contains("img"))
            {
                return 1;
            }
            return 0;
        }
        private static Queue<string> queue = new Queue<string>();
        public static void ThreadPoolAddHumor(int humorId)
        {
            queue.Clear();
            for (int j = 0; j < 10000; j++)
            {
                if (!queue.Contains("http://www.pengfu.com/content_" + humorId + "_1.html"))
                {
                    queue.Enqueue("http://www.pengfu.com/content_" + humorId + "_1.html");
                    humorId++;
                }
                
            }
            for (int j = 0; j < max; j++)
            {
                ThreadPool.QueueUserWorkItem(GetContent);
            }
            while (true)
            {
                if (k == max)
                {
                    break;
                }
            }
        }

        private static int i = 0;
        private static readonly int max = 100;
        static volatile int k = 1;
        private static object o = new object();
        public static void GetContent(object m)
        {
            while (true)
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    string html;
                    try
                    {
                        html = wc.DownloadString(queue.Dequeue());
                    }
                    catch (Exception ex)
                    {

                        continue;
                    }

                    T_Humor_HumorInfo humorInfo = GetHumorInfo(html);
                    if (humorInfo == null)
                    {
                        continue;
                    }
                    lock (o)
                    {
                        bll_HumorInfo.AddHumorInfo(humorInfo);
                    }

                }
                if (i == max)
                {
                    break;
                }
            }
            k++;
        }
    }
}
