﻿var bcms = UE.getEditor('BCMS');
$(document).ready(function () {
    //BindClick("XCTS_R");
    LoadDuoX("游玩项目", "YWXM");
});
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: type,
            TBName: "CODES_LYJD"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                   if (i % 5 === 4 && i != xml.list.length - 1) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 174px'>";
                    }
                }
                if (parseInt(xml.list.length % 5) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 5) * 40 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 5) + 1) * 40 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".li" + id).bind("click", function () { ValidateCheck(id, "忘记选择" + type + "啦"); });
                if (xml.list.length === 0)
                    $("#div" + id).css("display", "none");
                else
                    $("#div" + id).css("display", "");
                if (type === "游玩项目")
                    LoadDuoX("适合人群", "SHRQ");
                if (type === "适合人群")
                    LoadJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载旅游酒店_周边游基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/LYJD/LoadLYJD_ZBYJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.LYJD_ZBYJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.LYJD_ZBYJBXX.ID);
                //设置编辑器的内容
                bcms.ready(function () { bcms.setContent(xml.Value.BCMSString); });
                $("#spanQY").html(xml.Value.LYJD_ZBYJBXX.QY);
                $("#spanDD").html(xml.Value.LYJD_ZBYJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.LYJD_ZBYJBXX.XCTS_R !== null)
                    SetDX("XCTS", xml.Value.LYJD_ZBYJBXX.XCTS_R);
                if (xml.Value.LYJD_ZBYJBXX.CYFS !== null)
                    SetDX("CYFS", xml.Value.LYJD_ZBYJBXX.CYFS);
                if (xml.Value.LYJD_ZBYJBXX.YWXM !== null)
                    SetDuoX("YWXM", xml.Value.LYJD_ZBYJBXX.YWXM);
                if (xml.Value.LYJD_ZBYJBXX.SHRQ !== null)
                    SetDuoX("SHRQ", xml.Value.LYJD_ZBYJBXX.SHRQ);
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
    obj = jsonObj.AddJson(obj, "XCTS_R", "'" + GetDX("XCTS") + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "CYFS", "'" + GetDX("CYFS") + "'");
    obj = jsonObj.AddJson(obj, "YWXM", "'" + GetDuoX("YWXM") + "'");
    obj = jsonObj.AddJson(obj, "SHRQ", "'" + GetDuoX("SHRQ") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/LYJD/FBLYJD_ZBYJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            BCMS: bcms.getContent(),
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