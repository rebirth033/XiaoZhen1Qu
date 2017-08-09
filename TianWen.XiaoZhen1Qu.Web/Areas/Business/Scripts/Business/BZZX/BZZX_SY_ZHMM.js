$(document).ready(function () {
    ToZHMM();
});

//帮助中心_首页
function ToZHMM() {
    $("#iframeright").attr("src", getRootPath() + "/Business/ZHMM/ZHMM?YHID=" + getUrlParam("YHID"));
}
