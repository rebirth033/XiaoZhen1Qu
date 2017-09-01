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
//绑定具体问题hover事件
function bindJTWTHover() {
    $(".span_wtjj_inner").each(function () {
        $(this).bind("mouseover", function () {
            $(this).css("color", "#ff6a00");
        })
        $(this).bind("mouseleave", function () {
            $(this).css("color", "#0000cd");
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
        $("#td_xxbhinfo").html("<textarea class=\"textarea_mswt\"></textarea><span>以上信息没有解决您的问题？</span><input class=\"btn btn-info\" type=\"button\" style=\"margin-top: -3px; width: 140px;\" value=\"填表单，联系客服\" onclick=\"TBD()\" />");
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
    if (id.indexOf("qtxxmy") != -1)
        ShowQTXXMY();
    if (id.indexOf("ssbts") != -1)
        ShowSSBTS();
    if (id.indexOf("zhbdj") != -1)
        ShowZHBDJ();
    if (id.indexOf("bpwfczj") != -1)
        ShowBPWFCZJ();
    if (id.indexOf("bpwessj") != -1)
        ShowBPWESSJ();
}
//信息被删除
function ShowXXBSC() {
    $("#span_step_text_second").html("请输入您的信息编号：<span class=\"span_second_lx\">[信息被删除]</span>");
    $("#div_xxbsc").css("display", "block");
    $("#btnCKBSCYY").bind("click", CKBSCYY);
}
//信息被返回修改
function ShowXXBFHXG() {
    $("#span_step_text_second").html("请描述您遇到的问题：<span class=\"span_second_lx\">[信息被返回修改]</span>");
    $("#div_xxbfhxg").css("display", "block");
    $("#tr_xxbh").css("display", "");
    BindWTMS();
}
//信息被判分类不当
function ShowXXBPFLDB() {
    $("#span_step_text_second").html("请描述您遇到的问题：<span class=\"span_second_lx\">[信息被判分类不当]</span>");
    $("#div_xxbfhxg").css("display", "block");
    $("#tr_xxbh").css("display", "");
    BindWTMS();
}
//信息不显示
function ShowXXBXS() {
    $("#span_step_text_second").html("请描述您遇到的问题：<span class=\"span_second_lx\">[信息不显示]</span>");
    $("#div_xxbfhxg").css("display", "block");
    $("#tr_xxbh").css("display", "");
    BindWTMS();
}
//投诉举报虚假信息
function ShowTSJBXJXX() {
    $("#span_step_text_second").html("请描述您遇到的问题：<span class=\"span_second_lx\">[投诉举报虚假信息]</span>");
    $("#div_xxbfhxg").css("display", "block");
    $("#tr_xxbh").css("display", "");
    BindWTMS();
}
//冒用手机号码
function ShowMYSJHM() {
    $("#span_step_text_second").html("请描述您遇到的问题：<span class=\"span_second_lx\">[冒用手机号码]</span>");
    $("#div_xxbfhxg").css("display", "block");
    $("#tr_xxbh").css("display", "none");
    BindWTMS();
}
//其它信息冒用
function ShowQTXXMY() {
    $("#span_step_text_second").html("请选择具体问题：<span class=\"span_second_lx\">[其它信息冒用]</span>");
    $("#div_qtxxmy").css("display", "block");
    $("#div_qtxxmy .span_wtjj_inner").bind("click", SelectJTWT);
}
//申诉被投诉
function ShowSSBTS() {
    $("#span_step_text_second").html("请选择具体问题：<span class=\"span_second_lx\">[申诉被投诉]</span>");
    $("#div_ssbts").css("display", "block");
    $("#div_ssbts .span_wtjj_inner").bind("click", SelectJTWT);
}
//账号被冻结
function ShowZHBDJ() {
    $("#span_step_text_second").html("请选择具体问题：<span class=\"span_second_lx\">[账号被冻结]</span>");
    $("#div_zhbdj").css("display", "block");
    $("#div_zhbdj .span_wtjj_inner").bind("click", SelectJTWT);
}
//被判为房产中介
function ShowBPWFCZJ() {
    $("#span_step_text_second").html("请描述您遇到的问题：<span class=\"span_second_lx\">[被判为房产中介]</span>");
    $("#div_xxbfhxg").css("display", "block");
    $("#tr_xxbh").css("display", "none");
    BindWTMS();
}
//被判为二手商家
function ShowBPWESSJ() {
    $("#span_step_text_second").html("请描述您遇到的问题：<span class=\"span_second_lx\">[被判为二手商家]</span>");
    $("#div_xxbfhxg").css("display", "block");
    $("#tr_xxbh").css("display", "none");
    BindWTMS();
}
//绑定问题描述框
function BindWTMS() {
    $("#textarea_mswt").bind("focus", WTMSFocus);
    $("#textarea_mswt").bind("blur", WTMSBlur);
}
//问题描述框鼠标键入
function WTMSFocus() {
    $("#textarea_mswt").css("color", "#333333");
    $("#textarea_mswt").html("");
}
//问题描述框鼠标移除
function WTMSBlur() {
    $("#textarea_mswt").css("color", "#999999");
    if ($("#textarea_mswt").html() === "") {
        $("#textarea_mswt").html("请描述您的具体问题，字数在15至300之间");
    }
}
//选择具体问题
function SelectJTWT() {
    $(".span_wtjj_inner").each(function () {
        $(this).css("font-weight", "normal").css("color", "#0000cd");
    });
    bindJTWTHover();
    $(this).css("color", "#ef6a00");
    $(this).unbind("mouseleave");
    showJTWT(this.id);
}
//显示具体问题
function showJTWT(id) {
    $(".div_qtxxmy_inner").css("display", "none");
    if (id.indexOf("sfzbmy") != -1) {
        $("#div_wtjj_inner_sfzbmy").css("display", "block");
    }
    if (id.indexOf("mygrxx") != -1) {
        $("#div_wtjj_inner_mygrxx").css("display", "block");
    }
    if (id.indexOf("gsxxbmy") != -1) {
        $("#div_wtjj_inner_gsxxbmy").css("display", "block");
    }
    if (id.indexOf("btswxjwfxx") != -1) {
        $("#div_wtjj_inner_btswxjwfxx").css("display", "block");
    }
    if (id.indexOf("xxbsczmb") != -1) {
        $("#div_wtjj_inner_xxbsczmb").css("display", "block");
    }
    if (id.indexOf("xxbxs") != -1) {
        $("#div_wtjj_inner_xxbxs").css("display", "block");
    }
    if (id.indexOf("rhscdgsdpj") != -1) {
        $("#div_wtjj_inner_rhscdgsdpj").css("display", "block");
    }
    if (id.indexOf("fbxxstssjzhdj") != -1) {
        $("#div_wtjj_inner_fbxxstssjzhdj").css("display", "block");
    }
    if (id.indexOf("zhbdjdyyssm") != -1) {
        $("#div_wtjj_inner_zhbdjdyyssm").css("display", "block");
    }
    if (id.indexOf("zhwfdl") != -1) {
        $("#div_wtjj_inner_zhwfdl").css("display", "block");
    }
}

