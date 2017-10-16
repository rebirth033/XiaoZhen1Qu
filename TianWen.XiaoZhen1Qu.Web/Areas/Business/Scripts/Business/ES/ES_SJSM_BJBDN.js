var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#imgSJZR").bind("click", SJZRSelect);
    $("#imgSJHS").bind("click", SJHSSelect);
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qhcs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("LB"); Close("XL"); Close("XJ"); Close("QY"); Close("DD"); });
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);

    LoadTXXX();
    LoadDefault();
    LoadES_SJSM_BJBDNJBXX();
    BindClick("LB");
    BindClick("BJBPP");
    BindClick("XL");
    BindClick("BJBXH");
    BindClick("XJ");
    BindClick("QY");
    BindClick("SQ");

    BindClick("CPUPP");
    BindClick("CPUHS");
    BindClick("NC");
    BindClick("YP");
    BindClick("PMCC");
    BindClick("XK");
});
//房屋描述框focus
function FYMSFocus() {
    $("#FYMS").css("color", "#333333");
}
//房屋描述框blur
function FYMSBlur() {
    $("#FYMS").css("color", "#999999");
}
//房屋描述框设默认文本
function FYMSSetDefault() {
    var fyms = "1.房屋特征：\r\n\r\n2.周边配套：\r\n\r\n3.房东心态：";
    $("#FYMS").html(fyms);
}
//加载默认
function LoadDefault() {
    ue.ready(function () {
        ue.setHeight(200);
    });
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSJHS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgSYG").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgQXWCF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择商家转让
function SJZRSelect() {
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSJHS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择商家回收
function SJHSSelect() {
    $("#imgSJHS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadBJBLB();
        }
        if (type === "BJBPP") {
            LoadBJBPP();
        }
        if (type === "BJBXH") {
            LoadBJBXH();
        }
        if (type === "CPUPP") {
            LoadCPUPP();
        }
        if (type === "CPUHS") {
            LoadCPUHS();
        }
        if (type === "NC") {
            LoadNC();
        }
        if (type === "YP") {
            LoadYP();
        }
        if (type === "PMCC") {
            LoadPMCC();
        }
        if (type === "XK") {
            LoadXK();
        }
        if (type === "XL") {
            LoadPJ();
        }
        if (type === "XJ") {
            LoadXJ();
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载笔记本类别
function LoadBJBLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_SJSM",
        dataType: "json",
        data:
        {
            TYPENAME: "笔记本类别"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;height:69px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"LB\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
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
//加载笔记本品牌
function LoadBJBPP() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_SJSM",
        dataType: "json",
        data:
        {
            TYPENAME: "笔记本品牌"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;height:340px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectBJBPP(this,\"BJBPP\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divBJBPP").html(html);
                $("#divBJBPP").css("display", "block");
                ActiveStyle("BJBPP");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载笔记本型号
function LoadBJBXH(BJBPP) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: BJBPP,
            TBName: "CODES_ES_SJSM"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;height:340px;width:200px'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"BJBXH\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divBJBXH").html(html);
                $("#divBJBXH").css("display", "block");
                ActiveStyle("BJBXH");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载CPU品牌
function LoadCPUPP() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_SJSM",
        dataType: "json",
        data:
        {
            TYPENAME: "CPU品牌"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"CPUPP\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divCPUPP").html(html);
                $("#divCPUPP").css("display", "block");
                ActiveStyle("CPUPP");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载CPU核数
function LoadCPUHS() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_SJSM",
        dataType: "json",
        data:
        {
            TYPENAME: "CPU核数"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"CPUHS\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divCPUHS").html(html);
                $("#divCPUHS").css("display", "block");
                ActiveStyle("CPUHS");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载内存
function LoadNC() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_SJSM",
        dataType: "json",
        data:
        {
            TYPENAME: "内存"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"NC\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divNC").html(html);
                $("#divNC").css("display", "block");
                ActiveStyle("NC");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载硬盘
function LoadYP() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_SJSM",
        dataType: "json",
        data:
        {
            TYPENAME: "硬盘"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"YP\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divYP").html(html);
                $("#divYP").css("display", "block");
                ActiveStyle("YP");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载屏幕尺寸
function LoadPMCC() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_SJSM",
        dataType: "json",
        data:
        {
            TYPENAME: "屏幕尺寸"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"PMCC\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divPMCC").html(html);
                $("#divPMCC").css("display", "block");
                ActiveStyle("PMCC");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载显卡
function LoadXK() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_SJSM",
        dataType: "json",
        data:
        {
            TYPENAME: "显卡"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"XK\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divXK").html(html);
                $("#divXK").css("display", "block");
                ActiveStyle("XK");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载笔记本新旧
function LoadXJ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_SJSM",
        dataType: "json",
        data:
        {
            TYPENAME: "新旧程度"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"XJ\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divXJ").html(html);
                $("#divXJ").css("display", "block");
                ActiveStyle("XJ");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载笔记本配件
function LoadPJ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_ES_SJSM",
        dataType: "json",
        data:
        {
            TYPENAME: "笔记本配件"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"XL\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divXL").html(html);
                $("#divXL").css("display", "block");
                ActiveStyle("XL");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    PDLB(obj.innerHTML);
}
//判断类别
function PDLB(LB) {
    if (LB.indexOf("配件") !== -1) {
        $("#divXLText").css("display", "");
        $("#divBJBPPText").css("display", "none");
        $("#divBJBXHText").css("display", "none");
        $("#divBJBXXCS").css("display", "none");
        $("#divBJBXXCS_2").css("display", "none");
    } else {
        $("#divXLText").css("display", "none");
        $("#divBJBPPText").css("display", "");
        $("#divBJBXHText").css("display", "");
        $("#divBJBXXCS").css("display", "");
        $("#divBJBXXCS_2").css("display", "");
    }
}
//选择笔记本品牌
function SelectBJBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadBJBXH(code);
}
//获取供求
function GetGQ() {
    if ($("#imgSJZR").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置供求
function SetGQ(gq) {
    if (gq === 0) {
        $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgSJHS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgSJHS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//加载二手_手机数码_二手手机基本信息
function LoadES_SJSM_BJBDNJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_SJSM_BJBDN/LoadES_SJSM_BJBDNJBXX",
        dataType: "json",
        data:
        {
            ES_SJSM_BJBDNJBXXID: getUrlParam("ES_SJSM_BJBDNJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_SJSM_BJBDNJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_SJSM_BJBDNJBXXID").val(xml.Value.ES_SJSM_BJBDNJBXX.ES_SJSM_BJBDNJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.ES_SJSM_BJBDNJBXX.BCMS);
                });
                SetGQ(xml.Value.ES_SJSM_BJBDNJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_SJSM_BJBDNJBXX.LB);
                $("#spanBJBPP").html(xml.Value.ES_SJSM_BJBDNJBXX.BJBPP);
                $("#spanBJBXH").html(xml.Value.ES_SJSM_BJBDNJBXX.BJBXH);
                $("#spanXJ").html(xml.Value.ES_SJSM_BJBDNJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_SJSM_BJBDNJBXX.JYQY);
                $("#spanDD").html(xml.Value.ES_SJSM_BJBDNJBXX.JYDD);
                $("#spanXL").html(xml.Value.ES_SJSM_BJBDNJBXX.XL);

                $("#spanCPUPP").html(xml.Value.ES_SJSM_BJBDNJBXX.CPUPP);
                $("#spanCPUHS").html(xml.Value.ES_SJSM_BJBDNJBXX.CPUHS);
                $("#spanNC").html(xml.Value.ES_SJSM_BJBDNJBXX.NC);
                $("#spanYP").html(xml.Value.ES_SJSM_BJBDNJBXX.YP);
                $("#spanPMCC").html(xml.Value.ES_SJSM_BJBDNJBXX.PMCC);
                $("#spanXK").html(xml.Value.ES_SJSM_BJBDNJBXX.XK);

                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_SJSM_BJBDNJBXX.LB);
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
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "BJBPP", "'" + $("#spanBJBPP").html() + "'");
    obj = jsonObj.AddJson(obj, "BJBXH", "'" + $("#spanBJBXH").html() + "'");
    obj = jsonObj.AddJson(obj, "XJ", "'" + $("#spanXJ").html() + "'");
    obj = jsonObj.AddJson(obj, "JYQY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "JYDD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetGQ() + "'");

    obj = jsonObj.AddJson(obj, "CPUPP", "'" + $("#spanCPUPP").html() + "'");
    obj = jsonObj.AddJson(obj, "CPUHS", "'" + $("#spanCPUHS").html() + "'");
    obj = jsonObj.AddJson(obj, "NC", "'" + $("#spanNC").html() + "'");
    obj = jsonObj.AddJson(obj, "YP", "'" + $("#spanYP").html() + "'");
    obj = jsonObj.AddJson(obj, "PMCC", "'" + $("#spanPMCC").html() + "'");
    obj = jsonObj.AddJson(obj, "XK", "'" + $("#spanXK").html() + "'");

    if (getUrlParam("ES_SJSM_BJBDNJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_SJSM_BJBDNJBXXID", "'" + getUrlParam("ES_SJSM_BJBDNJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_SJSM_BJBDN/FB",
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
