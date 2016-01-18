<%@ WebHandler Language="C#" Class="ajax_Regist" %>

using System;
using System.Web;
using TxHumor.Common;
using TxHumor.Controller;
using TxHumor.Model;
using TxHumor.UI.Model;

public class ajax_Regist : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "json/application";
        m_Q_Regist regist=new m_Q_Regist();
        //填充参数
        com_RequestParameterHelper.ToFillByRequest(regist);
        //判断参数是否为空
        if (string.IsNullOrWhiteSpace(regist.UserName) || string.IsNullOrWhiteSpace(regist.Pwd) ||
            string.IsNullOrWhiteSpace(regist.Email) || string.IsNullOrWhiteSpace(regist.Code))
        {
            context.Response.Write(JsonHelper.Serialize(new{success=false,message="请填写完整参数"}));
            return;
        }
        //判断密码是否相等
        T_User user=new T_User()
        {
            Email = regist.Email,
            Pwd = regist.Pwd,
            UserName = regist.UserName
        };
        ctrl_ServiceClient.UpdateService<T_User>("通过逻辑层添加用户", new object[] { user });
        context.Response.Write(JsonHelper.Serialize(new { success = true, message = "添加用户成功" }));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}