var isleave = true;
var xlts = UE.getEditor('XLTS');
var xcap = UE.getEditor('XCAP');
var ydxz = UE.getEditor('YDXZ');
var fybh = UE.getEditor('FYBH');
var zfxm = UE.getEditor('ZFXM');
$(document).ready(function () {
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
    LoadLYJD_CJYJBXX();
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
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "CYFS") {
            LoadCODESByTYPENAME("出游方式", "CYFS", "CODES_LYJD");
        }
        if (type === "WFJT_Q") {
            LoadCODESByTYPENAME("往返交通_去", "WFJT_Q", "CODES_LYJD");
        }
        if (type === "WFJT_H") {
            LoadCODESByTYPENAME("往返交通_回", "WFJT_H", "CODES_LYJD");
        }
        if (type === "XCTS_R") {
            LoadCODESByTYPENAME("行程安排_日", "XCTS_R", "CODES_LYJD");
        }
        if (type === "XCTS_W") {
            LoadCODESByTYPENAME("行程安排_晚", "XCTS_W", "CODES_LYJD");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载旅游酒店_出境游基本信息
function LoadLYJD_CJYJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LYJD_CJY/LoadLYJD_CJYJBXX",
        dataType: "json",
        data:
        {
            LYJD_CJYJBXXID: getUrlParam("LYJD_CJYJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.LYJD_CJYJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#LYJD_CJYJBXXID").val(xml.Value.LYJD_CJYJBXX.LYJD_CJYJBXXID);
                //设置编辑器的内容
                xlts.ready(function () { xlts.setContent(xml.Value.LYJD_CJYJBXX.XLTS); });
                xcap.ready(function () { xcap.setContent(xml.Value.LYJD_CJYJBXX.XCAP); });
                if (xml.Value.LYJD_CJYJBXX.YDXZ !== null)
                    ydxz.ready(function () { ydxz.setContent(xml.Value.LYJD_CJYJBXX.YDXZ); });
                fybh.ready(function () { fybh.setContent(xml.Value.LYJD_CJYJBXX.FYBH); });
                zfxm.ready(function () { zfxm.setContent(xml.Value.LYJD_CJYJBXX.ZFXM); });

                $("#spanCYFS").html(xml.Value.LYJD_CJYJBXX.CYFS);
                $("#spanWFJT_Q").html(xml.Value.LYJD_CJYJBXX.WFJT_Q);
                $("#spanWFJT_H").html(xml.Value.LYJD_CJYJBXX.WFJT_H);
                $("#spanXCTS_R").html(xml.Value.LYJD_CJYJBXX.XCTS_R);
                $("#spanXCTS_W").html(xml.Value.LYJD_CJYJBXX.XCTS_W);
                $("#spanQY").html(xml.Value.LYJD_CJYJBXX.QY);
                $("#spanDD").html(xml.Value.LYJD_CJYJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.LYJD_CJYJBXX.FTRQ !== null)
                    SetDX("FTRQ", xml.Value.LYJD_CJYJBXX.FTRQ);
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

    if (getUrlParam("LYJD_CJYJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "LYJD_CJYJBXXID", "'" + getUrlParam("LYJD_CJYJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LYJD_CJY/FB",
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