$(document).ready(function () {

});
//加载默认
function LoadDefault() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FCXX/LoadFCXX",
        dataType: "json",
        data:
        {
            TYPE: "FCXX_TD",
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadJBXX(xml.list[0]);
                LoadXQ(xml.list[0], xml.BCMSString);
                LoadSPXX();
                LoadDTXX(xml.list[0].DZ);
                LoadCNXH("FCXX_TD");
                LoadGRXX(xml.grxxlist[0]);
                LoadJJRTJFY("FCXX_TD");
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
    html += ('<p class="p_div_body_left_head_ll">11月5日 22:36 3次浏览 </p>');
    html += ('</div>');
    html += ('<div class="div_body_left_body">');
    html += ('<div class="div_body_left_body_left">');
    html += ('<img id="img_body_left_body_left_show" class="img_body_left_body_left_show" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<span onclick="LeftImg()" class="div_body_left_body_left_list_an" style="margin-right: 10px;"><</span>');
    html += ('<div class="div_body_left_body_left_list">');
    html += ('<ul id="ul_body_left_body_left_list" class="ul_body_left_body_left_list">');
    for (var i = 0; i < obj.PHOTOS.length; i++) {
        html += ('<li class="li_body_left_body_left_list_tp">');
        html += ('<img class="img_body_left_body_left_list_tp" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[i].PHOTONAME + "?j=" + Math.random() + '" />');
        html += ('<div class="div_img_body_left_body_left_list_tp"></div>');
        html += ('</li>');
    }
    html += ('</ul>');
    html += ('</div>');
    html += ('<span onclick="RightImg(' + obj.PHOTOS.length + ')" class="div_body_left_body_left_list_an">></span>');
    html += ('</div>');
    html += ('<div class="div_body_left_body_right">');
    html += ('<p class="p_body_left_body_right_first">');
    html += ('<span class="span_body_left_body_right_zj">' + obj.ZJ + '</span><span class="span_body_left_body_right_zjdw">元/月</span>');
    html += ('<span class="span_body_left_body_right_yffs">' + obj.YFFS + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">类型：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.XZLLX + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">物业费：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.WYF + '元/㎡</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">签约年限：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.QYNX + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">面积：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.MJ + '平米</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">具体地址：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.QY + '-' + obj.DD + '-' + obj.JTDZ + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right_lxdh">');
    html += ('<img class="img_body_left_body_right_lxdh" src="' + getRootPath() + '/Areas/Business/Css/images/lxdh.png" />' + obj.LXDH);
    html += ('</p>');
    html += ('</div>');
    html += ('</div>');
    $("#div_body_left").append(html);
    HandlerTPXX();
}
//处理图片信息
function HandlerTPXX() {
    $(".div_img_body_left_body_left_list_tp:eq(0)").each(function () { $(this).css("background-color", "rgba(0,0,0,0)") });
    $(".li_body_left_body_left_list_tp").bind("click", function () {
        $("#img_body_left_body_left_show").attr("src", $(this).find("img")[0].src);
        $(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0.5)");
        $(this).find(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0)");
    });
}
var right = 0;
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
    if (right < length - 1) {
        right += 1;
        $("#ul_body_left_body_left_list").css("transform", "translate3d(-" + right * 100 + "px, 0px, 0px)").css("transition-duration", "500ms");
        $("#ul_body_left_body_left_list").find(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0.5)");
        $("#ul_body_left_body_left_list").find(".li_body_left_body_left_list_tp:eq(" + right + ")").find(".div_img_body_left_body_left_list_tp").css("background-color", "rgba(0,0,0,0)");
        $("#img_body_left_body_left_show").attr("src", $("#ul_body_left_body_left_list").find(".li_body_left_body_left_list_tp:eq(" + right + ")").find("img")[0].src);
    }
}
//伸缩图片
function ToggleImg(length) {
    if ($("#div_body_left_body_fyxq_zk").html().indexOf("展开") !== -1) {
        $("#div_body_left_body_fyxq_xx").css("overflow", "visible").css("height", "auto");
        $("#div_body_left_body_fyxq_zk").html("收起更多图片 共（" + length + "）张");
    } else {
        $("#div_body_left_body_fyxq_xx").css("overflow", "hidden").css("height", "530px");
        $("#div_body_left_body_fyxq_zk").html("展开更多图片 共（" + length + "）张");
    }
}
//加载详情
function LoadXQ(obj, BCMSString) {
    var html = "";
    html += ('<div class="div_body_left_body_fyxq">');
    html += ('<p class="p_body_left_body_fyxq">写字楼详情</p>');
    //if (obj.FWPZ !== null) {
    //    var fwpzarray = obj.FWPZ.split(',');
    //html += ('<div class="div_body_left_body_fyxq_xx">');
    //    html += ('<div class="div_body_left_body_fyxq_xx_left">房屋配置</div>');
    //    html += ('<div class="div_body_left_body_fyxq_xx_right" style="width: 600px;">');
    //    for (var i = 0; i < fwpzarray.length; i++) {
    //        html += ('<span class="span_body_left_body_fyxq_xx_right">');
    //        html += ('<img class="img_body_left_body_fyxq_xx_right" src="' + getRootPath() + '/Areas/Business/Css/images/xxxx/fc/xxxx_fc_' + fwpzarray[i] + '.png")" />');
    //        html += ('<span class="span_img_body_left_body_fyxq_xx_right">' + fwpzarray[i] + '</span>');
    //        html += ('</span>');
    //    }
    //    html += ('</div>');
    //    html += ('</div>');
    //}

    html += ('<div class="div_body_left_body_fyxq_xx">');
    html += ('<div class="div_body_left_body_fyxq_xx_left">房源描述</div>');
    html += ('<div class="div_body_left_body_fyxq_xx_right fyms">');
    html += (BCMSString);
    html += ('</div>');
    html += ('</div>');
    html += ('<div id="div_body_left_body_fyxq_xx" class="div_body_left_body_fyxq_xx" style="overflow:hidden;">');
    html += ('<ul class="ul_body_left_body_fyxq_xx">');
    for (var i = 0; i < obj.PHOTOS.length; i++) {
        html += ('<li class="li_body_left_body_fyxq_xx">');
        html += ('<img class="img_body_left_body_fyxq_xx" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[i].PHOTONAME + "?j=" + Math.random() + '" />');
        html += ('</li>');
    }
    html += ('</ul>');
    html += ('</div>');

    html += ('<div id="div_body_left_body_fyxq_zk" onclick="ToggleImg(' + obj.PHOTOS.length + ')" class="div_body_left_body_fyxq_zk">展开更多图片 共（' + obj.PHOTOS.length + '）张</div>');
    html += ('</div>');
    $("#div_body_left").append(html);
    if (obj.PHOTOS.length > 4) {
        $("#div_body_left_body_fyxq_xx").css("height", "530px");
        $("#div_body_left_body_fyxq_zk").css("display", "block");
    }
}
//伸缩图片
function ToggleImg(length) {
    if ($("#div_body_left_body_fyxq_zk").html().indexOf("展开") !== -1) {
        $("#div_body_left_body_fyxq_xx").css("overflow", "visible").css("height", "auto");
        $("#div_body_left_body_fyxq_zk").html("收起更多图片 共（" + length + "）张");
    } else {
        $("#div_body_left_body_fyxq_xx").css("overflow", "hidden").css("height", "530px");
        $("#div_body_left_body_fyxq_zk").html("展开更多图片 共（" + length + "）张");
    }
}
//加载信息
function LoadDZ() {
    var html = "";
    html += ('<div class="div_body_left_body_xqxx">');
    html += ('<div id="div_body_left_body_xqxx_dtxx" class="div_body_left_body_xqxx_dtxx">');
    html += ('<p class="p_body_left_body_xqxx_dtxx">写字楼地址</p>');
    html += ('<div style="width: 780px; height: 300px; border: 1px solid gray" id="container"></div>');
    html += ('</div>');
    html += ('</div>');
    $("#div_body_left").append(html);
}
//加载地图信息
function LoadDTXX(XQMC) {
    var map = new BMap.Map("container");//创建地图实例
    map.centerAndZoom("福州市", 15);//创建点坐标,地图初始化
    map.enableScrollWheelZoom(true);//允许鼠标滑轮放大缩小 
    map.enableContinuousZoom(true);//允许惯性拖拽
    map.addControl(new BMap.NavigationControl({ isOpen: true, anchor: BMAP_ANCHOR_BOTTOM_LEFT }));  //添加默认缩放平移控件,右上角打开
    map.addControl(new BMap.OverviewMapControl({ isOpen: true, anchor: BMAP_ANCHOR_BOTTOM_RIGHT })); //添加默认缩略地图控件,右下角打开
    searchByStationName(map, XQMC);
};
//地址定位
function searchByStationName(map, XQMC) {
    map.clearOverlays();//清空原来的标注
    var localSearch = new BMap.LocalSearch(map);
    localSearch.enableAutoViewport(); //允许自动调节窗体大小
    localSearch.setSearchCompleteCallback(function (searchResult) {
        var poi = searchResult.getPoi(0);
        map.centerAndZoom(poi.point, 13);
        var marker = new BMap.Marker(new BMap.Point(poi.point.lng, poi.point.lat));  // 创建标注，为要查询的地址对应的经纬度
        map.addOverlay(marker);
    });
    localSearch.search(XQMC);
}
//加载猜你喜欢
function LoadCNXH(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FCCX/LoadFCXX",
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
                }
                html += ('</ul>');
                html += ('</div>');
                $("#div_body_left").append(html);
                LoadJPTJ("FCXX_TD");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载猜你喜欢单条信息
function LoadCNXHInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'FCXX_TD\',\'' + obj.ID + '\')" class="li_body_left_body_cnxh">');
    html += ('<img class="img_li_body_left_body_cnxh" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_left_body_cnxh_xq">' + obj.QY + ' / ' + obj.DD + ' / ' + obj.JTDZ + '</p>');
    html += ('<p class="p_li_body_left_body_cnxh_cs">' + obj.MJ + '平</p>');
    html += ('<p class="p_li_body_left_body_cnxh_jg">' + obj.ZJ + obj.ZJDW + '</p>');
    html += ('</li>');
    return html;
}
//加载精品推荐
function LoadJPTJ(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FCCX/LoadFCXX",
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
    html += ('<li onclick="OpenXXXX(\'FCXX_TD\',\'' + obj.ID + '\')" class="li_body_left_body_jptj">');
    html += ('<img class="img_li_body_left_body_jptj" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_left_body_jptj_xq">' + obj.QY + ' / ' + obj.DD + ' / ' + obj.JTDZ + '</p>');
    html += ('<p class="p_li_body_left_body_jptj_cs">' + obj.MJ + '平</p>');
    html += ('<p class="p_li_body_left_body_jptj_jg">' + obj.ZJ + obj.ZJDW + '</p>');
    html += ('</li>');
    return html;
}
//加载该经纪人推荐房源
function LoadJJRTJFY(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FCCX/LoadFCXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: "STATUS:1",
            PageSize: 5,
            PageIndex: 1
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += ('<div class="div_body_right_jjrtj">');
                html += ('<p class="p_body_right_jjrtj">该经纪人推荐房源</p>');
                html += ('<ul id="ul_body_right_jjrtj" class="ul_body_right_jjrtj">');
                for (var i = 0; i < xml.list.length; i++) {
                    html += LoadJJRTJFYInfo(xml.list[i]);
                }
                html += ('</ul>');
                html += ('</div>');
                $("#div_body_right").append(html);
                $(".li_body_right_jjrtj").bind("mouseover", function () { $(this).find(".p_li_body_right_jjrtj_xq").css("color", "#5bc0de"); });
                $(".li_body_right_jjrtj").bind("mouseleave", function () { $(this).find(".p_li_body_right_jjrtj_xq").css("color", "#333333"); });
                LoadXGLM();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载该经纪人推荐房源单条信息
function LoadJJRTJFYInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'FCXX_TD\',\'' + obj.ID + '\')" class="li_body_right_jjrtj">');
    html += ('<img class="img_li_body_right_jjrtj" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_li_body_right_jjrtj">');
    html += ('<p class="p_li_body_right_jjrtj_xq">' + obj.QY + ' / ' + obj.DD + ' / ' + obj.JTDZ + '</p>');
    html += ('<p class="p_li_body_right_jjrtj_cs">' + obj.MJ + '平</p>');
    html += ('<p class="p_li_body_right_jjrtj_jg">' + obj.ZJ + obj.ZJDW + '</p>');
    html += ('</div>');
    html += ('</li>');
    return html;
}
//加载相关类目
function LoadXGLM() {
    var list = "福州日租/短租,福州二手房出售,福州新房出售,福州租房/出租,福州找室友,福州写字楼出租".split(",");
    var html = "";
    html += ('<div class="div_body_right_xglm">');
    html += ('<p class="p_body_right_xglm">相关类目</p>');
    html += ('<ul id="ul_body_right_xglm" class="ul_body_right_xglm">');
    for (var i = 0; i < list.length; i++) {
        html += '<li class="li_body_right_xglm">' + list[i] + '</li>';
    }
    html += ('<em class="em_body_right_xglm"></em>');
    html += ('</ul>');
    list = "福州酒店宾馆,福州医药保健,福州电子通讯,福州服饰鞋包,福州汽修美容,福州家居建材".split(",");
    html += ('<ul id="ul_body_right_xglm" class="ul_body_right_xglm">');
    for (var i = 0; i < list.length; i++) {
        html += '<li class="li_body_right_xglm">' + list[i] + '</li>';
    }
    html += ('</ul>');
    html += ('</div>');
    $("#div_body_right").append(html);
}