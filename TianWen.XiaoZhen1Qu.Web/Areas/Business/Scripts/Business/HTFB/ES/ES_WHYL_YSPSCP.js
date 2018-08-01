$(document).ready(function () {
    LoadDuoX("配送方式", "PSFS", "CODES_ES_SJSM");
    BindClick("LB");
    BindClick("XL");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("艺术品/收藏品类别", "LB", "CODES_ES_WHYL", Bind, "YSPSCPLB", "LB", "");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_WHYL", Bind, "YSPSCPLB", "XL", "");
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM", Bind, "XJCD", "XJ", "");
        }
    });
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
}
//选择艺术品/收藏品品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载二手_文化娱乐_艺术品/收藏品基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/ES/LoadES_WHYL_YSPSCPJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_WHYL_YSPSCPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.ES_WHYL_YSPSCPJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                if (xml.Value.ES_WHYL_YSPSCPJBXX.SF !== null)
                    SetDX("SF", xml.Value.ES_WHYL_YSPSCPJBXX.SF);
                if (xml.Value.ES_WHYL_YSPSCPJBXX.PSFS !== null)
                    SetDuoX("PSFS", xml.Value.ES_WHYL_YSPSCPJBXX.PSFS);
                $("#spanLB").html(xml.Value.ES_WHYL_YSPSCPJBXX.LB);
                $("#spanQY").html(xml.Value.ES_WHYL_YSPSCPJBXX.QY);
                $("#spanDD").html(xml.Value.ES_WHYL_YSPSCPJBXX.DD);
                $("#spanXL").html(xml.Value.ES_WHYL_YSPSCPJBXX.XL);
                LoadPhotos(xml.Value.Photos);
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
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("SF") + "'");
    obj = jsonObj.AddJson(obj, "PSFS", "'" + GetDuoX("PSFS") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/ES/FBES_WHYL_YSPSCPJBXX",
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
