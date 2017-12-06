$(document).ready(function () {

    BindClick("HLLX");
    BindClick("JDXJ");
    LoadHQSY_HYJDJBXX();
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "HLLX") {
            LoadCODESByTYPENAME("婚宴酒店婚礼类型", "HLLX", "CODES_HQSY", Bind, "HYJDHLLX", "HLLX", "");
        }
        if (type === "JDXJ") {
            LoadCODESByTYPENAME("酒店星级", "JDXJ", "CODES_HQSY", Bind, "HYJDJDXJ", "JDXJ", "");
        }
        if (type === "XL") {
            LoadXL();
        }
    });
}
//选择类别下拉框
function SelectLB(obj, type, lbid) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#LBID").val(lbid);
}
//加载婚庆摄影_婚宴酒店基本信息
function LoadHQSY_HYJDJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY/LoadHQSY_HYJDJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.HQSY_HYJDJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.HQSY_HYJDJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanHLLX").html(xml.Value.HQSY_HYJDJBXX.HLLX);
                $("#spanJDXJ").html(xml.Value.HQSY_HYJDJBXX.JDXJ);
                $("#spanQY").html(xml.Value.HQSY_HYJDJBXX.QY);
                $("#spanDD").html(xml.Value.HQSY_HYJDJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.HQSY_HYJDJBXX.JDLX !== null)
                    SetDX("JDLX", xml.Value.HQSY_HYJDJBXX.JDLX);
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
    obj = jsonObj.AddJson(obj, "HLLX", "'" + $("#spanHLLX").html() + "'");
    obj = jsonObj.AddJson(obj, "JDXJ", "'" + $("#spanJDXJ").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "JDLX", "'" + GetDX("JDLX") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY/FBHQSY_HYJDJBXX",
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