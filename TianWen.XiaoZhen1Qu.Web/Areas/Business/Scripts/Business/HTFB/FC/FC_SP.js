$(document).ready(function () {
    $("body").bind("click", function() { Close("_XZQ"); });
    $("#divGQ").find(".div_radio").bind("click", GetGQ);
    LoadFC_SPJBXX();
    BindClick("SPLX");
    BindClick("JYHY");
    BindClick("QY");
    BindClick("DD");
    BindClick("ZJDW");
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "SPLX") {
            LoadCODESByTYPENAME("商铺类型", "SPLX", "CODES_FC", Bind, "LX", "SPLX", "");

        }
        if (type === "JYHY") {
            LoadCODESByTYPENAME("经营行业", "JYHY", "CODES_FC", Bind, "SPJYHY", "JYHY", "");

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
    if (gq !== "出售") {
        $("#divZJ").css("display", "block");
        $("#divSJ").css("display", "none");
    }
    else {
        $("#divZJ").css("display", "none");
        $("#divSJ").css("display", "block");
    }
}
//获取供求
function GetGQ() {
    var value = "";
    $("#divGQ").find("img").each(function () {
        if ($(this).attr("src").indexOf("blue") !== -1)
            value = $(this).parent().find("label")[0].innerHTML;
    });
    if (value !== "出售") {
        $("#divZJ").css("display", "block");
        $("#divSJ").css("display", "none");
    } else {
        $("#divZJ").css("display", "none");
        $("#divSJ").css("display", "block");
    }
    return value;
}
//加载房产_商铺基本信息
function LoadFC_SPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC/LoadFC_SPJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.FC_SPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.FC_SPJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.FC_SPJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.FC_SPJBXX.GQ);
                if (xml.Value.FC_SPJBXX.FL !== null)
                    SetDX("FL", xml.Value.FC_SPJBXX.FL);
                if (xml.Value.FC_SPJBXX.JYZT !== null)
                    SetDX("JYZT", xml.Value.FC_SPJBXX.JYZT);
                $("#spanSPLX").html(xml.Value.FC_SPJBXX.SPLX);
                $("#spanJYHY").html(xml.Value.FC_SPJBXX.JYHY);
                $("#spanQY").html(xml.Value.FC_SPJBXX.QY);
                $("#spanDD").html(xml.Value.FC_SPJBXX.DD);
                $("#spanZJDW").html(xml.Value.FC_SPJBXX.ZJDW);
                $("#JYGZ").html(xml.Value.FC_SPJBXX.JYGZ);
                SetGQ(xml.Value.FC_SPJBXX.GQ);
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
    obj = jsonObj.AddJson(obj, "SPLX", "'" + $("#spanSPLX").html() + "'");
    obj = jsonObj.AddJson(obj, "JYHY", "'" + $("#spanJYHY").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "ZJDW", "'" + $("#spanZJDW").html() + "'");
    obj = jsonObj.AddJson(obj, "SJ", "'" + $("#SJ").val() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "FL", "'" + GetDX("FL") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");
    obj = jsonObj.AddJson(obj, "JYZT", "'" + GetDX("JYZT") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC/FBFC_SPJBXX",
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