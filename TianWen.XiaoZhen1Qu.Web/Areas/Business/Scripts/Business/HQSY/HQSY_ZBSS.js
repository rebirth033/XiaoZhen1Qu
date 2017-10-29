$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
    LoadHQSY_ZBSSJBXX();
});
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("珠宝首饰", "LB", "CODES_HQSY", Bind, "ZBSSLB", "LB", "");
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
function SelectLB(obj, type, lbid) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#LBID").val(lbid);
}
//加载婚庆摄影_珠宝首饰基本信息
function LoadHQSY_ZBSSJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY_ZBSS/LoadHQSY_ZBSSJBXX",
        dataType: "json",
        data:
        {
            HQSY_ZBSSJBXXID: getUrlParam("HQSY_ZBSSJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.HQSY_ZBSSJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#HQSY_ZBSSJBXXID").val(xml.Value.HQSY_ZBSSJBXX.HQSY_ZBSSJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.HQSY_ZBSSJBXX.LB);
                $("#spanQY").html(xml.Value.HQSY_ZBSSJBXX.QY);
                $("#spanDD").html(xml.Value.HQSY_ZBSSJBXX.DD);
                LoadPhotos(xml.Value.Photos);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");

    if (getUrlParam("HQSY_ZBSSJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "HQSY_ZBSSJBXXID", "'" + getUrlParam("HQSY_ZBSSJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY_ZBSS/FB",
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