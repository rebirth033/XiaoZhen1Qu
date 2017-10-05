﻿var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#imgLS").bind("click", LSSelect);
    $("#imgLSSWS").bind("click", LSSWSSelect);
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
    LoadFLZXLB();
    LoadDefault();
    BindClick("QY");
    BindClick("DD");
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
    $("#imgLS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgLSSWS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择律师
function LSSelect() {
    $("#imgLS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgLSSWS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#divZYZH").css("display", "");
    $("#divZYJG").css("display", "");
}
//选择律师事务所
function LSSWSSelect() {
    $("#imgLS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgLSSWS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#divZYZH").css("display", "none");
    $("#divZYJG").css("display", "none");
}
//获取来源
function GetLY() {
    if ($("#imgLS").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置来源
function SetLY(sfsm) {
    if (sfsm === 0) {
        $("#imgLS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgLSSWS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgLS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgLSSWS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//加载法律咨询类别
function LoadFLZXLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_SWFW",
        dataType: "json",
        data:
        {
            TYPENAME: "法律咨询"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liFLZXLB' onclick='SelectFLZXLB(this)'><img class='img_FLZXLB'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 3 || i === 7 || i === 11 || i === 15 || i === 19) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divFLZXLB").css("height", parseInt(xml.list.length / 4) * 45 + "px");
                else
                    $("#divFLZXLB").css("height", (parseInt(xml.list.length / 4) + 1) * 45 + "px");
                html += "</ul>";
                $("#divFLZXLBText").html(html);
                $(".img_FLZXLB").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadSWFW_FLZXJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择法律咨询
function SelectFLZXLB(obj) {
    if ($(obj).find("img").attr("src").indexOf("blue") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
}
//获取法律咨询类别
function GetFLZXLB() {
    var FLZXLB = "";
    $(".liFLZXLB").each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            FLZXLB += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(FLZXLB, ',');
}
//设置法律咨询类别
function SetFLZXLB(lbs) {
    var lbarray = lbs.split(',');
    for (var i = 0; i < lbarray.length; i++) {
        $(".liFLZXLB").each(function () {
            if ($(this).find("label")[0].innerHTML.indexOf(lbarray[i]) !== -1)
                $(this).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
        });
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
//加载商务服务_法律咨询基本信息
function LoadSWFW_FLZXJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW_FLZX/LoadSWFW_FLZXJBXX",
        dataType: "json",
        data:
        {
            SWFW_FLZXJBXXID: getUrlParam("SWFW_FLZXJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SWFW_FLZXJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SWFW_FLZXJBXXID").val(xml.Value.SWFW_FLZXJBXX.SWFW_FLZXJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.SWFW_FLZXJBXX.BCMS);
                });
                SetFLZXLB(xml.Value.SWFW_FLZXJBXX.LB);
                SetLY(xml.Value.SWFW_FLZXJBXX.LY);
                $("#spanQY").html(xml.Value.SWFW_FLZXJBXX.QY);
                $("#spanDD").html(xml.Value.SWFW_FLZXJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "LB", "'" + GetFLZXLB() + "'");
    obj = jsonObj.AddJson(obj, "LY", "'" + GetLY() + "'");

    if (getUrlParam("SWFW_FLZXJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SWFW_FLZXJBXXID", "'" + getUrlParam("SWFW_FLZXJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW_FLZX/FB",
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