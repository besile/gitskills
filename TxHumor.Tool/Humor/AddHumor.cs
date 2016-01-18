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
    public class AddHumor
    {
        public static T_Humor_HumorInfo GetHumor(string html)
        {
            string regTitle = @"<div class=""mala-title"">
					<h2>(.+)?</h2>
				</div>";
            string regContent = @"<div class=""mala-img"">
											<a class=""mala-link-jump"" [^>]*> (.+)?</a>					
					<div class=""mala-img-sponsor fn-clear"">
						<!--广告位-->
						广告
						<!--广告位end-->
					</div>
					<!-- // mala-img-sponsor end -->
				</div>";
            string regGood = @"<i class=""ui-icon give-good""></i>[^<]*<em>(\d+)?</em>";
            string regBad = @"<i class=""ui-icon give-bad""></i>[^<]*<em>(\d+)?</em>";
            var match = Regex.Match(html, regTitle);
            string title = match.Groups[1].Value;
            var contentMatch = Regex.Match(html, regContent);
            string content = contentMatch.Groups[1].Value;
            int supportNum = Regex.Match(html, regGood).Groups[1].Value.ToSimpleT(0);
            int opposeNum = Regex.Match(html, regBad).Groups[1].Value.ToSimpleT(0);
            string regUserInfo = @"<a class=""mala-author-avatar"" href=""#"">[^<]*?<img src=""([^""]+)?""[^>]*?></a>[^<]*?<h5><a href=""http://www.jiongshibaike.com/users/([^""]+)?"">([^<]+)?</a></h5>";
            string regTags = @"<a href=""http://www.jiongshibaike.com/gs/([^""]+)?"" title=""([^""]+)?"">([^<]+)?</a>";
            Match matchUser=Regex.Match(html, regUserInfo);
            string face = "http://www.jiongshibaike.com/Data/Static/face/default.png";
            int userId = 0;
            string userName = "匿名";
            if (matchUser.Success)
            {
                face = matchUser.Groups[1].Value;
                userId = Convert.ToInt32(matchUser.Groups[2].Value);
                userName = matchUser.Groups[3].Value;
            }
            var matchs = Regex.Matches(html, regTags);
            string tags = string.Empty;
            foreach (Match m in matchs)
            {
                string tag = m.Groups[1].Value;
                tags += HttpUtility.UrlDecode(tag) + ",";
            }
            T_Humor_HumorInfo humorInfo=new T_Humor_HumorInfo()
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
                IpAddress = "127.0.0.1"
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
        private static Queue<string> queue=new Queue<string>(); 
        public static void ThreadPoolAddHumor(int humorId)
        {
            for (int j = 0; j < 10000; j++)
            {
                queue.Enqueue("http://www.jiongshibaike.com/contents/"+humorId);
                humorId++;
            }
            for (int j = 0; j < max; j++)
            {
                ThreadPool.QueueUserWorkItem(GetContent, queue.Dequeue());
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
        private static object o=new object();
        public static void GetContent(object url)
        {
            while (true)
            {
                using (WebClient wc = new WebClient())
                {
                    string html;
                    try
                    {
                        html = wc.DownloadString(url.ToString());
                    }
                    catch (Exception ex)
                    {
                        
                        continue;
                    }
                    
                    T_Humor_HumorInfo humorInfo=GetHumor(html);
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
