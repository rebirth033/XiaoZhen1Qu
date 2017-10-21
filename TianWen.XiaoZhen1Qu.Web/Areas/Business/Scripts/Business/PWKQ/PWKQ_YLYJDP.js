var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#YXQZ").datepicker({ minDate: 0 });
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    
    $("body").bind("click", function () { Close("_XZQ"); Close("LB"); Close("XL"); Close("XJ"); Close("QY"); Close("DD"); });




    LoadDefault();
    LoadPWKQ_YLYJDPJBXX();
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
});
//描述框focus
function FYMSFocus() {
    $("#FYMS").css("color", "#333333");
}
//描述框blur
function FYMSBlur() {
    $("#FYMS").css("color", "#999999");
}
//描述框设默认文本
function FYMSSetDefault() {
    var fyms = "1.房屋特征：\r\n\r\n2.周边配套：\r\n\r\n3.房东心态：";
    $("#FYMS").html(fyms);
}
//加载默认
function LoadDefault() {
    ue.ready(function () {
        ue.setHeight(200);
    });
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("游乐园/景点票", "LB", "CODES_PWKQ");
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
function LoadPWKQ_YLYJDPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PWKQ_YLYJDP/LoadPWKQ_YLYJDPJBXX",
        dataType: "json",
        data:
        {
            PWKQ_YLYJDPJBXXID: getUrlParam("PWKQ_YLYJDPJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.PWKQ_YLYJDPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#PWKQ_YLYJDPJBXXID").val(xml.Value.PWKQ_YLYJDPJBXX.PWKQ_YLYJDPJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.PWKQ_YLYJDPJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.PWKQ_YLYJDPJBXX.GQ);
                $("#spanLB").html(xml.Value.PWKQ_YLYJDPJBXX.LB);
                $("#spanQY").html(xml.Value.PWKQ_YLYJDPJBXX.JYQY);
                $("#spanDD").html(xml.Value.PWKQ_YLYJDPJBXX.JYDD);
                if (xml.Value.PWKQ_YLYJDPJBXX.YXQZ.ToString("yyyy-MM-dd") !== "1-1-1")
                    $("#YXQZ").val(xml.Value.PWKQ_YLYJDPJBXX.YXQZ.ToString("yyyy-MM-dd"));
                return;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//发布
function FB() {
    if (AllValidate() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "JYQY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "JYDD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if ($("#YXQZ").val() !== "")
        obj = jsonObj.AddJson(obj, "YXQZ", "'" + $("#YXQZ").val() + "'");
    if (getUrlParam("PWKQ_YLYJDPJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "PWKQ_YLYJDPJBXXID", "'" + getUrlParam("PWKQ_YLYJDPJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PWKQ_YLYJDP/FB",
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
