$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadLR_MTSSJBXX();
    BindClick("LB");
});
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    if (type === "LB")
        PDLB(obj.innerHTML);
}
//判断类别
function PDLB(LB) {
    if (LB === "减肥") {
        $("#divJFFS").css("display", "");
        BindClick("FS");
    } else {
        $("#divJFFS").css("display", "none");
    }
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("美体瘦身", "LB", "CODES_LR", Bind, "MTSSLB", "LB", "");
        }
        if (type === "FS") {
            LoadCODESByTYPENAME("减肥方式", "FS", "CODES_LR", Bind, "JFFS", "FS", "");
        }
        
    });
}
//加载丽人_美体瘦身基本信息
function LoadLR_MTSSJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LR/LoadLR_MTSSJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.LR_MTSSJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.LR_MTSSJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.LR_MTSSJBXX.LB);
                $("#spanFS").html(xml.Value.LR_MTSSJBXX.FS);
                $("#spanQY").html(xml.Value.LR_MTSSJBXX.QY);
                $("#spanDD").html(xml.Value.LR_MTSSJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "FS", "'" + $("#spanFS").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LR/FBLR_MTSSJBXX",
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