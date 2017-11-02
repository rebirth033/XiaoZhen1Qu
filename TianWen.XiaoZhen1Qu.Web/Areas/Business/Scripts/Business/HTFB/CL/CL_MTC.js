$(document).ready(function () {
    $("#divXSQK").find(".div_radio").bind("click", GetXSQK);
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadCL_MTCJBXX();
    BindClick("LB");
    BindClick("GCSJ");
    BindClick("PP");
    BindClick("QY");
    BindClick("SQ");
});
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("摩托车", "LB", "CODES_CL", Bind, "MTCLB", "LB", "");
        }
        if (type === "PP") {
            LoadCODESByTYPENAME("摩托车品牌", "PP", "CODES_CL", Bind, "MTCPP", "PP", "");
        }
        if (type === "GCSJ") {
            LoadCODESByTYPENAME("购车时间", "GCSJ", "CODES_CL", Bind, "MTCGCSJ", "GCSJ", "");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
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
        if ($(this).attr("src").indexOf("blue") !== -1)
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
function LoadCL_MTCJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL/LoadCL_MTCJBXX",
        dataType: "json",
        data:
        {
            CL_MTCJBXXID: getUrlParam("CL_MTCJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_MTCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#CL_MTCJBXXID").val(xml.Value.CL_MTCJBXX.CL_MTCJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.CL_MTCJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.CL_MTCJBXX.GQ);
                if (xml.Value.CL_MTCJBXX.XSLC !== null)
                    SetDX("XSQK", xml.Value.CL_MTCJBXX.XSLC);
                SetXSQK(xml.Value.CL_MTCJBXX.XSLC);
                $("#spanLB").html(xml.Value.CL_MTCJBXX.LB);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanPP").html() + "'");
    obj = jsonObj.AddJson(obj, "GCSJ", "'" + $("#spanGCSJ").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");
    obj = jsonObj.AddJson(obj, "XSLC", "'" + GetDX("XSQK") + "'");

    if (getUrlParam("CL_MTCJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "CL_MTCJBXXID", "'" + getUrlParam("CL_MTCJBXXID") + "'");

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
            } else {

            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
