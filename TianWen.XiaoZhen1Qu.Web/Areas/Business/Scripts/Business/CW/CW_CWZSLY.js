﻿var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#imgZS").bind("click", ZSSelect);
    $("#imgLY").bind("click", LYSelect);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qCWZSLYs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);
    LoadTXXX();
    LoadDefault();
    LoadCW_CWZSLYJBXX();
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
    $("#imgZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgLY").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择赠送
function ZSSelect() {
    $("#imgZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgLY").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择领养
function LYSelect() {
    $("#imgZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgLY").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}
//获取供求
function GetGQ() {
    if ($("#imgZS").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置供求
function SetGQ(GQ) {
    if (GQ === 0) {
        $("#imgZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgLY").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgLY").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
}
//加载宠物_宠物猫基本信息
function LoadCW_CWZSLYJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CW_CWZSLY/LoadCW_CWZSLYJBXX",
        dataType: "json",
        data:
        {
            CW_CWZSLYJBXXID: getUrlParam("CW_CWZSLYJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CW_CWZSLYJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#CW_CWZSLYJBXXID").val(xml.Value.CW_CWZSLYJBXX.CW_CWZSLYJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.CW_CWZSLYJBXX.BCMS);
                });
                SetGQ(xml.Value.CW_CWZSLYJBXX.GQ);
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
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetGQ() + "'");

    if (getUrlParam("CW_CWZSLYJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "CW_CWZSLYJBXXID", "'" + getUrlParam("CW_CWZSLYJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CW_CWZSLY/FB",
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