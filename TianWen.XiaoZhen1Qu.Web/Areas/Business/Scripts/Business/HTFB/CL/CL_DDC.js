$(document).ready(function () {

    LoadCL_DDCJBXX();
    BindClick("CX");
    BindClick("PP");
    BindClick("DCDY");
    BindClick("DCRL");
    BindClick("XJ");
});
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "CX") {
            LoadCODESByTYPENAME("电动车车型", "CX", "CODES_CL", Bind, "DDCCX", "CX", "");
        }
        if (type === "PP") {
            LoadCODESByTYPENAME("电动车品牌", "PP", "CODES_CL", Bind, "DDCPP", "PP", "");
        }
        if (type === "DCDY") {
            LoadCODESByTYPENAME("电动车电池电压", "DCDY", "CODES_CL", Bind, "DDCDCDY", "DCDY", "");
        }
        if (type === "DCRL") {
            LoadCODESByTYPENAME("电动车电池容量", "DCRL", "CODES_CL", Bind, "DDCDCRL", "DCRL", "");
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
}
//加载车辆_自行车/电动车/三轮车基本信息
function LoadCL_DDCJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL/LoadCL_DDCJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_DDCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.CL_DDCJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setHeight(200); ue.setContent(xml.Value.BCMSString); });
                $("#spanCX").html(xml.Value.CL_DDCJBXX.CX);
                $("#spanPP").html(xml.Value.CL_DDCJBXX.PP);
                $("#spanXJ").html(xml.Value.CL_DDCJBXX.XJ);
                $("#spanQY").html(xml.Value.CL_DDCJBXX.QY);
                $("#spanDD").html(xml.Value.CL_DDCJBXX.DD);
                $("#spanDCDY").html(xml.Value.CL_DDCJBXX.DCDY);
                $("#spanDCRL").html(xml.Value.CL_DDCJBXX.DCRL);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.CL_DDCJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.CL_DDCJBXX.GQ);
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
    obj = jsonObj.AddJson(obj, "XJ", "'" + $("#spanXJ").html() + "'");
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
        url: getRootPath() + "/Business/CL/FBCL_DDCJBXX",
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
