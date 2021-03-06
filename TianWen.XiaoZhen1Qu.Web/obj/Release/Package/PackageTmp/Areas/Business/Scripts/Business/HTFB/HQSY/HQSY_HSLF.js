﻿$(document).ready(function () {
    BindClick("YS");
    BindClick("LX");
    BindClick("CZ");
    LoadJBXX();
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "YS") {
            LoadCODESByTYPENAME("婚纱礼服颜色", "YS", "CODES_HQSY", Bind, "HSLFYS", "YS", "");
        }
        if (type === "LX") {
            LoadCODESByTYPENAME("婚纱礼服类型", "LX", "CODES_HQSY", Bind, "HSLFLX", "LX", "");
        }
        if (type === "CZ") {
            LoadCODESByTYPENAME("婚纱礼服材质", "CZ", "CODES_HQSY", Bind, "HSLFCZ", "CZ", "");
        }
    });
}
//选择类别下拉框
function SelectLB(obj, type, lbid) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#LBID").val(lbid);
}
//加载婚庆摄影_婚纱礼服基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/HQSY/LoadHQSY_HSLFJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.HQSY_HSLFJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.HQSY_HSLFJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanYS").html(xml.Value.HQSY_HSLFJBXX.YS);
                $("#spanLX").html(xml.Value.HQSY_HSLFJBXX.LX);
                $("#spanCZ").html(xml.Value.HQSY_HSLFJBXX.CZ);
                $("#spanQY").html(xml.Value.HQSY_HSLFJBXX.QY);
                $("#spanDD").html(xml.Value.HQSY_HSLFJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.HQSY_HSLFJBXX.FG !== null)
                    SetDX("FG", xml.Value.HQSY_HSLFJBXX.FG);
                if (xml.Value.HQSY_HSLFJBXX.KS !== null)
                    SetDX("KS", xml.Value.HQSY_HSLFJBXX.KS);
                if (xml.Value.HQSY_HSLFJBXX.FWFW !== null)
                    SetDuoX("FWFW", xml.Value.HQSY_HSLFJBXX.FWFW);
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
    obj = jsonObj.AddJson(obj, "YS", "'" + $("#spanYS").html() + "'");
    obj = jsonObj.AddJson(obj, "LX", "'" + $("#spanLX").html() + "'");
    obj = jsonObj.AddJson(obj, "CZ", "'" + $("#spanCZ").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "FG", "'" + GetDX("FG") + "'");
    obj = jsonObj.AddJson(obj, "KS", "'" + GetDX("KS") + "'");
    obj = jsonObj.AddJson(obj, "FWFW", "'" + GetDuoX("FWFW") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/HQSY/FBHQSY_HSLFJBXX",
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