$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadPFCG_TSJBXX();
    BindClick("QY");
    BindClick("DD");
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载批发采购_图书基本信息
function LoadPFCG_TSJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PFCG_TS/LoadPFCG_TSJBXX",
        dataType: "json",
        data:
        {
            PFCG_TSJBXXID: getUrlParam("PFCG_TSJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.PFCG_TSJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#PFCG_TSJBXXID").val(xml.Value.PFCG_TSJBXX.PFCG_TSJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanQY").html(xml.Value.PFCG_TSJBXX.QY);
                $("#spanDD").html(xml.Value.PFCG_TSJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("PFCG_TSJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "PFCG_TSJBXXID", "'" + getUrlParam("PFCG_TSJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PFCG_TS/FB",
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