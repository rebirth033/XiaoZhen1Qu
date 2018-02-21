var currentIndex = 1;
$(document).ready(function () {
    $("#imgTXYZM").bind("click", QHTXYZM);
    $("#span_content_info_inner_yzm").bind("click", QHTXYZM);
    $("#input_content_info_cx").bind("click", SJCX);
    $("#input_content_info_qd").bind("click", YZZH);
    $("#span_content_info_sjyzm_tip_inner").bind("click", ToSJHSR);
    $("#checkbox_main_info_bottom").bind("click", SelectAll);
    LoadDefault("divZJFBXX", currentIndex);
});
//切换图形验证码
function QHTXYZM() {
    $("#imgTXYZM").attr("src", getRootPath() + '/Areas/Business/Aspx/png.aspx?' + Math.random());
}
//手机检查
function SJCheck() {
    if (!ValidateCellPhone($("#input_sjhm").val())) {
        $("#input_sjhm").css("border-color", "#F2272D");
        $("#span_sjhm_info").css("color", "#F2272D");
        $("#span_sjhm_info").html("手机号码格式不正确");
        return false;
    }
    else if ($("#input_sjhm").val().length === 0) {
        $("#input_sjhm").css("border-color", "#F2272D");
        $("#span_sjhm_info").css("color", "#F2272D");
        $("#span_sjhm_info").html("请输入手机号");
        return false;
    }
    else {
        $("#input_sjhm").css("border-color", "#999");
        $("#span_sjhm_info").html('');
        return true;
    }
}
//图形验证检查
function TXYZMCheck() {
    if ($("#input_txyzm").val().length === 0) {
        $("#input_txyzm").css("border-color", "#F2272D");
        $("#span_txyzm_info").css("color", "#F2272D");
        $("#span_txyzm_info").html("请输入图形验证码");
        return false;
    }
    if (!/^[0-9]{4}$/.test($("#input_txyzm").val())) {
        $("#input_txyzm").css("border-color", "#F2272D");
        $("#span_txyzm_info").css("color", "#F2272D");
        $("#span_txyzm_info").html("图形验证码输入格式有误");
        return false;
    }
    else {
        $("#input_txyzm").css("border-color", "#999");
        $("#span_txyzm_info").html('');
        return true;
    }
}
//手机查询前检查
function SJCXValidate() {
    if (!SJCheck()) return false;
    if (!TXYZMCheck()) return false;
    return true;
}
//手机查询
function SJCX() {
    if (!SJCXValidate()) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/BZZX/SJCX",
        dataType: "json",
        data:
        {
            SJ: $("#input_sjhm").val(),
            TXYZM: $("#input_txyzm").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                GetCheckCode();

            } else {
                if (xml.Type === 1) {
                    $("#input_sjhm").css("border-color", "#F2272D");
                    $("#span_sjhm_info").css("color", "#F2272D");
                    $("#span_sjhm_info").html(xml.Message);
                }
                if (xml.Type === 2) {
                    $("#input_txyzm").css("border-color", "#F2272D");
                    $("#span_txyzm_info").css("color", "#F2272D");
                    $("#span_txyzm_info").html(xml.Message);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//手机号输入
function ToSJHSR() {
    $("#div_sjhsr").css("display", "block");
    $("#div_htyzm").css("display", "none");
    $("#div_sdzh").css("display", "none");
}
//回填验证码
function ToHYTZM() {
    $("#div_sjhsr").css("display", "none");
    $("#div_htyzm").css("display", "block");
    $("#div_sdzh").css("display", "none");
}
//账号锁定
function ToZHSD() {
    $("#div_sjhsr").css("display", "none");
    $("#div_htyzm").css("display", "none");
    $("#div_sdzh").css("display", "block");
}
//获取手机验证码
function GetCheckCode() {
    $.ajax({
        type: "POST",
        dataType: "json",
        url: getRootPath() + "/YHJBXX/GetYZM",
        data: {
            SJ: $("#input_sjhm").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                ToHYTZM();
            }
            else {
                window.wxc.xcConfirm("验证码发送失败", window.wxc.xcConfirm.typeEnum.error);
            }
        }
    });
}
//验证账户前检查
function YZZHValidate() {
    if (!YZMCheck()) return false;
    return true;
}
//验证码检查
function YZMCheck() {
    if ($("#input_sjyzm").val().length === 0) {
        $("#input_sjyzm").css("border-color", "#F2272D");
        $("#span_sjyzm_info").css("color", "#F2272D");
        $("#span_sjyzm_info").html("请输入手机验证码");
        return false;
    }
    if (!/^[0-9]{6}$/.test($("#input_sjyzm").val())) {
        $("#input_sjyzm").css("border-color", "#F2272D");
        $("#span_sjyzm_info").css("color", "#F2272D");
        $("#span_sjyzm_info").html("手机验证码输入格式有误");
        return false;
    }
    else {
        $("#input_sjyzm").css("border-color", "#999");
        $("#span_sjyzm_info").html('');
        return true;
    }
}
//验证账户
function YZZH() {
    if (!YZZHValidate()) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/BZZX/YZZH",
        dataType: "json",
        data:
        {
            SJ: $("#input_sjhm").val(),
            YZM: $("#input_sjyzm").val(),
        },
        success: function (xml) {
            if (xml.Result === 1) {
                ToZHSD();
            } else {
                if (xml.Type === 1) {
                    $("#input_sjyzm").css("border-color", "#F2272D");
                    $("#span_sjyzm_info").css("color", "#F2272D");
                    $("#span_sjyzm_info").html(xml.Message);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载发布信息
function LoadDefault(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    $.ajax({
        type: "POST",
        url: getRootPath() + "/WDFB/LoadYHFBXX",
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
//发布信息html拼接
function LoadInfo(obj) {
    var html = "";
    html += ('<tr class="tr_main_info">');
    html += ('<td style="width:40px;"><input type="checkbox" value="' + obj.YHXXID + '" /></td>');
    html += ('<td style="width:360px;"><span class="span_main_info_bt">' + obj.BT + '</span></td>');
    html += ('<td style="width:250px;">' + obj.JCXXID + '</td>');
    html += ('<td style="width:250px;">' + obj.CJSJ.ToString("yyyy-MM-dd hh:mm:ss") + '</td>');
    html += ('</tr>');
    $("#tbody_main_info_xttz").append(html);
}
//加载分页
function LoadPage(PageCount) {
    var index = parseInt(currentIndex);
    $("#div_main_info_bottom_fy").html('');
    if (index > 1) {
        $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + (index - 1) + '\')" class="a_main_info_bottom_fy">上一页</a>');
    }
    for (var i = 1; i <= PageCount; i++) {
        if (i === index)
            $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy a_main_info_bottom_fy_current">' + i + '</a>');
        else
            $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + i + '\')" class="a_main_info_bottom_fy">' + i + '</a>');
    }
    if (index < PageCount) {
        $("#div_main_info_bottom_fy").append('<a onclick="LoadDefault(\'' + "divZJFBXX" + '\',\'' + (index + 1) + '\')" class="a_main_info_bottom_fy">下一页</a>');
    }
}
//全选
function SelectAll() {
    $("#tbody_main_info_xttz").find("input[type='checkbox']").each(function () {
        if ($("#checkbox_main_info_bottom").prop("checked") === true)
            $(this).prop("checked", true);
        else
            $(this).prop("checked", false);
    });
}