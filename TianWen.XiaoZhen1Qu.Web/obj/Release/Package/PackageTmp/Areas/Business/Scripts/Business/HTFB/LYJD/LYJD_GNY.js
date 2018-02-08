var xcap = UE.getEditor('XCAP');
var fybh = UE.getEditor('FYBH');
var zfxm = UE.getEditor('ZFXM');
$(document).ready(function () {
    BindClick("CYFS");
    BindClick("WFJT_Q");
    BindClick("WFJT_H");
    BindClick("XCTS_R");
    BindClick("XCTS_W");
    LoadJBXX();
});
//加载默认
function LoadDefault() {
    xcap.ready(function () { xcap.setHeight(200); });
    fybh.ready(function () { fybh.setHeight(200); });
    zfxm.ready(function () { zfxm.setHeight(200); });
    if ($("#span_top_right_yhm_text").html() === "") {
        $(".div_shadow").css("display", "block");
        $(".div_body_yhdl").css("display", "block");
    }
}
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "CYFS") {
            LoadCODESByTYPENAME("出游方式", "CYFS", "CODES_LYJD", Bind, "GNYCYFS", "CYFS", "");
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
//加载旅游酒店_国内游基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LYJD/LoadLYJD_GNYJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.LYJD_GNYJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.LYJD_GNYJBXX.ID);
                //设置编辑器的内容
                fybh.ready(function () { fybh.setContent(xml.Value.FYBHString); });
                zfxm.ready(function () { zfxm.setContent(xml.Value.ZFXMString); });
                xcap.ready(function () { xcap.setContent(xml.Value.XCAPString); });

                $("#spanWFJT_Q").html(xml.Value.LYJD_GNYJBXX.WFJT_Q);
                $("#spanWFJT_H").html(xml.Value.LYJD_GNYJBXX.WFJT_H);
                $("#spanXCTS_R").html(xml.Value.LYJD_GNYJBXX.XCTS_R);
                $("#spanXCTS_W").html(xml.Value.LYJD_GNYJBXX.XCTS_W);
                $("#spanQY").html(xml.Value.LYJD_GNYJBXX.QY);
                $("#spanDD").html(xml.Value.LYJD_GNYJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.LYJD_GNYJBXX.CYLB !== null)
                    SetDX("CYLB", xml.Value.LYJD_GNYJBXX.CYLB);
                if (xml.Value.LYJD_GNYJBXX.CYFS !== null)
                    SetDX("CYFS", xml.Value.LYJD_GNYJBXX.CYFS);
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
    obj = jsonObj.AddJson(obj, "WFJT_Q", "'" + $("#spanWFJT_Q").html() + "'");
    obj = jsonObj.AddJson(obj, "WFJT_H", "'" + $("#spanWFJT_H").html() + "'");
    obj = jsonObj.AddJson(obj, "XCTS_R", "'" + $("#spanXCTS_R").html() + "'");
    obj = jsonObj.AddJson(obj, "XCTS_W", "'" + $("#spanXCTS_W").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "CYLB", "'" + GetDX("CYLB") + "'");
    obj = jsonObj.AddJson(obj, "CYFS", "'" + GetDX("CYFS") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LYJD/FBLYJD_GNYJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            FYBH: fybh.getContent(),
            XCAP: xcap.getContent(),
            ZFXM: zfxm.getContent(),
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