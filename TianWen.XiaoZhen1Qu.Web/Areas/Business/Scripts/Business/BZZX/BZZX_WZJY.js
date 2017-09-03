$(document).ready(function () {
    $(".span_wtlx_inner_right").bind("click", SelectWTLX);
    $("#btnTJYJ").bind("click", TJYJ);
    $("#inputUpload").bind("change", Upload);
    bindHover();
    BindWTMS();
});
//选择问题类型
function SelectWTLX() {
    $(".span_wtlx_inner_right").each(function () {
        $(this).css("background-color", "#ffffff").css("font-weight", "normal").css("color", "#000");
    });
    bindHover();
    $(this).css("background-color", "#ff6a00").css("font-weight", "700").css("color", "#fff");
    $(this).unbind("mouseleave");
    showWTLX(this.id);
}
//绑定问题类型hover事件
function bindHover() {
    $(".span_wtlx_inner_right").each(function () {
        $(this).bind("mouseover", function () {
            $(this).css("background-color", "#ff6a00").css("font-weight", "700").css("color", "#fff");
        })
        $(this).bind("mouseleave", function () {
            $(this).css("background-color", "#ffffff").css("font-weight", "normal").css("color", "#000");
        })
    });
}
//绑定具体问题hover事件
function bindJTWTHover() {
    $(".span_wtjj_inner").each(function () {
        $(this).bind("mouseover", function () {
            $(this).css("color", "#ff6a00");
        })
        $(this).bind("mouseleave", function () {
            $(this).css("color", "#0000cd");
        })
    });
}
//绑定问题描述框
function BindWTMS() {
    $("#textarea_yjnr").bind("focus", WTMSFocus);
    $("#textarea_yjnr").bind("blur", WTMSBlur);
}
//问题描述框鼠标键入
function WTMSFocus() {
    $("#textarea_yjnr").css("color", "#333333");
    if ($("#textarea_yjnr").val().indexOf("您可填写15-300字") !== -1)
        $("#textarea_yjnr").html("");
}
//问题描述框鼠标移除
function WTMSBlur() {
    $("#textarea_yjnr").css("color", "#999999");
    if ($("#textarea_yjnr").html() === "") {
        $("#textarea_yjnr").html("您可填写15-300字。\r\n您的意见若被采纳，会通过消息通知您，请关注消息更新记录");
    }
}
//类别检查
function CheckLB() {
    var hasSelect = false;
    $(".span_wtlx_inner_right").each(function () {
        if ($(this).css("color") !== "rgb(51, 51, 51)")
            hasSelect = true;
    });
    if (hasSelect)
        return true;
    else {
        alert("还未选择类别");
        return false;
    }
}
//意见内容检查
function CheckYJNR() {
    if ($("#textarea_yjnr").val().indexOf("您可填写15-300字") !== -1) {
        $("#textarea_yjnr").css("border-color", "#F2272D");
        $("#span_yjnrinfo").css("color", "#F2272D");
        $("#span_yjnrinfo").html("意见内容在15-300字之间，不可为空");
        return false;
    }
    else {
        $("#textarea_yjnr").css("border-color", "#DEDEDE");
        $("#span_yjnrinfo").html("");
        return true;
    }
}
//网站意见验证
function ValidateWZYJ() {
    if (CheckLB() & CheckYJNR())
        return true;
    else
        return false;
}

function TJYJ() {
    if (ValidateWZYJ() === false) return;
    //var jsonObj = new JsonDB("myTabContent");
    //var obj = jsonObj.GetJsonObject();
    ////手动添加如下字段
    //obj = jsonObj.AddJson(obj, "CX", "'" + $("#spanFWCX").html() + "'");
    //obj = jsonObj.AddJson(obj, "ZXQK", "'" + $("#spanZXQK").html() + "'");
    //obj = jsonObj.AddJson(obj, "ZZLX", "'" + $("#spanZZLX").html() + "'");
    //obj = jsonObj.AddJson(obj, "YFFS", "'" + $("#spanYFFS").html() + "'");
    //obj = jsonObj.AddJson(obj, "ZJYBHFY", "'" + GetDX("BHFY") + "'");
    //obj = jsonObj.AddJson(obj, "FWPZ", "'" + GetDX("FWPZ") + "'");
    //obj = jsonObj.AddJson(obj, "FWLD", "'" + GetDX("FWLD") + "'");
    //obj = jsonObj.AddJson(obj, "CZYQ", "'" + GetDX("CZYQ") + "'");
    //obj = jsonObj.AddJson(obj, "CZFS", "'" + GetCZFS() + "'");
    //obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    //if ($("#KRZSJ").val() !== "")
    //    obj = jsonObj.AddJson(obj, "KRZSJ", "'" + $("#KRZSJ").val() + "'");
    //if (getUrlParam("FWCZJBXXID") !== null)
    //    obj = jsonObj.AddJson(obj, "FWCZJBXXID", "'" + getUrlParam("FWCZJBXXID") + "'");

    //$.ajax({
    //    type: "POST",
    //    url: getRootPath() + "/Business/FWCZ/FB",
    //    dataType: "json",
    //    data:
    //    {
    //        Json: jsonObj.JsonToString(obj),
    //        FYMS: $("#FYMS").html(),
    //        FWZP: GetPhotoUrls()
    //    },
    //    success: function (xml) {
    //        if (xml.Result === 1) {
    //            window.location.href = getRootPath() + "/Business/FBCG/FBCG";
    //        } else {
    //            if (xml.Type === 1) {
    //                $("#YZM").css("border-color", "#F2272D");
    //                $("#YZMInfo").css("color", "#F2272D");
    //                $("#YZMInfo").html(xml.Message);
    //            }
    //            if (xml.Type === 2) {
    //                $("#YHM").css("border-color", "#F2272D");
    //                $("#YHMInfo").css("color", "#F2272D");
    //                $("#YHMInfo").html(xml.Message);
    //            }
    //        }
    //    },
    //    error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

    //    }
    //});
}