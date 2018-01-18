$(document).ready(function () {
    LoadDuoX("申请学历", "SQXL");
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
                    if (i % 5 === 4) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 183px'>";
                    }
                }
                if (parseInt(xml.list.length % 5) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 5) * 50 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 5) + 1) * 50 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".li" + id).bind("click", function () { ValidateCheck(id, "忘记选择" + type + "啦"); });
                if (type === "申请学历")
                    LoadJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载商务服务_留学基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/JYPX/LoadJYPX_LXJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JYPX_LXJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.JYPX_LXJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () {ue.setContent(xml.Value.BCMSString);});
                SetXLBQ(xml.Value.JYPX_LXJBXX.GJ);
                $("#spanQY").html(xml.Value.JYPX_LXJBXX.QY);
                $("#spanDD").html(xml.Value.JYPX_LXJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.JYPX_LXJBXX.SQXL !== null)
                    SetDuoX("SQXL", xml.Value.JYPX_LXJBXX.SQXL);
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
    obj = jsonObj.AddJson(obj, "SQXL", "'" + GetDuoX("SQXL") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/JYPX/FBJYPX_LXJBXX",
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
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}