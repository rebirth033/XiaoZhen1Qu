$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ");});
    LoadES_JDJJBG_ESJJJBXX();
    BindClick("LB");
    BindClick("PBPP");
    BindClick("PBXH");
    BindClick("XJ");

});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("二手家具", "LB", "CODES_ES_JDJJBG", Bind, "ESJJLB", "LB", "");
        }
        if (type === "XL") {
            $("#divXL").css("display", "block");
            ActiveStyle("XL");
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM", Bind, "XJCD", "XJ", "");
        }
        if (type === "CCC") {
            LoadCODESByTYPENAME("床尺寸", "CCC", "CODES_ES_JDJJBG");
        }
        if (type === "CDCC") {
            LoadCODESByTYPENAME("床尺寸", "CDCC", "CODES_ES_JDJJBG");
        }
    });
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    if (type === "LB") {
        PDLB(obj.innerHTML);
    }
}
//判断类别
function PDLB(LB) {
    if (LB === "床") {
        $("#divCXXCS").css("display", "");
        $("#divCDXXCS").css("display", "none");
        BindClick("CCC");
    }
    else if (LB === "床垫") {
        $("#divCXXCS").css("display", "none");
        $("#divCDXXCS").css("display", "");
        BindClick("CDCC");
    }
    else {
        $("#divCXXCS").css("display", "none");
        $("#divCDXXCS").css("display", "none");
    }
    LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_JDJJBG", Bind, "ESJJLB", "XL", "");
    $("#spanXL").html("请选择小类");
}
//选择二手家具品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载二手_手机数码_二手家具基本信息
function LoadES_JDJJBG_ESJJJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/LoadES_JDJJBG_ESJJJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_JDJJBG_ESJJJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.ES_JDJJBG_ESJJJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.ES_JDJJBG_ESJJJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_JDJJBG_ESJJJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_JDJJBG_ESJJJBXX.LB);
                $("#spanCCC").html(xml.Value.ES_JDJJBG_ESJJJBXX.CCC);
                $("#spanCDCC").html(xml.Value.ES_JDJJBG_ESJJJBXX.CDCC);
                $("#spanXJ").html(xml.Value.ES_JDJJBG_ESJJJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_JDJJBG_ESJJJBXX.QY);
                $("#spanDD").html(xml.Value.ES_JDJJBG_ESJJJBXX.DD);
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
    if (ValidateAll() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "CCC", "'" + $("#spanCCC").html() + "'");
    obj = jsonObj.AddJson(obj, "CDCC", "'" + $("#spanCDCC").html() + "'");
    obj = jsonObj.AddJson(obj, "XJ", "'" + $("#spanXJ").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/FBES_JDJJBG_ESJJJBXX",
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
