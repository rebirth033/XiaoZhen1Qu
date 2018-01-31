$(document).ready(function () {
    BindClick("CX");
    BindClick("DCDY");
    BindClick("DCRL");
    BindClick("XJ");
    LoadDuoX("电动车品牌", "PP");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "CX") {
            LoadCODESByTYPENAME("电动车车型", "CX", "CODES_CL", Bind, "DDCCX", "CX", "");
        }
        if (type === "DCDY") {
            LoadCODESByTYPENAME("电动车电池电压", "DCDY", "CODES_CL", Bind, "DDCDCDY", "DCDY", "");
        }
        if (type === "DCRL") {
            LoadCODESByTYPENAME("电动车电池容量", "DCRL", "CODES_CL", Bind, "DDCDCRL", "DCRL", "");
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM", Bind, "XJCD", "XJ", "");
        }
    });
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
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
            TBName: "CODES_CL"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' style='width:120px;' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 5 === 4 && i !== xml.list.length - 1) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 183px'>";
                    }
                }
                if (parseInt(xml.list.length % 5) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 5) * 45 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 5) + 1) * 45 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".li" + id).bind("click", function () { ValidateCheck(id, "忘记选择品牌啦"); });
                LoadJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载车辆_电动车基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL/LoadCL_DDCJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_DDCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.CL_DDCJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanCX").html(xml.Value.CL_DDCJBXX.CX);
                $("#spanXJ").html(xml.Value.CL_DDCJBXX.XJ);
                $("#spanQY").html(xml.Value.CL_DDCJBXX.QY);
                $("#spanDD").html(xml.Value.CL_DDCJBXX.DD);
                $("#spanDCDY").html(xml.Value.CL_DDCJBXX.DCDY);
                $("#spanDCRL").html(xml.Value.CL_DDCJBXX.DCRL);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.CL_DDCJBXX.SF !== null)
                    SetDX("SF", xml.Value.CL_DDCJBXX.SF);
                if (xml.Value.CL_DDCJBXX.PP !== null)
                    SetDuoX("PP", xml.Value.CL_DDCJBXX.PP);
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
    obj = jsonObj.AddJson(obj, "CX", "'" + $("#spanCX").html() + "'");
    obj = jsonObj.AddJson(obj, "PP", "'" + GetDuoX("PP") + "'");
    obj = jsonObj.AddJson(obj, "XJ", "'" + $("#spanXJ").html() + "'");
    obj = jsonObj.AddJson(obj, "DCDY", "'" + $("#spanDCDY").html() + "'");
    obj = jsonObj.AddJson(obj, "DCRL", "'" + $("#spanDCRL").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("SF") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL/FBCL_DDCJBXX",
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
