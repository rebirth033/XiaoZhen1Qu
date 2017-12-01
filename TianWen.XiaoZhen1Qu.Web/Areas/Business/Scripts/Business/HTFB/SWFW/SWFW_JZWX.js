﻿$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadJZWXLB();
});
//加载建筑维修类别
function LoadJZWXLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "建筑维修",
            TBName: "CODES_SWFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liJZWXLB' style='width:140px;' onclick='SelectDuoX(this)'><img class='img_JZWXLB'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 4 === 3) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divJZWXLB").css("height", parseInt(xml.list.length / 4) * 50 + "px");
                else
                    $("#divJZWXLB").css("height", (parseInt(xml.list.length / 4) + 1) * 50 + "px");
                html += "</ul>";
                $("#divJZWXLBText").html(html);
                $(".img_JZWXLB").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liJZWXLB").bind("click", function () { ValidateCheck("JZWXLB", "忘记选择类别啦"); });
                LoadSWFW_JZWXJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        
    });
}
//加载商务服务_建筑维修基本信息
function LoadSWFW_JZWXJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW/LoadSWFW_JZWXJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SWFW_JZWXJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.SWFW_JZWXJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                SetDuoX("JZWXLB", xml.Value.SWFW_JZWXJBXX.LB);
                $("#spanQY").html(xml.Value.SWFW_JZWXJBXX.QY);
                $("#spanDD").html(xml.Value.SWFW_JZWXJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDuoX("JZWXLB") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW/FBSWFW_JZWXJBXX",
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