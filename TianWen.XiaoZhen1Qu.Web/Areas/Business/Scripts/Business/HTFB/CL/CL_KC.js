$(document).ready(function () {
    LoadJBXX();
    LoadCYLS();
    $("#divPPText").bind("click", function () { LoadHCPP(); });
    BindClick("SPNF");
    BindClick("SPYF");
    BindClick("NJDQNF");
    BindClick("NJDQYF");
    BindClick("JQXDQNF");
    BindClick("JQXDQYF");
    BindClick("SYXDQNF");
    BindClick("SYXDQYF");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "SPNF") {
            LoadCODESByTYPENAME("出厂年份", type, "CODES_CL", Bind, "SCSPSJ", "SPNF", "");
        }
        if (type === "SPYF") {
            LoadCODESByTYPENAME("出厂月份", type, "CODES_CL", Bind, "SCSPSJ", "SPYF", "");
        }
        if (type === "NJDQNF") {
            LoadCODESByTYPENAME("到期年份", type, "CODES_CL");
        }
        if (type === "NJDQYF") {
            LoadCODESByTYPENAME("出厂月份", type, "CODES_CL");
        }
        if (type === "JQXDQNF") {
            LoadCODESByTYPENAME("到期年份", type, "CODES_CL");
        }
        if (type === "JQXDQYF") {
            LoadCODESByTYPENAME("出厂月份", type, "CODES_CL");
        }
        if (type === "SYXDQNF") {
            LoadCODESByTYPENAME("到期年份", type, "CODES_CL");
        }
        if (type === "SYXDQYF") {
            LoadCODESByTYPENAME("出厂月份", type, "CODES_CL");
        }
    });
}
//加载品牌名称
function LoadHCPP() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "客车品牌",
            TBName: "CODES_CL"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#div_row_right_jcpp_first").html('');
                var html = "";
                html += '<span class="p_row_right_jcpp">请选择品牌<span onclick="CloseJCPP(1)" class="span_row_right_jcpp">×</span></span>';
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
//打开车系列表
function OpenSecond(codeid,codename) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: codeid,
            TBName: "CODES_CL"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#div_row_right_jcpp_second").html('');
                var html = "";
                html += '<span class="p_row_right_jcpp">请选择车系<span onclick="CloseJCPP(2)" class="span_row_right_jcpp">×</span></span>';
                html += '<ul class="ul_row_right_jcpp_second">';
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<li onclick="SelectSecond(\'' + codename + '\',\'' + xml.list[i].CODENAME + '\')" class="li_row_right_jcpp_second">' + xml.list[i].CODENAME + '</li>';
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
//选择款式
function SelectSecond(pp, cx) {
    $("#spanPP").html(pp + " " + cx);
}
//关闭选择品牌框
function CloseJCPP(count) {
    if (count === 1) {
        $("#div_row_right_jcpp_first").css("display", "none");
        $("#div_row_right_jcpp_second").css("display", "none");
    }
    if (count === 2) {
        $("#div_row_right_jcpp_second").css("display", "none");
    }
}
//加载车辆颜色
function LoadCYLS() {
    var colors = new Array("black:黑", "red:红", "white:白", "rgb(230, 230, 230):银", "rgb(214, 214, 214):灰", "rgb(51, 153, 255):蓝", "rgb(255, 255, 0):黄", "rgb(153, 102, 0):棕");
    for (var i = 0; i < colors.length; i++) {
        var obj = colors[i].split(':');
        $("#div_clys_right").append('<div class="div_clys"><span class="span_clys_left" style="background-color: ' + obj[0] + '"></span><span class="span_clys_right">' + obj[1] + '</span></div>');
    }
    colors = new Array("rgb(13, 207, 110):绿", "rgb(255, 102, 0):橙", "rgb(204, 51, 153):紫", "rgb(243, 238, 170):香槟", "rgb(255, 204, 0):金", "rgb(255, 192, 203):粉红", "其他");
    for (var i = 0; i < colors.length; i++) {
        var obj = colors[i].split(':');
        if (i === colors.length - 1)
            $("#div_clys_right2").append('<div class="div_clys"><span class="span_clys_left" style="border:none;"></span><span class="span_clys_right">' + obj[0] + '</span></div>');
        else
            $("#div_clys_right2").append('<div class="div_clys"><span class="span_clys_left" style="background-color: ' + obj[0] + '"></span><span class="span_clys_right">' + obj[1] + '</span></div>');
    }
    $(".div_clys").bind("click", ActiveCLYS);
}
//获取车辆颜色
function GetCLYS() {
    var value = "";
    $(".div_clys").each(function () {
        if ($(this).css("background-color") === "rgb(188, 107, 166)")
            value = $(this).find(".span_clys_right")[0].innerHTML;
    });
    return value;
}
//设置车辆颜色
function SetCLYS(clys) {
    $(".div_clys").each(function () {
        if ($(this).find(".span_clys_right")[0].innerHTML === clys)
            $(this).css("border-color", "#bc6ba6").css("background-color", "#bc6ba6");
    });
}
//选择车辆颜色
function ActiveCLYS() {
    $(".div_clys").each(function () {
        $(this).css("border-color", "#cccccc").css("background-color", "#ffffff");;
    });
    $(this).css("border-color", "#bc6ba6").css("background-color", "#bc6ba6");
}
//加载车辆_客车基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL/LoadCL_KCJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_KCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.CL_KCJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanPP").html(xml.Value.CL_KCJBXX.PP);
                $("#spanCX").html(xml.Value.CL_KCJBXX.CX);
                $("#spanSPNF").html(xml.Value.CL_KCJBXX.SPNF);
                $("#spanSPYF").html(xml.Value.CL_KCJBXX.SPYF);
                $("#spanNJDQNF").html(xml.Value.CL_KCJBXX.NJDQNF);
                $("#spanNJDQYF").html(xml.Value.CL_KCJBXX.NJDQYF);
                $("#spanJQXDQNF").html(xml.Value.CL_KCJBXX.JQXDQNF);
                $("#spanJQXDQYF").html(xml.Value.CL_KCJBXX.JQXDQYF);
                $("#spanSYXDQNF").html(xml.Value.CL_KCJBXX.SYXDQNF);
                $("#spanSYXDQYF").html(xml.Value.CL_KCJBXX.SYXDQYF);
                $("#spanQY").html(xml.Value.CL_KCJBXX.QY);
                $("#spanDD").html(xml.Value.CL_KCJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.CL_KCJBXX.CLYS !== null)
                    SetCLYS(xml.Value.CL_KCJBXX.CLYS);
                if (xml.Value.CL_KCJBXX.SF !== null)
                    SetDX("SF", xml.Value.CL_KCJBXX.SF);
                if (xml.Value.CL_KCJBXX.SFDQBY !== null)
                    SetDX("SFDQBY", xml.Value.CL_KCJBXX.SFDQBY);
                if (xml.Value.CL_KCJBXX.YWZDSG !== null)
                    SetDX("YWZDSG", xml.Value.CL_KCJBXX.YWZDSG);
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
    obj = jsonObj.AddJson(obj, "PP", "'" + $("#spanPP").html() + "'");
    obj = jsonObj.AddJson(obj, "CX", "'" + $("#spanCX").html() + "'");
    obj = jsonObj.AddJson(obj, "CLYS", "'" + GetCLYS() + "'");
    obj = jsonObj.AddJson(obj, "SPNF", "'" + $("#spanSPNF").html() + "'");
    obj = jsonObj.AddJson(obj, "SPYF", "'" + $("#spanSPYF").html() + "'");
    obj = jsonObj.AddJson(obj, "NJDQNF", "'" + $("#spanNJDQNF").html() + "'");
    obj = jsonObj.AddJson(obj, "NJDQYF", "'" + $("#spanNJDQYF").html() + "'");
    obj = jsonObj.AddJson(obj, "JQXDQNF", "'" + $("#spanJQXDQNF").html() + "'");
    obj = jsonObj.AddJson(obj, "JQXDQYF", "'" + $("#spanJQXDQYF").html() + "'");
    obj = jsonObj.AddJson(obj, "SYXDQNF", "'" + $("#spanSYXDQNF").html() + "'");
    obj = jsonObj.AddJson(obj, "SYXDQYF", "'" + $("#spanSYXDQYF").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("SF") + "'");
    obj = jsonObj.AddJson(obj, "SFDQBY", "'" + GetDX("SFDQBY") + "'");
    obj = jsonObj.AddJson(obj, "YWZDSG", "'" + GetDX("YWZDSG") + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CL/FBCL_KCJBXX",
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