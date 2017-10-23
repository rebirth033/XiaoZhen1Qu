
$(document).ready(function () {
    
    
    $("body").bind("click", function () { Close("_XZQ");});
    
    LoadES_JDJJBG_BGSBJBXX();
    BindClick("LB");
    BindClick("XJ");
    BindClick("QY");
    BindClick("DD");
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("办公用品/设备", "LB", "CODES_ES_JDJJBG");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_JDJJBG");
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
    BindClick("XL");
}
//选择家居日用品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载二手_手机数码_家居日用基本信息
function LoadES_JDJJBG_BGSBJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_JDJJBG_BGSB/LoadES_JDJJBG_BGSBJBXX",
        dataType: "json",
        data:
        {
            ES_JDJJBG_BGSBJBXXID: getUrlParam("ES_JDJJBG_BGSBJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_JDJJBG_BGSBJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_JDJJBG_BGSBJBXXID").val(xml.Value.ES_JDJJBG_BGSBJBXX.ES_JDJJBG_BGSBJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.ES_SJSM_PBDNJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_SJSM_PBDNJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_JDJJBG_BGSBJBXX.LB);
                $("#spanXJ").html(xml.Value.ES_JDJJBG_BGSBJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_JDJJBG_BGSBJBXX.QY);
                $("#spanDD").html(xml.Value.ES_JDJJBG_BGSBJBXX.DD);
                $("#spanXL").html(xml.Value.ES_JDJJBG_BGSBJBXX.XL);
                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_JDJJBG_BGSBJBXX.LB);
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

    if (getUrlParam("ES_JDJJBG_BGSBJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_JDJJBG_BGSBJBXXID", "'" + getUrlParam("ES_JDJJBG_BGSBJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_JDJJBG_BGSB/FB",
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
