$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadSJSJWPLB();
    BindClick("QY");
    BindClick("DD");
});
//加载代驾/司机外派类别
function LoadSJSJWPLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "代驾/司机外派",
            TBName: "CODES_SHFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liSJSJWPLB' onclick='SelectDuoX(this)'><img class='img_SJSJWPLB'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 6 === 5) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divSJSJWPLBText").html(html);
                $(".img_SJSJWPLB").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liSJSJWPLB").bind("click", function () { ValidateCheck("OUTLB", "忘记选择类别啦"); });
                LoadSHFW_CLFW_DJSJWPJBXX();
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
//加载休闲娱乐_代驾/司机外派基本信息
function LoadSHFW_CLFW_DJSJWPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_CLFW_DJSJWP/LoadSHFW_CLFW_DJSJWPJBXX",
        dataType: "json",
        data:
        {
            SHFW_CLFW_DJSJWPJBXXID: getUrlParam("SHFW_CLFW_DJSJWPJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SHFW_CLFW_DJSJWPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SHFW_CLFW_DJSJWPJBXXID").val(xml.Value.SHFW_CLFW_DJSJWPJBXX.SHFW_CLFW_DJSJWPJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                SetDuoX("SJSJWPLB", xml.Value.SHFW_CLFW_DJSJWPJBXX.LB);
                $("#spanQY").html(xml.Value.SHFW_CLFW_DJSJWPJBXX.QY);
                $("#spanDD").html(xml.Value.SHFW_CLFW_DJSJWPJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDuoX("SJSJWPLB") + "'");

    if (getUrlParam("SHFW_CLFW_DJSJWPJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SHFW_CLFW_DJSJWPJBXXID", "'" + getUrlParam("SHFW_CLFW_DJSJWPJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_CLFW_DJSJWP/FB",
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