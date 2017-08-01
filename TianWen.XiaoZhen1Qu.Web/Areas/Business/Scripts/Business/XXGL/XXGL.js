var currentIndex = 1;
$(document).ready(function () {
    $("#spanXTTZ").css("color", "#5bc0de");
    $("#spanXTTZ").css("font-weight", "700");
    $("#emXTTZ").css("background-color", "#5bc0de");
    $("#emXTTZ").css("height", "2px");
    $(".divstep").bind("click", HeadActive);
    $("#checkbox_main_info_bottom").bind("click", SelectAll);
    $("#input_main_info_bottom_scxzx").bind("click", DeleteSelect);
    $("#input_main_info_bottom_swzd").bind("click", ZDSelect);
    LoadDefault("divXTTZLB", currentIndex);
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
    LoadDefault($(this)[0].id + "LB", 1);
}

function LoadDefault(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/XXGL/LoadYHXX",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID"),
            TYPE: TYPE,
            PageSize: 10,
            PageIndex: PageIndex
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadPage(xml.PageCount);
                $("#tbody_main_info_xttz").html('');
                $("#span_main_info_head_gjt").html(xml.TotalCount);
                $("#span_main_info_head_wdjt").html(xml.WCCount);
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

function LoadPage(PageCount) {
    var index = parseInt(currentIndex);
    $("#div_main_info_bottom_fy").html('');
    if (index > 1) {
        $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divXTTZLB" + '\',\'' + (index - 1) + '\')" class="a_main_info_bottom_fy">上一页</a>');
    }
    for (var i = 1; i <= PageCount; i++) {
        if (i === index)
            $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divXTTZLB" + '\',\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
        else
            $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divXTTZLB" + '\',\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
    }
    if (index < PageCount) {
        $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divXTTZLB" + '\',\'' + (index + 1) + '\')" class="a_main_info_bottom_fy">下一页</a>');
    }
}

function LoadInfo(obj) {
    var html = "";
    html += ('<tr class="tr_main_info">');
    html += ('<td style="width:40px;"><input type="checkbox" value="' + obj.YHXXID + '" /></td>');
    html += ('<td style="width:120px;">' + obj.FJR + '</td>');
    html += ('<td style="width:400px;"><a class="a_main_info_xxnr">' + obj.XXNR + '</a>。</td>');
    html += ('<td style="width:120px;">' + obj.XXSJ.ToString("yyyy-MM-dd hh:mm:ss") + '</td>');
    html += ('<td style="width:80px;"><a class="a_main_info_cz" onclick="DeleteYHXX(' + obj.YHXXID + ')">删除</a></td>');
    html += ('</tr>');
    $("#tbody_main_info_xttz").append(html);
}

function NoInfo(TYPE) {
    if (TYPE === "divXTTZLB") {
        $("#tbody_main_info_xttz").html('<div class="div_no_info">您暂时没有系统通知消息</div>');
    }
    if (TYPE === "divKHZXLB") {
        $("#div_main_info").html('<div class="div_no_info">您暂时没有咨询消息</div>');
    }
    if (TYPE === "divWDZXLB") {
        $("#div_main_info").html('<div class="div_no_info">您暂时没有咨询消息</div>');
    }
}

function DeleteYHXX(YHXXID) {
    if (confirm("确定要删除吗?")) {
        $.ajax({
            type: "POST",
            url: getRootPath() + "/Business/XXGL/DeleteYHXX",
            dataType: "json",
            data:
            {
                YHXXID: YHXXID
            },
            success: function (xml) {
                if (xml.Result === 1) {
                    LoadDefault("divXTTZLB", currentIndex);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

            }
        });
    }
}

function ZDYHXX(YHXXID) {
    if (confirm("确定要将这些消息设成已读吗?")) {
        $.ajax({
            type: "POST",
            url: getRootPath() + "/Business/XXGL/ZDYHXX",
            dataType: "json",
            data:
            {
                YHXXID: YHXXID
            },
            success: function(xml) {
                if (xml.Result === 1) {
                    LoadDefault("divXTTZLB", currentIndex);
                }
            },
            error: function(XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

            }
        });
    }
}

function SelectAll() {
    $("#tbody_main_info_xttz").find("input[type='checkbox']").each(function () {
        if ($("#checkbox_main_info_bottom").prop("checked") === true)
            $(this).prop("checked", true);
        else
            $(this).prop("checked", false);
    });
}

function DeleteSelect() {
    var selects = "";
    $("#tbody_main_info_xttz").find("input[type='checkbox']").each(function () {
        if ($(this).prop("checked") === true)
            selects += $(this).val() + ",";
    });
    DeleteYHXX(RTrim(selects));
}

function ZDSelect() {
    var selects = "";
    $("#tbody_main_info_xttz").find("input[type='checkbox']").each(function () {
        if ($(this).prop("checked") === true)
            selects += $(this).val() + ",";
    });
    ZDYHXX(RTrim(selects));
}