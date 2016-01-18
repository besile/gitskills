(function ($, w) {
    var mkb = mkb || {};
    mkb.config = mkb.config || {};
    mkb.init = mkb.init || {};
    mkb.config = {
        itemObj: { "youhao": { name: "油耗", id: 10 },
            "dongli": { name: "动力", id: 4 },
            "xingjiabi": { name: "性价比", id: 7 },
            "peizhi": { name: "配置", id: 6 },
            "caokong": { name: "操控", id: 5 },
            "kongjian": { name: "空间", id: 3 },
            "waiguan": { name: "外观", id: 1 },
            "shushidu": { name: "舒适度", id: 8 },
            "neishi": { name: "内饰", id: 2 },
            "yanghu": { name: "养护", id: 11 },
            "fuwu": { name: "服务", id: 12 },
            "baoxian": { name: "保险", id: 15 },
            "gaizhuang": { name: "改装", id: 13 },
            "peijian": { name: "配件", id: 14 },
            "weixiu": { name: "维修", id: 9 }
        },
        contextDefult: "有什么心得体验告诉大家？（最多140个字）",
        picUploadUrl: "./ajax/t_uploadHandler.ashx",
        addUrl: "./ajax/t_weiadd.ashx",
        picUploadMaxSize: 20 * 1024 * 1024,
        uploadAcceptFileTypes: /(\.|\/)(gif|jpe?g|png|bmp)$/i,
        loadNum: 0
    };

    mkb.check = mkb.check || {};
    mkb.data = mkb.data || {};
    //检测用户是否输入分项
    mkb.check.checkItem = function () {
        //验证
        $("#ul_item").click(function (ev) {
            var obj = ev.srcElement ? ev.srcElement : ev.target, $span = $(obj).parent("span"), errorItem = $("#itemerror");
            if (obj.nodeName === "EM") {
                $(obj).addClass("good").prevAll().addClass("good");
                $(obj).nextAll().removeClass("good");
                //把点击获取的数据放到对应分项数据中
                $span.attr("value", $(obj).attr("value"));
                errorItem.hide();
            }
        });
        var sum = 0;
        $("[name='div_item'] span").each(function () {
            sum += parseInt($(this).attr("value"));
        });
        return sum;
    };
    mkb.check.zongping = function () {
        var content = $.trim($("#txt_context").val()), $input = $("#pContextFontSizeIn"), $output = $("#pContextFontSizeOut"), len = content.length, errorMsg = $("#contenterror");
        if (content === "" || content === mkb.config.contextDefult) {
            //提示输入总评
            errorMsg.show();
            $output.hide();
            $input.html("还可输入<strong>140</strong>个字符。").show();
            return false;
        }
        //验证输入的字数
        if (len <= 140) {
            $output.hide();
            errorMsg.hide();
            $input.html("还可输入<strong>" + (140 - len) + "</strong>个字符。").show();
        } else {
            $input.hide();
            $output.show();
        }
        if (len < 5) {
            errorMsg.html("最少输入5个字").show();
            return false;
        } else if (len > 140) {
            errorMsg.html("最多输入140个字").show();
            return false;
        } else {
            errorMsg.html("").hide();
        }
        return true;
    };
    //验证用户输入总评
    mkb.check.checkZongPin = function () {
        $("#txt_context").on("keyup input propertychange", function () {
            return mkb.check.zongping();
        }).blur(function () {
            return mkb.check.zongping();
        });
        return true;
    };
    //验证用户上传图片数据
    mkb.check.checkImage = function () {
        var uploadImgNum = $("#hduploadimgnum").val(), loadImgNum = mkb.config.loadNum;
        if (parseInt(uploadImgNum) === 0) {
            return true;
        }
        if (parseInt(uploadImgNum) === parseInt(loadImgNum)) {
            return true;
        }
        return false;
    };
    //验证车款
    mkb.check.checkTrim = function () {
        var mid = $("#mid").val(), sid = $("#sid").val(), carid = $("#carid").val();
        if (parseInt(sid) === 0 || parseInt(carid) === 0) {
            return false;
        }
        return true;
    };
    //清除输入的内容
    mkb.check.clean = function () {
        $("#hduploadimgnum").val(0);
        $("#hdloadimgnum").val(0);
        $("#txt_context").val("");
    };
    //获取数据
    //分项数据
    mkb.data.item = function () {
        //分项
        var itemlist = [], itemObj = mkb.config.itemObj;
        $("[name='div_item']").each(function () {
            var $this = $(this), pingyin = $this.attr("id");
            itemlist.push({
                ItemId: itemObj[pingyin].id,
                ItemName: itemObj[pingyin].name,
                ItemPingYin: pingyin,
                ItemStar: $this.find("span").attr("value")
            });
        });
        return itemlist;
    };
    //图片数据
    mkb.data.images = function () {
        //图片
        var piclist = [];
        $("#files li[name='liFileList']").each(function () {
            var $this = $(this);
            piclist.push({
                PicId: $this.attr("gid"),
                PicUrl: $this.attr("url")
            });
        });
        return piclist;
    };
    //把上传好的图片追加到图片集合中
    mkb.data.showImage = function (result) {
        $("#addimage").before($('<li id="li' + result.Guid + '" name="liFileList" gid="' + result.Guid + '" url="' + result.Url + '" title="' + result.Title + '" sUrl="' + result.ShowUrl + '"><img id="img' + result.Guid + '" src="' + result.ShowUrl + '" alt="' + result.Title + '"></li>'));
    };
    //添加或者减少图片隐藏数据用户上传几张图片 同时要加载图片 
    mkb.data.imageNum = function (result, flag) {
        var numObj = $("#hduploadimgnum"), num = 0;
        num = numObj.val();

        if (flag === "+") {
            numObj.val(parseInt(num) + 1);
            //加载图片
            $("#img" + result.Guid).load(function () {
                //loadImgObj.val(parseInt(loadNum) + 1);
                mkb.config.loadNum++;
                //同时放置关闭按钮
                $(this).after($('<a id="aDel' + result.Guid + '" href="javascript:;"  style="display: block;" class="close">关闭</a>'));
                //删除图片
                mkb.data.delImg(result);
            });
        } else {
            if (num > 0) {
                numObj.val(parseInt(num) - 1);
            } else {
                numObj.val(0);
            }
            if (mkb.config.loadNum > 0) {
                mkb.config.loadNum--;
                //loadImgObj.val(parseInt(loadNum) - 1);
            } else {
                //loadImgObj.val(0);
                mkb.config.loadNum = 0;
            }
        }

    };
    //删除图片
    mkb.data.delImg = function (result) {
        var $li = $('#li' + result.Guid), $ad = $('#aDel' + result.Guid);
        $ad.on("click", function () {
            $li.remove();
            $("#imageerror").hide();
            mkb.data.imageNum(result, "-");
        });
    };
    //上传图片
    mkb.data.uploadImages = function () {
        var $msg = $("#imageerror"), isSend = $("#btnSend");
        $('#fileupload').fileupload({
            url: mkb.config.picUploadUrl,
            dataType: 'json',
            maxFileSize: mkb.config.picUploadMaxSize,
            sequentialUploads: true, //顺序执行，控制图片数量
            send: function (e, data) {
                //设置不可发送
                isSend.attr("issend", 1);
                var f = 0;
                //大小类型验证
                $.each(data.files, function (index, file) {
                    if (file.size > mkb.config.picUploadMaxSize) {
                        $msg.html("未上传大小正确的文件").show();
                        f = 1;
                    } else if (!mkb.config.uploadAcceptFileTypes.test(file.name)) {
                        $msg.html("未上传格式正确的文件").show();
                        f = 1;
                    } else {
                        $msg.hide();
                    }
                });
                if (f === 1) {
                    isSend.attr("issend", 0); //可以提交
                    return false;
                }
                //上传合计验证
                var num = $("#hduploadimgnum").val();
                if (num < 9) {
                    $("#addimage").before($('<li id="liUploading"><div id="divUploadPer"class="up_ing">已上传10%</div></li>')); //上传中样式
                    $msg.hide();
                    return true;
                } else {
                    $msg.html("最多上传9张图片").show();
                    return false;
                }

            },
            done: function (e, data) {
                $('#liUploading').remove(); //上传中样式
                var result = data.result;
                if (result.State === 1) {
                    mkb.data.showImage(result);
                    //添加数目
                    mkb.data.imageNum(result, "+");

                } else {
                    $msg.html("未上传正确的文件").show();
                }
                isSend.attr("issend", 0);
            },
            fail: function (e, data) {
                $('#liUploading').remove();
                //$msg.html("未上传正确的文件").show();
                isSend.attr("issend", 0); //可以提交
            },
            progress: function (e, data) {
                var progress = parseInt(data.loaded / data.total * 100, 10);
                $('#divUploadPer').html('已上传' + progress + '%');
            }
        });
    };
    //
    mkb.data.add = function () {
        var btnSend = $("#btnSend");
        btnSend.click(function () {
            //数据未加载全
            if (parseInt(btnSend.attr("issend")) === 1) {
                //alert("请填写完整信息");
                $("#msg_go").html("请填写完整信息").show();
                return false;
            }
            //验证数据 
            var item = mkb.check.checkItem(), zongping = mkb.check.checkZongPin(), zong = mkb.check.zongping(), image = mkb.check.checkImage(), data = {}, itemData = [], imageData = [], content = $.trim($("#txt_context").val()), carid, sid, trim = mkb.check.checkTrim(), errorItem = $("#itemerror");
            if (!trim) {
                //alert("请选择车款");
                $("#errortrim").html("请选择车款").show();
                location.href = "#nametrim";
                return false;
            }
            if (!item) {
                errorItem.show();
                location.href = "#nameitem";
                return false;
            } else {
                errorItem.hide();
            }

            if (content === "" || content === mkb.config.contextDefult) {
                //alert("请输入总评");
                location.href = "#namecontent";
                $("#contenterror").html("请输入总评").show();
                return false;
            }
            if (!zongping) {
                //alert("请填写总评");
                location.href = "#namecontent";
                $("#contenterror").html("请输入总评").show();
                return false;
            }
            if (!zong) {
                return false;
            }
            if (!image) {
                //alert("等待图片加载...");
                $("#imageerror").html("等待图片加载...").show();
                location.href = "#nameimage";
                return false;
            }
            //发送中
            btnSend.html("发送中...").off("click");
            //获取数据
            itemData = mkb.data.item();
            imageData = mkb.data.images();

            carid = $("#carid").val();
            sid = parseInt($("#sid").val());
            data = {
                carid: sid,
                trimid: carid,
                itemlist: encodeURIComponent(JSON.stringify(itemData)),
                piclist: JSON.stringify(imageData),
                content: encodeURIComponent(content)
            };
            $.ajax({
                url: mkb.config.addUrl,
                dataType: "json",
                type: "post",
                data: data,
                success: function (res) {
                    if (res.state === 0) {
                        w.setTimeout(function () { w.location.href = res.url; }, 2000);
                    } else {
                        //msg.html(res.message).show();
                        $("#msg_go").html(res.message).show();
                    }
                },
                error: function () {

                }
            });
        });
    };
    //初始化
    mkb.init = function () {
        //验证分项
        mkb.check.checkItem();
        //验证总评
        mkb.check.checkZongPin();

        //上传图片
        mkb.data.uploadImages();

        mkb.data.add();

        //清除内容
        mkb.check.clean();
    };
    mkb.init();
})(jQuery, window);