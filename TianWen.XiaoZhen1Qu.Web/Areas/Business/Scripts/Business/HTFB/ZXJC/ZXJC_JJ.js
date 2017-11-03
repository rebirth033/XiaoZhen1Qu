﻿$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadZXJC_JJJBXX();
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
});
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("家具", "LB", "CODES_ZXJC", Bind, "OUTLB", "LB", "");
        }
        if (type === "XL") {
            LoadXL();
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
function SelectLB(obj, type, lbid) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#LBID").val(lbid);
    PDLB(obj.innerHTML);
}
//判断类别
function PDLB(lbmc) {
    if (lbmc !== "床" && lbmc !== "床垫" && lbmc !== "沙发") {
        $("#spanXL").html("请选择小类");
        $("#divXLText").css("display", "");
        $("#divXL").css("display", "none");
        BindClick("XL");
    }
    else {
        $("#divXLText").css("display", "none");
    }
}
//加载小类
function LoadXL(type) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: $("#LBID").val(),
            TBName: "CODES_ZXJC"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var height = 341;
                if (xml.list.length < 10)
                    height = parseInt(xml.list.length * 34) + 1;
                var html = "<ul class='ul_select' style='overflow-y: scroll; height:" + height + "px'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectDropdown(this,\"XL\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divXL").html(html);
                $("#divXL").css("display", "block");
                Bind("OUTLB", "XL", "");
                ActiveStyle("XL");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载装修家具_家具基本信息
function LoadZXJC_JJJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ZXJC/LoadZXJC_JJJBXX",
        dataType: "json",
        data:
        {
            ZXJC_JJJBXXID: getUrlParam("ZXJC_JJJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ZXJC_JJJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ZXJC_JJJBXXID").val(xml.Value.ZXJC_JJJBXX.ZXJC_JJJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                PDLB(xml.Value.ZXJC_JJJBXX.LB);
                $("#spanLB").html(xml.Value.ZXJC_JJJBXX.LB);
                $("#spanXL").html(xml.Value.ZXJC_JJJBXX.XL);
                $("#spanQY").html(xml.Value.ZXJC_JJJBXX.QY);
                $("#spanDD").html(xml.Value.ZXJC_JJJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");

    if (getUrlParam("ZXJC_JJJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ZXJC_JJJBXXID", "'" + getUrlParam("ZXJC_JJJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ZXJC/FBZXJC_JJJBXX",
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