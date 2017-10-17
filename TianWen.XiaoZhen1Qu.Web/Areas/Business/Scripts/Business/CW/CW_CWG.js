var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#imgGRZR").bind("click", GRZRSelect);
    $("#imgSJZR").bind("click", SJZRSelect);
    $("#imgYQC").bind("click", YQCSelect);
    $("#imgWQC").bind("click", WQCSelect);
    $("#imgZC").bind("click", ZCSelect);
    $("#imgBZC").bind("click", BZCSelect);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qCWGs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);
    LoadTXXX();
    LoadDefault();
    LoadCW_CWGJBXX();
    BindClick("PZ");
    BindClick("NLDW");
    BindClick("XB");
    BindClick("YMQK");
    BindClick("YMZL");
});
//加载宠物狗品种标签
function LoadCWG() {
    var arrayObj = new Array('RM', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    var html = "";
    for (var i = 0; i < arrayObj.length; i++) {
        if (i === 0)
            html += '<div class="divstep_yx" id="div' + arrayObj[i] + '" style="width:62px;"><span class="spanstep_yx" id="span' + arrayObj[i] + '">' + "热门" + '</span><em class="emstep_yx" id="em' + arrayObj[i] + '"></em></div>';
        else
            html += '<div class="divstep_yx" id="div' + arrayObj[i] + '"><span class="spanstep_yx" id="span' + arrayObj[i] + '">' + arrayObj[i] + '</span><em class="emstep_yx" id="em' + arrayObj[i] + '"></em></div>';
    }
    $("#div_content_cwgbq").html(html);
    $(".divstep_yx").bind("click", CWGBQActive);
}
//宠物狗品种标签切换
function CWGBQActive() {
    LoadCWGPZ(this.id);
}
//加载宠物狗品种名称
function LoadCWGPZ(CWG) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByCodeValueAndTypeName",
        dataType: "json",
        data:
        {
            CODEVALUE: CWG.split("div")[1],
            TYPENAME: "宠物狗",
            TBName: "CODES_CW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_yxmc" onclick="CWGXZ(\'' + xml.list[i].CODENAME + '\',\'' + xml.list[i].CODEID + '\')">' + xml.list[i].CODENAME + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_yxmc" style=\"width:200px;text-align:left;margin-left:14px;\">该字母下暂无数据</span>';
                $("#div_content_cwgmc").html(html);
                $("#divPZ").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择宠物狗品种名称
function CWGXZ(CXMC, CXID) {
    $("#spanPZ").html(CXMC);
    $("#divPZ").css("display", "none");
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
    $("#imgGRZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgYQC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgWQC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgZC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgBZC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择个人转让
function GRZRSelect() {
    $("#imgGRZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择商家转让
function SJZRSelect() {
    $("#imgGRZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}
//选择已驱虫
function YQCSelect() {
    $("#imgYQC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgWQC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择未驱虫
function WQCSelect() {
    $("#imgYQC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgWQC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}
//选择支持
function ZCSelect() {
    $("#imgZC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgBZC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择不支持
function BZCSelect() {
    $("#imgZC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgBZC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}
//获取身份
function GetSF() {
    if ($("#imgGRZR").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置身份
function SetSF(SFDQBY) {
    if (SFDQBY === 0) {
        $("#imgGRZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgGRZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//获取驱虫情况
function GetQCQK() {
    if ($("#imgYQC").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置驱虫情况
function SetQCQK(QCQK) {
    if (QCQK === 0) {
        $("#imgYQC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgWQC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgYQC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgWQC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//获取视频看狗
function GetSPKG() {
    if ($("#imgZC").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置视频看狗
function SetSPKG(SPKG) {
    if (SPKG === 0) {
        $("#imgZC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgBZC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgZC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgBZC").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//加载年龄单位
function LoadNLDW() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_CW",
        dataType: "json",
        data:
        {
            TYPENAME: "年龄单位"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"NLDW\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divNLDW").html(html);
                $("#divNLDW").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载性别
function LoadXB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_CW",
        dataType: "json",
        data:
        {
            TYPENAME: "性别"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll; height:103px'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"XB\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divXB").html(html);
                $("#divXB").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载疫苗情况
function LoadYMQK() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_CW",
        dataType: "json",
        data:
        {
            TYPENAME: "疫苗情况"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll; height:137px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"YMQK\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divYMQK").html(html);
                $("#divYMQK").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载疫苗种类
function LoadYMZL() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_CW",
        dataType: "json",
        data:
        {
            TYPENAME: "疫苗种类"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"YMZL\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divYMZL").html(html);
                $("#divYMZL").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "PZ") {
            LoadCWG();
            LoadCWGPZ("divRM");
        }
        if (type === "NLDW") {
            LoadNLDW();
        }
        if (type === "XB") {
            LoadXB();
        }
        if (type === "YMQK") {
            LoadYMQK();
        }
        if (type === "YMZL") {
            LoadYMZL();
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
//选择宠物狗品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载车辆_宠物狗基本信息
function LoadCW_CWGJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CW_CWG/LoadCW_CWGJBXX",
        dataType: "json",
        data:
        {
            CW_CWGJBXXID: getUrlParam("CW_CWGJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CW_CWGJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#CW_CWGJBXXID").val(xml.Value.CW_CWGJBXX.CW_CWGJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.CW_CWGJBXX.BCMS);
                });
                $("#spanPZ").html(xml.Value.CW_CWGJBXX.PZ);
                $("#spanNLDW").html(xml.Value.CW_CWGJBXX.NLDW);
                $("#spanXB").html(xml.Value.CW_CWGJBXX.XB);
                $("#spanYMQK").html(xml.Value.CW_CWGJBXX.YMQK);
                $("#spanYMZL").html(xml.Value.CW_CWGJBXX.YMZL);
                SetSF(xml.Value.CW_CWGJBXX.SF);
                SetQCQK(xml.Value.CW_CWGJBXX.QCQK);
                SetSPKG(xml.Value.CW_CWGJBXX.SPKG);
                LoadPhotos(xml.Value.Photos);
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
    obj = jsonObj.AddJson(obj, "PZ", "'" + $("#spanPZ").html() + "'");
    obj = jsonObj.AddJson(obj, "NLDW", "'" + $("#spanNLDW").html() + "'");
    obj = jsonObj.AddJson(obj, "XB", "'" + $("#spanXB").html() + "'");
    obj = jsonObj.AddJson(obj, "YMQK", "'" + $("#spanYMQK").html() + "'");
    obj = jsonObj.AddJson(obj, "YMZL", "'" + $("#spanYMZL").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetSF() + "'");
    obj = jsonObj.AddJson(obj, "QCQK", "'" + GetQCQK() + "'");
    obj = jsonObj.AddJson(obj, "SPKG", "'" + GetSPKG() + "'");

    if (getUrlParam("CW_CWGJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "CW_CWGJBXXID", "'" + getUrlParam("CW_CWGJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CW_CWG/FB",
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