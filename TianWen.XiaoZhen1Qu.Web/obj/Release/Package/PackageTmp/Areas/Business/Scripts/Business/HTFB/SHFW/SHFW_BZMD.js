﻿$(document).ready(function () {
    $("#divSFSM").find(".div_radio").bind("click", function () { ValidateRadio("SFSM", "忘记选择是否上门啦"); });
    LoadDuoX("殡葬/墓地类别", "LB");
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
                    html += "<li class='li" + id + "' style='width:140px;' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 4 === 3 && i !== xml.list.length - 1) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 183px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 4) * 60 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 4) + 1) * 60 + "px");
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
//加载生活服务_殡葬/墓地基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW/LoadSHFW_BZMDJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SHFW_BZMDJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.SHFW_BZMDJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                if (xml.Value.SHFW_BZMDJBXX.LB !== null)
                    SetDuoX("LB", xml.Value.SHFW_BZMDJBXX.LB);
                if (xml.Value.SHFW_BZMDJBXX.FWFW !== null)
                    SetDuoX("FWFW", xml.Value.SHFW_BZMDJBXX.FWFW);
                $("#spanQY").html(xml.Value.SHFW_BZMDJBXX.QY);
                $("#spanDD").html(xml.Value.SHFW_BZMDJBXX.DD);
                SetDX("SFSM", xml.Value.SHFW_BZMDJBXX.SFSM);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDuoX("LB") + "'");
    obj = jsonObj.AddJson(obj, "FWFW", "'" + GetDuoX("FWFW") + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + GetDuoX("XL") + "'");
    obj = jsonObj.AddJson(obj, "SFSM", "'" + GetDX("SFSM") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW/FBSHFW_BZMDJBXX",
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