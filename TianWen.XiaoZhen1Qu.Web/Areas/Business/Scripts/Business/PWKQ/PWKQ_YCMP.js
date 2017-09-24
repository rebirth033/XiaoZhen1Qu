var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#imgZR").bind("click", ZRSelect);
    $("#imgQG").bind("click", QGSelect);
    $("#YXQZ").datepicker({ minDate: 0 });
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#span_content_info_qhcs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("LB"); Close("XL"); Close("XJ"); Close("QY"); Close("DD"); });
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);

    LoadTXXX();
    LoadDefault();
    LoadPWKQ_DYPJBXX();
    BindClick("LB");
    BindClick("XJ");
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
    $("#imgZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgQG").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择转让
function ZRSelect() {
    $("#imgZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgQG").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择求购
function QGSelect() {
    $("#imgZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgQG").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadLB();
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载类别
function LoadLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_PWKQ",
        dataType: "json",
        data:
        {
            TYPENAME: "演出门票"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"LB\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divLB").html(html);
                $("#divLB").css("display", "block");
                ActiveStyle("LB");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//获取供求
function GetGQ() {
    if ($("#imgZR").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置供求
function SetGQ(gq) {
    if (gq === 0) {
        $("#imgZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgQG").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgQG").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//加载票务卡券_电影票基本信息
function LoadPWKQ_DYPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PWKQ_DYP/LoadPWKQ_DYPJBXX",
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
                    ue.setContent(xml.Value.PWKQ_DYPJBXX.BCMS);
                });
                SetGQ(xml.Value.PWKQ_DYPJBXX.GQ);
                $("#spanLB").html(xml.Value.PWKQ_DYPJBXX.LB);
                $("#spanQY").html(xml.Value.PWKQ_DYPJBXX.JYQY);
                $("#spanDD").html(xml.Value.PWKQ_DYPJBXX.JYDD);
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
    if (AllValidate() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "JYQY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "JYDD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetGQ() + "'");

    if ($("#YXQZ").val() !== "")
        obj = jsonObj.AddJson(obj, "YXQZ", "'" + $("#YXQZ").val() + "'");
    if (getUrlParam("PWKQ_DYPJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "PWKQ_DYPJBXXID", "'" + getUrlParam("PWKQ_DYPJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PWKQ_DYP/FB",
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
