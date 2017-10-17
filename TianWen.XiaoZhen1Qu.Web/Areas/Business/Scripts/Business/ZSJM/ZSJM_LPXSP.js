var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qCWFWs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);
    LoadTXXX();
    LoadDefault();
    BindClick("LB");
    BindClick("PPLS");
    BindClick("TZJE");
    BindClick("QGFDS");
    BindClick("DDMJ");
    BindClick("QY");
    BindClick("DD");
    LoadSHRQ();
});
//描述框focus
function FYMSFocus() {
    $("#FYMS").css("color", "#333333");
}
//描述框blur
function FYMSBlur() {
    $("#FYMS").css("color", "#999999");
}
//描述框设默认文本
function FYMSSetDefault() {
    var fyms = "1.房屋特征：\r\n\r\n2.周边配套：\r\n\r\n3.房东心态：";
    $("#FYMS").html(fyms);
}
//加载默认
function LoadDefault() {
    ue.ready(function () {
        ue.setHeight(200);
    });
}
//加载适合人群
function LoadSHRQ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "适合人群",
            TBName: "CODES_ZSJM"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liSHRQ' onclick='SelectSHRQ(this)'><img class='img_SHRQ'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 5 || i === 11 || i === 17 || i === 23 || i === 29) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divSHRQText").html(html);
                $(".img_SHRQ").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
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
                    html += "<li class='liZSDQ' onclick='SelectZSDQ(this)'><img class='img_ZSDQ'/><label style='font-weight:normal;'>" + xml.list[i].NAME + "</label></li>";
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
                LoadZSJM_LPXSPJBXX();
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
    if ((name.indexOf("饰品挂件") !== -1 || name.indexOf("礼品") !== -1 || name.indexOf("工艺品") !== -1 || name.indexOf("珠宝玉器") !== -1) && name !== "礼品加工")
        LoadLPXSPXL(codeid);
    else 
        $("#divLPXSPXL").css("display", "none");
}
//加载礼品/小商品小类
function LoadLPXSPXL(codeid) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadJXXX",
        dataType: "json",
        data:
        {
            JXID: codeid
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liLPXSPXL' onclick='SelectLPXSPXL(this)'><img class='img_LPXSPXL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 5 || i === 11 || i === 17 || i === 23 || i === 29) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divLPXSPXLText").html(html);
                $(".img_LPXSPXL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");

                if (parseInt(xml.list.length % 6) === 0)
                    $("#divLPXSPXL").css("height", parseInt(xml.list.length / 6) * 45 + "px");
                else
                    $("#divLPXSPXL").css("height", (parseInt(xml.list.length / 6) + 1) * 45 + "px");

                $("#divLPXSPXL").css("display", "");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择礼品/小商品小类
function SelectLPXSPXL(obj) {
    if ($(obj).find("img").attr("src").indexOf("blue") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
}
//获取礼品/小商品小类
function GetLPXSPXL() {
    var LPXSPXL = "";
    $(".liLPXSPXL").each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            LPXSPXL += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(LPXSPXL, ',');
}
//设置礼品/小商品小类
function SetLPXSPXL(lbs) {
    var lbarray = lbs.split(',');
    for (var i = 0; i < lbarray.length; i++) {
        $(".liLPXSPXL").each(function () {
            if ($(this).find("label")[0].innerHTML.indexOf(lbarray[i]) !== -1)
                $(this).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
        });
    }
    $("#divLPXSPXL").css("display", "");
}
//选择适合人群
function SelectSHRQ(obj) {
    if ($(obj).find("img").attr("src").indexOf("blue") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
}
//获取适合人群
function GetSHRQ() {
    var SHRQ = "";
    $(".liSHRQ").each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            SHRQ += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(SHRQ, ',');
}
//设置适合人群
function SetSHRQ(lbs) {
    if (lbs !== "" && lbs !== null) {
        var lbarray = lbs.split(',');
        for (var i = 0; i < lbarray.length; i++) {
            $(".liSHRQ").each(function () {
                if ($(this).find("label")[0].innerHTML.indexOf(lbarray[i]) !== -1)
                    $(this).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
            });
        }
    }
}
//选择招商地区
function SelectZSDQ(obj) {
    if ($(obj).find("img").attr("src").indexOf("blue") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
}
//获取招商地区
function GetZSDQ() {
    var ZSDQ = "";
    $(".liZSDQ").each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            ZSDQ += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(ZSDQ, ',');
}
//设置招商地区
function SetZSDQ(lbs) {
    var lbarray = lbs.split(',');
    for (var i = 0; i < lbarray.length; i++) {
        $(".liZSDQ").each(function () {
            if ($(this).find("label")[0].innerHTML.indexOf(lbarray[i]) !== -1)
                $(this).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
        });
    }
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("礼品/小商品", "LB", "CODES_ZSJM");
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
//加载招商加盟_礼品/小商品基本信息
function LoadZSJM_LPXSPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ZSJM_LPXSP/LoadZSJM_LPXSPJBXX",
        dataType: "json",
        data:
        {
            ZSJM_LPXSPJBXXID: getUrlParam("ZSJM_LPXSPJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ZSJM_LPXSPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ZSJM_LPXSPJBXXID").val(xml.Value.ZSJM_LPXSPJBXX.ZSJM_LPXSPJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.ZSJM_LPXSPJBXX.BCMS);
                });
                $("#spanLB").html(xml.Value.ZSJM_LPXSPJBXX.LB);
                $("#spanQY").html(xml.Value.ZSJM_LPXSPJBXX.QY);
                $("#spanDD").html(xml.Value.ZSJM_LPXSPJBXX.DD);
                $("#spanPPLS").html(xml.Value.ZSJM_LPXSPJBXX.PPLS);
                $("#spanTZJE").html(xml.Value.ZSJM_LPXSPJBXX.TZJE);
                $("#spanQGFDS").html(xml.Value.ZSJM_LPXSPJBXX.QGFDS);
                $("#spanDDMJ").html(xml.Value.ZSJM_LPXSPJBXX.DDMJ);
                LoadPhotos(xml.Value.Photos);
                SetSHRQ(xml.Value.ZSJM_LPXSPJBXX.SHRQ);
                SetZSDQ(xml.Value.ZSJM_LPXSPJBXX.ZSDQ);
                if ((xml.Value.ZSJM_LPXSPJBXX.LB.indexOf("饰品挂件") !== -1 || xml.Value.ZSJM_LPXSPJBXX.LB.indexOf("礼品") !== -1 || xml.Value.ZSJM_LPXSPJBXX.LB.indexOf("工艺品") !== -1 || xml.Value.ZSJM_LPXSPJBXX.LB.indexOf("珠宝玉器") !== -1) && xml.Value.ZSJM_LPXSPJBXX.LB !== "礼品加工") {
                    LoadLPXSPXLByName(xml.Value.ZSJM_LPXSPJBXX.LB, xml.Value.ZSJM_LPXSPJBXX.XL);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//发布
function FB() {
    if (AllValidate() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "PPLS", "'" + $("#spanPPLS").html() + "'");
    obj = jsonObj.AddJson(obj, "TZJE", "'" + $("#spanTZJE").html() + "'");
    obj = jsonObj.AddJson(obj, "QGFDS", "'" + $("#spanQGFDS").html() + "'");
    obj = jsonObj.AddJson(obj, "DDMJ", "'" + $("#spanDDMJ").html() + "'");
    obj = jsonObj.AddJson(obj, "SHRQ", "'" + GetSHRQ() + "'");
    obj = jsonObj.AddJson(obj, "ZSDQ", "'" + GetZSDQ() + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + GetLPXSPXL() + "'");

    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("ZSJM_LPXSPJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ZSJM_LPXSPJBXXID", "'" + getUrlParam("ZSJM_LPXSPJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ZSJM_LPXSP/FB",
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