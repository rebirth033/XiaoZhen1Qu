
$(document).ready(function () {$("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });BindClick("YS");
    BindClick("LX");
    BindClick("CZ");
    BindClick("QY");
    BindClick("DD");
    LoadHQSY_HSLFJBXX();
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "YS") {
            LoadCODESByTYPENAME("婚纱礼服颜色", "YS", "CODES_HQSY");
        }
        if (type === "LX") {
            LoadCODESByTYPENAME("婚纱礼服类型", "LX", "CODES_HQSY");
        }
        if (type === "CZ") {
            LoadCODESByTYPENAME("婚纱礼服材质", "CZ", "CODES_HQSY");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//选择类别下拉框
function SelectLB(obj, type, lbid) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#LBID").val(lbid);
}
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: type,
            TBName: "CODES_HQSY"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 3 || i === 7 || i === 11) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 4) * 45 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 4) + 1) * 45 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadHQSY_HSLFJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载婚庆摄影_婚纱礼服基本信息
function LoadHQSY_HSLFJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY_HSLF/LoadHQSY_HSLFJBXX",
        dataType: "json",
        data:
        {
            HQSY_HSLFJBXXID: getUrlParam("HQSY_HSLFJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.HQSY_HSLFJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#HQSY_HSLFJBXXID").val(xml.Value.HQSY_HSLFJBXX.HQSY_HSLFJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanYS").html(xml.Value.HQSY_HSLFJBXX.YS);
                $("#spanLX").html(xml.Value.HQSY_HSLFJBXX.LX);
                $("#spanCZ").html(xml.Value.HQSY_HSLFJBXX.CZ);
                $("#spanQY").html(xml.Value.HQSY_HSLFJBXX.QY);
                $("#spanDD").html(xml.Value.HQSY_HSLFJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.HQSY_HSLFJBXX.FG !== null)
                    SetDX("FG", xml.Value.HQSY_HSLFJBXX.FG);
                if (xml.Value.HQSY_HSLFJBXX.KS !== null)
                    SetDX("KS", xml.Value.HQSY_HSLFJBXX.KS);
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
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "YS", "'" + $("#spanYS").html() + "'");
    obj = jsonObj.AddJson(obj, "LX", "'" + $("#spanLX").html() + "'");
    obj = jsonObj.AddJson(obj, "CZ", "'" + $("#spanCZ").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "FG", "'" + GetDX("FG") + "'");
    obj = jsonObj.AddJson(obj, "KS", "'" + GetDX("KS") + "'");

    if (getUrlParam("HQSY_HSLFJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "HQSY_HSLFJBXXID", "'" + getUrlParam("HQSY_HSLFJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY_HSLF/FB",
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