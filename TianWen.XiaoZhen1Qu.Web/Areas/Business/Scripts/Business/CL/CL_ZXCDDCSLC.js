var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#div_upload").bind("mouseover", GetUploadCss);
    $("#div_upload").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qhcs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("LB"); Close("XL"); Close("DCDY"); Close("DCRL"); Close("CC"); Close("XJ"); Close("QY"); Close("DD"); });




    LoadDefault();
    LoadCL_ZXCDDCSLCJBXX();
    BindClick("LB");
    BindClick("XJ");
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
//加载图形信息
function LoadTXXX() {
    $("#spanTXXX").css("color", "#5bc0de");
    $("#emTXXX").css("background", "#5bc0de");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LBXZ/LoadLBByID",
        dataType: "json",
        data:
        {
            LBID: getUrlParam("CLICKID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                if (xml.list.length > 0)
                    $("#spanLBXZ").html("1." + xml.list[0].LBNAME);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

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
    if (LB === "自行车") {
        $("#divZXCXXCS").css("display", "");
        $("#divDDCXXCS").css("display", "none");
        BindClick("ZXCPP");
        BindClick("CC");
        LoadCODESByTYPENAME("自行车品牌", "ZXCPP", "CODES_CL");
        LoadCODESByTYPENAME("自行车尺寸", "CC", "CODES_CL");
    }
    else if (LB === "电动车") {
        $("#divZXCXXCS").css("display", "none");
        $("#divDDCXXCS").css("display", "");
        BindClick("DDCPP");
        BindClick("DCDY");
        BindClick("DCRL");
        LoadCODESByTYPENAME("电动车品牌", "DDCPP", "CODES_CL");
        LoadCODESByTYPENAME("电池电压", "DCDY", "CODES_CL");
        LoadCODESByTYPENAME("电池容量", "DCRL", "CODES_CL");
    }
    else {
        $("#divZXCXXCS").css("display", "none");
        $("#divDDCXXCS").css("display", "none");
    }
    BindClick("XL");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("自行车/电动车/三轮车", "LB", "CODES_CL");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_CL");
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
//选择自行车/电动车/三轮车品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载车辆_自行车/电动车/三轮车基本信息
function LoadCL_ZXCDDCSLCJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL_ZXCDDCSLC/LoadCL_ZXCDDCSLCJBXX",
        dataType: "json",
        data:
        {
            CL_ZXCDDCSLCJBXXID: getUrlParam("CL_ZXCDDCSLCJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_ZXCDDCSLCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#CL_ZXCDDCSLCJBXXID").val(xml.Value.CL_ZXCDDCSLCJBXX.CL_ZXCDDCSLCJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.CL_ZXCDDCSLCJBXX.BCMS);
                });
                $("#spanLB").html(xml.Value.CL_ZXCDDCSLCJBXX.LB);
                $("#spanXJ").html(xml.Value.CL_ZXCDDCSLCJBXX.XJ);
                $("#spanQY").html(xml.Value.CL_ZXCDDCSLCJBXX.JYQY);
                $("#spanSQ").html(xml.Value.CL_ZXCDDCSLCJBXX.JYDD);
                $("#spanDDCPP").html(xml.Value.CL_ZXCDDCSLCJBXX.DDCPP);
                $("#spanZXCPP").html(xml.Value.CL_ZXCDDCSLCJBXX.ZXCPP);
                $("#spanCC").html(xml.Value.CL_ZXCDDCSLCJBXX.CC);
                $("#spanDCDY").html(xml.Value.CL_ZXCDDCSLCJBXX.DCDY);
                $("#spanDCRL").html(xml.Value.CL_ZXCDDCSLCJBXX.DCRL);
                $("#spanXL").html(xml.Value.CL_ZXCDDCSLCJBXX.XL);
                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.CL_ZXCDDCSLCJBXX.LB);
                if (xml.Value.ES_SJSM_PBDNJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_SJSM_PBDNJBXX.GQ);
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
    obj = jsonObj.AddJson(obj, "DDCPP", "'" + $("#spanDDCPP").html() + "'");
    obj = jsonObj.AddJson(obj, "ZXCPP", "'" + $("#spanZXCPP").html() + "'");
    obj = jsonObj.AddJson(obj, "CC", "'" + $("#spanCC").html() + "'");
    obj = jsonObj.AddJson(obj, "DCDY", "'" + $("#spanDCDY").html() + "'");
    obj = jsonObj.AddJson(obj, "DCRL", "'" + $("#spanDCRL").html() + "'");
    obj = jsonObj.AddJson(obj, "JYQY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "JYDD", "'" + $("#spanSQ").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if (getUrlParam("CL_ZXCDDCSLCJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "CL_ZXCDDCSLCJBXXID", "'" + getUrlParam("CL_ZXCDDCSLCJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL_ZXCDDCSLC/FB",
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
