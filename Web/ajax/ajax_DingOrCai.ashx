<%@ WebHandler Language="C#" Class="ajax_DingOrCai" %>

using System;
using System.Web;

public class ajax_DingOrCai : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "json/application";
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}