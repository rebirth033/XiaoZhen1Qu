var curIndex = 1; //当前index
var temp = 0;
$(document).ready(function () {
    $(".div_head_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_foot").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_bottom").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".img_head_left_logo").css("margin-left", "20px");
    $("#li_head_sy").css("background", "#bc6ba6").css("color", "#ffffff");
    $("#div_yhm").bind("click", ShowWDXX);
    $("#SS").bind("keyup", LoadSSJG);
    $("#span_ss").bind("click", OpenSSJG);
    LoadDefault();
});
//首页获取title
function GetHeadNav() {
    $("#title").html("信息小镇_首页");
}
//发布信息
function FBXX() {
    window.open(getRootPath() + "/Business/LBXZ/LBXZ");
}
//加载默认
function LoadDefault() {
    LoadSY_ML();
    LoadHeadSearch();
}
//加载头部搜索栏关键字
function LoadHeadSearch() {
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'FCCX\',\'FCCX_ZZF\',\'13\')">租房子</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'CLCX\',\'CLCX_JC\',\'185\')">二手车</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'QZZPCX\',\'QZZPCX_JZ\',\'89\')">兼职</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'ZXJCCX\',\'ZXJCCX_JZFW\',\'130\')">装修服务</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'LYJDCX\',\'LYJDCX_GNY\',\'124\')">旅游度假</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'SHFWCX\',\'SHFWCX_GNY\',\'172\')">居民搬家</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'HQSYCX\',\'HQSYCX_HQGS\',\'136\')">婚庆公司</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss_split">|</span>');
    $(".div_head_right_ss").append('<span class="span_head_right_ss" onclick="OpenSS(\'XXYLCX\',\'XXYLCX_YDJS\',\'44\')">运动健身</span>');
}
//搜索栏备注导航
function OpenSS(DL, XL, ID) {
    window.open(getRootPath() + "/Business/" + DL + "/" + XL + "?LBID=" + ID);
}
//打开详细页面
function OpenXXXX(LBID, JCXXID) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadLBByJCXX",
        dataType: "json",
        data:
        {
            LBID: LBID,
            JCXXID: JCXXID
        },
        success: function (xml) {
            if (xml.Result === 1) {
                if (LBID === 19) {
                    window.open(getRootPath() + "/Business/FCXX/FCXX_ZZF?ID=" + xml.id);
                }
                if (LBID === 1902) {
                    window.open(getRootPath() + "/Business/FCXX/FCXX_HZF?ID=" + xml.id);
                }
                if (LBID === 20) {
                    window.open(getRootPath() + "/Business/FCXX/FCXX_SP?ID=" + xml.id);
                }
                if (LBID === 21) {
                    window.open(getRootPath() + "/Business/FCXX/FCXX_ESF?ID=" + xml.id);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}
//加载首页_目录
function LoadSY_ML() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadSY_ML",
        dataType: "json",
        data: {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadSY_MLInfo(xml.list, xml.xzq, "FC");
                LoadSY_MLInfo(xml.list, xml.xzq, "CL");
                LoadSY_ML_CWInfo(xml.list, xml.xzq, "CW");
                LoadSY_MLInfo(xml.list, xml.xzq, "ZP");
                LoadSY_ML_WXLInfo(xml.list, xml.xzq, "ZSJM");
                LoadSY_ML_SHFWInfo(xml.list, xml.xzq, "SHFW");
                LoadSY_ML_WXLInfo(xml.list, xml.xzq, "JYPX");
                LoadSY_ML_WXLInfo(xml.list, xml.xzq, "PFCG");
                LoadSY_ML_SHFWInfo(xml.list, xml.xzq, "SWFW");
                LoadSY_MLInfo(xml.list, xml.xzq, "ES");
                $("#p_body_middle_left_title_FC").css("border-bottom", "2px solid #59d072");
                $("#p_body_middle_left_title_CL").css("border-bottom", "2px solid #44eea6");
                $("#p_body_middle_left_title_CW").css("border-bottom", "2px solid #f473de");
                $("#p_body_middle_left_title_ZP").css("border-bottom", "2px solid #00bfe1");
                $("#p_body_middle_left_title_ZSJM").css("border-bottom", "2px solid #abc466");
                $("#p_body_middle_left_title_PX").css("border-bottom", "2px solid #c49966");
                $("#p_body_middle_left_title_SHFW").css("border-bottom", "2px solid #3dbfe1");
                $("#p_body_middle_left_title_JYPX").css("border-bottom", "2px solid #fda19d");
                $("#p_body_middle_left_title_PFCG").css("border-bottom", "2px solid #eb437e");
                $("#p_body_middle_left_title_SWFW").css("border-bottom", "2px solid #d323e1");
                $("#p_body_middle_left_title_ES").css("border-bottom", "2px solid #64f4de");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载首页_目录详细信息（有小类）
function LoadSY_MLInfo(list, xzq, typename) {
    var html = "";
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "DL" && list[i].TYPENAME === typename)
            html += ('<p id="p_body_middle_left_title_' + typename + '" class="p_body_middle_left_title">' + list[i].LBNAME + '</p>');
    }
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "XL" && list[i].TYPENAME === typename) {
            html += ('<p class="p_body_middle_left_title_small">' + list[i].LBNAME + '</p>');
            html += ('<ul class="ul_body_middle_left_section" style="height: ' + GetHeight(list, list[i].ID, typename) + 'px;">');
            for (var j = 0; j < list.length; j++) {
                if (list[j].PARENTID === list[i].ID) {
                    if (list[j].ISHOT === "是")
                        html += ('<li class="li_body_middle_left_section purple" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                    else
                        html += ('<li class="li_body_middle_left_section" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                }
            }
            html += ('</ul>');
        }
    }
    $("#div_body_middle_left_" + typename).append(html);
}
//加载首页_目录详细信息（有小类_生活服务）
function LoadSY_ML_SHFWInfo(list, xzq, typename) {
    var html = "";
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "DL" && list[i].TYPENAME === typename)
            html += ('<p id="p_body_middle_left_title_' + typename + '" class="p_body_middle_left_title">' + list[i].LBNAME + '</p>');
    }
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "XL" && list[i].TYPENAME === typename) {
            html += ('<span class="span_body_middle_left_title_small_shfw">' + list[i].LBNAME + '</span>');
            html += ('<ul class="ul_body_middle_left_section_shfw" style="height: ' + GetHeight(list, list[i].ID, typename) + 'px;">');
            for (var j = 0; j < list.length; j++) {
                if (list[j].PARENTID === list[i].ID) {
                    if (list[j].ISHOT === "是")
                        html += ('<li class="li_body_middle_left_section_shfw purple" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                    else
                        html += ('<li class="li_body_middle_left_section_shfw" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                }
            }
            html += ('</ul>');
        }
    }
    $("#div_body_middle_left_" + typename).append(html);
}
//加载首页_目录详细信息（有小类_宠物）
function LoadSY_ML_CWInfo(list, xzq, typename) {
    var html = "";
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "DL" && list[i].TYPENAME === typename)
            html += ('<p id="p_body_middle_left_title_' + typename + '" class="p_body_middle_left_title">' + list[i].LBNAME + '</p>');
    }
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "XL" && list[i].TYPENAME === typename) {
            html += ('<span class="span_body_middle_left_title_small_cw">' + list[i].LBNAME + '</span>');
            html += ('<ul class="ul_body_middle_left_section_cw" style="height: ' + GetHeight(list, list[i].ID, typename) + 'px;">');
            for (var j = 0; j < list.length; j++) {
                if (list[j].PARENTID === list[i].ID) {
                    if (list[j].ISHOT === "是")
                        html += ('<li class="li_body_middle_left_section_cw purple" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                    else
                        html += ('<li class="li_body_middle_left_section_cw" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                }
            }
            html += ('</ul>');
        }
    }
    $("#div_body_middle_left_" + typename).append(html);
}
//加载首页_目录详细信息（无小类）
function LoadSY_ML_WXLInfo(list, xzq, typename) {
    var html = "";
    for (var i = 0; i < list.length; i++) {
        if (list[i].TYPE === "DL" && list[i].TYPENAME === typename) {
            html += ('<p id="p_body_middle_left_title_' + typename + '" class="p_body_middle_left_title">' + list[i].LBNAME + '</p>');
            html += ('<ul class="ul_body_middle_left_section" style="height: ' + GetHeight(list, list[i].ID, typename) + 'px;">');
            for (var j = 0; j < list.length; j++) {
                if (list[j].PARENTID === list[i].ID) {
                    if (list[j].ISHOT === "是")
                        html += ('<li style="width:90px;" class="li_body_middle_left_section orange" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                    else
                        html += ('<li style="width:90px;" class="li_body_middle_left_section" onclick="OpenCXLB(' + list[j].LBID + ',\'' + list[j].LBURL + '\',\'' + list[j].CONDITION + '\')">' + list[j].LBNAME + '</li>');
                }
            }
            html += ('</ul>');
        }
    }
    $("#div_body_middle_left_" + typename).append(html);
}
//获取高度
function GetHeight(list, parentid, typename) {
    var count = 0, height = 0;
    for (var i = 0; i < list.length; i++) {
        if (list[i].PARENTID === parentid) {
            count++;
        }
    }
    if (typename === "FC" || typename === "CL" || typename === "ZP" || typename === "ES") {
        height = parseInt((count / 7)) * 30;
        if (count % 7 !== 0) height += 30;
    }
    else if (typename === "SHFW" || typename === "SWFW") {
        height = parseInt((count / 6)) * 30;
        if (count % 6 !== 0) height += 30;
    }
    else {
        height = parseInt((count / 3)) * 30;
        if (count % 3 !== 0) height += 30;
    }
    return height;
}
//打开查询列表
function OpenCXLB(lbid, lburl, condition) {
    if (condition !== "null" && condition !== null)
        window.open(getRootPath() + "/Business" + lburl + "?LBID=" + lbid + "&" + condition);
    else
        window.open(getRootPath() + "/Business" + lburl + "?LBID=" + lbid);
}
//打开二级首页
function ToEJSY(type) {
    window.open(getRootPath() + "/Business/SY/" + type);
}
//加载搜索结果
function LoadSSJG() {
    if (event.keyCode === 40) {//按下
        var lis = $("#divSSJGlist").find("li");
        for (var i = 0; i < lis.length; i++) {
            if ($("#divSSJGlist").find("li:eq(" + i + ")").css("background-color") === "rgb(236, 236, 236)") {
                $("#divSSJGlist").find("li:eq(" + i + ")").css("background-color", "#FFFFFF");
                $("#divSSJGlist").find("li:eq(" + i + ")").bind("mouseover", function () { $(this).css("background-color", "#ececec"); });
                $("#divSSJGlist").find("li:eq(" + i + ")").bind("mouseleave", function () { $(this).css("background-color", "#FFFFFF"); });
                $("#divSSJGlist").find("li:eq(" + (i + 1) + ")").css("background-color", "#ececec");
                return;
            }
        }
        $("#divSSJGlist").find("li:eq(0)").css("background-color", "#ececec");
        return;
    }
    if (event.keyCode === 38) {//按上
        var lis = $("#divSSJGlist").find("li");
        for (var i = 0; i < lis.length; i++) {
            if ($("#divSSJGlist").find("li:eq(" + i + ")").css("background-color") === "rgb(236, 236, 236)") {
                if (i !== 0)
                    $("#divSSJGlist").find("li:eq(" + (i - 1) + ")").css("background-color", "#ececec");
                $("#divSSJGlist").find("li:eq(" + i + ")").css("background-color", "#FFFFFF");
                $("#divSSJGlist").find("li:eq(" + i + ")").bind("mouseover", function () { $(this).css("background-color", "#ececec"); });
                $("#divSSJGlist").find("li:eq(" + i + ")").bind("mouseleave", function () { $(this).css("background-color", "#FFFFFF"); });
                return;
            }
        }
        $("#divSSJGlist").find("li:eq(" + (lis.length - 1) + ")").css("background-color", "#ececec");
        return;
    }
    if (event.keyCode === 13) {//回车
        var lis = $("#divSSJGlist").find("li");
        for (var i = 0; i < lis.length; i++) {
            if ($("#divSSJGlist").find("li:eq(" + i + ")").css("background-color") === "rgb(236, 236, 236)") {
                SelectSSJG($("#divSSJGlist").find("li:eq(" + i + ")").attr("codename"), $("#divSSJGlist").find("li:eq(" + i + ")").attr("codeid"), $("#divSSJGlist").find("li:eq(" + i + ")").attr("url"), $("#divSSJGlist").find("li:eq(" + i + ")").attr("parentid"));
                return;
            }
        }
    }
    var SS = $("#SS").val();
    if (SS === "") {
        $("#divSSJGlist").css("display", "none");
        return;
    }
    if (ValidateChinese(SS)) //判断是否是汉字
        LoadKeyWordByHZ(SS);
    else
        LoadKeyWordByPY(SS);
}
//根据汉字获取关键字
function LoadKeyWordByHZ(SS) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadKeyWordByHZ",
        dataType: "json",
        data:
        {
            SS: SS
        },
        success: function (xml) {
            if (xml.Result === 1 && xml.list.length > 0) {
                var html = "<ul id='ulSSJG' class='ul_select' style='height:" + (xml.list.length > 10 ? 341 : (xml.list.length * 34.5)) + "px;'>";
                for (var i = 0; i < (xml.list.length > 10 ? 10 : xml.list.length) ; i++) {
                    var index = xml.list[i].CODENAME.indexOf(SS);
                    var xqmclength = SS.length;
                    var xqmchtml = "";
                    if (index === 0)
                        xqmchtml = "<span style='color:#333333;font-weight:bolder;'>" + SS + "</span>" + "<span style='color:#333333'>" + xml.list[i].CODENAME.substr(xqmclength, xml.list[i].CODENAME.length - SS.length) + "</span>";
                    else {
                        xqmchtml = "<span style='color:#333333'>" + xml.list[i].CODENAME.substr(0, index) + "</span>" + "<span style='color:#333333;font-weight:bolder;'>" + xml.list[i].CODENAME.substr(index, xqmclength) + "</span>" + "<span style='color:#333333'>" + xml.list[i].CODENAME.substr(index + xqmclength, xml.list[i].CODENAME.length - index - xqmclength) + "</span>";
                    }
                    html += "<li class='li_select' codename='" + xml.list[i].CODENAME + "' codeid='" + xml.list[i].CODEID + "' url='" + xml.list[i].URL + "' parentid='" + xml.list[i].PARENTID + "' onclick='SelectSSJG(\"" + xml.list[i].CODENAME + "\",\"" + xml.list[i].CODEID + "\",\"" + xml.list[i].URL + "\",\"" + xml.list[i].PARENTID + "\")'>" + xqmchtml + "&nbsp;&nbsp;<span style='color:#999999;font-size:12px;'>" + (xml.list[i].TYPENAME === null ? "" : xml.list[i].TYPENAME) + "</span>" + "</li>";
                }
                html += "</ul>";
                $("#divSSJGlist").html(html);
                $("#divSSJGlist").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//根据拼音获取关键字
function LoadKeyWordByPY(SS) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadKeyWordByPY",
        dataType: "json",
        data:
        {
            SS: SS
        },
        success: function (xml) {
            if (xml.Result === 1 && xml.list.length > 0) {
                var html = "<ul id='ulSS' class='ul_select' style='height: " + (xml.list.length * 34.5) + "px;width:594px;background-color:#ffffff'>";
                for (var i = 0; i < xml.list.length; i++) {
                    var index = 0;
                    var pys = xml.list[i].SSPY.split(' ');
                    var count = 0;
                    var sySS = SS;

                    if (xml.list[i].SSPYSZM != null && xml.list[i].SSPYSZM.indexOf(sySS) !== -1) {
                        index = GetStartIndexBySZM(xml.list[i].SSPYSZM, sySS);
                        count = sySS.length;
                    }
                    else {
                        index = GetStartIndex(pys, sySS);
                        for (var j = 0; j < pys.length; j++) {
                            if (sySS.length > pys[j].length) {
                                if (sySS.indexOf(pys[j]) !== -1) {
                                    count++;
                                    sySS = sySS.substr(pys[j].length, sySS.length - pys[j].length);
                                }
                            }
                            else {
                                if (pys[j].indexOf(sySS) !== -1 || pys[j].indexOf(sySS) !== -1) {
                                    count++;
                                    break;;
                                }
                            }
                        }
                    }
                    var getlength = count;
                    var SShtml = "";
                    if (index === 0)
                        SShtml = "<span style='color:#333333;font-weight:bolder;'>" + xml.list[i].SS.substr(0, getlength) + "</span>" + "<span style='color:#333333'>" + xml.list[i].SS.substr(getlength, xml.list[i].SS.length - getlength) + "</span>";
                    else {
                        SShtml = "<span style='color:#333333'>" + xml.list[i].SS.substr(0, index) + "</span>" + "<span style='color:#333333;font-weight:bolder;'>" + xml.list[i].SS.substr(index, getlength) + "</span>" + "<span style='color:#333333'>" + xml.list[i].SS.substr(index + getlength, xml.list[i].SS.length - index - getlength) + "</span>";
                    }
                    html += "<li class='li_select' onclick='SelectSS(this)'>" + SShtml + "&nbsp;&nbsp;<span style='color:#999999;font-size:12px;'>" + (xml.list[i].XQDZ === null ? "" : xml.list[i].XQDZ) + "</span>" + "</li>";
                }
                html += "</ul>";
                $("#divSSJGlist").html(html);
                $("#divSSJGlist").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//获取开始索引
function GetStartIndex(pys, sqmc) {
    var index = 0;
    for (var j = 0; j < pys.length; j++) {
        if (sqmc.length > pys[j].length) {
            if (sqmc.indexOf(pys[j]) !== -1) {
                index = j;
                break;;
            }
        }
        else {
            if (pys[j].indexOf(sqmc) !== -1 || pys[j].indexOf(sqmc) !== -1) {
                index = j;
                break;;
            }
        }
    }
    return index;
}
//根据首字母获取开始索引
function GetStartIndexBySZM(pyszm, sqmc) {
    return pyszm.indexOf(sqmc);
}
//选择关键字
function SelectSSJG(codename, codeid, url, parentid) {
    $("#SS").val(codename);
    $("#LBID").val(codeid);
    $("#URL").val(url);
    $("#divSSJGlist").css("display", "none");
}
//打开搜索结果
function OpenSSJG() {
    var url = "";
    if ($("#URL").val().split('_')[0] === "ES") {
        url = "/" + $("#URL").val().split('_')[0] + "CX/" + $("#URL").val().split('_')[0] + "CX_" + $("#URL").val().split('_')[1] + "_" + $("#URL").val().split('_')[2];
    }
    else {
        url = "/" + $("#URL").val().split('_')[0] + "CX/" + $("#URL").val().split('_')[0] + "CX_" + $("#URL").val().split('_')[1];
    }

    var condition = "";
    OpenCXLB($("#LBID").val(), url, condition)
}