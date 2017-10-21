var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    
    
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    
    $("body").bind("click", function () { Close("_XZQ"); Close("LB"); Close("XL"); Close("XJ"); Close("QY"); Close("DD"); });




    LoadDefault();
    LoadES_SJSM_TSJJBXX();
    BindClick("LB");
    BindClick("PBPP");
    BindClick("PBXH");
    BindClick("XJ");
    BindClick("QY");
    BindClick("DD");

    BindClick("CPUPP");
    BindClick("CPUHS");
    BindClick("NC");
    BindClick("YP");
    BindClick("PMCC");
    BindClick("XK");
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
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("台式机/配件","LB","CODES_ES_SJSM");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_SJSM");
        }
        if (type === "CPUPP") {
            LoadCODESByTYPENAME("CPU品牌", "CPUPP", "CODES_ES_SJSM");
        }
        if (type === "CPUHS") {
            LoadCODESByTYPENAME("CPU核数", "CPUHS", "CODES_ES_SJSM");
        }
        if (type === "NC") {
            LoadCODESByTYPENAME("内存", "NC", "CODES_ES_SJSM");
        }
        if (type === "YP") {
            LoadCODESByTYPENAME("硬盘", "YP", "CODES_ES_SJSM");
        }
        if (type === "PMCC") {
            LoadCODESByTYPENAME("屏幕尺寸", "PMCC", "CODES_ES_SJSM");
        }
        if (type === "XK") {
            LoadCODESByTYPENAME("显卡", "XK", "CODES_ES_SJSM");
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
    if (LB === "台式机") {
        $("#divTSJXXCS").css("display", "");
        $("#divTSJXXCS_2").css("display", "");
        $("#divXLText").css("display", "none");
    }
    else {
        $("#divTSJXXCS").css("display", "none");
        $("#divTSJXXCS_2").css("display", "none");
        $("#divXLText").css("display", "");
        BindClick("XL");
    }
}
//选择台式机/配件品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载二手_手机数码_台式机/配件基本信息
function LoadES_SJSM_TSJJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_SJSM_TSJ/LoadES_SJSM_TSJJBXX",
        dataType: "json",
        data:
        {
            ES_SJSM_TSJJBXXID: getUrlParam("ES_SJSM_TSJJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_SJSM_TSJJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_SJSM_TSJJBXXID").val(xml.Value.ES_SJSM_TSJJBXX.ES_SJSM_TSJJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.ES_SJSM_PBDNJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_SJSM_PBDNJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_SJSM_TSJJBXX.LB);
                $("#spanXJ").html(xml.Value.ES_SJSM_TSJJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_SJSM_TSJJBXX.JYQY);
                $("#spanDD").html(xml.Value.ES_SJSM_TSJJBXX.JYDD);
                $("#spanXL").html(xml.Value.ES_SJSM_TSJJBXX.XL);

                $("#spanCPUPP").html(xml.Value.ES_SJSM_TSJJBXX.CPUPP);
                $("#spanCPUHS").html(xml.Value.ES_SJSM_TSJJBXX.CPUHS);
                $("#spanNC").html(xml.Value.ES_SJSM_TSJJBXX.NC);
                $("#spanYP").html(xml.Value.ES_SJSM_TSJJBXX.YP);
                $("#spanPMCC").html(xml.Value.ES_SJSM_TSJJBXX.PMCC);
                $("#spanXK").html(xml.Value.ES_SJSM_TSJJBXX.XK);

                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_SJSM_TSJJBXX.LB);
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
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "XJ", "'" + $("#spanXJ").html() + "'");
    obj = jsonObj.AddJson(obj, "JYQY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "JYDD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    obj = jsonObj.AddJson(obj, "CPUPP", "'" + $("#spanCPUPP").html() + "'");
    obj = jsonObj.AddJson(obj, "CPUHS", "'" + $("#spanCPUHS").html() + "'");
    obj = jsonObj.AddJson(obj, "NC", "'" + $("#spanNC").html() + "'");
    obj = jsonObj.AddJson(obj, "YP", "'" + $("#spanYP").html() + "'");
    obj = jsonObj.AddJson(obj, "PMCC", "'" + $("#spanPMCC").html() + "'");
    obj = jsonObj.AddJson(obj, "XK", "'" + $("#spanXK").html() + "'");

    if (getUrlParam("ES_SJSM_TSJJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_SJSM_TSJJBXXID", "'" + getUrlParam("ES_SJSM_TSJJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_SJSM_TSJ/FB",
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
