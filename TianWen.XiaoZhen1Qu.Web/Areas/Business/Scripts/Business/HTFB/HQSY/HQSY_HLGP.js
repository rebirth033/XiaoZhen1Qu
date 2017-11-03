﻿$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    BindClick("GPLX");
    BindClick("QY");
    BindClick("DD");
    LoadHQSY_HLGPJBXX();
});
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "GPLX") {
            LoadCODESByTYPENAME("跟拍类型", "GPLX", "CODES_HQSY", Bind, "HLGPGPLX", "GPLX", "");
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
}
//加载婚庆摄影_婚礼跟拍基本信息
function LoadHQSY_HLGPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY/LoadHQSY_HLGPJBXX",
        dataType: "json",
        data:
        {
            HQSY_HLGPJBXXID: getUrlParam("HQSY_HLGPJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.HQSY_HLGPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#HQSY_HLGPJBXXID").val(xml.Value.HQSY_HLGPJBXX.HQSY_HLGPJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanGPLX").html(xml.Value.HQSY_HLGPJBXX.GPLX);
                $("#spanQY").html(xml.Value.HQSY_HLGPJBXX.QY);
                $("#spanDD").html(xml.Value.HQSY_HLGPJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "GPLX", "'" + $("#spanGPLX").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");

    if (getUrlParam("HQSY_HLGPJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "HQSY_HLGPJBXXID", "'" + getUrlParam("HQSY_HLGPJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY/FBHQSY_HLGPJBXX",
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