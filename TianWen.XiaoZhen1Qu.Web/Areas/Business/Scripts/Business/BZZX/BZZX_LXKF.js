$(document).ready(function () {
    $(".span_wtlx_inner_right").bind("click", SelectWTLX);
    bindHover();
    BindWTMS();
});
//选择问题类型
function SelectWTLX() {
    $(".span_wtlx_inner_right").each(function () {
        $(this).css("background-color", "#eBeBeB").css("font-weight", "normal").css("color", "#000");
    });
    bindHover();
    $(this).css("background-color", "#ff6a00").css("font-weight", "700").css("color", "#fff");
    $(this).unbind("mouseleave");
    showWTLX(this.id);
}
//绑定问题类型hover事件
function bindHover() {
    $(".span_wtlx_inner_right").each(function () {
        $(this).bind("mouseover", function () {
            $(this).css("background-color", "#ff6a00").css("font-weight", "700").css("color", "#fff");
        })
        $(this).bind("mouseleave", function () {
            $(this).css("background-color", "#eBeBeB").css("font-weight", "normal").css("color", "#000");
        })
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
        $("#td_xxbhinfo").html("<textarea class=\"textarea_bscyy\"></textarea><span>以上信息没有解决您的问题？</span><input class=\"btn btn-info\" type=\"button\" style=\"margin-top: -3px; width: 140px;\" value=\"填表单，联系客服\" onclick=\"TBD()\" />");
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
    if (id.indexOf("xxbsc") != -1)
        ShowXXBSC();
    if (id.indexOf("xxbfhxg") != -1)
        ShowXXBFHXG();
    if (id.indexOf("xxbpflbd") != -1)
        ShowXXBPFLDB();
    if (id.indexOf("xxbxs") != -1)
        ShowXXBXS();
    if (id.indexOf("tsjbxjxx") != -1)
        ShowTSJBXJXX();
    if (id.indexOf("mysjhm") != -1)
        ShowMYSJHM();
}
//信息被删除
function ShowXXBSC() {
    $("#span_step_text_second").html("请输入您的信息编号：");
    $("#div_xxbsc").css("display", "block");
    $("#btnCKBSCYY").bind("click", CKBSCYY);
}
//信息被返回修改
function ShowXXBFHXG() {
    $("#span_step_text_second").html("请描述您遇到的问题：");
    $("#div_xxbfhxg").css("display", "block");
    BindWTMS();
}
//信息被判分类不当
function ShowXXBPFLDB() {
    $("#span_step_text_second").html("请描述您遇到的问题：");
    $("#div_xxbfhxg").css("display", "block");
    BindWTMS();
}
//信息不显示
function ShowXXBXS() {
    $("#span_step_text_second").html("请描述您遇到的问题：");
    $("#div_xxbfhxg").css("display", "block");
    BindWTMS();
}
//投诉举报虚假信息
function ShowTSJBXJXX() {
    $("#span_step_text_second").html("请描述您遇到的问题：");
    $("#div_xxbfhxg").css("display", "block");
    BindWTMS();
}
//冒用手机号码
function ShowMYSJHM() {
    $("#span_step_text_second").html("请描述您遇到的问题：");
    $("#div_xxbfhxg").css("display", "block");
    BindWTMS();
}

function BindWTMS() {
    $("#textarea_mswt").bind("focus", WTMSFocus);
    $("#textarea_mswt").bind("blur", WTMSBlur);
}

function WTMSFocus() {
    $("#textarea_mswt").css("color", "#333333");
    $("#textarea_mswt").html("");
}

function WTMSBlur() {
    $("#textarea_mswt").css("color", "#999999");
    if ($("#textarea_mswt").html() === "") {
        $("#textarea_mswt").html("请描述您的具体问题，字数在15至300之间");
    }
}