using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TxHumor.Common;
using TxHumor.Config;
using TxHumor.Controller;
using TxHumor.Model;
using TxHumor.UI.Model;

public partial class Index : PageBase
{
    private m_Q_Humor queryHumor = new m_Q_Humor();
    protected void Page_Load(object sender, EventArgs e)
    {
        //LogTools.Log.InfoFormat("根据活动id获得活动详情异常！异常信息:[{0}]", "56588");记录错误日志
        InitPrams();
        int recordCount;
        LoadIndexHumor(out recordCount);
        LoadPage(recordCount);
    }

    private void InitPrams()
    {
        com_RequestParameterHelper.ToFillByRequest(queryHumor);
    }
    /// <summary>
    /// 获取开始时间
    /// </summary>
    /// <returns></returns>
    private DateTime GetStartTime()
    {
        DateTime startTime = DateTime.Now;
        switch (queryHumor.Type)
        {
            case "day":
                return startTime.AddDays(-1);
            case "week":
                return startTime.AddDays(-7);
            case "month":
                return startTime.AddDays(-30);
            default:
                return startTime.AddDays(-1);
        }
    }

    private void LoadIndexHumor(out int recordCount)
    {
        recordCount = 0;
        object[] prams = new object[]
        {
            queryHumor.PageIndex,
            pager_down.PageSize,
            GetStartTime().AddDays(-10),
            recordCount
        };
        List<T_Humor_HumorInfo> humorInfos = ctrl_ServiceClient.GetService<T_Humor_HumorInfo>(AppConfig.OpenCache, "通过逻辑层获取首页帖子列表", prams);
        recordCount = Convert.ToInt32(prams[prams.Length - 1]);
        this.rpt_humorList.DataSource = humorInfos;
        this.rpt_humorList.ItemDataBound += new RepeaterItemEventHandler(rpt_humorList_ItemDataBound);
        this.rpt_humorList.DataBind();
    }

    private void LoadPage(int recordCount)
    {
        pager_down.CurrentPageIndex = queryHumor.PageIndex;
        pager_down.RecordCount = recordCount;
        
        queryHumor.Pager = "{0}";
        string url = com_UrlHelper.GetAbsUrl("http://test.pengfu.com", new { a = queryHumor.Type, b = "page"+queryHumor.Pager }, "/", null);
        pager_down.DisplayTotalPageCount = false;
        pager_down.IsShowInput = false;

        pager_down.UrlRewritePattern = url;
    }

    void rpt_humorList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        T_Humor_HumorInfo humor = e.Item.DataItem as T_Humor_HumorInfo;

        Repeater rpt_TagIds=e.Item.FindControl("rpt_TagIds") as Repeater;
        string[] tagIds = null;
        if (!string.IsNullOrWhiteSpace(humor.TagIds))
        {
            tagIds=humor.TagIds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }
        rpt_TagIds.DataSource = tagIds;
        rpt_TagIds.DataBind();

        //绑定评论
        List<T_Humor_Comment> comments = ctrl_ServiceClient.GetService<T_Humor_Comment>(AppConfig.OpenCache, "通过逻辑层获取列表页评论列表",
            new object[] { humor.Id })??new List<T_Humor_Comment>(0);
        PlaceHolder ph_showcomment = e.Item.FindControl("ph_showcomment") as PlaceHolder;
        if (comments.Count == 0)
        {
            ph_showcomment.Visible = false;
        }
        foreach (T_Humor_Comment comment in comments)
        {
            if (string.IsNullOrWhiteSpace(comment.CommentXml))
            {
                continue;
            }
            comment.CommentXmlModel = CommentHelper.GetReplyContent(comment.CommentXml);
        }
        Repeater rpt_CommentList = e.Item.FindControl("rpt_CommentList") as Repeater;
        rpt_CommentList.DataSource = comments;
        rpt_CommentList.ItemDataBound += new RepeaterItemEventHandler(rpt_CommentList_ItemDataBound);
        rpt_CommentList.DataBind();
    }

    void rpt_CommentList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        T_Humor_Comment comment = e.Item.DataItem as T_Humor_Comment;
        PlaceHolder ph_showquote = e.Item.FindControl("ph_showquote") as PlaceHolder;
        if (comment == null || string.IsNullOrWhiteSpace(comment.CommentXml))
        {
            ph_showquote.Visible = false;
            return;
        }
        Repeater rpt_CommentQuoteList = e.Item.FindControl("rpt_CommentQuoteList") as Repeater;
        List<m_CommentXml> list=new List<m_CommentXml> {comment.CommentXmlModel};
        rpt_CommentQuoteList.DataSource = list;
        rpt_CommentQuoteList.DataBind();
    }
}