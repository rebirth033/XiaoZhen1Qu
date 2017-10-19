var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
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



    LoadDefault();
    LoadSHFW_CLFW_QCMRZSJBXX();
    BindClick("LB");
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
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("汽车美容/装饰", "LB", "CODES_SHFW");
        }
        if (type === "XCDD") {
            LoadCODESByTYPENAME("洗车地点", "XCDD", "CODES_SHFW");
        }
        if (type === "XCFS") {
            LoadCODESByTYPENAME("洗车方式", "XCFS", "CODES_SHFW");
        }
        if (type === "PP") {
            LoadCODESByTYPENAME($("#spanLB").html(), "PP", "CODES_SHFW");
        }
        if (type === "PZ") {
            LoadCODESByTYPENAME("打蜡品种", "PZ", "CODES_SHFW");
        }
        if (type === "TMFW") {
            LoadCODESByTYPENAME("贴膜范围", "TMFW", "CODES_SHFW");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    PDLB(obj.innerHTML);
}
//判断类别
function PDLB(lbmc) {
    if (lbmc === "洗车") {
        $("#divQCMRZSXCDD").css("display", "");
        $("#divQCMRZSXCFS").css("display", "");
        $("#divQCMRZSPP").css("display", "none");
        $("#divQCMRZSPZ").css("display", "none");
        $("#divQCMRZSTMFW").css("display", "none");
        BindClick("XCDD");
        BindClick("XCFS");
    }
    if (lbmc === "打蜡") {
        $("#divQCMRZSXCDD").css("display", "none");
        $("#divQCMRZSXCFS").css("display", "none");
        $("#divQCMRZSPP").css("display", "");
        $("#spanPP").html("请选择品牌");
        $("#divQCMRZSPZ").css("display", "");
        $("#divQCMRZSTMFW").css("display", "none");
        BindClick("PP");
        BindClick("PZ");
    }
    if (lbmc === "镀膜" || lbmc === "封釉" || lbmc === "座椅包真皮" || lbmc === "底盘装甲") {
        $("#divQCMRZSXCDD").css("display", "none");
        $("#divQCMRZSXCFS").css("display", "none");
        $("#divQCMRZSPP").css("display", "");
        $("#spanPP").html("请选择品牌");
        $("#divQCMRZSPZ").css("display", "none");
        $("#divQCMRZSTMFW").css("display", "none");
        BindClick("PP");
    }
    if (lbmc === "玻璃贴膜") {
        $("#divQCMRZSXCDD").css("display", "none");
        $("#divQCMRZSXCFS").css("display", "none");
        $("#divQCMRZSPP").css("display", "");
        $("#spanPP").html("请选择品牌");
        $("#divQCMRZSPZ").css("display", "none");
        $("#divQCMRZSTMFW").css("display", "");
        BindClick("PP");
        BindClick("TMFW");
    }
    if (lbmc === "内饰清洗" || lbmc === "大灯翻新" || lbmc === "空调清洗" || lbmc === "真皮座椅保养" || lbmc === "汽车精品") {
        $("#divQCMRZSXCDD").css("display", "none");
        $("#divQCMRZSXCFS").css("display", "none");
        $("#divQCMRZSPP").css("display", "none");
        $("#divQCMRZSPZ").css("display", "none");
        $("#divQCMRZSTMFW").css("display", "none");
    }
}
//加载生活服务_汽车美容/装饰基本信息
function LoadSHFW_CLFW_QCMRZSJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_CLFW_QCMRZS/LoadSHFW_CLFW_QCMRZSJBXX",
        dataType: "json",
        data:
        {
            SHFW_CLFW_QCMRZSJBXXID: getUrlParam("SHFW_CLFW_QCMRZSJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SHFW_CLFW_QCMRZSJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SHFW_CLFW_QCMRZSJBXXID").val(xml.Value.SHFW_CLFW_QCMRZSJBXX.SHFW_CLFW_QCMRZSJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.SHFW_CLFW_QCMRZSJBXX.BCMS);
                });
                PDLB(xml.Value.SHFW_CLFW_QCMRZSJBXX.LB);
                $("#spanLB").html(xml.Value.SHFW_CLFW_QCMRZSJBXX.LB);
                $("#spanXCDD").html(xml.Value.SHFW_CLFW_QCMRZSJBXX.XCDD);
                $("#spanXCFS").html(xml.Value.SHFW_CLFW_QCMRZSJBXX.XCFS);
                $("#spanPP").html(xml.Value.SHFW_CLFW_QCMRZSJBXX.PP);
                $("#spanPZ").html(xml.Value.SHFW_CLFW_QCMRZSJBXX.PZ);
                $("#spanTMFW").html(xml.Value.SHFW_CLFW_QCMRZSJBXX.TMFW);
                $("#spanQY").html(xml.Value.SHFW_CLFW_QCMRZSJBXX.QY);
                $("#spanDD").html(xml.Value.SHFW_CLFW_QCMRZSJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "XCDD", "'" + $("#spanXCDD").html() + "'");
    obj = jsonObj.AddJson(obj, "XCFS", "'" + $("#spanXCFS").html() + "'");
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanPP").html() + "'");
    obj = jsonObj.AddJson(obj, "PZ", "'" + $("#spanPZ").html() + "'");
    obj = jsonObj.AddJson(obj, "TMFW", "'" + $("#spanTMFW").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");

    if (getUrlParam("SHFW_CLFW_QCMRZSJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SHFW_CLFW_QCMRZSJBXXID", "'" + getUrlParam("SHFW_CLFW_QCMRZSJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_CLFW_QCMRZS/FB",
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