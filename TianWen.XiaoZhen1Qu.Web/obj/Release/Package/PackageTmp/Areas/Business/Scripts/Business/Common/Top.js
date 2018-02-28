$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 1200) / 2);
    $("#span_dl").bind("click", OpenDL);
    $("#span_zc").bind("click", OpenZC);
    $("#span_grzx").bind("click", OpenGRZX);
    $("#span_bzzx").bind("click", OpenBZZX);
    LoadUser();
});
//登录
function OpenDL() {
    window.location.href = getRootPath() + "/YHDL/YHDL";
}
//注册
function OpenZC() {
    window.location.href = getRootPath() + "/YHJBXX/YHJBXX";
}
//个人中心
function OpenGRZX() {
    if ($("#input_yhm").val() !== "") {
        window.open(getRootPath() + "/HTGL/HTGL");
    }
    else {
        window.open(getRootPath() + "/YHDL/YHDL?To=HTGL");
    }
}
//帮助中心
function OpenBZZX() {
    window.open(getRootPath() + "/BZZX/BZZX");
}
//加载用户下拉框
function LoadUser() {
    if ($("#input_yhm").val() !== "") {
        var html = "";
        html += "<a class='a_yhm'>" + $("#input_yhm").val() + "</a id='i_yhm' class='i_yhm'>";
        html += '<span class="span_top_right_yhm" id="span_top_right_yhm_img"></span>';
        html += '<div class="div_top_right_dropdown_yhm" id="div_top_right_dropdown_yhm">';
        html += '<ul class="ul_top_right_yhm">';
        html += '<li class="li_top_right_yhm">我的信息</li>';
        html += '<li class="li_top_right_yhm">我的账户</li>';
        html += '<li class="li_top_right_yhm">我的资金</li>';
        html += '<li class="li_top_right_yhm" onclick="Exit()">退出</li>';
        html += '</ul>';
        html += '</div>';
        $("#div_yhm").html(html);
        $("#div_yhm").css("display", "");
        $("#span_dl").css("display", "none");
    }
    else {
        $("#div_yhm").css("display", "none");
        $("#span_dl").css("display", "");
    }
    $("#div_yhm").bind("mouseover", ShowYHCD);
    $("#div_yhm").bind("mouseleave", HideYHCD);
}
//退出
function Exit() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/YHDL/Exit",
        dataType: "json",
        data: {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.location.reload();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//显示我的信息
function ShowWDXX() {
    window.open(getRootPath() + "/HTGL/HTGL");
    $("#liWDXX").css("font-size", "18px").css("font-weight", "700");
    $("#liWDZH").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZJ").css("font-size", "16px").css("font-weight", "normal");
    $("#liSHGJ").css("font-size", "16px").css("font-weight", "normal");
    $("#ulWDXX").css("display", "block");
    $("#ulWDZH").css("display", "block");
    $("#ulWDZJ").css("display", "block");
    $("#ulSHGJ").css("display", "block");
    ToWDFB();
}
//显示我的账户
function ShowWDZH() {
    window.open(getRootPath() + "/HTGL/HTGL");
    $("#liWDXX").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZH").css("font-size", "18px").css("font-weight", "700");
    $("#liWDZJ").css("font-size", "16px").css("font-weight", "normal");
    $("#liSHGJ").css("font-size", "16px").css("font-weight", "normal");
    $("#ulWDXX").css("display", "none");
    $("#ulWDZH").css("display", "block");
    $("#ulWDZJ").css("display", "block");
    $("#ulSHGJ").css("display", "block");
    ToGRZL();
}
//显示我的资金
function ShowWDZJ() {
    window.open(getRootPath() + "/HTGL/HTGL");
    $("#liWDXX").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZH").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZJ").css("font-size", "18px").css("font-weight", "700");
    $("#liSHGJ").css("font-size", "16px").css("font-weight", "normal");
    $("#ulWDXX").css("display", "none");
    $("#ulWDZH").css("display", "none");
    $("#ulWDZJ").css("display", "block");
    $("#ulSHGJ").css("display", "block");
    ToXJMXCX();
}
//显示生活工具
function ShowSHGJ() {
    window.open(getRootPath() + "/HTGL/HTGL");
    $("#liWDXX").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZH").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZJ").css("font-size", "16px").css("font-weight", "normal");
    $("#liSHGJ").css("font-size", "18px").css("font-weight", "700");
    $("#ulWDXX").css("display", "none");
    $("#ulWDZH").css("display", "none");
    $("#ulWDZJ").css("display", "none");
    $("#ulSHGJ").css("display", "block");
    ToHFCZ();
}
//显示用户菜单
function ShowYHCD() {
    $("#div_top_right_dropdown_yhm").css("display", "block");
    $("#span_top_right_yhm_img").css("background-image", 'url(' + getRootPath() + "/Areas/Business/Css/images/arrow_up.png" + ')');
}
//隐藏用户菜单
function HideYHCD() {
    $("#div_top_right_dropdown_yhm").css("display", "none");
    $("#span_top_right_yhm_img").css("background-image", 'url(' + getRootPath() + "/Areas/Business/Css/images/arrow_down.png" + ')');
}
//我的发布
function ToWDFB() {
    $("#iframeright").attr("src", getRootPath() + "/WDFB/WDFB");
}
//个人资料
function ToGRZL() {
    $("#iframeright").attr("src", getRootPath() + "/GRZL/GRZL");
}
//我的资金>现金>明细查询
function ToXJMXCX() {
    $("#iframeright").attr("src", getRootPath() + "/WDXJ/WDXJ_MXCX");
}
//我的资金>现金>充值
function ToXJCZ() {
    $("#iframeright").attr("src", getRootPath() + "/WDXJ/WDXJ_CZ");
}