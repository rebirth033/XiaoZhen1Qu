﻿var right = 0;
$(document).ready(function () {

});
//加载默认
function LoadDefault() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/CLXX/LoadCLXX",
        dataType: "json",
        data:
        {
            TYPE: "CLXX_KC",
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadJBXX(xml.list[0]);
                LoadXQ(xml.list[0], xml.BCMSString);
                LoadCNXH("CLXX_KC");
                LoadGRXX(xml.grxxlist[0]);
                LoadJJRTJFY("CLXX_KC");
                HandlerTPXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载基本信息
function LoadJBXX(obj) {
    var html = "";
    html += ('<div class="div_body_left_head">');
    html += ('<p class="p_div_body_left_head_bt">' + obj.BT + '</p>');
    html += ('<p class="p_div_body_left_head_ll">' + obj.ZXGXSJ.ToString('yyyy年MM月dd日') + '  ' + obj.LLCS + '次浏览 <span id="span_div_body_left_head_jb" class="span_div_body_left_head_jb">举报</span><span class="span_div_body_left_head_split">|</span><span id="span_div_body_left_head_sc" onclick="SCXX(\'' + obj.JCXXID + '\')" class="span_div_body_left_head_sc">收藏</span></p>');
    html += ('</div>');
    html += ('<div class="div_body_left_body">');
    html += ('<div class="div_body_left_body_left">');
    html += ('<div class="div_body_left_body_left_img">');
    html += ('<img id="img_body_left_body_left_show" onload="DrawImage(this,460,350)" onclick="ImgShow(this)" class="img_body_left_body_left_show" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('</div>');
    html += ('<span onclick="LeftImg(' + obj.PHOTOS.length + ')" class="div_body_left_body_left_list_an" style="margin-right: 10px;"><</span>');
    html += ('<div class="div_body_left_body_left_list">');
    html += ('<ul id="ul_body_left_body_left_list" class="ul_body_left_body_left_list">');
    for (var i = 0; i < obj.PHOTOS.length; i++) {
        html += ('<li class="li_body_left_body_left_list_tp">');
        html += ('<img class="img_body_left_body_left_list_tp" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[i].PHOTONAME + "?j=" + Math.random() + '" />');
        html += ('<div class="div_img_body_left_body_left_list_tp" onmouseover="ClickShowImg(this,'+i+')"></div>');
        html += ('</li>');
    }
    html += ('</ul>');
    html += ('</div>');
    html += ('<span onclick="RightImg(' + obj.PHOTOS.length + ')" class="div_body_left_body_left_list_an">></span>');
    html += ('</div>');
    html += ('<div class="div_body_left_body_right">');
    html += ('<p class="p_body_left_body_right_first">');
    html += ('<span class="span_body_left_body_right_zj">' + GetJG(obj.JG, '万元') + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">品&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;牌：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.PP.split(' ')[0] + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">上牌时间：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.SPNF + obj.SPYF + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">表显里程：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.XSLC + '万公里</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">车辆颜色：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.CLYS + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">联&nbsp;&nbsp;系&nbsp;&nbsp;人：</span>');
    html += ('<span class="span_body_left_body_right_right">' + ValidateNull(obj.LXR) + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">看车地址：</span>');
    html += ('<span class="span_body_left_body_right_right">' + '[' + ValidateNull(obj.QY) + ' - ' + ValidateNull(obj.DD) + '] ' + obj.JTDZ + '</span>');
    html += ('</p>');
    html += ('<div class="div_body_left_body_right_lxdh" id="div_body_left_body_right_lxdh" onclick="ShowLXDH(\''+obj.LXDH+'\')"><img class="img_body_left_body_right_lxdh"  src="' + getRootPath() + "/Areas/Business/Css/images/XXXX/GY/xxxx_gy_lxdh.png" + '" /><span class="span_body_left_body_right_lxdh">联系电话</span></div>');
    html += ('</div>');
    html += ('</div>');
    $("#div_body_left").append(html);

}
//加载车辆详情
function LoadXQ(obj, BCMSString) {
    var html = "";
    html += ('<div class="div_body_left_body_xq">');
    html += ('<p class="p_body_left_body_xq">车辆详情</p>');
    //html += ('<div class="div_body_left_body_xq_xx">');
    //html += ('<div class="div_body_left_body_xq_xx_left">基本信息</div>');
    //html += ('<div class="div_body_left_body_xq_xx_right" style="width: 600px;">');

    //html += ('<p class="p_body_left_body_xq_xx_right"><span class="span_body_left_body_xq_xx_right_left">出厂时间：</span><span class="span_body_left_body_xq_xx_right_right">' + obj.SPNF + obj.SPYF + '</span></p>');
    //html += ('<p class="p_body_left_body_xq_xx_right"><span class="span_body_left_body_xq_xx_right_left">表显里程：</span><span class="span_body_left_body_xq_xx_right_right">' + obj.XSLC + '</span></p>');

    //html += ('<p class="p_body_left_body_xq_xx_right"><span class="span_body_left_body_xq_xx_right_left">马力：</span><span class="span_body_left_body_xq_xx_right_right">120匹</span></p>');
    //html += ('<p class="p_body_left_body_xq_xx_right"><span class="span_body_left_body_xq_xx_right_left">档位数：</span><span class="span_body_left_body_xq_xx_right_right">5</span></p>');

    //html += ('<p class="p_body_left_body_xq_xx_right"><span class="span_body_left_body_xq_xx_right_left">整车重量：</span><span class="span_body_left_body_xq_xx_right_right">4.49吨</span></p>');
    //html += ('<p class="p_body_left_body_xq_xx_right"><span class="span_body_left_body_xq_xx_right_left">额定载重：</span><span class="span_body_left_body_xq_xx_right_right">' + obj.EDZZ + '吨</span></p>');

    //html += ('<p class="p_body_left_body_xq_xx_right"><span class="span_body_left_body_xq_xx_right_left">货箱长度：</span><span class="span_body_left_body_xq_xx_right_right">4.2米</span></p>');
    //html += ('<p class="p_body_left_body_xq_xx_right"><span class="span_body_left_body_xq_xx_right_left">货箱宽度：</span><span class="span_body_left_body_xq_xx_right_right">2.1米</span></p>');

    //html += ('<p class="p_body_left_body_xq_xx_right"><span class="span_body_left_body_xq_xx_right_left">货箱高度：</span><span class="span_body_left_body_xq_xx_right_right">2米</span></p>');

    //html += ('</div>');
    //html += ('</div>');
    html += ('<div class="div_body_left_body_xq_xx">');
    html += ('<div class="div_body_left_body_xq_xx_left">车辆描述</div>');
    html += ('<div id="div_body_left_body_xq_xx_bcms" class="div_body_left_body_xq_xx_right fyms div_body_left_body_xq_xx_bcms">');
    html += (BCMSString);
    html += ('</div>');
    html += ('</div>');

    html += ('<div id = "zk" class="div_body_left_body_xq_xx"></div>');

    html += ('<div id="div_body_left_body_xq_xx" class="div_body_left_body_xq_xx" style="overflow:hidden;">');
    html += ('<ul class="ul_body_left_body_xq_xx">');
    for (var i = 0; i < obj.PHOTOS.length; i++) {
        html += ('<li class="li_body_left_body_xq_xx">');
        html += ('<img id="img_body_left_body_xq_xx' + i + '" onload="DrawImage(this,403,348)" onclick="ImgShow(this)" class="img_body_left_body_xq_xx" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[i].PHOTONAME + "?j=" + Math.random() + '" />');
        html += ('</li>');
    }
    html += ('</ul>');
    html += ('</div>');

    html += ('<div id="div_body_left_body_xq_zk" onclick="ToggleImg(' + obj.PHOTOS.length + ')" class="div_body_left_body_xq_zk">展开更多图片 共（' + obj.PHOTOS.length + '）张</div>');
    html += ('</div>');

    $("#div_body_left").append(html);

    if (parseInt(RTrimStr($("#div_body_left_body_xq_xx_bcms").css("height"), "px")) > 300) {
        $("#div_body_left_body_xq_xx_bcms").css("height", "300px").css("overflow", "hidden");
        $("#zk").append('<div id="div_body_left_body_xq_zk_bcms" onclick="ToggleBCMS()" class="div_body_left_body_xq_zk_bcms">展开内容<i id="i_body_left_body_xq_zk_bcms" class="i_body_left_body_xq_zk_bcms"></i></div>');
    }    	
	if (obj.PHOTOS.length > 4) {
        $("#div_body_left_body_xq_xx").css("height", "710px");
        $("#div_body_left_body_xq_zk").css("display", "block");
    }

}

//加载猜你喜欢
function LoadCNXH(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/CLCX/LoadCLXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: "STATUS:1",
            PageSize: 4,
            PageIndex: 1
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += ('<div class="div_body_left_body_cnxh">');
                html += ('<p class="p_body_left_body_cnxh">猜你喜欢</p>');
                html += ('<ul id="ul_body_left_body_cnxh" class="ul_body_left_body_cnxh">');
                for (var i = 0; i < xml.list.length; i++) {
                    html += LoadCNXHInfo(xml.list[i]);
                    if (i === 3) break;
                }
                html += ('</ul>');
                html += ('</div>');
                $("#div_body_left").append(html);
                LoadJPTJ("CLXX_KC");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载猜你喜欢单条信息
function LoadCNXHInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'CLXX_KC\',\'' + obj.ID + '\')" class="li_body_left_body_cnxh">');
    html += ('<img class="img_li_body_left_body_cnxh" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_left_body_cnxh_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_body_cnxh_cs">' + obj.PP.split(' ')[0] + ' / ' + obj.SPNF + ' / ' + obj.CLYS + '</p>');
    html += ('<p class="p_li_body_left_body_cnxh_jg">' + obj.JG + '万元</p>');
    html += ('</li>');
    return html;
}
//加载精品推荐
function LoadJPTJ(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/CLCX/LoadCLXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: "STATUS:1",
            PageSize: 4,
            PageIndex: 1
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += ('<div class="div_body_left_body_jptj">');
                html += ('<p class="p_body_left_body_jptj">精品推荐</p>');
                html += ('<ul id="ul_body_left_body_jptj" class="ul_body_left_body_jptj">');
                for (var i = 0; i < xml.list.length; i++) {
                    html += LoadJPTJInfo(xml.list[i]);
                    if (i === 3) break;
                }
                html += ('</ul>');
                html += ('</div>');
                $("#div_body_left").append(html);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载精品推荐单条信息
function LoadJPTJInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'CLXX_KC\',\'' + obj.ID + '\')" class="li_body_left_body_jptj">');
    html += ('<img class="img_li_body_left_body_jptj" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_left_body_jptj_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_body_jptj_cs">' + obj.PP.split(' ')[0] + ' / ' + obj.SPNF + ' / ' + obj.CLYS + '</p>');
    html += ('<p class="p_li_body_left_body_jptj_jg">' + obj.JG + '万元</p>');
    html += ('</li>');
    return html;
}
//加载该经纪人推荐
function LoadJJRTJFY(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/CLCX/LoadCLXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: "STATUS:1",
            PageSize: 4,
            PageIndex: 1
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += ('<div class="div_body_right_jjrtj">');
                html += ('<p class="p_body_right_jjrtj">该经纪人推荐</p>');
                html += ('<ul id="ul_body_right_jjrtj" class="ul_body_right_jjrtj">');
                for (var i = 0; i < xml.list.length; i++) {
                    html += LoadJJRTJFYInfo(xml.list[i]);
                    if (i === 3) break;
                }
                html += ('</ul>');
                html += ('</div>');
                $("#div_body_right").append(html);
                $(".li_body_right_jjrtj").bind("mouseover", function () { $(this).find(".p_li_body_right_jjrtj_xq").css("color", "#bc6ba6"); });
                $(".li_body_right_jjrtj").bind("mouseleave", function () { $(this).find(".p_li_body_right_jjrtj_xq").css("color", "#333333"); });
                LoadXGLM();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载该经纪人推荐单条信息
function LoadJJRTJFYInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'CLXX_KC\',\'' + obj.ID + '\')" class="li_body_right_jjrtj">');
    html += ('<img class="img_li_body_right_jjrtj" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_li_body_right_jjrtj">');
    html += ('<p class="p_li_body_right_jjrtj_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_jjrtj_cs">' + obj.PP.split(' ')[0] + ' / ' + obj.SPNF + ' / ' + obj.CLYS + '</p>');
    html += ('<p class="p_li_body_right_jjrtj_jg">' + obj.JG + '万元</p>');
    html += ('</div>');
    html += ('</li>');
    return html;
}
//加载相关类目
function LoadXGLM() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadXGLM",
        dataType: "json",
        data:
        {
            TYPE: "CL,CL"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += ('<div class="div_body_right_xglm">');
                html += ('<p class="p_body_right_xglm">相关类目</p>');
                html += ('<ul id="ul_body_right_xglm" class="ul_body_right_xglm">');
                for (var i = 0; i < xml.list.length; i++) {
                    if (xml.list[i].FBYM.indexOf("CL_") !== -1)
                        html += '<li class="li_body_right_xglm" onclick="OpenXGLM(\'' + xml.list[i].FBYM + '\',' + xml.list[i].LBID + ')">' + xml.xzq + xml.list[i].LBNAME + '</li>';
                }
                html += ('<em class="em_body_right_xglm"></em>');
                html += ('</ul>');
                html += ('</div>');
                $("#div_body_right").append(html);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//打开相关类目
function OpenXGLM(lbname, lbid) {
    if (lbname.indexOf("CL_") !== -1)
        window.open(getRootPath() + "/" + "/CLCX/" + lbname.replace("CL_", "CLCX_") + "?LBID=" + lbid);
}
//搜索栏备注导航
function OpenSS(TYPE, ID) {
    window.open(getRootPath() + "/CLCX/CLCX_KC?LBID=13" + "&" + TYPE + "=" + ID);
}