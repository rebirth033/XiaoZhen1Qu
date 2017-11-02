$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadZHFS();
    BindClick("QY");
    BindClick("DD");
    BindClick("YSJGDW");
});
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "YSJGDW") {
            LoadCODESByTYPENAME("运输价格单位", "YSJGDW", "CODES_SWFW", Bind, "YSJG", "YSJGDW", "");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载组货方式
function LoadZHFS() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "组货方式",
            TBName: "CODES_SWFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liZHFS' onclick='SelectDuoX(this)'><img class='img_ZHFS'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 4 === 3) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divZHFS").css("height", parseInt(xml.list.length / 4) * 50 + "px");
                else
                    $("#divZHFS").css("height", (parseInt(xml.list.length / 4) + 1) * 50 + "px");
                html += "</ul>";
                $("#divZHFSText").html(html);
                $(".img_ZHFS").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liZHFS").bind("click", function () { ValidateCheck("ZHFS", "忘记选择组货方式啦"); });
                LoadHWZL();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载货物种类
function LoadHWZL() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "货物种类",
            TBName: "CODES_SWFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liHWZL' onclick='SelectDuoX(this)'><img class='img_HWZL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 4 === 3) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divHWZL").css("height", parseInt(xml.list.length / 4) * 50 + "px");
                else
                    $("#divHWZL").css("height", (parseInt(xml.list.length / 4) + 1) * 50 + "px");
                html += "</ul>";
                $("#divHWZLText").html(html);
                $(".img_HWZL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liHWZL").bind("click", function () { ValidateCheck("HWZL", "忘记选择货物种类啦"); });
                LoadFWYS();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载服务延伸
function LoadFWYS() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "服务延伸",
            TBName: "CODES_SWFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liFWYS' onclick='SelectDuoX(this)'><img class='img_FWYS'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 4 === 3) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divFWYS").css("height", parseInt(xml.list.length / 4) * 60 + "px");
                else
                    $("#divFWYS").css("height", (parseInt(xml.list.length / 4) + 1) * 60 + "px");
                html += "</ul>";
                $("#divFWYSText").html(html);
                $(".img_FWYS").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liFWYS").bind("click", function () { ValidateCheck("FWYS", "忘记选择服务延伸啦"); });
                LoadSWFW_HYZXJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载商务服务_货运专线基本信息
function LoadSWFW_HYZXJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW/LoadSWFW_HYZXJBXX",
        dataType: "json",
        data:
        {
            SWFW_HYZXJBXXID: getUrlParam("SWFW_HYZXJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SWFW_HYZXJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SWFW_HYZXJBXXID").val(xml.Value.SWFW_HYZXJBXX.SWFW_HYZXJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanQY").html(xml.Value.SWFW_HYZXJBXX.QY);
                $("#spanDD").html(xml.Value.SWFW_HYZXJBXX.DD);
                $("#spanYSDWJG").html(xml.Value.SWFW_HYZXJBXX.YSDWJG);
                SetDX("YSFW", xml.Value.SWFW_HYZXJBXX.YSFW);
                SetDX("HYTD", xml.Value.SWFW_HYZXJBXX.HYTD);
                SetDX("SFWF", xml.Value.SWFW_HYZXJBXX.SFWF);
                SetDX("YWZZ", xml.Value.SWFW_HYZXJBXX.YWZZ);
                SetDX("BC", xml.Value.SWFW_HYZXJBXX.BC);
                SetDuoX("ZHFS", xml.Value.SWFW_HYZXJBXX.ZHFS);
                SetDuoX("HWZL", xml.Value.SWFW_HYZXJBXX.HWZL);
                SetDuoX("FWYS", xml.Value.SWFW_HYZXJBXX.FWYS);
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
    obj = jsonObj.AddJson(obj, "BT", "'" + $("#spanQY").html() + "至" + $("#DDD").val() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "YSJGDW", "'" + $("#spanYSJGDW").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "YSFW", "'" + GetDX("YSFW") + "'");
    obj = jsonObj.AddJson(obj, "HYTD", "'" + GetDX("HYTD") + "'");
    obj = jsonObj.AddJson(obj, "SFWF", "'" + GetDX("SFWF") + "'");
    obj = jsonObj.AddJson(obj, "YWZZ", "'" + GetDX("YWZZ") + "'");
    obj = jsonObj.AddJson(obj, "BC", "'" + GetDX("BC") + "'");
    obj = jsonObj.AddJson(obj, "ZHFS", "'" + GetDuoX("ZHFS") + "'");
    obj = jsonObj.AddJson(obj, "HWZL", "'" + GetDuoX("HWZL") + "'");
    obj = jsonObj.AddJson(obj, "FWYS", "'" + GetDuoX("FWYS") + "'");

    if (getUrlParam("SWFW_HYZXJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SWFW_HYZXJBXXID", "'" + getUrlParam("SWFW_HYZXJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW/FBSWFW_HYZXJBXX",
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