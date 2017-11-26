var xlts = UE.getEditor('XLTS');
var xcap = UE.getEditor('XCAP');
var ydxz = UE.getEditor('YDXZ');
var fybh = UE.getEditor('FYBH');
var zfxm = UE.getEditor('ZFXM');
$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    BindClick("CYFS");
    BindClick("WFJT_Q");
    BindClick("WFJT_H");
    BindClick("XCTS_R");
    BindClick("XCTS_W");
    LoadLYJD_CJYJBXX();
    BCMSSetDefault();
});
//描述框设默认文本
function BCMSSetDefault() {
    //var xcap = '<span style="color: gray;font-size:12px;">请详细描述游玩的行程安排，包含住宿、用餐、游玩景点、费用说明、注意事项等，认真填写游玩描述会达到双倍的效果</span>';
    //$("#XCAP").html(xcap);
}
//加载默认
function LoadDefault() {
    xlts.ready(function () { xlts.setHeight(200); });
    xcap.ready(function () { xcap.setHeight(200); });
    ydxz.ready(function () { ydxz.setHeight(200); });
    fybh.ready(function () { fybh.setHeight(200); });
    zfxm.ready(function () { zfxm.setHeight(200); });
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "CYFS") {
            LoadCODESByTYPENAME("出游方式", "CYFS", "CODES_LYJD", Bind, "CJYCYFS", "CYFS", "");
        }
        if (type === "WFJT_Q") {
            LoadCODESByTYPENAME("往返交通_去", "WFJT_Q", "CODES_LYJD", Bind, "WFJT", "WFJT_Q", "");
        }
        if (type === "WFJT_H") {
            LoadCODESByTYPENAME("往返交通_回", "WFJT_H", "CODES_LYJD", Bind, "WFJT", "WFJT_H", "");
        }
        if (type === "XCTS_R") {
            LoadCODESByTYPENAME("行程安排_日", "XCTS_R", "CODES_LYJD", Bind, "XCTS", "XCTS_R", "");
        }
        if (type === "XCTS_W") {
            LoadCODESByTYPENAME("行程安排_晚", "XCTS_W", "CODES_LYJD", Bind, "XCTS", "XCTS_W", "");
        }
    });
}
//加载旅游酒店_出境游基本信息
function LoadLYJD_CJYJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LYJD/LoadLYJD_CJYJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.LYJD_CJYJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.LYJD_CJYJBXX.ID);
                //设置编辑器的内容
                xlts.ready(function () { xlts.setContent(xml.Value.XLTSString); });
                xcap.ready(function () { xcap.setContent(xml.Value.XCAPString); });
                ydxz.ready(function () { ydxz.setContent(xml.Value.YDXZString); });
                fybh.ready(function () { fybh.setContent(xml.Value.FYBHString); });
                zfxm.ready(function () { zfxm.setContent(xml.Value.ZFXMString); });

                $("#spanCYFS").html(xml.Value.LYJD_CJYJBXX.CYFS);
                $("#spanWFJT_Q").html(xml.Value.LYJD_CJYJBXX.WFJT_Q);
                $("#spanWFJT_H").html(xml.Value.LYJD_CJYJBXX.WFJT_H);
                $("#spanXCTS_R").html(xml.Value.LYJD_CJYJBXX.XCTS_R);
                $("#spanXCTS_W").html(xml.Value.LYJD_CJYJBXX.XCTS_W);
                $("#spanQY").html(xml.Value.LYJD_CJYJBXX.QY);
                $("#spanDD").html(xml.Value.LYJD_CJYJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.LYJD_CJYJBXX.FTRQ !== null)
                    SetDX("FTRQ", xml.Value.LYJD_CJYJBXX.FTRQ);
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
    obj = jsonObj.AddJson(obj, "CYFS", "'" + $("#spanCYFS").html() + "'");
    obj = jsonObj.AddJson(obj, "WFJT_Q", "'" + $("#spanWFJT_Q").html() + "'");
    obj = jsonObj.AddJson(obj, "WFJT_H", "'" + $("#spanWFJT_H").html() + "'");
    obj = jsonObj.AddJson(obj, "XCTS_R", "'" + $("#spanXCTS_R").html() + "'");
    obj = jsonObj.AddJson(obj, "XCTS_W", "'" + $("#spanXCTS_W").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "FTRQ", "'" + GetDX("FTRQ") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LYJD/FBLYJD_CJYJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            XLTS: xlts.getContent(),
            XCAP: xcap.getContent(),
            YDXZ: ydxz.getContent(),
            FYBH: fybh.getContent(),
            ZFXM: zfxm.getContent(),
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