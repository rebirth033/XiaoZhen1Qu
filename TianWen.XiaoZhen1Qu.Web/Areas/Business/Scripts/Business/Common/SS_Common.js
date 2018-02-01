$(document).ready(function () {
    $("#SS").bind("keyup", LoadSSJG);
    $("#HideSS").bind("keyup", LoadHideSSJG);
    $("#span_ss").bind("click", OpenSSJG);
    $("#span_hide_ss").bind("click", OpenHideSSJG);
});
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
                SelectSSJG($("#divSSJGlist").find("li:eq(" + i + ")").attr("codename"), $("#divSSJGlist").find("li:eq(" + i + ")").attr("codeid"), $("#divSSJGlist").find("li:eq(" + i + ")").attr("url"), $("#divSSJGlist").find("li:eq(" + i + ")").attr("parentid"), $("#divSSJGlist").find("li:eq(" + i + ")").attr("condition"));
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
//加载搜索结果
function LoadHideSSJG() {
    if (event.keyCode === 40) {//按下
        var lis = $("#divHideSSJGlist").find("li");
        for (var i = 0; i < lis.length; i++) {
            if ($("#divHideSSJGlist").find("li:eq(" + i + ")").css("background-color") === "rgb(236, 236, 236)") {
                $("#divHideSSJGlist").find("li:eq(" + i + ")").css("background-color", "#FFFFFF");
                $("#divHideSSJGlist").find("li:eq(" + i + ")").bind("mouseover", function () { $(this).css("background-color", "#ececec"); });
                $("#divHideSSJGlist").find("li:eq(" + i + ")").bind("mouseleave", function () { $(this).css("background-color", "#FFFFFF"); });
                $("#divHideSSJGlist").find("li:eq(" + (i + 1) + ")").css("background-color", "#ececec");
                return;
            }
        }
        $("#divHideSSJGlist").find("li:eq(0)").css("background-color", "#ececec");
        return;
    }
    if (event.keyCode === 38) {//按上
        var lis = $("#divHideSSJGlist").find("li");
        for (var i = 0; i < lis.length; i++) {
            if ($("#divHideSSJGlist").find("li:eq(" + i + ")").css("background-color") === "rgb(236, 236, 236)") {
                if (i !== 0)
                    $("#divHideSSJGlist").find("li:eq(" + (i - 1) + ")").css("background-color", "#ececec");
                $("#divHideSSJGlist").find("li:eq(" + i + ")").css("background-color", "#FFFFFF");
                $("#divHideSSJGlist").find("li:eq(" + i + ")").bind("mouseover", function () { $(this).css("background-color", "#ececec"); });
                $("#divHideSSJGlist").find("li:eq(" + i + ")").bind("mouseleave", function () { $(this).css("background-color", "#FFFFFF"); });
                return;
            }
        }
        $("#divHideSSJGlist").find("li:eq(" + (lis.length - 1) + ")").css("background-color", "#ececec");
        return;
    }
    if (event.keyCode === 13) {//回车
        var lis = $("#divHideSSJGlist").find("li");
        for (var i = 0; i < lis.length; i++) {
            if ($("#divHideSSJGlist").find("li:eq(" + i + ")").css("background-color") === "rgb(236, 236, 236)") {
                SelectHideSSJG($("#divHideSSJGlist").find("li:eq(" + i + ")").attr("codename"), $("#divHideSSJGlist").find("li:eq(" + i + ")").attr("codeid"), $("#divHideSSJGlist").find("li:eq(" + i + ")").attr("url"), $("#divHideSSJGlist").find("li:eq(" + i + ")").attr("parentid"), $("#divHideSSJGlist").find("li:eq(" + i + ")").attr("condition"));
                return;
            }
        }
    }
    var SS = $("#HideSS").val();
    if (SS === "") {
        $("#divHideSSJGlist").css("display", "none");
        return;
    }
    if (ValidateChinese(SS)) //判断是否是汉字
        LoadHideKeyWordByHZ(SS);
    else
        LoadHideKeyWordByPY(SS);
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
                    html += "<li class='li_select' codename='" + xml.list[i].CODENAME + "' codeid='" + xml.list[i].CODEID + "' url='" + xml.list[i].URL + "' parentid='" + xml.list[i].PARENTID + "' condition='" + xml.list[i].CONDITION + "' onclick='SelectSSJG(\"" + xml.list[i].CODENAME + "\",\"" + xml.list[i].CODEID + "\",\"" + xml.list[i].URL + "\",\"" + xml.list[i].PARENTID + "\",\"" + xml.list[i].CONDITION + "\")'>" + xqmchtml + "&nbsp;&nbsp;<span style='color:#999999;font-size:12px;'>" + RTrimStr((xml.list[i].TYPENAME === null ? "" : xml.list[i].TYPENAME), "类别") + "</span>" + "</li>";
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
//根据汉字获取关键字
function LoadHideKeyWordByHZ(SS) {
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
                var html = "<ul id='ulHideSSJG' class='ul_select' style='position:relative;left:-1px;width:503px;height:" + (xml.list.length > 10 ? 341 : (xml.list.length * 34.5)) + "px;'>";
                for (var i = 0; i < (xml.list.length > 10 ? 10 : xml.list.length) ; i++) {
                    var index = xml.list[i].CODENAME.indexOf(SS);
                    var xqmclength = SS.length;
                    var xqmchtml = "";
                    if (index === 0)
                        xqmchtml = "<span style='color:#333333;font-weight:bolder;'>" + SS + "</span>" + "<span style='color:#333333'>" + xml.list[i].CODENAME.substr(xqmclength, xml.list[i].CODENAME.length - SS.length) + "</span>";
                    else {
                        xqmchtml = "<span style='color:#333333'>" + xml.list[i].CODENAME.substr(0, index) + "</span>" + "<span style='color:#333333;font-weight:bolder;'>" + xml.list[i].CODENAME.substr(index, xqmclength) + "</span>" + "<span style='color:#333333'>" + xml.list[i].CODENAME.substr(index + xqmclength, xml.list[i].CODENAME.length - index - xqmclength) + "</span>";
                    }
                    html += "<li class='li_select' codename='" + xml.list[i].CODENAME + "' codeid='" + xml.list[i].CODEID + "' url='" + xml.list[i].URL + "' parentid='" + xml.list[i].PARENTID + "' condition='" + xml.list[i].CONDITION + "' onclick='SelectHideSSJG(\"" + xml.list[i].CODENAME + "\",\"" + xml.list[i].CODEID + "\",\"" + xml.list[i].URL + "\",\"" + xml.list[i].PARENTID + "\",\"" + xml.list[i].CONDITION + "\")'>" + xqmchtml + "&nbsp;&nbsp;<span style='color:#999999;font-size:12px;'>" + RTrimStr((xml.list[i].TYPENAME === null ? "" : xml.list[i].TYPENAME), "类别") + "</span>" + "</li>";
                }
                html += "</ul>";
                $("#divHideSSJGlist").html(html);
                $("#divHideSSJGlist").css("display", "block");
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
                var html = "<ul id='ulSSJG' class='ul_select' style='height:" + (xml.list.length > 10 ? 341 : (xml.list.length * 34.5)) + "px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    var index = 0;
                    var pys = xml.list[i].CODENAMEPY.split(' ');
                    var count = 0;
                    var sySS = SS;

                    if (xml.list[i].CODENAMEPYSZM != null && xml.list[i].CODENAMEPYSZM.indexOf(sySS) !== -1) {
                        index = GetStartIndexBySZM(xml.list[i].CODENAMEPYSZM, sySS);
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
                        SShtml = "<span style='color:#333333;font-weight:bolder;'>" + xml.list[i].CODENAME.substr(0, getlength) + "</span>" + "<span style='color:#333333'>" + xml.list[i].CODENAME.substr(getlength, xml.list[i].CODENAME.length - getlength) + "</span>";
                    else {
                        SShtml = "<span style='color:#333333'>" + xml.list[i].CODENAME.substr(0, index) + "</span>" + "<span style='color:#333333;font-weight:bolder;'>" + xml.list[i].CODENAME.substr(index, getlength) + "</span>" + "<span style='color:#333333'>" + xml.list[i].CODENAME.substr(index + getlength, xml.list[i].CODENAME.length - index - getlength) + "</span>";
                    }
                    html += "<li class='li_select' codename='" + xml.list[i].CODENAME + "' codeid='" + xml.list[i].CODEID + "' url='" + xml.list[i].URL + "' parentid='" + xml.list[i].PARENTID + "' condition='" + xml.list[i].CONDITION + "' onclick='SelectSSJG(\"" + xml.list[i].CODENAME + "\",\"" + xml.list[i].CODEID + "\",\"" + xml.list[i].URL + "\",\"" + xml.list[i].PARENTID + "\",\"" + xml.list[i].CONDITION + "\")'>" + SShtml + "&nbsp;&nbsp;<span style='color:#999999;font-size:12px;'>" + RTrimStr((xml.list[i].TYPENAME === null ? "" : xml.list[i].TYPENAME), "类别") + "</span>" + "</li>";
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
function LoadHideKeyWordByPY(SS) {
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
                var html = "<ul id='ulHideSSJG' class='ul_select' style='position:relative;left:-1px;width:503px;height:" + (xml.list.length > 10 ? 341 : (xml.list.length * 34.5)) + "px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    var index = 0;
                    var pys = xml.list[i].CODENAMEPY.split(' ');
                    var count = 0;
                    var sySS = SS;

                    if (xml.list[i].CODENAMEPYSZM != null && xml.list[i].CODENAMEPYSZM.indexOf(sySS) !== -1) {
                        index = GetStartIndexBySZM(xml.list[i].CODENAMEPYSZM, sySS);
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
                        SShtml = "<span style='color:#333333;font-weight:bolder;'>" + xml.list[i].CODENAME.substr(0, getlength) + "</span>" + "<span style='color:#333333'>" + xml.list[i].CODENAME.substr(getlength, xml.list[i].CODENAME.length - getlength) + "</span>";
                    else {
                        SShtml = "<span style='color:#333333'>" + xml.list[i].CODENAME.substr(0, index) + "</span>" + "<span style='color:#333333;font-weight:bolder;'>" + xml.list[i].CODENAME.substr(index, getlength) + "</span>" + "<span style='color:#333333'>" + xml.list[i].CODENAME.substr(index + getlength, xml.list[i].CODENAME.length - index - getlength) + "</span>";
                    }
                    html += "<li class='li_select' codename='" + xml.list[i].CODENAME + "' codeid='" + xml.list[i].CODEID + "' url='" + xml.list[i].URL + "' parentid='" + xml.list[i].PARENTID + "' condition='" + xml.list[i].CONDITION + "' onclick='SelectHideSSJG(\"" + xml.list[i].CODENAME + "\",\"" + xml.list[i].CODEID + "\",\"" + xml.list[i].URL + "\",\"" + xml.list[i].PARENTID + "\",\"" + xml.list[i].CONDITION + "\")'>" + SShtml + "&nbsp;&nbsp;<span style='color:#999999;font-size:12px;'>" + RTrimStr((xml.list[i].TYPENAME === null ? "" : xml.list[i].TYPENAME), "类别") + "</span>" + "</li>";
                }
                html += "</ul>";
                $("#divHideSSJGlist").html(html);
                $("#divHideSSJGlist").css("display", "block");
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
function SelectSSJG(codename, codeid, url, parentid, condition) {
    $("#SS").val(codename);
    $("#LBID").val(parentid);
    $("#URL").val(url);
    $("#CONDITION").val(condition);
    $("#divSSJGlist").css("display", "none");
}
//选择关键字
function SelectHideSSJG(codename, codeid, url, parentid, condition) {
    $("#HideSS").val(codename);
    $("#HideLBID").val(parentid);
    $("#HideURL").val(url);
    $("#HideCONDITION").val(condition);
    $("#divHideSSJGlist").css("display", "none");
}
//打开搜索结果
function OpenSSJG() {
    if ($("#LBID").val() !== "")
        OpenSSJGBySelect();
    else
        OpenSSJGByInput();
}
//打开隐藏搜索结果
function OpenHideSSJG() {
    if ($("#HideLBID").val() !== "")
        OpenHideSSJGBySelect();
    else
        OpenHideSSJGByInput();
}
//根据下拉框选择的关键字搜索结果
function OpenSSJGBySelect() {
    var url = "";
    if ($("#URL").val().split('_')[0] === "ES") {
        url = "/" + $("#URL").val().split('_')[0] + "CX/" + $("#URL").val().split('_')[0] + "CX_" + $("#URL").val().split('_')[1] + "_" + $("#URL").val().split('_')[2];
    }
    else {
        url = "/" + $("#URL").val().split('_')[0] + "CX/" + $("#URL").val().split('_')[0] + "CX_" + $("#URL").val().split('_')[1];
    }
    var condition = $("#CONDITION").val();
    OpenCXLB($("#LBID").val(), url, condition);
}
//根据下拉框选择的关键字搜索结果
function OpenHideSSJGBySelect() {
    var url = "";
    if ($("#HideURL").val().split('_')[0] === "ES") {
        url = "/" + $("#HideURL").val().split('_')[0] + "CX/" + $("#HideURL").val().split('_')[0] + "CX_" + $("#HideURL").val().split('_')[1] + "_" + $("#HideURL").val().split('_')[2];
    }
    else {
        url = "/" + $("#HideURL").val().split('_')[0] + "CX/" + $("#HideURL").val().split('_')[0] + "CX_" + $("#HideURL").val().split('_')[1];
    }
    var condition = $("#HideCONDITION").val();
    OpenHideCXLB($("#HideLBID").val(), url, condition);
}
//根据输入的关键字搜索结果
function OpenSSJGByInput() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadKeyWordByHZ",
        dataType: "json",
        data:
        {
            SS: $("#SS").val()
        },
        success: function (xml) {
            if (xml.Result === 1 && xml.list.length > 0) {
                SelectSSJG(xml.list[0].CODENAME, xml.list[0].CODEID, xml.list[0].URL, xml.list[0].PARENTID, xml.list[0].CONDITION);
                var url = "";
                if ($("#URL").val().split('_')[0] === "ES") {
                    url = "/" + $("#URL").val().split('_')[0] + "CX/" + $("#URL").val().split('_')[0] + "CX_" + $("#URL").val().split('_')[1] + "_" + $("#URL").val().split('_')[2];
                }
                else {
                    url = "/" + $("#URL").val().split('_')[0] + "CX/" + $("#URL").val().split('_')[0] + "CX_" + $("#URL").val().split('_')[1];
                }
                OpenCXLB($("#LBID").val(), url, $("#CONDITION").val());
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//根据输入的关键字搜索结果
function OpenHideSSJGByInput() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SY/LoadKeyWordByHZ",
        dataType: "json",
        data:
        {
            SS: $("#HideSS").val()
        },
        success: function (xml) {
            if (xml.Result === 1 && xml.list.length > 0) {
                SelectSSJG(xml.list[0].CODENAME, xml.list[0].CODEID, xml.list[0].URL, xml.list[0].PARENTID, xml.list[0].CONDITION);
                var url = "";
                if ($("#HideURL").val().split('_')[0] === "ES") {
                    url = "/" + $("#HideURL").val().split('_')[0] + "CX/" + $("#HideURL").val().split('_')[0] + "CX_" + $("#HideURL").val().split('_')[1] + "_" + $("#HideURL").val().split('_')[2];
                }
                else {
                    url = "/" + $("#HideURL").val().split('_')[0] + "CX/" + $("#HideURL").val().split('_')[0] + "CX_" + $("#HideURL").val().split('_')[1];
                }
                OpenHideCXLB($("#HideLBID").val(), url, $("#HideCONDITION").val());
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//打开查询列表
function OpenCXLB(lbid, lburl, condition) {
    if (condition !== "null" && condition !== null)
        window.open(getRootPath() + "/Business" + lburl + "?LBID=" + lbid + "&" + condition);
    else
        window.open(getRootPath() + "/Business" + lburl + "?LBID=" + lbid);
    $("#LBID").val('');
}
//打开查询列表
function OpenHideCXLB(lbid, lburl, condition) {
    if (condition !== "null" && condition !== null)
        window.open(getRootPath() + "/Business" + lburl + "?LBID=" + lbid + "&" + condition);
    else
        window.open(getRootPath() + "/Business" + lburl + "?LBID=" + lbid);
    $("#HideLBID").val('');
}