﻿$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadDuoX("商超设备", "SCSBLB");
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
            TBName: "CODES_PFCG"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 4 === 3) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 4) * 45 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 4) + 1) * 45 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liSCSBLB").bind("click", function () { ValidateCheck("SCSBLB", "忘记选择商超设备啦"); });
                LoadPFCG_SCSBJBXX();
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
//加载休闲娱乐_商超设备基本信息
function LoadPFCG_SCSBJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PFCG/LoadPFCG_SCSBJBXX",
        dataType: "json",
        data:
        {
            PFCG_SCSBJBXXID: getUrlParam("PFCG_SCSBJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.PFCG_SCSBJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#PFCG_SCSBJBXXID").val(xml.Value.PFCG_SCSBJBXX.PFCG_SCSBJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                SetDuoX("SCSBLB", xml.Value.PFCG_SCSBJBXX.LB);
                $("#spanQY").html(xml.Value.PFCG_SCSBJBXX.QY);
                $("#spanDD").html(xml.Value.PFCG_SCSBJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDuoX("SCSBLB") + "'");

    if (getUrlParam("PFCG_SCSBJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "PFCG_SCSBJBXXID", "'" + getUrlParam("PFCG_SCSBJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PFCG/FBPFCG_SCSBJBXX",
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