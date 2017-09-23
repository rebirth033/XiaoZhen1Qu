﻿var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#imgS").bind("click", SSelect);
    $("#imgF").bind("click", FSelect);
    $("#imgY").bind("click", YSelect);
    $("#imgW").bind("click", WSelect);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qKCs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);
    LoadTXXX();
    LoadDefault();
    LoadCL_JCJBXX();
    LoadCYLS();
    BindClick("PP");
    BindClick("SPNF");
    BindClick("SPYF");
    BindClick("NJDQNF");
    BindClick("NJDQYF");
    BindClick("JQXDQNF");
    BindClick("JQXDQYF");
    BindClick("SYXDQNF");
    BindClick("SYXDQYF");
});
//加载品牌标签
function LoadPP() {
    var arrayObj = new Array('RM', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    var html = "";
    for (var i = 0; i < arrayObj.length; i++) {
        if (i === 0)
            html += '<div class="divstep_yx" id="div' + arrayObj[i] + '" style="width:62px;"><span class="spanstep_yx" id="span' + arrayObj[i] + '">' + "热门" + '</span><em class="emstep_yx" id="em' + arrayObj[i] + '"></em></div>';
        else
            html += '<div class="divstep_yx" id="div' + arrayObj[i] + '"><span class="spanstep_yx" id="span' + arrayObj[i] + '">' + arrayObj[i] + '</span><em class="emstep_yx" id="em' + arrayObj[i] + '"></em></div>';
    }
    $("#div_content_yxbq").html(html);
    $(".divstep_yx").bind("click", KCBQActive);
}
//品牌标签切换
function KCBQActive() {
    LoadPPMC("轿车品牌", this.id);
}
//加载品牌名称
function LoadPPMC(KCLX, KCBQ) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadKCPPXX",
        dataType: "json",
        data:
        {
            KCLX: KCLX,
            KCBQ: KCBQ.split("div")[1]
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_yxmc" onclick="PPXZ(\'' + xml.list[i].CODENAME + '\',\'' + xml.list[i].CODEID + '\')">' + xml.list[i].CODENAME + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_yxmc" style=\"width:200px;text-align:left;margin-left:14px;\">该字母下暂无游戏</span>';
                $("#div_content_yxmc").html(html);
                $("#divPP").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择品牌名称
function PPXZ(PPMC, PPID) {
    $("#PPID").val(PPID);
    $("#spanPP").html(PPMC);
    $("#divPP").css("display", "none");
    $("#divCXText").css("display", "");
    BindClick("CX");
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
    $("#imgS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgY").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择是
function SSelect() {
    $("#imgS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择否
function FSelect() {
    $("#imgS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}
//选择有
function YSelect() {
    $("#imgY").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择无
function WSelect() {
    $("#imgY").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}
//获取是否定期保养
function GetSFDQBY() {
    if ($("#imgS").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置是否定期保养
function SetSFDQBY(SFDQBY) {
    if (SFDQBY === 0) {
        $("#imgS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//获取有无重大事故
function GetYWZDSG() {
    if ($("#imgY").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置有无重大事故
function SetYWZDSG(YWZDSG) {
    if (YWZDSG === 0) {
        $("#imgY").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgY").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "PP") {
            LoadPP();
            LoadPPMC("轿车品牌", "divRM");
        }
        if (type === "CX") {
            LoadKCCX();
        }
        if (type.indexOf("NF") !== -1) {
            LoadNF(type);
        }
        if (type.indexOf("YF") !== -1) {
            LoadYF(type);
        }
    });
}
//加载轿车车系
function LoadKCCX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadKCCXXX",
        dataType: "json",
        data:
        {
            PPID: $("#PPID").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"CX\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divCX").html(html);
                $("#divCX").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载出厂年限
function LoadNF(ID) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_CL",
        dataType: "json",
        data:
        {
            TYPENAME: "出厂年限"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"" + ID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#div" + ID).html(html);
                $("#div" + ID).css("display", "block");
                ActiveStyle(ID);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载出厂月份
function LoadYF(ID) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_CL",
        dataType: "json",
        data:
        {
            TYPENAME: "出厂月份"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"" + ID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#div" + ID).html(html);
                $("#div" + ID).css("display", "block");
                ActiveStyle(ID);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载车辆颜色
function LoadCYLS() {
    var colors = new Array("black:黑", "red:红", "white:白", "rgb(230, 230, 230):银", "rgb(214, 214, 214):灰", "rgb(51, 153, 255):蓝", "rgb(255, 255, 0):黄", "rgb(153, 102, 0):棕");
    for (var i = 0; i < colors.length; i++) {
        var obj = colors[i].split(':');
        $("#div_clys_right").append('<div class="div_clys"><span class="span_clys_left" style="background-color: ' + obj[0] + '"></span><span class="span_clys_right">' + obj[1] + '</span></div>');
    }
    colors = new Array("rgb(13, 207, 110):绿", "rgb(255, 102, 0):橙", "rgb(204, 51, 153):紫", "rgb(243, 238, 170):香槟", "rgb(255, 204, 0):金", "rgb(255, 192, 203):粉红", "其他");
    for (var i = 0; i < colors.length; i++) {
        var obj = colors[i].split(':');
        if (i === colors.length - 1)
            $("#div_clys_right2").append('<div class="div_clys"><span class="span_clys_left" style="border:none;"></span><span class="span_clys_right">' + obj[0] + '</span></div>');
        else
            $("#div_clys_right2").append('<div class="div_clys"><span class="span_clys_left" style="background-color: ' + obj[0] + '"></span><span class="span_clys_right">' + obj[1] + '</span></div>');
    }
    $(".div_clys").bind("click", ActiveCLYS);
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
//选择车辆颜色
function ActiveCLYS() {
    $(".div_clys").each(function () {
        $(this).css("background-color", "#ffffff;");
    });
    $(this).css("background-color", "#87B53B");
}
//加载车辆_轿车基本信息
function LoadCL_JCJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL_JC/LoadCL_JCJBXX",
        dataType: "json",
        data:
        {
            CL_JCJBXXID: getUrlParam("CL_JCJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_JCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#CL_JCJBXXID").val(xml.Value.CL_JCJBXX.CL_JCJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.CL_JCJBXX.BCMS);
                });
                $("#spanPP").html(xml.Value.CL_JCJBXX.PP);
                $("#spanCX").html(xml.Value.CL_JCJBXX.CX);
                $("#spanSPNF").html(xml.Value.CL_JCJBXX.SPNF);
                $("#spanSPYF").html(xml.Value.CL_JCJBXX.SPYF);
                $("#spanNJDQNF").html(xml.Value.CL_JCJBXX.NJDQNF);
                $("#spanNJDQYF").html(xml.Value.CL_JCJBXX.NJDQYF);
                $("#spanJQXDQNF").html(xml.Value.CL_JCJBXX.JQXDQNF);
                $("#spanJQXDQYF").html(xml.Value.CL_JCJBXX.JQXDQYF);
                $("#spanSYXDQNF").html(xml.Value.CL_JCJBXX.SYXDQNF);
                $("#spanSYXDQYF").html(xml.Value.CL_JCJBXX.SYXDQYF);
                LoadPhotos(xml.Value.Photos);
                SetSFDQBY(xml.Value.CL_JCJBXX.SFDQBY);
                SetYWZDSG(xml.Value.CL_JCJBXX.YWZDSG);
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
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanPP").html() + "'");
    obj = jsonObj.AddJson(obj, "CX", "'" + $("#spanCX").html() + "'");
    obj = jsonObj.AddJson(obj, "SPNF", "'" + $("#spanSPNF").html() + "'");
    obj = jsonObj.AddJson(obj, "SPYF", "'" + $("#spanSPYF").html() + "'");
    obj = jsonObj.AddJson(obj, "NJDQNF", "'" + $("#spanNJDQNF").html() + "'");
    obj = jsonObj.AddJson(obj, "NJDQYF", "'" + $("#spanNJDQYF").html() + "'");
    obj = jsonObj.AddJson(obj, "JQXDQNF", "'" + $("#spanJQXDQNF").html() + "'");
    obj = jsonObj.AddJson(obj, "JQXDQYF", "'" + $("#spanJQXDQYF").html() + "'");
    obj = jsonObj.AddJson(obj, "SYXDQNF", "'" + $("#spanSYXDQNF").html() + "'");
    obj = jsonObj.AddJson(obj, "SYXDQYF", "'" + $("#spanSYXDQYF").html() + "'");
    obj = jsonObj.AddJson(obj, "SFDQBY", "'" + GetSFDQBY() + "'");
    obj = jsonObj.AddJson(obj, "YWZDSG", "'" + GetYWZDSG() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("CL_JCJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "CL_JCJBXXID", "'" + getUrlParam("CL_JCJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL_JC/FB",
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