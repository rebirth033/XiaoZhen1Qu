
$(document).ready(function () {
    
    
    
    $("body").bind("click", function () { Close("_XZQ"); Close("LB"); Close("XL");Close("XJ"); Close("QY"); Close("DD"); });




    
    LoadES_QTES_ESSBJBXX();
    BindClick("LB");
    BindClick("XJ");
    BindClick("QY");
    BindClick("DD");

});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("二手设备", "LB", "CODES_ES_QTES");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_QTES");
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
function SelectLB(obj, type, lbcode) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    PDLB(obj.innerHTML);
    $("#LBCode").val(obj.innerHTML);
}
//判断类别
function PDLB(LB) {
    BindClick("XL");
}
//选择二手设备品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载二手_手机数码_二手设备基本信息
function LoadES_QTES_ESSBJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_QTES_ESSB/LoadES_QTES_ESSBJBXX",
        dataType: "json",
        data:
        {
            ES_QTES_ESSBJBXXID: getUrlParam("ES_QTES_ESSBJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_QTES_ESSBJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_QTES_ESSBJBXXID").val(xml.Value.ES_QTES_ESSBJBXX.ES_QTES_ESSBJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.ES_SJSM_PBDNJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_SJSM_PBDNJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_QTES_ESSBJBXX.LB);
                $("#spanXJ").html(xml.Value.ES_QTES_ESSBJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_QTES_ESSBJBXX.QY);
                $("#spanSQ").html(xml.Value.ES_QTES_ESSBJBXX.DD);

                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_QTES_ESSBJBXX.LB);
                $("#spanXL").html(xml.Value.ES_QTES_ESSBJBXX.XL);
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
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if (getUrlParam("ES_QTES_ESSBJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_QTES_ESSBJBXXID", "'" + getUrlParam("ES_QTES_ESSBJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_QTES_ESSB/FB",
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
