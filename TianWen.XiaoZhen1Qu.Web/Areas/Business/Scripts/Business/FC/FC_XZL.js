﻿var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#imgCZ").bind("click", CZSelect);
    $("#imgCS").bind("click", CSSelect);
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
    LoadDefault();
    LoadFC_XZLJBXX();
    BindClick("XZLLX");
    BindClick("KZCGS");
    BindClick("QY");
    BindClick("SQ");
    BindClick("ZJDW");
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
    $("#imgSPZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSYZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgCS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择出租
function CZSelect() {
    $("#imgCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgCS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#divZJ").css("display", "block");
    $("#divSJ").css("display", "none");
}
//选择出售
function CSSelect() {
    $("#imgCS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#divZJ").css("display", "none");
    $("#divSJ").css("display", "block");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "XZLLX") {
            LoadXZLLX();
        }
        if (type === "KZCGS") {
            LoadKZCGS();
        }
        if (type === "ZJDW") {
            LoadZJDW();
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "SQ") {
            LoadSQ();
        }
    });
}
//加载写字楼类型
function LoadXZLLX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_FC",
        dataType: "json",
        data:
        {
            TYPENAME: "写字楼类型"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: none;height:70px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"XZLLX\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divXZLLX").html(html);
                $("#divXZLLX").css("display", "block");
                ActiveStyle("XZLLX");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载可否注册公司
function LoadKZCGS() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_FC",
        dataType: "json",
        data:
        {
            TYPENAME: "可注册公司"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll; height:70px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"KZCGS\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divKZCGS").html(html);
                $("#divKZCGS").css("display", "block");
                ActiveStyle("KZCGS");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载区域
function LoadQY() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadQY",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectQY(this,\"QY\",\"" + xml.list[i].CODE + "\")'>" + RTrim(RTrim(RTrim(xml.list[i].NAME, '市'), '区'), '县') + "</li>";
                }
                html += "</ul>";
                $("#divQY").html(html);
                $("#divQY").css("display", "block");
                ActiveStyle("QY");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载商圈
function LoadSQ(QY) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadSQ",
        dataType: "json",
        data:
        {
            QY: QY
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"SQ\")'>" + RTrimStr(xml.list[i].NAME, '街道,镇,林场,管理处') + "</li>";
                }
                html += "</ul>";
                $("#divSQ").html(html);
                $("#divSQ").css("display", "block");
                ActiveStyle("SQ");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载租金单位
function LoadZJDW() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_FC",
        dataType: "json",
        data:
        {
            TYPENAME: "租金单位"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: none;height:70px;margin-left:-1px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"ZJDW\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divZJDW").html(html);
                $("#divZJDW").css("display", "block");
                ActiveStyle("ZJDW");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择区域下拉框
function SelectQY(obj, type, code) {
    $("#QYCode").val(code);
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadSQ(code);
}
//获取供求
function GetGQ() {
    if ($("#imgCZ").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置供求
function SetGQ(gq) {
    if (gq === 0) {
        $("#imgCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgCS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#divZJ").css("display", "block");
        $("#divSJ").css("display", "none");
    }
    else {
        $("#imgCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgCS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#divZJ").css("display", "none");
        $("#divSJ").css("display", "block");
    }
}
//加载房产_写字楼基本信息
function LoadFC_XZLJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC_XZL/LoadFC_XZLJBXX",
        dataType: "json",
        data:
        {
            FC_XZLJBXXID: getUrlParam("FC_XZLJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.FC_XZLJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#FC_XZLJBXXID").val(xml.Value.FC_XZLJBXX.FC_XZLJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.FC_XZLJBXX.BCMS);
                });
                SetGQ(xml.Value.FC_XZLJBXX.GQ);
                $("#spanXZLLX").html(xml.Value.FC_XZLJBXX.XZLLX);
                $("#spanKZCGS").html(xml.Value.FC_XZLJBXX.KZCGS);
                $("#spanQY").html(xml.Value.FC_XZLJBXX.QY);
                $("#spanSQ").html(xml.Value.FC_XZLJBXX.SQ);
                $("#spanZJDW").html(xml.Value.FC_XZLJBXX.ZJDW);
                LoadPhotos(xml.Value.Photos);
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
    obj = jsonObj.AddJson(obj, "XZLLX", "'" + $("#spanXZLLX").html() + "'");
    obj = jsonObj.AddJson(obj, "KZCGS", "'" + $("#spanKZCGS").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "SQ", "'" + $("#spanSQ").html() + "'");
    obj = jsonObj.AddJson(obj, "ZJDW", "'" + $("#spanZJDW").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetGQ() + "'");

    if (getUrlParam("FC_XZLJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "FC_XZLJBXXID", "'" + getUrlParam("FC_XZLJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC_XZL/FB",
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