var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#imgDQZP").bind("click", DQZPSelect);
    $("#imgCQZP").bind("click", CQZPSelect);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#DQJZKSSJ").datepicker({ minDate: 0 });
    $("#DQJZJSSJ").datepicker({ minDate: 0 });
    $("#span_content_info_qCWFWs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("JZLB"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);
    $("td").bind("click", SelectJZSJ);
    LoadTXXX();
    LoadDefault();
    LoadQZZP_JZZPJBXX();
    BindClick("JZLB");
    BindClick("XZSPDW");
    BindClick("XZJS");
    BindClick("GZCS");
    BindClick("QY");
    BindClick("DD");
});
//选择兼职时间
function SelectJZSJ() {
    $(this).find(".img_jzsj").each(function () {
        if($(this).attr("src").indexOf("blue") !== -1)
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
            html += '<div class="divstep_yx" id="div' + arrayObj[i] + '" style="width:62px;"><span class="spanstep_yx" id="span' + arrayObj[i] + '">' + "热门" + '</span><em class="emstep_yx" id="em' + arrayObj[i] + '"></em></div>';
        else
            html += '<div class="divstep_yx" id="div' + arrayObj[i] + '"><span class="spanstep_yx" id="span' + arrayObj[i] + '">' + arrayObj[i] + '</span><em class="emstep_yx" id="em' + arrayObj[i] + '"></em></div>';
    }
    $("#div_content_yxbq").html(html);
    $(".divstep_yx").bind("click", JCBQActive);
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
                    html += '<span class="span_yxmc" onclick="GZCSXZ(\'' + xml.list[i].NAME + '\',\'' + xml.list[i].CODE + '\')">' + xml.list[i].NAME + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_yxmc" style=\"width:200px;text-align:left;margin-left:14px;\">该字母下暂无数据</span>';
                $("#div_content_yxmc").html(html);
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
    $("#imgDQZP").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgCQZP").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $(".img_jzsj").each(function () {
        $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    });
}
//选择短期招聘
function DQZPSelect() {
    $("#imgDQZP").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgCQZP").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#divDQJZSJ").css("display", "");
}
//选择长期招聘
function CQZPSelect() {
    $("#imgDQZP").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgCQZP").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#divDQJZSJ").css("display", "none");
}
//获取兼职有效期
function GetJZYXQ() {
    if ($("#imgDQZP").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置兼职有效期
function SetJZYXQ(JZYXQ) {
    if (JZYXQ === 0) {
        $("#imgDQZP").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgCQZP").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#divDQJZSJ").css("display", "");
    }
    else {
        $("#imgDQZP").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgCQZP").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#divDQJZSJ").css("display", "none");
    }
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "XZSPDW") {
            LoadDropdown("薪资水平单位", "XZSPDW");
        }
        if (type === "XZJS") {
            LoadDropdown("薪资结算", "XZJS");
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
        url: getRootPath() + "/Business/Common/LoadCODES_QZZP",
        dataType: "json",
        data:
        {
            TYPENAME: "兼职类别"
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
}
//加载兼职招聘类别
function LoadDropdown(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_QZZP",
        dataType: "json",
        data:
        {
            TYPENAME: type
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"" + id + "\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#div" + id).html(html);
                $("#div" + id).css("display", "block");
                ActiveStyle(id);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载职位福利
function LoadZWFL() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_QZZP",
        dataType: "json",
        data:
        {
            TYPENAME: "职位福利"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liZWFL' onclick='SelectZWFL(this)'><img class='img_ZWFL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 5 || i === 11 || i === 17 || i === 23 || i === 29) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 6) === 0)
                    $("#divZWFL").css("height", parseInt(xml.list.length / 6) * 45 + "px");
                else
                    $("#divZWFL").css("height", (parseInt(xml.list.length / 6) + 1) * 45 + "px");
                html += "</ul>";
                $("#divZWFLText").html(html);
                $(".img_ZWFL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadQZZP_JZZPJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择职位福利
function SelectZWFL(obj) {
    if ($(obj).find("img").attr("src").indexOf("blue") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
}
//获取职位福利
function GetZWFL() {
    var ZWFL = "";
    $(".liZWFL").each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            ZWFL += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(ZWFL, ',');
}
//设置职位福利
function SetZWFL(lbs) {
    if (lbs !== "" && lbs !== null) {
        var lbarray = lbs.split(',');
        for (var i = 0; i < lbarray.length; i++) {
            $(".liZWFL").each(function () {
                if ($(this).find("label")[0].innerHTML.indexOf(lbarray[i]) !== -1)
                    $(this).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
            });
        }
    }
}
//加载区域
function LoadQY() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadQYByXZQ",
        dataType: "json",
        data:
        {
            XZQ:$("#CityName").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectQY(this,\"QY\",\"" + xml.list[i].CODE + "\")'>" + RTrim(RTrim(RTrim(xml.list[i].NAME, '市'), '区'), '县') + "</li>";
                }
                html += "</ul>";
                $("#divQY").html(html);
                $("#divQY").css("display", "block");
                ActiveStyle("QY");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载地段
function LoadDD() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadSQ",
        dataType: "json",
        data:
        {
            QY: $("#QYCode").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"DD\")'>" + RTrimStr(xml.list[i].NAME, '街道,镇,林场,管理处') + "</li>";
                }
                html += "</ul>";
                $("#divDD").html(html);
                $("#divDD").css("display", "block");
                ActiveStyle("DD");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
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
                    ue.setContent(xml.Value.QZZP_JZZPJBXX.BCMS);
                });
                $("#spanJZLB").html(xml.Value.QZZP_JZZPJBXX.JZLB);
                $("#spanXZSPDW").html(xml.Value.QZZP_JZZPJBXX.XZSPDW);
                $("#spanXZJS").html(xml.Value.QZZP_JZZPJBXX.XZJS);
                $("#spanJZYXQ").html(xml.Value.QZZP_JZZPJBXX.JZYXQ);
                $("#spanGZCS").html(xml.Value.QZZP_JZZPJBXX.GZCS);
                $("#spanQY").html(xml.Value.QZZP_JZZPJBXX.QY);
                $("#spanDD").html(xml.Value.QZZP_JZZPJBXX.DD);
                SetJZYXQ(xml.Value.QZZP_JZZPJBXX.JZYXQ);
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
    if (AllValidate() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "JZLB", "'" + $("#spanJZLB").html() + "'");
    obj = jsonObj.AddJson(obj, "XZSPDW", "'" + $("#spanXZSPDW").html() + "'");
    obj = jsonObj.AddJson(obj, "XZJS", "'" + $("#spanXZJS").html() + "'");
    obj = jsonObj.AddJson(obj, "GZCS", "'" + $("#spanGZCS").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "JZYXQ", "'" + GetJZYXQ() + "'");
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