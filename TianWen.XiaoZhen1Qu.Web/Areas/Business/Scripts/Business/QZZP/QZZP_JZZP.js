$(document).ready(function () {
    $("#DQJZKSSJ").datepicker({ minDate: 0 });
    $("#DQJZJSSJ").datepicker({ minDate: 0 });
    $("body").bind("click", function () { Close("_XZQ"); });
    $("td").bind("click", SelectJZSJ);
    LoadQZZP_JZZPJBXX();
    BindClick("JZLB");
    BindClick("XZDW");
    BindClick("XZJS");
    BindClick("GZCS");
    BindClick("QY");
    BindClick("DD");
});
//选择兼职时间
function SelectJZSJ() {
    $(this).find(".img_jzsj").each(function () {
        if ($(this).attr("src").indexOf("blue") !== -1)
            $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
        else
            $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
    });
}
//加载工作城市标签
function LoadGZCSBQ() {
    var arrayObj = new Array('RM', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    var html = "";
    for (var i = 0; i < arrayObj.length; i++) {
        if (i === 0)
            html += '<div class="div_bqss_content_bq" id="div' + arrayObj[i] + '" style="width:62px;"><span class="span_bqss_content_bq" id="span' + arrayObj[i] + '">' + "热门" + '</span><em class="em_bqss_content_bq" id="em' + arrayObj[i] + '"></em></div>';
        else
            html += '<div class="div_bqss_content_bq" id="div' + arrayObj[i] + '"><span class="span_bqss_content_bq" id="span' + arrayObj[i] + '">' + arrayObj[i] + '</span><em class="em_bqss_content_bq" id="em' + arrayObj[i] + '"></em></div>';
    }
    $("#div_bqss_body_bq").html(html);
    $(".div_bqss_content_bq").bind("click", JCBQActive);
}
//工作城市标签切换
function JCBQActive() {
    LoadGZCS("A", this.id);
}
//加载工作城市名称
function LoadGZCS(JCLX, JCBQ) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/GetDistrictByShortName",
        dataType: "json",
        data:
        {
            ShortName: JCBQ.split("div")[1]
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_mc" onclick="GZCSXZ(\'' + xml.list[i].NAME + '\',\'' + xml.list[i].CODE + '\')">' + xml.list[i].NAME + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_mc" style=\"width:200px;text-align:left;margin-left:14px;\">该字母下暂无数据</span>';
                $("#div_bqss_body_mc").html(html);
                $("#divGZCS").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择工作城市名称
function GZCSXZ(GZCSMC, GZCSID) {
    $("#CityName").val(GZCSMC);
    $("#spanGZCS").html(GZCSMC);
    $("#divGZCS").css("display", "none");
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
//加载默认
function LoadDefault() {
    ue.ready(function () {
        ue.setHeight(200);
    });
    $(".img_jzsj").each(function () {
        $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
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
        if ($(this).attr("src").indexOf("blue") !== -1)
            jzsj += this.id + ",";
    });
    return RTrim(jzsj, ',');
}
//设置兼职时间
function SetJZSJ(jzsj) {
    $(".img_jzsj").each(function () {
        if (jzsj.indexOf(this.id) !== -1)
            $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
    });
}
//绑定下拉框鼠标点击样式
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
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
        if (type === "GZCS") {
            LoadGZCSBQ();
            LoadGZCS("A", "divA");
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
    $("#BT").val($(this)[0].innerHTML);
    ValidateSelect("ZPJZLB", "JZLB", "忘记选择兼职类别啦");
}
//选择区域下拉框
function SelectQY(obj, type, code) {
    $("#QYCode").val(code);
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadDD();
}
//加载求职招聘_兼职招聘基本信息
function LoadQZZP_JZZPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/QZZP_JZZP/LoadQZZP_JZZPJBXX",
        dataType: "json",
        data:
        {
            QZZP_JZZPJBXXID: getUrlParam("QZZP_JZZPJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.QZZP_JZZPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#QZZP_JZZPJBXXID").val(xml.Value.QZZP_JZZPJBXX.QZZP_JZZPJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanJZLB").html(xml.Value.QZZP_JZZPJBXX.JZLB);
                $("#spanXZDW").html(xml.Value.QZZP_JZZPJBXX.XZDW);
                $("#spanXZJS").html(xml.Value.QZZP_JZZPJBXX.XZJS);
                $("#spanGZCS").html(xml.Value.QZZP_JZZPJBXX.GZCS);
                $("#spanQY").html(xml.Value.QZZP_JZZPJBXX.QY);
                $("#spanDD").html(xml.Value.QZZP_JZZPJBXX.DD);
                SetDX("ZPJZYXQ", xml.Value.QZZP_JZZPJBXX.JZYXQ);
                SetJZSJ(xml.Value.QZZP_JZZPJBXX.JZSJ);
                if (xml.Value.QZZP_JZZPJBXX.DQJZKSSJ.ToString("yyyy-MM-dd") !== "1-1-1")
                    $("#DQJZKSSJ").val(xml.Value.QZZP_JZZPJBXX.DQJZKSSJ.ToString("yyyy-MM-dd"));
                if (xml.Value.QZZP_JZZPJBXX.DQJZJSSJ.ToString("yyyy-MM-dd") !== "1-1-1")
                    $("#DQJZJSSJ").val(xml.Value.QZZP_JZZPJBXX.DQJZJSSJ.ToString("yyyy-MM-dd"));
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
    obj = jsonObj.AddJson(obj, "GZCS", "'" + $("#spanGZCS").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "JZYXQ", "'" + GetDX("ZPJZYXQ") + "'");
    obj = jsonObj.AddJson(obj, "JZSJ", "'" + GetJZSJ() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    if ($("#DQJZKSSJ").val() !== "")
        obj = jsonObj.AddJson(obj, "DQJZKSSJ", "'" + $("#DQJZKSSJ").val() + "'");
    if ($("#DQJZJSSJ").val() !== "")
        obj = jsonObj.AddJson(obj, "DQJZJSSJ", "'" + $("#DQJZJSSJ").val() + "'");
    if (getUrlParam("QZZP_JZZPJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "QZZP_JZZPJBXXID", "'" + getUrlParam("QZZP_JZZPJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/QZZP_JZZP/FB",
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