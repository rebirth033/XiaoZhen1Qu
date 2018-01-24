﻿$(document).ready(function () {
    $("#divGQ").find(".div_radio").bind("click", GetGQ);
    LoadJBXX();
    BindClick("YFFS");
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
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "YFFS") {
            LoadCODESByTYPENAME("押付方式", "YFFS", "CODES_FC", Bind, "ZJ", "YFFS", "");
        }
    });
}
//设置供求
function SetGQ(gq) {
    if (gq !== "出售") {
        $("#divZJ").css("display", "block");
        $("#divKZCGS").css("display", "block");
        $("#divSJ").css("display", "none");
    }
    else {
        $("#divZJ").css("display", "none");
        $("#divKZCGS").css("display", "none");
        $("#divSJ").css("display", "block");
    }
}
//获取供求
function GetGQ() {
    var value = "";
    $("#divGQ").find("img").each(function () {
        if ($(this).attr("src").indexOf("purple") !== -1)
            value = $(this).parent().find("label")[0].innerHTML;
    });
    if (value !== "出售") {
        $("#divZJ").css("display", "block");
        $("#divKZCGS").css("display", "block");
        $("#divSJ").css("display", "none");
    } else {
        $("#divZJ").css("display", "none");
        $("#divKZCGS").css("display", "none");
        $("#divSJ").css("display", "block");
    }
    return value;
}
//加载房产_写字楼基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC/LoadFC_XZLJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.FC_XZLJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.FC_XZLJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                if (xml.Value.FC_XZLJBXX.SF !== null) {
                    SetDX("SF", xml.Value.FC_XZLJBXX.SF);
                }
                if (xml.Value.FC_XZLJBXX.GQ !== null){
                    SetDX("GQ", xml.Value.FC_XZLJBXX.GQ);
                    SetGQ(xml.Value.FC_XZLJBXX.GQ);
                }
                if (xml.Value.FC_XZLJBXX.LX !== null)
                    SetDX("XZLLX", xml.Value.FC_XZLJBXX.XZLLX);
                if (xml.Value.FC_XZLJBXX.KZCGS !== null)
                    SetDX("KZCGS", xml.Value.FC_XZLJBXX.KZCGS);
                $("#spanQY").html(xml.Value.FC_XZLJBXX.QY);
                $("#spanDD").html(xml.Value.FC_XZLJBXX.DD);
                $("#spanYFFS").html(xml.Value.FC_XZLJBXX.YFFS);
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
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "YFFS", "'" + $("#spanYFFS").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("SF") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");
    if (GetDX("GQ") === "出租")
        obj = jsonObj.AddJson(obj, "ZJDW", "'元/月'");
    if (GetDX("GQ") === "出售")
        obj = jsonObj.AddJson(obj, "ZJDW", "'万元'");
    obj = jsonObj.AddJson(obj, "XZLLX", "'" + GetDX("XZLLX") + "'");
    obj = jsonObj.AddJson(obj, "KZCGS", "'" + GetDX("KZCGS") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC/FBFC_XZLJBXX",
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
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}