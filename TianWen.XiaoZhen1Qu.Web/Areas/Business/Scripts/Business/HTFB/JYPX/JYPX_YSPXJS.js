$(document).ready(function () {
    BindClick("JXKM");
    $("#divXLBQ").bind("click", function () { LoadXLBQ("CODES_JYPX_XX", "学校"); });
    LoadJBXX();
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "JXKM") {
            LoadCODESByTYPENAME("艺术培训教学科目类别", "JXKM", "CODES_JYPX", Bind, "YSPXJSJXKM", "JXKM", "");
        }
    });
}
//选择小类标签
function SelectXLBQ(obj, codename) {
    if ($(obj).find("img").attr("src").indexOf("purple") !== -1) {
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
        $("#" + codename).remove();
    }
    else {
        if ($("#spanXLBQ").find(".div_XLBQ").length !== 1) {
            if ($("#spanXLBQ").html().indexOf("请选择") !== -1) $("#spanXLBQ").html('');
            $("#spanXLBQ").append('<div id="' + codename + '" class="div_XLBQ">' + codename + '</div>');
            $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_purple.png");
        }
        else
            alert("最多只选择1项");
    }
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
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 183px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 4) * 45 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 4) + 1) * 45 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                if (type === "辅导科目")
                    LoadJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载商务服务_艺术培训教师基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/JYPX/LoadJYPX_YSPXJSJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JYPX_YSPXJSJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.JYPX_YSPXJSJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanJXKM").html(xml.Value.JYPX_YSPXJSJBXX.JXKM);
                SetXLBQ(xml.Value.JYPX_YSPXJSJBXX.BYYX);
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
    obj = jsonObj.AddJson(obj, "BYYX", "'" + GetXLBQ() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("SF") + "'");
    obj = jsonObj.AddJson(obj, "JJJY", "'" + GetDX("JJJY") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

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
                window.location.href = getRootPath() + "/Business/FBCG/FBCG?LBID=" + getUrlParam("CLICKID") + "&ID=" + xml.Value.ID;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}