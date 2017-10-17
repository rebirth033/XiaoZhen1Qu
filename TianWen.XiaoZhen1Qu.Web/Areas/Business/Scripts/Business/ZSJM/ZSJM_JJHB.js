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
//加载家居环保类别
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
                LoadZSJM_JJHBJBXX();
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
    if ((name.indexOf("家纺床品") !== -1 || name.indexOf("窗帘布艺") !== -1 || name.indexOf("家具") !== -1 || name.indexOf("清洁环保") !== -1))
        LoadJJHBXL(codeid);
    else
        $("#divJJHBXL").css("display", "none");
}
//加载家居环保小类
function LoadJJHBXL(codeid) {
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
                    html += "<li class='liJJHBXL' onclick='SelectJJHBXL(this)'><img class='img_JJHBXL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 5 || i === 11 || i === 17 || i === 23 || i === 29) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divJJHBXLText").html(html);
                $(".img_JJHBXL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");

                if (parseInt(xml.list.length % 6) === 0)
                    $("#divJJHBXL").css("height", parseInt(xml.list.length / 6) * 45 + "px");
                else
                    $("#divJJHBXL").css("height", (parseInt(xml.list.length / 6) + 1) * 45 + "px");

                $("#divJJHBXL").css("display", "");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载家居环保小类
function LoadJJHBXLByName(name, xl) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadJJHBXX",
        dataType: "json",
        data:
        {
            name: name
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liJJHBXL' onclick='SelectJJHBXL(this)'><img class='img_JJHBXL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 5 || i === 11 || i === 17 || i === 23 || i === 29) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divJJHBXLText").html(html);
                $(".img_JJHBXL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");

                if (parseInt(xml.list.length % 6) === 0)
                    $("#divJJHBXL").css("height", parseInt(xml.list.length / 6) * 45 + "px");
                else
                    $("#divJJHBXL").css("height", (parseInt(xml.list.length / 6) + 1) * 45 + "px");

                $("#divJJHBXL").css("display", "");
                SetJJHBXL(xl);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择家居环保小类
function SelectJJHBXL(obj) {
    if ($(obj).find("img").attr("src").indexOf("blue") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
}
//获取家居环保小类
function GetJJHBXL() {
    var JJHBXL = "";
    $(".liJJHBXL").each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            JJHBXL += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(JJHBXL, ',');
}
//设置家居环保小类
function SetJJHBXL(lbs) {
    var lbarray = lbs.split(',');
    for (var i = 0; i < lbarray.length; i++) {
        $(".liJJHBXL").each(function () {
            if ($(this).find("label")[0].innerHTML.indexOf(lbarray[i]) !== -1)
                $(this).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
        });
    }
    $("#divJJHBXL").css("display", "");
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
            LoadDropdown("家居环保", "LB");
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
//加载招商加盟_家居环保基本信息
function LoadZSJM_JJHBJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ZSJM_JJHB/LoadZSJM_JJHBJBXX",
        dataType: "json",
        data:
        {
            ZSJM_JJHBJBXXID: getUrlParam("ZSJM_JJHBJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ZSJM_JJHBJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ZSJM_JJHBJBXXID").val(xml.Value.ZSJM_JJHBJBXX.ZSJM_JJHBJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.ZSJM_JJHBJBXX.BCMS);
                });
                $("#spanLB").html(xml.Value.ZSJM_JJHBJBXX.LB);
                $("#spanQY").html(xml.Value.ZSJM_JJHBJBXX.QY);
                $("#spanDD").html(xml.Value.ZSJM_JJHBJBXX.DD);
                $("#spanPPLS").html(xml.Value.ZSJM_JJHBJBXX.PPLS);
                $("#spanTZJE").html(xml.Value.ZSJM_JJHBJBXX.TZJE);
                $("#spanQGFDS").html(xml.Value.ZSJM_JJHBJBXX.QGFDS);
                $("#spanDDMJ").html(xml.Value.ZSJM_JJHBJBXX.DDMJ);
                LoadPhotos(xml.Value.Photos);
                SetSHRQ(xml.Value.ZSJM_JJHBJBXX.SHRQ);
                SetZSDQ(xml.Value.ZSJM_JJHBJBXX.ZSDQ);
                if (xml.Value.ZSJM_JJHBJBXX.LB.indexOf("家纺床品") !== -1 || xml.Value.ZSJM_JJHBJBXX.LB.indexOf("窗帘布艺") !== -1 || xml.Value.ZSJM_JJHBJBXX.LB.indexOf("家具") !== -1 || xml.Value.ZSJM_JJHBJBXX.LB.indexOf("清洁环保") !== -1) {
                    LoadJJHBXLByName(xml.Value.ZSJM_JJHBJBXX.LB, xml.Value.ZSJM_JJHBJBXX.XL);
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
    obj = jsonObj.AddJson(obj, "XL", "'" + GetJJHBXL() + "'");

    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("ZSJM_JJHBJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ZSJM_JJHBJBXXID", "'" + getUrlParam("ZSJM_JJHBJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ZSJM_JJHB/FB",
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