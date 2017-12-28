﻿$(document).ready(function () {
    $("#divXSQK").find(".div_radio").bind("click", GetXSQK);
    LoadJBXX();
    BindClick("CX");
    BindClick("GCSJ");
    BindClick("PP");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "CX") {
            LoadCODESByTYPENAME("摩托车车型", "CX", "CODES_CL", Bind, "MTCLB", "CX", "");
        }
        if (type === "PP") {
            LoadCODESByTYPENAME("摩托车品牌", "PP", "CODES_CL", Bind, "MTCPP", "PP", "");
        }
        if (type === "GCSJ") {
            LoadCODESByTYPENAME("购车时间", "GCSJ", "CODES_CL", Bind, "MTCGCSJ", "GCSJ", "");
        }
    });
}
//设置行驶情况
function SetXSQK(XSQK) {
    if (XSQK !== "已行使") {
        $("#divMTCGCSJ").css("display", "none");
        $("#divGLS").css("display", "none");
    }
    else {
        $("#divMTCGCSJ").css("display", "");
        $("#divGLS").css("display", "");
    }
}
//获取行驶情况
function GetXSQK() {
    var value = "";
    $("#divXSQK").find("img").each(function () {
        if ($(this).attr("src").indexOf("purple") !== -1)
            value = $(this).parent().find("label")[0].innerHTML;
    });
    if (value !== "已行使") {
        $("#divMTCGCSJ").css("display", "none");
        $("#divGLS").css("display", "none");
    } else {
        $("#divMTCGCSJ").css("display", "");
        $("#divGLS").css("display", "");
    }
    return value;
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
}
//选择摩托车品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载车辆_摩托车基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL/LoadCL_MTCJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_MTCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.CL_MTCJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                if (xml.Value.CL_MTCJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.CL_MTCJBXX.GQ);
                if (xml.Value.CL_MTCJBXX.XSLC !== null)
                    SetDX("XSQK", xml.Value.CL_MTCJBXX.XSLC);
                SetXSQK(xml.Value.CL_MTCJBXX.XSLC);
                $("#spanCX").html(xml.Value.CL_MTCJBXX.CX);
                $("#spanPP").html(xml.Value.CL_MTCJBXX.PP);
                $("#spanGCSJ").html(xml.Value.CL_MTCJBXX.GCSJ);
                $("#spanQY").html(xml.Value.CL_MTCJBXX.QY);
                $("#spanDD").html(xml.Value.CL_MTCJBXX.DD);
                $("#spanXL").html(xml.Value.CL_MTCJBXX.XL);

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
    if (ValidateAll() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "CX", "'" + $("#spanCX").html() + "'");
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanPP").html() + "'");
    obj = jsonObj.AddJson(obj, "GCSJ", "'" + $("#spanGCSJ").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");
    obj = jsonObj.AddJson(obj, "XSLC", "'" + GetDX("XSQK") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL/FBCL_MTCJBXX",
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
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
