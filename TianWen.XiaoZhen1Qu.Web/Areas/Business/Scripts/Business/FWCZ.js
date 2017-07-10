﻿$(document).ready(function () {
    $("#XQMC").bind("keyup", LoadXQMC);
    $("#spanCXLB").bind("click", CXLB);
    $("#imgZTCZ").bind("click", ZTCZSelect);
    $("#imgDJCZ").bind("click", DJCZSelect);
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    $(".inputLCFB").bind("focus", LCFBFocus);
    $(".inputLCFB").bind("blur", LCFBBlur);
    $(".inputFWLX").bind("focus", LCFBFocus);
    $(".inputFWLX").bind("blur", LCFBBlur);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#KRZSJ").datepicker({ minDate: 0 });

    $("#inputUpload").change(function () {
        var file = this.files[0];
        readFile(file, $("#divImg"));
    });

    BindHover();
    LoadTXXX();
    LoadFWCX();
    LoadZXQK();
    LoadZZLX();
    LoadYFFS();
    LoadBHFY();
    LoadDefault();
    LoadFWCZXX();
    FYMSSetDefault();
});
//新建阅读器
var reader = new FileReader();
function readFile(file, element) {
    //根据文件类型选择阅读方式
    switch (file.type) {
        case 'image/jpg':
        case 'image/png':
        case 'image/jpeg':
        case 'image/gif':
            reader.readAsDataURL(file);
            break;
    }

    reader.addEventListener('load', function () {
        //如果说让读取的文件显示的话 还是需要通过文件的类型创建不同的标签
        switch (file.type) {
            case 'image/jpg':
            case 'image/png':
            case 'image/jpeg':
            case 'image/gif':
                var img = document.createElement('img');
                img.src = reader.result;
                element.append(img);
                element.siblings(".addhao").hide();
                element.show();
                break;
        }
    });
}
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

function LCFBFocus() {
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

function LCFBBlur() {
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
    $("#imgZTCZ").css("background-position", "-67px -57px");
    $("#imgDJCZ").css("background-position", "-67px 0px");
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
            _masker.CloseMasker(false, errorThrown);
        }
    });
}

function CXLB() {
    window.location.href = getRootPath() + "/Business/LBXZ/LBXZ";
}

function ZTCZSelect() {
    $("#imgZTCZ").css("background-position", "-67px -57px");
    $("#imgDJCZ").css("background-position", "-67px 0px");
}

function DJCZSelect() {
    $("#imgDJCZ").css("background-position", "-67px -57px");
    $("#imgZTCZ").css("background-position", "-67px 0px");
}

function LoadXQMC() {
    var XQMC = $("#XQMC").val();
    if (XQMC === "") {
        $("#divXQMClist").css("display", "none");
        return;
    }
    if (/^[\u4e00-\u9fa5]+$/i.test(XQMC)) //判断是否是汉字
        LoadXQJBXXSByHZ(XQMC);
    else
        LoadXQJBXXSByPY(XQMC);
}

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
                var html = "<ul id='ulXQMC' class='uldropdown' style='height: " + (xml.list.length * 34.5) + "px;width:594px;background-color:#ffffff'>";
                for (var i = 0; i < xml.list.length; i++) {
                    var index = xml.list[i].XQMC.indexOf(XQMC);
                    var xqmclength = XQMC.length;
                    var xqmchtml = "";
                    if (index === 0)
                        xqmchtml = "<span style='color:#333333;font-weight:bolder;'>" + XQMC + "</span>" + "<span style='color:#333333'>" + xml.list[i].XQMC.substr(xqmclength, xml.list[i].XQMC.length - XQMC.length) + "</span>";
                    else {
                        xqmchtml = "<span style='color:#333333'>" + xml.list[i].XQMC.substr(0, index) + "</span>" + "<span style='color:#333333;font-weight:bolder;'>" + xml.list[i].XQMC.substr(index, xqmclength) + "</span>" + "<span style='color:#333333'>" + xml.list[i].XQMC.substr(index + xqmclength, xml.list[i].XQMC.length - index - xqmclength) + "</span>";
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
                var html = "<ul id='ulXQMC' class='uldropdown' style='height: " + (xml.list.length * 34.5) + "px;width:594px;background-color:#ffffff'>";
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
            _masker.CloseMasker(false, errorThrown);
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
            _masker.CloseMasker(false, errorThrown);
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
            _masker.CloseMasker(false, errorThrown);
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
            _masker.CloseMasker(false, errorThrown);
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
            _masker.CloseMasker(false, errorThrown);
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
            _masker.CloseMasker(false, errorThrown);
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
            _masker.CloseMasker(false, errorThrown);
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
            _masker.CloseMasker(false, errorThrown);
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

function Validate() {
    //if (!YHMCheck()) return false;
    //if (!MMCheck()) return false;
    //if (!QRMMCheck()) return false;
    //if (!SJCheck()) return false;
    //if (!ValidateCheckCode()) return false;
    return true;
}

function FB() {
    if (Validate() === false) return;
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
    if (getUrlParam("FWCZID") !== null)
        obj = jsonObj.AddJson(obj, "FWCZID", "'" + getUrlParam("FWCZID") + "'");
    //obj = jsonObj.AddJson(obj, "ZZLX", "'" + $("#spanZZLX").html() + "'");
    //obj = jsonObj.AddJson(obj, "ZZLX", "'" + $("#spanZZLX").html() + "'");
    //obj = jsonObj.AddJson(obj, "FWCZID", "'" + FWCZID + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FWCZ/FB",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            FYMS: $("#FYMS").html()
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
                SetDX("BHFY", xml.Value.FWCZXX.ZJYBHFY);
                SetDX("FWPZ", xml.Value.FWCZXX.FWPZ);
                SetDX("FWLD", xml.Value.FWCZXX.FWLD);
                SetDX("CZYQ", xml.Value.FWCZXX.CZYQ);
                SetCZFS(xml.Value.FWCZXX.CZFS);
                $("#spanFWCX").html(xml.Value.FWCZXX.CX);
                $("#spanZXQK").html(xml.Value.FWCZXX.ZXQK);
                $("#spanZZLX").html(xml.Value.FWCZXX.ZZLX);
                $("#spanYFFS").html(xml.Value.FWCZXX.YFFS);
                $("#FYMS").html(xml.Value.FWCZXX.FYMS);
                $("#KRZSJ").val(xml.Value.FWCZXX.KRZSJ.ToString("yyyy-MM-dd"));
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            _masker.CloseMasker(false, errorThrown);
        }
    });

}