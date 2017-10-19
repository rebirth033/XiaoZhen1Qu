﻿var isleave = true;
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
    $("body").bind("click", function () { Close("_XZQ"); Close("LB"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });



    LoadDefault();
    LoadCL_HCJBXX();
    BindClick("LB");
    BindClick("PP");
    BindClick("CCNX");
    BindClick("CCYF");
    BindClick("QY");
    BindClick("DD");
    BindClick("GCSJ");
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
    $(".divstep_yx").bind("click", YXBQActive);
}
//品牌标签切换
function YXBQActive() {
    LoadPPMC(this.id);
}
//加载品牌名称
function LoadPPMC(HC) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByCodeValueAndTypeName",
        dataType: "json",
        data:
        {
            CODEVALUE: HC.split("div")[1],
            TYPENAME: "货车品牌",
            TBName: "CODES_CL"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_yxmc" onclick="PPXZ(\'' + xml.list[i].CODENAME + '\',\'' + xml.list[i].CODEID + '\')">' + xml.list[i].CODENAME + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_yxmc" style=\"width:200px;text-align:left;margin-left:14px;\">该字母下暂无数据</span>';
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
    $("#spanPP").html(PPMC);
    $(".div_xzk").css("display", "none");
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
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("货车", "LB", "CODES_CL");
        }
        if (type === "PP") {
            LoadPP();
            LoadPPMC("divRM");
        }
        if (type === "CCNX") {
            LoadCODESByTYPENAME("出厂年限", "CCNX", "CODES_CL");
        }
        if (type === "CCYF") {
            LoadCODESByTYPENAME("出厂月份", "CCYF", "CODES_CL");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
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
//选择货车品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载车辆_货车基本信息
function LoadCL_HCJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL_HC/LoadCL_HCJBXX",
        dataType: "json",
        data:
        {
            CL_HCJBXXID: getUrlParam("CL_HCJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_HCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#CL_HCJBXXID").val(xml.Value.CL_HCJBXX.CL_HCJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.CL_HCJBXX.BCMS);
                });
                $("#spanLB").html(xml.Value.CL_HCJBXX.LB);
                $("#spanXL").html(xml.Value.CL_HCJBXX.XL);
                $("#spanPP").html(xml.Value.CL_HCJBXX.PP);
                $("#spanCCNX").html(xml.Value.CL_HCJBXX.CCNX);
                $("#spanCCYF").html(xml.Value.CL_HCJBXX.CCYF);
                $("#spanQY").html(xml.Value.CL_HCJBXX.JYQY);
                $("#spanSQ").html(xml.Value.CL_HCJBXX.JYDD);

                LoadPhotos(xml.Value.Photos);
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
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanPP").html() + "'");
    obj = jsonObj.AddJson(obj, "CCNX", "'" + $("#spanCCNX").html() + "'");
    obj = jsonObj.AddJson(obj, "CCYF", "'" + $("#spanCCYF").html() + "'");
    obj = jsonObj.AddJson(obj, "JYQY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "JYDD", "'" + $("#spanSQ").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("CL_HCJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "CL_HCJBXXID", "'" + getUrlParam("CL_HCJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL_HC/FB",
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
