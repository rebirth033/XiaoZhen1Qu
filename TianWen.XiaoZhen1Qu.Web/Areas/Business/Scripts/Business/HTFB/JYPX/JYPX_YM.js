$(document).ready(function () {
    LoadDuoX("移民类别", "YMLB");
    $("#divXLBQ").bind("click", function () { LoadXLBQ("CODES_JYPX", "留学国家"); });
});
//选择小类标签
function SelectXLBQ(obj, codename) {
    if ($(obj).find("img").attr("src").indexOf("purple") !== -1) {
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
        $("#" + codename).remove();
    }
    else {
        if ($("#spanXLBQ").find(".div_XLBQ").length !== 2) {
            if ($("#spanXLBQ").html().indexOf("请选择") !== -1) $("#spanXLBQ").html('');
            $("#spanXLBQ").append('<div id="' + codename + '" class="div_XLBQ">' + codename + '</div>');
            $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_purple.png");
        }
        else
            alert("最多只选择2项");
    }
}
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
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
                    if (i % 6 === 5 && i != xml.list.length - 1) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 173px'>";
                    }
                }
                if (parseInt(xml.list.length % 6) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 6) * 60 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 6) + 1) * 60 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".li" + id).bind("click", function () { ValidateCheck(id, "忘记选择" + type + "啦"); });
                if (type === "移民类别")
                    LoadJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载商务服务_移民基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/JYPX/LoadJYPX_YMJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JYPX_YMJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.JYPX_YMJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                SetXLBQ(xml.Value.JYPX_YMJBXX.GJ);
                $("#spanQY").html(xml.Value.JYPX_YMJBXX.QY);
                $("#spanDD").html(xml.Value.JYPX_YMJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.JYPX_YMJBXX.YMLB !== null)
                    SetDuoX("YMLB", xml.Value.JYPX_YMJBXX.YMLB);
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
    obj = jsonObj.AddJson(obj, "GJ", "'" + GetXLBQ() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "YMLB", "'" + GetDuoX("YMLB") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/JYPX/FBJYPX_YMJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            BCMS: ue.getContent(),
            FWZP: GetPhotoUrls()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.location.href = getRootPath() + "/FBCG/FBCG?LBID=" + getUrlParam("CLICKID") + "&ID=" + xml.Value.ID + "&JCXXID=" + xml.Value.JCXXID;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}