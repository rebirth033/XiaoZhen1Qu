﻿$(document).ready(function () {
    $("#div_gq_cz").bind("click", CZSelect);
    $("#div_gq_cs").bind("click", CSSelect);
    $("body").bind("click", function() { Close("_XZQ"); });
    LoadFC_CWJBXX();
    BindClick("ZJDW");
});
//选择出租
function CZSelect() {
    $("#divZJ").css("display", "block");
    $("#divSJ").css("display", "none");
}
//选择出售
function CSSelect() {
    $("#divZJ").css("display", "none");
    $("#divSJ").css("display", "block");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "ZJDW") {
            LoadCODESByTYPENAME("租金单位", "ZJDW", "CODES_FC");
        }
    });
}
//设置供求
function SetGQ(gq) {
    if (gq !== "出售") {
        $("#divZJ").css("display", "block");
        $("#divSJ").css("display", "none");
    }
    else {
        $("#divZJ").css("display", "none");
        $("#divSJ").css("display", "block");
    }
}
//获取供求
function GetGQ() {
    var value = "";
    $("#divGQ").find("img").each(function () {
        if ($(this).attr("src").indexOf("blue") !== -1)
            value = $(this).parent().find("label")[0].innerHTML;
    });
    if (value !== "出售") {
        $("#divZJ").css("display", "block");
        $("#divSJ").css("display", "none");
    } else {
        $("#divZJ").css("display", "none");
        $("#divSJ").css("display", "block");
    }
    return value;
}
//加载房产_写字楼基本信息
function LoadFC_CWJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC/LoadFC_CWJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.FC_CWJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.FC_CWJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.FC_CWJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.FC_CWJBXX.GQ);
                $("#spanKZCGS").html(xml.Value.FC_CWJBXX.KZCGS);
                $("#spanQY").html(xml.Value.FC_CWJBXX.QY);
                $("#spanDD").html(xml.Value.FC_CWJBXX.DD);
                $("#spanZJDW").html(xml.Value.FC_CWJBXX.ZJDW);
                LoadPhotos(xml.Value.Photos);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//发布
function FB() {
    if (ValidateAll() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "KZCGS", "'" + $("#spanKZCGS").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "ZJDW", "'" + $("#spanZJDW").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC/FBFC_CWJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            BCMS: ue.getContent(),
            FWZP: GetPhotoUrls()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.location.href = getRootPath() + "/Business/FBCG/FBCG";
            } else {

            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}