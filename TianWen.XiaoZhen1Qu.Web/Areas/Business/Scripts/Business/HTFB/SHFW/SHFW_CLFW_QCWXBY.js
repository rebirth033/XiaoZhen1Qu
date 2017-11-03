﻿$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadSHFW_CLFW_QCWXBYJBXX();
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("汽车维修/保养", "LB", "CODES_SHFW", Bind, "OUTLB", "LB", "");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载生活服务_汽车维修/保养基本信息
function LoadSHFW_CLFW_QCWXBYJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW/LoadSHFW_CLFW_QCWXBYJBXX",
        dataType: "json",
        data:
        {
            SHFW_CLFW_QCWXBYJBXXID: getUrlParam("SHFW_CLFW_QCWXBYJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SHFW_CLFW_QCWXBYJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SHFW_CLFW_QCWXBYJBXXID").val(xml.Value.SHFW_CLFW_QCWXBYJBXX.SHFW_CLFW_QCWXBYJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanQY").html(xml.Value.SHFW_CLFW_QCWXBYJBXX.QY);
                $("#spanDD").html(xml.Value.SHFW_CLFW_QCWXBYJBXX.DD);
                $("#spanLB").html(xml.Value.SHFW_CLFW_QCWXBYJBXX.LB);
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
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");

    if (getUrlParam("SHFW_CLFW_QCWXBYJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SHFW_CLFW_QCWXBYJBXXID", "'" + getUrlParam("SHFW_CLFW_QCWXBYJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW/FBSHFW_CLFW_QCWXBYJBXX",
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