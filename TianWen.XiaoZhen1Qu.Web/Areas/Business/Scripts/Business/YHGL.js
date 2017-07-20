$(document).ready(function () {
    $("#liGRZX").bind("click", ShowGRZX);
    $("#liZHSZ").bind("click", ShowZHSZ);
    $("#liSHGJ").bind("click", ShowSHGJ);
    $("#spanWDFB").bind("click", ToWDFB);
    ToWDFB();
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
            _masker.CloseMasker(false, errorThrown);
        }
    });
}

function ToWDFB() {
    $("#iframeright").attr("src", getRootPath() + "/Business/WDFB/WDFB");
}

function ShowGRZX() {
    $("#ulGRZX").css("display", "block");
    $("#ulZHSZ").css("display", "block");
    $("#ulSHGJ").css("display", "block");
}

function ShowZHSZ() {
    $("#ulGRZX").css("display", "none");
    $("#ulZHSZ").css("display", "block");
    $("#ulSHGJ").css("display", "block");
}

function ShowSHGJ() {
    $("#ulGRZX").css("display", "none");
    $("#ulZHSZ").css("display", "none");
    $("#ulSHGJ").css("display", "block");
}