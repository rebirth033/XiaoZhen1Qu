
$(document).ready(function () {$("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });BindClick("LB");
    BindClick("PPLS");
    BindClick("TZJE");
    BindClick("QGFDS");
    BindClick("DDMJ");
    BindClick("QY");
    BindClick("DD");
    LoadDuoX("适合人群", "SHRQ");
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
            TBName: "CODES_ZSJM"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 5 || i === 11 || i === 17 || i === 23 || i === 29) {
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
                LoadZSDQ();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载招商地区
function LoadZSDQ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/GetDistrictTJByXZQDM",
        dataType: "json",
        data:
        {
            XZQDM: $("#input_XZQDM").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liZSDQ' onclick='SelectDuoX(this)'><img class='img_ZSDQ'/><label style='font-weight:normal;'>" + xml.list[i].NAME + "</label></li>";
                    if (i === 5 || i === 11 || i === 17 || i === 23 || i === 29) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 6) === 0)
                    $("#divZSDQ").css("height", parseInt(xml.list.length / 6) * 45 + "px");
                else
                    $("#divZSDQ").css("height", (parseInt(xml.list.length / 6) + 1) * 45 + "px");
                html += "</ul>";
                $("#divZSDQText").html(html);
                $(".img_ZSDQ").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadZSJM_MRBJJBXX();
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
    PDLB(obj.innerHTML, codeid);
}
//判断类别
function PDLB(name, codeid) {
    if (name.indexOf("化妆品") !== -1 || name.indexOf("美容SPA") !== -1 || name.indexOf("养生保健") !== -1)
        LoadMRBJXL(codeid);
}
//加载美容保健小类
function LoadMRBJXL(codeid) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: codeid,
            TBName: "CODES_ZSJM"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liMRBJXL' onclick='SelectDuoX(this)'><img class='img_MRBJXL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 5 || i === 11 || i === 17 || i === 23 || i === 29) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divMRBJXLText").html(html);
                $(".img_MRBJXL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");

                if (parseInt(xml.list.length % 6) === 0)
                    $("#divMRBJXL").css("height", parseInt(xml.list.length / 6) * 45 + "px");
                else
                    $("#divMRBJXL").css("height", (parseInt(xml.list.length / 6) + 1) * 45 + "px");

                $("#divMRBJXL").css("display", "");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("美容保健", "LB", "CODES_ZSJM");
        }
        if (type === "PPLS") {
            LoadCODESByTYPENAME("品牌历史", "PPLS", "CODES_ZSJM");
        }
        if (type === "TZJE") {
            LoadCODESByTYPENAME("投资金额", "TZJE", "CODES_ZSJM");
        }
        if (type === "QGFDS") {
            LoadCODESByTYPENAME("全国分店数", "QGFDS", "CODES_ZSJM");
        }
        if (type === "DDMJ") {
            LoadCODESByTYPENAME("单店面积", "DDMJ", "CODES_ZSJM");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载招商加盟_美容保健基本信息
function LoadZSJM_MRBJJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ZSJM_MRBJ/LoadZSJM_MRBJJBXX",
        dataType: "json",
        data:
        {
            ZSJM_MRBJJBXXID: getUrlParam("ZSJM_MRBJJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ZSJM_MRBJJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ZSJM_MRBJJBXXID").val(xml.Value.ZSJM_MRBJJBXX.ZSJM_MRBJJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.ZSJM_MRBJJBXX.LB);
                $("#spanQY").html(xml.Value.ZSJM_MRBJJBXX.QY);
                $("#spanDD").html(xml.Value.ZSJM_MRBJJBXX.DD);
                $("#spanPPLS").html(xml.Value.ZSJM_MRBJJBXX.PPLS);
                $("#spanTZJE").html(xml.Value.ZSJM_MRBJJBXX.TZJE);
                $("#spanQGFDS").html(xml.Value.ZSJM_MRBJJBXX.QGFDS);
                $("#spanDDMJ").html(xml.Value.ZSJM_MRBJJBXX.DDMJ);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.ZSJM_MRBJJBXX.SHRQ !== null)
                    SetDuoX("SHRQ", xml.Value.ZSJM_MRBJJBXX.SHRQ);
                if (xml.Value.ZSJM_MRBJJBXX.ZSDQ !== null)
                    SetDuoX("ZSDQ", xml.Value.ZSJM_MRBJJBXX.ZSDQ);
                if (xml.Value.ZSJM_MRBJJBXX.LB.indexOf("化妆品") !== -1 || xml.Value.ZSJM_MRBJJBXX.LB.indexOf("美容SPA") !== -1 || xml.Value.ZSJM_MRBJJBXX.LB.indexOf("养生保健") !== -1) {
                    LoadMRBJXLByName(xml.Value.ZSJM_MRBJJBXX.LB, xml.Value.ZSJM_MRBJJBXX.XL);
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
    obj = jsonObj.AddJson(obj, "SHRQ", "'" + GetDuoX("SHRQ") + "'");
    obj = jsonObj.AddJson(obj, "ZSDQ", "'" + GetDuoX("ZSDQ") + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + GetDuoX("XL") + "'");

    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("ZSJM_MRBJJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ZSJM_MRBJJBXXID", "'" + getUrlParam("ZSJM_MRBJJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ZSJM_MRBJ/FB",
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