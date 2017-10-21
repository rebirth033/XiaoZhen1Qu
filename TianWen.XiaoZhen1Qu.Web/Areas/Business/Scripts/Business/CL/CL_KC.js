
$(document).ready(function () {$("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });LoadCL_KCJBXX();
    LoadCYLS();
    BindClick("PP");
    BindClick("SPNF");
    BindClick("SPYF");
    BindClick("NJDQNF");
    BindClick("NJDQYF");
    BindClick("JQXDQNF");
    BindClick("JQXDQYF");
    BindClick("SYXDQNF");
    BindClick("SYXDQYF");
});
//加载品牌标签
function LoadPP() {
    var arrayObj = new Array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    var html = "";
    for (var i = 0; i < arrayObj.length; i++) {
        html += '<div class="div_bqss_content_bq" id="div' + arrayObj[i] + '"><span class="span_bqss_content_bq" id="span' + arrayObj[i] + '">' + arrayObj[i] + '</span><em class="em_bqss_content_bq" id="em' + arrayObj[i] + '"></em></div>';
    }
    $("#div_bqss_body_bq").html(html);
    $(".div_bqss_content_bq").bind("click", KCBQActive);
}
//品牌标签切换
function KCBQActive() {
    LoadPPMC("客车品牌", this.id);
}
//加载品牌名称
function LoadPPMC(KCLX, KCBQ) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByCodeValueAndTypeName",
        dataType: "json",
        data:
        {
            CODEVALUE: KCBQ.split("div")[1],
            TYPENAME: "客车品牌",
            TBName: "CODES_CL"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_mc" onclick="PPXZ(\'' + xml.list[i].CODENAME + '\',\'' + xml.list[i].CODEID + '\')">' + xml.list[i].CODENAME + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_mc" style=\"width:200px;text-align:left;margin-left:14px;\">该字母下暂无数据</span>';
                $("#div_bqss_body_mc").html(html);
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

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "PP") {
            LoadPP();
            LoadPPMC("客车品牌", "divA");
        }
        if (type === "CX") {
            LoadKCCX();
        }
        if (type.indexOf("NF") !== -1) {
            LoadCODESByTYPENAME("出厂年限", type, "CODES_CL");
        }
        if (type.indexOf("YF") !== -1) {
            LoadCODESByTYPENAME("出厂月份", type, "CODES_CL");
        }
    });
}
//加载客车车系
function LoadKCCX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: $("#PPID").val(),
            TBName: "CODES_CL"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ul_select' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectDropdown(this,\"CX\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divCX").html(html);
                $("#divCX").css("display", "block");
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
//选择下拉框
function SelectDropdown(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
}
//选择车辆颜色
function ActiveCLYS() {
    $(".div_clys").each(function () {
        $(this).css("background-color", "#ffffff;");
    });
    $(this).css("background-color", "#87B53B");
}
//加载车辆_客车基本信息
function LoadCL_KCJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL_KC/LoadCL_KCJBXX",
        dataType: "json",
        data:
        {
            CL_KCJBXXID: getUrlParam("CL_KCJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_KCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#CL_KCJBXXID").val(xml.Value.CL_KCJBXX.CL_KCJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanPP").html(xml.Value.CL_KCJBXX.PP);
                $("#spanCX").html(xml.Value.CL_KCJBXX.CX);
                $("#spanSPNF").html(xml.Value.CL_KCJBXX.SPNF);
                $("#spanSPYF").html(xml.Value.CL_KCJBXX.SPYF);
                $("#spanNJDQNF").html(xml.Value.CL_KCJBXX.NJDQNF);
                $("#spanNJDQYF").html(xml.Value.CL_KCJBXX.NJDQYF);
                $("#spanJQXDQNF").html(xml.Value.CL_KCJBXX.JQXDQNF);
                $("#spanJQXDQYF").html(xml.Value.CL_KCJBXX.JQXDQYF);
                $("#spanSYXDQNF").html(xml.Value.CL_KCJBXX.SYXDQNF);
                $("#spanSYXDQYF").html(xml.Value.CL_KCJBXX.SYXDQYF);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.CL_KCJBXX.SFDQBY !== null)
                    SetDX("SFDQBY", xml.Value.CL_KCJBXX.SFDQBY);
                if (xml.Value.CL_KCJBXX.YWZDSG !== null)
                    SetDX("YWZDSG", xml.Value.CL_KCJBXX.YWZDSG);
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
    obj = jsonObj.AddJson(obj, "SFDQBY", "'" + GetDX("SFDQBY") + "'");
    obj = jsonObj.AddJson(obj, "YWZDSG", "'" + GetDX("YWZDSG") + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("CL_KCJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "CL_KCJBXXID", "'" + getUrlParam("CL_KCJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL_KC/FB",
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