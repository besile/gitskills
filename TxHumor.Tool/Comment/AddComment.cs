using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TxHumor.BLL;
using TxHumor.Common;
using TxHumor.Model;

namespace TxHumor.Tool.Comment
{
    public class AddComment
    {
        public static T_Humor_Comment GetHumorComment(int humorId,string html)
        {
            string regContent = @"<span class=""zxhffont"">([^<]+)?</span>";
            string regUserInfo = @"<a class=""newUser"" target=""_blank"" href=""/u/([^""]+)?"">([^：]+)?：</a>";
            string regFloor = @"<em>(\d+)?楼</em>";
            string regSupportNumAndId = @"<span class=""dingBtn"" id=""liangle_([^""]+)?"" [^>]+?>(\d+)?</span>";
            string regCommentXml = @"<div class=""yyoFont"">

                                            <em>(\d+)?楼</em>
                                                <a href=""/u/([^""]+)?"">([^：]+)?：</a>
                                            <span>(.+)?</span>
                                        </div>";
            string commentXml = @"<Root><ReplyId>{0}</ReplyId><Floor>{1}</Floor><UserId>{2}</UserId><UserName>{3}</UserName><Content>{4}</Content></Root>";
            string content=Regex.Match(html, regContent).Groups[1].Value;
            Match mUser = Regex.Match(html, regUserInfo);
            int userId = mUser.Groups[1].Value.ToSimpleT(0);
            string userName = mUser.Groups[2].Value;
            Match mSupport = Regex.Match(html, regSupportNumAndId);
            int supportNum = mSupport.Groups[2].Value.ToSimpleT(0);
            int commentId = mSupport.Groups[1].Value.ToSimpleT(0);
            Match mComent = Regex.Match(html, regCommentXml);
            commentXml = string.Format(commentXml, commentId, mComent.Groups[1].Value, mComent.Groups[2].Value,
                mComent.Groups[3].Value, mComent.Groups[4].Value);
            int floor=Regex.Match(html, regFloor).Groups[1].Value.ToSimpleT(0);
            T_Humor_Comment comment=new T_Humor_Comment()
            {
                CreateUserId = userId,
                CreateUserName = userName,
                CommentContent = content,
                CommentXml = commentXml,
                SupportNum = supportNum,
                IpAddress = "127.0.0.1",
                HumorId = humorId,
                Floor = floor
            };
            return null;
        }

        private static Queue<string> queue = new Queue<string>();
        public static void ThreadPoolAddHumor(int humorId)
        {
            for (int j = 0; j <= max; j++)
            {
                queue.Enqueue("http://www.pengfu.com/content_"+humorId+"_1.html");
                humorId++;
            }
            GetContent(null);
            //for (int j = 0; j <= max; j++)
            //{
            //    ThreadPool.QueueUserWorkItem(GetContent, null);
            //}
            //while (true)
            //{
            //    if (k == max)
            //    {
            //        break;
            //    }
            //}
        }
        private static int i = 0;
        private static readonly int max = 10;
        static volatile int k = 1;
        private static object o = new object();
        public static void GetContent(object url)
        {
            //while (true)
            //{
            //    using (WebClient wc = new WebClient())
            //    {
            //        string html;

            //        string address=queue.Dequeue();
            //        wc.Encoding = Encoding.UTF8;
            //        try
            //        {
            //            html = wc.DownloadString(address);
            //        }
            //        catch (Exception ex)
            //        {

            //            continue;
            //        }
            //        string humorId = address.Replace("http://www.pengfu.com/content_", "").Replace("_1.html", "");
            //        T_Humor_Comment humorInfo = GetHumorComment(humorId.ToSimpleT(0), html);
            //        lock (o)
            //        {
            //            //bll_HumorInfo.AddHumorInfo(humorInfo);
            //        }

            //    }
            //    if (i == max)
            //    {
            //        break;
            //    }
            //}
            //k++;
            using (WebClient wc = new WebClient())
            {
                string html;

                string address = queue.Dequeue();
                wc.Encoding = Encoding.UTF8;
                NameValueCollection nc=new NameValueCollection();
               
                string humorId = address.Replace("http://www.pengfu.com/content_", "").Replace("_1.html", "");
                nc.Add("humorId",humorId);
                nc.Add("pageIndex","1");
                nc.Add("type","1");
                wc.Headers.Add(nc);
               
                html = wc.DownloadString(address);
                T_Humor_Comment humorInfo = GetHumorComment(humorId.ToSimpleT(0), html);
                lock (o)
                {
                    //bll_HumorInfo.AddHumorInfo(humorInfo);
                }

            }
        }
    }
}
