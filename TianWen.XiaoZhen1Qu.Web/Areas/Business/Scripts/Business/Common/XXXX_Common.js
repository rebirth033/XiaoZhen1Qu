﻿var imgIndex = 0;
$(document).ready(function () {
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
    //$(".div_img_body_left_body_left_list_tp:eq(0)").each(function () { 
	//$(this).css("background-color", "rgba(0,0,0,0)") 
    //});
    //if ($("#img_body_left_body_left_show").length > 0) {
    // 	var img = new Image();
    // 	img.src = $("#img_body_left_body_left_show").attr("src");
    // 	$("#img_body_left_body_left_show").css("width", ((img.width > 460 || img.width === 0) ? 460 : img.width));
    //    $("#img_body_left_body_left_show").css("height", ((img.height > 350 || img.height === 0) ? 350 : img.height));
    //}

    //$(".img_body_left_body_xq_xx").each(function () {
    //    var img = new Image();
    //    img.src = $("#" + this.id).attr("src");

	//var width = img.width;//区域宽度
    //    var height = img.height;//区域高度
	//var ratio = 405 / 350;//宽高比
 	//imgWidth = img.width;//图片实际宽度
    //    imgHeight = img.height;//图片实际高度
    //    imgRatio = imgWidth / imgHeight;//实际宽高比
    //    if (ratio > imgRatio) {
    //         showWidth = height * imgRatio;//调整宽度太小
    //         $("#" + this.id).attr('width', showWidth).css('margin-left', (width - showWidth) / 2);
    //    } else {
    //         showHeight = width / imgRatio;//调高度太小
    //         $("#" + this.id).attr('height', showHeight).css('margin-top', (height - showHeight) / 2);
    //    }

    //    $("#" + this.id).css("width", 405)
    //    $("#" + this.id).css("height", 350);
    //});
}
//图片左侧切换
function LeftImg(length) {
    if (imgIndex> 0) {
	if(imgIndex <= length - 4 && $("#ul_body_left_body_left_list").css("transform").indexOf("-") !== -1)
            $("#ul_body_left_body_left_list").css("transform", "translate3d(-" + (imgIndex-1) * 100 + "px, 0px, 0px)").css("transition-duration", "500ms");
        imgIndex -= 1;
        $("#ul_body_left_body_left_list").find(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0.5)");
        $("#ul_body_left_body_left_list").find(".li_body_left_body_left_list_tp:eq(" + imgIndex + ")").find(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0)");
        $("#img_body_left_body_left_show").attr("src", $("#ul_body_left_body_left_list").find(".li_body_left_body_left_list_tp:eq(" + imgIndex + ")").find("img")[0].src);
    }
}
//图片右侧切换
function RightImg(length) {
    if (imgIndex < length-1) {
	if(imgIndex >= 3)
            $("#ul_body_left_body_left_list").css("transform", "translate3d(-" + (imgIndex-2) * 100 + "px, 0px, 0px)").css("transition-duration", "500ms");
        imgIndex += 1;
        $("#ul_body_left_body_left_list").find(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0.5)");
        $("#ul_body_left_body_left_list").find(".li_body_left_body_left_list_tp:eq(" + imgIndex + ")").find(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0)");
        $("#img_body_left_body_left_show").attr("src", $("#ul_body_left_body_left_list").find(".li_body_left_body_left_list_tp:eq(" + imgIndex + ")").find("img")[0].src);
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
function ImgShow(obj) {
    $("#div_show").html('');
    var show_html = ('<div class="div_show_left" onclick="LeftShowImg(' + $(".img_body_left_body_left_list_tp").length + ')"><img class="img_show_left" /></div>');
    show_html += ('<div class="div_show_middle">');
    show_html += ('<div class="div_show_middle_top">');
    show_html += ('<img id="img_show_middle" class="img_show_middle" onload="DrawImage(this,785,520)" />');
    show_html += ('</div>');
    show_html += ('<div class="div_show_middle_bottom" id="div_show_middle_bottom">');
    show_html += ('</div>');
    show_html += ('</div>');
    show_html += ('<div class="div_show_right" onclick="RightShowImg(' + $(".img_body_left_body_left_list_tp").length + ')"><img class="img_show_right" /></div>');
    $("#div_show").html(show_html);

    $("#div_shadow").css("display", "block");
    $("#div_show").css("display", "block");
    $("#div_close").css("display", "block");
    var image = new Image();
    image.src = obj.src;
    $("#img_show_middle").attr("src",image.src);

    $("#div_show_middle_bottom").html('');
    var html = ('<ul id="ul_show_list" class="ul_body_left_body_left_list">');
    for (var i = 0; i < $(".img_body_left_body_xq_xx").length; i++) {
        html += ('<li class="li_show_tp" id="' + i + '">');
        html += ('<img class="img_show_tp" src="' + $(".img_body_left_body_xq_xx")[i].src + '" />');
        html += ('<div class="div_show_tp"></div>');
        html += ('</li>');
    }
    html += ('</ul>');
    $("#div_show_middle_bottom").html(html);

    if($(".img_body_left_body_xq_xx").length > 6) $("#ul_show_list").css("width", "2000px");

    $(".li_show_tp").bind("mouseover", function () {
	imgIndex = parseInt(this.id);
        $("#img_show_middle").attr("src", $(this).find("img")[0].src);
        $(".div_show_tp").css("background-color", "rgba(0,0,0,0.5)");
        $(this).find(".div_show_tp").css("background-color", "rgba(0,0,0,0)");
    });
}
//图片隐藏
function ImgHide(){
    $("#div_shadow").css("display", "none");
    $("#div_show").css("display", "none");
    $("#div_close").css("display", "none");
}
//图片左侧切换
function LeftShowImg(length) {
    if (imgIndex > 0) {
	if(imgIndex <= length - 5)
            $("#ul_show_lis").css("transform", "translate3d(-" + (imgIndex - 1) * 100 + "px, 0px, 0px)").css("transition-duration", "500ms");
        imgIndex -= 1;
        $("#ul_show_list").find(".div_show_tp").css("background-color", "rgba(0,0,0,0.5)");
        $("#ul_show_list").find(".li_show_tp:eq(" + imgIndex + ")").find(".div_show_tp").css("background-color", "rgba(0,0,0,0)");
        $("#img_show_middle").attr("src", $("#ul_show_list").find(".li_show_tp:eq(" + imgIndex + ")").find("img")[0].src);
    }
}
//图片右侧切换
function RightShowImg(length) {
    if (imgIndex < length-1) {
	if(imgIndex >= 4)
	    $("#ul_show_list").css("transform", "translate3d(-" + (imgIndex-2) * 100 + "px, 0px, 0px)").css("transition-duration", "500ms");
        imgIndex += 1;
        $("#ul_show_list").find(".div_show_tp").css("background-color", "rgba(0,0,0,0.5)");
        $("#ul_show_list").find(".li_show_tp:eq(" + imgIndex + ")").find(".div_show_tp").css("background-color", "rgba(0,0,0,0)");
        $("#img_show_middle").attr("src", $("#ul_show_list").find(".li_show_tp:eq(" + imgIndex + ")").find("img")[0].src);
    }
}
//鼠标经过显示图片
function ClickShowImg(obj,num){
	right = num;
        imgIndex = num;
        $("#img_body_left_body_left_show").attr("src", $(obj).parent().find("img")[0].src);
        $(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0.5)");
        $(obj).css("background-color", "rgba(0,0,0,0)");
}
//显示联系电话
function ShowLXDH(lxdh) {
    $("#div_body_left_body_right_lxdh").html('<span class="span_body_left_body_right_lxdh" style="font-size:28px;">' + lxdh + '</span>');
}