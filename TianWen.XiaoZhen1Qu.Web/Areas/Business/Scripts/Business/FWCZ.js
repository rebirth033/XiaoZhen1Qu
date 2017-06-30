$(document).ready(function () {
    $("#spanCXLB").bind("click", CXLB);
    $("#imgZTCZ").bind("click", ZTCZSelect);
    $("#imgDJCZ").bind("click", DJCZSelect);
    BindHover();
    LoadTXXX();
    LoadFWCX();
    LoadZXQK();
    LoadZZLX();
});

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
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'><li class='lidropdown'>请选择朝向</li>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown'>" + xml.list[i].CODENAME + "</li>";
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
                var html = "<ul class='uldropdown'><li class='lidropdown'>请选择装修情况</li>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown'>" + xml.list[i].CODENAME + "</li>";
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
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'><li class='lidropdown'>请选择住宅类型</li>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown'>" + xml.list[i].CODENAME + "</li>";
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
}