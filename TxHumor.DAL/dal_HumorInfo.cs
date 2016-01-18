using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TxHumor.Common;
using TxHumor.Config;
using TxHumor.Model;

namespace TxHumor.DAL
{
    public class dal_HumorInfo
    {
        /// <summary>
        /// 添加帖子
        /// </summary>
        /// <param name="humorInfo"></param>
        /// <returns></returns>
        public static int AddHumorInfo(T_Humor_HumorInfo humorInfo)
        {
            SqlParameter[] prams = {
                                      new SqlParameter("@CreateUserId", humorInfo.CreateUserId),
                                      new SqlParameter("@HumorTitle", humorInfo.HumorTitle),
                                      new SqlParameter("@HumorType", humorInfo.HumorType),
                                      new SqlParameter("@HumorUbbContent", humorInfo.HumorUbbContent),
                                      new SqlParameter("@HumorContent", humorInfo.HumorContent),
                                      new SqlParameter("@CommentNum",humorInfo.CommentNum), 
                                      new SqlParameter("@CreateUserName", humorInfo.CreateUserName),
                                      new SqlParameter("@SupportNum", humorInfo.SupportNum),
                                      new SqlParameter("@OpposeNum", humorInfo.OpposeNum),
                                      new SqlParameter("@IpAddress", humorInfo.IpAddress),
                                      new SqlParameter("@TagIds", humorInfo.TagIds)
                                   };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(DbConfig.GetDb("Humor")
                , CommandType.StoredProcedure
                , "AddHumor"
                , prams));
        }
        /// <summary>
        /// 通过帖子ID获取帖子信息
        /// </summary>
        /// <param name="humorId"></param>
        /// <returns></returns>
        public static DataTable GetHumorInfoById(int humorId)
        {
            DataTable dt = SqlHelper.ExecuteDataset(DbConfig.GetDb("Humor"), CommandType.StoredProcedure, "GetHumorInfoById",
                new SqlParameter[] { new SqlParameter("@HumorId", humorId) }).Tables[0];
            return dt;
        }
        /// <summary>
        /// 通过帖子IDS获取帖子信息
        /// </summary>
        /// <param name="humorIds"></param>
        /// <returns></returns>
        public static DataTable GetHumorInfoByIds(string humorIds)
        {
            DataTable dt = SqlHelper.ExecuteDataset(DbConfig.GetDb("Humor"), CommandType.StoredProcedure, "GetHumorInfoByIds",
                new SqlParameter[] { new SqlParameter("@HumorIds", humorIds) }).Tables[0];
            return dt;
        }
        /// <summary>
        /// 获取口碑信息测试
        /// </summary>
        /// <returns></returns>
        public static DataTable GetHumorInfo()
        {
            DataTable dt = SqlHelper.ExecuteDataset(DbConfig.GetDb("Humor"), CommandType.Text,
                "SELECT * FROM dbo.T_Humor_HumorInfo(NOLOCK) ", null).Tables[0];
            return dt;
        }

        public static void UpdateHumorInfo(T_Humor_HumorInfo humorInfo)
        {
            SqlParameter[] prams = {
                                      new SqlParameter("@HumorContent", humorInfo.HumorContent),
                                      new SqlParameter("@HumorType", humorInfo.HumorType),
                                      new SqlParameter("@Id", humorInfo.Id)
                                   };
            SqlHelper.ExecuteNonQuery(DbConfig.GetDb("Humor"), CommandType.Text, @"
UPDATE dbo.T_Humor_HumorInfo SET HumorContent=@HumorContent,HumorType=@HumorType WHERE id=@Id", prams);
        }

        /// <summary>
        /// 获取首页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="startTime"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public static DataTable GetIndexHumor(int pageIndex, int pageSize, DateTime startTime,out int recordCount)
        {
            SqlParameter[] prams = {
                                      new SqlParameter("@PageIndex", pageIndex),
                                      new SqlParameter("@PageSize", pageSize),
                                      new SqlParameter("@StartTime", startTime),
                                      new SqlParameter("@RecordCount", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, string.Empty, DataRowVersion.Default, null)
                                   };
            DataTable dt = SqlHelper.ExecuteDataset(DbConfig.GetDb("Humor")
                , CommandType.StoredProcedure
                , "GetIndexHumor"
                , prams).Tables[0];
            recordCount = Convert.ToInt32(prams[prams.Length - 1].Value);
            return dt;
        }
    }
}
