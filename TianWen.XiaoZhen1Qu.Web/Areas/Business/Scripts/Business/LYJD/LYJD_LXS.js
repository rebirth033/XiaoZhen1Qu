var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    
    
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qCWFWs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });



    LoadDefault();
    BindClick("QY");
    BindClick("DD");
    LoadLYJD_LXSJBXX();
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
//加载旅游酒店_旅行社基本信息
function LoadLYJD_LXSJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LYJD_LXS/LoadLYJD_LXSJBXX",
        dataType: "json",
        data:
        {
            LYJD_LXSJBXXID: getUrlParam("LYJD_LXSJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.LYJD_LXSJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#LYJD_LXSJBXXID").val(xml.Value.LYJD_LXSJBXX.LYJD_LXSJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.LYJD_LXSJBXX.LB);
                $("#spanQY").html(xml.Value.LYJD_LXSJBXX.QY);
                $("#spanDD").html(xml.Value.LYJD_LXSJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                LoadXL(xml.Value.LYJD_LXSJBXX.LB, xml.Value.LYJD_LXSJBXX.XL);
                if (xml.Value.LYJD_LXSJBXX.CD !== null)
                    SetDuoX("CD", xml.Value.LYJD_LXSJBXX.CD);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + GetDuoX("XL") + "'");
    obj = jsonObj.AddJson(obj, "CD", "'" + GetDuoX("CD") + "'");

    if (getUrlParam("LYJD_LXSJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "LYJD_LXSJBXXID", "'" + getUrlParam("LYJD_LXSJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LYJD_LXS/FB",
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