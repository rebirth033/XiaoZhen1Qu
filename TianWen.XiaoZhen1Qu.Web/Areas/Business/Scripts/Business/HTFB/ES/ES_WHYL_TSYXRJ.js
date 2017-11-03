﻿$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ");});
    LoadES_WHYL_TSYXRJJBXX();
    BindClick("LB");
    BindClick("XJ");
    BindClick("QY");
    BindClick("DD");
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("图书/音像/软件", "LB", "CODES_ES_WHYL", Bind, "TSYXRJLB", "LB", "");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_WHYL", Bind, "TSYXRJLB", "XL", "");
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM", Bind, "XJCD", "XJ", "");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    BindClick("XL");
}
//选择图书/音像/软件品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载二手_手机数码_图书/音像/软件基本信息
function LoadES_WHYL_TSYXRJJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/LoadES_WHYL_TSYXRJJBXX",
        dataType: "json",
        data:
        {
            ES_WHYL_TSYXRJJBXXID: getUrlParam("ES_WHYL_TSYXRJJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_WHYL_TSYXRJJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_WHYL_TSYXRJJBXXID").val(xml.Value.ES_WHYL_TSYXRJJBXX.ES_WHYL_TSYXRJJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.ES_WHYL_TSYXRJJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_WHYL_TSYXRJJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_WHYL_TSYXRJJBXX.LB);
                $("#spanXL").html(xml.Value.ES_WHYL_TSYXRJJBXX.XL);
                $("#spanXJ").html(xml.Value.ES_WHYL_TSYXRJJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_WHYL_TSYXRJJBXX.QY);
                $("#spanDD").html(xml.Value.ES_WHYL_TSYXRJJBXX.DD);

                LoadPhotos(xml.Value.Photos);                
                return;
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
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if (getUrlParam("ES_WHYL_TSYXRJJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_WHYL_TSYXRJJBXXID", "'" + getUrlParam("ES_WHYL_TSYXRJJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/FBES_WHYL_TSYXRJJBXX",
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