﻿$(document).ready(function () {
    $("body").bind("click", function() { Close("_XZQ"); });
    LoadSHFW_SHFW_KSHSXSJBXX();
    BindClick("QY");
    BindClick("DD");
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载生活服务_开锁/换锁/修锁基本信息
function LoadSHFW_SHFW_KSHSXSJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_SHFW_KSHSXS/LoadSHFW_SHFW_KSHSXSJBXX",
        dataType: "json",
        data:
        {
            SHFW_SHFW_KSHSXSJBXXID: getUrlParam("SHFW_SHFW_KSHSXSJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SHFW_SHFW_KSHSXSJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SHFW_SHFW_KSHSXSJBXXID").val(xml.Value.SHFW_SHFW_KSHSXSJBXX.SHFW_SHFW_KSHSXSJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanQY").html(xml.Value.SHFW_SHFW_KSHSXSJBXX.QY);
                $("#spanDD").html(xml.Value.SHFW_SHFW_KSHSXSJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("SHFW_SHFW_KSHSXSJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SHFW_SHFW_KSHSXSJBXXID", "'" + getUrlParam("SHFW_SHFW_KSHSXSJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_SHFW_KSHSXS/FB",
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