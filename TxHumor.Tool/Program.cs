using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TxHumor.Common;
using TxHumor.Config;
using TxHumor.Controller;
using TxHumor.DAL;
using TxHumor.Model;
using TxHumor.Solr;
using TxHumor.Solr.Models;
using TxHumor.Tool.Comment;
using TxHumor.Tool.Humor;

namespace TxHumor.Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddHumor.ThreadPoolAddHumor(46873);
            //var list=ctrl_ServiceClient.GetService<T_Humor_HumorInfo>(false, "通过逻辑层获取帖子列表", null);
            //string s = @"<a target=""_blank"" href=""/content_1266911_1.html"">一日一囧0604：糗事一箩筐！</a>";
            //string regTitle = @"<a target=""_blank"" href='/content_[^_]+?_1.html'>([^<]+)?</a>";
            //string html=AddPengFuHumor.GetContent("http://www.pengfu.com/xiaohua_1.html");
            //var m = Regex.Match(html, regTitle);
            //string v=m.Groups[1].Value;
            //AddPengFuHumor.ThreadPoolAddHumor(729439);
            //GetHumor();
            //AddComment.ThreadPoolAddHumor(729439);
            int total;
            //List<SolrHumorModel> humors = SolrHumor.GetHumorSolrsByQueryText("单位缺女职员今年一次性从学校里招了七个女实习生有一天几个哥们在一起喝酒他们说你这回发财了七个仙女呀好好选一个可以甩掉光棍的帽子了我一口喝下一杯酒说那哪是七仙女简直就是江南七怪", 1, 10, out total);
            string[] a = new string[]{ "1", "2", "3" };
            Array b = new Int32[] {};
            int res=SqlHelper.ExecuteNonQuery(DbConfig.GetDb("Humor"), CommandType.Text,
                "UPDATE dbo.T_Humor_HumorInfo SET IsDelete=1 WHERE Id IN(@Ids)", new SqlParameter("@Ids", "1,2,3"));
            Console.Read();
        }

        private static void GetHumor()
        {
            DataTable dt=dal_HumorInfo.GetHumorInfo();
            List<T_Humor_HumorInfo> humorInfos=com_ModelFillHelper.FillModelList<T_Humor_HumorInfo>(dt);
            foreach (T_Humor_HumorInfo humorInfo in humorInfos)
            {
                humorInfo.HumorContent=Regex.Replace(humorInfo.HumorContent, @"<span class=""watermark"">@捧腹网 </span>", "");
                humorInfo.HumorContent=Regex.Replace(humorInfo.HumorContent,
                    @"border=""[^""]+?"" class=""[^""]+?"" isbig=""[^""]+?"" smallPic=""[^""]+?"" bigPic=""[^""]+?"" onclick=""[^""]+?""",
                    "");
                if (humorInfo.HumorContent.Contains(".swf"))
                {
                    humorInfo.HumorType = 3;
                }
                else if (humorInfo.HumorContent.Contains(".gif"))
                {
                    humorInfo.HumorType = 2;
                }
                dal_HumorInfo.UpdateHumorInfo(humorInfo);
            }
        }
    }
}
