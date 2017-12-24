$(document).ready(function () {
    $("body").bind("click", function() { Close("_XZQ"); });
    $("#divGQ").find(".div_radio").bind("click", GetGQ);
    $("#divFL").find(".div_radio").bind("click", GetFL);
    BindClick("SPLX");
    BindClick("JYHY");
    BindClick("ZJDW");
    BindClick("YFFS");
    LoadDuoX("商铺配套", "SPPT");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "SPLX") {
            LoadCODESByTYPENAME("商铺类型", "SPLX", "CODES_FC", Bind, "LX", "SPLX", "");
        }
        if (type === "JYHY") {
            LoadCODESByTYPENAME("经营行业", "JYHY", "CODES_FC", Bind, "SPJYHY", "JYHY", "");

        }
        if (type === "ZJDW") {
            LoadCODESByTYPENAME("厂房租金单位", "ZJDW", "CODES_FC");
        }
        if (type === "YFFS") {
            LoadCODESByTYPENAME("押付方式", "YFFS", "CODES_FC");
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
            TBName: "CODES_FC"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 4 || i === 9 || i === 14 || i === 19) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 183px'>";
                    }
                }
                if (parseInt(xml.list.length % 5) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 5) * 45 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 5) + 1) * 45 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadFC_SPJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//设置分类
function SetFL(fl) {
    if (fl !== "商铺租售") {
        $("#divGQ").css("display", "none");
    }
    else {
        $("#divGQ").css("display", "block");
    }
}
//获取分类
function GetFL() {
    var value = "";
    $("#divFL").find("img").each(function () {
        if ($(this).attr("src").indexOf("purple") !== -1)
            value = $(this).parent().find("label")[0].innerHTML;
    });
    if (value !== "商铺租售") {
        $("#divGQ").css("display", "none");
    } else {
        $("#divGQ").css("display", "block");
    }
    return value;
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
        if ($(this).attr("src").indexOf("purple") !== -1)
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
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                if (xml.Value.FC_SPJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.FC_SPJBXX.GQ);
                if (xml.Value.FC_SPJBXX.FL !== null)
                    SetDX("FL", xml.Value.FC_SPJBXX.FL);
                if (xml.Value.FC_SPJBXX.JYZT !== null)
                    SetDX("JYZT", xml.Value.FC_SPJBXX.JYZT);
                if (xml.Value.FC_SPJBXX.SFLJ !== null)
                    SetDX("SFLJ", xml.Value.FC_SPJBXX.SFLJ);
                if (xml.Value.FC_SPJBXX.PT !== null)
                    SetDuoX("SPPT", xml.Value.FC_SPJBXX.PT);
                $("#spanSPLX").html(xml.Value.FC_SPJBXX.SPLX);
                $("#spanJYHY").html(xml.Value.FC_SPJBXX.JYHY);
                $("#spanQY").html(xml.Value.FC_SPJBXX.QY);
                $("#spanDD").html(xml.Value.FC_SPJBXX.DD);
                $("#spanZJDW").html(xml.Value.FC_SPJBXX.ZJDW);
                $("#spanYFFS").html(xml.Value.FC_SPJBXX.YFFS);
                SetFL(xml.Value.FC_SPJBXX.FL);
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
    if (GetDX("GQ") === "出租")
        obj = jsonObj.AddJson(obj, "ZJDW", "'元/月'");
    if (GetDX("GQ") === "出售")
        obj = jsonObj.AddJson(obj, "ZJDW", "'万元'");
    obj = jsonObj.AddJson(obj, "YFFS", "'" + $("#spanYFFS").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "FL", "'" + GetDX("FL") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");
    obj = jsonObj.AddJson(obj, "JYZT", "'" + GetDX("JYZT") + "'");
    obj = jsonObj.AddJson(obj, "SFLJ", "'" + GetDX("SFLJ") + "'");
    obj = jsonObj.AddJson(obj, "PT", "'" + GetDuoX("SPPT") + "'");

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