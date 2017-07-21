$(document).ready(function () {
    $("#liGRZX").css("font-size", "18px").css("font-weight", "700");
    ToWDFB();
    $("#liGRZX").bind("click", ShowGRZX);
    $("#liZHSZ").bind("click", ShowZHSZ);
    $("#liSHGJ").bind("click", ShowSHGJ);
    $("#spanWDFB").bind("click", ToWDFB);
    $("#spanWDSC").bind("click", ToWDSC);
    $("#spanWDQZ").bind("click", ExpandWDQZ);
    $("#imgWDQZ").bind("click", ExpandWDQZ);
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

function ExpandWDQZ() {
    $(".WDQZ_child").each(function() {
        $(this).css("display", "block");
    });
}