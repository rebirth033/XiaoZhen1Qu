var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 900) / 2);
    $(".div_head").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $(".div_content").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $("#spanCXLB").bind("click", CXLB);
    $("#imgGRZR").bind("click", GRZRSelect);
    $("#imgSJZR").bind("click", SJZRSelect);
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
    LoadFZXMXBLB();
    LoadDefault();
    LoadES_MYFZMR_FZXMXBJBXX();
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
    $("#imgGRZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择个人转让
function GRZRSelect() {
    $("#imgGRZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择商家转让
function SJZRSelect() {
    $("#imgGRZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}
//加载服装/鞋帽/箱包类别
function LoadFZXMXBLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_MYFZMR",
        dataType: "json",
        data:
        {
            TYPENAME: "服装/鞋帽/箱包"
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
//加载母婴/服装/美容小类
function LoadFZXMXBXL(type) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_MYFZMR",
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
//加载母婴/服装/美容详细参数
function LoadXXCS(id, type) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_MYFZMR",
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
//加载母婴/服装/美容新旧
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
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadFZXMXBLB();
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
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    PDLB(obj.innerHTML);
}
//判断类别
function PDLB(LB) {
    if (LB === "服装") {
        $("#divFZXXCS").css("display", "");
        $("#divXXXCS").css("display", "none");
        LoadXXCS("FZCC", "服装尺寸");
        BindHover("FZCC");
    }
    else if (LB === "鞋") {
        $("#divFZXXCS").css("display", "none");
        $("#divXXXCS").css("display", "");
        LoadXXCS("XCC", "鞋尺寸");
        BindHover("XCC");
    }
    else {
        $("#divFZXXCS").css("display", "none");
        $("#divXXXCS").css("display", "none");
    }
    LoadFZXMXBXL(LB);
    BindClick("XL");
}
//选择母婴/服装/美容品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//获取供求
function GetGQ() {
    if ($("#imgGRZR").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置供求
function SetGQ(gq) {
    if (gq === 0) {
        $("#imgGRZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgGRZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//加载二手_手机数码_母婴/服装/美容基本信息
function LoadES_MYFZMR_FZXMXBJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_MYFZMR_FZXMXB/LoadES_MYFZMR_FZXMXBJBXX",
        dataType: "json",
        data:
        {
            ES_MYFZMR_FZXMXBJBXXID: getUrlParam("ES_MYFZMR_FZXMXBJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_MYFZMR_FZXMXBJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_MYFZMR_FZXMXBJBXXID").val(xml.Value.ES_MYFZMR_FZXMXBJBXX.ES_MYFZMR_FZXMXBJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.ES_MYFZMR_FZXMXBJBXX.BCMS);
                });
                SetGQ(xml.Value.ES_MYFZMR_FZXMXBJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.LB);
                $("#spanXJ").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.JYQY);
                $("#spanSQ").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.JYDD);

                $("#spanDSPMCC").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.DSPMCC);
                $("#spanDSPP").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.DSPP);
                $("#spanXYJPP").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.XYJPP);
                $("#spanKTPP").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.KTPP);
                $("#spanKTBPDS").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.KTBPDS);
                $("#spanKTGL").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.KTGL);
                $("#spanBXPP").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.BXPP);
                $("#spanBGPP").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.BGPP);

                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_MYFZMR_FZXMXBJBXX.LB);
                $("#spanXL").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.XL);
                return;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//鼠标经过
function MouseOver() {
    isleave = false;
}
//鼠标离开
function MouseLeave() {
    isleave = true;
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

    if (getUrlParam("ES_MYFZMR_FZXMXBJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_MYFZMR_FZXMXBJBXXID", "'" + getUrlParam("ES_MYFZMR_FZXMXBJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_MYFZMR_FZXMXB/FB",
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
