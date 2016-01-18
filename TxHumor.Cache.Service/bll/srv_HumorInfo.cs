using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TxHumor.Common;
using TxHumor.Config;
using TxHumor.DAL;
using TxHumor.Model;

namespace TxHumor.Cache.Service.bll
{
    public class srv_HumorInfo
    {
        public static T_Humor_HumorInfo GetHumorInfoById(int humorId)
        {
            DataTable dt=dal_HumorInfo.GetHumorInfoById(humorId);
            return com_ModelFillHelper.FillModel<T_Humor_HumorInfo>(dt);
        }

        public static List<T_Humor_HumorInfo> GetHumorInfoByIds(string humorIds)
        {
            DataTable dt = dal_HumorInfo.GetHumorInfoByIds(humorIds);
            return com_ModelFillHelper.FillModelList<T_Humor_HumorInfo>(dt);
        }
    }
}
