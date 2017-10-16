﻿var isleave = true;
var xlts = UE.getEditor('XLTS');
var xcap = UE.getEditor('XCAP');
var ydxz = UE.getEditor('YDXZ');
var fybh = UE.getEditor('FYBH');
var zfxm = UE.getEditor('ZFXM');
$(document).ready(function () {
    $(".div_radio").bind("click", RadioSelect);
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    $("#XCAP").bind("focus", XCAPFocus);
    $("#XCAP").bind("blur", XCAPBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qCWFWs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);
    LoadTXXX();
    LoadDefault();
    BindClick("CYFS");
    BindClick("QY");
    BindClick("DD");
    BindClick("WFJT_Q");
    BindClick("WFJT_H");
    BindClick("XCTS_R");
    BindClick("XCTS_W");
    LoadLYJD_GNYJBXX();
    FYMSSetDefault();
});
//描述框focus
function XCAPFocus() {
    $("#XCAP").html("");
}
//描述框blur
function XCAPBlur() {
    $("#XCAP").css("color", "#999999");
}
//描述框设默认文本
function FYMSSetDefault() {
    var xcap = '<span style="color: gray;font-size:12px;">请详细描述游玩的行程安排，包含住宿、用餐、游玩景点、费用说明、注意事项等，认真填写游玩描述会达到双倍的效果</span>';
    $("#XCAP").html(xcap);
}
//加载默认
function LoadDefault() {
    xlts.ready(function () { xlts.setHeight(100); });
    xcap.ready(function () { xcap.setHeight(200); });
    ydxz.ready(function () { ydxz.setHeight(100); });
    fybh.ready(function () { fybh.setHeight(100); });
    zfxm.ready(function () { zfxm.setHeight(100); });
    $(".iFWCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "CYFS") {
            LoadDropdown("出游方式", "CYFS"); 
        }
        if (type === "WFJT_Q") {
            LoadDropdown("往返交通_去", "WFJT_Q");
        }
        if (type === "WFJT_H") {
            LoadDropdown("往返交通_回", "WFJT_H");
        }
        if (type === "XCTS_R") {
            LoadDropdown("行程安排_日", "XCTS_R");
        }
        if (type === "XCTS_W") {
            LoadDropdown("行程安排_晚", "XCTS_W");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载出游方式
function LoadDropdown(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_LYJD",
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
//加载旅游酒店_国内游基本信息
function LoadLYJD_GNYJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LYJD_GNY/LoadLYJD_GNYJBXX",
        dataType: "json",
        data:
        {
            LYJD_GNYJBXXID: getUrlParam("LYJD_GNYJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.LYJD_GNYJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#LYJD_GNYJBXXID").val(xml.Value.LYJD_GNYJBXX.LYJD_GNYJBXXID);
                //设置编辑器的内容
                xlts.ready(function () { xlts.setContent(xml.Value.LYJD_GNYJBXX.XLTS); });
                xcap.ready(function () { xcap.setContent(xml.Value.LYJD_GNYJBXX.XCAP); });
                if (xml.Value.LYJD_GNYJBXX.YDXZ !== null)
                ydxz.ready(function () { ydxz.setContent(xml.Value.LYJD_GNYJBXX.YDXZ); });
                fybh.ready(function () { fybh.setContent(xml.Value.LYJD_GNYJBXX.FYBH); });
                zfxm.ready(function () { zfxm.setContent(xml.Value.LYJD_GNYJBXX.ZFXM); });

                $("#spanCYFS").html(xml.Value.LYJD_GNYJBXX.CYFS);
                $("#spanWFJT_Q").html(xml.Value.LYJD_GNYJBXX.WFJT_Q);
                $("#spanWFJT_H").html(xml.Value.LYJD_GNYJBXX.WFJT_H);
                $("#spanXCTS_R").html(xml.Value.LYJD_GNYJBXX.XCTS_R);
                $("#spanXCTS_W").html(xml.Value.LYJD_GNYJBXX.XCTS_W);
                $("#spanQY").html(xml.Value.LYJD_GNYJBXX.QY);
                $("#spanDD").html(xml.Value.LYJD_GNYJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.LYJD_GNYJBXX.FTRQ !== null)
                    SetDX("FTRQ", xml.Value.LYJD_GNYJBXX.FTRQ);
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
    obj = jsonObj.AddJson(obj, "CYFS", "'" + $("#spanCYFS").html() + "'");
    obj = jsonObj.AddJson(obj, "WFJT_Q", "'" + $("#spanWFJT_Q").html() + "'");
    obj = jsonObj.AddJson(obj, "WFJT_H", "'" + $("#spanWFJT_H").html() + "'");
    obj = jsonObj.AddJson(obj, "XCTS_R", "'" + $("#spanXCTS_R").html() + "'");
    obj = jsonObj.AddJson(obj, "XCTS_W", "'" + $("#spanXCTS_W").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "FTRQ", "'" + GetDX("FTRQ") + "'");

    if (getUrlParam("LYJD_GNYJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "LYJD_GNYJBXXID", "'" + getUrlParam("LYJD_GNYJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LYJD_GNY/FB",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            XLTS: xlts.getContent(),
            XCAP: xcap.getContent(),
            YDXZ: ydxz.getContent(),
            FYBH: fybh.getContent(),
            ZFXM: zfxm.getContent(),
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