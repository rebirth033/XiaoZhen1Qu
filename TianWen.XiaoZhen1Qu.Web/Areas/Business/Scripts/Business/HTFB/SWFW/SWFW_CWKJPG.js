﻿$(document).ready(function () {
    LoadCWKJPGLB();
});
//加载财务会计/评估类别
function LoadCWKJPGLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "财务会计/评估类别",
            TBName: "CODES_SWFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liCWKJPGLB' onclick='SelectDuoX(this)'><img class='img_CWKJPGLB'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 4 === 3) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 183px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divCWKJPGLB").css("height", parseInt(xml.list.length / 4) * 60 + "px");
                else
                    $("#divCWKJPGLB").css("height", (parseInt(xml.list.length / 4) + 1) * 60 + "px");
                html += "</ul>";
                $("#divCWKJPGLBText").html(html);
                $(".img_CWKJPGLB").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liCWKJPGLB").bind("click", function () { ValidateCheck("CWKJPGLB", "忘记选择类别啦"); });
                LoadFWFW();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载商务服务_财务会计/评估基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/SWFW/LoadSWFW_CWKJPGJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SWFW_CWKJPGJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.SWFW_CWKJPGJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                SetDuoX("CWKJPGLB", xml.Value.SWFW_CWKJPGJBXX.LB);
                SetDX("SFSM", xml.Value.SWFW_CWKJPGJBXX.SFSM);
                if (xml.Value.SWFW_CWKJPGJBXX.FWFW !== null)
                    SetDuoX("FWFW", xml.Value.SWFW_CWKJPGJBXX.FWFW);
                $("#spanQY").html(xml.Value.SWFW_CWKJPGJBXX.QY);
                $("#spanDD").html(xml.Value.SWFW_CWKJPGJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDuoX("CWKJPGLB") + "'");
    obj = jsonObj.AddJson(obj, "SFSM", "'" + GetDX("SFSM") + "'");
    obj = jsonObj.AddJson(obj, "FWFW", "'" + GetDuoX("FWFW") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/SWFW/FBSWFW_CWKJPGJBXX",
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