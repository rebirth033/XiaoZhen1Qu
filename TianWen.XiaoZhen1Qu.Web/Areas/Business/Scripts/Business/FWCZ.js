var isleave = true;
$(document).ready(function () {
    $("#XQMC").bind("keyup", LoadXQMC);
    $("#spanCXLB").bind("click", CXLB);
    $("#imgZTCZ").bind("click", ZTCZSelect);
    $("#imgDJCZ").bind("click", DJCZSelect);
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    $(".inputLCFB").bind("focus", FWLXYLCFBFocus);
    $(".inputLCFB").bind("blur", FWLXYLCFBBlur);
    $(".inputFWLX").bind("focus", FWLXYLCFBFocus);
    $(".inputFWLX").bind("blur", FWLXYLCFBBlur);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#KRZSJ").datepicker({ minDate: 0 });
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);


    BindHover();
    LoadTXXX();
    LoadFWCX();
    LoadZXQK();
    LoadZZLX();
    LoadYFFS();
    LoadBHFY();
    LoadDefault();
    FYMSSetDefault();
});

function FYMSFocus() {
    $("#FYMS").css("color", "#333333");
}

function FYMSBlur() {
    $("#FYMS").css("color", "#999999");
}

function FYMSSetDefault() {
    var fyms = "1.房屋特征：\r\n\r\n2.周边配套：\r\n\r\n3.房东心态：";
    $("#FYMS").html(fyms);
}

function FWLXYLCFBFocus() {
    if ($(this)[0].id === "C")
        $("#spanC").css("border", "1px solid #5bc0de");
    if ($(this)[0].id === "GJC")
        $("#spanGJC").css("border", "1px solid #5bc0de");
    if ($(this)[0].id === "ZJ")
        $("#spanZJ").css("border", "1px solid #5bc0de");
    if ($(this)[0].id === "S")
        $("#spanS").css("border", "1px solid #5bc0de");
    if ($(this)[0].id === "T")
        $("#spanT").css("border", "1px solid #5bc0de");
    if ($(this)[0].id === "W")
        $("#spanW").css("border", "1px solid #5bc0de");
    if ($(this)[0].id === "PFM")
        $("#spanPFM").css("border", "1px solid #5bc0de");

}

function FWLXYLCFBBlur() {
    if ($(this)[0].id === "C")
        $("#spanC").css("border", "1px solid #cccccc");
    if ($(this)[0].id === "GJC")
        $("#spanGJC").css("border", "1px solid #cccccc");
    if ($(this)[0].id === "ZJ")
        $("#spanZJ").css("border", "1px solid #cccccc");
    if ($(this)[0].id === "S")
        $("#spanS").css("border", "1px solid #cccccc");
    if ($(this)[0].id === "T")
        $("#spanT").css("border", "1px solid #cccccc");
    if ($(this)[0].id === "W")
        $("#spanW").css("border", "1px solid #cccccc");
    if ($(this)[0].id === "PFM")
        $("#spanPFM").css("border", "1px solid #cccccc");
}

function LoadDefault() {
    $("#imgZTCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgDJCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}

function LoadTXXX() {
    $("#spanTXXX").css("color", "#5bc0de");
    $("#emTXXX").css("background", "#5bc0de");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LBXZ/LoadLBByID",
        dataType: "json",
        data:
        {
            LBID: getUrlParam("CLICKID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                if (xml.list.length > 0)
                    $("#spanLBXZ").html("1." + xml.list[0].LBNAME);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function CXLB() {
    window.location.href = getRootPath() + "/Business/LBXZ/LBXZ";
}

function ZTCZSelect() {
    $("#imgZTCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgDJCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}

function DJCZSelect() {
    $("#imgZTCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgDJCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}

function LoadXQMC() {
    if (event.keyCode === 40) {//按下
        var lis = $("#divXQMClist").find("li");
        for (var i = 0; i < lis.length; i++) {
            if ($("#divXQMClist").find("li:eq(" + i + ")").css("background-color") === "rgb(236, 236, 236)") {
                $("#divXQMClist").find("li:eq(" + i + ")").css("background-color", "#FFFFFF");
                $("#divXQMClist").find("li:eq(" + i + ")").bind("mouseover", function () { $(this).css("background-color", "#ececec"); });
                $("#divXQMClist").find("li:eq(" + i + ")").bind("mouseleave", function () { $(this).css("background-color", "#FFFFFF"); });
                $("#divXQMClist").find("li:eq(" + (i + 1) + ")").css("background-color", "#ececec");
                return;
            }
        }
        $("#divXQMClist").find("li:eq(0)").css("background-color", "#ececec");
        return;
    }
    if (event.keyCode === 38) {//按上
        var lis = $("#divXQMClist").find("li");
        for (var i = 0; i < lis.length; i++) {
            if ($("#divXQMClist").find("li:eq(" + i + ")").css("background-color") === "rgb(236, 236, 236)") {
                if (i !== 0)
                    $("#divXQMClist").find("li:eq(" + (i - 1) + ")").css("background-color", "#ececec");
                $("#divXQMClist").find("li:eq(" + i + ")").css("background-color", "#FFFFFF");
                $("#divXQMClist").find("li:eq(" + i + ")").bind("mouseover", function () { $(this).css("background-color", "#ececec"); });
                $("#divXQMClist").find("li:eq(" + i + ")").bind("mouseleave", function () { $(this).css("background-color", "#FFFFFF"); });
                return;
            }
        }
        $("#divXQMClist").find("li:eq(" + (lis.length - 1) + ")").css("background-color", "#ececec");
        return;
    }
    if (event.keyCode === 13) {//回车
        var lis = $("#divXQMClist").find("li");
        for (var i = 0; i < lis.length; i++) {
            if ($("#divXQMClist").find("li:eq(" + i + ")").css("background-color") === "rgb(236, 236, 236)") {
                SelectXQMC($("#divXQMClist").find("li:eq(" + i + ")"));
                return;
            }
        }
    }
    var XQMC = $("#XQMC").val();
    if (XQMC === "") {
        $("#divXQMClist").css("display", "none");
        return;
    }
    if (ValidateChinese(XQMC)) //判断是否是汉字
        LoadXQJBXXSByHZ(XQMC);
    else
        LoadXQJBXXSByPY(XQMC);
}

//根据汉字获取小区信息
function LoadXQJBXXSByHZ(XQMC) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FWCZ/LoadXQJBXXSByHZ",
        dataType: "json",
        data:
        {
            XQMC: XQMC
        },
        success: function (xml) {
            if (xml.Result === 1 && xml.list.length > 0) {
                var html = "<ul id='ulXQMC' onmouseover='MouseOver()' onmouseleave='MouseLeave()' class='uldropdown' style='height: " + (xml.list.length * 34.5) + "px;width:594px;background-color:#ffffff'>";
                for (var i = 0; i < xml.list.length; i++) {
                    var index = xml.list[i].XQMC.indexOf(XQMC);
                    var xqmclength = XQMC.length;
                    var xqmchtml = "";
                    if (index === 0)
                        xqmchtml = "<span style='color:#333333;font-weight:bolder;'>" + XQMC + "</span>" + "<span style='color:#333333'>" + xml.list[i].XQMC.substr(xqmclength, xml.list[i].XQMC.length - XQMC.length) + "</span>";
                    else {
                        xqmchtml = "<span style='color:#333333'>" + xml.list[i].XQMC.substr(0, index) + "</span>" + "<span style='color:#333333;font-weight:bolder;'>" + xml.list[i].XQMC.substr(index, xqmclength) + "</span>" + "<span style='color:#333333'>" + xml.list[i].XQMC.substr(index + xqmclength, xml.list[i].XQMC.length - index - xqmclength) + "</span>";
                    }
                    html += "<li class='lidropdown' onmouseover='UnbindBlur(this)' onclick='SelectXQMC(this)'>" + xqmchtml + "&nbsp;&nbsp;<span style='color:#999999;font-size:12px;'>" + (xml.list[i].XQDZ === null ? "" : xml.list[i].XQDZ) + "</span>" + "</li>";
                }
                html += "</ul>";
                $("#divXQMClist").html(html);
                $("#divXQMClist").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//根据拼音获取小区信息
function LoadXQJBXXSByPY(XQMC) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FWCZ/LoadXQJBXXSByPY",
        dataType: "json",
        data:
        {
            XQMC: XQMC
        },
        success: function (xml) {
            if (xml.Result === 1 && xml.list.length > 0) {
                var html = "<ul id='ulXQMC' onmouseover='MouseOver()' onmouseleave='MouseLeave()' class='uldropdown' style='height: " + (xml.list.length * 34.5) + "px;width:594px;background-color:#ffffff'>";
                for (var i = 0; i < xml.list.length; i++) {
                    var index = 0;
                    var pys = xml.list[i].XQMCPY.split(' ');
                    var count = 0;
                    var syxqmc = XQMC;

                    if (xml.list[i].XQMCPYSZM != null && xml.list[i].XQMCPYSZM.indexOf(syxqmc) !== -1) {
                        index = GetStartIndexBySZM(xml.list[i].XQMCPYSZM, syxqmc);
                        count = syxqmc.length;
                    }
                    else {
                        index = GetStartIndex(pys, syxqmc);
                        for (var j = 0; j < pys.length; j++) {
                            if (syxqmc.length > pys[j].length) {
                                if (syxqmc.indexOf(pys[j]) !== -1) {
                                    count++;
                                    syxqmc = syxqmc.substr(pys[j].length, syxqmc.length - pys[j].length);
                                }
                            }
                            else {
                                if (pys[j].indexOf(syxqmc) !== -1 || pys[j].indexOf(syxqmc) !== -1) {
                                    count++;
                                    break;;
                                }
                            }
                        }
                    }
                    var getlength = count;
                    var xqmchtml = "";
                    if (index === 0)
                        xqmchtml = "<span style='color:#333333;font-weight:bolder;'>" + xml.list[i].XQMC.substr(0, getlength) + "</span>" + "<span style='color:#333333'>" + xml.list[i].XQMC.substr(getlength, xml.list[i].XQMC.length - getlength) + "</span>";
                    else {
                        xqmchtml = "<span style='color:#333333'>" + xml.list[i].XQMC.substr(0, index) + "</span>" + "<span style='color:#333333;font-weight:bolder;'>" + xml.list[i].XQMC.substr(index, getlength) + "</span>" + "<span style='color:#333333'>" + xml.list[i].XQMC.substr(index + getlength, xml.list[i].XQMC.length - index - getlength) + "</span>";
                    }
                    html += "<li class='lidropdown' onclick='SelectXQMC(this)'>" + xqmchtml + "&nbsp;&nbsp;<span style='color:#999999;font-size:12px;'>" + (xml.list[i].XQDZ === null ? "" : xml.list[i].XQDZ) + "</span>" + "</li>";
                }
                html += "</ul>";
                $("#divXQMClist").html(html);
                $("#divXQMClist").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

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

function GetStartIndexBySZM(pyszm, sqmc) {
    return pyszm.indexOf(sqmc);
}

function LoadFWCX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FWCZ/LoadCODES",
        dataType: "json",
        data:
        {
            TYPENAME: "朝向"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";//<li class='lidropdown'>请选择朝向</li>
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectFWCX(this)'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divFWCX").html(html);
                $("#divFWCX").css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function LoadZXQK() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FWCZ/LoadCODES",
        dataType: "json",
        data:
        {
            TYPENAME: "装修情况"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='height: 171px;'>";//<li class='lidropdown'>请选择装修情况</li>
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectZXQK(this)'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divZXQK").html(html);
                $("#divZXQK").css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function LoadZZLX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FWCZ/LoadCODES",
        dataType: "json",
        data:
        {
            TYPENAME: "住宅类型"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";//<li class='lidropdown'>请选择住宅类型</li>
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectZZLX(this)'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divZZLX").html(html);
                $("#divZZLX").css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function LoadYFFS() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FWCZ/LoadCODES",
        dataType: "json",
        data:
        {
            TYPENAME: "押付方式"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";//<li class='lidropdown'>请选择住宅类型</li>
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectYFFS(this)'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divYFFS").html(html);
                $("#divYFFS").css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function LoadBHFY() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FWCZ/LoadCODES",
        dataType: "json",
        data:
        {
            TYPENAME: "包含费用"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liFWPZ' onclick='SelectFWPZ(this)'>" + xml.list[i].CODENAME + "</li>";
                    if (i === 5 || i === 11) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divBHFYText").html(html);
            }
            LoadFWPZ();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function LoadFWPZ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FWCZ/LoadCODES",
        dataType: "json",
        data:
        {
            TYPENAME: "房屋配置"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liFWPZ' onclick='SelectFWPZ(this)'>" + xml.list[i].CODENAME + "</li>";
                    if (i === 5 || i === 11) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divFWPZText").html(html);
            }
            LoadFWLD();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function LoadFWLD() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FWCZ/LoadCODES",
        dataType: "json",
        data:
        {
            TYPENAME: "房屋亮点"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liFWPZ' onclick='SelectFWPZ(this)'>" + xml.list[i].CODENAME + "</li>";
                    if (i === 5 || i === 11) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divFWLDText").html(html);
            }
            LoadCZYQ();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function LoadCZYQ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FWCZ/LoadCODES",
        dataType: "json",
        data:
        {
            TYPENAME: "出租要求"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liFWPZ' onclick='SelectFWPZ(this)'>" + xml.list[i].CODENAME + "</li>";
                    if (i === 5 || i === 11) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divCZYQText").html(html);
            }
            LoadFWCZXX();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function HoverStyle(name) {
    $("#div" + name + "Text").css("border-top", "1px solid #5bc0de").css("border-right", "1px solid #5bc0de").css("border-left", "1px solid #5bc0de").css("border-bottom", "1px solid #5bc0de");
    $("#div" + name).find("ul").css("border-left", "1px solid #5bc0de").css("border-right", "1px solid #5bc0de").css("border-bottom", "1px solid #5bc0de");
    $("#span" + name).css("color", "#333333");
}

function LeaveStyle(name) {
    $("#div" + name + "Text").css("border-top", "1px solid #cccccc").css("border-right", "1px solid #cccccc").css("border-left", "1px solid #cccccc").css("border-bottom", "1px solid #cccccc");
    $("#div" + name).find("ul").css("border-left", "1px solid #cccccc").css("border-right", "1px solid #cccccc").css("border-bottom", "1px solid #cccccc");
    $("#span" + name).css("color", "#999999");
}

function BindHover() {
    $("#divFWCXText").hover(function () {
        $("#divFWCX").css("display", "block");
        HoverStyle("FWCX");
    }, function () {
        $("#divFWCX").css("display", "none");
        LeaveStyle("FWCX");
    });
    $("#divFWCX").hover(function () {
        $("#divFWCX").css("display", "block");
        HoverStyle("FWCX");
    }, function () {
        $("#divFWCX").css("display", "none");
        LeaveStyle("FWCX");
    });
    $("#divZXQKText").hover(function () {
        $("#divZXQK").css("display", "block");
        HoverStyle("ZXQK");
    }, function () {
        $("#divZXQK").css("display", "none");
        LeaveStyle("ZXQK");
    });
    $("#divZXQK").hover(function () {
        $("#divZXQK").css("display", "block");
        HoverStyle("ZXQK");
    }, function () {
        $("#divZXQK").css("display", "none");
        LeaveStyle("ZXQK");
    });
    $("#divZZLXText").hover(function () {
        $("#divZZLX").css("display", "block");
        HoverStyle("ZZLX");
    }, function () {
        $("#divZZLX").css("display", "none");
        LeaveStyle("ZZLX");
    });
    $("#divZZLX").hover(function () {
        $("#divZZLX").css("display", "block");
        HoverStyle("ZZLX");
    }, function () {
        $("#divZZLX").css("display", "none");
        LeaveStyle("ZZLX");
    });
    $("#divYFFSText").hover(function () {
        $("#divYFFS").css("display", "block");
        HoverStyle("YFFS");
    }, function () {
        $("#divYFFS").css("display", "none");
        LeaveStyle("YFFS");
    });
    $("#divYFFS").hover(function () {
        $("#divYFFS").css("display", "block");
        HoverStyle("YFFS");
    }, function () {
        $("#divYFFS").css("display", "none");
        LeaveStyle("YFFS");
    });
}

function SelectXQMC(obj) {
    var html = "";
    for (var i = 0; i < $(obj).find("span").length - 1; i++) {
        html += $(obj).find("span")[i].innerHTML;
    }
    $("#XQMC").val(html);
    $("#divXQMClist").css("display", "none");
    isleave = true;
}

function SelectFWCX(obj) {
    $("#spanFWCX").html(obj.innerHTML);
    $("#divFWCX").css("display", "none");
}

function SelectZXQK(obj) {
    $("#spanZXQK").html(obj.innerHTML);
    $("#divZXQK").css("display", "none");
}

function SelectZZLX(obj) {
    $("#spanZZLX").html(obj.innerHTML);
    $("#divZZLX").css("display", "none");
}

function SelectYFFS(obj) {
    $("#spanYFFS").html(obj.innerHTML);
    $("#divYFFS").css("display", "none");
}

function SelectFWPZ(obj) {
    if ($(obj).css("color") === "rgb(51, 51, 51)")
        $(obj).css("color", "#5bc0de");
    else
        $(obj).css("color", "#333333");
}

function GetUploadCss() {
    $("#divUploadOut").css("border-color", "#5bc0de");
}

function LeaveUploadCss() {
    $("#divUploadOut").css("border-color", "#cccccc");
}

function GetDX(type) {
    var result = "";
    $("#div" + type + "Text").find("li").each(function (i) {
        if ($(this).css("color") !== "rgb(51, 51, 51)")
            result += i + ",";
    });
    return result.substr(0, result.length - 1);
}

function SetDX(type, value) {
    var result = "";
    var values = value.split(',');
    $("#div" + type + "Text").find("li").each(function (i) {
        if (values.contains(i))
            $(this).css("color", "#5bc0de");
    });
    return result.substr(0, result.length - 1);
}

function GetCZFS() {
    if ($("#imgZTCZ").css("background-position") === "-67px -57px")
        return "0";
    else
        return "1";
}

function SetCZFS(CZFS) {
    if (CZFS === 0) {
        $("#imgZTCZ").css("background-position", "-67px -57px");
        $("#imgDJCZ").css("background-position", "-67px 0px");
    }
    else {
        $("#imgZTCZ").css("background-position", "-67px 0px");
        $("#imgDJCZ").css("background-position", "-67px -57px");
    }
}

function LoadFWCZXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FWCZ/LoadFWCZXX",
        dataType: "json",
        data:
        {
            FWCZID: getUrlParam("FWCZID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.FWCZXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#FWCZID").val(xml.Value.FWCZXX.FWCZID);
                if (xml.Value.FWCZXX.ZJYBHFY !== null)
                    SetDX("BHFY", xml.Value.FWCZXX.ZJYBHFY);
                if (xml.Value.FWCZXX.FWPZ !== null)
                    SetDX("FWPZ", xml.Value.FWCZXX.FWPZ);
                if (xml.Value.FWCZXX.FWLD !== null)
                    SetDX("FWLD", xml.Value.FWCZXX.FWLD);
                if (xml.Value.FWCZXX.CZYQ !== null)
                    SetDX("CZYQ", xml.Value.FWCZXX.CZYQ);
                SetCZFS(xml.Value.FWCZXX.CZFS);
                $("#spanFWCX").html(xml.Value.FWCZXX.CX);
                $("#spanZXQK").html(xml.Value.FWCZXX.ZXQK);
                $("#spanZZLX").html(xml.Value.FWCZXX.ZZLX);
                $("#spanYFFS").html(xml.Value.FWCZXX.YFFS);
                $("#FYMS").html(xml.Value.FWCZXX.FYMS);
                if (xml.Value.FWCZXX.KRZSJ.ToString("yyyy-MM-dd") !== "1-1-1")
                    $("#KRZSJ").val(xml.Value.FWCZXX.KRZSJ.ToString("yyyy-MM-dd"));
                LoadPhotos(xml.Value.Photos);
                return;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });

}

function MouseOver() {
    isleave = false;
}

function MouseLeave() {
    isleave = true;
}

function GetPhotoUrls() {
    var photourls = "";
    $("#ulImgs1").find("img").each(function () {
        photourls += $(this).attr("src") + ",";
    });
    $("#ulImgs2").find("img").each(function () {
        photourls += $(this).attr("src") + ",";
    });
    return RTrim(photourls);
}

function LoadPhotos(photos) {
    if (photos.length > 0) {
        $("#divFWZPValue").css("display", "block");
        if (photos.length > 4)
            $("#divLXRXX").css("margin-top", "300px");
        for (var i = 0; i < photos.length; i++) {
            if (i > 3)
                $("#ulImgs2").append("<li draggable='true' class='liImg'><img src='" + photos[i].PHOTOURL + "' class='divImg' /><div class='toolbar_wrap'><div class='opacity'></div><div class='toolbar'><a class='edit'></a><a class='delete'></a></div></div></li>");
            else
                $("#ulImgs1").append("<li draggable='true' class='liImg'><img src='" + photos[i].PHOTOURL + "' class='divImg' /><div class='toolbar_wrap'><div class='opacity'></div><div class='toolbar'><a class='edit'></a><a class='delete'></a></div></div></li>");
        }
        BindToolBar();
    }
}

function BindToolBar() {
    BindMouseHover();
    BindUlImgEdit();
    BindUlImgDelete();
}

function BindMouseHover() {
    $("#ulImgs1").find("img").each(function (i) {
        $(this).bind("mouseover", function () {
            $(this).next().css("display", "block");
        });
        $("#ulImgs1").find(".toolbar_wrap").each(function () {
            $(this).bind("mouseleave", function () {
                $(this).css("display", "none");
            });
        });
    });
    $("#ulImgs2").find("img").each(function (i) {
        $(this).bind("mouseover", function () {
            $(this).next().css("display", "block");
        });
        $("#ulImgs2").find(".toolbar_wrap").each(function () {
            $(this).bind("mouseleave", function () {
                $(this).css("display", "none");
            });
        });
    });
}

function BindUlImgEdit() {
    $(".ulImgs").find(".edit").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $("#shadow").css("display", "block");
            $("#editImgWindow").css("display", "block");
            var c = $("#canvas")[0];
            var cxt = c.getContext("2d");
            var img = new Image();
            img.src = $(this).parent().parent().parent().find("img").attr("src");
            img.onload = function () //确保图片已经加载完毕  
            {
                cxt.clearRect(0, 0, c.width, c.height);
                var left = (c.width - img.width / 3) / 2;
                var top = (c.height - img.height / 3) / 2;
                cxt.drawImage(img, left, top, img.width / 3, img.height / 3);
                $("#rotate").bind("click", { src: img.src }, Rotate);
                $("#btnSavePhoto").bind("click", { src: img.src }, SavePhoto);
            }
        });
    });
}

function BindUlImgDelete() {
    $("#ulImgs1").find(".delete").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $(this).parent().parent().parent("li").remove();
            if ($("#ulImgs2").find("li").length > 0) {
                $("#ulImgs1").append($("#ulImgs2").find("li:eq(0)")[0].outerHTML);
                $("#ulImgs2").find("li:eq(0)").remove();
                BindMouseHover();
                ControlUpload();
                BindUlImg1Delete();
            }
        });
    });
    $("#ulImgs2").find(".delete").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $(this).parent().parent().parent("li").remove();
            BindMouseHover();
            ControlUpload();
            BindUlImg2Delete();
        });
    });
}

function BindUlImg1Delete() {
    $("#ulImgs1").find(".delete").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $(this).parent().parent().parent("li").remove();
            if ($("#ulImgs2").find("li").length > 0) {
                $("#ulImgs1").append($("#ulImgs2").find("li:eq(0)")[0].outerHTML);
                $("#ulImgs2").find("li:eq(0)").remove();
                BindMouseHover();
                ControlUpload();
            }
        });
    });
}

function BindUlImg2Delete() {
    $("#ulImgs2").find(".delete").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $(this).parent().parent().parent("li").remove();
            BindMouseHover();
            ControlUpload();
        });
    });
}

function Rotate(obj) {
    var c = $("#canvas")[0];
    var cxt = c.getContext("2d");
    var x = c.width / 2; //画布宽度的一半
    var y = c.height / 2;//画布高度的一半

    var img = new Image();
    img.src = obj.data.src;
    img.onload = function () //确保图片已经加载完毕  
    {
        cxt.clearRect(0, 0, c.width, c.height);
        cxt.translate(x, y);//将绘图原点移到画布中点
        cxt.rotate((Math.PI / 180) * 90);//旋转角度
        cxt.translate(-x, -y);//将画布原点移动
        var left = (c.width - img.width / 3) / 2;
        var top = (c.height - img.height / 3) / 2;
        cxt.drawImage(img, left, top, img.width / 3, img.height / 3);
    }

}

function SavePhoto(obj) {
    var filepath = obj.data.src;
    var c = $("#canvas")[0];
    var data = c.toDataURL();
    var b64 = data.substring(22);
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Areas/Business/Ashx/SavePhotos.Ashx",
        dataType: "json",
        data:
        {
            data: b64,
            filepath: filepath
        },
        success: function (xml) {
            alert(xml);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

//上传照片
function Upload() {
    $("#divFWZPValue").css("display", "block");
    var f = $(this).get(0).files[0];
    var reader = new FileReader();
    reader.readAsDataURL(f);
    reader.onload = function (theFile) {
        var image = new Image();
        image.src = theFile.target.result;
        image.onload = function () {
            var form = $("#myform");
            var formData = new FormData(form);
            formData.append('Filedata', f);
            formData.append('width', this.width);
            formData.append('height', this.height);
            var xhr = new XMLHttpRequest();
            xhr.addEventListener("load", uploadComplete, false);
            xhr.open('POST', getRootPath() + "/Areas/Business/Ashx/SavePhotos.Ashx");
            xhr.send(formData);
        };
    };
}

//上传完成事件
function uploadComplete(evt) {
    var imagepath = getRootPath() + "/Areas/Business/Photos/" + evt.target.responseText;
    if ($("#ulImgs1").find("img").length < 4) {
        $("#ulImgs1").append("<li draggable='true' class='liImg'><img src='" + imagepath + "' class='divImg' /><div class='toolbar_wrap'><div class='opacity'></div><div class='toolbar'><a class='edit'></a><a class='delete'></a></div></div></li>");

    }
    else {
        $("#divLXRXX").css("margin-top", "300px");
        $("#ulImgs2").append("<li draggable='true' class='liImg'><img src='" + imagepath + "' class='divImg' /><div class='toolbar_wrap'><div class='opacity'></div><div class='toolbar'><a class='edit'></a><a class='delete'></a></div></div></li>");
    }
    ControlUpload();
    ValidateFWZP();
    BindToolBar();
}

function ControlUpload() {
    if ($("#ulImgs2").find("img").length === 4) {
        $("#divUploadOut").css("background-color", "#ececec");
        $("#inputUpload").attr("disabled", "disabled");
    } else {
        $("#divUploadOut").css("background-color", "#fff");
        $("#inputUpload").removeAttr("disabled");
    }
}

function CloseWindow() {
    $("#shadow").css("display", "none");
    $("#editImgWindow").css("display", "none");
}

function FB() {
    if (AllValidate() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "CX", "'" + $("#spanFWCX").html() + "'");
    obj = jsonObj.AddJson(obj, "ZXQK", "'" + $("#spanZXQK").html() + "'");
    obj = jsonObj.AddJson(obj, "ZZLX", "'" + $("#spanZZLX").html() + "'");
    obj = jsonObj.AddJson(obj, "YFFS", "'" + $("#spanYFFS").html() + "'");
    obj = jsonObj.AddJson(obj, "ZJYBHFY", "'" + GetDX("BHFY") + "'");
    obj = jsonObj.AddJson(obj, "FWPZ", "'" + GetDX("FWPZ") + "'");
    obj = jsonObj.AddJson(obj, "FWLD", "'" + GetDX("FWLD") + "'");
    obj = jsonObj.AddJson(obj, "CZYQ", "'" + GetDX("CZYQ") + "'");
    obj = jsonObj.AddJson(obj, "CZFS", "'" + GetCZFS() + "'");
    if ($("#KRZSJ").val() !== "")
        obj = jsonObj.AddJson(obj, "KRZSJ", "'" + $("#KRZSJ").val() + "'");
    if (getUrlParam("FWCZID") !== null)
        obj = jsonObj.AddJson(obj, "FWCZID", "'" + getUrlParam("FWCZID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FWCZ/FB",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            FYMS: $("#FYMS").html(),
            FWZP: GetPhotoUrls()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                alert("发布成功");
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