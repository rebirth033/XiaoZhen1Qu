var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#div_upload").bind("mouseover", GetUploadCss);
    $("#div_upload").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qCWFWs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });



    LoadDefault();
    BindClick("PSFG");
    BindClick("LX");
    BindClick("CZ");
    BindClick("QY");
    BindClick("DD");
    LoadHQSY_HSSYJBXX();
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
    ue.ready(function () { ue.setHeight(200); });
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "PSFG") {
            LoadCODESByTYPENAME("拍摄风格", "PSFG", "CODES_HQSY");
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
                LoadHQSY_HSSYJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载婚庆摄影_婚纱摄影基本信息
function LoadHQSY_HSSYJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY_HSSY/LoadHQSY_HSSYJBXX",
        dataType: "json",
        data:
        {
            HQSY_HSSYJBXXID: getUrlParam("HQSY_HSSYJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.HQSY_HSSYJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#HQSY_HSSYJBXXID").val(xml.Value.HQSY_HSSYJBXX.HQSY_HSSYJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanPSFG").html(xml.Value.HQSY_HSSYJBXX.PSFG);
                $("#spanQY").html(xml.Value.HQSY_HSSYJBXX.QY);
                $("#spanDD").html(xml.Value.HQSY_HSSYJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                SetDX("YLGZS", xml.Value.HQSY_HSSYJBXX.YLGZS);
                SetDX("PSDD", xml.Value.HQSY_HSSYJBXX.PSDD);
                SetDX("FWBZ", xml.Value.HQSY_HSSYJBXX.FWBZ);
                SetDX("FZSFFQ", xml.Value.HQSY_HSSYJBXX.FZSFFQ);
                SetDX("FZPSSF", xml.Value.HQSY_HSSYJBXX.FZPSSF);
                SetDX("TXNHZZX", xml.Value.HQSY_HSSYJBXX.TXNHZZX);
                SetDX("JXKPZS", xml.Value.HQSY_HSSYJBXX.JXKPZS);
                SetDX("DPZS", xml.Value.HQSY_HSSYJBXX.DPZS);
                SetDX("JPSF", xml.Value.HQSY_HSSYJBXX.JPSF);
                SetDX("JDSF", xml.Value.HQSY_HSSYJBXX.JDSF);
                SetDX("BHCY", xml.Value.HQSY_HSSYJBXX.BHCY);
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
    obj = jsonObj.AddJson(obj, "PSFG", "'" + $("#spanPSFG").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "YLGZS", "'" + GetDX("YLGZS") + "'");
    obj = jsonObj.AddJson(obj, "PSDD", "'" + GetDX("PSDD") + "'");
    obj = jsonObj.AddJson(obj, "FWBZ", "'" + GetDX("FWBZ") + "'");
    obj = jsonObj.AddJson(obj, "FZSFFQ", "'" + GetDX("FZSFFQ") + "'");
    obj = jsonObj.AddJson(obj, "FZPSSF", "'" + GetDX("FZPSSF") + "'");
    obj = jsonObj.AddJson(obj, "TXNHZZX", "'" + GetDX("TXNHZZX") + "'");
    obj = jsonObj.AddJson(obj, "JXKPZS", "'" + GetDX("JXKPZS") + "'");
    obj = jsonObj.AddJson(obj, "DPZS", "'" + GetDX("DPZS") + "'");
    obj = jsonObj.AddJson(obj, "JPSF", "'" + GetDX("JPSF") + "'");
    obj = jsonObj.AddJson(obj, "JDSF", "'" + GetDX("JDSF") + "'");
    obj = jsonObj.AddJson(obj, "BHCY", "'" + GetDX("BHCY") + "'");

    if (getUrlParam("HQSY_HSSYJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "HQSY_HSSYJBXXID", "'" + getUrlParam("HQSY_HSSYJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY_HSSY/FB",
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