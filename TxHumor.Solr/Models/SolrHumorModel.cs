using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolrNet.Attributes;

namespace TxHumor.Solr.Models
{
    public class SolrHumorModel
    {
        [SolrUniqueKey("id")]
        public string Id { get; set; }
        [SolrField("humorid")]
        public int HumorId { get; set; }

        //[Attr_MatchField("guid")]
        //[Attr_GuidCachePrimaryKey]
        //[SolrField("guid")]
        //public Guid Uinonkey { get; set; }


        [SolrField("username")]
        public string UserName { get; set; }


        [SolrField("title")]
        public string HumorTitle { get; set; }

        [SolrField("supportnum")]
        public int SupportNum { get; set; }


        [SolrField("opposenum")]
        public int OpposeNum { get; set; }


        [SolrField("commentnum")]
        public int CommentNum { get; set; }


        [SolrField("humorscore")]
        public double Score { get; set; }


        [SolrField("tags")]
        public List<string> Tags { get; set; }



        [SolrField("showtime")]
        public DateTime ShowTime { get; set; }




        [SolrField("userid")]
        public int CreateUserId { get; set; }



        [SolrField("isdelete")]
        public int IsDelete { get; set; }

        /// <summary>
        /// 口碑内容
        /// </summary>

        [SolrField("content")]
        public string HumorContent { get; set; }
    }
}
