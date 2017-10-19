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
    $("#span_content_info_qKCs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });



    LoadDefault();
    LoadCL_JCJBXX();
    LoadCYLS();
    BindClick("PP");
    BindClick("GHCS");
    BindClick("SPNF");
    BindClick("SPYF");
    BindClick("NJDQNF");
    BindClick("NJDQYF");
    BindClick("JQXDQNF");
    BindClick("JQXDQYF");
    BindClick("SYXDQNF");
    BindClick("SYXDQYF");
    BindClick("PZSZSF");
});
//加载品牌标签
function LoadPP() {
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
//品牌标签切换
function JCBQActive() {
    LoadPPMC("轿车品牌", this.id);
}
//加载品牌名称
function LoadPPMC(JCLX, JCBQ) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByCodeValueAndTypeName",
        dataType: "json",
        data:
        {
            CODEVALUE: JCBQ.split("div")[1],
            TYPENAME: "轿车品牌",
            TBName: "CODES_CL_JC"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_yxmc" onclick="PPXZ(\'' + xml.list[i].CODENAME + '\',\'' + xml.list[i].CODEID + '\')">' + xml.list[i].CODENAME + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_yxmc" style=\"width:200px;text-align:left;margin-left:14px;\">该字母下暂无数据</span>';
                $("#div_content_yxmc").html(html);
                $("#divPP").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择品牌名称
function PPXZ(PPMC, PPID) {
    $("#PPID").val(PPID);
    $("#spanPP").html(PPMC);
    $("#divPP").css("display", "none");
    $("#divCXText").css("display", "");
    BindClick("CX");
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
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "PP") {
            LoadPP();
            LoadPPMC("轿车品牌", "divRM");
        }
        if (type.indexOf("NF") !== -1) {
            LoadCODESByTYPENAME("出厂年限", type, "CODES_CL");
        }
        if (type.indexOf("YF") !== -1) {
            LoadCODESByTYPENAME("出厂月份", type, "CODES_CL");
        }
        if (type.indexOf("GHCS") !== -1) {
            LoadCODESByTYPENAME("过户次数", type, "CODES_CL");
        }
        if (type.indexOf("PZSZSF") !== -1) {
            LoadPZSZSF(type);
        }
        if (type.indexOf("PZSZCS") !== -1) {
            LoadPZSZCS(type);
        }
    });
}
//加载牌照所在省份
function LoadPZSZSF() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/GetDistrictByGrade",
        dataType: "json",
        data:
        {
            Grade: "省级"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ul_select' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectPZSZSF(this,\"PZSZSF\",\"" + xml.list[i].CODE + "\")'>" + RTrim(RTrim(xml.list[i].NAME, '市'), '省') + "</li>";
                }
                html += "</ul>";
                $("#divPZSZSF").html(html);
                $("#divPZSZSF").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载牌照所在城市
function LoadPZSZCS() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/GetDistrictBySuperCode",
        dataType: "json",
        data:
        {
            SuperCode: $("#SPSF").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ul_select' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectDropdown(this,\"PZSZCS\",\"" + xml.list[i].CODE + "\")'>" + xml.list[i].NAME + "</li>";
                }
                html += "</ul>";
                $("#divPZSZCS").html(html);
                $("#divPZSZCS").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载车辆颜色
function LoadCYLS() {
    var colors = new Array("black:黑", "red:红", "white:白", "rgb(230, 230, 230):银", "rgb(214, 214, 214):灰", "rgb(51, 153, 255):蓝", "rgb(255, 255, 0):黄", "rgb(153, 102, 0):棕");
    for (var i = 0; i < colors.length; i++) {
        var obj = colors[i].split(':');
        $("#div_clys_right").append('<div class="div_clys"><span class="span_clys_left" style="background-color: ' + obj[0] + '"></span><span class="span_clys_right">' + obj[1] + '</span></div>');
    }
    colors = new Array("rgb(13, 207, 110):绿", "rgb(255, 102, 0):橙", "rgb(204, 51, 153):紫", "rgb(243, 238, 170):香槟", "rgb(255, 204, 0):金", "rgb(255, 192, 203):粉红", "其他");
    for (var i = 0; i < colors.length; i++) {
        var obj = colors[i].split(':');
        if (i === colors.length - 1)
            $("#div_clys_right2").append('<div class="div_clys"><span class="span_clys_left" style="border:none;"></span><span class="span_clys_right">' + obj[0] + '</span></div>');
        else
            $("#div_clys_right2").append('<div class="div_clys"><span class="span_clys_left" style="background-color: ' + obj[0] + '"></span><span class="span_clys_right">' + obj[1] + '</span></div>');
    }
    $(".div_clys").bind("click", ActiveCLYS);
}
//选择车辆颜色
function ActiveCLYS() {
    $(".div_clys").each(function () {
        $(this).css("background-color", "#ffffff;");
    });
    $(this).css("background-color", "#87B53B");
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
}
//选择上牌省份
function SelectPZSZSF(obj, type, code) {
    $("#SPSF").val(code);
    $("#spanPZSZSF").html(obj.innerHTML);
    $("#divPZSZSF").css("display", "none");
    BindClick("PZSZCS");
}
//加载车辆_轿车基本信息
function LoadCL_JCJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL_JC/LoadCL_JCJBXX",
        dataType: "json",
        data:
        {
            CL_JCJBXXID: getUrlParam("CL_JCJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_JCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#CL_JCJBXXID").val(xml.Value.CL_JCJBXX.CL_JCJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.CL_JCJBXX.BCMS);
                });
                $("#spanPP").html(xml.Value.CL_JCJBXX.PP);
                $("#spanCX").html(xml.Value.CL_JCJBXX.CX);
                $("#spanSPNF").html(xml.Value.CL_JCJBXX.SPNF);
                $("#spanSPYF").html(xml.Value.CL_JCJBXX.SPYF);
                $("#spanNJDQNF").html(xml.Value.CL_JCJBXX.NJDQNF);
                $("#spanNJDQYF").html(xml.Value.CL_JCJBXX.NJDQYF);
                $("#spanJQXDQNF").html(xml.Value.CL_JCJBXX.JQXDQNF);
                $("#spanJQXDQYF").html(xml.Value.CL_JCJBXX.JQXDQYF);
                $("#spanSYXDQNF").html(xml.Value.CL_JCJBXX.SYXDQNF);
                $("#spanSYXDQYF").html(xml.Value.CL_JCJBXX.SYXDQYF);
                $("#spanPZSZSF").html(xml.Value.CL_JCJBXX.PZSZSF);
                $("#spanPZSZCS").html(xml.Value.CL_JCJBXX.PZSZCS);
                $("#spanGHCS").html(xml.Value.CL_JCJBXX.GHCS);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.CL_JCJBXX.SFDQBY !== null)
                    SetDX("SFDQBY", xml.Value.CL_JCJBXX.SFDQBY);
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
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanPP").html() + "'");
    obj = jsonObj.AddJson(obj, "CX", "'" + $("#spanCX").html() + "'");
    obj = jsonObj.AddJson(obj, "SPNF", "'" + $("#spanSPNF").html() + "'");
    obj = jsonObj.AddJson(obj, "SPYF", "'" + $("#spanSPYF").html() + "'");
    obj = jsonObj.AddJson(obj, "NJDQNF", "'" + $("#spanNJDQNF").html() + "'");
    obj = jsonObj.AddJson(obj, "NJDQYF", "'" + $("#spanNJDQYF").html() + "'");
    obj = jsonObj.AddJson(obj, "JQXDQNF", "'" + $("#spanJQXDQNF").html() + "'");
    obj = jsonObj.AddJson(obj, "JQXDQYF", "'" + $("#spanJQXDQYF").html() + "'");
    obj = jsonObj.AddJson(obj, "SYXDQNF", "'" + $("#spanSYXDQNF").html() + "'");
    obj = jsonObj.AddJson(obj, "SYXDQYF", "'" + $("#spanSYXDQYF").html() + "'");
    obj = jsonObj.AddJson(obj, "PZSZSF", "'" + $("#spanPZSZSF").html() + "'");
    obj = jsonObj.AddJson(obj, "PZSZCS", "'" + $("#spanPZSZCS").html() + "'");
    obj = jsonObj.AddJson(obj, "GHCS", "'" + $("#spanGHCS").html() + "'");
    obj = jsonObj.AddJson(obj, "SFDQBY", "'" + GetDX("SFDQBY") + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("CL_JCJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "CL_JCJBXXID", "'" + getUrlParam("CL_JCJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL_JC/FB",
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