var isleave = true;
var xlts = UE.getEditor('XLTS');
var xcap = UE.getEditor('XCAP');
var ydxz = UE.getEditor('YDXZ');
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
    $(".iFWCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "CYFS") {
            LoadCYFS();
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
function LoadCYFS() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_LYJD",
        dataType: "json",
        data:
        {
            TYPENAME: "出游方式"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"CYFS\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divCYFS").html(html);
                $("#divCYFS").css("display", "block");
                ActiveStyle("CYFS");
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
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.LYJD_GNYJBXX.BCMS);
                });
                $("#spanLB").html(xml.Value.LYJD_GNYJBXX.LB);
                $("#spanQY").html(xml.Value.LYJD_GNYJBXX.QY);
                $("#spanDD").html(xml.Value.LYJD_GNYJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                LoadXL(xml.Value.LYJD_GNYJBXX.LB, xml.Value.LYJD_GNYJBXX.XL);
                if (xml.Value.LYJD_GNYJBXX.CD !== null)
                    SetDuoX("CD", xml.Value.LYJD_GNYJBXX.CD);
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
    obj = jsonObj.AddJson(obj, "XL", "'" + GetDuoX("XL") + "'");
    obj = jsonObj.AddJson(obj, "CD", "'" + GetDuoX("CD") + "'");

    if (getUrlParam("LYJD_GNYJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "LYJD_GNYJBXXID", "'" + getUrlParam("LYJD_GNYJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LYJD_GNY/FB",
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