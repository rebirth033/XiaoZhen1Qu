$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ");});
    LoadES_WHYL_YSPSCPJBXX();
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
});
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("艺术品/收藏品", "LB", "CODES_ES_WHYL", Bind, "YSPSCPLB", "LB", "");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_WHYL", Bind, "YSPSCPLB", "XL", "");
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM", Bind, "XJCD", "XJ", "");
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
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    BindClick("XL");
}
//选择艺术品/收藏品品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载二手_文化娱乐_艺术品/收藏品基本信息
function LoadES_WHYL_YSPSCPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_WHYL_YSPSCP/LoadES_WHYL_YSPSCPJBXX",
        dataType: "json",
        data:
        {
            ES_WHYL_YSPSCPJBXXID: getUrlParam("ES_WHYL_YSPSCPJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_WHYL_YSPSCPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_WHYL_YSPSCPJBXXID").val(xml.Value.ES_WHYL_YSPSCPJBXX.ES_WHYL_YSPSCPJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.ES_WHYL_YSPSCPJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_WHYL_YSPSCPJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_WHYL_YSPSCPJBXX.LB);
                $("#spanQY").html(xml.Value.ES_WHYL_YSPSCPJBXX.QY);
                $("#spanDD").html(xml.Value.ES_WHYL_YSPSCPJBXX.DD);
                $("#spanXL").html(xml.Value.ES_WHYL_YSPSCPJBXX.XL);
                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_WHYL_YSPSCPJBXX.LB);
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
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if (getUrlParam("ES_WHYL_YSPSCPJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_WHYL_YSPSCPJBXXID", "'" + getUrlParam("ES_WHYL_YSPSCPJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_WHYL_YSPSCP/FB",
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
