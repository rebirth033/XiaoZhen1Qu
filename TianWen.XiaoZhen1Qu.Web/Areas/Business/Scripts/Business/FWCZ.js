$(document).ready(function () {
    $("#spanCXLB").bind("click", CXLB);
    $("#imgZTCZ").bind("click", ZTCZSelect);
    $("#imgDJCZ").bind("click", DJCZSelect);
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    BindHover();
    LoadTXXX();
    LoadFWCX();
    LoadZXQK();
    LoadZZLX();
    LoadYFFS();
    LoadFWPZ();
    LoadFWLD();
    LoadCZYQ();
    LoadBHFY();
    LoadDefault();
});

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
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            _masker.CloseMasker(false, errorThrown);
        }
    });
}

function BindHover() {
    $("#divFWCXText").hover(function () {
        $("#divFWCX").css("display", "block");
    }, function () {
        $("#divFWCX").css("display", "none");
    });
    $("#divFWCX").hover(function () {
        $("#divFWCX").css("display", "block");
    }, function () {
        $("#divFWCX").css("display", "none");
    });
    $("#divZXQKText").hover(function () {
        $("#divZXQK").css("display", "block");
    }, function () {
        $("#divZXQK").css("display", "none");
    });
    $("#divZXQK").hover(function () {
        $("#divZXQK").css("display", "block");
    }, function () {
        $("#divZXQK").css("display", "none");
    });
    $("#divZZLXText").hover(function () {
        $("#divZZLX").css("display", "block");
    }, function () {
        $("#divZZLX").css("display", "none");
    });
    $("#divZZLX").hover(function () {
        $("#divZZLX").css("display", "block");
    }, function () {
        $("#divZZLX").css("display", "none");
    });
    $("#divYFFSText").hover(function () {
        $("#divYFFS").css("display", "block");
    }, function () {
        $("#divYFFS").css("display", "none");
    });
    $("#divYFFS").hover(function () {
        $("#divYFFS").css("display", "block");
    }, function () {
        $("#divYFFS").css("display", "none");
    });
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
    obj = jsonObj.AddJson(obj, "FWCX", "'" + $("#spanFWCX").html() + "'");
    obj = jsonObj.AddJson(obj, "ZXQK", "'" + $("#spanZXQK").html() + "'");
    obj = jsonObj.AddJson(obj, "ZZLX", "'" + $("#spanZZLX").html() + "'");
    obj = jsonObj.AddJson(obj, "BHFY", "'" + GetDX("BHFY") + "'");
    obj = jsonObj.AddJson(obj, "FWPZ", "'" + GetDX("FWPZ") + "'");
    obj = jsonObj.AddJson(obj, "FWLD", "'" + GetDX("FWLD") + "'");
    obj = jsonObj.AddJson(obj, "CZYQ", "'" + GetDX("CZYQ") + "'");
    obj = jsonObj.AddJson(obj, "CZFS", "'" + GetCZFS() + "'");
    obj = jsonObj.AddJson(obj, "ZZLX", "'" + $("#spanZZLX").html() + "'");
    obj = jsonObj.AddJson(obj, "ZZLX", "'" + $("#spanZZLX").html() + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FWCZ/FB",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj)
        },
        success: function (xml) {
            if (xml.Result === 1) {
                alert("注册成功");
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
            _masker.CloseMasker(false, errorThrown);
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

function GetCZFS() {
    if ($("#imgZTCZ").css("background-position") === "-67px -57px")
        return "0";
    else
        return "1";
}