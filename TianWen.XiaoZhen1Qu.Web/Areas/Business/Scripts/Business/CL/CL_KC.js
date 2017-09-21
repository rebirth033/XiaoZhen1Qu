var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#imgCLMM").bind("click", CLMMSelect);
    $("#imgPJ").bind("click", PJSelect);
    $("#imgWXBY").bind("click", WXBYSelect);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qKCs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);
    LoadTXXX();
    LoadDefault();
    LoadCL_KCJBXX();
    BindClick("PP");
    BindClick("CCNX");
    BindClick("CCYF");
    BindClick("QY");
    BindClick("DD");
});
//加载品牌标签
function LoadPP() {
    var arrayObj = new Array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    var html = "";
    for (var i = 0; i < arrayObj.length; i++) {
        html += '<div class="divstep_yx" id="div' + arrayObj[i] + '"><span class="spanstep_yx" id="span' + arrayObj[i] + '">' + arrayObj[i] + '</span><em class="emstep_yx" id="em' + arrayObj[i] + '"></em></div>';
    }
    $("#div_content_yxbq").html(html);
    $(".divstep_yx").bind("click", KCBQActive);
}
//品牌标签切换
function KCBQActive() {
    LoadPPMC("客车品牌", this.id);
}
//加载品牌名称
function LoadPPMC(KCLX, KCBQ) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadKCPPXX",
        dataType: "json",
        data:
        {
            KCLX: KCLX,
            KCBQ: KCBQ.split("div")[1]
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_yxmc" onclick="PPXZ(\'' + xml.list[i].CODENAME + '\',\'' + xml.list[i].CODEID + '\')">' + xml.list[i].CODENAME + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_yxmc" style=\"width:200px;text-align:left;margin-left:14px;\">该字母下暂无游戏</span>';
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
    $("#imgCLMM").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgPJ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgWXBY").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择车辆买卖
function CLMMSelect() {
    $("#imgCLMM").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgPJ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgWXBY").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择配件
function PJSelect() {
    $("#imgCLMM").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgPJ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgWXBY").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择维修保养
function WXBYSelect() {
    $("#imgCLMM").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgPJ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgWXBY").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}
//加载客车车系
function LoadKCCX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadKCCXXX",
        dataType: "json",
        data:
        {
            PPID: $("#PPID").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"CX\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
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
//加载出厂年限
function LoadCCNX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_CL",
        dataType: "json",
        data:
        {
            TYPENAME: "出厂年限"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"CCNX\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divCCNX").html(html);
                $("#divCCNX").css("display", "block");
                ActiveStyle("CCNX");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载出厂月份
function LoadCCYF() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_CL",
        dataType: "json",
        data:
        {
            TYPENAME: "出厂月份"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"CCYF\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divCCYF").html(html);
                $("#divCCYF").css("display", "block");
                ActiveStyle("CCYF");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
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
        if (type === "CCNX") {
            LoadCCNX();
        }
        if (type === "CCYF") {
            LoadCCYF();
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
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
                    ue.setContent(xml.Value.CL_KCJBXX.BCMS);
                });
                $("#spanQY").html(xml.Value.CL_KCJBXX.JYQY);
                $("#spanDD").html(xml.Value.CL_KCJBXX.JYDD);
                $("#spanXL").html(xml.Value.CL_KCJBXX.XL);
                $("#spanCX").html(xml.Value.CL_KCJBXX.LB);
                $("#spanCCNX").html(xml.Value.CL_KCJBXX.CCNX);
                $("#spanCCYF").html(xml.Value.CL_KCJBXX.CCYF);
                LoadPhotos(xml.Value.Photos);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanCX").html() + "'");
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanPP").html() + "'");
    obj = jsonObj.AddJson(obj, "CCNX", "'" + $("#spanCCNX").html() + "'");
    obj = jsonObj.AddJson(obj, "CCYF", "'" + $("#spanCCYF").html() + "'");
    obj = jsonObj.AddJson(obj, "JYQY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "JYDD", "'" + $("#spanDD").html() + "'");
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