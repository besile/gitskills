using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TxHumor.Common;
using TxHumor.DAL;
using TxHumor.Model;
using TxHumor.Solr;

namespace TxHumor.UpdateSolr.Service.bll
{
    public class srv_SolrHumor
    {
        public static void AddSolrHumor(string humorIds)
        {
            DataTable dt=dal_HumorInfo.GetHumorInfoByIds(humorIds);
            List<T_Humor_HumorInfo> humors=com_ModelFillHelper.FillModelList<T_Humor_HumorInfo>(dt);
            SolrHumor.AddHumorSolr(humors);
        }
    }
}
