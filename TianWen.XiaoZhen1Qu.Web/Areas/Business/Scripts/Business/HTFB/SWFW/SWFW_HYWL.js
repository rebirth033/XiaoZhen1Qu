$(document).ready(function () {

    LoadHYWLLB();
});
//加载货运物流类别
function LoadHYWLLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "货运物流类别",
            TBName: "CODES_SWFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liHYWLLB' onclick='SelectDuoX(this)'><img class='img_HYWLLB'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 4 === 3) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 183px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divHYWLLB").css("height", parseInt(xml.list.length / 4) * 60 + "px");
                else
                    $("#divHYWLLB").css("height", (parseInt(xml.list.length / 4) + 1) * 60 + "px");
                html += "</ul>";
                $("#divHYWLLBText").html(html);
                $(".img_HYWLLB").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liHYWLLB").bind("click", function () { ValidateCheck("HYWLLB", "忘记选择类别啦"); });
                LoadSWFW_HYWLJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {

    });
}
//加载商务服务_货运物流基本信息
function LoadSWFW_HYWLJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW/LoadSWFW_HYWLJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SWFW_HYWLJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.SWFW_HYWLJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                SetDuoX("HYWLLB", xml.Value.SWFW_HYWLJBXX.LB);
                $("#spanQY").html(xml.Value.SWFW_HYWLJBXX.QY);
                $("#spanDD").html(xml.Value.SWFW_HYWLJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDuoX("HYWLLB") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW/FBSWFW_HYWLJBXX",
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