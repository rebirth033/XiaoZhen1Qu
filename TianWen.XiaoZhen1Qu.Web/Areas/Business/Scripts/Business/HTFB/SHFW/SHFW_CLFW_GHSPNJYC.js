$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadGHSPNJYC();
    BindClick("QY");
    BindClick("DD");
});
//加载过户/上牌/年检/验车类别
function LoadGHSPNJYC() {
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
                    html += "<li class='liOUTLB' onclick='SelectDuoX(this)'><img class='img_GHSPNJYC'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 4 === 3) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divOUTLB").css("height", parseInt(xml.list.length / 4) * 60 + "px");
                else
                    $("#divOUTLB").css("height", (parseInt(xml.list.length / 4) + 1) * 60 + "px");
                html += "</ul>";
                $("#divOUTLBText").html(html);
                $(".img_GHSPNJYC").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liOUTLB").bind("click", function () { ValidateCheck("OUTLB", "忘记选择类别啦"); });
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
        url: getRootPath() + "/Business/SHFW/LoadSHFW_CLFW_GHSPNJYCJBXX",
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
                if (xml.Value.SHFW_CLFW_GHSPNJYCJBXX.LB !== "" && xml.Value.SHFW_CLFW_GHSPNJYCJBXX.LB !== null)
                SetDuoX("OUTLB", xml.Value.SHFW_CLFW_GHSPNJYCJBXX.LB);
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
    if (ValidateAll() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDuoX("OUTLB") + "'");

    if (getUrlParam("SHFW_CLFW_GHSPNJYCJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SHFW_CLFW_GHSPNJYCJBXXID", "'" + getUrlParam("SHFW_CLFW_GHSPNJYCJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW/FBSHFW_CLFW_GHSPNJYCJBXX",
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