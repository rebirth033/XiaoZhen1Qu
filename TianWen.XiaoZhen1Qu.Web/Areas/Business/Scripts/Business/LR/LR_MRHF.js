﻿$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadDuoX("美容护肤", "MRHFLB");
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
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
            TBName: "CODES_LR"
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
                    $("#div" + id).css("height", parseInt(xml.list.length / 6) * 45 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 6) + 1) * 45 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liMRHFLB").bind("click", function () { ValidateCheck("MRHFLB", "忘记选择类别啦"); });
                LoadLR_MRHFJBXX();
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
//加载休闲娱乐_美容护肤基本信息
function LoadLR_MRHFJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LR_MRHF/LoadLR_MRHFJBXX",
        dataType: "json",
        data:
        {
            LR_MRHFJBXXID: getUrlParam("LR_MRHFJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.LR_MRHFJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#LR_MRHFJBXXID").val(xml.Value.LR_MRHFJBXX.LR_MRHFJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.LR_MRHFJBXX.LB !== null)
                    SetDuoX("MRHFLB", xml.Value.LR_MRHFJBXX.LB);
                $("#spanQY").html(xml.Value.LR_MRHFJBXX.QY);
                $("#spanDD").html(xml.Value.LR_MRHFJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDuoX("MRHFLB") + "'");

    if (getUrlParam("LR_MRHFJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "LR_MRHFJBXXID", "'" + getUrlParam("LR_MRHFJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LR_MRHF/FB",
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