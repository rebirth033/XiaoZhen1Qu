var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qCWFWs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);
    LoadTXXX();
    LoadDefault();
    BindClick("MYXZ");
    BindClick("XLYQ");
    BindClick("GZNX");
    LoadZWFL();
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
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "MYXZ") {
            LoadDropdown("每月薪资", "MYXZ");
        }
        if (type === "XLYQ") {
            LoadDropdown("学历要求", "XLYQ");
        }
        if (type === "GZNX") {
            LoadDropdown("工作年限", "GZNX");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载全职招聘类别
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
                LoadQZZP_QZZPJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择全职招聘小类
function SelectZWFL(obj) {
    if ($(obj).find("img").attr("src").indexOf("blue") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
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
//加载求职招聘_全职招聘基本信息
function LoadQZZP_QZZPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/QZZP_QZZP/LoadQZZP_QZZPJBXX",
        dataType: "json",
        data:
        {
            QZZP_QZZPJBXXID: getUrlParam("QZZP_QZZPJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.QZZP_QZZPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#QZZP_QZZPJBXXID").val(xml.Value.QZZP_QZZPJBXX.QZZP_QZZPJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.QZZP_QZZPJBXX.BCMS);
                });
                $("#spanLB").html(xml.Value.QZZP_QZZPJBXX.LB);
                $("#spanMYXZ").html(xml.Value.QZZP_QZZPJBXX.MYXZ);
                $("#spanXLYQ").html(xml.Value.QZZP_QZZPJBXX.XLYQ);
                $("#spanGZNX").html(xml.Value.QZZP_QZZPJBXX.GZNX);
                LoadPhotos(xml.Value.Photos);
                SetZWFL(xml.Value.QZZP_QZZPJBXX.ZWFL);
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
    obj = jsonObj.AddJson(obj, "MYXZ", "'" + $("#spanMYXZ").html() + "'");
    obj = jsonObj.AddJson(obj, "XLYQ", "'" + $("#spanXLYQ").html() + "'");
    obj = jsonObj.AddJson(obj, "GZNX", "'" + $("#spanGZNX").html() + "'");
    obj = jsonObj.AddJson(obj, "ZWFL", "'" + GetZWFL() + "'");

    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("QZZP_QZZPJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "QZZP_QZZPJBXXID", "'" + getUrlParam("QZZP_QZZPJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/QZZP_QZZP/FB",
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