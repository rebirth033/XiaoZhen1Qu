$(document).ready(function () {
    $("#YXQZ").datepicker({ minDate: 0 });
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadPWKQ_DYPJBXX();
    BindClick("QY");
    BindClick("DD");
});
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载票务卡券_电影票基本信息
function LoadPWKQ_DYPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PWKQ/LoadPWKQ_DYPJBXX",
        dataType: "json",
        data:
        {
            PWKQ_DYPJBXXID: getUrlParam("PWKQ_DYPJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.PWKQ_DYPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#PWKQ_DYPJBXXID").val(xml.Value.PWKQ_DYPJBXX.PWKQ_DYPJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.PWKQ_DYPJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.PWKQ_DYPJBXX.GQ);
                if (xml.Value.PWKQ_DYPJBXX.LB !== null)
                    SetDX("KQLB", xml.Value.PWKQ_DYPJBXX.LB);
                $("#spanQY").html(xml.Value.PWKQ_DYPJBXX.QY);
                $("#spanDD").html(xml.Value.PWKQ_DYPJBXX.DD);
                if (xml.Value.PWKQ_DYPJBXX.YXQZ.ToString("yyyy-MM-dd") !== "1-1-1")
                    $("#YXQZ").val(xml.Value.PWKQ_DYPJBXX.YXQZ.ToString("yyyy-MM-dd"));
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
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDX("KQLB") + "'");

    if ($("#YXQZ").val() !== "")
        obj = jsonObj.AddJson(obj, "YXQZ", "'" + $("#YXQZ").val() + "'");
    if (getUrlParam("PWKQ_DYPJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "PWKQ_DYPJBXXID", "'" + getUrlParam("PWKQ_DYPJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PWKQ/FBPWKQ_DYPJBXX",
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
