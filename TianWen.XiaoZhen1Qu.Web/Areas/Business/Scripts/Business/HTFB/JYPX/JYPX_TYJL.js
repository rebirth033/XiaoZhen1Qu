﻿$(document).ready(function () {
    BindClick("JXKM");
    LoadJBXX();
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "JXKM") {
            LoadCODESByTYPENAME("体育培训类别", "JXKM", "CODES_JYPX", Bind, "TYJLJXKM", "JXKM", "");
        }
    });
}
//加载教育培训_体育教练基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/JYPX/LoadJYPX_TYJLJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JYPX_TYJLJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.JYPX_TYJLJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanJXKM").html(xml.Value.JYPX_TYJLJBXX.JXKM);
                $("#spanQY").html(xml.Value.JYPX_TYJLJBXX.QY);
                $("#spanDD").html(xml.Value.JYPX_TYJLJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                SetDX("SF", xml.Value.JYPX_TYJLJBXX.SF);
                SetDX("JJJY", xml.Value.JYPX_TYJLJBXX.JJJY);
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
    obj = jsonObj.AddJson(obj, "JXKM", "'" + $("#spanJXKM").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("SF") + "'");
    obj = jsonObj.AddJson(obj, "JJJY", "'" + GetDX("JJJY") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/JYPX/FBJYPX_TYJLJBXX",
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