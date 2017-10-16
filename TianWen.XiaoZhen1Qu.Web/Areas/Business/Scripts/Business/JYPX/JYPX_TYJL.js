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
    BindClick("JXKM");
    BindClick("QY");
    BindClick("DD");
    LoadJYPX_TYJLJBXX();
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
    $(".iFWCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//加载体育教练教学科目
function LoadJXKM() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_JYPX",
        dataType: "json",
        data:
        {
            TYPENAME: "体育培训教学科目"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"JXKM\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divJXKM").html(html);
                $("#divJXKM").css("display", "block");
                ActiveStyle("JXKM");
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
    LoadXL($("#spanYZ").html());
    $("#divXL").css("display", "");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "JXKM") {
            LoadJXKM();
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载教育培训_体育教练基本信息
function LoadJYPX_TYJLJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/JYPX_TYJL/LoadJYPX_TYJLJBXX",
        dataType: "json",
        data:
        {
            JYPX_TYJLJBXXID: getUrlParam("JYPX_TYJLJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JYPX_TYJLJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#JYPX_TYJLJBXXID").val(xml.Value.JYPX_TYJLJBXX.JYPX_TYJLJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.JYPX_TYJLJBXX.BCMS);
                });
                $("#spanJXKM").html(xml.Value.JYPX_TYJLJBXX.JXKM);
                $("#spanQY").html(xml.Value.JYPX_TYJLJBXX.QY);
                $("#spanDD").html(xml.Value.JYPX_TYJLJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                SetDX("SF", xml.Value.JYPX_TYJLJBXX.SF);
                SetDX("JJJY", xml.Value.JYPX_TYJLJBXX.JJJY);
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
    obj = jsonObj.AddJson(obj, "JXKM", "'" + $("#spanJXKM").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("SF") + "'");
    obj = jsonObj.AddJson(obj, "JJJY", "'" + GetDX("JJJY") + "'");

    if (getUrlParam("JYPX_TYJLJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "JYPX_TYJLJBXXID", "'" + getUrlParam("JYPX_TYJLJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/JYPX_TYJL/FB",
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