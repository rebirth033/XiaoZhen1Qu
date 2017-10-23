
$(document).ready(function () {
    
    
    
    $("body").bind("click", function () { Close("_XZQ");});




    
    LoadES_JDJJBG_JJRYJBXX();
    BindClick("LB");
    BindClick("XJ");
    BindClick("QY");
    BindClick("DD");
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("家居/日用品", "LB", "CODES_ES_JDJJBG");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_JDJJBG");
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM");
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
    if (LB === "床") {
        $("#divCXXCS").css("display", "");
        $("#divCDXXCS").css("display", "none");
        LoadCODESByTYPENAME("床尺寸", "CCC", "CODES_ES_JDJJBG");
        BindClick("CCC");
    }
    else if (LB === "床垫") {
        $("#divCXXCS").css("display", "none");
        $("#divCDXXCS").css("display", "");
        LoadCODESByTYPENAME("床尺寸", "CDCC", "CODES_ES_JDJJBG");
        BindClick("CDCC");
    }
    else {
        $("#divCXXCS").css("display", "none");
        $("#divCDXXCS").css("display", "none");
    }
    BindClick("XL");
}
//选择家居日用品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载二手_手机数码_家居日用基本信息
function LoadES_JDJJBG_JJRYJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_JDJJBG_JJRY/LoadES_JDJJBG_JJRYJBXX",
        dataType: "json",
        data:
        {
            ES_JDJJBG_JJRYJBXXID: getUrlParam("ES_JDJJBG_JJRYJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_JDJJBG_JJRYJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_JDJJBG_JJRYJBXXID").val(xml.Value.ES_JDJJBG_JJRYJBXX.ES_JDJJBG_JJRYJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.ES_SJSM_PBDNJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_SJSM_PBDNJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_JDJJBG_JJRYJBXX.LB);
                $("#spanXJ").html(xml.Value.ES_JDJJBG_JJRYJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_JDJJBG_JJRYJBXX.QY);
                $("#spanSQ").html(xml.Value.ES_JDJJBG_JJRYJBXX.DD);

                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_JDJJBG_JJRYJBXX.LB);
                $("#spanXL").html(xml.Value.ES_JDJJBG_JJRYJBXX.XL);
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
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "XJ", "'" + $("#spanXJ").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanSQ").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if (getUrlParam("ES_JDJJBG_JJRYJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_JDJJBG_JJRYJBXXID", "'" + getUrlParam("ES_JDJJBG_JJRYJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_JDJJBG_JJRY/FB",
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
