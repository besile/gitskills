<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="Index.aspx.cs" Inherits="Index" %>

<%@ Register Src="~/UserControl/uc_Tag.ascx" TagName="uc_Tag" TagPrefix="uc" %>
<%@ Register TagPrefix="uc" Namespace="TxHumor.Common.WebControls" Assembly="TxHumor.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <div id="wrapper">
        <div class="layout fn-clear">
            <div class="ui-main">
                <asp:Repeater runat="server" ID="rpt_humorList">
                    <ItemTemplate>
                        <!-- // ui-module start -->
                        <div class="ui-module">
                            <a class="tooltip ui-icon open-new-link" title="在新窗口打开" href="http://www.jiongshibaike.com/contents/11106"
                                target="_blank">在新窗口打开</a>
                            <div class="mala-title">
                                <h3>
                                    <a href="http://www.jiongshibaike.com/contents/<%#Eval("Id") %>" target="_blank">
                                        <%#Eval("HumorTitle") %></a></h3>
                            </div>
                            <div class="mala-author fn-clear">
                                <a class="mala-author-avatar" href="#">
                                    <img src="<%#GetUserHead(Eval("CreateUserId")) %>" alt=""></a>
                                <h5>
                                    <%#Eval("CreateUserName") %></h5>
                            </div>
                            <!-- // mala-author end -->
                            <div class="mala-img">
                                <%#Eval("HumorContent") %>
                            </div>
                            <!-- // mala-img end -->
                            <div class="mala-fundus fn-clear">
                                <!--标签 开始-->
                                <div class="mala-tags">
                                    <asp:Repeater runat="server" ID="rpt_TagIds">
                                        <ItemTemplate>
                                            <a href="http://www.jiongshibaike.com/gs/<%#Container.DataItem %>" title="<%#Container.DataItem %>">
                                                <%#Container.DataItem%></a><em>/</em>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <!--标签 结束-->
                                <div class="mala-share">
                                    <div class="bdshare_t bds_tools get-codes-bdshare" id="bdshare" data="{ &quot;url&quot;:&quot;http://www.jiongshibaike.com/contents/11106&quot;,&quot;text&quot;:&quot;转自@囧事百科 其实不是你想的那样&quot;,&quot;desc&quot;:&quot;本人男！那天在小区里遇到一要好的女同学，她抱着她一岁多的侄子出来散步。那小子对女同学呀呀的说妈妈，妈妈，特可爱！我就逗他，叫爸爸，叫爸爸。这时我妈不知道从哪里冒了出来，眼睛里含着泪花，哀怨的盯着我们！带着哭腔！“这么大的事也不和我说！来，奶奶抱！”&quot;}">
                                        <span class="bds_more"></span>
                                    </div>
                                </div>
                                <ul class="mala-counts" data="11106">
                                    <li><a class="tooltip add-fav" title="收藏" href="javascript:;" data="http://www.jiongshibaike.com/User/Love/my_love/id/11106">
                                        <i class="ui-icon add-love" id="nd11106"></i></a></li>
                                    <li><a class="tooltip digg-good" title="<%#Eval("SupportNum") %>个赞" href="javascript:;"
                                        name="ding" id="ding<%#Eval("Id") %>"><i class="ui-icon give-good"></i><em>
                                            <%#Eval("SupportNum") %></em></a></li>
                                    <li><a class="tooltip digg-bad" title="<%#Eval("OpposeNum")%>个踩" href="javascript:;"
                                        name="chai" id="cai<%#Eval("Id") %>"><i class="ui-icon give-bad"></i>-<em><%#Eval("OpposeNum")%></em></a></li>
                                    <li><a class="tooltip cmt-toggle" title="点击展开评论" href="javascript:;"><i class="ui-icon cmt-icon">
                                    </i><em>
                                        <%#Eval("CommentNum") %></em></a></li>
                                </ul>
                            </div>
                            <!--评论 开始-->
                            <!-- // mala-fundus end -->
                            <!--评论框 开始-->
                            <div id="smallComment_<%#Eval("Id") %>" style="display: block;" class="inputBox">
                                <input type="text" value="快来说两句吧！不用登录也能评论哦！" show-comment="comment" show-data="<%#Eval("Id") %>">
                                <div class="btnBox" get-data="commentinfo" humorid="<%#Eval("Id") %>">
                                    <em></em><span class="plFont">
                                        <%#Eval("CommentNum") %></span><b></b><span class="jianjiao"></span>
                                </div>
                            </div>
                            <div style="display: none;" id="divCommentContent_<%#Eval("Id") %>" class="hufuInput">
                                <div class="textBox">
                                    <textarea id="txtCommentContent_<%#Eval("Id") %>" rows="" cols="" name=""></textarea>
                                    <div get-data="commentinfo" humorid="<%#Eval("Id") %>" class="btnBox">
                                        <em></em><span class="plFont">
                                            <%#Eval("CommentNum") %></span><b></b> <span class="jianjiao"></span><span style="display: none"
                                                id="spanPlus_<%#Eval("CommentNum") %>">-</span>
                                    </div>
                                </div>
                                <div class="textBtn">
                                    <span issubmit="0" id="<%#Eval("Id") %>" name="submit">提交</span>
                                </div>
                            </div>
                            <!--评论框 结束-->
                            <!--评论 开始-->
                            <div id="newList_<%#Eval("Id") %>" style="display: none" class="newSList">
                                <asp:PlaceHolder runat="server" ID="ph_showcomment">
                                    <p class="xxTitle">
                                        <strong>最新评论</strong><span></span></p>
                                </asp:PlaceHolder>
                                <div id="newsBox_<%#Eval("Id") %>" class="newsBox">
                                    <!--全部更改 全部显示 隐藏 添加测试数据-->
                                    <asp:Repeater runat="server" ID="rpt_CommentList">
                                        <ItemTemplate>
                                            <div id="3675627" class="ihoverBg">
                                                <dl>
                                                    <dt>
                                                        <img width="35" height="35" src="http://img1.pengfu.cn/middle/613/651613.jpg"></dt>
                                                    <dd>
                                                        <div class="fontP">
                                                            <em>
                                                                <%#Eval("Floor") %>楼</em> <a href="/u/6702908" target="_blank" class="newUser">
                                                                    <%#Eval("CreateUserName") %>：</a>
                                                            <asp:PlaceHolder runat="server" ID="ph_showquote">
                                                                <!--引用 开始-->
                                                                <asp:Repeater runat="server" ID="rpt_CommentQuoteList">
                                                                    <ItemTemplate>
                                                                        <div class="yingYong">
                                                                            <div class="yyBox">
                                                                                <div class="yyJiao">
                                                                                </div>
                                                                                <div class="yyoFont">
                                                                                    <em>
                                                                                        <%#Eval("Floor") %>楼</em> <a href="/u/7205040">
                                                                                            <%#Eval("UserName") %>：</a> <span>
                                                                                                <%#Eval("Content") %></span>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </asp:PlaceHolder>
                                                            <!--引用 结束-->
                                                            <span class="zxhffont">
                                                                <%#Eval("CommentContent") %></span>
                                                            <div class="tisDianji">
                                                                <span onclick="UpdateSupportNum(3675627,6702908,'为什麽是雨丶',false,1266798)" id="liangle_3675627"
                                                                    class="dingBtn">
                                                                    <%#Eval("SupportNum") %></span> <span onclick="fnHuiFu(1266798,3675627,'为什麽是雨丶',false)"
                                                                        class="pinglBtn">回复</span> <a style="cursor: pointer; margin-left: 15px" onclick="showDaShangDialog(6702908,'为什麽是雨丶',1266798)"
                                                                            class="pinglBtn">打赏</a> <a href="javascript:void()" onclick="report(3675627)" class="jubao"
                                                                                style="display: none;">举报</a>
                                                            </div>
                                                        </div>
                                                    </dd>
                                                </dl>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <!--添加测试数据-->
                                </div>
                            </div>
                            <!-- // ui-comment end -->
                            <!--评论 结束-->
                        </div>
                        <!-- // ui-module end -->
                    </ItemTemplate>
                </asp:Repeater>
                <!-- // ui-pages end -->
                <div class="ui-module-pages fn-clear">
                    <uc:AspNetPager ID="pager_down" PageSize="10" runat="server" PageDivCSS="ui-pages">
                    </uc:AspNetPager>
                </div>
                <!-- // ui-module-pages end -->
            </div>
            <!--右边 开始-->
            <uc:uc_Tag ID="Tags" runat="server" />
            <!--右边 结束-->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="Server">
</asp:Content>
