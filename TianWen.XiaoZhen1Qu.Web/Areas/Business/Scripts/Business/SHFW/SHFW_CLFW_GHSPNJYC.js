var isleave = true;
var ue = UE.getEditor('BCMS');
$(document).ready(function () {
    
    
    $("#btnFB").bind("click", FB);
    $("#BCMS").bind("focus", BCMSFocus);
    $("#BCMS").bind("blur", BCMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qCWFWs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });



    LoadSJSJWPLB();
    LoadDefault();
    BindClick("QY");
    BindClick("DD");
});
//描述框focus
function BCMSFocus() {
    $("#BCMS").css("color", "#333333");
}
//描述框blur
function BCMSBlur() {
    $("#BCMS").css("color", "#999999");
}
//描述框设默认文本
function BCMSSetDefault() {
    var BCMS = "1.房屋特征：\r\n\r\n2.周边配套：\r\n\r\n3.房东心态：";
    $("#BCMS").html(BCMS);
}
//加载默认
function LoadDefault() {
    ue.ready(function () {
        ue.setHeight(200);
    });
}
//加载过户/上牌/年检/验车类别
function LoadSJSJWPLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "过户/上牌/年检/验车",
            TBName: "CODES_SHFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liFWPZ' onclick='SelectDuoX(this)'><img class='img_SJSJWPLB'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 5 || i === 11 || i === 17 || i === 23 || i === 29) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divSJSJWPLBText").html(html);
                $(".img_SJSJWPLB").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadSHFW_CLFW_GHSPNJYCJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
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
//加载休闲娱乐_过户/上牌/年检/验车基本信息
function LoadSHFW_CLFW_GHSPNJYCJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_CLFW_GHSPNJYC/LoadSHFW_CLFW_GHSPNJYCJBXX",
        dataType: "json",
        data:
        {
            SHFW_CLFW_GHSPNJYCJBXXID: getUrlParam("SHFW_CLFW_GHSPNJYCJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SHFW_CLFW_GHSPNJYCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SHFW_CLFW_GHSPNJYCJBXXID").val(xml.Value.SHFW_CLFW_GHSPNJYCJBXX.SHFW_CLFW_GHSPNJYCJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                SetDuoX("SJSJWPLB", xml.Value.SHFW_CLFW_GHSPNJYCJBXX.LB);
                $("#spanQY").html(xml.Value.SHFW_CLFW_GHSPNJYCJBXX.QY);
                $("#spanDD").html(xml.Value.SHFW_CLFW_GHSPNJYCJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDuoX("SJSJWPLB") + "'");

    if (getUrlParam("SHFW_CLFW_GHSPNJYCJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SHFW_CLFW_GHSPNJYCJBXXID", "'" + getUrlParam("SHFW_CLFW_GHSPNJYCJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_CLFW_GHSPNJYC/FB",
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