$(document).ready(function () {
    $("#XQMC").bind("keyup", LoadXQMC);
    $("#KRZSJ").datepicker({ minDate: 0 });
    BindClick("FWCX");
    BindClick("ZXQK");
    BindClick("ZZLX");
    BindClick("CQNX");
    BindClick("CQLX");
    BindClick("JZND");
    LoadDuoX("出售房屋亮点", "FWLD");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "FWCX") {
            LoadCODESByTYPENAME("朝向", "FWCX", "CODES_FC", Bind, "FWQK", "FWCX", "");
        }
        if (type === "ZXQK") {
            LoadCODESByTYPENAME("装修情况", "ZXQK", "CODES_FC", Bind, "FWQK", "ZXQK", "");
        }
        if (type === "ZZLX") {
            LoadCODESByTYPENAME("住宅类型", "ZZLX", "CODES_FC", Bind, "FWQK", "ZZLX", "");
        }
        if (type === "CQNX") {
            LoadCODESByTYPENAME("产权年限", "CQNX", "CODES_FC", Bind, "CQMS", "CQNX", "");
        }
        if (type === "CQLX") {
            LoadCODESByTYPENAME("产权类型", "CQLX", "CODES_FC", Bind, "CQMS", "CQLX", "");
        }
        if (type === "JZND") {
            LoadCODESByTYPENAME("建筑年代", "JZND", "CODES_FC", Bind, "CQMS", "JZND", "");
        }
    });
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
                SelectXQMC($("#divXQMClist").find("li:eq(" + i + ")")[0]);
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
        url: getRootPath() + "/FC/LoadXQJBXXSByHZ",
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
        url: getRootPath() + "/FC/LoadXQJBXXSByPY",
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
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
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
                    if (i % 5 === 4 && i !== xml.list.length - 1) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 173px'>";
                    }
                }
                if (parseInt(xml.list.length % 5) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 5) * 45 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 5) + 1) * 45 + "px");
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
//选择小区名称
function SelectXQMC(obj) {
    var array = obj.innerText.split(' ');
    $("#XQMC").val(array[0]);
    $("#XQDZ").val(array[0]);
    $("#divXQMClist").css("display", "none");
    ValidateXQMC();
}
//加载
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/FC/LoadFC_ESFJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.FC_ESFJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                if (xml.Value.FC_ESFJBXX.SF !== null)
                    SetDX("SF", xml.Value.FC_ESFJBXX.SF);
                if (xml.Value.FC_ESFJBXX.FWLD !== null)
                    SetDuoX("FWLD", xml.Value.FC_ESFJBXX.FWLD);
                $("#spanFWCX").html(xml.Value.FC_ESFJBXX.CX);
                $("#spanZXQK").html(xml.Value.FC_ESFJBXX.ZXQK);
                $("#spanZZLX").html(xml.Value.FC_ESFJBXX.ZZLX);
                $("#spanCQNX").html(xml.Value.FC_ESFJBXX.CQNX);
                $("#spanCQLX").html(xml.Value.FC_ESFJBXX.CQLX);
                $("#spanJZND").html(xml.Value.FC_ESFJBXX.JZND);
                $("#SJ").html(xml.Value.FC_ESFJBXX.SJ);
                $("#XQDZ").val(xml.Value.FC_ESFJBXX.XQMC);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                if (xml.Value.FC_ESFJBXX.KRZSJ.ToString("yyyy-MM-dd") !== "1-1-1")
                    $("#KRZSJ").val(xml.Value.FC_ESFJBXX.KRZSJ.ToString("yyyy-MM-dd"));
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
    obj = jsonObj.AddJson(obj, "SJ", "'" + $("#SJ").val() + "'");
    obj = jsonObj.AddJson(obj, "ZXQK", "'" + $("#spanZXQK").html() + "'");
    obj = jsonObj.AddJson(obj, "ZZLX", "'" + $("#spanZZLX").html() + "'");
    obj = jsonObj.AddJson(obj, "CQNX", "'" + $("#spanCQNX").html() + "'");
    obj = jsonObj.AddJson(obj, "CQLX", "'" + $("#spanCQLX").html() + "'");
    obj = jsonObj.AddJson(obj, "JZND", "'" + $("#spanJZND").html() + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("SF") + "'");
    obj = jsonObj.AddJson(obj, "FWLD", "'" + GetDuoX("FWLD") + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    if ($("#KRZSJ").val() !== "")
        obj = jsonObj.AddJson(obj, "KRZSJ", "'" + $("#KRZSJ").val() + "'");
    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/FC/FBFC_ESFJBXX",
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