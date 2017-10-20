var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    
    
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qhcs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("LB"); Close("XL"); Close("XJ"); Close("QY"); Close("DD"); });





    LoadDefault();
    LoadES_WHYL_WYXNWPJBXX();
    BindClick("LB");
    BindClick("XL");
    BindClick("XJ");
    BindClick("QY");
    BindClick("DD");

});
//加载游戏标签
function LoadYXBQ() {
    var arrayObj = new Array('RMYX', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    var html = "";
    for (var i = 0; i < arrayObj.length; i++) {
        if (i === 0)
            html += '<div class="div_bqss_content_bq" id="div' + arrayObj[i] + '" style="width:62px;"><span class="span_bqss_content_bq" id="span' + arrayObj[i] + '">' + "热门" + '</span><em class="em_bqss_content_bq" id="em' + arrayObj[i] + '"></em></div>';
        else
            html += '<div class="div_bqss_content_bq" id="div' + arrayObj[i] + '"><span class="span_bqss_content_bq" id="span' + arrayObj[i] + '">' + arrayObj[i] + '</span><em class="em_bqss_content_bq" id="em' + arrayObj[i] + '"></em></div>';
    }
    $("#div_bqss_body_bq").html(html);
    $(".div_bqss_content_bq").bind("mouseover", YXBQActive);
}
//游戏标签切换
function YXBQActive() {
    LoadYXMC(this.id);
}
//加载游戏名称
function LoadYXMC(SZM) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/YXCZ/LoadByCodeValueAndTypeName",
        dataType: "json",
        data:
        {
            CODEVALUE: SZM.split("div")[1],
            TYPENAME: "游戏",
            TBName: "CODES_ES_WHYL"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_mc" onclick="YXXZ(\'' + xml.list[i].YXMC + '\')">' + xml.list[i].YXMC + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_mc">该字母下暂无数据</span>';
                $("#div_bqss_body_mc").html(html);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择游戏名称
function YXXZ(YXMC) {
    $("#spanXL").html(YXMC);
    $("#divXL").css("display", "none");
}
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
        if (type === "LB") {
            LoadCODESByTYPENAME("网游/虚拟物品", "LB", "CODES_ES_WHYL");
        }
        if (type === "XL") {
            LoadYXBQ();
            LoadYXMC("divA");
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
}
//选择网游/虚拟物品品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载二手_手机数码_网游/虚拟物品基本信息
function LoadES_WHYL_WYXNWPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_WHYL_WYXNWP/LoadES_WHYL_WYXNWPJBXX",
        dataType: "json",
        data:
        {
            ES_WHYL_WYXNWPJBXXID: getUrlParam("ES_WHYL_WYXNWPJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_WHYL_WYXNWPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_WHYL_WYXNWPJBXXID").val(xml.Value.ES_WHYL_WYXNWPJBXX.ES_WHYL_WYXNWPJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.ES_SJSM_PBDNJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_SJSM_PBDNJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_WHYL_WYXNWPJBXX.LB);
                $("#spanXJ").html(xml.Value.ES_WHYL_WYXNWPJBXX.XJ);
                $("#spanXL").html(xml.Value.ES_WHYL_WYXNWPJBXX.XL);
                $("#spanQY").html(xml.Value.ES_WHYL_WYXNWPJBXX.JYQY);
                $("#spanSQ").html(xml.Value.ES_WHYL_WYXNWPJBXX.JYDD);
                $("#spanXL").html(xml.Value.ES_WHYL_WYXNWPJBXX.XL);
                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_WHYL_WYXNWPJBXX.LB);
                return;
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
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "XJ", "'" + $("#spanXJ").html() + "'");
    obj = jsonObj.AddJson(obj, "JYQY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "JYDD", "'" + $("#spanSQ").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if (getUrlParam("ES_WHYL_WYXNWPJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_WHYL_WYXNWPJBXXID", "'" + getUrlParam("ES_WHYL_WYXNWPJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_WHYL_WYXNWP/FB",
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
