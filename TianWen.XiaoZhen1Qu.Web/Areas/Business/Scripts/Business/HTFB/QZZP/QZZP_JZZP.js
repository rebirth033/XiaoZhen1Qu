$(document).ready(function () {
    $("#DQJZKSSJ").datepicker({ minDate: 0 });
    $("#DQJZJSSJ").datepicker({ minDate: 0 });
    $("td").bind("click", SelectJZSJ);
    LoadJBXX();
    BindClick("JZLB");
    BindClick("XZDW");
    BindClick("XZJS");
    BindClick("GZCS");
    $(".img_jzsj").each(function () { $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png"); });
});
//选择兼职时间
function SelectJZSJ() {
    $(this).find(".img_jzsj").each(function () {
        if ($(this).attr("src").indexOf("purple") !== -1)
            $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
        else
            $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/check_purple.png");
    });
    ValidateJZSJ();
}
//显示职位类别
function ShowJZLBThird() {
    $(this).find(".div_JZLB_third").each(function () {
        $(this).css("display", "block");
    });
}
//隐藏职位类别
function HideJZLBThird() {
    $(this).find(".div_JZLB_third").each(function () {
        $(this).css("display", "none");
    });
}
//设置兼职有效期
function SetJZYXQ(JZYXQ) {
    if (JZYXQ === 0) {
        $("#divDQJZSJ").css("display", "");
    }
    else {
        $("#divDQJZSJ").css("display", "none");
    }
}
//获取兼职时间
function GetJZSJ() {
    var jzsj = "";
    $(".img_jzsj").each(function () {
        if ($(this).attr("src").indexOf("purple") !== -1)
            jzsj += this.id + ",";
    });
    return RTrim(jzsj, ',');
}
//设置兼职时间
function SetJZSJ(jzsj) {
    $(".img_jzsj").each(function () {
        if (jzsj.indexOf(this.id) !== -1)
            $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/check_purple.png");
    });
}
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "XZDW") {
            LoadCODESByTYPENAME("薪资水平单位", "XZDW", "CODES_QZZP", Bind, "ZPXZSP", "XZDW", "");
        }
        if (type === "XZJS") {
            LoadCODESByTYPENAME("薪资结算", "XZJS", "CODES_QZZP", Bind, "ZPXZJS", "XZJS", "");
        }
        if (type === "JZLB") {
            LoadJZLB();
        }
    });
}
//加载兼职类别
function LoadJZLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "兼职类别",
            TBName: "CODES_QZZP"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = '<div class="div_jzlb">';
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_jzlb">' + xml.list[i].CODENAME + '</span>';
                }
                html += '</div>';
                $("#divJZLB").html(html);
                $("#divJZLB").css("display", "block");
                $(".span_jzlb").bind("click", SelectJZLB);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择兼职类别
function SelectJZLB() {
    $("#spanJZLB").html($(this)[0].innerHTML);
    $("#divJZLB").css("display", "none");
    ValidateSelect("ZPJZLB", "JZLB", "忘记选择兼职类别啦");
}
//加载求职招聘_兼职招聘基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/QZZP/LoadQZZP_JZZPJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.QZZP_JZZPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.QZZP_JZZPJBXX.ID);
                //设置编辑器的内容
                ue.ready(function() { ue.setContent(xml.Value.BCMSString); });
                $("#spanJZLB").html(xml.Value.QZZP_JZZPJBXX.JZLB);
                $("#spanXZDW").html(xml.Value.QZZP_JZZPJBXX.XZDW);
                $("#spanXZJS").html(xml.Value.QZZP_JZZPJBXX.XZJS);
                $("#spanQY").html(xml.Value.QZZP_JZZPJBXX.QY);
                $("#spanDD").html(xml.Value.QZZP_JZZPJBXX.DD);
                SetDX("ZPJZYXQ", xml.Value.QZZP_JZZPJBXX.JZYXQ);
                SetJZSJ(xml.Value.QZZP_JZZPJBXX.JZSJ);
                if (xml.Value.QZZP_JZZPJBXX.DQJZKSSJ.ToString("yyyy-MM-dd") !== "1-1-1")
                    $("#DQJZKSSJ").val(xml.Value.QZZP_JZZPJBXX.DQJZKSSJ.ToString("yyyy-MM-dd"));
                if (xml.Value.QZZP_JZZPJBXX.DQJZJSSJ.ToString("yyyy-MM-dd") !== "1-1-1")
                    $("#DQJZJSSJ").val(xml.Value.QZZP_JZZPJBXX.DQJZJSSJ.ToString("yyyy-MM-dd"));
            } else {
                $("#spanJZLB").html($("#spanLBXZ").html().replace("1.", ""));
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
    obj = jsonObj.AddJson(obj, "JZLB", "'" + $("#spanJZLB").html() + "'");
    obj = jsonObj.AddJson(obj, "XZDW", "'" + $("#spanXZDW").html() + "'");
    obj = jsonObj.AddJson(obj, "XZJS", "'" + $("#spanXZJS").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "JZYXQ", "'" + GetDX("ZPJZYXQ") + "'");
    obj = jsonObj.AddJson(obj, "JZSJ", "'" + GetJZSJ() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    if ($("#DQJZKSSJ").val() !== "")
        obj = jsonObj.AddJson(obj, "DQJZKSSJ", "'" + $("#DQJZKSSJ").val() + "'");
    if ($("#DQJZJSSJ").val() !== "")
        obj = jsonObj.AddJson(obj, "DQJZJSSJ", "'" + $("#DQJZJSSJ").val() + "'");
    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/QZZP/FBQZZP_JZZPJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            BCMS: ue.getContent()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.location.href = getRootPath() + "/Business/FBCG/FBCG?LBID=" + getUrlParam("CLICKID") + "&ID=" + xml.Value.ID + "&JCXXID=" + xml.Value.JCXXID;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}