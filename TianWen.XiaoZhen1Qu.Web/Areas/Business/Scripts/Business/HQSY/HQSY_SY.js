
$(document).ready(function () {$("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });BindClick("CYSJ");
    BindClick("QY");
    BindClick("DD");
    LoadHQSY_SYJBXX();
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "CYSJ") {
            LoadCODESByTYPENAME("从业时间", "CYSJ", "CODES_HQSY");
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
//选择类别下拉框
function SelectLB(obj, type, lbid) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#LBID").val(lbid);
}
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: type,
            TBName: "CODES_HQSY"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 3 || i === 7 || i === 11) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 4) * 45 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 4) + 1) * 45 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadHQSY_SYJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载婚庆摄影_司仪基本信息
function LoadHQSY_SYJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY_SY/LoadHQSY_SYJBXX",
        dataType: "json",
        data:
        {
            HQSY_SYJBXXID: getUrlParam("HQSY_SYJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.HQSY_SYJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#HQSY_SYJBXXID").val(xml.Value.HQSY_SYJBXX.HQSY_SYJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanCYSJ").html(xml.Value.HQSY_SYJBXX.CYSJ);
                $("#spanQY").html(xml.Value.HQSY_SYJBXX.QY);
                $("#spanDD").html(xml.Value.HQSY_SYJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.HQSY_SYJBXX.SYXB !== null)
                    SetDX("SYXB", xml.Value.HQSY_SYJBXX.SYXB);
                if (xml.Value.HQSY_SYJBXX.ZCFG !== null)
                    SetDX("ZCFG", xml.Value.HQSY_SYJBXX.ZCFG);
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
    obj = jsonObj.AddJson(obj, "CYSJ", "'" + $("#spanCYSJ").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "SYXB", "'" + GetDX("SYXB") + "'");
    obj = jsonObj.AddJson(obj, "ZCFG", "'" + GetDX("ZCFG") + "'");

    if (getUrlParam("HQSY_SYJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "HQSY_SYJBXXID", "'" + getUrlParam("HQSY_SYJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/HQSY_SY/FB",
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