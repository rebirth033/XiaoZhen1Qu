$(document).ready(function () {
    LoadCYLS();
    BindClick("PP");
    BindClick("GHCS");
    BindClick("SPNF");
    BindClick("SPYF");
    BindClick("NJDQNF");
    BindClick("NJDQYF");
    BindClick("JQXDQNF");
    BindClick("JQXDQYF");
    BindClick("SYXDQNF");
    BindClick("SYXDQYF");
    BindClick("PZSZSF");
    LoadDuoX("车辆加装配置", "CLJZPZ");
    $("#divPPText").bind("click", function () { LoadJCPP(); });
});
//加载品牌名称
function LoadJCPP() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "轿车品牌",
            TBName: "CODES_CL_JC"
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
                            html += '<li onclick="OpenSecond(\'' + xml.list[j].CODEID + '\')" class="li_row_right_jcpp_first_right_value">' + xml.list[j].CODENAME + '</li>';
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
function OpenSecond(codeid) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: codeid,
            TBName: "CODES_CL_JC"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#div_row_right_jcpp_second").html('');
                var html = "";
                html += '<span class="p_row_right_jcpp">请选择车系<span onclick="CloseJCPP(2)" class="span_row_right_jcpp">×</span></span>';
                html += '<ul class="ul_row_right_jcpp_second">';
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<li onclick="OpenThird(\'' + xml.list[i].CODEID + '\',\'' + xml.list[i].CODEVALUE + " " + xml.list[i].CODENAME + '\')" class="li_row_right_jcpp_second">' + xml.list[i].CODEVALUE + " " + xml.list[i].CODENAME + '</li>';
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
//打开款式列表
function OpenThird(codeid, cx) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: codeid,
            TBName: "CODES_CL_JC"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#div_row_right_jcpp_third").html('');
                var html = "";
                html += '<span class="p_row_right_jcpp">请选择款式<span onclick="CloseJCPP(3)" class="span_row_right_jcpp">×</span></span>';
                html += '<ul class="ul_row_right_jcpp_third">';
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<li onclick="SelectThird(\'' + cx + '\',\'' + xml.list[i].CODENAME + '\')" class="li_row_right_jcpp_third">' + xml.list[i].CODENAME + '</li>';
                }
                html += '</ul>';
                $("#div_row_right_jcpp_third").append(html);
                $("#div_row_right_jcpp_third").css("display", "inline-block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择款式
function SelectThird(cx, ks) {
    $("#spanPP").html(cx + " " + ks);
    ValidateJCPP();
}
//关闭选择品牌框
function CloseJCPP(count) {
    if (count === 1) {
        $("#div_row_right_jcpp_first").css("display", "none");
        $("#div_row_right_jcpp_second").css("display", "none");
        $("#div_row_right_jcpp_third").css("display", "none");
    }
    if (count === 2) {
        $("#div_row_right_jcpp_second").css("display", "none");
        $("#div_row_right_jcpp_third").css("display", "none");
    }
    if (count === 3) {
        $("#div_row_right_jcpp_third").css("display", "none");
    }
}
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type.indexOf("NF") !== -1) {
            if (type === "SPNF")
                LoadCODESByTYPENAME("出厂年份", type, "CODES_CL", Bind, "SCSPSJ", "SPNF", "");
            else
                LoadCODESByTYPENAME("到期年份", type, "CODES_CL");
        }
        if (type.indexOf("YF") !== -1) {
            if (type === "SPYF")
                LoadCODESByTYPENAME("出厂月份", type, "CODES_CL", Bind, "SCSPSJ", "SPYF", "");
            else
                LoadCODESByTYPENAME("出厂月份", type, "CODES_CL");
        }
        if (type.indexOf("GHCS") !== -1) {
            LoadCODESByTYPENAME("过户次数", type, "CODES_CL");
        }
        if (type.indexOf("PZSZSF") !== -1) {
            LoadPZSZSF(type);
        }
        if (type.indexOf("PZSZCS") !== -1) {
            LoadPZSZCS(type);
        }
    });
}
//加载牌照所在省份
function LoadPZSZSF() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/GetDistrictByGrade",
        dataType: "json",
        data:
        {
            Grade: "省级"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ul_select' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectPZSZSF(this,\"PZSZSF\",\"" + xml.list[i].CODEID + "\")'>" + RTrim(RTrim(xml.list[i].CODENAME, '市'), '省') + "</li>";
                }
                html += "</ul>";
                $("#divPZSZSF").html(html);
                $("#divPZSZSF").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载牌照所在城市
function LoadPZSZCS() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/GetDistrictBySuperCode",
        dataType: "json",
        data:
        {
            SuperCode: $("#SPSF").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ul_select' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectDropdown(this,\"PZSZCS\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divPZSZCS").html(html);
                $("#divPZSZCS").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载车辆颜色
function LoadCYLS() {
    var colors = new Array("black:黑", "white:白", "red:红", "rgb(255, 255, 0):黄", "rgb(51, 153, 255):蓝", "rgb(13, 207, 110):绿", "rgb(255, 102, 0):橙");
    for (var i = 0; i < colors.length; i++) {
        var obj = colors[i].split(':');
        $("#div_clys_right").append('<div class="div_clys"><span class="span_clys_left" style="background-color: ' + obj[0] + '"></span><span class="span_clys_right">' + obj[1] + '</span></div>');
    }
    colors = new Array("rgb(204, 51, 153):紫", "rgb(255, 204, 0):金", "rgb(230, 230, 230):银", "rgb(214, 214, 214):灰", "rgb(153, 102, 0):棕", "rgb(255, 192, 203):粉红", "其他");
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
        $(this).css("border-color", "#cccccc").css("background-color", "#ffffff");
        $(this).bind("mouseover",function(){$(this).css("background-color", "#ececec");});
        $(this).bind("mouseout",function(){$(this).css("background-color", "#ffffff");});
    });
    $(this).css("border-color", "#bc6ba6").css("background-color", "#bc6ba6");
    $(this).unbind("mouseover").unbind("mouseout");

}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
}
//选择上牌省份
function SelectPZSZSF(obj, type, code) {
    $("#SPSF").val(code);
    $("#spanPZSZSF").html(obj.innerHTML);
    $("#divPZSZSF").css("display", "none");
    BindClick("PZSZCS");
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
            TBName: "CODES_CL"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 6 === 5) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 183px'>";
                    }
                }
                if (parseInt(xml.list.length % 6) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 6) * 60 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 6) + 1) * 60 + "px");
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
//加载车辆_轿车基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/CL/LoadCL_JCJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_JCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.CL_JCJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanPP").html(xml.Value.CL_JCJBXX.PP);
                $("#spanSPNF").html(xml.Value.CL_JCJBXX.SPNF);
                $("#spanSPYF").html(xml.Value.CL_JCJBXX.SPYF);
                $("#spanNJDQNF").html(xml.Value.CL_JCJBXX.NJDQNF);
                $("#spanNJDQYF").html(xml.Value.CL_JCJBXX.NJDQYF);
                $("#spanJQXDQNF").html(xml.Value.CL_JCJBXX.JQXDQNF);
                $("#spanJQXDQYF").html(xml.Value.CL_JCJBXX.JQXDQYF);
                $("#spanSYXDQNF").html(xml.Value.CL_JCJBXX.SYXDQNF);
                $("#spanSYXDQYF").html(xml.Value.CL_JCJBXX.SYXDQYF);
                $("#spanPZSZSF").html(xml.Value.CL_JCJBXX.PZSZSF);
                $("#spanPZSZCS").html(xml.Value.CL_JCJBXX.PZSZCS);
                $("#spanGHCS").html(xml.Value.CL_JCJBXX.GHCS);
                $("#spanQY").html(xml.Value.CL_JCJBXX.QY);
                $("#spanDD").html(xml.Value.CL_JCJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.CL_JCJBXX.SF !== null)
                    SetDX("SF", xml.Value.CL_JCJBXX.SF);
                if (xml.Value.CL_JCJBXX.CLYS !== null)
                    SetCLYS(xml.Value.CL_JCJBXX.CLYS);
                if (xml.Value.CL_JCJBXX.SFDQBY !== null)
                    SetDX("SFDQBY", xml.Value.CL_JCJBXX.SFDQBY);
                if (xml.Value.CL_JCJBXX.SFDQBY !== null)
                    SetDuoX("CLJZPZ", xml.Value.CL_JCJBXX.CLJZPZ);
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
    obj = jsonObj.AddJson(obj, "CLYS", "'" + GetCLYS() + "'");
    obj = jsonObj.AddJson(obj, "SPNF", "'" + $("#spanSPNF").html() + "'");
    obj = jsonObj.AddJson(obj, "SPYF", "'" + $("#spanSPYF").html() + "'");
    obj = jsonObj.AddJson(obj, "NJDQNF", "'" + $("#spanNJDQNF").html() + "'");
    obj = jsonObj.AddJson(obj, "NJDQYF", "'" + $("#spanNJDQYF").html() + "'");
    obj = jsonObj.AddJson(obj, "JQXDQNF", "'" + $("#spanJQXDQNF").html() + "'");
    obj = jsonObj.AddJson(obj, "JQXDQYF", "'" + $("#spanJQXDQYF").html() + "'");
    obj = jsonObj.AddJson(obj, "SYXDQNF", "'" + $("#spanSYXDQNF").html() + "'");
    obj = jsonObj.AddJson(obj, "SYXDQYF", "'" + $("#spanSYXDQYF").html() + "'");
    obj = jsonObj.AddJson(obj, "PZSZSF", "'" + $("#spanPZSZSF").html() + "'");
    obj = jsonObj.AddJson(obj, "PZSZCS", "'" + $("#spanPZSZCS").html() + "'");
    obj = jsonObj.AddJson(obj, "GHCS", "'" + $("#spanGHCS").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("SF") + "'");
    obj = jsonObj.AddJson(obj, "SFDQBY", "'" + GetDX("SFDQBY") + "'");
    obj = jsonObj.AddJson(obj, "CLJZPZ", "'" + GetDuoX("CLJZPZ") + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/CL/FBCL_JCJBXX",
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