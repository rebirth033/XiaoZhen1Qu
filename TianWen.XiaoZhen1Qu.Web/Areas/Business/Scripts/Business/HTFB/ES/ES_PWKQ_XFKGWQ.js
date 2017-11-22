﻿$(document).ready(function () {
    $("#YXQZ").datepicker({ minDate: 0 });
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadES_PWKQ_XFKGWQJBXX();
    BindClick("LB");
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("消费卡/购物券", "LB", "CODES_ES_PWKQ", Bind, "XFKGWQLB", "LB", "");
        }
    });
}
//加载票务卡券_电影票基本信息
function LoadES_PWKQ_XFKGWQJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/LoadES_PWKQ_XFKGWQJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_PWKQ_XFKGWQJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.ES_PWKQ_XFKGWQJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.ES_PWKQ_XFKGWQJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_PWKQ_XFKGWQJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_PWKQ_XFKGWQJBXX.LB);
                $("#spanQY").html(xml.Value.ES_PWKQ_XFKGWQJBXX.QY);
                $("#spanDD").html(xml.Value.ES_PWKQ_XFKGWQJBXX.DD);
                if (xml.Value.ES_PWKQ_XFKGWQJBXX.YXQZ.ToString("yyyy-MM-dd") !== "1-1-1")
                    $("#YXQZ").val(xml.Value.ES_PWKQ_XFKGWQJBXX.YXQZ.ToString("yyyy-MM-dd"));
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
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if ($("#YXQZ").val() !== "")
        obj = jsonObj.AddJson(obj, "YXQZ", "'" + $("#YXQZ").val() + "'");
    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/FBES_PWKQ_XFKGWQJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            BCMS: ue.getContent()
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