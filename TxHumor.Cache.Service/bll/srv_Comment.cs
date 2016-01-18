using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TxHumor.Common;
using TxHumor.DAL;
using TxHumor.Model;

namespace TxHumor.Cache.Service.bll
{
    public class srv_Comment
    {
        public static T_Humor_Comment GetCommentById(int commentId)
        {
            DataTable dt = dal_Comment.GetCommentById(commentId);
            return com_ModelFillHelper.FillModel<T_Humor_Comment>(dt);
        }

        public static List<T_Humor_Comment> GetCommentByIds(string commentIds)
        {
            DataTable dt = dal_Comment.GetCommentByIds(commentIds);
            return com_ModelFillHelper.FillModelList<T_Humor_Comment>(dt);
        }
    }
}
