$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    BindClick("JXKM");
    BindClick("BYYX");
    BindClick("QY");
    BindClick("DD");
    LoadJYPX_YSPXJSJBXX();
});
//加载毕业院校标签
function LoadBYYX() {
    var arrayObj = new Array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    var html = "";
    for (var i = 0; i < arrayObj.length; i++) {
        html += '<div class="div_bqss_content_bq" id="div' + arrayObj[i] + '"><span class="span_bqss_content_bq" id="span' + arrayObj[i] + '">' + arrayObj[i] + '</span><em class="em_bqss_content_bq" id="em' + arrayObj[i] + '"></em></div>';
    }
    $("#div_bqss_body_bq").html(html);
    $(".div_bqss_content_bq").bind("click", JCBQActive);
}
//毕业院校标签切换
function JCBQActive() {
    LoadBYYXMC("学校", this.id);
}
//加载毕业院校名称
function LoadBYYXMC(JCLX, JCBQ) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByCodeValueAndTypeName",
        dataType: "json",
        data:
        {
            CODEVALUE: JCBQ.split("div")[1],
            TYPENAME: "学校",
            TBName: "CODES_JYPX_XX"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_mc" onclick="BYYXXZ(\'' + xml.list[i].CODENAME + '\',\'' + xml.list[i].CODEID + '\')">' + xml.list[i].CODENAME + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_mc" style=\"width:200px;text-align:left;margin-left:14px;\">该字母下暂无数据</span>';
                $("#div_bqss_body_mc").html(html);
                $("#divBYYX").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择毕业院校名称
function BYYXXZ(BYYXMC, BYYXID) {
    $("#spanBYYX").html(BYYXMC);
    $("#divBYYX").css("display", "none");
    ValidateSelect("YSPXJSBYYX", "BYYX", "忘记选择毕业院校啦");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "JXKM") {
            LoadCODESByTYPENAME("艺术培训", "JXKM", "CODES_JYPX", Bind, "YSPXJSJXKM", "JXKM", "");
        }
        if (type === "BYYX") {
            LoadBYYX();
            LoadBYYXMC("毕业院校", "divA");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
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
            TBName: "CODES_JYPX"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 4 === 3) {
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
                if (xml.list.length === 0)
                    $("#div" + id).css("display", "none");
                else
                    $("#div" + id).css("display", "");
                if (type === "辅导科目")
                    LoadJYPX_YSPXJSJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载商务服务_艺术培训教师基本信息
function LoadJYPX_YSPXJSJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/JYPX/LoadJYPX_YSPXJSJBXX",
        dataType: "json",
        data:
        {
            JYPX_YSPXJSJBXXID: getUrlParam("JYPX_YSPXJSJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JYPX_YSPXJSJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#JYPX_YSPXJSJBXXID").val(xml.Value.JYPX_YSPXJSJBXX.JYPX_YSPXJSJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanJXKM").html(xml.Value.JYPX_YSPXJSJBXX.JXKM);
                $("#spanBYYX").html(xml.Value.JYPX_YSPXJSJBXX.BYYX);
                $("#spanQY").html(xml.Value.JYPX_YSPXJSJBXX.QY);
                $("#spanDD").html(xml.Value.JYPX_YSPXJSJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                SetDX("SF", xml.Value.JYPX_YSPXJSJBXX.SF);
                SetDX("JJJY", xml.Value.JYPX_YSPXJSJBXX.JJJY);
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
    obj = jsonObj.AddJson(obj, "JXKM", "'" + $("#spanJXKM").html() + "'");
    obj = jsonObj.AddJson(obj, "BYYX", "'" + $("#spanBYYX").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("SF") + "'");
    obj = jsonObj.AddJson(obj, "JJJY", "'" + GetDX("JJJY") + "'");

    if (getUrlParam("JYPX_YSPXJSJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "JYPX_YSPXJSJBXXID", "'" + getUrlParam("JYPX_YSPXJSJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/JYPX/FBJYPX_YSPXJSJBXX",
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