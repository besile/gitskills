/*==================用户登录部分(该js类单独使用不依赖pflibrary_public5.1.js)========================*/
function Request(name) {
    var reg = new RegExp("(^|\\?|&)" + name + "=([^&]*)(\\s|&|$)", "i");
    if (reg.test(location.href)) {
        return unescape(RegExp.$2.replace(/\+/g, " "));
    }
    else {
        return "";
    }
}
document.onkeydown = function (e) {
    e = e || window.event;
    var keyCode = e.keyCode;
    if (keyCode == 13) {
        if (window.location.href.indexOf("login.htm") > -1) {
            PF_Login();
        }
        else {
            FastRegProess();
        }
    }
}
//登录和注册切换
function loginRegisterSwap(eleName) {
    if (eleName == "reg") {
        PF_GetRegValImg();
    }
    var btn = "#span_" + eleName;
    $(btn).click();
}
//登录框加载初始化
$(document).ready(
function () {

});
//初始化捧腹登录状态
function PF_InitLoginBar(isTrue) {
    syncCallBack(function () {
        initUserInfo();
    }, 1000);
}

//登陆后回调
function loginCallBack() {
    Tx_WriteSingleLogin();
    syncCallBack(function () {
        //initUserInfo();
        LoginPengFu();
    }, 1500);
}
//注册后回调
function registerCallBack() {
    Tx_WriteSingleLogin();
    syncCallBack(function () {

    }, 1500);
    syncCallBack(function () {
        //initUserInfo();
    }, 1000);
}

function initUserInfo() {
    var userId = UserInfo().userId;
    var res = InitLoginInfo(userId, true, LoginSuccess, LoginFail);
    if (res) {
        //初始化登录信息
        parent.TX.PopLayer.CloseLayer(); //关闭弹出层
    }
}

//登录
function PF_Login() {
    var fastLoginUserName = $("#fastLoginUserName");
    var fastLoginPassWord = $("#fastLoginPwd");
    expDT = 365;
    if (fastLoginUserName.val().length < 1) {
        alert("用户ID不能为空"); fastLoginUserName.focus(); return;
    }
    else if (fastLoginPassWord.val().length < 1) {
        alert("密码不能为空");
        fastLoginPassWord.focus();
        return;
    }

    var fastLoginValidate = $("#fastLoginValtext");
    var isNeedCaptcha;
    var captchaCode = "";
    if (fastLoginValidate.is(":visible")) {
        isNeedCaptcha = true;
        captchaCode = $("#fastLoginVal").val();
    } else {
        isNeedCaptcha = false;
    }


}



//验证码
//TxReg_GetFastRegValImg
function PF_GetRegValImg() {
    $("#fastRegValImg").attr("src", 'http://sso.tiexue.net/captcha/image?width=80&height=30&t=' + Math.random());
}
//TxReg_GetFastLoginValImg
function PF_GetLoginValImg() {
    $("#fastLoginValImg").attr("src", 'http://sso.tiexue.net/captcha/image?width=80&height=30&t=' + Math.random());
}
//注册
function FastRegProess() {
    if (document.getElementById("chkAgree").checked == true) {
        var jUserName = $("#fastRegUserName");
        if (jUserName.val() == "") {
            $("#fastRegUserName").select(); alert("请输入用户名!"); return false;
        }
        var jUserPwd = $("#fastRegPwd");
        if (jUserPwd.val() == "") {
            $("#fastRegPwd").select(); alert("请输入密码!"); return false;
        }
        var jUserRePwd = $("#fastRegRePwd");
        if (jUserRePwd.val() == "") {
            $("#fastRegRePwd").select(); alert("请再次输入密码!"); return false;
        }
        var jUserEmail = $("#fastRegEmail");
        if (jUserEmail.val() == "") {
            $("#fastRegEmail").select(); alert("请输入邮箱!"); return false;
        }
        var jUserVal = $("#fastRegVal");
        if (jUserVal.val() == "") {
            $("#fastRegVal").select(); alert("请输入验证码!"); return false;
        }

        $.ajax({
            url: "./ajax/ajax_Regist.ashx",
            data: { userName: jUserName.val(), pwd: jUserPwd.val(), email: jUserEmail.val(), code: jUserVal.val() },
            dataType: "json",
            type: "post",
            success: function (res) {
                if (res.success) {
                    //初始化登录信息
                    parent.TX.PopLayer.CloseLayer(); //关闭弹出层
                } else {
                    alert("注册错误");
                }
            },
            error: function () {
                alert("网络错误啦!");
            }
        });
    }
    else {
        alert("请先阅读注册条款。");
    }
}
//清空input初始化值
function clearAalue(obj, isLand) {
    if (obj.value == "邮箱/用户名" || obj.value == "邮箱" || obj.value == "用户名" || obj.value == "验证码") {
        obj.value = "";
        $(obj).select();
    }
    if (obj.value == "密码") {
        //登陆页密码框
        if (isLand) {
            $(obj).parent().html("<input id=\"fastLoginPwd\" type=\"password\" />");
            $("#fastLoginPwd").select();
        }
        //注册页密码框
        else {
            $(obj).parent().html("<input id=\"fastRegPwd\" type=\"password\" />");
            $("#fastRegPwd").select();
        }
    }
    if (obj.value == "确认密码") {
        $(obj).parent().html("<input id=\"fastRegRePwd\" type=\"password\" />");
        $("#fastRegRePwd").select();
    }
}


function showQQ() {
    SetCookie(OAuthOperateKey, "login", 60 * 60 * 24 * 7);
    parent.window.open('http://oauth.pengfu.com/Account/LogOn?ClientId=1&ServiceProvider=QQ', '_blank', 'height=600, width=600, toolbar=no, menubar=no, scrollbars=yes, resizable=no, location=no, status=no');
}

function showSina() {
    SetCookie(OAuthOperateKey, "login", 60 * 60 * 24 * 7);
    parent.window.open('http://oauth.pengfu.com/Account/LogOn?ClientId=1&ServiceProvider=SinaWeibo', '_blank', 'height=600, width=600, toolbar=no, menubar=no, scrollbars=yes, resizable=no, location=no, status=no');
}