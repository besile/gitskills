using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using TxHumor.Common;
using TxHumor.Model;

/// <summary>
///CommentHelper 的摘要说明
/// </summary>
public class CommentHelper
{
	public CommentHelper()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 获取引用内容
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static m_CommentXml GetReplyContent(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            return null;
        }
        XElement root = XElement.Parse(content);
        XElement xFloor = root.Element("Floor");
        int floor = 0;
        if (xFloor != null)
        {
            floor = xFloor.Value.ToSimpleT(0);
        }
        m_CommentXml comment=new m_CommentXml()
        {
            Floor = floor,
            Content = root.Element("Content") == null ? string.Empty : root.Element("Content").Value,
            ReplyId = root.Element("ReplyId") == null ? 0 : root.Element("ReplyId").Value.ToSimpleT(0),
            UserId = root.Element("UserId") == null ? 0 : root.Element("UserId").Value.ToSimpleT(0),
            UserName = root.Element("UserName") == null ? string.Empty : root.Element("UserName").Value
        };
        return comment;
    }
}