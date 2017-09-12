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
    $("#imgSYG").bind("click", SYGSelect);
    $("#imgQXWCF").bind("click", QXWCFSelect);
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qhcs").bind("click", LoadXZQByGrade);
    $("body").bind("click", CloseXZQ);
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);

    LoadTXXX();
    LoadBJBLB();
    LoadBJBPP();
    LoadQY();
    LoadDefault();
    //LoadES_SJSM_BJBDNJBXX();
    BindHover("LB");
    BindHover("BJBPP");
    BindHover("BJBXH");
    BindHover("QY");
    BindHover("SQ");
});
//显示用户菜单
function ShowYHCD() {
    $("#div_top_right_dropdown_yhm").css("display", "block");
    $("#span_top_right_yhm_img").css("background-image", 'url(' + getRootPath() + "/Areas/Business/Css/images/arrow_up.png" + ')');
}
//隐藏用户菜单
function HideYHCD() {
    $("#div_top_right_dropdown_yhm").css("display", "none");
    $("#span_top_right_yhm_img").css("background-image", 'url(' + getRootPath() + "/Areas/Business/Css/images/arrow_down.png" + ')');
}
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
//加载类别信息
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
//重选类别
function CXLB() {
    window.location.href = getRootPath() + "/Business/LBXZ/LBXZ";
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
//使用过
function SYGSelect() {
    $("#imgSYG").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgQXWCF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//全新未拆封
function QXWCFSelect() {
    $("#imgQXWCF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSYG").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//加载笔记本类别
function LoadBJBLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_COMPUTER",
        dataType: "json",
        data:
        {
            TYPENAME: "笔记本类别"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;height:69px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"LB\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divLB").html(html);
                $("#divLB").css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载笔记本品牌
function LoadBJBPP() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_COMPUTER",
        dataType: "json",
        data:
        {
            TYPENAME: "笔记本品牌"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;height:340px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectBJBPP(this,\"BJBPP\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divBJBPP").html(html);
                $("#divBJBPP").css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载笔记本型号
function LoadBJBXH(BJBPP) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadBJBXH",
        dataType: "json",
        data:
        {
            BJBPP: BJBPP
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;height:340px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"BJBXH\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divBJBXH").html(html);
                $("#divBJBXH").css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载区域
function LoadQY() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadQY",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectQY(this,\"QY\",\"" + xml.list[i].CODE + "\")'>" + RTrim(RTrim(RTrim(xml.list[i].NAME, '市'), '区'), '县') + "</li>";
                }
                html += "</ul>";
                $("#divQY").html(html);
                $("#divQY").css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载地段
function LoadSQ(QY) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadSQ",
        dataType: "json",
        data:
        {
            QY: QY
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"SQ\")'>" + RTrimStr(xml.list[i].NAME, '街道,镇,林场,管理处') + "</li>";
                }
                html += "</ul>";
                $("#divSQ").html(html);
                $("#divSQ").css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//鼠标盘旋样式
function HoverStyle(name) {
    $("#div" + name + "Text").css("border-top", "1px solid #5bc0de").css("border-right", "1px solid #5bc0de").css("border-left", "1px solid #5bc0de").css("border-bottom", "1px solid #5bc0de");
    $("#div" + name).find("ul").css("border-left", "1px solid #5bc0de").css("border-right", "1px solid #5bc0de").css("border-bottom", "1px solid #5bc0de");
    $("#span" + name).css("color", "#333333");
}
//鼠标离开样式
function LeaveStyle(name) {
    $("#div" + name + "Text").css("border-top", "1px solid #cccccc").css("border-right", "1px solid #cccccc").css("border-left", "1px solid #cccccc").css("border-bottom", "1px solid #cccccc");
    $("#div" + name).find("ul").css("border-left", "1px solid #cccccc").css("border-right", "1px solid #cccccc").css("border-bottom", "1px solid #cccccc");
    $("#span" + name).css("color", "#999999");
}
//绑定下拉框鼠标盘旋样式
function BindHover(type) {
    $("#div" + type + "Text").hover(function () {
        $("#div" + type).css("display", "block");
        HoverStyle(type);
    }, function () {
        $("#div" + type).css("display", "none");
        LeaveStyle(type);
    });
    $("#div" + type).hover(function () {
        $("#div" + type).css("display", "block");
        HoverStyle(type);
    }, function () {
        $("#div" + type).css("display", "none");
        LeaveStyle(type);
    });
}
//选择下拉框
function SelectDropdown(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
}
//选择区域下拉框
function SelectQY(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadSQ(code);
}
//选择笔记本品牌
function SelectBJBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadBJBXH(code);
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
//获取使用情况
function GetSYQK() {
    if ($("#imgSYG").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置使用情况
function SetSYQK(gq) {
    if (gq === 0) {
        $("#imgSYG").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgQXWCF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgSYG").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgQXWCF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//加载二手_手机数码_二手手机基本信息
function LoadES_SJSM_BJBDNJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_SJSM_BJBDN/LoadES_SJSM_BJBDNJBXX",
        dataType: "json",
        data:
        {
            ES_SJSM_BJBDNJBXXID: getUrlParam("ES_SJSM_BJBDNJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_SJSM_BJBDNJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_SJSM_BJBDNJBXXID").val(xml.Value.ES_SJSM_BJBDNJBXX.ES_SJSM_BJBDNJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.ES_SJSM_BJBDNJBXX.BCMS);
                });
                SetGQ(xml.Value.ES_SJSM_BJBDNJBXX.GQ);
                $("#spanQY").html(xml.Value.ES_SJSM_BJBDNJBXX.JYQY);
                $("#spanSQ").html(xml.Value.ES_SJSM_BJBDNJBXX.JYDD);
                $("#spanSJPP").html(xml.Value.ES_SJSM_BJBDNJBXX.SJPP);
                $("#spanSJXH").html(xml.Value.ES_SJSM_BJBDNJBXX.SJXH);
                LoadPhotos(xml.Value.Photos);
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
    obj = jsonObj.AddJson(obj, "SJPP", "'" + $("#spanSJPP").html() + "'");
    obj = jsonObj.AddJson(obj, "SJXH", "'" + $("#spanSJXH").html() + "'");
    obj = jsonObj.AddJson(obj, "JYQY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "JYDD", "'" + $("#spanSQ").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetGQ() + "'");
    obj = jsonObj.AddJson(obj, "SYQK", "'" + GetSYQK() + "'");

    if (getUrlParam("ES_SJSM_BJBDNJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_SJSM_BJBDNJBXXID", "'" + getUrlParam("ES_SJSM_BJBDNJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_SJSM_BJBDN/FB",
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
