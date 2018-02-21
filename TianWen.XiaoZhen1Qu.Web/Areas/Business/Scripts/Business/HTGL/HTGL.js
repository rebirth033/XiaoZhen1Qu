$(document).ready(function () {
    $(".div_content").css("margin-left", (document.documentElement.clientWidth - 1084) / 2);
    $(".div_head_left").css("margin-left", (document.documentElement.clientWidth - 1044) / 2);
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 1084) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 1084) / 2);
    $(".span_fbxx").css("margin-right", (document.documentElement.clientWidth - 1084) / 2);
    $("#liWDXX").bind("click", ShowWDXX);
    $("#liWDZH").bind("click", ShowWDZH);
    $("#liWDZJ").bind("click", ShowWDZJ);
    $("#liSHGJ").bind("click", ShowSHGJ);
    $("#spanWDFB").bind("click", ToWDFB);
    $("#spanWDSC").bind("click", ToWDSC);
    $("#spanGRZL").bind("click", ToGRZL);
    $("#spanZHBD").bind("click", ToZHBD);
    $("#spanRZGL").bind("click", ToRZGL);
    $("#spanMMSZ").bind("click", ToMMSZ);
    $("#spanXXGL").bind("click", ToXXGL);
    $("#spanHFCZ").bind("click", ToHFCZ);
    $("#spanYXCZ").bind("click", ToYXCZ);
    $("#spanWZCX").bind("click", ToWZCX);
    $("#span_top_right_sy").bind("click", OpenSY);
    $("#spanBZZX").bind("click", OpenBZZX);
    $("#spanXJMXCX").bind("click", ToXJMXCX);
    $("#spanXJCZ").bind("click", ToXJCZ);
    //$("#spanWDQZ").parent().bind("click", { type: "WDQZ" }, ExpandSecond_Leaf);
    //$("#spanWDZP").parent().bind("click", { type: "WDZP" }, ExpandSecond_Tree);
    //$("#spanZWGL").parent().bind("click", { type: "ZWGL" }, ExpandThird);
    //$("#spanJLGL").parent().bind("click", { type: "JLGL" }, ExpandThird);
    //$("#spanZHXX").parent().bind("click", { type: "ZHXX" }, ExpandThird);
    //$("#spanTGB").parent().bind("click", { type: "TGB" }, ExpandSecond_Leaf);
    $(".li_left_menu").bind("click", LiFocus);
    $("#span_close").bind("click", CloseQQRZ);
    $("#span_xjfwxy_close").bind("click", CloseXJFWXY);
    $("#div_body_image_qqtx").bind("mouseover", ShowQQ);
    $("#div_body_image_qqtx").bind("mouseleave", HideQQ);
    $("#div_body_image_qqtx").bind("click", QQBD);
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);
    $("#span_fbxx").bind("click", OpenLBXZ);
    $("#title").html("信息小镇_后台管理");
    if (getUrlParam("Show") === "WDZJ")
        ShowWDZJ();
    else
        ShowWDXX();

});
//显示用户菜单
function ShowYHCD() {
    $("#div_top_right_dropdown_yhm").css("display", "block");
    $("#span_top_right_yhm_img").css("background-image", 'url(' + getRootPath() + "/Areas/Business/Css/images/arrow_up.png" + ')');
}
//隐藏用户菜单
function HideYHCD() {
    $("#div_top_right_dropdown_yhm").css("display", "none");
    $("#span_top_right_yhm_img").css("background-image", 'url(' + getRootPath() + "/Areas/Business/Css/images/arrow_down.png" + ')');
}
//退出
function Exit() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/YHDL/Exit",
        dataType: "json",
        data: {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.location.href = getRootPath() + "/YHDL/YHDL";
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//自动登录
function AutoLogin() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/YHGL/AutoLogin",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.wxc.xcConfirm("登录成功", window.wxc.xcConfirm.typeEnum.success);
            } else {
                window.location.href = getRootPath() + "/YHDL/YHDL";
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
    $(this).find("span").each(function () {
        $(this).css("color", "#bc6ba6");
    });
}
//我的发布
function ToWDFB() {
    $("#iframeright").attr("src", getRootPath() + "/WDFB/WDFB");
}
//我的收藏
function ToWDSC() {
    $("#iframeright").attr("src", getRootPath() + "/WDSC/WDSC");
}
//个人资料
function ToGRZL() {
    $("#iframeright").attr("src", getRootPath() + "/GRZL/GRZL");
}
//我的资金>现金>明细查询
function ToXJMXCX() {
    $("#iframeright").attr("src", getRootPath() + "/WDXJ/WDXJ_MXCX");
}
//我的资金>现金>充值
function ToXJCZ() {
    $("#iframeright").attr("src", getRootPath() + "/WDXJ/WDXJ_CZ");
}
//账号绑定
function ToZHBD() {
    $("#iframeright").attr("src", getRootPath() + "/ZHBD/ZHBD");
}
//认证管理
function ToRZGL() {
    $("#iframeright").attr("src", getRootPath() + "/RZGL/RZGL");
}
//密码设置
function ToMMSZ() {
    $("#iframeright").attr("src", getRootPath() + "/GRZL/MMSZ");
}
//消息管理
function ToXXGL() {
    $("#iframeright").attr("src", getRootPath() + "/XXGL/XXGL");
}
//话费充值
function ToHFCZ() {
    $("#iframeright").attr("src", getRootPath() + "/HFCZ/HFCZ");
}
//游戏充值
function ToYXCZ() {
    $("#iframeright").attr("src", getRootPath() + "/YXCZ/YXCZ");
}
//违章查询
function ToWZCX() {
    $("#iframeright").attr("src", getRootPath() + "/WZCX/WZCX");
}
//首页
function OpenSY() {
    window.open(getRootPath() + "/SY/SY");
}
//帮助中心
function OpenBZZX() {
    window.open(getRootPath() + "/BZZX/BZZX");
}
//类别选择
function OpenLBXZ() {
    window.open(getRootPath() + "/LBXZ/LBXZ");
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
    ToWDFB();
}
//显示我的账户
function ShowWDZH() {
    $("#liWDXX").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZH").css("font-size", "18px").css("font-weight", "700");
    $("#liWDZJ").css("font-size", "16px").css("font-weight", "normal");
    $("#liSHGJ").css("font-size", "16px").css("font-weight", "normal");
    $("#ulWDXX").css("display", "none");
    $("#ulWDZH").css("display", "block");
    $("#ulWDZJ").css("display", "block");
    $("#ulSHGJ").css("display", "block");
    ToGRZL();
}
//显示我的资金
function ShowWDZJ() {
    $("#liWDXX").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZH").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZJ").css("font-size", "18px").css("font-weight", "700");
    $("#liSHGJ").css("font-size", "16px").css("font-weight", "normal");
    $("#ulWDXX").css("display", "none");
    $("#ulWDZH").css("display", "none");
    $("#ulWDZJ").css("display", "block");
    $("#ulSHGJ").css("display", "block");
    ToXJMXCX();
}
//显示生活工具
function ShowSHGJ() {
    $("#liWDXX").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZH").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZJ").css("font-size", "16px").css("font-weight", "normal");
    $("#liSHGJ").css("font-size", "18px").css("font-weight", "700");
    $("#ulWDXX").css("display", "none");
    $("#ulWDZH").css("display", "none");
    $("#ulWDZJ").css("display", "none");
    $("#ulSHGJ").css("display", "block");
    ToHFCZ();
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
            $("." + this.id.substr(4, 4) + "_child").each(function () {
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
//关闭信息小镇现金服务协议窗口
function CloseXJFWXY() {
    $("#XJFWXYWindow").css("display", "none");
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
    $("#div_body_image_qqtx").find(".toolbar").each(function () {
        $.ajax({
            type: "POST",
            url: getRootPath() + "/GRZL/UpdateQQ",
            dataType: "json",
            data:
            {
                YHID: getUrlParam("YHID"),
                QQ: $(this).html()
            },
            success: function (xml) {
                if (xml.Result === 1) {
                    window.wxc.xcConfirm("QQ绑定成功", window.wxc.xcConfirm.typeEnum.success);
                    CloseQQRZ();
                    $("#iframeright").attr("src", getRootPath() + "/ZHBD/ZHBD");
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

            }
        });
    });
}