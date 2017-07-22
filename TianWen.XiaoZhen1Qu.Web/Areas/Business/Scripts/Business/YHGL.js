$(document).ready(function () {
    $("#liGRZX").css("font-size", "18px").css("font-weight", "700");
    $("#imgWDQZ").attr("src", getRootPath() + "/Areas/Business/Css/images/down.png");
    $("#imgWDZP").attr("src", getRootPath() + "/Areas/Business/Css/images/down.png");
    ToWDFB();
    $("#liGRZX").bind("click", ShowGRZX);
    $("#liZHSZ").bind("click", ShowZHSZ);
    $("#liSHGJ").bind("click", ShowSHGJ);
    $("#spanWDFB").bind("click", ToWDFB);
    $("#spanWDSC").bind("click", ToWDSC);
    $("#spanWDQZ").parent().bind("click", { type: "WDQZ" }, ExpandSecond_Leaf);
    $("#spanWDZP").parent().bind("click", { type: "WDZP" }, ExpandSecond_Tree);
    $("#spanZWGL").parent().bind("click", { type: "ZWGL" }, ExpandThird);
    $("#spanJLGL").parent().bind("click", { type: "JLGL" }, ExpandThird);
    $("#spanZHXX").parent().bind("click", { type: "ZHXX" }, ExpandThird);
});

function AutoLogin() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/YHGL/AutoLogin",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                alert("登录成功");
            } else {
                window.location.href = getRootPath() + "/Business/YHDLXX/YHDLXX";
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function ToWDFB() {
    $("#iframeright").attr("src", getRootPath() + "/Business/WDFB/WDFB");
}

function ToWDSC() {
    $("#iframeright").attr("src", getRootPath() + "/Business/WDSC/WDSC");
}

function ShowGRZX() {
    $("#liGRZX").css("font-size", "18px").css("font-weight", "700");
    $("#liZHSZ").css("font-size", "16px").css("font-weight", "normal");
    $("#liSHGJ").css("font-size", "16px").css("font-weight", "normal");
    $("#ulGRZX").css("display", "block");
    $("#ulZHSZ").css("display", "block");
    $("#ulSHGJ").css("display", "block");
}

function ShowZHSZ() {
    $("#liZHSZ").css("font-size", "18px").css("font-weight", "700");
    $("#liGRZX").css("font-size", "16px").css("font-weight", "normal");
    $("#liSHGJ").css("font-size", "16px").css("font-weight", "normal");
    $("#ulGRZX").css("display", "none");
    $("#ulZHSZ").css("display", "block");
    $("#ulSHGJ").css("display", "block");
}

function ShowSHGJ() {
    $("#liSHGJ").css("font-size", "18px").css("font-weight", "700");
    $("#liGRZX").css("font-size", "16px").css("font-weight", "normal");
    $("#liZHSZ").css("font-size", "16px").css("font-weight", "normal");
    $("#ulGRZX").css("display", "none");
    $("#ulZHSZ").css("display", "none");
    $("#ulSHGJ").css("display", "block");
}

function ExpandSecond_Leaf(obj) {
    if ($("#img" + obj.data.type).attr("src").indexOf("up") !== -1) {
        $("." + obj.data.type + "_child").each(function () {
            $(this).css("display", "none");
        });
        $(".img_left_menu_third").each(function () {
            $(this).css("display", "none");
        });
        $("#img" + obj.data.type).attr("src", getRootPath() + "/Areas/Business/Css/images/down.png");
    } else {
        $("." + obj.data.type + "_child").each(function () {
            $(this).css("display", "block");
        });
        $(".img_left_menu_third").each(function () {
            $(this).css("display", "block");
        });
        $("#img" + obj.data.type).attr("src", getRootPath() + "/Areas/Business/Css/images/up.png");
    }
}

function ExpandSecond_Tree(obj) {
    if ($("#img" + obj.data.type).attr("src").indexOf("up") !== -1) {
        $("." + obj.data.type + "_child").each(function () {
            $(this).css("display", "none");
        });
        $(".img_left_menu_third").each(function () {
            $(this).css("display", "none");
        });
        $("#img" + obj.data.type).attr("src", getRootPath() + "/Areas/Business/Css/images/down.png");
    } else {
        $("." + obj.data.type + "_child").each(function () {
            $(this).css("display", "block");
        });
        $(".img_left_menu_third").each(function () {
            $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/expand.png");
            $(this).css("display", "block");
        });
        $("#img" + obj.data.type).attr("src", getRootPath() + "/Areas/Business/Css/images/up.png");
    }
}

function ExpandThird(obj) {
    if ($("#img" + obj.data.type).attr("src").indexOf("expand") !== -1) {
        $("." + obj.data.type + "_child").each(function () {
            $(this).css("display", "block");
        });
        $(".img_left_menu_four").each(function () {
            $(this).css("display", "block");
        });
        $("#img" + obj.data.type).attr("src", getRootPath() + "/Areas/Business/Css/images/contract.png");
    } else {
        $("." + obj.data.type + "_child").each(function () {
            $(this).css("display", "none");
        });
        $(".img_left_menu_four").each(function () {
            $(this).css("display", "none");
        });
        $("#img" + obj.data.type).attr("src", getRootPath() + "/Areas/Business/Css/images/expand.png");
    }
}