var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 900) / 2);
    $(".div_head").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $(".div_content").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $("#spanCXLB").bind("click", CXLB);
    $("#imgSJZR").bind("click", SJZRSelect);
    $("#imgSJHS").bind("click", SJHSSelect);
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qhcs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("LB"); Close("XL"); Close("XJ"); Close("QY"); Close("DD"); });
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);

    LoadTXXX();
    LoadSMCPLB();
    LoadDefault();
    LoadES_SJSM_SMCPJBXX();
    BindClick("LB");
    BindClick("PBPP");
    BindClick("PBXH");
    BindClick("XJ");
    BindClick("QY");
    BindClick("SQ");
});
//房屋描述框focus
function FYMSFocus() {
    $("#FYMS").css("color", "#333333");
}
//房屋描述框blur
function FYMSBlur() {
    $("#FYMS").css("color", "#999999");
}
//房屋描述框设默认文本
function FYMSSetDefault() {
    var fyms = "1.房屋特征：\r\n\r\n2.周边配套：\r\n\r\n3.房东心态：";
    $("#FYMS").html(fyms);
}
//加载默认
function LoadDefault() {
    ue.ready(function () {
        ue.setHeight(200);
    });
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSJHS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgSYG").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgQXWCF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择商家转让
function SJZRSelect() {
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSJHS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择商家回收
function SJHSSelect() {
    $("#imgSJHS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadSMCPLB();
        }
        if (type === "XL") {
            LoadSMCPXL();
        }
        if (type === "XJ") {
            LoadXJ();
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载数码产品类别
function LoadSMCPLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_SJSM",
        dataType: "json",
        data:
        {
            TYPENAME: "数码产品类别"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"LB\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divLB").html(html);
                $("#divLB").css("display", "block");
                ActiveStyle("LB");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载数码产品小类
function LoadSMCPXL(type) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_SJSM",
        dataType: "json",
        data:
        {
            TYPENAME: type
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"XL\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divXL").html(html);
                $("#divXL").css("display", "block");
                ActiveStyle("XL");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载数码产品新旧
function LoadXJ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES",
        dataType: "json",
        data:
        {
            TYPENAME: "新旧程度"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"XJ\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divXJ").html(html);
                $("#divXJ").css("display", "block");
                ActiveStyle("XJ");
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
    LoadSMCPXL(LB);
    BindClick("XL");
}
//选择数码产品品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//获取供求
function GetGQ() {
    if ($("#imgSJZR").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置供求
function SetGQ(gq) {
    if (gq === 0) {
        $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgSJHS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgSJHS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//加载二手_手机数码_数码产品基本信息
function LoadES_SJSM_SMCPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_SJSM_SMCP/LoadES_SJSM_SMCPJBXX",
        dataType: "json",
        data:
        {
            ES_SJSM_SMCPJBXXID: getUrlParam("ES_SJSM_SMCPJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_SJSM_SMCPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_SJSM_SMCPJBXXID").val(xml.Value.ES_SJSM_SMCPJBXX.ES_SJSM_SMCPJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.ES_SJSM_SMCPJBXX.BCMS);
                });
                SetGQ(xml.Value.ES_SJSM_SMCPJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_SJSM_SMCPJBXX.LB);
                $("#spanXJ").html(xml.Value.ES_SJSM_SMCPJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_SJSM_SMCPJBXX.JYQY);
                $("#spanDD").html(xml.Value.ES_SJSM_SMCPJBXX.JYDD);
                $("#spanXL").html(xml.Value.ES_SJSM_SMCPJBXX.XL);
                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_SJSM_SMCPJBXX.LB);
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
    obj = jsonObj.AddJson(obj, "JYDD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetGQ() + "'");

    if (getUrlParam("ES_SJSM_SMCPJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_SJSM_SMCPJBXXID", "'" + getUrlParam("ES_SJSM_SMCPJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_SJSM_SMCP/FB",
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
