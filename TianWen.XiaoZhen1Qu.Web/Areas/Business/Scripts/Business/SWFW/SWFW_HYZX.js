var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#imgGNHYZX").bind("click", GNHYZXSelect);
    $("#imgGJHYZX").bind("click", GJHYZXSelect);
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
    LoadHYZXLB();
    LoadDefault();
    BindClick("QY");
    BindClick("DD");
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
    $(".iFWCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择国内货运专线
function GNHYZXSelect() {
    $("#imgGNHYZX").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgGJHYZX").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择国际货运专线
function GJHYZXSelect() {
    $("#imgGNHYZX").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgGJHYZX").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}
//获取供求
function GetGQ() {
    if ($("#imgGRZR").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置供求
function SetGQ(gq) {
    if (gq === 0) {
        $("#imgGRZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgGRZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgSJZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//加载货运专线类别
function LoadHYZXLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_SWFW",
        dataType: "json",
        data:
        {
            TYPENAME: "货运专线"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liHYZXLB' onclick='SelectHYZXLB(this)'><img class='img_HYZXLB'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 3 || i === 7 || i === 11 || i === 15 || i === 19) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divHYZXLB").css("height", parseInt(xml.list.length / 4) * 45 + "px");
                else
                    $("#divHYZXLB").css("height", (parseInt(xml.list.length / 4) + 1) * 45 + "px");
                html += "</ul>";
                $("#divHYZXLBText").html(html);
                $(".img_HYZXLB").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadSWFW_HYZXJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择货运专线
function SelectHYZXLB(obj) {
    if ($(obj).find("img").attr("src").indexOf("blue") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
}
//获取货运专线类别
function GetHYZXLB() {
    var HYZXLB = "";
    $(".liHYZXLB").each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            HYZXLB += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(HYZXLB, ',');
}
//设置货运专线类别
function SetHYZXLB(lbs) {
    var lbarray = lbs.split(',');
    for (var i = 0; i < lbarray.length; i++) {
        $(".liHYZXLB").each(function () {
            if ($(this).find("label")[0].innerHTML.indexOf(lbarray[i]) !== -1)
                $(this).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
        });
    }
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadLB();
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载商务服务_货运专线基本信息
function LoadSWFW_HYZXJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW_HYZX/LoadSWFW_HYZXJBXX",
        dataType: "json",
        data:
        {
            SWFW_HYZXJBXXID: getUrlParam("SWFW_HYZXJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SWFW_HYZXJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SWFW_HYZXJBXXID").val(xml.Value.SWFW_HYZXJBXX.SWFW_HYZXJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.SWFW_HYZXJBXX.BCMS);
                });
                SetHYZXLB(xml.Value.SWFW_HYZXJBXX.LB);
                $("#spanQY").html(xml.Value.SWFW_HYZXJBXX.QY);
                $("#spanDD").html(xml.Value.SWFW_HYZXJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "LB", "'" + GetHYZXLB() + "'");

    if (getUrlParam("SWFW_HYZXJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SWFW_HYZXJBXXID", "'" + getUrlParam("SWFW_HYZXJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW_HYZX/FB",
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