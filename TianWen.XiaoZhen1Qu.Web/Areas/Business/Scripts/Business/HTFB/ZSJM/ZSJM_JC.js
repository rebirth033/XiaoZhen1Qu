﻿$(document).ready(function () {
    BindClick("LB");
    BindClick("PPLS");
    BindClick("TZJE");
    BindClick("QGFDS");
    BindClick("DDMJ");
    LoadDuoX("适合人群", "SHRQ");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("建材类别", "LB", "CODES_ZSJM", Bind, "JCLB", "LB", "");
        }
        if (type === "PPLS") {
            LoadCODESByTYPENAME("品牌历史", "PPLS", "CODES_ZSJM");
        }
        if (type === "TZJE") {
            LoadCODESByTYPENAME("投资金额", "TZJE", "CODES_ZSJM", Bind, "JCTZJE", "TZJE", "");
        }
        if (type === "QGFDS") {
            LoadCODESByTYPENAME("全国分店数", "QGFDS", "CODES_ZSJM");
        }
        if (type === "DDMJ") {
            LoadCODESByTYPENAME("单店面积", "DDMJ", "CODES_ZSJM");
        }
    });
}
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: type,
            TBName: "CODES_ZSJM"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 6 === 5 && i != xml.list.length - 1) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 174px'>";
                    }
                }
                if (parseInt(xml.list.length % 6) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 6) * 40 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 6) + 1) * 40 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                if (type === "适合人群")
                    LoadDuoX("经营模式", "JYMS");
                if (type === "经营模式")
                    LoadFWFW();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择类别下拉框
function SelectLB(obj, type, codeid) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    if (type === "LB")
        PDLB(obj.innerHTML, codeid);
}
//判断类别
function PDLB(name, codeid) {
    $("#divXL").css("display", "");
    LoadDuoX(name, "XL");
}
//加载招商加盟_建材基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/ZSJM/LoadZSJM_JCJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ZSJM_JCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.ZSJM_JCJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanLB").html(xml.Value.ZSJM_JCJBXX.LB);
                $("#spanQY").html(xml.Value.ZSJM_JCJBXX.QY);
                $("#spanDD").html(xml.Value.ZSJM_JCJBXX.DD);
                $("#spanPPLS").html(xml.Value.ZSJM_JCJBXX.PPLS);
                $("#spanTZJE").html(xml.Value.ZSJM_JCJBXX.TZJE);
                $("#spanQGFDS").html(xml.Value.ZSJM_JCJBXX.QGFDS);
                $("#spanDDMJ").html(xml.Value.ZSJM_JCJBXX.DDMJ);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.ZSJM_JCJBXX.XL !== null)
                    SetDuoX("XL", xml.Value.ZSJM_JCJBXX.XL);
                if (xml.Value.ZSJM_JCJBXX.SHRQ !== null)
                    SetDuoX("SHRQ", xml.Value.ZSJM_JCJBXX.SHRQ);
                if (xml.Value.ZSJM_JCJBXX.JYMS !== null)
                    SetDuoX("JYMS", xml.Value.ZSJM_JCJBXX.JYMS);
                if (xml.Value.ZSJM_JCJBXX.FWFW !== null)
                    SetDuoX("FWFW", xml.Value.ZSJM_JCJBXX.FWFW);
                if ((xml.Value.ZSJM_LPSPJBXX.LB.indexOf("饰品挂件") !== -1 || xml.Value.ZSJM_LPSPJBXX.LB.indexOf("礼品") !== -1 || xml.Value.ZSJM_LPSPJBXX.LB.indexOf("工艺品") !== -1 || xml.Value.ZSJM_LPSPJBXX.LB.indexOf("珠宝玉器") !== -1) && xml.Value.ZSJM_LPSPJBXX.LB !== "礼品加工") {
                    LoadXLByName(xml.Value.ZSJM_LPSPJBXX.LB, xml.Value.ZSJM_LPSPJBXX.XL, "CODES_ZSJM");
                }
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
    obj = jsonObj.AddJson(obj, "PPLS", "'" + $("#spanPPLS").html() + "'");
    obj = jsonObj.AddJson(obj, "TZJE", "'" + $("#spanTZJE").html() + "'");
    obj = jsonObj.AddJson(obj, "QGFDS", "'" + $("#spanQGFDS").html() + "'");
    obj = jsonObj.AddJson(obj, "DDMJ", "'" + $("#spanDDMJ").html() + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + GetDuoX("XL") + "'");
    obj = jsonObj.AddJson(obj, "SHRQ", "'" + GetDuoX("SHRQ") + "'");
    obj = jsonObj.AddJson(obj, "JYMS", "'" + GetDuoX("JYMS") + "'");
    obj = jsonObj.AddJson(obj, "FWFW", "'" + GetDuoX("FWFW") + "'");

    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/ZSJM/FBZSJM_JCJBXX",
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