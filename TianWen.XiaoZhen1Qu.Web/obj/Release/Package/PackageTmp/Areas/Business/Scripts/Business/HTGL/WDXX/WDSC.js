var currentIndex = 1;
$(document).ready(function () {
    $("#spanSCXX").css("color", "#bc6ba6");
    $("#spanSCXX").css("font-weight", "700");
    $("#emSCXX").css("background-color", "#bc6ba6");
    $("#emSCXX").css("height", "2px");
    $(".divstep").bind("click", HeadActive);
    LoadDefault("divSCXX", currentIndex);
});

function HeadActive() {
    $(".divstep").each(function () {
        $(this).find("span").each(function () {
            $(this).css("color", "#cccccc");
            $(this).css("font-weight", "normal");
        });
        $(this).find("em").each(function () {
            $(this).css("background-color", "#cccccc");
            $(this).css("height", "1px");
        });
    });
    $(this).find("span").each(function () {
        $(this).css("color", "#bc6ba6");
        $(this).css("font-weight", "700");
    });
    $(this).find("em").each(function () {
        $(this).css("background-color", "#bc6ba6");
        $(this).css("height", "2px");
    });
    LoadDefault($(this)[0].id, currentIndex);
}

function LoadDefault(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    $.ajax({
        type: "POST",
        url: getRootPath() + "/WDSC/LoadSCXX",
        dataType: "json",
        data:
        {
            PageSize: 4,
            PageIndex: PageIndex
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#div_main_info").html('');
                LoadPage(xml.PageCount);
                LoadInfo(xml.JCXXs,xml.SCXXs);
                if (xml.JCXXs.length === 0)
                    NoInfo(TYPE);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function LoadInfo(JCXXs, SCXXs) {
    var html = "";
    html += ('<ul class="ul_new_info">');
    for (var i = 0; i < JCXXs.length; i++) {
        html += ('<li class="li_new_info" onclick="OpenXXXX(\'' + SCXXs[i].TYPE + '\',\'' + SCXXs[i].TYPEID + '\',\'' + SCXXs[i].LBID + '\')">');
        html += ('<span class="span_info_left">' + JCXXs[i].BT + '</span>');
        html += ('<span class="span_info_middle">' + JCXXs[i].DH + '</span>');
        html += ('<span class="span_info_right">' + JCXXs[i].CJSJ.ToString("yyyy年MM月dd日") + '</span>');
        html += ('</li>');
    }
    html += ('</ul>');
    $("#div_main_info").append(html);
}

function NoInfo(TYPE) {
    if (TYPE === "divSCXX") {
        $("#div_main_info").html('<div class="div_no_info">您没有收藏的信息</div>');
    }
    if (TYPE === "divLLGXX") {
        $("#div_main_info").html('<div class="div_no_info">您没有浏览过的信息</div>');
    }
    if (TYPE === "divGZDP") {
        $("#div_main_info").html('<div class="div_no_info">您没有关注的店铺</div>');
    }
}

function Delete(JCXXID) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/WDSC/DeleteYHSCXX",
        dataType: "json",
        data:
        {
            YHID: "2718ced3-996d-427d-925d-a08e127cc0b8",
            JCXXID: JCXXID
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadByActive();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function LoadByActive() {
    $(".spanstep").each(function (i) {
        if ($("#" + this.id).css("color") === "rgb(188, 107, 166)")
            LoadDefault($("#" + this.id).parent()[0].id);
    });
}

//打开详细页面
function OpenXXXX(TYPE, ID, LBID) {
    window.open(getRootPath() + "/" + TYPE.split('_')[0] + "/" + TYPE + "?ID=" + ID + "&LBID=" + LBID + "&TYPE=" + TYPE);
}
//加载分页
function LoadPage(PageCount) {
    var index = parseInt(currentIndex);
    $("#div_main_info_bottom_fy").html('');
    if (index > 1) {
        $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divSCXX" + '\',\'' + 1 + '\')" class="a_main_info_bottom_fy">首页</a>');
        $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divSCXX" + '\',\'' + (index - 1) + '\')" class="a_main_info_bottom_fy">上一页</a>');
    }
    if (index < 5) {
        for (var i = 1; i <= PageCount; i++) {
            if (i === index)
                $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divSCXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
            else {
                if (i <= 9) {
                    $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divSCXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
                }
            }
        }
    }
    if (index >= 5 && index < PageCount - 4) {
        for (var i = 1; i <= PageCount; i++) {
            if (i === index)
                $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divSCXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
            else {
                if (i >= index - 4 && i <= index + 4) {
                    $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divSCXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
                }
            }
        }
    }
    if (index >= PageCount - 4 && PageCount > 4) {
        for (var i = 1; i <= PageCount; i++) {
            if (i === index)
                $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divSCXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
            else {
                if (i > PageCount - 9) {
                    $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divSCXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
                }
            }
        }
    }

    if (index < PageCount) {
        $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divSCXX" + '\',\'' + (index + 1) + '\')" class="a_main_info_bottom_fy">下一页</a>');
        $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divSCXX" + '\',\'' + PageCount + '\')" class="a_main_info_bottom_fy">尾页</a>');
    }
}