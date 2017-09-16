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
    $("body").bind("click", CloseXZQ);
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);

    LoadTXXX();
    LoadGCQXLB();
    LoadXJ();
    LoadQY();
    LoadDefault();
    LoadES_QTES_GCQXJBXX();
    BindHover("LB");
    BindHover("XJ");
    BindHover("QY");
    BindHover("SQ");

});
//加载品牌标签
function LoadYXBQ() {
    var arrayObj = new Array('RMYX', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    var html = "";
    for (var i = 0; i < arrayObj.length; i++) {
        if (i === 0)
            html += '<div class="divstep_yx" id="div' + arrayObj[i] + '" style="width:62px;"><span class="spanstep_yx" id="span' + arrayObj[i] + '">' + "热门" + '</span><em class="emstep_yx" id="em' + arrayObj[i] + '"></em></div>';
        else
            html += '<div class="divstep_yx" id="div' + arrayObj[i] + '"><span class="spanstep_yx" id="span' + arrayObj[i] + '">' + arrayObj[i] + '</span><em class="emstep_yx" id="em' + arrayObj[i] + '"></em></div>';
    }
    $("#div_content_yxbq").html(html);

    $(".divstep_yx").bind("mouseover", YXBQActive);
}
//品牌标签切换
function YXBQActive() {
    LoadYXMC(this.id);
}
//加载品牌名称
function LoadYXMC(SZM) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/YXCZ/LoadGCQXJBXX",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID"),
            SZM: SZM.split("div")[1]
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_yxmc" onclick="YXXZ(\'' + xml.list[i].YXMC + '\')">' + xml.list[i].YXMC + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_yxmc">该字母下暂无游戏</span>';
                $("#div_content_yxmc").html(html);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择品牌名称
function YXXZ(YXMC) {
    $("#spanXL").html(YXMC);
    $("#divXL").css("display", "none");
}
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
//重选类别
function CXLB() {
    window.location.href = getRootPath() + "/Business/LBXZ/LBXZ";
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
//加载工程器械类别
function LoadGCQXLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_QTES",
        dataType: "json",
        data:
        {
            TYPENAME: "工程器械"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
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
//加载工程器械小类
function LoadGCQXXL(type) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_QTES",
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
                $("#divXL").css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载工程器械详细参数
function LoadXXCS(id, type) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_QT",
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
                $("#div" + id).css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载工程器械新旧
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
                $("#divXJ").css("display", "none");
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
    PDLB(obj.innerHTML);
}
//判断类别
function PDLB(LB) {
    LoadGCQXXL(LB);
    BindHover("XL");
}

//选择区域下拉框
function SelectQY(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadSQ(code);
}
//选择工程器械品牌
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
//加载二手_手机数码_工程器械基本信息
function LoadES_QTES_GCQXJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_QTES_GCQX/LoadES_QTES_GCQXJBXX",
        dataType: "json",
        data:
        {
            ES_QTES_GCQXJBXXID: getUrlParam("ES_QTES_GCQXJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_QTES_GCQXJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_QTES_GCQXJBXXID").val(xml.Value.ES_QTES_GCQXJBXX.ES_QTES_GCQXJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.ES_QTES_GCQXJBXX.BCMS);
                });
                SetGQ(xml.Value.ES_QTES_GCQXJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_QTES_GCQXJBXX.LB);
                $("#spanXJ").html(xml.Value.ES_QTES_GCQXJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_QTES_GCQXJBXX.JYQY);
                $("#spanSQ").html(xml.Value.ES_QTES_GCQXJBXX.JYDD);

                $("#spanDSPMCC").html(xml.Value.ES_QTES_GCQXJBXX.DSPMCC);
                $("#spanDSPP").html(xml.Value.ES_QTES_GCQXJBXX.DSPP);
                $("#spanXYJPP").html(xml.Value.ES_QTES_GCQXJBXX.XYJPP);
                $("#spanKTPP").html(xml.Value.ES_QTES_GCQXJBXX.KTPP);
                $("#spanKTBPDS").html(xml.Value.ES_QTES_GCQXJBXX.KTBPDS);
                $("#spanKTGL").html(xml.Value.ES_QTES_GCQXJBXX.KTGL);
                $("#spanBXPP").html(xml.Value.ES_QTES_GCQXJBXX.BXPP);
                $("#spanBGPP").html(xml.Value.ES_QTES_GCQXJBXX.BGPP);

                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_QTES_GCQXJBXX.LB);
                $("#spanXL").html(xml.Value.ES_QTES_GCQXJBXX.XL);
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

    if (getUrlParam("ES_QTES_GCQXJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_QTES_GCQXJBXXID", "'" + getUrlParam("ES_QTES_GCQXJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_QTES_GCQX/FB",
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
