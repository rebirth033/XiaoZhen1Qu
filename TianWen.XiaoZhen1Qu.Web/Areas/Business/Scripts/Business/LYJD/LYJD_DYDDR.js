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



    LoadDefault();
    BindClick("XL");
    BindClick("DTJY");
    BindClick("QY");
    BindClick("DD");
    LoadDuoX("导游语种", "DYYZ");
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
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: type,
            TBName: "CODES_LYJD"
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
                if (type === "导游语种")
                    LoadLYJD_DYDDRJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "XL") {
            LoadCODESByTYPENAME("导游学历", "XL", "CODES_LYJD");
        }
        if (type === "DTJY") {
            LoadCODESByTYPENAME("带团经验", "DTJY", "CODES_LYJD");
        }
        if (type === "CYFS") {
            LoadCODESByTYPENAME("出游方式", "CYFS", "CODES_LYJD");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载旅游酒店_导游/当地人基本信息
function LoadLYJD_DYDDRJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LYJD_DYDDR/LoadLYJD_DYDDRJBXX",
        dataType: "json",
        data:
        {
            LYJD_DYDDRJBXXID: getUrlParam("LYJD_DYDDRJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.LYJD_DYDDRJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#LYJD_DYDDRJBXXID").val(xml.Value.LYJD_DYDDRJBXX.LYJD_DYDDRJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanXL").html(xml.Value.LYJD_DYDDRJBXX.XL);
                $("#spanDTJY").html(xml.Value.LYJD_DYDDRJBXX.DTJY);
                $("#spanQY").html(xml.Value.LYJD_DYDDRJBXX.QY);
                $("#spanDD").html(xml.Value.LYJD_DYDDRJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                SetDX("XB", xml.Value.LYJD_DYDDRJBXX.XB);
                SetDX("DYLX", xml.Value.LYJD_DYDDRJBXX.DYLX);
                SetDuoX("DYYZ", xml.Value.LYJD_DYDDRJBXX.DYYZ);
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
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "DTJY", "'" + $("#spanDTJY").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "XB", "'" + GetDX("XB") + "'");
    obj = jsonObj.AddJson(obj, "DYLX", "'" + GetDX("DYLX") + "'");
    obj = jsonObj.AddJson(obj, "DYYZ", "'" + GetDuoX("DYYZ") + "'");

    if (getUrlParam("LYJD_DYDDRJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "LYJD_DYDDRJBXXID", "'" + getUrlParam("LYJD_DYDDRJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LYJD_DYDDR/FB",
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