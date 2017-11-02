$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    BindClick("LB");
    BindClick("PP");
    BindClick("QY");
    BindClick("DD");
    LoadSHFW_SHFW_SHPSJBXX();
});

//选择类别下拉框
function SelectLB(obj, type, id) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    if(type === "LB")
    PDLB(obj.innerHTML);

}
//判断类别
function PDLB(lbmc) {
    if (lbmc === "跑腿服务") {
        LoadXL($("#spanLB").html());
        $("#divXL").css("display", "block");
        $("#divTZSPP").css("display", "none");
    }
    else if (lbmc === "桶装水") {
        $("#divXL").css("display", "none");
        $("#divTZSPP").css("display", "");
    }
    else {
        $("#divXL").css("display", "none");
        $("#divTZSPP").css("display", "none");
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
                    if (i % 6 === 5) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 6) === 0)
                    $("#divXL").css("height", parseInt(xml.list.length / 6) * 60 + "px");
                else
                    $("#divXL").css("height", (parseInt(xml.list.length / 6) + 1) * 60 + "px");
                html += "</ul>";
                $("#divXLText").html(html);
                $(".img_XL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liXL").bind("click", function () { ValidateCheck("XL", "忘记选择小类啦"); });
                if (xml.list.length === 0)
                    $("#divXL").css("display", "none");
                else
                    $("#divXL").css("display", "");
                if (xl !== "" && xl !== null)
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
            LoadCODESByTYPENAME("生活配送", "LB", "CODES_SHFW", Bind, "OUTLB", "LB", "");
        }
        if (type === "PP") {
            LoadCODESByTYPENAME("桶装水品牌", "PP", "CODES_SHFW", Bind, "TZSPP", "PP", "");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载生活服务_生活配送基本信息
function LoadSHFW_SHFW_SHPSJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW/LoadSHFW_SHFW_SHPSJBXX",
        dataType: "json",
        data:
        {
            SHFW_SHFW_SHPSJBXXID: getUrlParam("SHFW_SHFW_SHPSJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SHFW_SHFW_SHPSJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SHFW_SHFW_SHPSJBXXID").val(xml.Value.SHFW_SHFW_SHPSJBXX.SHFW_SHFW_SHPSJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.SHFW_SHFW_SHPSJBXX.LB);
                $("#spanQY").html(xml.Value.SHFW_SHFW_SHPSJBXX.QY);
                $("#spanDD").html(xml.Value.SHFW_SHFW_SHPSJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.SHFW_SHFW_SHPSJBXX.LB.indexOf("跑腿服务") !== -1) {
                    LoadXL(xml.Value.SHFW_SHFW_SHPSJBXX.LB, xml.Value.SHFW_SHFW_SHPSJBXX.XL);
                }
                if (xml.Value.SHFW_SHFW_SHPSJBXX.LB.indexOf("桶装水") !== -1) {
                    $("#divTZSPP").css("display", "");
                    $("#spanPP").html(xml.Value.SHFW_SHFW_SHPSJBXX.PP);
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
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanPP").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + GetDuoX("XL") + "'");

    if (getUrlParam("SHFW_SHFW_SHPSJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SHFW_SHFW_SHPSJBXXID", "'" + getUrlParam("SHFW_SHFW_SHPSJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW/FBSHFW_SHFW_SHPSJBXX",
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