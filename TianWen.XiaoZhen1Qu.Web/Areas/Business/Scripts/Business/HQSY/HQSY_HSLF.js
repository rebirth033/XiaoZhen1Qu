﻿var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $(".div_radio").bind("click", RadioSelect);
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
    BindClick("YS");
    BindClick("LX");
    BindClick("CZ");
    BindClick("QY");
    BindClick("DD");
    LoadHQSY_HSLFJBXX();
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
    ue.ready(function () { ue.setHeight(200); });
    $(".iFWCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "YS") {
            LoadDropdown("婚纱礼服颜色", "YS");
        }
        if (type === "LX") {
            LoadDropdown("婚纱礼服类型", "LX");
        }
        if (type === "CZ") {
            LoadDropdown("婚纱礼服材质", "CZ");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载婚纱礼服类别
function LoadDropdown(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_HQSY",
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
function SelectLB(obj, type, lbid) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#LBID").val(lbid);
}
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_HQSY",
        dataType: "json",
        data:
        {
            TYPENAME: type
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 3 || i === 7 || i === 11) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 4) * 45 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 4) + 1) * 45 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadHQSY_HSLFJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载婚庆摄影_婚纱礼服基本信息
function LoadHQSY_HSLFJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY_HSLF/LoadHQSY_HSLFJBXX",
        dataType: "json",
        data:
        {
            HQSY_HSLFJBXXID: getUrlParam("HQSY_HSLFJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.HQSY_HSLFJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#HQSY_HSLFJBXXID").val(xml.Value.HQSY_HSLFJBXX.HQSY_HSLFJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.HQSY_HSLFJBXX.BCMS);
                });
                $("#spanGPLX").html(xml.Value.HQSY_HSLFJBXX.GPLX);
                $("#spanQY").html(xml.Value.HQSY_HSLFJBXX.QY);
                $("#spanDD").html(xml.Value.HQSY_HSLFJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "YS", "'" + $("#spanYS").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");

    if (getUrlParam("HQSY_HSLFJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "HQSY_HSLFJBXXID", "'" + getUrlParam("HQSY_HSLFJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY_HSLF/FB",
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