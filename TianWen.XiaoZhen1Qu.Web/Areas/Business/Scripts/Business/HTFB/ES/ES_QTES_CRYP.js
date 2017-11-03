﻿$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadES_QTES_CRYPJBXX();
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
});

//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    BindClick("XL");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("成人用品", "LB", "CODES_ES_QTES", Bind, "CRYPLB", "LB", "");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_QTES", Bind, "CRYPLB", "XL", "");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//选择成人用品品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载二手_手机数码_成人用品基本信息
function LoadES_QTES_CRYPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/LoadES_QTES_CRYPJBXX",
        dataType: "json",
        data:
        {
            ES_QTES_CRYPJBXXID: getUrlParam("ES_QTES_CRYPJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_QTES_CRYPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_QTES_CRYPJBXXID").val(xml.Value.ES_QTES_CRYPJBXX.ES_QTES_CRYPJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.ES_QTES_CRYPJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_QTES_CRYPJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_QTES_CRYPJBXX.LB);
                $("#spanQY").html(xml.Value.ES_QTES_CRYPJBXX.QY);
                $("#spanDD").html(xml.Value.ES_QTES_CRYPJBXX.DD);
                $("#spanXL").html(xml.Value.ES_QTES_CRYPJBXX.XL);
                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_QTES_CRYPJBXX.LB);
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
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if (getUrlParam("ES_QTES_CRYPJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_QTES_CRYPJBXXID", "'" + getUrlParam("ES_QTES_CRYPJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/FBES_QTES_CRYPJBXX",
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