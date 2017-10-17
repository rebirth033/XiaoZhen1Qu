var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#imgJXZS").bind("click", JXZSSelect);
    $("#imgJLZS").bind("click", JLZSSelect);
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
    BindClick("QY");
    BindClick("DD");
    LoadJZ();
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
    $("#imgJXZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgJLZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择驾校招生
function JXZSSelect() {
    $("#imgJXZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgJLZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择教练招生
function JLZSSelect() {
    $("#imgJXZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgJLZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}
//获取类别
function GetLB() {
    if ($("#imgJXZS").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置类别
function SetLB(gq) {
    if (gq === 0) {
        $("#imgJXZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgJLZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgJXZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgJLZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//加载驾照
function LoadJZ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "驾照",
            TBName: "CODES_SHFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liJZ' onclick='SelectJZ(this)'><img class='img_JZ'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 2 || i === 5 || i === 8 || i === 11 || i === 14) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 3) === 0)
                    $("#divJZ").css("height", parseInt(xml.list.length / 3) * 45 + "px");
                else
                    $("#divJZ").css("height", (parseInt(xml.list.length / 3) + 1) * 45 + "px");
                html += "</ul>";
                $("#divJZText").html(html);
                $(".img_JZ").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadBB();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载班别
function LoadBB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "班别",
            TBName: "CODES_SHFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liBB' onclick='SelectJZ(this)'><img class='img_BB'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 3 || i === 7 || i === 11 || i === 15 || i === 19) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divBB").css("height", parseInt(xml.list.length / 4) * 45 + "px");
                else
                    $("#divBB").css("height", (parseInt(xml.list.length / 4) + 1) * 45 + "px");
                html += "</ul>";
                $("#divBBText").html(html);
                $(".img_BB").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadSHFW_CLFW_JXJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择驾照
function SelectJZ(obj) {
    if ($(obj).find("img").attr("src").indexOf("blue") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
}
//获取驾照
function GetJZ() {
    var JZ = "";
    $(".liJZ").each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            JZ += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(JZ, ',');
}
//设置驾照
function SetJZ(lbs) {
    var lbarray = lbs.split(',');
    for (var i = 0; i < lbarray.length; i++) {
        $(".liJZ").each(function () {
            if ($(this).find("label")[0].innerHTML.indexOf(lbarray[i]) !== -1)
                $(this).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
        });
    }
}
//选择班别
function SelectBB(obj) {
    if ($(obj).find("img").attr("src").indexOf("blue") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
}
//获取班别
function GetBB() {
    var BB = "";
    $(".liBB").each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            BB += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(BB, ',');
}
//设置班别
function SetBB(lbs) {
    var lbarray = lbs.split(',');
    for (var i = 0; i < lbarray.length; i++) {
        $(".liBB").each(function () {
            if ($(this).find("label")[0].innerHTML.indexOf(lbarray[i]) !== -1)
                $(this).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
        });
    }
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载生活服务_驾校基本信息
function LoadSHFW_CLFW_JXJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_CLFW_JX/LoadSHFW_CLFW_JXJBXX",
        dataType: "json",
        data:
        {
            SHFW_CLFW_JXJBXXID: getUrlParam("SHFW_CLFW_JXJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SHFW_CLFW_JXJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SHFW_CLFW_JXJBXXID").val(xml.Value.SHFW_CLFW_JXJBXX.SHFW_CLFW_JXJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.SHFW_CLFW_JXJBXX.BCMS);
                });
                $("#spanQY").html(xml.Value.SHFW_CLFW_JXJBXX.QY);
                $("#spanDD").html(xml.Value.SHFW_CLFW_JXJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                SetLB(xml.Value.SHFW_CLFW_JXJBXX.LB);
                SetJZ(xml.Value.SHFW_CLFW_JXJBXX.JZ);
                SetBB(xml.Value.SHFW_CLFW_JXJBXX.BB);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + GetLB() + "'");
    obj = jsonObj.AddJson(obj, "JZ", "'" + GetJZ() + "'");
    obj = jsonObj.AddJson(obj, "BB", "'" + GetBB() + "'");

    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("SHFW_CLFW_JXJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SHFW_CLFW_JXJBXXID", "'" + getUrlParam("SHFW_CLFW_JXJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_CLFW_JX/FB",
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