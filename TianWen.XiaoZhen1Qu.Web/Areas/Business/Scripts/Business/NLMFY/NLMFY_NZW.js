﻿
$(document).ready(function () {$("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });LoadNLMFY_NZWJBXX();
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("农作物", "LB", "CODES_NLMFY");
        }
        if (type === "XL") {
            LoadXL();
            LoadXLMC($("#spanLB").html(), "divA");
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
function SelectLB(obj, type, lbid) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#LBID").val(lbid);
    BindClick("XL");
}

//加载小类标签
function LoadXL() {
    var arrayObj = new Array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    var html = "";
    for (var i = 0; i < arrayObj.length; i++) {
        html += '<div class="div_bqss_content_bq" id="div' + arrayObj[i] + '"><span class="span_bqss_content_bq" id="span' + arrayObj[i] + '">' + arrayObj[i] + '</span><em class="em_bqss_content_bq" id="em' + arrayObj[i] + '"></em></div>';
    }
    $("#div_bqss_body_bq").html(html);
    $(".div_bqss_content_bq").bind("click", JCBQActive);
}
//小类标签切换
function JCBQActive() {
    LoadXLMC($("#spanLB").html(), this.id);
}
//加载小类名称
function LoadXLMC(JCLX, JCBQ) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByCodeValueAndTypeName",
        dataType: "json",
        data:
        {
            TYPENAME: JCLX,
            CODEVALUE: JCBQ.split("div")[1],
            TBName: "CODES_NLMFY"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_mc" onclick="XLXZ(\'' + xml.list[i].CODENAME + '\',\'' + xml.list[i].CODEID + '\')">' + xml.list[i].CODENAME + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_mc" style=\"width:200px;text-align:left;margin-left:14px;\">该字母下暂无数据</span>';
                $("#div_bqss_body_mc").html(html);
                $("#divXL").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择小类名称
function XLXZ(XLMC, XLID) {
    $("#spanXL").html(XLMC);
    $("#divXL").css("display", "none");
}
//加载农林牧副渔_农作物基本信息
function LoadNLMFY_NZWJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/NLMFY_NZW/LoadNLMFY_NZWJBXX",
        dataType: "json",
        data:
        {
            NLMFY_NZWJBXXID: getUrlParam("NLMFY_NZWJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.NLMFY_NZWJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#NLMFY_NZWJBXXID").val(xml.Value.NLMFY_NZWJBXX.NLMFY_NZWJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.NLMFY_NZWJBXX.LB);
                $("#spanXL").html(xml.Value.NLMFY_NZWJBXX.XL);
                $("#spanQY").html(xml.Value.NLMFY_NZWJBXX.QY);
                $("#spanDD").html(xml.Value.NLMFY_NZWJBXX.DD);
                LoadPhotos(xml.Value.Photos);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//发布
function FB() {
    if (ValidateAll() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");

    if (getUrlParam("NLMFY_NZWJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "NLMFY_NZWJBXXID", "'" + getUrlParam("NLMFY_NZWJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/NLMFY_NZW/FB",
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