$(document).ready(function () {
    LoadCL_GCCJBXX();
    BindClick("CX");
    BindClick("CCNF");
    BindClick("CCYF");
    $("#divXLBQ").bind("click", function () { LoadXLBQ("CODES_CL", "工程车车型"); });
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "CCNF") {
            LoadCODESByTYPENAME("出厂年份", "CCNF", "CODES_CL", Bind, "GCCCCNF", "CCNF", "");
        }
        if (type === "CCYF") {
            LoadCODESByTYPENAME("出厂月份", "CCYF", "CODES_CL", Bind, "GCCCCNF", "CCYF", "");
        }
    });
}
//加载车辆_工程车基本信息
function LoadCL_GCCJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL/LoadCL_GCCJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_GCCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.CL_GCCJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                if (xml.Value.CL_GCCJBXX.LB !== null)
                    SetDX("GCCLB", xml.Value.CL_GCCJBXX.LB);
                $("#spanQY").html(xml.Value.CL_GCCJBXX.QY);
                $("#spanDD").html(xml.Value.CL_GCCJBXX.DD);
                $("#spanXL").html(xml.Value.CL_GCCJBXX.XL);
                $("#spanCX").html(xml.Value.CL_GCCJBXX.CX);
                $("#spanPP").html(xml.Value.CL_GCCJBXX.PP);
                $("#spanCCNF").html(xml.Value.CL_GCCJBXX.CCNF);
                $("#spanCCYF").html(xml.Value.CL_GCCJBXX.CCYF);
                LoadPhotos(xml.Value.Photos);
                PDCX(xml.Value.CL_GCCJBXX.CX);
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
    obj = jsonObj.AddJson(obj, "CX", "'" + $("#spanCX").html() + "'");
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanPP").html() + "'");
    obj = jsonObj.AddJson(obj, "CCNF", "'" + $("#spanCCNF").html() + "'");
    obj = jsonObj.AddJson(obj, "CCYF", "'" + $("#spanCCYF").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDX("GCCLB") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL/FBCL_GCCJBXX",
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
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}