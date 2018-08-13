$(document).ready(function () {
    LoadZYLY();
    $("#divYZText").bind("click", function () { LoadYZ(); });
});
//加载语种
function LoadYZ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "语种",
            TBName: "CODES_SWFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#div_row_right_jcpp_first").html('');
                var html = "";
                html += '<span class="p_row_right_jcpp">请选择语种<span onclick="CloseLXGJ(1)" class="span_row_right_jcpp">×</span></span>';
                html += '<div class="div_row_right_jcpp_first_left">';
                html += '<ul class="ul_row_right_jcpp_first_left">';
                for (var i = 0; i < BQArray.length; i++) {
                    var count = 0;
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            count++;
                    }
                    if (count !== 0)
                        html += '<li onclick="GoToBQ(\'' + BQArray[i] + '\')" class="li_row_right_jcpp_first_left">' + BQArray[i] + '</li>';
                }
                html += '</ul>';
                html += '</div>';

                html += '<div class="div_row_right_jcpp_first_right">';
                html += '<ul class="ul_row_right_jcpp_first_right">';
                for (var i = 0; i < BQArray.length; i++) {
                    var count = 0;
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            count++;
                    }
                    if (count !== 0)
                        html += '<li id="li_row_right_jcpp_first_right_tag_' + BQArray[i] + '" class="li_row_right_jcpp_first_right_tag">' + BQArray[i] + '</li>';
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            html += '<li onclick="SelectFirst(\'' + xml.list[j].CODENAME + '\')" class="li_row_right_jcpp_first_right_value">' + xml.list[j].CODENAME + '</li>';
                    }
                }
                html += '</ul>';
                html += '</div>';

                $("#div_row_right_jcpp_first").append(html);
                $("#div_row_right_jcpp_first").css("display", "inline-block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//跳转到标签位置
function GoToBQ(tag) {
    var len = document.getElementById("li_row_right_jcpp_first_right_tag_" + tag).offsetTop - 75;//获取div层到页面顶部的高度 
    $(".ul_row_right_jcpp_first_right").stop().animate({ scrollTop: len }, 300, "swing", function () { });
}
//选择职位
function SelectFirst(name) {
    $("#spanYZ").html(name);
    ValidateSelect("YZ", "YZ", "请选择语种");
}
//关闭选择语种
function CloseLXGJ(count) {
    if (count === 1) {
        $("#div_row_right_jcpp_first").css("display", "none");
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
            TBName: "CODES_SWFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' style='width:120px;' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 5 === 4 && i !== xml.list.length - 1) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 173px'>";
                    }
                }
                if (parseInt(xml.list.length % 5) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 5) * 40 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 5) + 1) * 40 + "px");
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
//加载专业领域
function LoadZYLY() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "专业领域",
            TBName: "CODES_SWFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liZYLY' onclick='SelectDuoX(this)'><img class='img_ZYLY'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 6 === 5 && i !== (xml.list.length - 1)) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 173px'>";
                    }
                }
                if (parseInt(xml.list.length % 6) === 0)
                    $("#divZYLY").css("height", parseInt(xml.list.length / 6) * 45 + "px");
                else
                    $("#divZYLY").css("height", (parseInt(xml.list.length / 6) + 1) * 45 + "px");
                html += "</ul>";
                $("#divZYLYText").html(html);
                $(".img_ZYLY").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                if (xml.list.length === 0)
                    $("#divZYLY").css("display", "none");
                else
                    $("#divZYLY").css("display", "");
                LoadWJLX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载文件类型
function LoadWJLX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "文件类型",
            TBName: "CODES_SWFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liWJLX' style='width:130px;' onclick='SelectDuoX(this)'><img class='img_WJLX'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 5 === 4 && i !== (xml.list.length - 1)) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 173px'>";
                    }
                }
                if (parseInt(xml.list.length % 5) === 0)
                    $("#divWJLX").css("height", parseInt(xml.list.length / 5) * 45 + "px");
                else
                    $("#divWJLX").css("height", (parseInt(xml.list.length / 5) + 1) * 45 + "px");
                html += "</ul>";
                $("#divWJLXText").html(html);
                $(".img_WJLX").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                if (xml.list.length === 0)
                    $("#divWJLX").css("display", "none");
                else
                    $("#divWJLX").css("display", "");
                LoadDuoX("翻译/速记类别", "LB");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载商务服务_翻译/速记基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/SWFW/LoadSWFW_FYSJJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SWFW_FYSJJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.SWFW_FYSJJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanYZ").html(xml.Value.SWFW_FYSJJBXX.YZ);
                $("#spanQY").html(xml.Value.SWFW_FYSJJBXX.QY);
                $("#spanDD").html(xml.Value.SWFW_FYSJJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                SetDuoX("ZYLY", xml.Value.SWFW_FYSJJBXX.ZYLY);
                SetDuoX("WJLX", xml.Value.SWFW_FYSJJBXX.WJLX);
		SetDuoX("LB", xml.Value.SWFW_FYSJJBXX.LB);
		SetDuoX("FWFW", xml.Value.SWFW_FYSJJBXX.FWFW);
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
    obj = jsonObj.AddJson(obj, "YZ", "'" + $("#spanYZ").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "ZYLY", "'" + GetDuoX("ZYLY") + "'");
    obj = jsonObj.AddJson(obj, "WJLX", "'" + GetDuoX("WJLX") + "'");
    obj = jsonObj.AddJson(obj, "FWFW", "'" + GetDuoX("FWFW") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/SWFW/FBSWFW_FYSJJBXX",
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