var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 900) / 2);
    $(".div_head").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $(".div_content").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $("#spanCXLB").bind("click", CXLB);
    $("#imgSJZR").bind("click", SJZRSelect);
    $("#imgSJHS").bind("click", SJHSSelect);
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qhcs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("LB"); Close("XL"); Close("XJ"); Close("QY"); Close("DD"); });
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);

    LoadTXXX();
    LoadPBLB();
    LoadDefault();
    LoadES_SJSM_PBDNJBXX();
    BindClick("LB");
    BindClick("PBPP");
    BindClick("PBXH");
    BindClick("XL");
    BindClick("XJ");
    BindClick("QY");
    BindClick("SQ");
});
//房屋描述框focus
function FYMSFocus() {
    $("#FYMS").css("color", "#333333");
}
//房屋描述框blur
function FYMSBlur() {
    $("#FYMS").css("color", "#999999");
}
//房屋描述框设默认文本
function FYMSSetDefault() {
    var fyms = "1.房屋特征：\r\n\r\n2.周边配套：\r\n\r\n3.房东心态：";
    $("#FYMS").html(fyms);
}
//加载默认
function LoadDefault() {
    ue.ready(function () {
        ue.setHeight(200);
    });
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSJHS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgSYG").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgQXWCF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择商家转让
function SJZRSelect() {
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSJHS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择商家回收
function SJHSSelect() {
    $("#imgSJHS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadPBLB();
        }
        if (type === "PBPP") {
            LoadPBPP();
        }
        if (type === "PBXH") {
            LoadPBXH();
        }
        if (type === "XJ") {
            LoadXJ();
        }
        if (type === "XL") {
            LoadPJ();
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载平板类别
function LoadPBLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_SJSM",
        dataType: "json",
        data:
        {
            TYPENAME: "平板类别"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;height:69px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"LB\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divLB").html(html);
                $("#divLB").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载平板品牌
function LoadPBPP() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_SJSM",
        dataType: "json",
        data:
        {
            TYPENAME: "平板品牌"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;height:340px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectPBPP(this,\"PBPP\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divPBPP").html(html);
                $("#divPBPP").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载平板型号
function LoadPBXH() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadPBXH",
        dataType: "json",
        data:
        {
            PBPP: $("#PPID").val()
},
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;height:340px;width:200px'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"PBXH\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divPBXH").html(html);
                $("#divPBXH").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载平板新旧
function LoadXJ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_SJSM",
        dataType: "json",
        data:
        {
            TYPENAME: "新旧程度"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"XJ\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divXJ").html(html);
                $("#divXJ").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载平板配件
function LoadPJ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_SJSM",
        dataType: "json",
        data:
        {
            TYPENAME: "平板电脑配件"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"XL\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divXL").html(html);
                $("#divXL").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    PDLB(obj.innerHTML);
}
//判断类别
function PDLB(LB) {
    if (LB.indexOf("配件") !== -1) {
        $("#divXLText").css("display", "");
        $("#divPBPPText").css("display", "none");
        $("#divPBXHText").css("display", "none");
        $("#divPBXXCS").css("display", "none");
        $("#divPBXXCS_2").css("display", "none");
    } else {
        $("#divXLText").css("display", "none");
        $("#divPBPPText").css("display", "");
        $("#divPBXHText").css("display", "");
        $("#divPBXXCS").css("display", "");
        $("#divPBXXCS_2").css("display", "");
    }
}
//选择平板品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#PPID").val(code);
}
//获取供求
function GetGQ() {
    if ($("#imgSJZR").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置供求
function SetGQ(gq) {
    if (gq === 0) {
        $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgSJHS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgSJHS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//加载二手_手机数码_平板基本信息
function LoadES_SJSM_PBDNJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_SJSM_PBDN/LoadES_SJSM_PBDNJBXX",
        dataType: "json",
        data:
        {
            ES_SJSM_PBDNJBXXID: getUrlParam("ES_SJSM_PBDNJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_SJSM_PBDNJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_SJSM_PBDNJBXXID").val(xml.Value.ES_SJSM_PBDNJBXX.ES_SJSM_PBDNJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.ES_SJSM_PBDNJBXX.BCMS);
                });
                SetGQ(xml.Value.ES_SJSM_PBDNJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_SJSM_PBDNJBXX.LB);
                $("#spanPBPP").html(xml.Value.ES_SJSM_PBDNJBXX.PBPP);
                $("#spanPBXH").html(xml.Value.ES_SJSM_PBDNJBXX.PBXH);
                $("#spanXJ").html(xml.Value.ES_SJSM_PBDNJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_SJSM_PBDNJBXX.JYQY);
                $("#spanSQ").html(xml.Value.ES_SJSM_PBDNJBXX.JYDD);
                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_SJSM_PBDNJBXX.LB);
                $("#spanXL").html(xml.Value.ES_SJSM_PBDNJBXX.XL);
                return;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//鼠标经过
function MouseOver() {
    isleave = false;
}
//鼠标离开
function MouseLeave() {
    isleave = true;
}
//发布
function FB() {
    if (AllValidate() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "PBPP", "'" + $("#spanPBPP").html() + "'");
    obj = jsonObj.AddJson(obj, "PBXH", "'" + $("#spanPBXH").html() + "'");
    obj = jsonObj.AddJson(obj, "CPUPP", "'" + $("#spanCPUPP").html() + "'");
    obj = jsonObj.AddJson(obj, "CPUHS", "'" + $("#spanCPUHS").html() + "'");
    obj = jsonObj.AddJson(obj, "NC", "'" + $("#spanNC").html() + "'");
    obj = jsonObj.AddJson(obj, "YP", "'" + $("#spanYP").html() + "'");
    obj = jsonObj.AddJson(obj, "PMCC", "'" + $("#spanPMCC").html() + "'");
    obj = jsonObj.AddJson(obj, "XK", "'" + $("#spanXK").html() + "'");
    obj = jsonObj.AddJson(obj, "XJ", "'" + $("#spanXJ").html() + "'");
    obj = jsonObj.AddJson(obj, "JYQY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "JYDD", "'" + $("#spanSQ").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetGQ() + "'");

    if (getUrlParam("ES_SJSM_PBDNJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_SJSM_PBDNJBXXID", "'" + getUrlParam("ES_SJSM_PBDNJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_SJSM_PBDN/FB",
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
