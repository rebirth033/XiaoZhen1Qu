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
//加载全职招聘类别
function LoadDropdown(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_QZZP",
        dataType: "json",
        data:
        {
            TYPENAME: type
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"" + id + "\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#div" + id).html(html);
                $("#div" + id).css("display", "block");
                ActiveStyle(id);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载适合人群
function LoadSHRQ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_QZZP",
        dataType: "json",
        data:
        {
            TYPENAME: "适合人群"
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
                LoadQZZP_QZZPJBXX();
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
    if (name.indexOf("文体用品") !== -1 || name.indexOf("母婴儿童用品") !== -1)
        LoadQZZPXL(codeid);
    if (name.indexOf("文具加工") !== -1)
        $("#divQZZPXL").css("display", "none");
}
//加载全职招聘小类
function LoadQZZPXL(codeid) {
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
                    html += "<li class='liQZZPXL' onclick='SelectQZZPXL(this)'><img class='img_QZZPXL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 5 || i === 11 || i === 17 || i === 23 || i === 29) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divQZZPXLText").html(html);
                $(".img_QZZPXL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");

                if (parseInt(xml.list.length % 6) === 0)
                    $("#divQZZPXL").css("height", parseInt(xml.list.length / 6) * 45 + "px");
                else
                    $("#divQZZPXL").css("height", (parseInt(xml.list.length / 6) + 1) * 45 + "px");

                $("#divQZZPXL").css("display", "");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载全职招聘小类
function LoadQZZPXLByName(name, xl) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadQZZPXX",
        dataType: "json",
        data:
        {
            name: name
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liQZZPXL' onclick='SelectQZZPXL(this)'><img class='img_QZZPXL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 5 || i === 11 || i === 17 || i === 23 || i === 29) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divQZZPXLText").html(html);
                $(".img_QZZPXL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");

                if (parseInt(xml.list.length % 6) === 0)
                    $("#divQZZPXL").css("height", parseInt(xml.list.length / 6) * 45 + "px");
                else
                    $("#divQZZPXL").css("height", (parseInt(xml.list.length / 6) + 1) * 45 + "px");

                $("#divQZZPXL").css("display", "");
                SetQZZPXL(xl);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择全职招聘小类
function SelectQZZPXL(obj) {
    if ($(obj).find("img").attr("src").indexOf("blue") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
}
//获取全职招聘小类
function GetQZZPXL() {
    var QZZPXL = "";
    $(".liQZZPXL").each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            QZZPXL += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(QZZPXL, ',');
}
//设置全职招聘小类
function SetQZZPXL(lbs) {
    var lbarray = lbs.split(',');
    for (var i = 0; i < lbarray.length; i++) {
        $(".liQZZPXL").each(function () {
            if ($(this).find("label")[0].innerHTML.indexOf(lbarray[i]) !== -1)
                $(this).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
        });
    }
    $("#divQZZPXL").css("display", "");
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
            LoadDropdown("全职招聘", "LB");
        }
        if (type === "PPLS") {
            LoadDropdown("品牌历史", "PPLS");
        }
        if (type === "TZJE") {
            LoadDropdown("投资金额", "TZJE");
        }
        if (type === "QGFDS") {
            LoadDropdown("全国分店数", "QGFDS");
        }
        if (type === "DDMJ") {
            LoadDropdown("单店面积", "DDMJ");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载求职招聘_全职招聘基本信息
function LoadQZZP_QZZPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/QZZP_QZZP/LoadQZZP_QZZPJBXX",
        dataType: "json",
        data:
        {
            QZZP_QZZPJBXXID: getUrlParam("QZZP_QZZPJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.QZZP_QZZPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#QZZP_QZZPJBXXID").val(xml.Value.QZZP_QZZPJBXX.QZZP_QZZPJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.QZZP_QZZPJBXX.BCMS);
                });
                $("#spanLB").html(xml.Value.QZZP_QZZPJBXX.LB);
                $("#spanQY").html(xml.Value.QZZP_QZZPJBXX.QY);
                $("#spanDD").html(xml.Value.QZZP_QZZPJBXX.DD);
                $("#spanPPLS").html(xml.Value.QZZP_QZZPJBXX.PPLS);
                $("#spanTZJE").html(xml.Value.QZZP_QZZPJBXX.TZJE);
                $("#spanQGFDS").html(xml.Value.QZZP_QZZPJBXX.QGFDS);
                $("#spanDDMJ").html(xml.Value.QZZP_QZZPJBXX.DDMJ);
                LoadPhotos(xml.Value.Photos);
                SetSHRQ(xml.Value.QZZP_QZZPJBXX.SHRQ);
                SetZSDQ(xml.Value.QZZP_QZZPJBXX.ZSDQ);
                if (xml.Value.QZZP_QZZPJBXX.LB.indexOf("文体用品") !== -1 || xml.Value.QZZP_QZZPJBXX.LB.indexOf("母婴儿童用品") !== -1) {
                    LoadQZZPXLByName(xml.Value.QZZP_QZZPJBXX.LB, xml.Value.QZZP_QZZPJBXX.XL);
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
    obj = jsonObj.AddJson(obj, "XL", "'" + GetQZZPXL() + "'");

    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("QZZP_QZZPJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "QZZP_QZZPJBXXID", "'" + getUrlParam("QZZP_QZZPJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/QZZP_QZZP/FB",
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