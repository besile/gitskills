using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TxHumor.Common.Attr;
using TxHumor.DAL;

namespace TxHumor.BLL
{
    public class bll_Comment
    {
        /// <summary>
        /// 获取列表页评论信息
        /// </summary>
        /// <param name="humorId"></param>
        /// <returns></returns>
        [Attr_CacheData("CacheCommentList")]
        public static List<int> GetCommentByHumorId(int humorId)
        {
            DataTable dt = dal_Comment.GetCommentByHumorId(humorId);
            if (dt == null || dt.Rows == null || dt.Rows.Count == 0) return null;
            List<int> ids = new List<int>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                ids.Add(Convert.ToInt32(dr["Id"]));
            }
            return ids;
        }
    }
}
