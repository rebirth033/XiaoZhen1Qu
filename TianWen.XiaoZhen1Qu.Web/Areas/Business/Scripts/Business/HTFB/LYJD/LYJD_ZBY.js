﻿var fwjs = UE.getEditor('BCMS');
$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    BindClick("QY");
    BindClick("DD");
    BindClick("XCTS_R");
    LoadDuoX("游玩项目", "YWXM");
});
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
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
                    if (i % 6 === 5) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 6) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 6) * 50 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 6) + 1) * 50 + "px");
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
                    LoadLYJD_ZBYJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
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
//加载旅游酒店_周边游基本信息
function LoadLYJD_ZBYJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LYJD/LoadLYJD_ZBYJBXX",
        dataType: "json",
        data:
        {
            LYJD_ZBYJBXXID: getUrlParam("LYJD_ZBYJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.LYJD_ZBYJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#LYJD_ZBYJBXXID").val(xml.Value.LYJD_ZBYJBXX.LYJD_ZBYJBXXID);
                //设置编辑器的内容
                fwjs.ready(function () { fwjs.setContent(xml.Value.LYJD_ZBYJBXX.FWJS); });
                $("#spanXCTS_R").html(xml.Value.LYJD_ZBYJBXX.XCTS_R);
                $("#spanQY").html(xml.Value.LYJD_ZBYJBXX.QY);
                $("#spanDD").html(xml.Value.LYJD_ZBYJBXX.DD);
                LoadPhotos(xml.Value.Photos);
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
    obj = jsonObj.AddJson(obj, "XCTS_R", "'" + $("#spanXCTS_R").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "CYFS", "'" + GetDX("CYFS") + "'");
    obj = jsonObj.AddJson(obj, "YWXM", "'" + GetDuoX("YWXM") + "'");
    obj = jsonObj.AddJson(obj, "SHRQ", "'" + GetDuoX("SHRQ") + "'");

    if (getUrlParam("LYJD_ZBYJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "LYJD_ZBYJBXXID", "'" + getUrlParam("LYJD_ZBYJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LYJD/FBLYJD_ZBYJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            FWJS: fwjs.getContent(),
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