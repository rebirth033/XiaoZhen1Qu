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
//加载教育培训类别
function LoadDropdown(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ZSJM",
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
        url: getRootPath() + "/Business/Common/LoadCODES_ZSJM",
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
                LoadZSJM_JYPXJBXX();
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
    if (name.indexOf("教育机构") !== -1)
        LoadJYPXXL(codeid);
    if (name.indexOf("儿童乐园") !== -1)
        $("#divJYPXXL").css("display", "none");
}
//加载教育培训小类
function LoadJYPXXL(codeid) {
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
                    html += "<li class='liJYPXXL' onclick='SelectJYPXXL(this)'><img class='img_JYPXXL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 5 || i === 11 || i === 17 || i === 23 || i === 29) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divJYPXXLText").html(html);
                $(".img_JYPXXL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");

                if (parseInt(xml.list.length % 6) === 0)
                    $("#divJYPXXL").css("height", parseInt(xml.list.length / 6) * 45 + "px");
                else
                    $("#divJYPXXL").css("height", (parseInt(xml.list.length / 6) + 1) * 45 + "px");

                $("#divJYPXXL").css("display", "");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载教育培训小类
function LoadJYPXXLByName(name, xl) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadLPXSPXX",
        dataType: "json",
        data:
        {
            name: name
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liJYPXXL' onclick='SelectJYPXXL(this)'><img class='img_JYPXXL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 5 || i === 11 || i === 17 || i === 23 || i === 29) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divJYPXXLText").html(html);
                $(".img_JYPXXL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");

                if (parseInt(xml.list.length % 6) === 0)
                    $("#divJYPXXL").css("height", parseInt(xml.list.length / 6) * 45 + "px");
                else
                    $("#divJYPXXL").css("height", (parseInt(xml.list.length / 6) + 1) * 45 + "px");

                $("#divJYPXXL").css("display", "");
                SetJYPXXL(xl);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择教育培训小类
function SelectJYPXXL(obj) {
    if ($(obj).find("img").attr("src").indexOf("blue") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
}
//获取教育培训小类
function GetJYPXXL() {
    var JYPXXL = "";
    $(".liJYPXXL").each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            JYPXXL += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(JYPXXL, ',');
}
//设置教育培训小类
function SetJYPXXL(lbs) {
    var lbarray = lbs.split(',');
    for (var i = 0; i < lbarray.length; i++) {
        $(".liJYPXXL").each(function () {
            if ($(this).find("label")[0].innerHTML.indexOf(lbarray[i]) !== -1)
                $(this).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
        });
    }
    $("#divJYPXXL").css("display", "");
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
            LoadDropdown("教育培训", "LB");
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
//加载招商加盟_教育培训基本信息
function LoadZSJM_JYPXJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ZSJM_JYPX/LoadZSJM_JYPXJBXX",
        dataType: "json",
        data:
        {
            ZSJM_JYPXJBXXID: getUrlParam("ZSJM_JYPXJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ZSJM_JYPXJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ZSJM_JYPXJBXXID").val(xml.Value.ZSJM_JYPXJBXX.ZSJM_JYPXJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.ZSJM_JYPXJBXX.BCMS);
                });
                $("#spanLB").html(xml.Value.ZSJM_JYPXJBXX.LB);
                $("#spanQY").html(xml.Value.ZSJM_JYPXJBXX.QY);
                $("#spanDD").html(xml.Value.ZSJM_JYPXJBXX.DD);
                $("#spanPPLS").html(xml.Value.ZSJM_JYPXJBXX.PPLS);
                $("#spanTZJE").html(xml.Value.ZSJM_JYPXJBXX.TZJE);
                $("#spanQGFDS").html(xml.Value.ZSJM_JYPXJBXX.QGFDS);
                $("#spanDDMJ").html(xml.Value.ZSJM_JYPXJBXX.DDMJ);
                LoadPhotos(xml.Value.Photos);
                SetSHRQ(xml.Value.ZSJM_JYPXJBXX.SHRQ);
                SetZSDQ(xml.Value.ZSJM_JYPXJBXX.ZSDQ);
                if (xml.Value.ZSJM_JYPXJBXX.LB.indexOf("教育机构") !== -1) {
                    LoadJYPXXLByName(xml.Value.ZSJM_JYPXJBXX.LB, xml.Value.ZSJM_JYPXJBXX.XL);
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
    obj = jsonObj.AddJson(obj, "XL", "'" + GetJYPXXL() + "'");

    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("ZSJM_JYPXJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ZSJM_JYPXJBXXID", "'" + getUrlParam("ZSJM_JYPXJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ZSJM_JYPX/FB",
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