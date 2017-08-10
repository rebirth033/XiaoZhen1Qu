$(document).ready(function () {
    $("#spanWXZF").css("color", "#31b0d5");
    $("#spanWXZF").css("font-weight", "700");
    $("#emWXZF").css("background-color", "#31b0d5");
    $("#emWXZF").css("height", "2px");
    $(".divstep").bind("click", HeadActive);
    LoadDefault("divWXZF");
});

function HeadActive() {
    $(".divstep").each(function () {
        $(this).find("span").each(function () {
            $(this).css("color", "#cccccc");
            $(this).css("font-weight", "normal");
        });
        $(this).find("em").each(function () {
            $(this).css("height", "1px");
            $(this).css("background-color", "#cccccc");
        });
    });
    $(this).find("span").each(function () {
        $(this).css("color", "#31b0d5");
        $(this).css("font-weight", "700");
    });
    $(this).find("em").each(function () {
        $(this).css("height", "2px");
        $(this).css("background-color", "#31b0d5");
    });
    LoadDivInfo(this.id);
}

function LoadDefault(id) {
    $("#img_radio_wxzf").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    //$("#imgDJCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    LoadDivInfo(id);
}

function LoadDivInfo(id) {
    if (id === "divWXZF") {
        $("#div_WXZF").css("display", "block");
        //$("#div_DJJDJL").css("display", "none");
        //LoadSZMX();
    }
    //else {
    //    $("#div_SZMX").css("display", "none");
    //    $("#div_DJJDJL").css("display", "block");
    //    LoadDJJDJL();
    //}
}