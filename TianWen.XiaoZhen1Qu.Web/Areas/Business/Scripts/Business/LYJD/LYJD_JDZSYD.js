﻿var isleave = true;
var ue = UE.getEditor('FWJS');
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
    LoadLYJD_JDZSYDJBXX();
});
//描述框focus
function FYMSFocus() {
    $("#FWJS").css("color", "#333333");
}
//描述框blur
function FYMSBlur() {
    $("#FWJS").css("color", "#999999");
}
//描述框设默认文本
function FYMSSetDefault() {
    var fyms = "1.房屋特征：\r\n\r\n2.周边配套：\r\n\r\n3.房东心态：";
    $("#FWJS").html(fyms);
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
//加载酒店/住宿预订类别
function LoadLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_LYJD",
        dataType: "json",
        data:
        {
            TYPENAME: "酒店/住宿预订"
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
//选择类别下拉框
function SelectLB(obj, type, id) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadXL($("#spanLB").html());
    $("#divXL").css("display", "");
}
//加载小类
function LoadXL(lbmc, xl) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_LYJD",
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
                    if (i === 3 || i === 7 || i === 11) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divXL").css("height", parseInt(xml.list.length / 4) * 45 + "px");
                else
                    $("#divXL").css("height", (parseInt(xml.list.length / 4) + 1) * 45 + "px");
                html += "</ul>";
                $("#divXLText").html(html);
                $(".img_XL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                if (xml.list.length === 0)
                    $("#divXL").css("display", "none");
                else
                    $("#divXL").css("display", "");
                if (xl !== "" && xl !== null && xl !== undefined)
                    SetXL(xl);
                if (lbmc === "品牌策划推广")
                    $(".liXL").css("width", "200px");
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
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadLB();
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载旅游酒店_酒店/住宿预订基本信息
function LoadLYJD_JDZSYDJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LYJD_JDZSYD/LoadLYJD_JDZSYDJBXX",
        dataType: "json",
        data:
        {
            LYJD_JDZSYDJBXXID: getUrlParam("LYJD_JDZSYDJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.LYJD_JDZSYDJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#LYJD_JDZSYDJBXXID").val(xml.Value.LYJD_JDZSYDJBXX.LYJD_JDZSYDJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.LYJD_JDZSYDJBXX.FWJS);
                });
                $("#spanLB").html(xml.Value.LYJD_JDZSYDJBXX.LB);
                $("#spanQY").html(xml.Value.LYJD_JDZSYDJBXX.QY);
                $("#spanDD").html(xml.Value.LYJD_JDZSYDJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                LoadXL(xml.Value.LYJD_JDZSYDJBXX.LB, xml.Value.LYJD_JDZSYDJBXX.XL);
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
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + GetXL() + "'");

    if (getUrlParam("LYJD_JDZSYDJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "LYJD_JDZSYDJBXXID", "'" + getUrlParam("LYJD_JDZSYDJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LYJD_JDZSYD/FB",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            FWJS: ue.getContent(),
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