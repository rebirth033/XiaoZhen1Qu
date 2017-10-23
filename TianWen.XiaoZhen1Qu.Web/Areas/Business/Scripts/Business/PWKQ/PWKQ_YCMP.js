
$(document).ready(function () {
    $("#SJ").datepicker({ minDate: 0 });$("body").bind("click", function () { Close("_XZQ");});




    
    LoadPWKQ_YCMPJBXX();
    BindClick("LB");
    BindClick("XJ");
    BindClick("QY");
    BindClick("DD");
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("演出门票", "LB", "CODES_PWKQ");
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
function LoadPWKQ_YCMPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PWKQ_YCMP/LoadPWKQ_YCMPJBXX",
        dataType: "json",
        data:
        {
            PWKQ_YCMPJBXXID: getUrlParam("PWKQ_YCMPJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.PWKQ_YCMPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#PWKQ_YCMPJBXXID").val(xml.Value.PWKQ_YCMPJBXX.PWKQ_YCMPJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.PWKQ_YCMPJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.PWKQ_YCMPJBXX.GQ);
                $("#spanLB").html(xml.Value.PWKQ_YCMPJBXX.LB);
                $("#spanQY").html(xml.Value.PWKQ_YCMPJBXX.QY);
                $("#spanDD").html(xml.Value.PWKQ_YCMPJBXX.DD);
                if (xml.Value.PWKQ_YCMPJBXX.SJ.ToString("yyyy-MM-dd") !== "1-1-1")
                    $("#SJ").val(xml.Value.PWKQ_YCMPJBXX.SJ.ToString("yyyy-MM-dd"));
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

    if ($("#SJ").val() !== "")
        obj = jsonObj.AddJson(obj, "SJ", "'" + $("#SJ").val() + "'");
    if (getUrlParam("PWKQ_YCMPJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "PWKQ_YCMPJBXXID", "'" + getUrlParam("PWKQ_YCMPJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PWKQ_YCMP/FB",
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
