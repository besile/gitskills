using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using TxHumor.Config;

/// <summary>
///PageBase 的摘要说明
/// </summary>
public class PageBase:Page
{
	public PageBase()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 获取用户头像
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public string GetUserHead(object userId)
    {
        if (userId == null)
        {
            return AppConfig.GetApp("DefaultHead");
        }
        int id = Convert.ToInt32(userId);
        if (id == 0)
        {
            return AppConfig.GetApp("DefaultHead");
        }
        return AppConfig.GetApp("DefaultHead");
    }
}