<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Content.aspx.cs" Inherits="Content" %>

<%@ Register Src="~/UserControl/uc_Tag.ascx" TagName="uc_Tag" TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="http://www.jiongshibaike.com/Data/Static/Css/base.css" type="text/css"
        rel="stylesheet" />
    <link href="http://www.jiongshibaike.com/Data/Static/Css/zoom.css" type="text/css"
        rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="http://www.jiongshibaike.com/Data/Static/Css/malabox.css" />
    <link rel="stylesheet" type="text/css" href="http://s.itiexue.net/css/global/global.css?resourceversion=1" />
    <link rel="stylesheet" type="text/css" href="http://s.itiexue.net/css/pengfu/v2/public.css?resourceversion=10" />
    <link rel="stylesheet" type="text/css" href="http://s.itiexue.net/css/pengfu/v2/index.css?resourceversion=10" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="Server">
    <div id="wrapper">
        <div class="layout fn-clear">
            <div class="ui-main">
                <div class="ui-module">
                    <div class="mala-title">
                        <h2>
                            其实不是你想的那样</h2>
                    </div>
                    <div class="mala-author fn-clear">
                        <p class="min-page">
                            <a class="tooltip" href="http://www.jiongshibaike.com/contents/11105" alt="我有一个坏习惯"
                                title="我有一个坏习惯">« 上一篇</a> <i class="i">•</i> <a class="tooltip" href="http://www.jiongshibaike.com/grand"
                                    title="随机来一篇">随机</a> <i>•</i> <a class="tooltip" href="http://www.jiongshibaike.com/contents/11107"
                                        alt="多么善于问问题的孩纸啊！" original-title="多么善于问问题的孩纸啊！">下一篇 »</a>
                        </p>
                        <a class="mala-author-avatar" href="#">
                            <img src="http://www.jiongshibaike.com/Data/Static/face/default.png" alt=""></a>
                        <h5>
                            匿名</h5>
                    </div>
                    <!-- // mala-author end -->
                    <div class="mala-img">
                        <a class="mala-link-jump" href="http://www.jiongshibaike.com/contents/11107" alt="多么善于问问题的孩纸啊！"
                            title="多么善于问问题的孩纸啊！">
                            <p>
                                本人男！那天在小区里遇到一要好的女同学，她抱着她一岁多的侄子出来散步。</p>
                            <p>
                                那小子对女同学呀呀的说妈妈，妈妈，特可爱！</p>
                            <p>
                                我就逗他，叫爸爸，叫爸爸。</p>
                            <p>
                                这时我妈不知道从哪里冒了出来，眼睛里含着泪花，哀怨的盯着我们！</p>
                            <p>
                                带着哭腔！“这么大的事也不和我说！来，奶奶抱！”</p>
                        </a>
                        <div class="mala-img-sponsor fn-clear">
                            <!--广告位-->
                            广告
                            <!--广告位end-->
                        </div>
                        <!-- // mala-img-sponsor end -->
                    </div>
                    <!-- // mala-img end -->
                    <script type="text/javascript">
                        $(document).ready(function () {
                            $(".mala-img img,.mala-text img").each(function () {
                                var $width = $(this).width();
                                if ($width > 620) {
                                    $(this).css("width", "620px");
                                }
                            });
                        });  
                    </script>
                    <div class="mala-page">
                        <p class="mala-page-item fn-clear">
                            <a class="tooltip mala-prev" href="http://www.jiongshibaike.com/contents/11105" alt="我有一个坏习惯"
                                original-title="我有一个坏习惯">上一篇</a> <a class="tooltip mala-random" href="http://www.jiongshibaike.com/grand"
                                    original-title="随机来一篇">随机来一篇</a> <a class="tooltip mala-next" href="http://www.jiongshibaike.com/contents/11107"
                                        alt="多么善于问问题的孩纸啊！" original-title="多么善于问问题的孩纸啊！">下一篇</a>
                        </p>
                    </div>
                    <div class="mala-sponsor-text fn-clear">
                        <!--广告位-->
                        广告位
                        <!--广告位end-->
                    </div>
                    <!-- // mala-sponsor-text end -->
                    <div class="mala-time">
                        <p style="display: none;">
                        </p>
                    </div>
                    <!-- // mala-time end -->
                    <div class="mala-fundus fn-clear">
                        <div class="mala-tags">
                            <a href="http://www.jiongshibaike.com/gs/%E7%94%B7%E5%A5%B3" title="男女">男女</a><em>/</em><a
                                href="http://www.jiongshibaike.com/gs/%E7%88%86%E7%AC%91" title="爆笑">爆笑</a><em>/</em><a
                                    href="http://www.jiongshibaike.com/gs/%E8%B6%A3%E4%BA%8B" title="趣事">趣事</a><em>/</em><a
                                        href="http://www.jiongshibaike.com/gs/%E5%A5%B3%E5%90%8C%E5%AD%A6" title="女同学">女同学</a><em>/</em>
                        </div>
                        <div class="mala-share">
                            <div class="bdshare_t bds_tools get-codes-bdshare" id="bdshare" data="{ &quot;url&quot;:&quot;http://www.jiongshibaike.com/contents/11106&quot;,&quot;text&quot;:&quot;转自@囧事百科：&quot;,&quot;pic&quot;:&quot;&quot;}">
                                <span class="bds_more"></span>
                            </div>
                        </div>
                        <ul class="mala-counts" data="11106&amp;art=1">
                            <li><a class="tooltip add-fav" href="javascript:;" data="http://www.jiongshibaike.com/User/Love/my_love/id/11106"
                                original-title="收藏"><i class="ui-icon add-love" id="nd11106"></i></a></li>
                            <li><a class="tooltip digg-good" href="javascript:;" data="http://www.jiongshibaike.com/?m=Article&amp;a=ping&amp;id=11106&amp;type=yes"
                                id="ding11106" original-title="443个赞"><i class="ui-icon give-good"></i><em>443</em></a></li>
                            <li><a class="tooltip digg-bad" href="javascript:;" data="http://www.jiongshibaike.com/?m=Article&amp;a=ping&amp;id=11106&amp;type=no"
                                id="chai11106" original-title="88个踩"><i class="ui-icon give-bad"></i>-<em>88</em></a></li>
                            <li><a class="tooltip cmt-toggle cmt-toggle-active" href="javascript:;" original-title="点击展开评论">
                                <i class="ui-icon cmt-icon"></i><em>17</em></a></li>
                        </ul>
                    </div>
                    <!-- // mala-fundus end -->
                    <div class="ui-comments" style="display: block;" data="11106" id="article-comment">
                        <div class="ui-icon ui-comment-arrow">
                        </div>
                        <div class="ui-cmt-item ui-cmt-send fn-clear">
                            <div class="cmt-avatar">
                                <img alt="" src="http://www.jiongshibaike.com/Data/Static/image/noavatar_small.gif">
                            </div>
                            <form action="http://www.jiongshibaike.com/?m=Reply&amp;a=reply" method="post" id="form-11106">
                            <div class="cmt-main">
                                <div class="cmt-no-send" style="display: block;">
                                    <textarea class="ui-input">不用登录也可以评论啦，为求人品，赶快说一句吧~</textarea>
                                </div>
                                <div class="cmt-to-send" style="display: none;">
                                    <textarea class="ui-input ui-textarea limit-letter" id="reply-cont11106" name="content"></textarea>
                                    <div class="cmt-send-ft">
                                        <input type="hidden" name="aid" value="11106" id="id">
                                        <input type="hidden" name="repid" value="0" id="repid">
                                        <!--<input type="hidden" name="oldrep-cont" value="" id="rep-cont"/>-->
                                        <label>
                                            <strong id="num">100</strong><em>/</em><strong class="big">100</strong></label>
                                        <a hidefocus="true" href="javascript:;" class="ui-link" id="bt-11106" data="11106">发表评论</a>
                                        <a href="javascript:;" class="cancel">取消</a>
                                    </div>
                                </div>
                            </div>
                            </form>
                        </div>
                        <!--测试数据-->
                        <div class="newSList">
                            <div id="newsBox_1266856" class="newsBox">
                                <div id="3675919" onmouseout="juBao(false,3675919)" onmouseover="juBao(true,3675919)"
                                    class="ihoverBg">
                                    <dl>
                                        <dt>
                                            <img width="35" height="35" src="http://h.img.pengfu.cn/nofound.png"></dt>
                                        <dd>
                                            <div class="fontP">
                                                <em>23楼</em> <a href="javascript:void()" target="_blank" class="newUser">陕西省西安市捧友：</a>
                                                <div class="yingYong">
                                                </div>
                                                <span class="zxhffont">听小便的，我给自己起的绰号就是：“犀利的”！</span>
                                                <div class="tisDianji">
                                                    <span onclick="UpdateSupportNum(3675919,0,'123.139.231.2',false,1266856)" id="liangle_3675919"
                                                        class="dingBtn">0</span> <span onclick="fnHuiFu(1266856,3675919,'陕西省西安市捧友',false)"
                                                            class="pinglBtn">回复</span> <a style="cursor: pointer; margin-left: 15px" onclick="showDaShangDialog(0,'123.139.231.2',1266856)"
                                                                class="pinglBtn">打赏</a> <a href="javascript:void()" onclick="report(3675919)" class="jubao"
                                                                    style="display: none;">举报</a>
                                                </div>
                                            </div>
                                        </dd>
                                    </dl>
                                </div>
                                <div id="3675875" onmouseout="juBao(false,3675875)" onmouseover="juBao(true,3675875)"
                                    class="ihoverBg">
                                    <dl>
                                        <dt>
                                            <img width="35" height="35" src="http://h.img.pengfu.cn/nofound.png"></dt>
                                        <dd>
                                            <div class="fontP">
                                                <em>22楼</em> <a href="javascript:void()" target="_blank" class="newUser">吉林省长春市捧友：</a>
                                                <div class="yingYong">
                                                </div>
                                                <span class="zxhffont">厕所管理史努比</span>
                                                <div class="tisDianji">
                                                    <span onclick="UpdateSupportNum(3675875,0,'139.210.109.92',false,1266856)" id="liangle_3675875"
                                                        class="dingBtn">0</span> <span onclick="fnHuiFu(1266856,3675875,'吉林省长春市捧友',false)"
                                                            class="pinglBtn">回复</span> <a style="cursor: pointer; margin-left: 15px" onclick="showDaShangDialog(0,'139.210.109.92',1266856)"
                                                                class="pinglBtn">打赏</a> <a href="javascript:void()" onclick="report(3675875)" class="jubao"
                                                                    style="display: none;">举报</a>
                                                </div>
                                            </div>
                                        </dd>
                                    </dl>
                                </div>
                                <div id="3675866" onmouseout="juBao(false,3675866)" onmouseover="juBao(true,3675866)"
                                    class="ihoverBg">
                                    <dl>
                                        <dt>
                                            <img width="35" height="35" src="http://h.img.pengfu.cn/nofound.png"></dt>
                                        <dd>
                                            <div class="fontP">
                                                <em>21楼</em> <a href="/u/6823813" target="_blank" class="newUser">Q名不要太长像.qq：</a>
                                                <div class="yingYong">
                                                </div>
                                                <span class="zxhffont">绝代风骚 E X O</span>
                                                <div class="tisDianji">
                                                    <span onclick="UpdateSupportNum(3675866,6823813,'Q名不要太长像.qq',false,1266856)" id="liangle_3675866"
                                                        class="dingBtn">1</span> <span onclick="fnHuiFu(1266856,3675866,'Q名不要太长像.qq',false)"
                                                            class="pinglBtn">回复</span> <a style="cursor: pointer; margin-left: 15px" onclick="showDaShangDialog(6823813,'Q名不要太长像.qq',1266856)"
                                                                class="pinglBtn">打赏</a> <a href="javascript:void()" onclick="report(3675866)" class="jubao"
                                                                    style="display: none;">举报</a>
                                                </div>
                                            </div>
                                        </dd>
                                    </dl>
                                </div>
                                <div id="3675831" onmouseout="juBao(false,3675831)" onmouseover="juBao(true,3675831)"
                                    class="ihoverBg">
                                    <dl>
                                        <dt>
                                            <img width="35" height="35" src="http://h.img.pengfu.cn/nofound.png"></dt>
                                        <dd>
                                            <div class="fontP">
                                                <em>20楼</em> <a href="javascript:void()" target="_blank" class="newUser">北京市捧友：</a>
                                                <div class="yingYong">
                                                </div>
                                                <span class="zxhffont">7楼果然被删了。</span>
                                                <div class="tisDianji">
                                                    <span onclick="UpdateSupportNum(3675831,0,'124.202.191.102',false,1266856)" id="liangle_3675831"
                                                        class="dingBtn">0</span> <span onclick="fnHuiFu(1266856,3675831,'北京市捧友',false)" class="pinglBtn">
                                                            回复</span> <a style="cursor: pointer; margin-left: 15px" onclick="showDaShangDialog(0,'124.202.191.102',1266856)"
                                                                class="pinglBtn">打赏</a> <a href="javascript:void()" onclick="report(3675831)" class="jubao"
                                                                    style="display: none;">举报</a>
                                                </div>
                                            </div>
                                        </dd>
                                    </dl>
                                </div>
                                <div id="3675781" onmouseout="juBao(false,3675781)" onmouseover="juBao(true,3675781)"
                                    class="ihoverBg">
                                    <dl>
                                        <dt>
                                            <img width="35" height="35" src="http://h.img.pengfu.cn/nofound.png"></dt>
                                        <dd>
                                            <div class="fontP">
                                                <em>19楼</em> <a href="/u/7603260" target="_blank" class="newUser">冰龙小子：</a>
                                                <div class="yingYong">
                                                </div>
                                                <span class="zxhffont">北京西客站南广场东门金大中</span>
                                                <div class="tisDianji">
                                                    <span onclick="UpdateSupportNum(3675781,7603260,'冰龙小子',false,1266856)" id="liangle_3675781"
                                                        class="dingBtn">1</span> <span onclick="fnHuiFu(1266856,3675781,'冰龙小子',false)" class="pinglBtn">
                                                            回复</span> <a style="cursor: pointer; margin-left: 15px" onclick="showDaShangDialog(7603260,'冰龙小子',1266856)"
                                                                class="pinglBtn">打赏</a> <a href="javascript:void()" onclick="report(3675781)" class="jubao"
                                                                    style="display: none;">举报</a>
                                                </div>
                                            </div>
                                        </dd>
                                    </dl>
                                </div>
                                <div id="3675761" onmouseout="juBao(false,3675761)" onmouseover="juBao(true,3675761)"
                                    class="ihoverBg">
                                    <dl>
                                        <dt>
                                            <img width="35" height="35" src="http://h.img.pengfu.cn/nofound.png"></dt>
                                        <dd>
                                            <div class="fontP">
                                                <em>18楼</em> <a href="/u/3573591" target="_blank" class="newUser">qiqi7852：</a>
                                                <div class="yingYong">
                                                </div>
                                                <span class="zxhffont">高 潮村周星星</span>
                                                <div class="tisDianji">
                                                    <span onclick="UpdateSupportNum(3675761,3573591,'qiqi7852',false,1266856)" id="liangle_3675761"
                                                        class="dingBtn">0</span> <span onclick="fnHuiFu(1266856,3675761,'qiqi7852',false)"
                                                            class="pinglBtn">回复</span> <a style="cursor: pointer; margin-left: 15px" onclick="showDaShangDialog(3573591,'qiqi7852',1266856)"
                                                                class="pinglBtn">打赏</a> <a href="javascript:void()" onclick="report(3675761)" class="jubao"
                                                                    style="display: none;">举报</a>
                                                </div>
                                            </div>
                                        </dd>
                                    </dl>
                                </div>
                                <div id="3675750" onmouseout="juBao(false,3675750)" onmouseover="juBao(true,3675750)"
                                    class="ihoverBg">
                                    <dl>
                                        <dt>
                                            <img width="35" height="35" src="http://img8.pengfu.cn/middle/852/47852.jpg"></dt>
                                        <dd>
                                            <div class="fontP">
                                                <em>17楼</em> <a href="/u/4095037" target="_blank" class="newUser">百邪良辰：</a>
                                                <div class="yingYong">
                                                    <div class="yyBox">
                                                        <div class="yyJiao">
                                                        </div>
                                                        <div class="yyoFont">
                                                            <em>2楼</em> <a href="/u/6629593">涩郎-追风.qq：</a> <span>我最喜欢的明星叫苍井空，我经常下车的公交车站是柳钢和华庭苑。怎么组?柳钢的苍井空？华庭苑的苍井空？绰号是不错，但我怎么才能找到适合这个绰号的人送给她呢？这个问题相当难搞定啊</span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <span class="zxhffont">苍井柳钢。。。怎么样。。。</span>
                                                <div class="tisDianji">
                                                    <span onclick="UpdateSupportNum(3675750,4095037,'百邪良辰',false,1266856)" id="liangle_3675750"
                                                        class="dingBtn">0</span> <span onclick="fnHuiFu(1266856,3675750,'百邪良辰',false)" class="pinglBtn">
                                                            回复</span> <a style="cursor: pointer; margin-left: 15px" onclick="showDaShangDialog(4095037,'百邪良辰',1266856)"
                                                                class="pinglBtn">打赏</a> <a href="javascript:void()" onclick="report(3675750)" class="jubao"
                                                                    style="display: none;">举报</a>
                                                </div>
                                            </div>
                                        </dd>
                                    </dl>
                                </div>
                                <div id="3675737" onmouseout="juBao(false,3675737)" onmouseover="juBao(true,3675737)"
                                    class="ihoverBg">
                                    <dl>
                                        <dt>
                                            <img width="35" height="35" src="http://h.img.pengfu.cn/nofound.png"></dt>
                                        <dd>
                                            <div class="fontP">
                                                <em>16楼</em> <a href="javascript:void()" target="_blank" class="newUser">手机用户163837：</a>
                                                <div class="yingYong">
                                                </div>
                                                <span class="zxhffont">使命召唤来的</span>
                                                <div class="tisDianji">
                                                    <span onclick="UpdateSupportNum(3675737,0,'手机用户163837',false,1266856)" id="liangle_3675737"
                                                        class="dingBtn">0</span> <span onclick="fnHuiFu(1266856,3675737,'手机用户163837',false)"
                                                            class="pinglBtn">回复</span> <a style="cursor: pointer; margin-left: 15px" onclick="showDaShangDialog(0,'手机用户163837',1266856)"
                                                                class="pinglBtn">打赏</a> <a href="javascript:void()" onclick="report(3675737)" class="jubao"
                                                                    style="display: none;">举报</a>
                                                </div>
                                            </div>
                                        </dd>
                                    </dl>
                                </div>
                                <div id="3675718" onmouseout="juBao(false,3675718)" onmouseover="juBao(true,3675718)"
                                    class="ihoverBg">
                                    <dl>
                                        <dt>
                                            <img width="35" height="35" src="http://img8.pengfu.cn/middle/428/747428.jpg"></dt>
                                        <dd>
                                            <div class="fontP">
                                                <em>15楼</em> <a href="/u/7630902" target="_blank" class="newUser">奔驰bc：</a>
                                                <div class="yingYong">
                                                </div>
                                                <span class="zxhffont">杨叶路口周杰伦</span>
                                                <div class="tisDianji">
                                                    <span onclick="UpdateSupportNum(3675718,7630902,'奔驰bc',false,1266856)" id="liangle_3675718"
                                                        class="dingBtn">0</span> <span onclick="fnHuiFu(1266856,3675718,'奔驰bc',false)" class="pinglBtn">
                                                            回复</span> <a style="cursor: pointer; margin-left: 15px" onclick="showDaShangDialog(7630902,'奔驰bc',1266856)"
                                                                class="pinglBtn">打赏</a> <a href="javascript:void()" onclick="report(3675718)" class="jubao"
                                                                    style="display: none;">举报</a>
                                                </div>
                                            </div>
                                        </dd>
                                    </dl>
                                </div>
                                <div id="3675717" onmouseout="juBao(false,3675717)" onmouseover="juBao(true,3675717)"
                                    class="ihoverBg">
                                    <dl>
                                        <dt>
                                            <img width="35" height="35" src="http://img0.pengfu.cn/middle/324/843324.jpg"></dt>
                                        <dd>
                                            <div class="fontP">
                                                <em>14楼</em> <a href="/u/5661247" target="_blank" class="newUser">lwplgs110：</a>
                                                <div class="yingYong">
                                                </div>
                                                <span class="zxhffont">村口东站里根总统</span>
                                                <div class="tisDianji">
                                                    <span onclick="UpdateSupportNum(3675717,5661247,'lwplgs110',false,1266856)" id="liangle_3675717"
                                                        class="dingBtn">2</span> <span onclick="fnHuiFu(1266856,3675717,'lwplgs110',false)"
                                                            class="pinglBtn">回复</span> <a style="cursor: pointer; margin-left: 15px" onclick="showDaShangDialog(5661247,'lwplgs110',1266856)"
                                                                class="pinglBtn">打赏</a> <a href="javascript:void()" onclick="report(3675717)" class="jubao"
                                                                    style="display: none;">举报</a>
                                                </div>
                                            </div>
                                        </dd>
                                    </dl>
                                </div>
                                <div class="pageBox">
                                    <div class="page">
                                        <p>
                                            <a onclick="return false" class="select onclick" href="/comment_1266856_1.html">1</a>
                                            <a href="/comment_1266856_2.html" class="onclick">2</a> <a href="/comment_1266856_3.html"
                                                class="onclick">3</a> <a href="/comment_1266856_2.html" class="onclick">&gt;</a>
                                            <a href="/comment_1266856_3.html" class="onclick">末页</a>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--测试数据-->
                        <div class="ui-cmt-num" style="display: block">
                            <style>
                                .ui-cmt-num a
                                {
                                    margin-left: 5px;
                                }
                            </style>
                            21 条记录 1/2 页 <a href="http://www.jiongshibaike.com/?m=Reply&amp;a=ajaxreplys&amp;id=11106&amp;p=2">
                                下一页</a> <span class="current">1</span><a href="http://www.jiongshibaike.com/?m=Reply&amp;a=ajaxreplys&amp;id=11106&amp;p=2">2</a>
                        </div>
                        <div id="mainform" style="display: none;">
                            <form action="http://www.jiongshibaike.com/?m=Reply&amp;a=reply" method="post" class="formrep">
                            <div class="cmt-main">
                                <div class="cmt-to-send" style="display: block;">
                                    <textarea class="ui-input ui-textarea limit-letter" id="reply-cont11106" name="content"></textarea>
                                    <div class="cmt-send-ft">
                                        <input type="hidden" name="aid" value="11106" id="id">
                                        <input type="hidden" name="repid" value="0" id="repid">
                                        <label>
                                            你还可以输入<strong id="num">100</strong>个字符</label>
                                        <a hidefocus="true" href="javascript:;" class="ui-link" id="bt-11106" data="11106">发表评论</a>
                                        <a href="javascript:;" class="cancel repcancel">取消</a>
                                    </div>
                                </div>
                            </div>
                            </form>
                        </div>
                    </div>
                    <!-- // ui-commen end -->
                    <script type="text/javascript">                        $(".ui-comments").loadreply();
                        $(".cmt-toggle").addClass("cmt-toggle-active");
                    </script>
                </div>
                <!-- // ui-module end -->
                <div class="ui-module" id="mala-related-module">
                    <div class="mala-sponsor fn-clear">
                        广告
                    </div>
                    <!-- // mala-sponsor end -->
                    <div class="mala-related fn-clear">
                        <ul>
                            <li><a class="img-item" href="http://www.jiongshibaike.com/contents/46873">
                                <img src="http://www.jiongshibaike.com/Data/Uploads/image/2014-09-03/2014090318042945.jpg"
                                    alt="有一种寒冷叫忘穿秋裤"></a>
                                <p>
                                    <a href="http://www.jiongshibaike.com/contents/46873">有一种寒冷叫忘穿秋裤</a>
                                </p>
                            </li>
                            <li><a class="img-item" href="http://www.jiongshibaike.com/contents/46872">
                                <img src="http://www.jiongshibaike.com/Data/Uploads/image/2014-09-03/2014090318042943.jpg"
                                    alt="嘿，往哪看呢？"></a>
                                <p>
                                    <a href="http://www.jiongshibaike.com/contents/46872">嘿，往哪看呢？</a>
                                </p>
                            </li>
                            <li><a class="img-item" href="http://www.jiongshibaike.com/contents/46874">
                                <img src="http://www.jiongshibaike.com/Data/Uploads/image/2014-09-03/2014090318042946.jpg"
                                    alt="当数量多，烟也成为艺术"></a>
                                <p>
                                    <a href="http://www.jiongshibaike.com/contents/46874">当数量多，烟也成为艺术</a>
                                </p>
                            </li>
                            <li><a class="img-item" href="http://www.jiongshibaike.com/contents/46875">
                                <img src="http://www.jiongshibaike.com/Data/Uploads/image/2014-09-03/2014090318043048.jpg"
                                    alt="草泥兔，长姿势了"></a>
                                <p>
                                    <a href="http://www.jiongshibaike.com/contents/46875">草泥兔，长姿势了</a>
                                </p>
                            </li>
                            <li><a class="img-item" href="http://www.jiongshibaike.com/contents/46879">
                                <img src="http://www.jiongshibaike.com/Data/Uploads/image/2014-09-03/2014090318043152.jpg"
                                    alt="上铺的同学，你该减肥了"></a>
                                <p>
                                    <a href="http://www.jiongshibaike.com/contents/46879">上铺的同学，你该减肥了</a>
                                </p>
                            </li>
                            <li><a class="img-item" href="http://www.jiongshibaike.com/contents/46877">
                                <img src="http://www.jiongshibaike.com/Data/Uploads/image/2014-09-03/2014090318042944.jpg"
                                    alt="屌丝们可以娶回家了"></a>
                                <p>
                                    <a href="http://www.jiongshibaike.com/contents/46877">屌丝们可以娶回家了</a>
                                </p>
                            </li>
                            <li><a class="img-item" href="http://www.jiongshibaike.com/contents/46881">
                                <img src="http://www.jiongshibaike.com/Data/Uploads/image/2014-09-03/2014090318043155.jpg"
                                    alt="难道你不觉得热吗？"></a>
                                <p>
                                    <a href="http://www.jiongshibaike.com/contents/46881">难道你不觉得热吗？</a>
                                </p>
                            </li>
                            <li><a class="img-item" href="http://www.jiongshibaike.com/contents/46880">
                                <img src="http://www.jiongshibaike.com/Data/Uploads/image/2014-09-03/2014090318043154.jpg"
                                    alt="尼玛，你不能温柔点吗？"></a>
                                <p>
                                    <a href="http://www.jiongshibaike.com/contents/46880">尼玛，你不能温柔点吗？</a>
                                </p>
                            </li>
                            <li><a class="img-item" href="http://www.jiongshibaike.com/contents/46883">
                                <img src="http://www.jiongshibaike.com/Data/Uploads/image/2014-09-03/2014090318043258.jpg"
                                    alt="商家太与时俱进了"></a>
                                <p>
                                    <a href="http://www.jiongshibaike.com/contents/46883">商家太与时俱进了</a>
                                </p>
                            </li>
                            <li><a class="img-item" href="http://www.jiongshibaike.com/contents/46882">
                                <img src="http://www.jiongshibaike.com/Data/Uploads/image/2014-09-03/2014090318043257.jpg"
                                    alt="看到这图直接笑高潮了"></a>
                                <p>
                                    <a href="http://www.jiongshibaike.com/contents/46882">看到这图直接笑高潮了</a>
                                </p>
                            </li>
                        </ul>
                    </div>
                    <!-- // mala-related end -->
                </div>
                <!-- // ui-module end -->
            </div>
            <!-- // ui-main end -->
            <!--右边 开始-->
            <uc:uc_Tag ID="Tags" runat="server" />
            <!--右边 结束-->
            <!-- // ui-side end -->
            <!-- // ui-side end -->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="Server">
    <script src="http://libs.baidu.com/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
    <script src="http://www.jiongshibaike.com/Data/Static/Js/jquery.tipsy.js" type="text/javascript"></script>
    <script src="http://www.jiongshibaike.com/Data/Static/Js/jquery.base.js" type="text/javascript"></script>
    <script src="http://www.jiongshibaike.com/Data/Static/Js/jquery.hotkey.js" type="text/javascript"></script>
    <script src="http://www.jiongshibaike.com/Data/Static/Js/jquery.fixed.js" type="text/javascript"></script>
    <script src="http://www.jiongshibaike.com/Data/Static/Js/jquery.lightbox_me.js" type="text/javascript"></script>
</asp:Content>
