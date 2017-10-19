var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#div_upload").bind("mouseover", GetUploadCss);
    $("#div_upload").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qCWFWs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });



    LoadDefault();
    BindClick("LB");
    BindClick("TCPP");
    BindClick("GCPP");
    BindClick("QY");
    BindClick("DD");
    LoadTCYS();
    LoadGCYS();
    LoadDuoX("婚车租赁", "TGFW");
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
//加载头车颜色
function LoadTCYS() {
    var colors = new Array("black:黑", "red:红", "white:白", "rgb(230, 230, 230):银", "rgb(214, 214, 214):灰", "rgb(51, 153, 255):蓝", "rgb(255, 255, 0):黄", "rgb(153, 102, 0):棕");
    for (var i = 0; i < colors.length; i++) {
        var obj = colors[i].split(':');
        $("#div_tcys_right").append('<div class="div_tcys"><span class="span_tcys_left" style="background-color: ' + obj[0] + '"></span><span class="span_tcys_right">' + obj[1] + '</span></div>');
    }
    colors = new Array("rgb(13, 207, 110):绿", "rgb(255, 102, 0):橙", "rgb(204, 51, 153):紫", "rgb(243, 238, 170):香槟", "rgb(255, 204, 0):金", "rgb(255, 192, 203):粉红", "其他");
    for (var i = 0; i < colors.length; i++) {
        var obj = colors[i].split(':');
        if (i === colors.length - 1)
            $("#div_tcys_right2").append('<div class="div_tcys"><span class="span_tcys_left" style="border:none;"></span><span class="span_tcys_right">' + obj[0] + '</span></div>');
        else
            $("#div_tcys_right2").append('<div class="div_tcys"><span class="span_tcys_left" style="background-color: ' + obj[0] + '"></span><span class="span_tcys_right">' + obj[1] + '</span></div>');
    }
    $(".div_tcys").bind("click", ActiveTCYS);
}
//加载跟车颜色
function LoadGCYS() {
    var colors = new Array("black:黑", "red:红", "white:白", "rgb(230, 230, 230):银", "rgb(214, 214, 214):灰", "rgb(51, 153, 255):蓝", "rgb(255, 255, 0):黄", "rgb(153, 102, 0):棕");
    for (var i = 0; i < colors.length; i++) {
        var obj = colors[i].split(':');
        $("#div_gcys_right").append('<div class="div_gcys"><span class="span_gcys_left" style="background-color: ' + obj[0] + '"></span><span class="span_gcys_right">' + obj[1] + '</span></div>');
    }
    colors = new Array("rgb(13, 207, 110):绿", "rgb(255, 102, 0):橙", "rgb(204, 51, 153):紫", "rgb(243, 238, 170):香槟", "rgb(255, 204, 0):金", "rgb(255, 192, 203):粉红", "其他");
    for (var i = 0; i < colors.length; i++) {
        var obj = colors[i].split(':');
        if (i === colors.length - 1)
            $("#div_gcys_right2").append('<div class="div_gcys"><span class="span_gcys_left" style="border:none;"></span><span class="span_gcys_right">' + obj[0] + '</span></div>');
        else
            $("#div_gcys_right2").append('<div class="div_gcys"><span class="span_gcys_left" style="background-color: ' + obj[0] + '"></span><span class="span_gcys_right">' + obj[1] + '</span></div>');
    }
    $(".div_gcys").bind("click", ActiveGCYS);
}
//选择头车颜色
function ActiveTCYS() {
    $(".div_tcys").each(function () {
        $(this).css("background-color", "#ffffff;");
    });
    $(this).css("background-color", "#87B53B");
}
//选择跟车颜色
function ActiveGCYS() {
    $(".div_gcys").each(function () {
        $(this).css("background-color", "#ffffff;");
    });
    $(this).css("background-color", "#87B53B");
}
//加载头车品牌标签
function LoadTCPP(type) {
    var arrayObj = new Array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    var html = "";
    for (var i = 0; i < arrayObj.length; i++) {
        html += '<div class="divstep_yx" id="div' + arrayObj[i] + '"><span class="spanstep_yx" id="span' + arrayObj[i] + '">' + arrayObj[i] + '</span><em class="emstep_yx" id="em' + arrayObj[i] + '"></em></div>';
    }
    $("#div_content_" + type + "bq").html(html);
    $(".divstep_yx").bind("click", TCBQActive);
}
//头车品牌标签切换
function TCBQActive() {
    LoadTCPPMC("婚车品牌", this.id);
}
//加载头车品牌名称
function LoadTCPPMC(JCLX, JCBQ) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByCodeValueAndTypeName",
        dataType: "json",
        data:
        {
            CODEVALUE: JCBQ.split("div")[1],
            TYPENAME: "婚车品牌",
            TBName: "CODES_HQSY"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_yxmc" onclick="TCPPXZ(\'' + xml.list[i].CODENAME + '\',\'' + xml.list[i].CODEID + '\')">' + xml.list[i].CODENAME + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_yxmc" style=\"width:200px;text-align:left;margin-left:14px;\">该字母下暂无数据</span>';
                $("#div_content_tcmc").html(html);
                $("#divTCPP").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择头车品牌名称
function TCPPXZ(TCPPMC, TCPPID) {
    $("#spanTCPP").html(TCPPMC);
    $("#divTCPP").css("display", "none");
}
//加载跟车品牌标签
function LoadGCPP(type) {
    var arrayObj = new Array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    var html = "";
    for (var i = 0; i < arrayObj.length; i++) {
        html += '<div class="divstep_yx" id="div' + arrayObj[i] + '"><span class="spanstep_yx" id="span' + arrayObj[i] + '">' + arrayObj[i] + '</span><em class="emstep_yx" id="em' + arrayObj[i] + '"></em></div>';
    }
    $("#div_content_" + type + "bq").html(html);
    $(".divstep_yx").bind("click", GCBQActive);
}
//跟车品牌标签切换
function GCBQActive() {
    LoadGCPPMC("婚车品牌", this.id);
}
//加载跟车品牌名称
function LoadGCPPMC(JCLX, JCBQ) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByCodeValueAndTypeName",
        dataType: "json",
        data:
        {
            CODEVALUE: JCBQ.split("div")[1],
            TYPENAME: "婚车品牌",
            TBName: "CODES_HQSY"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_yxmc" onclick="GCPPXZ(\'' + xml.list[i].CODENAME + '\',\'' + xml.list[i].CODEID + '\')">' + xml.list[i].CODENAME + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_yxmc" style=\"width:200px;text-align:left;margin-left:14px;\">该字母下暂无数据</span>';
                $("#div_content_gcmc").html(html);
                $("#divGCPP").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择跟车品牌名称
function GCPPXZ(GCPPMC, GCPPID) {
    $("#spanGCPP").html(GCPPMC);
    $("#divGCPP").css("display", "none");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("婚车租赁", "LB", "CODES_HQSY");
        }
        if (type === "TCPP") {
            LoadTCPP("tc");
            LoadTCPPMC("婚车品牌", "divA");
        }
        if (type === "GCPP") {
            LoadGCPP("gc");
            LoadGCPPMC("婚车品牌", "divA");
        }
        if (type === "XL") {
            LoadXL();
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//选择类别下拉框
function SelectLB(obj, type, lbid) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#LBID").val(lbid);
}
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: type,
            TBName: "CODES_HQSY"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 3 || i === 7 || i === 11) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 4) * 45 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 4) + 1) * 45 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadHQSY_HCZLJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//获取头车颜色
function GetTCYS(type) {
    var ys = "";
    $("#div" + type).find(".div_tcys").each(function () {
        if ($(this).css("background-color") === "rgb(135, 181, 59)") {
            ys = $(this).find(".span_tcys_right")[0].innerHTML;
        }
    });
    return ys;
}
//获取跟车颜色
function GetGCYS(type) {
    var ys = "";
    $("#div" + type).find(".div_gcys").each(function () {
        if ($(this).css("background-color") === "rgb(135, 181, 59)") {
            ys = $(this).find(".span_gcys_right")[0].innerHTML;
        }
    });
    return ys;
}
//设置头车颜色
function SetTCYS(type, ys) {
    $("#div" + type).find(".div_tcys").each(function () {
        if ($(this).find(".span_tcys_right")[0].innerHTML === ys) {
            $(this).css("background-color", "#87B53B");
        }
    });
}
//设置跟车颜色
function SetGCYS(type, ys) {
    $("#div" + type).find(".div_gcys").each(function () {
        if ($(this).find(".span_gcys_right")[0].innerHTML === ys) {
            $(this).css("background-color", "#87B53B");
        }
    });
}
//加载婚庆摄影_婚车租赁基本信息
function LoadHQSY_HCZLJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY_HCZL/LoadHQSY_HCZLJBXX",
        dataType: "json",
        data:
        {
            HQSY_HCZLJBXXID: getUrlParam("HQSY_HCZLJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.HQSY_HCZLJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#HQSY_HCZLJBXXID").val(xml.Value.HQSY_HCZLJBXX.HQSY_HCZLJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.HQSY_HCZLJBXX.BCMS);
                });
                $("#spanTCPP").html(xml.Value.HQSY_HCZLJBXX.TCPP);
                $("#spanGCPP").html(xml.Value.HQSY_HCZLJBXX.GCPP);
                $("#spanQY").html(xml.Value.HQSY_HCZLJBXX.QY);
                $("#spanDD").html(xml.Value.HQSY_HCZLJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.HQSY_HCZLJBXX.TCCZ !== null)
                    SetDX("TCCZ", xml.Value.HQSY_HCZLJBXX.TCCZ);
                if (xml.Value.HQSY_HCZLJBXX.MFTGCH !== null)
                    SetDX("MFTGCH", xml.Value.HQSY_HCZLJBXX.MFTGCH);
                if (xml.Value.HQSY_HCZLJBXX.TCYS !== null)
                    SetTCYS("TCYS", xml.Value.HQSY_HCZLJBXX.TCYS);
                if (xml.Value.HQSY_HCZLJBXX.GCYS !== null)
                    SetGCYS("GCYS", xml.Value.HQSY_HCZLJBXX.GCYS);
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
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "TCPP", "'" + $("#spanTCPP").html() + "'");
    obj = jsonObj.AddJson(obj, "GCPP", "'" + $("#spanGCPP").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "TCCZ", "'" + GetDX("TCCZ") + "'");
    obj = jsonObj.AddJson(obj, "MFTGCH", "'" + GetDX("MFTGCH") + "'");
    obj = jsonObj.AddJson(obj, "TCYS", "'" + GetTCYS("TCYS") + "'");
    obj = jsonObj.AddJson(obj, "GCYS", "'" + GetGCYS("GCYS") + "'");

    if (getUrlParam("HQSY_HCZLJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "HQSY_HCZLJBXXID", "'" + getUrlParam("HQSY_HCZLJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY_HCZL/FB",
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