$(document).ready(function () {
    $("#liWDXX").css("font-size", "18px").css("font-weight", "700");
    $("#liWDXX").bind("click", ShowWDXX);
    $("#liWDZH").bind("click", ShowWDZH);
    $("#liWDZJ").bind("click", ShowWDZJ);
    $("#liSHGJ").bind("click", ShowSHGJ);
    $("#spanWDFB").bind("click", ToWDFB);
    $("#spanWDSC").bind("click", ToWDSC);
    $("#spanGRZL").bind("click", ToGRZL);
    $("#spanWDZJ").bind("click", OpenWDZJ);
    $("#spanZHBD").bind("click", ToZHBD);
    $("#spanRZGL").bind("click", ToRZGL);
    $("#spanMMSZ").bind("click", ToMMSZ);
    $("#spanXXGL").bind("click", ToXXGL);
    $("#spanHFCZ").bind("click", ToHFCZ);
    $("#spanYXCZ").bind("click", ToYXCZ);
    $("#spanWZCX").bind("click", ToWZCX);
    $("#spanBZZX").bind("click", OpenBZZX);
    $("#spanWDQZ").parent().bind("click", { type: "WDQZ" }, ExpandSecond_Leaf);
    $("#spanWDZP").parent().bind("click", { type: "WDZP" }, ExpandSecond_Tree);
    $("#spanZWGL").parent().bind("click", { type: "ZWGL" }, ExpandThird);
    $("#spanJLGL").parent().bind("click", { type: "JLGL" }, ExpandThird);
    $("#spanZHXX").parent().bind("click", { type: "ZHXX" }, ExpandThird);
    $(".li_left_menu").bind("click", LiFocus);
    $("#span_close").bind("click", CloseQQRZ);
    $("#div_body_image_qqtx").bind("mouseover", ShowQQ);
    $("#div_body_image_qqtx").bind("mouseleave", HideQQ);
    $("#div_body_image_qqtx").bind("click", QQBD);
    ToWDFB();
});
//自动登录
function AutoLogin() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/YHGL/AutoLogin",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                alert("登录成功");
            } else {
                window.location.href = getRootPath() + "/Business/YHDLXX/YHDLXX";
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//菜单激活样式
function LiFocus() {
    $(".li_left_menu").each(function () {
        $(this).find("span").each(function () {
            $(this).css("color", "#595757");
        });
    });
    $(this).find("span").each(function() {
        $(this).css("color", "#ff6100");
    });
}
//我的发布
function ToWDFB() {
    $("#iframeright").attr("src", getRootPath() + "/Business/WDFB/WDFB?YHID="+getUrlParam("YHID"));
}
//我的收藏
function ToWDSC() {
    $("#iframeright").attr("src", getRootPath() + "/Business/WDSC/WDSC?YHID=" + getUrlParam("YHID"));
}
//个人资料
function ToGRZL() {
    $("#iframeright").attr("src", getRootPath() + "/Business/GRZL/GRZL?YHID=" + getUrlParam("YHID"));
}
//我的资金
function OpenWDZJ() {
    window.open(getRootPath() + "/Business/WDZJ/WDZJ?YHID=" + getUrlParam("YHID"));
}
//账号绑定
function ToZHBD() {
    $("#iframeright").attr("src", getRootPath() + "/Business/ZHBD/ZHBD?YHID=" + getUrlParam("YHID"));
}
//认证管理
function ToRZGL() {
    $("#iframeright").attr("src", getRootPath() + "/Business/RZGL/RZGL?YHID=" + getUrlParam("YHID"));
}
//密码设置
function ToMMSZ() {
    $("#iframeright").attr("src", getRootPath() + "/Business/GRZL/MMSZ?YHID=" + getUrlParam("YHID"));
}
//消息管理
function ToXXGL() {
    $("#iframeright").attr("src", getRootPath() + "/Business/XXGL/XXGL?YHID=" + getUrlParam("YHID"));
}

//话费充值
function ToHFCZ() {
    $("#iframeright").attr("src", getRootPath() + "/Business/HFCZ/HFCZ?YHID=" + getUrlParam("YHID"));
}

//游戏充值
function ToYXCZ() {
    $("#iframeright").attr("src", getRootPath() + "/Business/YXCZ/YXCZ?YHID=" + getUrlParam("YHID"));
}

//违章查询
function ToWZCX() {
    $("#iframeright").attr("src", getRootPath() + "/Business/WZCX/WZCX?YHID=" + getUrlParam("YHID"));
}

//帮助中心
function OpenBZZX() {
    window.open(getRootPath() + "/Business/BZZX/BZZX?YHID=" + getUrlParam("YHID"));
}

//显示我的信息
function ShowWDXX() {
    $("#liWDXX").css("font-size", "18px").css("font-weight", "700");
    $("#liWDZH").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZJ").css("font-size", "16px").css("font-weight", "normal");
    $("#liSHGJ").css("font-size", "16px").css("font-weight", "normal");
    $("#ulWDXX").css("display", "block");
    $("#ulWDZH").css("display", "block");
    $("#ulWDZJ").css("display", "block");
    $("#ulSHGJ").css("display", "block");
}
//显示我的账户
function ShowWDZH() {
    $("#liWDXX").css("font-size", "18px").css("font-weight", "normal");
    $("#liWDZH").css("font-size", "18px").css("font-weight", "700");
    $("#liWDZJ").css("font-size", "16px").css("font-weight", "normal");
    $("#liSHGJ").css("font-size", "16px").css("font-weight", "normal");
    $("#ulWDXX").css("display", "none");
    $("#ulWDZH").css("display", "block");
    $("#ulWDZJ").css("display", "block");
    $("#ulSHGJ").css("display", "block");
}
//显示我的资金
function ShowWDZJ() {
    $("#liWDXX").css("font-size", "18px").css("font-weight", "normal");
    $("#liWDZH").css("font-size", "18px").css("font-weight", "normal");
    $("#liWDZJ").css("font-size", "16px").css("font-weight", "700");
    $("#liSHGJ").css("font-size", "16px").css("font-weight", "normal");
    $("#ulWDXX").css("display", "none");
    $("#ulWDZH").css("display", "none");
    $("#ulWDZJ").css("display", "block");
    $("#ulSHGJ").css("display", "block");
}
//显示生活工具
function ShowSHGJ() {
    $("#liWDXX").css("font-size", "18px").css("font-weight", "normal");
    $("#liWDZH").css("font-size", "18px").css("font-weight", "normal");
    $("#liWDZJ").css("font-size", "16px").css("font-weight", "normal");
    $("#liSHGJ").css("font-size", "16px").css("font-weight", "700");
    $("#ulWDXX").css("display", "none");
    $("#ulWDZH").css("display", "none");
    $("#ulWDZJ").css("display", "none");
    $("#ulSHGJ").css("display", "block");
}
//展开第二级叶子节点
function ExpandSecond_Leaf(obj) {
    if ($("#img" + obj.data.type).attr("src").indexOf("up") !== -1) {
        $("." + obj.data.type + "_child").each(function () {
            $(this).css("display", "none");
        });
        $(".img_left_menu_third").each(function () {
            $(this).css("display", "none");
        });
        $("#img" + obj.data.type).attr("src", getRootPath() + "/Areas/Business/Css/images/down.png");
    } else {
        $("." + obj.data.type + "_child").each(function () {
            $(this).css("display", "block");
        });
        $(".img_left_menu_third").each(function () {
            $(this).css("display", "block");
        });
        $("#img" + obj.data.type).attr("src", getRootPath() + "/Areas/Business/Css/images/up.png");
    }
}
//展开第二级非叶子节点
function ExpandSecond_Tree(obj) {
    if ($("#img" + obj.data.type).attr("src").indexOf("up") !== -1) {
        $("." + obj.data.type + "_child").each(function () {
            $("." + this.id.substr(4, 4) + "_child").each(function() {
                $(this).css("display", "none");
            });
            $(this).css("display", "none");
        });
        $(".img_left_menu_third").each(function () {
            $(this).css("display", "none");
        });
        $("#img" + obj.data.type).attr("src", getRootPath() + "/Areas/Business/Css/images/down.png");
    } else {
        $("." + obj.data.type + "_child").each(function () {
            $(this).css("display", "block");
        });
        $(".img_left_menu_third").each(function () {
            $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/expand.png");
            $(this).css("display", "block");
        });
        $("#img" + obj.data.type).attr("src", getRootPath() + "/Areas/Business/Css/images/up.png");
    }
}
//展开第三级节点
function ExpandThird(obj) {
    if ($("#img" + obj.data.type).attr("src").indexOf("expand") !== -1) {
        $("." + obj.data.type + "_child").each(function () {
            $(this).css("display", "block");
        });
        $(".img_left_menu_four").each(function () {
            $(this).css("display", "block");
        });
        $("#img" + obj.data.type).attr("src", getRootPath() + "/Areas/Business/Css/images/contract.png");
    } else {
        $("." + obj.data.type + "_child").each(function () {
            $(this).css("display", "none");
        });
        $(".img_left_menu_four").each(function () {
            $(this).css("display", "none");
        });
        $("#img" + obj.data.type).attr("src", getRootPath() + "/Areas/Business/Css/images/expand.png");
    }
}
//关闭QQ认证窗口
function CloseQQRZ() {
    $("#editImgWindow").css("display", "none");
    $("#shadow").css("display", "none");
}
//显示QQ号码
function ShowQQ() {
    $(this).find("div").each(function () {
        $(this).css("display", "block");
    });
}
//隐藏QQ号码
function HideQQ() {
    $(this).find("div").each(function () {
        $(this).css("display", "none");
    });
}
//绑定QQ
function QQBD() {
    $("#div_body_image_qqtx").find(".toolbar").each(function() {
        $.ajax({
            type: "POST",
            url: getRootPath() + "/Business/GRZL/UpdateQQ",
            dataType: "json",
            data:
            {
                YHID: getUrlParam("YHID"),
                QQ: $(this).html()
            },
            success: function (xml) {
                if (xml.Result === 1) {
                    alert("QQ绑定成功");
                    CloseQQRZ();
                    $("#iframeright").attr("src", getRootPath() + "/Business/ZHBD/ZHBD?YHID=" + getUrlParam("YHID"));
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

            }
        });
    });
}