var isleave = true;
var ue = UE.getEditor('BCMS');
$(document).ready(function () {
    
    
    $("#btnFB").bind("click", FB);
    $("#BCMS").bind("focus", BCMSFocus);
    $("#BCMS").bind("blur", BCMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    
    $("body").bind("click", function () { Close("_XZQ"); Close("LB"); Close("XL"); Close("XJ"); Close("QY"); Close("SQ"); });

    LoadDefault();
    LoadFC_SPJBXX();
    BindClick("SPLX");
    BindClick("QY");
    BindClick("DD");
    BindClick("ZJDW");
});
//房屋描述框focus
function BCMSFocus() {
    $("#BCMS").css("color", "#333333");
}
//房屋描述框blur
function BCMSBlur() {
    $("#BCMS").css("color", "#999999");
}
//房屋描述框设默认文本
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
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "SPLX") {
            LoadCODESByTYPENAME("商铺类型", "SPLX", "CODES_FC");
        }
        if (type === "ZJDW") {
            LoadCODESByTYPENAME("租金单位", "ZJDW", "CODES_FC");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//设置供求
function SetGQ(gq) {
    if (gq === 0) {
        $("#divZJ").css("display", "block");
        $("#divSJ").css("display", "none");
    }
    else {
        $("#divZJ").css("display", "none");
        $("#divSJ").css("display", "block");
    }
}
//加载房产_商铺基本信息
function LoadFC_SPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC_SP/LoadFC_SPJBXX",
        dataType: "json",
        data:
        {
            FC_SPJBXXID: getUrlParam("FC_SPJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.FC_SPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#FC_SPJBXXID").val(xml.Value.FC_SPJBXX.FC_SPJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.FC_SPJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.FC_SPJBXX.GQ);
                if (xml.Value.FC_SPJBXX.FL !== null)
                    SetDX("FL", xml.Value.FC_SPJBXX.FL);
                $("#spanSPLX").html(xml.Value.FC_SPJBXX.SPLX);
                $("#spanQY").html(xml.Value.FC_SPJBXX.QY);
                $("#spanSQ").html(xml.Value.FC_SPJBXX.SQ);
                $("#spanZJDW").html(xml.Value.FC_SPJBXX.ZJDW);
                $("#JYGZ").html(xml.Value.FC_SPJBXX.JYGZ);
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
    obj = jsonObj.AddJson(obj, "SPLX", "'" + $("#spanSPLX").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "SQ", "'" + $("#spanSQ").html() + "'");
    obj = jsonObj.AddJson(obj, "ZJDW", "'" + $("#spanZJDW").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "FL", "'" + GetDX("FL") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if (getUrlParam("FC_SPJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "FC_SPJBXXID", "'" + getUrlParam("FC_SPJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC_SP/FB",
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