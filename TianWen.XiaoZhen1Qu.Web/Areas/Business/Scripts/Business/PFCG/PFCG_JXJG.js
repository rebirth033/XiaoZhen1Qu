﻿$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadPFCG_JXJGJBXX();
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
});
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("机械加工", "LB", "CODES_PFCG", Bind, "OUTLB", "LB", "");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载批发采购_机械加工基本信息
function LoadPFCG_JXJGJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PFCG_JXJG/LoadPFCG_JXJGJBXX",
        dataType: "json",
        data:
        {
            PFCG_JXJGJBXXID: getUrlParam("PFCG_JXJGJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.PFCG_JXJGJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#PFCG_JXJGJBXXID").val(xml.Value.PFCG_JXJGJBXX.PFCG_JXJGJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.PFCG_JXJGJBXX.LB);
                $("#spanQY").html(xml.Value.PFCG_JXJGJBXX.QY);
                $("#spanDD").html(xml.Value.PFCG_JXJGJBXX.DD);
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

    if (getUrlParam("PFCG_JXJGJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "PFCG_JXJGJBXXID", "'" + getUrlParam("PFCG_JXJGJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PFCG_JXJG/FB",
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