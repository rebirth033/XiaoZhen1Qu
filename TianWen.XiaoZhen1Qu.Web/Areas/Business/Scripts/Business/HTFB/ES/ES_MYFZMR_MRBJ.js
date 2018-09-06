$(document).ready(function () {
    LoadDuoX("配送方式", "PSFS", "CODES_ES_SJSM");
    BindClick("LB");
    BindClick("XL");
    BindClick("XJ");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("美容/保健类别", "LB", "CODES_ES_MYFZMR", Bind, "MRBJLB", "LB", "");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_MYFZMR", Bind, "MRBJLB", "XL", "");
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
//加载二手_手机数码_母婴/服装/美容基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/ES/LoadES_MYFZMR_MRBJJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_MYFZMR_MRBJJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.ES_MYFZMR_MRBJJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                if (xml.Value.ES_MYFZMR_MRBJJBXX.SF !== null)
                    SetDX("SF", xml.Value.ES_MYFZMR_MRBJJBXX.SF);
                if (xml.Value.ES_MYFZMR_MRBJJBXX.PSFS !== null)
                    SetDuoX("PSFS", xml.Value.ES_MYFZMR_MRBJJBXX.PSFS);
                $("#spanLB").html(xml.Value.ES_MYFZMR_MRBJJBXX.LB);
                $("#spanXL").html(xml.Value.ES_MYFZMR_MRBJJBXX.XL);
                $("#spanXJ").html(xml.Value.ES_MYFZMR_MRBJJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_MYFZMR_MRBJJBXX.QY);
                $("#spanDD").html(xml.Value.ES_MYFZMR_MRBJJBXX.DD);

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
        url: getRootPath() + "/ES/FBES_MYFZMR_MRBJJBXX",
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
