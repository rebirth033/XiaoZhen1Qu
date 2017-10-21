var currentIndex = 1;
$(document).ready(function () {
    $("#spanZJFBXX").css("color", "#5bc0de");
    $("#spanZJFBXX").css("font-weight", "700");
    $("#emZJFBXX").css("background-color", "#5bc0de");
    $("#emZJFBXX").css("height", "2px");
    $(".divstep").bind("click", HeadActive);
    LoadDefault("divZJFBXX", currentIndex);
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
        $(this).css("color", "#5bc0de");
        $(this).css("font-weight", "700");
    });
    $(this).find("em").each(function () {
        $(this).css("height", "2px");
        $(this).css("background-color", "#5bc0de");
    });
    LoadDefault($(this)[0].id, currentIndex);
}

function LoadDefault(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/WDFB/LoadYHFBXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            PageSize: 4,
            PageIndex: PageIndex
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#div_main_info").html('');
                LoadPage(xml.PageCount);
                $("#span_main_info_head_gjt").html(xml.TotalCount);
                for (var i = 0; i < xml.list.length; i++) {
                    LoadInfo(xml.list[i]);
                }
                if (xml.list.length === 0)
                    NoInfo(TYPE);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function LoadInfo(obj) {
    var html = "";
    html += ('<ul class="ul_new_info">');
    html += ('<li class="li_new_info">');
    html += ('<div class="div_new_info">');
    html += ('<div class="div_new_info_head">');
    html += ('<span class="span_new_info_head">信息号: ' + obj.JCXXID + '</span>');
    html += ('</div>');
    html += ('<div class="div_new_info_body">');
    html += ('<div class="div_new_info_body_left">');
    html += ('<div class="div_new_info_body_left_inner">');
    html += ('<div class="div_new_info_body_left_inner_img">');
    if (obj.PHOTOS.length > 0)
        html += ('<img class="img_new_info_body_left" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    else
        html += ('<img class="img_new_info_body_left" />');
    html += ('</div>');
    html += ('<div class="div_new_info_body_left_inner_info">');
    html += ('<span class="span_new_info_body_left_bt">' + obj.BT + '</span>');
    html += ('<span class="span_new_info_body_left_rq">' + obj.CJSJ.ToString("yyyy-MM-dd hh:mm:ss") + '</span>');
    html += ('<span class="span_new_info_body_left_dh">' + obj.DH + '</span>');
    html += ('</div>');
    html += ('</div>');
    html += ('</div>');
    html += ('<div class="div_new_info_body_middle">');
    if (obj.STATUS === 1) {
        html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_status">显示中</span>');
        html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_read">浏览:' + obj.LLCS + '</span>');
        html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_tip">进行置顶或精准推广会让你的信息成交更快哦。</span>');
    }
    else
        html += ('<span class="span_new_info_body_middle">个人删除</span>');
    html += ('</div>');
    html += ('<div class="div_new_info_body_right">');
    if (obj.STATUS === 0)
        html += ('<span class="span_new_info_body_right active" onclick="Restore(\'' + obj.JCXXID + '\')">恢复</span>');
    else {
        html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_common_button span_new_info_body_middle_update" onclick="Update(\'' + obj.JCXXID + '\',\'' + obj.LBID + '\')">修改</span>');
        html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_common_button span_new_info_body_middle_refresh">刷新</span>');
        html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_common_button span_new_info_body_middle_top">置顶</span>');
        html += ('<span class="span_new_info_body_middle_common span_new_info_body_middle_common_button span_new_info_body_middle_delete"  onclick="Delete(\'' + obj.JCXXID + '\')">删除</span>');
    }
    html += ('</div>');
    html += ('</div>');
    html += ('</div>');
    html += ('</li>');
    html += ('</ul>');
    $("#div_main_info").append(html);
}

function NoInfo(TYPE) {
    if (TYPE === "divZJFBXX") {
        $("#div_main_info").html('<div class="div_no_info">您最近三个月内没有发布信息</div>');
    }
    if (TYPE === "divXSZXX") {
        $("#div_main_info").html('<div class="div_no_info">您没有显示中的信息</div>');
    }
    if (TYPE === "divDSHXX") {
        $("#div_main_info").html('<div class="div_no_info">您没有待审核的信息</div>');
    }
    if (TYPE === "divYSCXX") {
        $("#div_main_info").html('<div class="div_no_info">您没有已删除的信息</div>');
    }
    if (TYPE === "divWXSXX") {
        $("#div_main_info").html('<div class="div_no_info">您没有未显示的信息</div>');
    }
}

function Restore(JCXXID) {
    if (confirm("您确定恢复本条信息吗?")) {
        $.ajax({
            type: "POST",
            url: getRootPath() + "/Business/WDFB/UpdateYHFBXX",
            dataType: "json",
            data:
            {
                JCXXID: JCXXID,
                OPTYPE: "RESTORE"
            },
            success: function (xml) {
                if (xml.Result === 1) {
                    alert("信息恢复成功");
                    LoadByActive();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
                _masker.CloseMasker(false, errorThrown);
            }
        });
    }
}

function Delete(JCXXID) {
    if (confirm("您确定删除本条信息吗?")) {
        $.ajax({
            type: "POST",
            url: getRootPath() + "/Business/WDFB/UpdateYHFBXX",
            dataType: "json",
            data:
            {
                JCXXID: JCXXID,
                OPTYPE: "DELETE"
            },
            success: function (xml) {
                if (xml.Result === 1) {
                    alert("信息删除成功");
                    LoadByActive();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
                _masker.CloseMasker(false, errorThrown);
            }
        });
    }
}

function Update(JCXXID, LBID) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/GetIDByJCXXIDAndLBID",
        dataType: "json",
        data:
        {
            JCXXID: JCXXID,
            LBID: LBID
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.open(getRootPath() + "/Business/" + xml.Value.FBYM + "/" + xml.Value.FBYM + "?" + xml.Value.Key + "=" + xml.Value.Value + "&CLICKID=" + xml.Value.LBID);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function LoadByActive() {
    $(".spanstep").each(function (i) {
        if ($("#" + this.id).css("color") === "rgb(91, 192, 222)")
            LoadDefault($("#" + this.id).parent()[0].id, currentIndex);
    });
}

function LoadPage(PageCount) {
    var index = parseInt(currentIndex);
    $("#div_main_info_bottom_fy").html('');
    if (index > 1) {
        $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + 1 + '\')" class="a_main_info_bottom_fy">首页</a>');
        $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + (index - 1) + '\')" class="a_main_info_bottom_fy">上一页</a>');
    }
    if (index < 5) {
        for (var i = 1; i <= PageCount; i++) {
            if (i === index)
                $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
            else {
                if (i <= 9) {
                    $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
                }
            }
        }
    }
    if (index >= 5 && index < PageCount - 4) {
        for (var i = 1; i <= PageCount; i++) {
            if (i === index)
                $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
            else {
                if (i >= index - 4 && i <= index + 4) {
                    $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
                }
            }
        }
    }
    if (index >= PageCount - 4 && PageCount > 4) {
        for (var i = 1; i <= PageCount; i++) {
            if (i === index)
                $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
            else {
                if (i > PageCount - 9) {
                    $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
                }
            }
        }
    }

    if (index < PageCount) {
        $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + (index + 1) + '\')" class="a_main_info_bottom_fy">下一页</a>');
        $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + PageCount + '\')" class="a_main_info_bottom_fy">尾页</a>');
    }
}