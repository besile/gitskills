using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.ServiceLocation;
using SolrNet;

namespace TxHumor.Solr
{
    public static class SolrManage
    {

        public static void Excute<TSolrDocument>(Action<ISolrOperations<TSolrDocument>> logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException("logic");
            }
            logic(ServiceLocator.Current.GetInstance<ISolrOperations<TSolrDocument>>());
        }

        public static TReturn Excute<TSolrDocument, TReturn>(Func<ISolrOperations<TSolrDocument>, TReturn> logic)
        {
            if (logic == null)
            {
                throw new ArgumentNullException("logic");
            }
            return logic(ServiceLocator.Current.GetInstance<ISolrOperations<TSolrDocument>>());
        }
    }
}
