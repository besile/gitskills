(function ($, g) {
    var config = {
        ajax_dingorcai:"./ajax/ajax_DingOrCai.ashx",
    };
    var commentClick = {
        postComment: function() {
            $("[name='submit']").click(function() {
                var _this = $(this);
            });
        },
        dingHumor: function() {
            $("[name='ding']").click(function() {
                var _this = $(this), id = _this.attr("id"),data= {},humorid=_this.attr("humorid");
                data = {humorId:humorid,userId:1,userName:"admin",};
            })
        }
    };
    var ajaxGetData = {
        ajaxDingOrCai: function(opts) {
            var options = $.extend(true, { async: false, cache: true, success: false, error: false, dataType: "json" }, opts);
            if (!options.url || !options.url.length) options.url = config.ajax_dingorcai;
            $.ajax(options);
        }
    };
    var ajaxSuccess = {
        dingOrCaiSuccess:function (res,id) {
            if (res.success) {
               //设置cookie 和添加数目
                var _id = $("#" + id + " em");
                var dingNum=_id.html();
                _id.html(dingNum + 1);
            }
        }
    };
    var pageInit= {
        showComment: function() {
            $("[show-comment='comment']").mousedown(function () {
                var _this = $(this), humorId = _this.attr("show-data");
                $("#smallComment_" + humorId).hide();
                $("#divCommentContent_" + humorId).show();
                $("#txtCommentContent_" + humorId).focus();
                //同时确定焦点
                //兼容火狐 和iejquery兼容IE和火狐下focus()事件
                if (navigator.userAgent.indexOf("Firefox") > 0) {
                    setTimeout(function () { $("#txtCommentContent_" + humorId).focus(); }, 0);
                }
            });
        }, 
        getComment: function () {
            $("[get-data='commentinfo']").click(function () {
                
                var _this = $(this), humorId = _this.attr("humorid");
                $("#newList_" + humorId).toggle();
            });
            
        }
    }
    $(function () {
        //显示评论框
        pageInit.showComment();
        //初始化评论
        pageInit.getComment();
    });

})(jQuery,window)