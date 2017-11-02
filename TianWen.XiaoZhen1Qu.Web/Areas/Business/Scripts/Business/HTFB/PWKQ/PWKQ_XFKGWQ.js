$(document).ready(function () {
    $("#YXQZ").datepicker({ minDate: 0 });
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadPWKQ_XFKGWQJBXX();
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("消费卡/购物券", "LB", "CODES_PWKQ", Bind, "XFKGWQLB", "LB", "");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载票务卡券_电影票基本信息
function LoadPWKQ_XFKGWQJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PWKQ/LoadPWKQ_XFKGWQJBXX",
        dataType: "json",
        data:
        {
            PWKQ_XFKGWQJBXXID: getUrlParam("PWKQ_XFKGWQJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.PWKQ_XFKGWQJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#PWKQ_XFKGWQJBXXID").val(xml.Value.PWKQ_XFKGWQJBXX.PWKQ_XFKGWQJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.PWKQ_XFKGWQJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.PWKQ_XFKGWQJBXX.GQ);
                $("#spanLB").html(xml.Value.PWKQ_XFKGWQJBXX.LB);
                $("#spanQY").html(xml.Value.PWKQ_XFKGWQJBXX.QY);
                $("#spanDD").html(xml.Value.PWKQ_XFKGWQJBXX.DD);
                if (xml.Value.PWKQ_XFKGWQJBXX.YXQZ.ToString("yyyy-MM-dd") !== "1-1-1")
                    $("#YXQZ").val(xml.Value.PWKQ_XFKGWQJBXX.YXQZ.ToString("yyyy-MM-dd"));
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
    if (getUrlParam("PWKQ_XFKGWQJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "PWKQ_XFKGWQJBXXID", "'" + getUrlParam("PWKQ_XFKGWQJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PWKQ/FBPWKQ_XFKGWQJBXX",
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
