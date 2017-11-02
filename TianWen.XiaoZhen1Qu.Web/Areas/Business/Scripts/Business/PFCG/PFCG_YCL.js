$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadPFCG_YCLJBXX();
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
});
//加载小类
function LoadXL() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: $("#LBID").val(),
            TBName: "CODES_PFCG"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ul_select' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectDropdown(this,\"XL\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divXL").html(html);
                $("#divXL").css("display", "block");
                Bind("OUTLB", "XL", "");
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
    $("#LBID").val(id);
    BindClick("XL");
    if (obj.innerHTML === "冶金" || obj.innerHTML === "橡胶制品") {
        $("#spanXL").html("请选择小类");
        $("#divXLText").css("display", "");
    } else {
        $("#divXLText").css("display", "none");
    }
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("原材料", "LB", "CODES_PFCG", Bind, "OUTLB", "LB", "");
        }
        if (type === "XL") {
            LoadXL();
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载批发采购_原材料基本信息
function LoadPFCG_YCLJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PFCG/LoadPFCG_YCLJBXX",
        dataType: "json",
        data:
        {
            PFCG_YCLJBXXID: getUrlParam("PFCG_YCLJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.PFCG_YCLJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#PFCG_YCLJBXXID").val(xml.Value.PFCG_YCLJBXX.PFCG_YCLJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.PFCG_YCLJBXX.LB);
                if (xml.Value.PFCG_YCLJBXX.LB === "冶金" || xml.Value.PFCG_YCLJBXX.LB === "橡胶制品") {
                    $("#spanXL").html("请选择小类");
                    $("#divXLText").css("display", "");
                } else {
                    $("#divXLText").css("display", "none");
                }
                $("#spanXL").html(xml.Value.PFCG_YCLJBXX.XL);
                $("#spanQY").html(xml.Value.PFCG_YCLJBXX.QY);
                $("#spanDD").html(xml.Value.PFCG_YCLJBXX.DD);
                LoadPhotos(xml.Value.Photos);
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
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("PFCG_YCLJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "PFCG_YCLJBXXID", "'" + getUrlParam("PFCG_YCLJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PFCG/FBPFCG_YCLJBXX",
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