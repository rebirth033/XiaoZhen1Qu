﻿$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $("#span_fbxx").bind("click", FBXX);
    LoadDefault();
    GetHeadNav();
});
//获取头部导航
function GetHeadNav() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/SY/LoadSY_ML",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "", title = "";
                html += ('<ul class="ul_nav">');
                html += ('<li class="li_nav_font">风铃网</li>');
                html += ('<li class="li_nav_split">></li>');
                title += "风铃网";
                for (var i = 0; i < xml.list.length; i++) {
                    if (xml.list[i].LBID === parseInt(getUrlParam("LBID"))) {
                        html += ('<li class="li_nav_font">' + xml.xzq + xml.list[i].TYPESHOWNAME + '</li>');
                        title += "_" + xml.xzq + xml.list[i].TYPESHOWNAME;
                        break;
                    }
                }
                html += ('<li class="li_nav_split">></li>');
                for (var i = 0; i < xml.list.length; i++) {
                    if (xml.list[i].LBID === parseInt(getUrlParam("LBID"))) {
                        html += ('<li class="li_nav_font">' + xml.xzq + xml.list[i].LBNAME + '</li>');
                        $("#li_body_head_first").html(xml.xzq + xml.list[i].LBNAME + "");
                        title += "_" + xml.xzq + xml.list[i].LBNAME;
                        break;
                    }
                }
                html += ('</ul>');
                $("#divNav").html(html);
                $("#title").html(title);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}
//加载个人信息
function LoadGRXX(grxx) {
    var html = "";
    html += ('<div class="div_body_right_grxx">');
    if (grxx.TX === null)
        html += ('<img class="img_div_body_right_grxx" src="' + getRootPath() + "/Areas/Business/Css/images/default_tx.png?j=" + Math.random() + '" />');
    else
        html += ('<img class="img_div_body_right_grxx"  src="' + getRootPath() + "/Areas/Business/Photos/" + grxx.YHID + "/GRZL/TX.jpg?j=" + Math.random() + '" />');
    html += ('<p class="p_div_body_right_yhm">' + grxx.YHM + '</p>');
    html += ('<p class="p_div_body_right_zcsj">注册时间：' + grxx.SQRQ.ToString("yyyy年MM月dd日") + '</p>');
    html += ('<div class="div_div_body_right_yyzz">');
    html += ('</div>');
    html += ('<div class="div_div_body_right_ckxy">查看TA的信用记录</div>');
    html += ('</div>');
    $("#div_body_right").append(html);
}
//处理图片信息
function HandlerTPXX() {
    $(".div_img_body_left_body_left_list_tp:eq(0)").each(function () { 
	$(this).css("background-color", "rgba(0,0,0,0)") 
    });

    $(".li_body_left_body_left_list_tp").bind("mouseover", function () {
        $("#img_body_left_body_left_show").attr("src", $(this).find("img")[0].src);
        $(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0.5)");
        $(this).find(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0)");
    });
    if ($("#img_body_left_body_left_show").length > 0) {
     	var img = new Image();
     	img.src = $("#img_body_left_body_left_show").attr("src");
     	$("#img_body_left_body_left_show").css("width", ((img.width > 460 || img.width === 0) ? 460 : img.width));
        $("#img_body_left_body_left_show").css("height", ((img.height > 350 || img.height === 0) ? 350 : img.height));
    }

    $(".img_body_left_body_xq_xx").each(function () {
        var img = new Image();
        img.src = $("#" + this.id).attr("src");

	var width = img.width;//区域宽度
        var height = img.height;//区域高度
	var ratio = 405 / 350;//宽高比
 	imgWidth = img.width;//图片实际宽度
        imgHeight = img.height;//图片实际高度
        imgRatio = imgWidth / imgHeight;//实际宽高比
        if (ratio > imgRatio) {
             showWidth = height * imgRatio;//调整宽度太小
             $("#" + this.id).attr('width', showWidth).css('margin-left', (width - showWidth) / 2);
        } else {
             showHeight = width / imgRatio;//调高度太小
             $("#" + this.id).attr('height', showHeight).css('margin-top', (height - showHeight) / 2);
        }

        $("#" + this.id).css("width", 405)
        $("#" + this.id).css("height", 350);
    });
}
//图片左侧切换
function LeftImg() {
    if (right > 0) {
        right -= 1;
        $("#ul_body_left_body_left_list").css("transform", "translate3d(-" + right * 100 + "px, 0px, 0px)").css("transition-duration", "500ms");
        $("#ul_body_left_body_left_list").find(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0.5)");
        $("#ul_body_left_body_left_list").find(".li_body_left_body_left_list_tp:eq(" + right + ")").find(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0)");
        $("#img_body_left_body_left_show").attr("src", $("#ul_body_left_body_left_list").find(".li_body_left_body_left_list_tp:eq(" + right + ")").find("img")[0].src);
    }
}
//图片右侧切换
function RightImg(length) {
    if (right < length - 4) {
        right += 1;
        $("#ul_body_left_body_left_list").css("transform", "translate3d(-" + right * 100 + "px, 0px, 0px)").css("transition-duration", "500ms");
        $("#ul_body_left_body_left_list").find(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0.5)");
        $("#ul_body_left_body_left_list").find(".li_body_left_body_left_list_tp:eq(" + right + ")").find(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0)");
        $("#img_body_left_body_left_show").attr("src", $("#ul_body_left_body_left_list").find(".li_body_left_body_left_list_tp:eq(" + right + ")").find("img")[0].src);
    }
}
//伸缩图片
function ToggleImg(length) {
    if ($("#div_body_left_body_xq_zk").html().indexOf("展开") !== -1) {
        $("#div_body_left_body_xq_xx").css("overflow", "visible").css("height", "auto").css("margin-bottom", "0");
        $("#div_body_left_body_xq_zk").html("收起更多图片 共（" + length + "）张");
    } else {
        $("#div_body_left_body_xq_xx").css("overflow", "hidden").css("height", "710px").css("margin-bottom", "10px");
        $("#div_body_left_body_xq_zk").html("展开更多图片 共（" + length + "）张");
    }
}
//伸缩详情描述
function ToggleBCMS() {
    if ($("#div_body_left_body_xq_zk_bcms").html().indexOf("展开") !== -1) {
        $("#div_body_left_body_xq_xx_bcms").css("overflow", "visible").css("height", "auto");
        $("#div_body_left_body_xq_zk_bcms").html('收起内容<i id="i_body_left_body_xq_zk_bcms" class="i_body_left_body_xq_zk_bcms"></i>');
        $("#i_body_left_body_xq_zk_bcms").css("background-image", "url(" + getRootPath() + "/areas/business/css/images/head_nav_up.png)");
    } else {
        $("#div_body_left_body_xq_xx_bcms").css("overflow", "hidden").css("height", "300px");
        $("#div_body_left_body_xq_zk_bcms").html('展开内容<i id="i_body_left_body_xq_zk_bcms" class="i_body_left_body_xq_zk_bcms"></i>');
        $("#i_body_left_body_xq_zk_bcms").css("background-image", "url(" + getRootPath() + "/areas/business/css/images/head_nav_down.png)");
    }
}
//发布信息
function FBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/LBXZ/LoadLBByID",
        dataType: "json",
        data:
        {
            LBID: getUrlParam("LBID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.open(getRootPath() + "/" + xml.list[0].FBYM.split('_')[0] + "/" + xml.list[0].FBYM + "?CLICKID=" + getUrlParam("LBID"));
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载价格
function GetJG(jg, dw) {
    if (jg === "面议")
        return '<span class="span_zj">面议</span>';
    else
        return '<span class="span_zj">' + jg + '</span>' + dw;
}
//隐藏完整电话
function HideWZDH() {
    $(".span_body_left_body_right_wzdh").fadeOut();
}
//显示完整电话
function ShowWZDH() {
    $(".span_body_left_body_right_wzdh").fadeIn().css("display", "block");
}
//获取楼层
function GetLC(szc, gjc) {
    if (parseInt(szc) < parseInt(gjc / 3))
        return "低层";
    if (parseInt(szc) >= parseInt(gjc / 3) && parseInt(szc) < parseInt(gjc / 3 * 2))
        return "中层";
    if (parseInt(szc) >= parseInt(gjc / 3 * 2))
        return "高层";
}
//处理显示数据
function HandlerData(value) {
    if (value.indexOf("请选择") !== -1)
        return "暂无数据";
    else
        return value;
}
//收藏信息
function SCXX(jcxxid) {
    if ($("#input_yhm").val() !== "") {
        $.ajax({
            type: "POST",
            url: getRootPath() + "/WDSC/SCXX",
            dataType: "json",
            data:
            {
                JCXXID: jcxxid,
                TYPE: getUrlParam("TYPE"),
                TYPEID: getUrlParam("ID"),
                LBID: getUrlParam("LBID")
            },
            success: function (xml) {
                if (xml.Result === 1) {
                    window.wxc.xcConfirm("已添加到我的收藏", window.wxc.xcConfirm.typeEnum.success);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

            }
        });
    }
    else {
        window.location.href = getRootPath() + "/YHDL/YHDL?To=SY";
    }
}
//绑定图片点击预览事件
function ImgShow() {
    $("#div_shadow").css("display", "block");
    $("#div_close").css("display", "block");
}
