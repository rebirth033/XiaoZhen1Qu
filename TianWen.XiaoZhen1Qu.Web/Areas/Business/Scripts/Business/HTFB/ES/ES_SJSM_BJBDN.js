$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ");});
    LoadES_SJSM_BJBDNJBXX();

    BindClick("LB");
    BindClick("BJBPP");
    BindClick("XL");
    BindClick("BJBXH");
    BindClick("XJ");
    BindClick("QY");
    BindClick("SQ");
    BindClick("CPUPP");
    BindClick("CPUHS");
    BindClick("NC");
    BindClick("YP");
    BindClick("PMCC");
    BindClick("XK");
});
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("笔记本类别", "LB", "CODES_ES_SJSM", Bind, "BJBLB", "LB", "");
        }
        if (type === "BJBPP") {
            LoadCODESByTYPENAME("笔记本品牌", "BJBPP", "CODES_ES_SJSM", Bind, "BJBLB", "BJBPP", "");
        }
        if (type === "BJBXH") {
            LoadBJBXH();
        }
        if (type === "CPUPP") {
            LoadCODESByTYPENAME("CPU品牌", "CPUPP", "CODES_ES_SJSM");
        }
        if (type === "CPUHS") {
            LoadCODESByTYPENAME("CPU核数", "CPUHS", "CODES_ES_SJSM");
        }
        if (type === "NC") {
            LoadCODESByTYPENAME("内存", "NC", "CODES_ES_SJSM");
        }
        if (type === "YP") {
            LoadCODESByTYPENAME("硬盘", "YP", "CODES_ES_SJSM");
        }
        if (type === "PMCC") {
            LoadCODESByTYPENAME("屏幕尺寸", "PMCC", "CODES_ES_SJSM");
        }
        if (type === "XK") {
            LoadCODESByTYPENAME("显卡", "XK", "CODES_ES_SJSM");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME("笔记本配件", "XL", "CODES_ES_SJSM");
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM", Bind, "XJCD", "XJ", "");
        }
        
    });
}
//加载笔记本型号
function LoadBJBXH() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: $("#PPID").val(),
            TBName: "CODES_ES_SJSM"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var height = 341;
                if (xml.list.length < 10)
                    height = parseInt(xml.list.length * 34) + 1;
                var html = "<ul class='ul_select' style='overflow-y: scroll; height:" + height + "px;width:200px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectDropdown(this,\"BJBXH\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divBJBXH").html(html);
                $("#divBJBXH").css("display", "block");
                ActiveStyle("BJBXH");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择类别下拉框
function SelectLB(obj, type, id) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#PPID").val(id);
    PDLB(obj.innerHTML);
}
//判断类别
function PDLB(LB) {
    if (LB.indexOf("配件") !== -1) {
        $("#divXLText").css("display", "");
        $("#divBJBPPText").css("display", "none");
        $("#divBJBXHText").css("display", "none");
        $("#divBJBXXCS").css("display", "none");
        $("#divBJBXXCS_2").css("display", "none");
    } else {
        $("#divXLText").css("display", "none");
        $("#divBJBPPText").css("display", "");
        $("#divBJBXHText").css("display", "");
        $("#divBJBXXCS").css("display", "");
        $("#divBJBXXCS_2").css("display", "");
    }
}
//选择笔记本品牌
function SelectBJBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadBJBXH(code);
}
//加载二手_手机数码_二手手机基本信息
function LoadES_SJSM_BJBDNJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/LoadES_SJSM_BJBDNJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_SJSM_BJBDNJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.ES_SJSM_BJBDNJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.ES_SJSM_BJBDNJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_SJSM_BJBDNJBXX.GQ);
                $("#spanLB").html(xml.Value.ES_SJSM_BJBDNJBXX.LB);
                $("#spanBJBPP").html(xml.Value.ES_SJSM_BJBDNJBXX.BJBPP);
                $("#spanBJBXH").html(xml.Value.ES_SJSM_BJBDNJBXX.BJBXH);
                $("#spanXJ").html(xml.Value.ES_SJSM_BJBDNJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_SJSM_BJBDNJBXX.QY);
                $("#spanDD").html(xml.Value.ES_SJSM_BJBDNJBXX.DD);
                $("#spanXL").html(xml.Value.ES_SJSM_BJBDNJBXX.XL);

                $("#spanCPUPP").html(xml.Value.ES_SJSM_BJBDNJBXX.CPUPP);
                $("#spanCPUHS").html(xml.Value.ES_SJSM_BJBDNJBXX.CPUHS);
                $("#spanNC").html(xml.Value.ES_SJSM_BJBDNJBXX.NC);
                $("#spanYP").html(xml.Value.ES_SJSM_BJBDNJBXX.YP);
                $("#spanPMCC").html(xml.Value.ES_SJSM_BJBDNJBXX.PMCC);
                $("#spanXK").html(xml.Value.ES_SJSM_BJBDNJBXX.XK);

                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_SJSM_BJBDNJBXX.LB);
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
    obj = jsonObj.AddJson(obj, "BJBPP", "'" + $("#spanBJBPP").html() + "'");
    obj = jsonObj.AddJson(obj, "BJBXH", "'" + $("#spanBJBXH").html() + "'");
    obj = jsonObj.AddJson(obj, "XJ", "'" + $("#spanXJ").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    obj = jsonObj.AddJson(obj, "CPUPP", "'" + $("#spanCPUPP").html() + "'");
    obj = jsonObj.AddJson(obj, "CPUHS", "'" + $("#spanCPUHS").html() + "'");
    obj = jsonObj.AddJson(obj, "NC", "'" + $("#spanNC").html() + "'");
    obj = jsonObj.AddJson(obj, "YP", "'" + $("#spanYP").html() + "'");
    obj = jsonObj.AddJson(obj, "PMCC", "'" + $("#spanPMCC").html() + "'");
    obj = jsonObj.AddJson(obj, "XK", "'" + $("#spanXK").html() + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/FBES_SJSM_BJBDNJBXX",
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
