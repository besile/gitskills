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
    public class dal_User
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int AddUser(T_User user)
        {
            SqlParameter[] prams = {
                                      new SqlParameter("@UserName", user.UserName),
                                      new SqlParameter("@Pwd", user.Pwd),
                                      new SqlParameter("@Email", user.Email),
                                   };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(DbConfig.GetDb("Humor")
                , CommandType.StoredProcedure
                , "AddUser"
                , prams));
        }
    }
}
