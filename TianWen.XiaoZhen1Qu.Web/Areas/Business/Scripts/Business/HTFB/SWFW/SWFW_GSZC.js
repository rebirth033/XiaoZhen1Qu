$(document).ready(function () {
    LoadGSZCLB();
});
//加载工商注册类别
function LoadGSZCLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "工商注册类别",
            TBName: "CODES_SWFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liGSZCLB' style='width:140px;' onclick='SelectDuoX(this)'><img class='img_GSZCLB'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 3 || i === 7 || i === 11 || i === 15 || i === 19) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 183px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divGSZCLB").css("height", parseInt(xml.list.length / 4) * 50 + "px");
                else
                    $("#divGSZCLB").css("height", (parseInt(xml.list.length / 4) + 1) * 50 + "px");
                html += "</ul>";
                $("#divGSZCLBText").html(html);
                $(".img_GSZCLB").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liGSZCLB").bind("click", function () { ValidateCheck("GSZCLB", "忘记选择类别啦"); });
                LoadFWFW();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载商务服务_工商注册基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW/LoadSWFW_GSZCJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SWFW_GSZCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.SWFW_GSZCJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                SetDuoX("GSZCLB", xml.Value.SWFW_GSZCJBXX.LB);
                if (xml.Value.SWFW_GSZCJBXX.FWFW !== null)
                    SetDuoX("FWFW", xml.Value.SWFW_GSZCJBXX.FWFW);
                $("#spanQY").html(xml.Value.SWFW_GSZCJBXX.QY);
                $("#spanDD").html(xml.Value.SWFW_GSZCJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDuoX("GSZCLB") + "'");
    obj = jsonObj.AddJson(obj, "FWFW", "'" + GetDuoX("FWFW") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW/FBSWFW_GSZCJBXX",
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