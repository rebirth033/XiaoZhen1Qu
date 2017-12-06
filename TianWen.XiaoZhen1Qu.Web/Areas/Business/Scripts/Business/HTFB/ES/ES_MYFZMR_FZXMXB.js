﻿$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ");});
    LoadES_MYFZMR_FZXMXBJBXX();
    BindClick("LB");
    BindClick("XJ");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("服装/鞋帽/箱包类别", "LB", "CODES_ES_MYFZMR", Bind, "FZXMXBLB", "LB", "");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_MYFZMR", Bind, "FZXMXBLB", "XL", "");
        }
        if (type === "FZCC") {
            LoadCODESByTYPENAME("服装尺寸", "FZCC", "CODES_ES_MYFZMR");
        }
        if (type === "XCC") {
            LoadCODESByTYPENAME("鞋尺寸", "XCC", "CODES_ES_MYFZMR");
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM", Bind, "XJCD", "XJ", "");
        }
        
    });
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    if(type === "LB")
    PDLB(obj.innerHTML);
}
//判断类别
function PDLB(LB) {
    if (LB === "服装") {
        $("#divFZXXCS").css("display", "");
        $("#divXXXCS").css("display", "none");
        BindClick("FZCC");
    }
    else if (LB === "鞋") {
        $("#divFZXXCS").css("display", "none");
        $("#divXXXCS").css("display", "");
        BindClick("XCC");
    }
    else {
        $("#divFZXXCS").css("display", "none");
        $("#divXXXCS").css("display", "none");
    }
    BindClick("XL");
}
//选择母婴/服装/美容品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载二手_手机数码_母婴/服装/美容基本信息
function LoadES_MYFZMR_FZXMXBJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/LoadES_MYFZMR_FZXMXBJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_MYFZMR_FZXMXBJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.ES_MYFZMR_FZXMXBJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.ES_MYFZMR_FZXMXBJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_MYFZMR_FZXMXBJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.LB);
                $("#spanXJ").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.QY);
                $("#spanDD").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.DD);
                $("#spanXL").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.XL);
                $("#spanXCC").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.XCC);
                $("#spanFZCC").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.FZCC);

                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_MYFZMR_FZXMXBJBXX.LB);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "XJ", "'" + $("#spanXJ").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "XCC", "'" + $("#spanXCC").html() + "'");
    obj = jsonObj.AddJson(obj, "FZCC", "'" + $("#spanFZCC").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");


    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/FBES_MYFZMR_FZXMXBJBXX",
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
