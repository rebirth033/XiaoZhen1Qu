﻿$(document).ready(function () {
    LoadDuoX("配送方式", "PSFS", "CODES_ES_SJSM");
    BindClick("LB");
    BindClick("XL");
    BindClick("XJ");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("图书/音像/软件类别", "LB", "CODES_ES_WHYL", Bind, "TSYXRJLB", "LB", "");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_WHYL", Bind, "TSYXRJLB", "XL", "");
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM", Bind, "XJCD", "XJ", "");
        }
    });
}
//选择类别下拉框
function SelectLB(obj, type, id) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    if(type === "LB") HasXL(id);
}
//选择图书/音像/软件品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//判断是否有小类
function HasXL(codeid){
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: codeid,
            TBName: "CODES_ES_MYFZMR"
        },
        success: function (xml) {
            if (xml.Result === 1) {
		if(xml.list.length>0){
		    $("#divXLText").css("display", "inline-block");
		    $("#spanXL").html("请选择小类");
		}
		else{
		    $("#divXLText").css("display", "none");
		}
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载二手_手机数码_图书/音像/软件基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/ES/LoadES_WHYL_TSYXRJJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_WHYL_TSYXRJJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.ES_WHYL_TSYXRJJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                if (xml.Value.ES_WHYL_TSYXRJJBXX.SF !== null)
                    SetDX("SF", xml.Value.ES_WHYL_TSYXRJJBXX.SF);
                if (xml.Value.ES_WHYL_TSYXRJJBXX.PSFS !== null)
                    SetDuoX("PSFS", xml.Value.ES_WHYL_TSYXRJJBXX.PSFS);
                $("#spanLB").html(xml.Value.ES_WHYL_TSYXRJJBXX.LB);
                $("#spanXL").html(xml.Value.ES_WHYL_TSYXRJJBXX.XL);
                $("#spanXJ").html(xml.Value.ES_WHYL_TSYXRJJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_WHYL_TSYXRJJBXX.QY);
                $("#spanDD").html(xml.Value.ES_WHYL_TSYXRJJBXX.DD);

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
        url: getRootPath() + "/ES/FBES_WHYL_TSYXRJJBXX",
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
