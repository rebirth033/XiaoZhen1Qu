$(document).ready(function () {
    BindClick("PSFG");
    BindClick("LX");
    BindClick("CZ");
    LoadFWFW();
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "PSFG") {
            LoadCODESByTYPENAME("婚纱摄影拍摄风格", "PSFG", "CODES_HQSY", Bind, "HSSYPSFG", "PSFG", "");
        }
    });
}
//选择类别下拉框
function SelectLB(obj, type, lbid) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#LBID").val(lbid);
}
//加载婚庆摄影_婚纱摄影基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY/LoadHQSY_HSSYJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.HQSY_HSSYJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.HQSY_HSSYJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanPSFG").html(xml.Value.HQSY_HSSYJBXX.PSFG);
                $("#spanQY").html(xml.Value.HQSY_HSSYJBXX.QY);
                $("#spanDD").html(xml.Value.HQSY_HSSYJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                SetDX("YLGZS", xml.Value.HQSY_HSSYJBXX.YLGZS);
                SetDX("PSDD", xml.Value.HQSY_HSSYJBXX.PSDD);
                SetDX("FWBZ", xml.Value.HQSY_HSSYJBXX.FWBZ);
                SetDX("FZSFFQ", xml.Value.HQSY_HSSYJBXX.FZSFFQ);
                SetDX("FZPSSF", xml.Value.HQSY_HSSYJBXX.FZPSSF);
                SetDX("TXNHZZX", xml.Value.HQSY_HSSYJBXX.TXNHZZX);
                SetDX("JXKPZS", xml.Value.HQSY_HSSYJBXX.JXKPZS);
                SetDX("DPZS", xml.Value.HQSY_HSSYJBXX.DPZS);
                SetDX("JPSF", xml.Value.HQSY_HSSYJBXX.JPSF);
                SetDX("JDSF", xml.Value.HQSY_HSSYJBXX.JDSF);
                SetDX("BHCY", xml.Value.HQSY_HSSYJBXX.BHCY);
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
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "PSFG", "'" + $("#spanPSFG").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "YLGZS", "'" + GetDX("YLGZS") + "'");
    obj = jsonObj.AddJson(obj, "PSDD", "'" + GetDX("PSDD") + "'");
    obj = jsonObj.AddJson(obj, "FWBZ", "'" + GetDX("FWBZ") + "'");
    obj = jsonObj.AddJson(obj, "FZSFFQ", "'" + GetDX("FZSFFQ") + "'");
    obj = jsonObj.AddJson(obj, "FZPSSF", "'" + GetDX("FZPSSF") + "'");
    obj = jsonObj.AddJson(obj, "TXNHZZX", "'" + GetDX("TXNHZZX") + "'");
    obj = jsonObj.AddJson(obj, "JXKPZS", "'" + GetDX("JXKPZS") + "'");
    obj = jsonObj.AddJson(obj, "DPZS", "'" + GetDX("DPZS") + "'");
    obj = jsonObj.AddJson(obj, "JPSF", "'" + GetDX("JPSF") + "'");
    obj = jsonObj.AddJson(obj, "JDSF", "'" + GetDX("JDSF") + "'");
    obj = jsonObj.AddJson(obj, "BHCY", "'" + GetDX("BHCY") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY/FBHQSY_HSSYJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            BCMS: ue.getContent(),
            FWZP: GetPhotoUrls()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.location.href = getRootPath() + "/Business/FBCG/FBCG?LBID=" + getUrlParam("CLICKID") + "&ID=" + xml.Value.ID + "&JCXXID=" + xml.Value.JCXXID;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}