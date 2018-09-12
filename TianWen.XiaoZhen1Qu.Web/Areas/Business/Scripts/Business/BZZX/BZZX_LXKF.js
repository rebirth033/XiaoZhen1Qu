$(document).ready(function () {
    $(".span_wtlx_inner_right").bind("click", SelectWTLX);
    $("#btn_submit").bind("click", TJWT);
    $("#input_upload").bind("change", UploadZP);
    bindHover();
    BindWTMS();
});
function ValidateZP() {
    
}
//选择问题类型
function SelectWTLX() {
    $(".span_wtlx_inner_right").each(function () {
        $(this).css("background-color", "#eBeBeB").css("font-weight", "normal").css("color", "#000");
    });
    bindHover();
    $(this).css("background-color", "#bc6ba6").css("font-weight", "700").css("color", "#fff");
    $(this).unbind("mouseleave");
    showWTLX(this.id);
}
//绑定问题类型hover事件
function bindHover() {
    $(".span_wtlx_inner_right").each(function () {
        $(this).bind("mouseover", function () {
            $(this).css("background-color", "#bc6ba6").css("font-weight", "700").css("color", "#fff");
        });
        $(this).bind("mouseleave", function () {
            $(this).css("background-color", "#eBeBeB").css("font-weight", "normal").css("color", "#000");
        });
    });
}
//绑定具体问题hover事件
function bindJTWTHover() {
    $(".span_wtjj_inner").each(function () {
        $(this).bind("mouseover", function () {
            $(this).css("color", "#bc6ba6");
        });
        $(this).bind("mouseleave", function () {
            $(this).css("color", "#0000cd");
        });
    });
}
//查询信息被删除原因
function CKBSCYY() {
    if (!XXBHCheck()) return;
}
//信息编号检查
function XXBHCheck() {
    if ($("#inputXXBH").val().length === 0) {
        $("#inputXXBH").css("border-color", "#F2272D");
        $("#td_xxbhinfo").html("<span id=\"XXBHInfo\" style=\"padding-left:12px;color:#F2272D\">请输入信息编号</span>");
        return false;
    }
    else {
        $("#inputXXBH").css("border-color", "#999");
        $("#td_xxbhinfo").html("<textarea class=\"textareaWTMS\"></textarea><span>以上信息没有解决您的问题?</span><input class=\"btn btn-info\" type=\"button\" style=\"margin-top: -3px; width: 140px;\" value=\"填表单，联系客服\" onclick=\"TBD()\" />");
        return true;
    }
}
//信息被删除->填表单
function TBD() {
    $("#div_content_tjkf").css("display", "block");
}
//显示问题类型
function showWTLX(id) {
    $(".div_wtjj_inner").each(function () {
        $(this).css("display", "none");
    });
    ShowXXBSC($("#" + id).html());
}
//获取问题类型
function GetWTLX() {
    var wtlx = "";
    $(".span_wtlx_inner_right").each(function() {
        if ($(this).css("color") === "rgb(255, 255, 255)") {
            wtlx = $(this).html();
        }
    });
    return wtlx;
}
//信息被删除
function ShowXXBSC(text) {
        $("#span_step_text_second").html("请输入您的信息编号：<span class=\"span_second_lx\">[" + text + "]</span>");
        $("#div_xxbsc").css("display", "block");
        $("#div_step_two").css("display", "block");
        $("#btnCKBSCYY").bind("click", CKBSCYY);
        if(text === "信息被删除" || text === "信息被返回修改" || text === "信息被判分类不当" || text === "信息不显示/无法刷新" || text === "投诉举报虚假信息")
            $("#tr_xxbh").css("display", "");
	else 
	    $("#tr_xxbh").css("display", "none");
}
//绑定问题描述框
function BindWTMS() {
    $("#textareaWTMS").bind("focus", WTMSFocus);
    $("#textareaWTMS").bind("blur", WTMSBlur);
}
//问题描述框鼠标键入
function WTMSFocus() {
    $("#textareaWTMS").css("color", "#333333");
    $("#textareaWTMS").html("");
}
//问题描述框鼠标移除
function WTMSBlur() {
    $("#textareaWTMS").css("color", "#999999");
    if ($("#textareaWTMS").html() === "") {
        $("#textareaWTMS").html("请描述您的具体问题，字数在500字以内");
    }
}
//问题描述检查
function CheckWTMS() {
    if ($("#textareaWTMS").val().indexOf("问题描述在500字以内") !== -1) {
        $("#textareaWTMS").css("border-color", "#F2272D");
        $("#span_wtmsinfo").css("color", "#F2272D");
        $("#span_wtmsinfo").html("问题描述在500字以内，不可为空");
        return false;
    }
    else {
        $("#textareaWTMS").css("border-color", "#DEDEDE");
        $("#span_wtmsinfo").html("");
        return true;
    }
}
//提交问题验证
function ValidateTJWT() {
    if (CheckWTMS())
        return true;
    else
        return false;
}
//提交问题
function TJWT() {
    if (ValidateTJWT() === false) return;
    $.ajax({
        type: "POST",
        url: getRootPath() + "/BZZX/SaveTJWT",
        dataType: "json",
        data:
        {
            WTLX: GetWTLX(),
            XXBH: $("#inputXXBH").val(),
            WTMS: $("#textareaWTMS").html(),
            FWZP: GetPhotoUrls()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                alert(xml.Message);
                window.location.href = window.location.href;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}