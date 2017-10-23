
$(document).ready(function () {$("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });BindClick("JXKM");
    BindClick("QY");
    BindClick("DD");
    LoadDuoX("辅导阶段", "FDJD");
    LoadDuoX("辅导科目", "FDKM");
    LoadJYPX_YYPXJSJBXX();
});

//选择类别下拉框
function SelectLB(obj, type, id) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadXL($("#spanYZ").html());
    $("#divXL").css("display", "");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "JXKM") {
            LoadCODESByTYPENAME("语言培训教学科目", "JXKM", "CODES_JYPX");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
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
            TBName: "CODES_JYPX"
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
                if (xml.list.length === 0)
                    $("#div" + id).css("display", "none");
                else
                    $("#div" + id).css("display", "");
                if (type === "辅导科目")
                    LoadJYPX_YYPXJSJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载商务服务_语言培训教师基本信息
function LoadJYPX_YYPXJSJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/JYPX_YYPXJS/LoadJYPX_YYPXJSJBXX",
        dataType: "json",
        data:
        {
            JYPX_YYPXJSJBXXID: getUrlParam("JYPX_YYPXJSJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JYPX_YYPXJSJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#JYPX_YYPXJSJBXXID").val(xml.Value.JYPX_YYPXJSJBXX.JYPX_YYPXJSJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanJXKM").html(xml.Value.JYPX_YYPXJSJBXX.JXKM);
                $("#spanQY").html(xml.Value.JYPX_YYPXJSJBXX.QY);
                $("#spanDD").html(xml.Value.JYPX_YYPXJSJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                SetDX("SF", xml.Value.JYPX_YYPXJSJBXX.SF);
                SetDX("JJJY", xml.Value.JYPX_YYPXJSJBXX.JJJY);
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
    obj = jsonObj.AddJson(obj, "JXKM", "'" + $("#spanJXKM").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("SF") + "'");
    obj = jsonObj.AddJson(obj, "JJJY", "'" + GetDX("JJJY") + "'");

    if (getUrlParam("JYPX_YYPXJSJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "JYPX_YYPXJSJBXXID", "'" + getUrlParam("JYPX_YYPXJSJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/JYPX_YYPXJS/FB",
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