
$(document).ready(function () {$("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });LoadXXYL_QPZYJBXX();
    
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("棋牌桌游", "LB", "CODES_XXYL");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载休闲娱乐_棋牌桌游基本信息
function LoadXXYL_QPZYJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/XXYL_QPZY/LoadXXYL_QPZYJBXX",
        dataType: "json",
        data:
        {
            XXYL_QPZYJBXXID: getUrlParam("XXYL_QPZYJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.XXYL_QPZYJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#XXYL_QPZYJBXXID").val(xml.Value.XXYL_QPZYJBXX.XXYL_QPZYJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.XXYL_QPZYJBXX.LB);
                $("#spanQY").html(xml.Value.XXYL_QPZYJBXX.QY);
                $("#spanDD").html(xml.Value.XXYL_QPZYJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("XXYL_QPZYJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "XXYL_QPZYJBXXID", "'" + getUrlParam("XXYL_QPZYJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/XXYL_QPZY/FB",
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