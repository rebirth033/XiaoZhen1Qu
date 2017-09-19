var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 900) / 2);
    $(".div_head").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $(".div_content").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $("#spanCXLB").bind("click", CXLB);
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
    $("#span_content_info_qGCCs").bind("click", LoadXZQByGrade);
    $("body").bind("click", CloseXZQ);
    $("body").bind("click", function () { Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYGCCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYGCCD);
    LoadTXXX();
    LoadDefault();
    LoadCL_GCCJBXX();
    BindClick("CX");
    BindClick("CCNX");
    BindClick("CCYF");
    BindClick("QY");
    BindClick("DD");
    LoadPPMC("挖掘机品牌", "divRM");
});
//加载工程车车型标签
function LoadGCC() {
    var arrayObj = new Array('RM', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    var html = "";
    for (var i = 0; i < arrayObj.length; i++) {
        if (i === 0)
            html += '<div class="divstep_yx" id="div' + arrayObj[i] + '" style="width:62px;"><span class="spanstep_yx" id="span' + arrayObj[i] + '">' + "热门" + '</span><em class="emstep_yx" id="em' + arrayObj[i] + '"></em></div>';
        else
            html += '<div class="divstep_yx" id="div' + arrayObj[i] + '"><span class="spanstep_yx" id="span' + arrayObj[i] + '">' + arrayObj[i] + '</span><em class="emstep_yx" id="em' + arrayObj[i] + '"></em></div>';
    }
    $("#div_content_gccbq").html(html);
    $(".divstep_yx").bind("click", GCCBQActive);
}
//工程车车型标签切换
function GCCBQActive() {
    LoadGCCMC(this.id);
}
//加载工程车车型名称
function LoadGCCMC(GCC) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadGCCJBXX",
        dataType: "json",
        data:
        {
            GCC: GCC.split("div")[1]
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_yxmc" onclick="GCCXZ(\'' + xml.list[i].CODENAME + '\',\'' + xml.list[i].CODEID + '\')">' + xml.list[i].CODENAME + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_yxmc" style=\"width:200px;text-align:left;margin-left:14px;\">该字母下暂无游戏</span>';
                $("#div_content_gccmc").html(html);
                $("#divCX").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择工程车车型名称
function GCCXZ(CXMC, CXID) {
    $("#spanCX").html(CXMC);
    $("#divCX").css("display", "none");
    PDCX(CXMC);
}
//判断类别
function PDCX(CXMC) {
    if (CXMC === "挖掘机") {
        $("#divGCCPP").css("display", "");
        BindClick("PP");
    }

}
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
    $(".divstep_yx").bind("click", YXBQActive);
}
//品牌标签切换
function YXBQActive() {
    LoadPPMC("挖掘机品牌", this.id);
}
//加载品牌名称
function LoadPPMC(GCCLX, GCCBQ) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadGCCPPXX",
        dataType: "json",
        data:
        {
            GCCLX: GCCLX,
            GCCBQ: GCCBQ.split("div")[1]
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
    $("#spanPP").html(PPMC);
    $("#divPP").css("display", "none");
}
//显示用户菜单
function ShowYGCCD() {
    $("#div_top_right_dropdown_yhm").css("display", "block");
    $("#span_top_right_yhm_img").css("background-image", 'url(' + getRootPath() + "/Areas/Business/Css/images/arrow_up.png" + ')');
}
//隐藏用户菜单
function HideYGCCD() {
    $("#div_top_right_dropdown_yhm").css("display", "none");
    $("#span_top_right_yhm_img").css("background-image", 'url(' + getRootPath() + "/Areas/Business/Css/images/arrow_down.png" + ')');
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
//加载图形信息
function LoadTXXX() {
    $("#spanTXXX").css("color", "#5bc0de");
    $("#emTXXX").css("background", "#5bc0de");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LBXZ/LoadLBByID",
        dataType: "json",
        data:
        {
            LBID: getUrlParam("CLICKID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                if (xml.list.length > 0)
                    $("#spanLBXZ").html("1." + xml.list[0].LBNAME);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//重选类别
function CXLB() {
    window.location.href = getRootPath() + "/Business/LBXZ/LBXZ";
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
//加载工程车车型
function LoadGCCLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_CL",
        dataType: "json",
        data:
        {
            TYPENAME: "工程车"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectCX(this,\"CX\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divCX").html(html);
                $("#divCX").css("display", "none");
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
        if (type === "CX") {
            LoadGCC();
            LoadGCCMC("divRM");
        }
        if (type === "PP") {
            LoadPP();
            LoadPPMC("挖掘机品牌", "divRM");
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
//选择工程车品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载车辆_工程车基本信息
function LoadCL_GCCJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL_GCC/LoadCL_GCCJBXX",
        dataType: "json",
        data:
        {
            CL_GCCJBXXID: getUrlParam("CL_GCCJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_GCCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#CL_GCCJBXXID").val(xml.Value.CL_GCCJBXX.CL_GCCJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.CL_GCCJBXX.BCMS);
                });
                $("#spanQY").html(xml.Value.CL_GCCJBXX.JYQY);
                $("#spanSQ").html(xml.Value.CL_GCCJBXX.JYDD);
                $("#spanXL").html(xml.Value.CL_GCCJBXX.XL);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanPP").html() + "'");
    obj = jsonObj.AddJson(obj, "CCNX", "'" + $("#spanCCNX").html() + "'");
    obj = jsonObj.AddJson(obj, "CCYF", "'" + $("#spanCCYF").html() + "'");
    obj = jsonObj.AddJson(obj, "JYQY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "JYDD", "'" + $("#spanSQ").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("CL_GCCJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "CL_GCCJBXXID", "'" + getUrlParam("CL_GCCJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL_GCC/FB",
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
//关闭
function Close(id) {
    $("#div" + id).css("display", "none");
    LeaveStyle(id);
}