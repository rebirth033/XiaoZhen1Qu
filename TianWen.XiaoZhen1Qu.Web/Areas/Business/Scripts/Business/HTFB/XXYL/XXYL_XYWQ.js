﻿$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadXXYL_XYWQJBXX();
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("洗浴温泉", "LB", "CODES_XXYL", Bind, "XYWQLB", "LB", "");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载休闲娱乐_户外基本信息
function LoadXXYL_XYWQJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/XXYL/LoadXXYL_XYWQJBXX",
        dataType: "json",
        data:
        {
            XXYL_XYWQJBXXID: getUrlParam("XXYL_XYWQJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.XXYL_XYWQJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#XXYL_XYWQJBXXID").val(xml.Value.XXYL_XYWQJBXX.XXYL_XYWQJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.XXYL_XYWQJBXX.LB);
                $("#spanQY").html(xml.Value.XXYL_XYWQJBXX.QY);
                $("#spanDD").html(xml.Value.XXYL_XYWQJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");

    if (getUrlParam("XXYL_XYWQJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "XXYL_XYWQJBXXID", "'" + getUrlParam("XXYL_XYWQJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/XXYL/FBXXYL_XYWQJBXX",
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