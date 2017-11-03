﻿$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ");});
    LoadES_SJSM_PBDNJBXX();
    BindClick("LB");
    BindClick("PBPP");
    BindClick("PBXH");
    BindClick("XL");
    BindClick("XJ");
    BindClick("QY");
    BindClick("SQ");
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("平板类别", "LB", "CODES_ES_SJSM", Bind, "PBLB", "LB", "");
        }
        if (type === "PBPP") {
            LoadCODESByTYPENAME("平板品牌", "PBPP", "CODES_ES_SJSM", Bind, "PBLB", "PBPP", "");
        }
        if (type === "PBXH") {
            LoadPBXH();
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM", Bind, "XJCD", "XJ", "");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME("平板电脑配件", "XL", "CODES_ES_SJSM", Bind, "PBLB", "XL", "");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载平板型号
function LoadPBXH() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: $("#PPID").val(),
            TBName: "CODES_ES_SJSM"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ul_select' style='overflow-y: scroll;height:340px;width:200px'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectDropdown(this,\"PBXH\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divPBXH").html(html);
                $("#divPBXH").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择类别下拉框
function SelectLB(obj, type, id) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#PPID").val(id);
    PDLB(obj.innerHTML);
}
//判断类别
function PDLB(LB) {
    if (LB.indexOf("配件") !== -1) {
        $("#divXLText").css("display", "");
        $("#divPBPPText").css("display", "none");
        $("#divPBXHText").css("display", "none");
        $("#divPBXXCS").css("display", "none");
        $("#divPBXXCS_2").css("display", "none");
    } else {
        $("#divXLText").css("display", "none");
        $("#divPBPPText").css("display", "");
        $("#divPBXHText").css("display", "");
        $("#divPBXXCS").css("display", "");
        $("#divPBXXCS_2").css("display", "");
    }
}
//选择平板品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#PPID").val(code);
}
//加载二手_手机数码_平板基本信息
function LoadES_SJSM_PBDNJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/LoadES_SJSM_PBDNJBXX",
        dataType: "json",
        data:
        {
            ES_SJSM_PBDNJBXXID: getUrlParam("ES_SJSM_PBDNJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_SJSM_PBDNJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_SJSM_PBDNJBXXID").val(xml.Value.ES_SJSM_PBDNJBXX.ES_SJSM_PBDNJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.ES_SJSM_PBDNJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_SJSM_PBDNJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_SJSM_PBDNJBXX.LB);
                $("#spanPBPP").html(xml.Value.ES_SJSM_PBDNJBXX.PBPP);
                $("#spanPBXH").html(xml.Value.ES_SJSM_PBDNJBXX.PBXH);
                $("#spanXL").html(xml.Value.ES_SJSM_PBDNJBXX.XL);
                $("#spanXJ").html(xml.Value.ES_SJSM_PBDNJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_SJSM_PBDNJBXX.QY);
                $("#spanDD").html(xml.Value.ES_SJSM_PBDNJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_SJSM_PBDNJBXX.LB);
                
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
    obj = jsonObj.AddJson(obj, "PBPP", "'" + $("#spanPBPP").html() + "'");
    obj = jsonObj.AddJson(obj, "PBXH", "'" + $("#spanPBXH").html() + "'");
    obj = jsonObj.AddJson(obj, "XJ", "'" + $("#spanXJ").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if (getUrlParam("ES_SJSM_PBDNJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_SJSM_PBDNJBXXID", "'" + getUrlParam("ES_SJSM_PBDNJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/FBES_SJSM_PBDNJBXX",
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