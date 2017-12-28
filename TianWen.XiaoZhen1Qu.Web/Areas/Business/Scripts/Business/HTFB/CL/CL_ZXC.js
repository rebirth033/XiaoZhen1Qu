$(document).ready(function () {
    LoadJBXX();
    BindClick("CX");
    BindClick("PP");
    BindClick("CC");
    BindClick("XJ");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "CX") {
            LoadCODESByTYPENAME("自行车车型", "CX", "CODES_CL", Bind, "ZXCCX", "CX", "");
        }
        if (type === "PP") {
            LoadCODESByTYPENAME("自行车品牌", "PP", "CODES_CL");
        }
        if (type === "CC") {
            LoadCODESByTYPENAME("自行车尺寸", "CC", "CODES_CL");
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
//加载车辆_自行车基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL/LoadCL_ZXCJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_ZXCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.CL_ZXCJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanCX").html(xml.Value.CL_ZXCJBXX.CX);
                $("#spanXJ").html(xml.Value.CL_ZXCJBXX.XJ);
                $("#spanQY").html(xml.Value.CL_ZXCJBXX.QY);
                $("#spanDD").html(xml.Value.CL_ZXCJBXX.DD);
                $("#spanPP").html(xml.Value.CL_ZXCJBXX.PP);
                $("#spanCC").html(xml.Value.CL_ZXCJBXX.CC);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.CL_ZXCJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.CL_ZXCJBXX.GQ);
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
    obj = jsonObj.AddJson(obj, "XJ", "'" + $("#spanXJ").html() + "'");
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanPP").html() + "'");
    obj = jsonObj.AddJson(obj, "CC", "'" + $("#spanCC").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL/FBCL_ZXCJBXX",
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
