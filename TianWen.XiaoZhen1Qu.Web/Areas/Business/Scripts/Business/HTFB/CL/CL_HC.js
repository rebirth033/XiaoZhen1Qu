$(document).ready(function () {
    LoadCL_HCJBXX();
    BindClick("LB");
    $("#divXLBQ").bind("click", function () { LoadXLBQ("CODES_CL", "货车品牌"); });
    BindClick("CCNF");
    BindClick("CCYF");
    BindClick("GCSJ");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("货车车型", "LB", "CODES_CL", Bind, "HCLB", "LB", "");
        }
        if (type === "CX") {
            LoadCX();
        }
        if (type === "CCNF") {
            LoadCODESByTYPENAME("出厂年份", "CCNF", "CODES_CL", Bind, "HCCCNF", "CCNF", "");
        }
        if (type === "CCYF") {
            LoadCODESByTYPENAME("出厂月份", "CCYF", "CODES_CL", Bind, "HCCCYF", "CCYF", "");
        }
    });
}
//加载货车车系
function LoadCX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: $("#PPID").val(),
            TBName: "CODES_CL"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var height = 341;
                if (xml.list.length < 10)
                    height = parseInt(xml.list.length * 34) + 1;
                var html = "<ul class='ul_select' style='overflow-y: scroll; height:" + height + "px'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectDropdown(this,\"CX\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divCX").html(html);
                $("#divCX").css("display", "block");
                Bind("HCPP", "CX", "");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择货车品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载车辆_货车基本信息
function LoadCL_HCJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL/LoadCL_HCJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_HCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.CL_HCJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.CL_HCJBXX.LB);
                $("#spanXL").html(xml.Value.CL_HCJBXX.XL);
                $("#spanPP").html(xml.Value.CL_HCJBXX.PP);
                $("#spanCX").html(xml.Value.CL_HCJBXX.CX);
                $("#spanCCNF").html(xml.Value.CL_HCJBXX.CCNF);
                $("#spanCCYF").html(xml.Value.CL_HCJBXX.CCYF);
                $("#spanQY").html(xml.Value.CL_HCJBXX.QY);
                $("#spanDD").html(xml.Value.CL_HCJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanPP").html() + "'");
    obj = jsonObj.AddJson(obj, "CX", "'" + $("#spanCX").html() + "'");
    obj = jsonObj.AddJson(obj, "CCNF", "'" + $("#spanCCNF").html() + "'");
    obj = jsonObj.AddJson(obj, "CCYF", "'" + $("#spanCCYF").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL/FBCL_HCJBXX",
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
