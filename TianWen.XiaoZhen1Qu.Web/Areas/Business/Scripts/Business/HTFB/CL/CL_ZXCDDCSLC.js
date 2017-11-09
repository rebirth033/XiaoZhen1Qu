$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadCL_ZXCDDCSLCJBXX();
    BindClick("LB");
    BindClick("XJ");
    BindClick("QY");
    BindClick("DD");
});
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("自行车/电动车/三轮车", "LB", "CODES_CL", Bind, "ZXCDDCSLCLB", "LB", "");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_CL", Bind, "ZXCDDCSLCLB", "XL", "");
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM", Bind, "XJCD", "XJ", "");
        }
        if (type === "ZXCPP") {
            LoadCODESByTYPENAME("自行车品牌", "ZXCPP", "CODES_CL");
        }
        if (type === "CC") {
            LoadCODESByTYPENAME("自行车尺寸", "CC", "CODES_CL");
        }
        if (type === "DDCPP") {
            LoadCODESByTYPENAME("电动车品牌", "DDCPP", "CODES_CL");
        }
        if (type === "DCDY") {
            LoadCODESByTYPENAME("电池电压", "DCDY", "CODES_CL");
        }
        if (type === "DCRL") {
            LoadCODESByTYPENAME("电池容量", "DCRL", "CODES_CL");
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
    if(type === "LB")
    PDLB(obj.innerHTML);
}
//判断类别
function PDLB(LB) {
    if (LB === "自行车") {
        $("#divZXCXXCS").css("display", "");
        $("#divDDCXXCS").css("display", "none");
        BindClick("ZXCPP");
        BindClick("CC");
    }
    else if (LB === "电动车") {
        $("#divZXCXXCS").css("display", "none");
        $("#divDDCXXCS").css("display", "");
        BindClick("DDCPP");
        BindClick("DCDY");
        BindClick("DCRL");
    }
    else {
        $("#divZXCXXCS").css("display", "none");
        $("#divDDCXXCS").css("display", "none");
    }
    BindClick("XL");
}
//选择自行车/电动车/三轮车品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载车辆_自行车/电动车/三轮车基本信息
function LoadCL_ZXCDDCSLCJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL/LoadCL_ZXCDDCSLCJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_ZXCDDCSLCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.CL_ZXCDDCSLCJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.CL_ZXCDDCSLCJBXX.LB);
                $("#spanXJ").html(xml.Value.CL_ZXCDDCSLCJBXX.XJ);
                $("#spanQY").html(xml.Value.CL_ZXCDDCSLCJBXX.QY);
                $("#spanDD").html(xml.Value.CL_ZXCDDCSLCJBXX.DD);
                $("#spanDDCPP").html(xml.Value.CL_ZXCDDCSLCJBXX.DDCPP);
                $("#spanZXCPP").html(xml.Value.CL_ZXCDDCSLCJBXX.ZXCPP);
                $("#spanCC").html(xml.Value.CL_ZXCDDCSLCJBXX.CC);
                $("#spanDCDY").html(xml.Value.CL_ZXCDDCSLCJBXX.DCDY);
                $("#spanDCRL").html(xml.Value.CL_ZXCDDCSLCJBXX.DCRL);
                $("#spanXL").html(xml.Value.CL_ZXCDDCSLCJBXX.XL);
                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.CL_ZXCDDCSLCJBXX.LB);
                if (xml.Value.CL_ZXCDDCSLCJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.CL_ZXCDDCSLCJBXX.GQ);
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
    obj = jsonObj.AddJson(obj, "DDCPP", "'" + $("#spanDDCPP").html() + "'");
    obj = jsonObj.AddJson(obj, "ZXCPP", "'" + $("#spanZXCPP").html() + "'");
    obj = jsonObj.AddJson(obj, "CC", "'" + $("#spanCC").html() + "'");
    obj = jsonObj.AddJson(obj, "DCDY", "'" + $("#spanDCDY").html() + "'");
    obj = jsonObj.AddJson(obj, "DCRL", "'" + $("#spanDCRL").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL/FBCL_ZXCDDCSLCJBXX",
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
