$(document).ready(function () {
    LoadDuoX("配送方式", "PSFS");
    BindClick("LB");
    BindClick("XL");
    BindClick("PBPP");
    BindClick("PBXH");
    BindClick("XJ");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("二手家电类别", "LB", "CODES_ES_JDJJBG", Bind, "ESJDLB", "LB", "");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_JDJJBG", Bind, "ESJDLB", "XL", "");
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM", Bind, "XJCD", "XJ", "");
        }
        if (type === "DSPMCC") {
            LoadCODESByTYPENAME("电视屏幕尺寸", "DSPMCC", "CODES_ES_JDJJBG");
        }
        if (type === "DSPP") {
            LoadCODESByTYPENAME("电视品牌", "DSPP", "CODES_ES_JDJJBG");
        }
        if (type === "XYJPP") {
            LoadCODESByTYPENAME("洗衣机品牌", "XYJPP", "CODES_ES_JDJJBG");
        }
        if (type === "KTPP") {
            LoadCODESByTYPENAME("空调品牌", "KTPP", "CODES_ES_JDJJBG");
        }
        if (type === "BPDS") {
            LoadCODESByTYPENAME("变频定速", "BPDS", "CODES_ES_JDJJBG");
        }
        if (type === "KTGL") {
            LoadCODESByTYPENAME("空调功率", "KTGL", "CODES_ES_JDJJBG");
        }
        if (type === "BXPP") {
            LoadCODESByTYPENAME("冰箱品牌", "BXPP", "CODES_ES_JDJJBG");
        }
        if (type === "BGPP") {
            LoadCODESByTYPENAME("冰柜品牌", "BGPP", "CODES_ES_JDJJBG");
        }
    });
}
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: type,
            TBName: "CODES_ES_SJSM"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                   if (i % 5 === 4 && i != xml.list.length - 1) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 173px'>";
                    }
                }
                if (parseInt(xml.list.length % 5) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 5) * 45 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 5) + 1) * 45 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");

                LoadJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    if (type === "LB")
        PDLB(obj.innerHTML);
}
//判断类别
function PDLB(LB) {
    if (LB === "电视机") {
        $("#divDSXXCS").css("display", "");
        $("#divXYJXXCS").css("display", "none");
        $("#divKTXXCS").css("display", "none");
        $("#divBXXXCS").css("display", "none");
        $("#divBGXXCS").css("display", "none");
        BindClick("DSPMCC");
        BindClick("DSPP");
    }
    else if (LB === "洗衣机") {
        $("#divDSXXCS").css("display", "none");
        $("#divXYJXXCS").css("display", "");
        $("#divKTXXCS").css("display", "none");
        $("#divBXXXCS").css("display", "none");
        $("#divBGXXCS").css("display", "none");
        BindClick("XYJPP");
    }
    else if (LB === "空调") {
        $("#divDSXXCS").css("display", "none");
        $("#divXYJXXCS").css("display", "none");
        $("#divKTXXCS").css("display", "");
        $("#divBXXXCS").css("display", "none");
        $("#divBGXXCS").css("display", "none");
        BindClick("KTPP");
        BindClick("BPDS");
        BindClick("KTGL");
    }
    else if (LB === "冰箱") {
        $("#divDSXXCS").css("display", "none");
        $("#divXYJXXCS").css("display", "none");
        $("#divKTXXCS").css("display", "none");
        $("#divBXXXCS").css("display", "");
        $("#divBGXXCS").css("display", "none");
        BindClick("BXPP");
    }
    else if (LB === "冰柜") {
        $("#divDSXXCS").css("display", "none");
        $("#divXYJXXCS").css("display", "none");
        $("#divKTXXCS").css("display", "none");
        $("#divBXXXCS").css("display", "none");
        $("#divBGXXCS").css("display", "");
        BindClick("BGPP");
    }
    else {
        $("#divDSXXCS").css("display", "none");
        $("#divXYJXXCS").css("display", "none");
        $("#divKTXXCS").css("display", "none");
        $("#divBXXXCS").css("display", "none");
        $("#divBGXXCS").css("display", "none");
    }
}
//加载二手_家电家具办公_二手家电基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/ES/LoadES_JDJJBG_ESJDJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_JDJJBG_ESJDJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.ES_JDJJBG_ESJDJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                if (xml.Value.ES_JDJJBG_ESJDJBXX.SF !== null)
                    SetDX("SF", xml.Value.ES_JDJJBG_ESJDJBXX.SF);
                if (xml.Value.ES_JDJJBG_ESJDJBXX.PSFS !== null)
                    SetDuoX("PSFS", xml.Value.ES_JDJJBG_ESJDJBXX.PSFS);
                $("#spanLB").html(xml.Value.ES_JDJJBG_ESJDJBXX.LB);
                $("#spanXJ").html(xml.Value.ES_JDJJBG_ESJDJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_JDJJBG_ESJDJBXX.QY);
                $("#spanDD").html(xml.Value.ES_JDJJBG_ESJDJBXX.DD);
                $("#spanXL").html(xml.Value.ES_JDJJBG_ESJDJBXX.XL);
                $("#spanDSPP").html(xml.Value.ES_JDJJBG_ESJDJBXX.PP);
                $("#spanXYJPP").html(xml.Value.ES_JDJJBG_ESJDJBXX.PP);
                $("#spanKTPP").html(xml.Value.ES_JDJJBG_ESJDJBXX.PP);
                $("#spanBXPP").html(xml.Value.ES_JDJJBG_ESJDJBXX.PP);
                $("#spanBGPP").html(xml.Value.ES_JDJJBG_ESJDJBXX.PP);
                $("#spanDSPMCC").html(xml.Value.ES_JDJJBG_ESJDJBXX.DSPMCC);
                $("#spanBPDS").html(xml.Value.ES_JDJJBG_ESJDJBXX.KTBPDS);
                $("#spanKTGL").html(xml.Value.ES_JDJJBG_ESJDJBXX.KTGL);

                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_JDJJBG_ESJDJBXX.LB);
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
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "XJ", "'" + $("#spanXJ").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("SF") + "'");
    obj = jsonObj.AddJson(obj, "PSFS", "'" + GetDuoX("PSFS") + "'");

    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanDSPP").html() + "'");
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanXYJPP").html() + "'");
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanKTPP").html() + "'");
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanBXPP").html() + "'");
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanBGPP").html() + "'");
    obj = jsonObj.AddJson(obj, "DSPMCC", "'" + $("#spanDSPMCC").html() + "'");
    obj = jsonObj.AddJson(obj, "KTBPDS", "'" + $("#spanBPDS").html() + "'");
    obj = jsonObj.AddJson(obj, "KTGL", "'" + $("#spanKTGL").html() + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/ES/FBES_JDJJBG_ESJDJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            BCMS: ue.getContent(),
            FWZP: GetPhotoUrls()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.location.href = getRootPath() + "/FBCG/FBCG?LBID=" + getUrlParam("CLICKID") + "&ID=" + xml.Value.ID + "&JCXXID=" + xml.Value.JCXXID;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
