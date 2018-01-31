$(document).ready(function () {
    LoadDuoX("管道疏通/清理类别", "LB");
});
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: type,
            TBName: "CODES_SHFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' style='width:160px;' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 4 === 3 && i !== xml.list.length - 1) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 183px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 4) * 50 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 4) + 1) * 50 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".li" + id).bind("click", function () { ValidateCheck(id, "忘记选择类别啦"); });
                LoadFWFW();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载生活服务_管道疏通/清理基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW/LoadSHFW_GDSTQLJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SHFW_GDSTQLJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.SHFW_GDSTQLJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                if (xml.Value.SHFW_GDSTQLJBXX.LB !== null)
                    SetDuoX("LB", xml.Value.SHFW_GDSTQLJBXX.LB);
                if (xml.Value.SHFW_GDSTQLJBXX.FWFW !== null)
                    SetDuoX("FWFW", xml.Value.SHFW_GDSTQLJBXX.FWFW);
                $("#spanQY").html(xml.Value.SHFW_GDSTQLJBXX.QY);
                $("#spanDD").html(xml.Value.SHFW_GDSTQLJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.SHFW_GDSTQLJBXX.LB.indexOf("下水道疏通") !== -1 || xml.Value.SHFW_GDSTQLJBXX.LB.indexOf("化粪池清理") !== -1 || xml.Value.SHFW_GDSTQLJBXX.LB.indexOf("打捞") !== -1 || xml.Value.SHFW_GDSTQLJBXX.LB.indexOf("工业管道安装／改造") !== -1 ) {
                    LoadXL(xml.Value.SHFW_GDSTQLJBXX.LB, xml.Value.SHFW_GDSTQLJBXX.XL);
                }
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
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDuoX("LB") + "'");
    obj = jsonObj.AddJson(obj, "FWFW", "'" + GetDuoX("FWFW") + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW/FBSHFW_GDSTQLJBXX",
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