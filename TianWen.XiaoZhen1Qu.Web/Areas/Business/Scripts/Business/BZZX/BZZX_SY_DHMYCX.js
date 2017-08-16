$(document).ready(function () {
    $("#imgTXYZM").bind("click", QHTXYZM);
    $("#span_content_info_inner_yzm").bind("click", QHTXYZM);
});


function QHTXYZM() {
    $("#imgTXYZM").attr("src", getRootPath() + '/Areas/Business/Aspx/png.aspx?' + Math.random());
}