﻿$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadSHFW_SHFW_BMYSJBXX();
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
});
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("月嫂/保姆", "LB", "CODES_SHFW", Bind, "OUTLB", "LB", "");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载生活服务_月嫂/保姆基本信息
function LoadSHFW_SHFW_BMYSJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW/LoadSHFW_SHFW_BMYSJBXX",
        dataType: "json",
        data:
        {
            SHFW_SHFW_BMYSJBXXID: getUrlParam("SHFW_SHFW_BMYSJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SHFW_SHFW_BMYSJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SHFW_SHFW_BMYSJBXXID").val(xml.Value.SHFW_SHFW_BMYSJBXX.SHFW_SHFW_BMYSJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.SHFW_SHFW_BMYSJBXX.LB);
                $("#spanQY").html(xml.Value.SHFW_SHFW_BMYSJBXX.QY);
                $("#spanDD").html(xml.Value.SHFW_SHFW_BMYSJBXX.DD);
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

    if (getUrlParam("SHFW_SHFW_BMYSJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SHFW_SHFW_BMYSJBXXID", "'" + getUrlParam("SHFW_SHFW_BMYSJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW/FBSHFW_SHFW_BMYSJBXX",
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