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
    LoadESJJLB();
    LoadDefault();
    LoadES_JDJJBG_ESJJJBXX();
    BindClick("LB");
    BindClick("PBPP");
    BindClick("PBXH");
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
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSJHS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
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
            LoadESJJLB();
        }
        if (type === "XL") {
            LoadESJJXL();
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
//加载二手家具类别
function LoadESJJLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_JDJJBG",
        dataType: "json",
        data:
        {
            TYPENAME: "二手家具"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;height:340px;'>";
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
//加载二手家具小类
function LoadESJJXL(type) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_JDJJBG",
        dataType: "json",
        data:
        {
            TYPENAME: type
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"XL\")'>" + xml.list[i].CODENAME + "</li>";
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
//加载二手家具详细参数
function LoadXXCS(id, type) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_JDJJBG",
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
//加载二手家具新旧
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
    if (LB === "床") {
        $("#divCXXCS").css("display", "");
        $("#divCDXXCS").css("display", "none");
        LoadXXCS("CCC", "床尺寸");
        BindHover("CCC");
    }
    else if (LB === "床垫") {
        $("#divCXXCS").css("display", "none");
        $("#divCDXXCS").css("display", "");
        LoadXXCS("CDCC", "床尺寸");
        BindHover("CDCC");
    }
    else {
        $("#divCXXCS").css("display", "none");
        $("#divCDXXCS").css("display", "none");
    }
    LoadESJJXL(LB);
    BindHover("XL");
}
//选择二手家具品牌
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
//加载二手_手机数码_二手家具基本信息
function LoadES_JDJJBG_ESJJJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_JDJJBG_ESJJ/LoadES_JDJJBG_ESJJJBXX",
        dataType: "json",
        data:
        {
            ES_JDJJBG_ESJJJBXXID: getUrlParam("ES_JDJJBG_ESJJJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_JDJJBG_ESJJJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_JDJJBG_ESJJJBXXID").val(xml.Value.ES_JDJJBG_ESJJJBXX.ES_JDJJBG_ESJJJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.ES_JDJJBG_ESJJJBXX.BCMS);
                });
                SetGQ(xml.Value.ES_JDJJBG_ESJJJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_JDJJBG_ESJJJBXX.LB);
                $("#spanXJ").html(xml.Value.ES_JDJJBG_ESJJJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_JDJJBG_ESJJJBXX.JYQY);
                $("#spanDD").html(xml.Value.ES_JDJJBG_ESJJJBXX.JYDD);
                $("#spanXL").html(xml.Value.ES_JDJJBG_ESJJJBXX.XL);
                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_JDJJBG_ESJJJBXX.LB);
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

    if (getUrlParam("ES_JDJJBG_ESJJJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_JDJJBG_ESJJJBXXID", "'" + getUrlParam("ES_JDJJBG_ESJJJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_JDJJBG_ESJJ/FB",
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
