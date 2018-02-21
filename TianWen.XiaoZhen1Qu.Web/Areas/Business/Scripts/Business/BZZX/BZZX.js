$(document).ready(function () {
    $("#span_head_nav_info_sy").bind("click", ToSY);
    $("#span_head_nav_info_lxkf").bind("click", ToLXKF);
    $("#span_head_nav_info_wzjy").bind("click", ToWZJY);
    if (getUrlParam("TYPE") === "CJWT" || getUrlParam("TYPE") === null)
        ToSY();
    if (getUrlParam("TYPE") === "LXKF")
        ToLXKF();
    if (getUrlParam("TYPE") === "YJFK")
        ToWZJY();
});

//帮助中心_首页
function ToSY() {
    $(".span_head_nav_info").css("background-color", "#bc6ba6");
    $("#span_head_nav_info_sy").css("background-color", "#ad5b97");
    $("#iframeright").attr("src", getRootPath() + "/BZZX/BZZX_SY");
}

//帮助中心_联系客服
function ToLXKF() {
    $(".span_head_nav_info").css("background-color", "#bc6ba6");
    $("#span_head_nav_info_lxkf").css("background-color", "#ad5b97");
    $("#iframeright").attr("src", getRootPath() + "/BZZX/BZZX_LXKF");
}

//帮助中心_网站建议
function ToWZJY() {
    $(".span_head_nav_info").css("background-color", "#bc6ba6");
    $("#span_head_nav_info_wzjy").css("background-color", "#ad5b97");
    $("#iframeright").attr("src", getRootPath() + "/BZZX/BZZX_WZJY");
}

//翻转
function Rotate(obj) {
    var c = $("#canvas")[0];
    var cxt = c.getContext("2d");
    var x = c.width / 2; //画布宽度的一半
    var y = c.height / 2;//画布高度的一半

    var img = new Image();
    img.src = obj.data.src;
    img.onload = function () //确保图片已经加载完毕  
    {
        cxt.clearRect(0, 0, c.width, c.height);
        cxt.translate(x, y);//将绘图原点移到画布中点
        cxt.rotate((Math.PI / 180) * 90);//旋转角度
        cxt.translate(-x, -y);//将画布原点移动
        var left = (c.width - img.width) / 2;
        var top = (c.height - img.height) / 2;
        cxt.drawImage(img, left, top, img.width, img.height);
    }
}
//关闭图片编辑窗口
function CloseWindow() {
    $("#shadow").css("display", "none");
    $("#editImgWindow").css("display", "none");
}