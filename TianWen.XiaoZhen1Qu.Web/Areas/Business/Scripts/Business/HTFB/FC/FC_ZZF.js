var ue = UE.getEditor('BCMS');
$(document).ready(function () {
    $("#XQMC").bind("keyup", LoadXQMC);
    $("#KRZSJ").datepicker({ minDate: 0 });
    $("body").bind("click", function () { Close("_XZQ"); Close("QY"); Close("SQ");});
    BindClick("FWCX");
    BindClick("ZXQK");
    BindClick("ZZLX");
    BindClick("YFFS");
    LoadDuoX("包含费用", "BHFY");
    BCMSSetDefault();
});

function BCMSFocus() {
    $("#BCMS").css("color", "#333333");
}

function BCMSBlur() {
    $("#BCMS").css("color", "#999999");
}

function BCMSSetDefault() {
    var BCMS = "1.房屋特征：\r\n\r\n2.周边配套：\r\n\r\n3.房东心态：";
    $("#BCMS").html(BCMS);
}

//加载小区名称
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
        url: getRootPath() + "/Business/FC/LoadXQJBXXSByHZ",
        dataType: "json",
        data:
        {
            XQMC: XQMC
        },
        success: function (xml) {
            if (xml.Result === 1 && xml.list.length > 0) {
                var html = "<ul id='ulXQMC' class='ul_select' style='height:" + (xml.list.length * 34.5) + "px;width:594px;background-color:#ffffff'>";
                for (var i = 0; i < xml.list.length; i++) {
                    var index = xml.list[i].XQMC.indexOf(XQMC);
                    var xqmclength = XQMC.length;
                    var xqmchtml = "";
                    if (index === 0)
                        xqmchtml = "<span style='color:#333333;font-weight:bolder;'>" + XQMC + "</span>" + "<span style='color:#333333'>" + xml.list[i].XQMC.substr(xqmclength, xml.list[i].XQMC.length - XQMC.length) + "</span>";
                    else {
                        xqmchtml = "<span style='color:#333333'>" + xml.list[i].XQMC.substr(0, index) + "</span>" + "<span style='color:#333333;font-weight:bolder;'>" + xml.list[i].XQMC.substr(index, xqmclength) + "</span>" + "<span style='color:#333333'>" + xml.list[i].XQMC.substr(index + xqmclength, xml.list[i].XQMC.length - index - xqmclength) + "</span>";
                    }
                    html += "<li class='li_select' onclick='SelectXQMC(this)'>" + xqmchtml + "&nbsp;&nbsp;<span style='color:#999999;font-size:12px;'>" + (xml.list[i].XQDZ === null ? "" : xml.list[i].XQDZ) + "</span>" + "</li>";
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
        url: getRootPath() + "/Business/FC/LoadXQJBXXSByPY",
        dataType: "json",
        data:
        {
            XQMC: XQMC
        },
        success: function (xml) {
            if (xml.Result === 1 && xml.list.length > 0) {
                var html = "<ul id='ulXQMC' class='ul_select' style='height: " + (xml.list.length * 34.5) + "px;width:594px;background-color:#ffffff'>";
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
                    html += "<li class='li_select' onclick='SelectXQMC(this)'>" + xqmchtml + "&nbsp;&nbsp;<span style='color:#999999;font-size:12px;'>" + (xml.list[i].XQDZ === null ? "" : xml.list[i].XQDZ) + "</span>" + "</li>";
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
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "FWCX") {
            LoadCODESByTYPENAME("朝向", "FWCX", "CODES_FC");
        }
        if (type === "ZXQK") {
            LoadCODESByTYPENAME("装修情况", "ZXQK", "CODES_FC");
        }
        if (type === "ZZLX") {
            LoadCODESByTYPENAME("住宅类型", "ZZLX", "CODES_FC");
        }
        if (type === "YFFS") {
            LoadCODESByTYPENAME("押付方式", "YFFS", "CODES_FC");
        }
    });
}
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: type,
            TBName: "CODES_FC"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 4 || i === 9 || i === 14 || i === 19) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 5) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 5) * 45 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 5) + 1) * 45 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                if (xml.list.length === 0)
                    $("#div" + id).css("display", "none");
                else
                    $("#div" + id).css("display", "");
                if (type === "包含费用")
                    LoadDuoX("房屋配置", "FWPZ");
                if (type === "房屋配置")
                    LoadDuoX("房屋亮点", "FWLD");
                if (type === "房屋亮点")
                    LoadDuoX("出租要求", "CZYQ");
                if (type === "出租要求")
                    LoadFC_ZZFXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择小区名称
function SelectXQMC(obj) {
    var array = obj.innerText.split(' ');
    $("#XQMC").val(array[0]);
    $("#XQDZ").val(array[2]);
    $("#divXQMClist").css("display", "none");
}
//加载
function LoadFC_ZZFXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC/LoadFC_ZZFJBXX",
        dataType: "json",
        data:
        {
            FC_ZZFJBXXID: getUrlParam("FC_ZZFJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.FC_ZZFJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                if (xml.Value.FC_ZZFJBXX.ZJYBHFY !== null)
                    SetDuoX("BHFY", xml.Value.FC_ZZFJBXX.ZJYBHFY);
                if (xml.Value.FC_ZZFJBXX.FWPZ !== null)
                    SetDuoX("FWPZ", xml.Value.FC_ZZFJBXX.FWPZ);
                if (xml.Value.FC_ZZFJBXX.FWLD !== null)
                    SetDuoX("FWLD", xml.Value.FC_ZZFJBXX.FWLD);
                if (xml.Value.FC_ZZFJBXX.CZYQ !== null)
                    SetDuoX("CZYQ", xml.Value.FC_ZZFJBXX.CZYQ);
                if (xml.Value.FC_ZZFJBXX.CZFS !== null)
                    SetDX("CZFS", xml.Value.FC_ZZFJBXX.CZFS);
                $("#spanFWCX").html(xml.Value.FC_ZZFJBXX.CX);
                $("#spanZXQK").html(xml.Value.FC_ZZFJBXX.ZXQK);
                $("#spanZZLX").html(xml.Value.FC_ZZFJBXX.ZZLX);
                $("#spanYFFS").html(xml.Value.FC_ZZFJBXX.YFFS);
                //设置编辑器的内容
                ue.ready(function () { ue.setHeight(200); ue.setContent(xml.Value.BCMSString); });
                if (xml.Value.FC_ZZFJBXX.KRZSJ.ToString("yyyy-MM-dd") !== "1-1-1")
                    $("#KRZSJ").val(xml.Value.FC_ZZFJBXX.KRZSJ.ToString("yyyy-MM-dd"));
                LoadPhotos(xml.Value.Photos);
                return;
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
    obj = jsonObj.AddJson(obj, "CX", "'" + $("#spanFWCX").html() + "'");
    obj = jsonObj.AddJson(obj, "ZXQK", "'" + $("#spanZXQK").html() + "'");
    obj = jsonObj.AddJson(obj, "ZZLX", "'" + $("#spanZZLX").html() + "'");
    obj = jsonObj.AddJson(obj, "YFFS", "'" + $("#spanYFFS").html() + "'");
    obj = jsonObj.AddJson(obj, "ZJYBHFY", "'" + GetDuoX("BHFY") + "'");
    obj = jsonObj.AddJson(obj, "FWPZ", "'" + GetDuoX("FWPZ") + "'");
    obj = jsonObj.AddJson(obj, "FWLD", "'" + GetDuoX("FWLD") + "'");
    obj = jsonObj.AddJson(obj, "CZYQ", "'" + GetDuoX("CZYQ") + "'");
    obj = jsonObj.AddJson(obj, "CZFS", "'" + GetDX("CZFS") + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    if ($("#KRZSJ").val() !== "")
        obj = jsonObj.AddJson(obj, "KRZSJ", "'" + $("#KRZSJ").val() + "'");
    if (getUrlParam("FC_ZZFJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "FC_ZZFJBXXID", "'" + getUrlParam("FC_ZZFJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC/FBFC_ZZFJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            BCMS: ue.getContent(),
            FWZP: GetPhotoUrls()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.location.href = getRootPath() + "/Business/FBCG/FBCG?YHID=" + getUrlParam("YHID");
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