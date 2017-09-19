﻿var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 900) / 2);
    $(".div_head").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $(".div_content").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $("#spanCXLB").bind("click", CXLB);
    $("#imgGRZR").bind("click", GRZRSelect);
    $("#imgSJZR").bind("click", SJZRSelect);
    $("#imgXCWXS").bind("click", XCWXSSelect);
    $("#imgYXS").bind("click", YXSSelect);
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qhcs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("LB"); Close("PP"); Close("QY"); Close("DD"); });
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);

    LoadTXXX();
    LoadMTCLB();
    LoadGCSJ();
    LoadMTCPP();
    LoadDefault();
    LoadCL_MTCJBXX();
    BindClick("LB");
    BindClick("GCSJ");
    BindClick("PP");
    BindClick("QY");
    BindClick("SQ");
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
    $("#imgGRZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgXCWXS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgYXS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//加载图形信息
function LoadTXXX() {
    $("#spanTXXX").css("color", "#5bc0de");
    $("#emTXXX").css("background", "#5bc0de");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LBXZ/LoadLBByID",
        dataType: "json",
        data:
        {
            LBID: getUrlParam("CLICKID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                if (xml.list.length > 0)
                    $("#spanLBXZ").html("1." + xml.list[0].LBNAME);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//重选类别
function CXLB() {
    window.location.href = getRootPath() + "/Business/LBXZ/LBXZ";
}
//选择个人转让
function GRZRSelect() {
    $("#imgGRZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择商家转让
function SJZRSelect() {
    $("#imgGRZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}
//新车未行使
function XCWXSSelect() {
    $("#imgXCWXS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgYXS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#divMTCGCSJ").css("display", "none");
    $("#divGLS").css("display", "none");
}
//已行使
function YXSSelect() {
    $("#imgXCWXS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgYXS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#divMTCGCSJ").css("display", "");
    $("#divGLS").css("display", "");
}
//加载摩托车类别
function LoadMTCLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_CL",
        dataType: "json",
        data:
        {
            TYPENAME: "摩托车"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"LB\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divLB").html(html);
                $("#divLB").css("display", "block");
                ActiveStyle("LB");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载摩托车品牌
function LoadMTCPP() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_CL",
        dataType: "json",
        data:
        {
            TYPENAME: "摩托车品牌"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"PP\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divPP").html(html);
                $("#divPP").css("display", "block");
                ActiveStyle("PP");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载摩托车购车时间
function LoadGCSJ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_CL",
        dataType: "json",
        data:
        {
            TYPENAME: "购车时间"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"GCSJ\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divGCSJ").html(html);
                $("#divGCSJ").css("display", "block");
                ActiveStyle("GCSJ");
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
            LoadMTCLB();
        }
        if (type === "PP") {
            LoadMTCPP();
        }
        if (type === "CCNX") {
            LoadCCNX();
        }
        if (type === "CCYF") {
            LoadCCYF();
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//选择下拉框
function SelectDropdown(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
}
//选择摩托车品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//获取供求
function GetGQ() {
    if ($("#imgGRZR").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置供求
function SetGQ(gq) {
    if (gq === 0) {
        $("#imgGRZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgGRZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//获取行驶里程
function GetXSLC() {
    if ($("#imgXCWXS").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置行驶里程
function SetXSLC(xslc) {
    if (xslc === 0) {
        $("#imgXCWXS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgYXS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#divMTCGCSJ").css("display", "none");
        $("#divGLS").css("display", "none");
    }
    else {
        $("#imgXCWXS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgYXS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#divMTCGCSJ").css("display", "");
        $("#divGLS").css("display", "");
    }
}
//加载车辆_摩托车基本信息
function LoadCL_MTCJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL_MTC/LoadCL_MTCJBXX",
        dataType: "json",
        data:
        {
            CL_MTCJBXXID: getUrlParam("CL_MTCJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_MTCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#CL_MTCJBXXID").val(xml.Value.CL_MTCJBXX.CL_MTCJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.CL_MTCJBXX.BCMS);
                });
                SetGQ(xml.Value.CL_MTCJBXX.GQ);
                SetXSLC(xml.Value.CL_MTCJBXX.XSLC);
                $("#spanLB").html(xml.Value.CL_MTCJBXX.LB);
                $("#spanPP").html(xml.Value.CL_MTCJBXX.PP);
                $("#spanGCSJ").html(xml.Value.CL_MTCJBXX.GCSJ);
                $("#spanQY").html(xml.Value.CL_MTCJBXX.JYQY);
                $("#spanDD").html(xml.Value.CL_MTCJBXX.JYDD);
                $("#spanXL").html(xml.Value.CL_MTCJBXX.XL);

                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.CL_MTCJBXX.LB);
                return;
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
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanPP").html() + "'");
    obj = jsonObj.AddJson(obj, "GCSJ", "'" + $("#spanGCSJ").html() + "'");
    obj = jsonObj.AddJson(obj, "JYQY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "JYDD", "'" + $("#spanSQ").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetGQ() + "'");
    obj = jsonObj.AddJson(obj, "XSLC", "'" + GetXSLC() + "'");

    if (getUrlParam("CL_MTCJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "CL_MTCJBXXID", "'" + getUrlParam("CL_MTCJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL_MTC/FB",
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