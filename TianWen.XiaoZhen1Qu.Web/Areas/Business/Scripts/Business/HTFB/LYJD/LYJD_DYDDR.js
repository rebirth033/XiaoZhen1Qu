$(document).ready(function () {
    BindClick("XL");
    BindClick("DTJY");
    LoadDuoX("导游语种", "DYYZ");
});
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: type,
            TBName: "CODES_LYJD"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 5 === 4) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 173px'>";
                    }
                }
                if (parseInt(xml.list.length % 5) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 5) * 60 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 5) + 1) * 60 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".li" + id).bind("click", function () { ValidateCheck(id, "忘记选择" + type + "啦"); });
                if (xml.list.length === 0)
                    $("#div" + id).css("display", "none");
                else
                    $("#div" + id).css("display", "");
                if (type === "导游语种")
                    LoadFWFW();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "XL") {
            LoadCODESByTYPENAME("导游学历", "XL", "CODES_LYJD", Bind, "DYDDRXL", "XL", "");
        }
        if (type === "DTJY") {
            LoadCODESByTYPENAME("带团经验", "DTJY", "CODES_LYJD", Bind, "DYDDRDTJY", "DTJY", "");
        }
        if (type === "CYFS") {
            LoadCODESByTYPENAME("出游方式", "CYFS", "CODES_LYJD", Bind, "DYDDRCYFS", "CYFS", "");
        }
    });
}
//加载旅游酒店_导游/当地人基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/LYJD/LoadLYJD_DYDDRJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.LYJD_DYDDRJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.LYJD_DYDDRJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanXL").html(xml.Value.LYJD_DYDDRJBXX.XL);
                $("#spanDTJY").html(xml.Value.LYJD_DYDDRJBXX.DTJY);
                $("#spanQY").html(xml.Value.LYJD_DYDDRJBXX.QY);
                $("#spanDD").html(xml.Value.LYJD_DYDDRJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                SetDX("XB", xml.Value.LYJD_DYDDRJBXX.XB);
                SetDX("DYLX", xml.Value.LYJD_DYDDRJBXX.DYLX);
                SetDuoX("DYYZ", xml.Value.LYJD_DYDDRJBXX.DYYZ);
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
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "DTJY", "'" + $("#spanDTJY").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "XB", "'" + GetDX("XB") + "'");
    obj = jsonObj.AddJson(obj, "DYLX", "'" + GetDX("DYLX") + "'");
    obj = jsonObj.AddJson(obj, "DYYZ", "'" + GetDuoX("DYYZ") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/LYJD/FBLYJD_DYDDRJBXX",
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