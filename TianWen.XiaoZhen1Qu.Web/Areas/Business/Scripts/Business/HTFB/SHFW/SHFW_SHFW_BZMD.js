﻿$(document).ready(function () {
    $("#divSFSM").find(".div_radio").bind("click", function () { ValidateRadio("SFSM", "忘记选择是否上门啦"); });
    $("body").bind("click", function () { Close("_XZQ"); });
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
    LoadSHFW_SHFW_BZMDJBXX();
});
//选择类别下拉框
function SelectLB(obj, type, id) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    PDLB(obj.innerHTML);
}

function PDLB(lb) {
    if (lb === "殡仪馆/殡葬服务" || lb === "殡葬用品") {
        LoadXL($("#spanLB").html());
        $("#divXL").css("display", "");
    }
    else {
        $("#divXL").css("display", "none");
    }
}
//加载小类
function LoadXL(lbmc, xl) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: lbmc,
            TBName: "CODES_SHFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liXL' onclick='SelectDuoX(this)'><img class='img_XL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 4 === 3) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divXL").css("height", parseInt(xml.list.length / 4) * 60 + "px");
                else
                    $("#divXL").css("height", (parseInt(xml.list.length / 4) + 1) * 60 + "px");
                html += "</ul>";
                $("#divXLText").html(html);
                $(".img_XL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liXL").bind("click", function () { ValidateCheck("XL", "忘记选择小类啦"); });
                if (xml.list.length === 0)
                    $("#divXL").css("display", "none");
                else
                    $("#divXL").css("display", "");
                if (xl !== "" && xl !== null && xl !== undefined)
                    SetDuoX("XL", xl);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("殡葬/墓地", "LB", "CODES_SHFW", Bind, "OUTLB", "LB", "");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载生活服务_殡葬/墓地基本信息
function LoadSHFW_SHFW_BZMDJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW/LoadSHFW_SHFW_BZMDJBXX",
        dataType: "json",
        data:
        {
            SHFW_SHFW_BZMDJBXXID: getUrlParam("SHFW_SHFW_BZMDJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SHFW_SHFW_BZMDJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SHFW_SHFW_BZMDJBXXID").val(xml.Value.SHFW_SHFW_BZMDJBXX.SHFW_SHFW_BZMDJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.SHFW_SHFW_BZMDJBXX.LB);
                $("#spanQY").html(xml.Value.SHFW_SHFW_BZMDJBXX.QY);
                $("#spanDD").html(xml.Value.SHFW_SHFW_BZMDJBXX.DD);
                SetDX("SFSM", xml.Value.SHFW_SHFW_BZMDJBXX.SFSM);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.SHFW_SHFW_BZMDJBXX.LB.indexOf("殡葬用品") !== -1 || xml.Value.SHFW_SHFW_BZMDJBXX.LB.indexOf("殡仪馆/殡葬服务") !== -1) {
                    LoadXL(xml.Value.SHFW_SHFW_BZMDJBXX.LB, xml.Value.SHFW_SHFW_BZMDJBXX.XL);
                }
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
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + GetDuoX("XL") + "'");
    obj = jsonObj.AddJson(obj, "SFSM", "'" + GetDX("SFSM") + "'");

    if (getUrlParam("SHFW_SHFW_BZMDJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SHFW_SHFW_BZMDJBXXID", "'" + getUrlParam("SHFW_SHFW_BZMDJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW/FBSHFW_SHFW_BZMDJBXX",
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