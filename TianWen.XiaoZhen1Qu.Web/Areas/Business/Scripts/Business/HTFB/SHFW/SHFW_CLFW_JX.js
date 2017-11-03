﻿$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    BindClick("QY");
    BindClick("DD");
    LoadJZ();
});
//加载驾照
function LoadJZ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "驾照",
            TBName: "CODES_SHFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liJZ' style='width:220px;' onclick='SelectDuoX(this)'><img class='img_JZ'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 3 === 2) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 3) === 0)
                    $("#divJZ").css("height", parseInt(xml.list.length / 3) * 50 + "px");
                else
                    $("#divJZ").css("height", (parseInt(xml.list.length / 3) + 1) * 50 + "px");
                html += "</ul>";
                $("#divJZText").html(html);
                $(".img_JZ").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liJZ").bind("click", function () { ValidateCheck("JZ", "忘记选择驾照啦"); });
                $(".liJZ:last").css("width", "300px");
                LoadBB();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载班别
function LoadBB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "班别",
            TBName: "CODES_SHFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liBB' style='width:150px;' onclick='SelectDuoX(this)'><img class='img_BB'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 4 === 3) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divBB").css("height", parseInt(xml.list.length / 4) * 60 + "px");
                else
                    $("#divBB").css("height", (parseInt(xml.list.length / 4) + 1) * 60 + "px");
                html += "</ul>";
                $("#divBBText").html(html);
                $(".img_BB").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liBB").bind("click", function () { ValidateCheck("BB", "忘记选择班别啦"); });
                LoadSHFW_CLFW_JXJBXX();
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
//加载生活服务_驾校基本信息
function LoadSHFW_CLFW_JXJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW/LoadSHFW_CLFW_JXJBXX",
        dataType: "json",
        data:
        {
            SHFW_CLFW_JXJBXXID: getUrlParam("SHFW_CLFW_JXJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SHFW_CLFW_JXJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SHFW_CLFW_JXJBXXID").val(xml.Value.SHFW_CLFW_JXJBXX.SHFW_CLFW_JXJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanQY").html(xml.Value.SHFW_CLFW_JXJBXX.QY);
                $("#spanDD").html(xml.Value.SHFW_CLFW_JXJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                SetDX("OUTLB", xml.Value.SHFW_CLFW_JXJBXX.LB);
                SetDuoX("JZ", xml.Value.SHFW_CLFW_JXJBXX.JZ);
                SetDuoX("BB", xml.Value.SHFW_CLFW_JXJBXX.BB);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDX("OUTLB") + "'");
    obj = jsonObj.AddJson(obj, "JZ", "'" + GetDuoX("JZ") + "'");
    obj = jsonObj.AddJson(obj, "BB", "'" + GetDuoX("BB") + "'");

    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("SHFW_CLFW_JXJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SHFW_CLFW_JXJBXXID", "'" + getUrlParam("SHFW_CLFW_JXJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW/FBSHFW_CLFW_JXJBXX",
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