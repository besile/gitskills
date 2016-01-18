using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SolrNet;
using SolrNet.Commands.Parameters;
using TxHumor.Common;
using TxHumor.Model;
using TxHumor.Solr.Models;

namespace TxHumor.Solr
{
    public class SolrHumor
    {
        static SolrHumor()
        {
            Startup.Init<SolrHumorModel>(UICommonConfig.GetMemcachedValueFromAppSettings("SolrHost", string.Empty));
        }

        public static void AddHumorSolr(List<T_Humor_HumorInfo> humors)
        {
            var solrHumors = humors.Select(GetSolrHumor).ToList();
            SolrManage.Excute<SolrHumorModel>(solr =>
            {
                solr.AddRange(solrHumors);
                solr.Commit();
            });
        }

        public static SolrHumorModel GetSolrHumor(T_Humor_HumorInfo humor)
        {
            if (humor == null)
            {
                return null;
            }
            int iHourCount = Convert.ToInt32(Math.Floor((DateTime.Now - humor.ShowTime).TotalHours));
            return new SolrHumorModel()
            {
                CommentNum = humor.CommentNum,
                CreateUserId = humor.CreateUserId,
                HumorContent = com_StringHelper.FilterContent(humor.HumorContent),
                HumorId = humor.Id,
                HumorTitle = humor.HumorTitle,
                Id = humor.Id.ToString(),
                IsDelete = humor.IsDelete,
                OpposeNum = humor.OpposeNum,
                SupportNum = humor.SupportNum,
                Tags = string.IsNullOrEmpty(humor.TagIds) ? new List<string>(0) : (humor.TagIds.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList()),
                Score = (((humor.SupportNum - humor.OpposeNum * 5 + humor.CommentNum * 3) * (Math.Pow(2.71828182845905, (-Math.Pow(iHourCount, 3) / 144)) + 2 * Math.Pow(2.71828182845905, (-Math.Pow(iHourCount, 2) / 89))) / 3) * humor.Factor)
            };
        }

        public static List<SolrHumorModel> GetHumorSolrsByQueryText(string queryText, int start, int rows,
            out int total, string orderBy = "humorid")
        {
            queryText = string.IsNullOrWhiteSpace(queryText) ? "*:*" : "content:" + queryText + " OR title: *" + queryText + "* OR tags:*" + queryText + "*";
            int iTotal = 0;
            List<SolrHumorModel> humors = SolrManage.Excute<SolrHumorModel, List<SolrHumorModel>>(solr =>
            {
                var result = solr.Query(queryText, new QueryOptions()
                {
                    Start = start,
                    Rows = rows,
                    OrderBy = new Collection<SortOrder>() { new SortOrder(orderBy, Order.DESC) },
                    Fields = new Collection<string>()
                    {
                        "humorid",
                        "title",
                        "content",
                        "supportnum",
                        "opposenum",
                        "commentnum",
                        "tags",
                        "userid",
                        "username",
                        "showtime",
                        "humorscore"
                    },
                    //FilterQueries = new List<ISolrQuery>() { new SolrQuery("showtime:[NOW/DAY-1DAY TO NOW/DAY]") },//一天之内必须罗马时间格式
                });
                iTotal = result.NumFound;
                return result;
            });
            total = iTotal;
            return humors;
        }


        public static List<T_Humor_HumorInfo> GetSolrHumorList()
        {
            return null;
        }
    }
}
