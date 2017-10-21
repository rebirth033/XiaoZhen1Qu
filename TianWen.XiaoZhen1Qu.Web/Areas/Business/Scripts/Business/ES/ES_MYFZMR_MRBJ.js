var isleave = true;
var ue = UE.getEditor('BCMS');
$(document).ready(function () {
    
    
    $("#btnFB").bind("click", FB);
    $("#BCMS").bind("focus", BCMSFocus);
    $("#BCMS").bind("blur", BCMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    
    $("body").bind("click", function () { Close("_XZQ"); Close("LB"); Close("XL"); Close("XJ"); Close("QY"); Close("DD"); });



    LoadDefault();
    LoadES_MYFZMR_MRBJJBXX();
    BindClick("LB");
    BindClick("XJ");
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
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("美容/保健", "LB", "CODES_ES_MYFZMR");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_MYFZMR");
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM");
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
function PDLB(LB) {
    BindClick("XL");
}
//选择母婴/服装/美容品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载二手_手机数码_母婴/服装/美容基本信息
function LoadES_MYFZMR_MRBJJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_MYFZMR_MRBJ/LoadES_MYFZMR_MRBJJBXX",
        dataType: "json",
        data:
        {
            ES_MYFZMR_MRBJJBXXID: getUrlParam("ES_MYFZMR_MRBJJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_MYFZMR_MRBJJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_MYFZMR_MRBJJBXXID").val(xml.Value.ES_MYFZMR_MRBJJBXX.ES_MYFZMR_MRBJJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.ES_SJSM_PBDNJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_SJSM_PBDNJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_MYFZMR_MRBJJBXX.LB);
                $("#spanXL").html(xml.Value.ES_MYFZMR_MRBJJBXX.XL);
                $("#spanXJ").html(xml.Value.ES_MYFZMR_MRBJJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_MYFZMR_MRBJJBXX.JYQY);
                $("#spanSQ").html(xml.Value.ES_MYFZMR_MRBJJBXX.JYDD);

                $("#spanDSPMCC").html(xml.Value.ES_MYFZMR_MRBJJBXX.DSPMCC);
                $("#spanDSPP").html(xml.Value.ES_MYFZMR_MRBJJBXX.DSPP);
                $("#spanXYJPP").html(xml.Value.ES_MYFZMR_MRBJJBXX.XYJPP);
                $("#spanKTPP").html(xml.Value.ES_MYFZMR_MRBJJBXX.KTPP);
                $("#spanKTBPDS").html(xml.Value.ES_MYFZMR_MRBJJBXX.KTBPDS);
                $("#spanKTGL").html(xml.Value.ES_MYFZMR_MRBJJBXX.KTGL);
                $("#spanBXPP").html(xml.Value.ES_MYFZMR_MRBJJBXX.BXPP);
                $("#spanBGPP").html(xml.Value.ES_MYFZMR_MRBJJBXX.BGPP);

                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_MYFZMR_MRBJJBXX.LB);
                
                return;
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
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "XJ", "'" + $("#spanXJ").html() + "'");
    obj = jsonObj.AddJson(obj, "JYQY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "JYDD", "'" + $("#spanSQ").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    obj = jsonObj.AddJson(obj, "DSPMCC", "'" + $("#spanDSPMCC").html() + "'");
    obj = jsonObj.AddJson(obj, "DSPP", "'" + $("#spanDSPP").html() + "'");
    obj = jsonObj.AddJson(obj, "XYJPP", "'" + $("#spanXYJPP").html() + "'");
    obj = jsonObj.AddJson(obj, "KTPP", "'" + $("#spanKTPP").html() + "'");
    obj = jsonObj.AddJson(obj, "KTBPDS", "'" + $("#spanKTBPDS").html() + "'");
    obj = jsonObj.AddJson(obj, "KTGL", "'" + $("#spanKTGL").html() + "'");
    obj = jsonObj.AddJson(obj, "BXPP", "'" + $("#spanBXPP").html() + "'");
    obj = jsonObj.AddJson(obj, "BGPP", "'" + $("#spanBGPP").html() + "'");

    if (getUrlParam("ES_MYFZMR_MRBJJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_MYFZMR_MRBJJBXXID", "'" + getUrlParam("ES_MYFZMR_MRBJJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_MYFZMR_MRBJ/FB",
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
