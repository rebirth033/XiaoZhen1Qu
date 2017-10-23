
$(document).ready(function () {
    
    
    
    $("body").bind("click", function () { Close("_XZQ");});




    
    LoadES_WHYL_WTHWYQJBXX();
    BindClick("LB");
    BindClick("XJ");
    BindClick("QY");
    BindClick("DD");
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("文体/户外/乐器", "LB", "CODES_ES_WHYL");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_WHYL");
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM");
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
    PDLB(obj.innerHTML);
}
//判断类别
function PDLB(LB) {
    BindClick("XL");
}
//选择文体/户外/乐器品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载二手_手机数码_文体/户外/乐器基本信息
function LoadES_WHYL_WTHWYQJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_WHYL_WTHWYQ/LoadES_WHYL_WTHWYQJBXX",
        dataType: "json",
        data:
        {
            ES_WHYL_WTHWYQJBXXID: getUrlParam("ES_WHYL_WTHWYQJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_WHYL_WTHWYQJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_WHYL_WTHWYQJBXXID").val(xml.Value.ES_WHYL_WTHWYQJBXX.ES_WHYL_WTHWYQJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.ES_SJSM_PBDNJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_SJSM_PBDNJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_WHYL_WTHWYQJBXX.LB);
                $("#spanXJ").html(xml.Value.ES_WHYL_WTHWYQJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_WHYL_WTHWYQJBXX.QY);
                $("#spanSQ").html(xml.Value.ES_WHYL_WTHWYQJBXX.DD);

                $("#spanDSPMCC").html(xml.Value.ES_WHYL_WTHWYQJBXX.DSPMCC);
                $("#spanDSPP").html(xml.Value.ES_WHYL_WTHWYQJBXX.DSPP);
                $("#spanXYJPP").html(xml.Value.ES_WHYL_WTHWYQJBXX.XYJPP);
                $("#spanKTPP").html(xml.Value.ES_WHYL_WTHWYQJBXX.KTPP);
                $("#spanKTBPDS").html(xml.Value.ES_WHYL_WTHWYQJBXX.KTBPDS);
                $("#spanKTGL").html(xml.Value.ES_WHYL_WTHWYQJBXX.KTGL);
                $("#spanBXPP").html(xml.Value.ES_WHYL_WTHWYQJBXX.BXPP);
                $("#spanBGPP").html(xml.Value.ES_WHYL_WTHWYQJBXX.BGPP);

                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_WHYL_WTHWYQJBXX.LB);
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
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanSQ").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    obj = jsonObj.AddJson(obj, "DSPMCC", "'" + $("#spanDSPMCC").html() + "'");
    obj = jsonObj.AddJson(obj, "DSPP", "'" + $("#spanDSPP").html() + "'");
    obj = jsonObj.AddJson(obj, "XYJPP", "'" + $("#spanXYJPP").html() + "'");
    obj = jsonObj.AddJson(obj, "KTPP", "'" + $("#spanKTPP").html() + "'");
    obj = jsonObj.AddJson(obj, "KTBPDS", "'" + $("#spanKTBPDS").html() + "'");
    obj = jsonObj.AddJson(obj, "KTGL", "'" + $("#spanKTGL").html() + "'");
    obj = jsonObj.AddJson(obj, "BXPP", "'" + $("#spanBXPP").html() + "'");
    obj = jsonObj.AddJson(obj, "BGPP", "'" + $("#spanBGPP").html() + "'");

    if (getUrlParam("ES_WHYL_WTHWYQJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_WHYL_WTHWYQJBXXID", "'" + getUrlParam("ES_WHYL_WTHWYQJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_WHYL_WTHWYQ/FB",
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
