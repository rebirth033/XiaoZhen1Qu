$(document).ready(function () {
    BindClick("FWLX");
    LoadDuoX("日租短租房屋配置", "FWPZ");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "FWLX") {
            LoadCODESByTYPENAME("短租房类型", "FWLX", "CODES_FC", Bind, "FWLX", "FWLX", "");
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
            TBName: "CODES_FC"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 4 || i === 9 || i === 14 || i === 19) {
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
                if (type === "日租短租房屋配置")
                    LoadDuoX("日租短租付款方式", "FKFS");
                if (type === "日租短租付款方式")
                    LoadJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载短租房基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC/LoadFC_DZFJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.FC_DZFJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#spanQY").html(xml.Value.FC_DZFJBXX.QY);
                $("#spanDD").html(xml.Value.FC_DZFJBXX.DD);
                $("#spanFWLX").html(xml.Value.FC_DZFJBXX.FWLX);
                if (xml.Value.FC_DZFJBXX.FWPZ !== null)
                    SetDuoX("FWPZ", xml.Value.FC_DZFJBXX.FWPZ);
                if (xml.Value.FC_DZFJBXX.FKFS !== null)
                    SetDuoX("FKFS", xml.Value.FC_DZFJBXX.FKFS);
                $("#ID").val(xml.Value.FC_DZFJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
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
    obj = jsonObj.AddJson(obj, "FWLX", "'" + $("#spanFWLX").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "FWPZ", "'" + GetDuoX("FWPZ") + "'");
    obj = jsonObj.AddJson(obj, "FKFS", "'" + GetDuoX("FKFS") + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC/FBFC_DZFJBXX",
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
            } else {
                if (xml.Type === 1) {
                    $("#YZM").css("border-color", "#F2272D");
                    $("#YZMInfo").css("color", "#F2272D");
                    $("#YZMInfo").html(xml.Message);
                }
                if (xml.Type === 2) {
                    $("#YHM").css("border-color", "#F2272D");
                    $("#YHMInfo").css("color", "#F2272D");
                    $("#YHMInfo").html(xml.Message);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}