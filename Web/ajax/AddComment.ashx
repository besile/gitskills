<%@ WebHandler Language="C#" Class="AddComment" %>

using System;
using System.Web;

public class AddComment : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}