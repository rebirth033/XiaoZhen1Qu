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
    LoadESJDLB();
    LoadDefault();
    LoadES_JDJJBG_ESJDJBXX();
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
            LoadESJDLB();
        }
        if (type === "XL") {
            LoadFZXMXBXL();
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
//加载二手家电类别
function LoadESJDLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_JDJJBG",
        dataType: "json",
        data:
        {
            TYPENAME: "二手家电"
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
//加载二手家电小类
function LoadESJDXL(type) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_JDJJBG",
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
//加载二手家电详细参数
function LoadXXCS(id, type) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_JDJJBG",
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
//加载二手家电新旧
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
    if (LB === "电视机") {
        $("#divDSXXCS").css("display", "");
        $("#divXYJXXCS").css("display", "none");
        $("#divKTXXCS").css("display", "none");
        $("#divBXXXCS").css("display", "none");
        $("#divBGXXCS").css("display", "none");
        LoadXXCS("DSPMCC", "电视屏幕尺寸");
        LoadXXCS("DSPP", "电视品牌");
        BindClick("DSPMCC");
        BindClick("DSPP");
    }
    else if (LB === "洗衣机") {
        $("#divDSXXCS").css("display", "none");
        $("#divXYJXXCS").css("display", "");
        $("#divKTXXCS").css("display", "none");
        $("#divBXXXCS").css("display", "none");
        $("#divBGXXCS").css("display", "none");
        LoadXXCS("XYJPP", "洗衣机品牌");
        BindClick("XYJPP");
    }
    else if (LB === "空调") {
        $("#divDSXXCS").css("display", "none");
        $("#divXYJXXCS").css("display", "none");
        $("#divKTXXCS").css("display", "");
        $("#divBXXXCS").css("display", "none");
        $("#divBGXXCS").css("display", "none");
        LoadXXCS("KTPP", "空调品牌");
        LoadXXCS("BPDS", "变频定速");
        LoadXXCS("KTGL", "空调功率");
        BindClick("KTPP");
        BindClick("BPDS");
        BindClick("KTGL");
    }
    else if (LB === "冰箱") {
        $("#divDSXXCS").css("display", "none");
        $("#divXYJXXCS").css("display", "none");
        $("#divKTXXCS").css("display", "none");
        $("#divBXXXCS").css("display", "");
        $("#divBGXXCS").css("display", "none");
        LoadXXCS("BXPP", "冰箱品牌");
        BindClick("BXPP");
    }
    else if (LB === "冰柜") {
        $("#divDSXXCS").css("display", "none");
        $("#divXYJXXCS").css("display", "none");
        $("#divKTXXCS").css("display", "none");
        $("#divBXXXCS").css("display", "none");
        $("#divBGXXCS").css("display", "");
        LoadXXCS("BGPP", "冰柜品牌");
        BindClick("BGPP");
    }
    else {
        $("#divDSXXCS").css("display", "none");
        $("#divXYJXXCS").css("display", "none");
        $("#divKTXXCS").css("display", "none");
        $("#divBXXXCS").css("display", "none");
        $("#divBGXXCS").css("display", "none");
    }
    LoadESJDXL(LB);
    BindClick("XL");
}
//选择二手家电品牌
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
//加载二手_家电家具办公_二手家电基本信息
function LoadES_JDJJBG_ESJDJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_JDJJBG_ESJD/LoadES_JDJJBG_ESJDJBXX",
        dataType: "json",
        data:
        {
            ES_JDJJBG_ESJDJBXXID: getUrlParam("ES_JDJJBG_ESJDJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_JDJJBG_ESJDJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_JDJJBG_ESJDJBXXID").val(xml.Value.ES_JDJJBG_ESJDJBXX.ES_JDJJBG_ESJDJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.ES_JDJJBG_ESJDJBXX.BCMS);
                });
                SetGQ(xml.Value.ES_JDJJBG_ESJDJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_JDJJBG_ESJDJBXX.LB);
                $("#spanXJ").html(xml.Value.ES_JDJJBG_ESJDJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_JDJJBG_ESJDJBXX.JYQY);
                $("#spanDD").html(xml.Value.ES_JDJJBG_ESJDJBXX.JYDD);
                $("#spanXL").html(xml.Value.ES_JDJJBG_ESJDJBXX.XL);
                $("#spanDSPMCC").html(xml.Value.ES_JDJJBG_ESJDJBXX.DSPMCC);
                $("#spanDSPP").html(xml.Value.ES_JDJJBG_ESJDJBXX.DSPP);
                $("#spanXYJPP").html(xml.Value.ES_JDJJBG_ESJDJBXX.XYJPP);
                $("#spanKTPP").html(xml.Value.ES_JDJJBG_ESJDJBXX.KTPP);
                $("#spanKTBPDS").html(xml.Value.ES_JDJJBG_ESJDJBXX.KTBPDS);
                $("#spanKTGL").html(xml.Value.ES_JDJJBG_ESJDJBXX.KTGL);
                $("#spanBXPP").html(xml.Value.ES_JDJJBG_ESJDJBXX.BXPP);
                $("#spanBGPP").html(xml.Value.ES_JDJJBG_ESJDJBXX.BGPP);

                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_JDJJBG_ESJDJBXX.LB);
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
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetGQ() + "'");

    obj = jsonObj.AddJson(obj, "DSPMCC", "'" + $("#spanDSPMCC").html() + "'");
    obj = jsonObj.AddJson(obj, "DSPP", "'" + $("#spanDSPP").html() + "'");
    obj = jsonObj.AddJson(obj, "XYJPP", "'" + $("#spanXYJPP").html() + "'");
    obj = jsonObj.AddJson(obj, "KTPP", "'" + $("#spanKTPP").html() + "'");
    obj = jsonObj.AddJson(obj, "KTBPDS", "'" + $("#spanKTBPDS").html() + "'");
    obj = jsonObj.AddJson(obj, "KTGL", "'" + $("#spanKTGL").html() + "'");
    obj = jsonObj.AddJson(obj, "BXPP", "'" + $("#spanBXPP").html() + "'");
    obj = jsonObj.AddJson(obj, "BGPP", "'" + $("#spanBGPP").html() + "'");

    if (getUrlParam("ES_JDJJBG_ESJDJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_JDJJBG_ESJDJBXXID", "'" + getUrlParam("ES_JDJJBG_ESJDJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_JDJJBG_ESJD/FB",
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
