﻿$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadSHFW_CLFW_QCPLJBXX();
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
//加载生活服务_汽车陪练基本信息
function LoadSHFW_CLFW_QCPLJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_CLFW_QCPL/LoadSHFW_CLFW_QCPLJBXX",
        dataType: "json",
        data:
        {
            SHFW_CLFW_QCPLJBXXID: getUrlParam("SHFW_CLFW_QCPLJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SHFW_CLFW_QCPLJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SHFW_CLFW_QCPLJBXXID").val(xml.Value.SHFW_CLFW_QCPLJBXX.SHFW_CLFW_QCPLJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanQY").html(xml.Value.SHFW_CLFW_QCPLJBXX.QY);
                $("#spanDD").html(xml.Value.SHFW_CLFW_QCPLJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");

    if (getUrlParam("SHFW_CLFW_QCPLJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SHFW_CLFW_QCPLJBXXID", "'" + getUrlParam("SHFW_CLFW_QCPLJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_CLFW_QCPL/FB",
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