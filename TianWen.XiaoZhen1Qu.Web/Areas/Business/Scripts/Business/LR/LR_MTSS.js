var isleave = true;
var ue = UE.getEditor('BCMS');
$(document).ready(function () {
    
    
    $("#btnFB").bind("click", FB);
    $("#BCMS").bind("focus", BCMSFocus);
    $("#BCMS").bind("blur", BCMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qCWFWs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });



    LoadLR_MTSSJBXX();
    LoadDefault();
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
});
//描述框focus
function BCMSFocus() {
    $("#BCMS").css("color", "#333333");
}
//描述框blur
function BCMSBlur() {
    $("#BCMS").css("color", "#999999");
}
//描述框设默认文本
function BCMSSetDefault() {
    var BCMS = "1.房屋特征：\r\n\r\n2.周边配套：\r\n\r\n3.房东心态：";
    $("#BCMS").html(BCMS);
}
//加载默认
function LoadDefault() {
    ue.ready(function () {
        ue.setHeight(200);
    });
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    PDLB(obj.innerHTML);
}
//判断类别
function PDLB(LB) {
    if (LB === "减肥") {
        $("#divJFFS").css("display", "");
        BindClick("FS");
    } else {
        $("#divJFFS").css("display", "none");
    }
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("美体瘦身", "LB", "CODES_LR");
        }
        if (type === "FS") {
            LoadCODESByTYPENAME("减肥方式", "FS", "CODES_LR");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载丽人_美体瘦身基本信息
function LoadLR_MTSSJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LR_MTSS/LoadLR_MTSSJBXX",
        dataType: "json",
        data:
        {
            LR_MTSSJBXXID: getUrlParam("LR_MTSSJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.LR_MTSSJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#LR_MTSSJBXXID").val(xml.Value.LR_MTSSJBXX.LR_MTSSJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.LR_MTSSJBXX.LB);
                $("#spanQY").html(xml.Value.LR_MTSSJBXX.QY);
                $("#spanDD").html(xml.Value.LR_MTSSJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("LR_MTSSJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "LR_MTSSJBXXID", "'" + getUrlParam("LR_MTSSJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LR_MTSS/FB",
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