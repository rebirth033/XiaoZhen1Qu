$(document).ready(function () {
    LoadJBXX();
    BindClick("LB");
    BindClick("XJ");
    BindClick("CPUPP");
    BindClick("CPUHS");
    BindClick("NC");
    BindClick("YP");
    BindClick("PMCC");
    BindClick("XK");
});

//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("台式机/配件类别", "LB", "CODES_ES_SJSM", Bind, "TSJLB", "LB", "");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_SJSM", Bind, "TSJLB", "XL", "");
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
            LoadCODESByTYPENAME("台式机屏幕尺寸", "PMCC", "CODES_ES_SJSM");
        }
        if (type === "XK") {
            LoadCODESByTYPENAME("显卡", "XK", "CODES_ES_SJSM");
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM", Bind, "XJCD", "XJ", "");
        }
    });
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    if (type === "LB")
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
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/LoadES_SJSM_TSJJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_SJSM_TSJJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.ES_SJSM_TSJJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                if (xml.Value.ES_SJSM_TSJJBXX.SF !== null)
                    SetDX("SF", xml.Value.ES_SJSM_TSJJBXX.SF);
                $("#spanLB").html(xml.Value.ES_SJSM_TSJJBXX.LB);
                $("#spanXJ").html(xml.Value.ES_SJSM_TSJJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_SJSM_TSJJBXX.QY);
                $("#spanDD").html(xml.Value.ES_SJSM_TSJJBXX.DD);
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
    if (ValidateAll() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "XJ", "'" + $("#spanXJ").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("SF") + "'");

    obj = jsonObj.AddJson(obj, "CPUPP", "'" + $("#spanCPUPP").html() + "'");
    obj = jsonObj.AddJson(obj, "CPUHS", "'" + $("#spanCPUHS").html() + "'");
    obj = jsonObj.AddJson(obj, "NC", "'" + $("#spanNC").html() + "'");
    obj = jsonObj.AddJson(obj, "YP", "'" + $("#spanYP").html() + "'");
    obj = jsonObj.AddJson(obj, "PMCC", "'" + $("#spanPMCC").html() + "'");
    obj = jsonObj.AddJson(obj, "XK", "'" + $("#spanXK").html() + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/FBES_SJSM_TSJJBXX",
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
