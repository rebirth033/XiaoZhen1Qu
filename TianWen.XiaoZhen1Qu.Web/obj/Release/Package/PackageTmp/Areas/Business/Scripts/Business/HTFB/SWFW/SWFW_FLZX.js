$(document).ready(function () {
    $("#div_ly_ls").bind("click", LSSelect);
    $("#div_ly_lssws").bind("click", LSSWSSelect);
    LoadFLZXLB();
});
//选择律师
function LSSelect() {
    $("#divZYZH").css("display", "");
    $("#divZYJG").css("display", "");
}
//选择律师事务所
function LSSWSSelect() {
    $("#divZYZH").css("display", "none");
    $("#divZYJG").css("display", "none");
}
//加载法律咨询类别
function LoadFLZXLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "法律咨询类别",
            TBName: "CODES_SWFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liFLZXLB' style='width:140px;' onclick='SelectDuoX(this)'><img class='img_FLZXLB'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 4 === 3) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 183px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divFLZXLB").css("height", parseInt(xml.list.length / 4) * 50 + "px");
                else
                    $("#divFLZXLB").css("height", (parseInt(xml.list.length / 4) + 1) * 50 + "px");
                html += "</ul>";
                $("#divFLZXLBText").html(html);
                $(".img_FLZXLB").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liFLZXLB").bind("click", function () { ValidateCheck("FLZXLB", "忘记选择类别啦"); });
                LoadJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载商务服务_法律咨询基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW/LoadSWFW_FLZXJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SWFW_FLZXJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.SWFW_FLZXJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                SetDuoX("FLZXLB", xml.Value.SWFW_FLZXJBXX.LB);
                SetDX("LY", xml.Value.SWFW_FLZXJBXX.LY);
                $("#spanQY").html(xml.Value.SWFW_FLZXJBXX.QY);
                $("#spanDD").html(xml.Value.SWFW_FLZXJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDuoX("FLZXLB") + "'");
    obj = jsonObj.AddJson(obj, "LY", "'" + GetDX("LY") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW/FBSWFW_FLZXJBXX",
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