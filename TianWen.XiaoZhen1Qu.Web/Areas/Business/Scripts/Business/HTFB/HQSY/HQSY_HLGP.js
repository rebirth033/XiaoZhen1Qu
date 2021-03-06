﻿$(document).ready(function () {
    BindClick("GPLX");
    LoadFWFW();
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "GPLX") {
            LoadCODESByTYPENAME("婚礼跟拍类型", "GPLX", "CODES_HQSY", Bind, "HLGPGPLX", "GPLX", "");
        }
        if (type === "XL") {
            LoadXL();
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
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/HQSY/LoadHQSY_HLGPJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.HQSY_HLGPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.HQSY_HLGPJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanGPLX").html(xml.Value.HQSY_HLGPJBXX.GPLX);
                $("#spanQY").html(xml.Value.HQSY_HLGPJBXX.QY);
                $("#spanDD").html(xml.Value.HQSY_HLGPJBXX.DD);
                if (xml.Value.HQSY_HLGPJBXX.FWFW !== null)
                    SetDuoX("FWFW", xml.Value.HQSY_HLGPJBXX.FWFW);
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
    obj = jsonObj.AddJson(obj, "FWFW", "'" + GetDuoX("FWFW") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/HQSY/FBHQSY_HLGPJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            BCMS: ue.getContent(),
            FWZP: GetPhotoUrls()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.location.href = getRootPath() + "/FBCG/FBCG?LBID=" + getUrlParam("CLICKID") + "&ID=" + xml.Value.ID + "&JCXXID=" + xml.Value.JCXXID;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}