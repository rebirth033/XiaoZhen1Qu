$(document).ready(function () {
    BindClick("MYXZ");
    BindClick("XLYQ");
    BindClick("GZNX");
    LoadDuoX("职位福利", "ZWFL");
    $("#divZWMCText").bind("click", function () { LoadZWMC(); });
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "MYXZ") {
            LoadCODESByTYPENAME("每月薪资", "MYXZ", "CODES_QZZP", Bind, "ZPMYXZ", "MYXZ", "");
        }
        if (type === "XLYQ") {
            LoadCODESByTYPENAME("学历要求", "XLYQ", "CODES_QZZP", Bind, "ZPXLYQ", "XLYQ", "");
        }
        if (type === "GZNX") {
            LoadCODESByTYPENAME("工作年限", "GZNX", "CODES_QZZP", Bind, "ZPGZNX", "GZNX", "");
        }
    });
}
//加载职位名称
function LoadZWMC() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadChildByCODENAME",
        dataType: "json",
        data:
        {
            CODENAME: $("#spanLBXZ").html().replace("1.", ""),
            TBName: "CODES_QZZP"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#div_row_right_jcpp_first").html('');
                var html = "";
                html += '<span class="p_row_right_jcpp">请选择职位类别<span onclick="CloseZWMC(1)" class="span_row_right_jcpp">×</span></span>';
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
                            html += '<li onclick="OpenSecond(\'' + xml.list[j].CODEID + '\',\'' + xml.list[j].CODENAME + '\')" class="li_row_right_jcpp_first_right_value">' + xml.list[j].CODENAME + '</li>';
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
//打开职位列表
function OpenSecond(codeid, codename) {
    $("#ZWLB").val(codename);
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: codeid,
            TBName: "CODES_QZZP"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#div_row_right_jcpp_second").html('');
                var html = "";
                html += '<span class="p_row_right_jcpp">请选择职位<span onclick="CloseZWMC(2)" class="span_row_right_jcpp">×</span></span>';
                html += '<ul class="ul_row_right_jcpp_second">';
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<li onclick="SelectSecond(\'' + xml.list[i].CODENAME + '\')" class="li_row_right_jcpp_second">' + xml.list[i].CODENAME + '</li>';
                }
                html += '</ul>';
                $("#div_row_right_jcpp_second").append(html);
                $("#div_row_right_jcpp_second").css("display", "inline-block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择职位
function SelectSecond(name) {
    $("#spanZWMC").html(name);
    ValidateSelect("ZWMC", "ZWMC", "请选择职位名称");
}
//关闭选择品牌框
function CloseZWMC(count) {
    if (count === 1) {
        $("#div_row_right_jcpp_first").css("display", "none");
        $("#div_row_right_jcpp_second").css("display", "none");
    }
    if (count === 2) {
        $("#div_row_right_jcpp_second").css("display", "none");
    }
}
//选择职位类别
function SelectZWLB() {
    $("#spanZWLB").html($(this)[0].innerHTML);
    $("#divZWLB").css("display", "none");
    $("#BT").val($(this)[0].innerHTML);
    ValidateSelect("ZPZWLB", "ZWLB", "忘记选择职位类别啦");
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
            TBName: "CODES_QZZP"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 4 || i === 9 || i === 14 || i === 19 || i === 24) {
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
                LoadJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载求职招聘_全职招聘基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/QZZP/LoadQZZP_QZZPJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.QZZP_QZZPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.QZZP_QZZPJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanZWMC").html(xml.Value.QZZP_QZZPJBXX.ZWMC);
   		$("#ZWLB").val(xml.Value.QZZP_QZZPJBXX.ZWLB);
                $("#spanMYXZ").html(xml.Value.QZZP_QZZPJBXX.MYXZ);
                $("#spanXLYQ").html(xml.Value.QZZP_QZZPJBXX.XLYQ);
                $("#spanGZNX").html(xml.Value.QZZP_QZZPJBXX.GZNX);
                $("#spanQY").html(xml.Value.QZZP_QZZPJBXX.QY);
                $("#spanDD").html(xml.Value.QZZP_QZZPJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.QZZP_QZZPJBXX.ZWFL !== null)
                    SetDuoX("ZWFL", xml.Value.QZZP_QZZPJBXX.ZWFL);
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
    obj = jsonObj.AddJson(obj, "ZWMC", "'" + $("#spanZWMC").html() + "'");
    obj = jsonObj.AddJson(obj, "ZWLB", "'" + $("#ZWLB").val() + "'");
    obj = jsonObj.AddJson(obj, "MYXZ", "'" + $("#spanMYXZ").html() + "'");
    obj = jsonObj.AddJson(obj, "XLYQ", "'" + $("#spanXLYQ").html() + "'");
    obj = jsonObj.AddJson(obj, "GZNX", "'" + $("#spanGZNX").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "ZWFL", "'" + GetDuoX("ZWFL") + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/QZZP/FBQZZP_QZZPJBXX",
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