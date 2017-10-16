﻿var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#imgSMFW").bind("click", SMFWSelect);
    $("#imgDDFW").bind("click", DDFWSelect);
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
    BindClick("QY");
    BindClick("DD");
    LoadSWFW_PHZPJBXX();
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
    $("#imgSMFW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgDDFW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择上门服务
function SMFWSelect() {
    $("#imgSMFW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgDDFW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择到店服务
function DDFWSelect() {
    $("#imgSMFW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgDDFW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}
//获取是否上门
function GetSFSM() {
    if ($("#imgSMFW").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置是否上门
function SetSFSM(sfsm) {
    if (sfsm === 0) {
        $("#imgSMFW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgDDFW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgSMFW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgDDFW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadLB("喷绘招牌", "LB");
        }
        if (type === "CZ") {
            LoadQTLB("灯箱/招牌材质", "CZ");
        }
        if (type === "GY") {
            LoadQTLB("灯箱/招牌工艺", "GY");
        }
        if (type === "SFFG") {
            LoadQTLB("是否发光", "SFFG");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载喷绘招牌类别
function LoadLB(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_SWFW",
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
//选择类别下拉框
function SelectLB(obj, type, id) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    PDLB(obj.innerHTML);
}
//判断类别
function PDLB(lbmc, xl) {
    if (lbmc === "灯箱/招牌") {
        LoadXL($("#spanLB").html(), xl);
        $("#divXL").css("display", "");
        $("#divPHZPCZ").css("display", "");
        $("#divPHZPGY").css("display", "");
        $("#divPHZPSFFG").css("display", "");
        $("#divPHZPYT").css("display", "none");
        $("#divPHZPGN").css("display", "none");
        BindClick("CZ");
        BindClick("GY");
        BindClick("SFFG");
    }
    else if (lbmc === "亮化工程" || lbmc === "背景/形象墙" || lbmc === "展架制作" || lbmc === "户外广告" || lbmc === "LED显示屏" || lbmc === "条幅/锦旗/奖牌") {
        LoadXL($("#spanLB").html(), xl);
        $("#divXL").css("display", "");
        $("#divPHZPCZ").css("display", "none");
        $("#divPHZPGY").css("display", "none");
        $("#divPHZPSFFG").css("display", "none");
        $("#divPHZPYT").css("display", "none");
        $("#divPHZPGN").css("display", "none");
        BindClick("XL");
    }
    else {
        $("#divPHZPYT").css("display", "");
        $("#divPHZPGN").css("display", "");
        $("#divPHZPCZ").css("display", "");
        $("#divXL").css("display", "none");
        $("#divPHZPGY").css("display", "none");
        $("#divPHZPSFFG").css("display", "none");
    }
}
//加载喷绘招牌类别
function LoadQTLB(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_SWFW",
        dataType: "json",
        data:
        {
            TYPENAME: type
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"" + id + "\")'>" + xml.list[i].CODENAME + "</li>";
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
//加载小类
function LoadXL(lbmc, xl) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_SWFW",
        dataType: "json",
        data:
        {
            TYPENAME: lbmc
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liXL' onclick='SelectXL(this)'><img class='img_XL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 4 || i === 9) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 5) === 0)
                    $("#divXL").css("height", parseInt(xml.list.length / 5) * 45 + "px");
                else
                    $("#divXL").css("height", (parseInt(xml.list.length / 5) + 1) * 45 + "px");
                html += "</ul>";
                $("#divXLText").html(html);
                $(".img_XL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                if (xml.list.length === 0)
                    $("#divXL").css("display", "none");
                else
                    $("#divXL").css("display", "");
                if (xl !== "" && xl !== null)
                    SetXL(xl);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择小类
function SelectXL(obj) {
    if ($(obj).find("img").attr("src").indexOf("blue") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
}
//获取小类
function GetXL() {
    var XL = "";
    $(".liXL").each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            XL += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(XL, ',');
}
//设置小类
function SetXL(lbs) {
    if (lbs !== "" && lbs !== null) {
        var lbarray = lbs.split(',');
        for (var i = 0; i < lbarray.length; i++) {
            $(".liXL").each(function () {
                if ($(this).find("label")[0].innerHTML.indexOf(lbarray[i]) !== -1)
                    $(this).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
            });
        }
    }
}
//加载商务服务_喷绘招牌基本信息
function LoadSWFW_PHZPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW_PHZP/LoadSWFW_PHZPJBXX",
        dataType: "json",
        data:
        {
            SWFW_PHZPJBXXID: getUrlParam("SWFW_PHZPJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SWFW_PHZPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SWFW_PHZPJBXXID").val(xml.Value.SWFW_PHZPJBXX.SWFW_PHZPJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.SWFW_PHZPJBXX.BCMS);
                });
                $("#spanLB").html(xml.Value.SWFW_PHZPJBXX.LB);
                $("#spanCZ").html(xml.Value.SWFW_PHZPJBXX.CZ);
                $("#spanGY").html(xml.Value.SWFW_PHZPJBXX.GY);
                $("#spanSFFG").html(xml.Value.SWFW_PHZPJBXX.SFFG);
                $("#spanQY").html(xml.Value.SWFW_PHZPJBXX.QY);
                $("#spanDD").html(xml.Value.SWFW_PHZPJBXX.DD);
                PDLB(xml.Value.SWFW_PHZPJBXX.LB, xml.Value.SWFW_PHZPJBXX.XL);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "CZ", "'" + $("#spanCZ").html() + "'");
    obj = jsonObj.AddJson(obj, "GY", "'" + $("#spanGY").html() + "'");
    obj = jsonObj.AddJson(obj, "SFFG", "'" + $("#spanSFFG").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + GetXL() + "'");

    if (getUrlParam("SWFW_PHZPJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SWFW_PHZPJBXXID", "'" + getUrlParam("SWFW_PHZPJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW_PHZP/FB",
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