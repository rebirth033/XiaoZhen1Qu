$(document).ready(function () {
    LoadDuoX("配送方式", "PSFS");
    BindClick("LB");
    BindClick("XL");
    BindClick("XJ");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("文体/户外/乐器类别", "LB", "CODES_ES_WHYL", Bind, "WTHWYQLB", "LB", "");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_WHYL", Bind, "WTHWYQLB", "XL", "");
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM", Bind, "XJCD", "XJ", "");
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
}
//选择文体/户外/乐器品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载二手_手机数码_文体/户外/乐器基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/ES/LoadES_WHYL_WTHWYQJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_WHYL_WTHWYQJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.ES_WHYL_WTHWYQJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                if (xml.Value.ES_WHYL_WTHWYQJBXX.SF !== null)
                    SetDX("SF", xml.Value.ES_WHYL_WTHWYQJBXX.SF);
                if (xml.Value.ES_WHYL_WTHWYQJBXX.PSFS !== null)
                    SetDuoX("PSFS", xml.Value.ES_WHYL_WTHWYQJBXX.PSFS);
                $("#spanLB").html(xml.Value.ES_WHYL_WTHWYQJBXX.LB);
                $("#spanXJ").html(xml.Value.ES_WHYL_WTHWYQJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_WHYL_WTHWYQJBXX.QY);
                $("#spanDD").html(xml.Value.ES_WHYL_WTHWYQJBXX.DD);

                $("#spanDSPMCC").html(xml.Value.ES_WHYL_WTHWYQJBXX.DSPMCC);
                $("#spanDSPP").html(xml.Value.ES_WHYL_WTHWYQJBXX.DSPP);
                $("#spanXYJPP").html(xml.Value.ES_WHYL_WTHWYQJBXX.XYJPP);
                $("#spanKTPP").html(xml.Value.ES_WHYL_WTHWYQJBXX.KTPP);
                $("#spanKTBPDS").html(xml.Value.ES_WHYL_WTHWYQJBXX.KTBPDS);
                $("#spanKTGL").html(xml.Value.ES_WHYL_WTHWYQJBXX.KTGL);
                $("#spanBXPP").html(xml.Value.ES_WHYL_WTHWYQJBXX.BXPP);
                $("#spanBGPP").html(xml.Value.ES_WHYL_WTHWYQJBXX.BGPP);

                LoadPhotos(xml.Value.Photos);
                $("#spanXL").html(xml.Value.ES_WHYL_WTHWYQJBXX.XL);
                return;
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

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/ES/FBES_WHYL_WTHWYQJBXX",
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
