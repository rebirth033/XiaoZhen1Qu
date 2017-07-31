$(document).ready(function () {
    $("#liGRZX").css("font-size", "18px").css("font-weight", "700");
    $("#imgWDQZ").attr("src", getRootPath() + "/Areas/Business/Css/images/down.png");
    $("#imgWDZP").attr("src", getRootPath() + "/Areas/Business/Css/images/down.png");
    $("#liGRZX").bind("click", ShowGRZX);
    $("#liZHSZ").bind("click", ShowZHSZ);
    $("#liSHGJ").bind("click", ShowSHGJ);
    $("#spanWDFB").bind("click", ToWDFB);
    $("#spanWDSC").bind("click", ToWDSC);
    $("#spanGRZL").bind("click", ToGRZL);
    $("#spanZHBD").bind("click", ToZHBD);
    $("#spanRZGL").bind("click", ToRZGL);
    $("#spanMMSZ").bind("click", ToMMSZ);
    $("#spanXXGL").bind("click", ToXXGL);
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

//显示个人中心
function ShowGRZX() {
    $("#liGRZX").css("font-size", "18px").css("font-weight", "700");
    $("#liZHSZ").css("font-size", "16px").css("font-weight", "normal");
    $("#liSHGJ").css("font-size", "16px").css("font-weight", "normal");
    $("#ulGRZX").css("display", "block");
    $("#ulZHSZ").css("display", "block");
    $("#ulSHGJ").css("display", "block");
}
//显示账户设置
function ShowZHSZ() {
    $("#liZHSZ").css("font-size", "18px").css("font-weight", "700");
    $("#liGRZX").css("font-size", "16px").css("font-weight", "normal");
    $("#liSHGJ").css("font-size", "16px").css("font-weight", "normal");
    $("#ulGRZX").css("display", "none");
    $("#ulZHSZ").css("display", "block");
    $("#ulSHGJ").css("display", "block");
}
//显示生活工具
function ShowSHGJ() {
    $("#liSHGJ").css("font-size", "18px").css("font-weight", "700");
    $("#liGRZX").css("font-size", "16px").css("font-weight", "normal");
    $("#liZHSZ").css("font-size", "16px").css("font-weight", "normal");
    $("#ulGRZX").css("display", "none");
    $("#ulZHSZ").css("display", "none");
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