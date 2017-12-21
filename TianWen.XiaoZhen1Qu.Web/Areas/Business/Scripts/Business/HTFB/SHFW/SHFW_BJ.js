$(document).ready(function () {
    LoadSHFW_BJJBXX();
    BindClick("LB");
    $("#FWQY").bind("click", LoadFWQY);
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("搬家类别", "LB", "CODES_SHFW", Bind, "OUTLB", "LB", "");
        }
    });
}
//加载生活服务_搬家基本信息
function LoadSHFW_BJJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW/LoadSHFW_BJJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SHFW_BJJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.SHFW_BJJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.SHFW_BJJBXX.LB);
                $("#spanQY").html(xml.Value.SHFW_BJJBXX.QY);
                $("#spanDD").html(xml.Value.SHFW_BJJBXX.DD);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW/FBSHFW_BJJBXX",
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
//加载服务区域
function LoadFWQY() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/GetAllDistrictByXZQDM",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += '<div class="div_row_right_fwqy_top">';
                html += '<div class="div_row_right_fwqy_top_qs"><img onclick="SelectFWQY(this)" class="img_row_right_fwqy_top_qs" src="' + getRootPath() + '/Areas/Business/Css/images/check_gray.png">全市</div>';
                html += '<img class="img_row_right_fwqy_top_close" onclick="CloseFWQY()" src="' + getRootPath() + '/Areas/Business/Css/images/close.png">';
                html += '</div>';
                html += '<div class="div_row_right_fwqy_left">';
                html += '<ul class="ul_row_right_fwqy_left">';
                for (var i = 0; i < xml.qylist.length; i++) {
                    html += '<li class="li_row_right_fwqy_left" onclick="TabFWQY(this,\'' + xml.qylist[i].CODEID + '\')"><img onclick="SelectFWQY(this)" class="img_row_right_fwqy_left" src="' + getRootPath() + '/Areas/Business/Css/images/check_gray.png">' + xml.qylist[i].CODENAME + '</li>';
                }
                html += '</ul>';
                html += '</div>';
                for (var i = 0; i < xml.qylist.length; i++) {
                    html += '<div id="' + xml.qylist[i].CODEID + '" class="div_row_right_fwqy_right">';
                    html += '<ul class="ul_row_right_fwqy_right">';
                    for (var j = 0; j < xml.ddlist.length; j++) {
                        if (xml.ddlist[j].PARENTID === xml.qylist[i].CODEID)
                            html += '<li onclick="SelectFWDD(this,\'' + xml.ddlist[j].CODENAME + '\')" class="li_row_right_fwqy_right"><img class="img_row_right_fwqy_right" src="' + getRootPath() + '/Areas/Business/Css/images/check_gray.png">' + xml.ddlist[j].CODENAME + '</li>';
                    }
                    html += '</ul>';
                    html += '</div>';
                }

                $("#div_row_right_fwqy").html(html);
                $("#div_row_right_fwqy").css("display", "block");
                $(".li_row_right_fwqy_left:eq(0)").css("background-color", "#ffffff");
                $(".div_row_right_fwqy_right:eq(0)").css("display", "inline-block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//切换服务区域
function TabFWQY(obj, codeid) {
    $(".li_row_right_fwqy_left").css("background-color", "#eeeff1");
    $(obj).css("background-color", "#ffffff");
    $(".div_row_right_fwqy_right").css("display", "none");
    $("#" + codeid).css("display", "inline-block");
}
//选择服务区域
function SelectFWQY(obj) {
    if ($(obj).attr("src").indexOf("purple") !== -1)
        $(obj).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).attr("src", getRootPath() + "/Areas/Business/Css/images/check_purple.png");
}
//选择服务区域
function SelectFWDD(obj, codename) {
    if ($(obj).find("img").attr("src").indexOf("purple") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_purple.png");
    $("#FWQY").val(codename);
}
//关闭服务区域
function CloseFWQY() {
    $("#div_row_right_fwqy").css("display", "none");
}