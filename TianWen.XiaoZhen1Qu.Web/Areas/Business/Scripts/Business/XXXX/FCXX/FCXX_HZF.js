var right = 0;
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
            TYPE: "FCXX_HZF",
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadJBXX(xml.list[0]);
                Loadxq(xml.list[0], xml.BCMSString);
                LoadXQXX(xml.list[0]);
                LoadDTXX(xml.list[0].XQMC);
                LoadCNXH("FCXX_HZF");
                LoadGRXX(xml.grxxlist[0]);
                LoadJJRTJFY("FCXX_HZF");
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
    html += ('<p class="p_div_body_left_head_ll">' + obj.ZXGXSJ.ToString('yyyy年MM月dd日') + '  ' + obj.LLCS + '次浏览 </p>');
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
    html += ('<span class="span_body_left_body_right_zj">' + GetJG(obj.ZJ, '元/月') + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">出租方式：</span>');
    html += ('<span class="span_body_left_body_right_right">单间出租</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">押付方式：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.YFFS + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">房屋类型：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.S + '室' + obj.T + '厅' + obj.W + '卫 ' + obj.PFM + '平米 ' + obj.ZXQK + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">朝向楼层：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.CX + ' ' + GetLC(obj.C, obj.GJC) + '/共' + obj.GJC + '层</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">所在小区：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.XQMC + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">详细地址：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.XQDZ.replace('［', '[').replace('］', '] ') + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">联系电话：</span>');
    html += ('<span class="span_body_left_body_right_right span_body_left_body_right_right_lxdh">' + obj.LXDH.substr(0, 4) + '****' + '</span>');
    html += ('<span class="span_body_left_body_right_right_ckwzdh" onclick="ShowWZDH()">完整电话</span>');
    html += ('<span class="span_body_left_body_right_wzdh"><span class="span_body_left_body_right_wzdh_lxdh"><i class="i_body_left_body_right_wzdh_lxdh"></i>' + obj.LXDH + '</span><span class="span_body_left_body_right_wzdh_ts">联系时请一定说明在信息小镇上看到的哈，谢谢^_^</span><i class="i_body_left_body_right_wzdh_close" onclick="HideWZDH()">×</i></span>');
    html += ('</p>');
    html += ('</div>');
    html += ('</div>');
    $("#div_body_left").append(html);
    HandlerTPXX();
}
//加载详情
function Loadxq(obj, BCMSString) {
    var html = "";
    html += ('<div class="div_body_left_body_xq">');
    html += ('<p class="p_body_left_body_xq">房源详情</p>');
    html += ('<div class="div_body_left_body_xq_xx">');
    if (obj.FWPZ !== null) {
        var fwpzarray = obj.FWPZ.split(',');

        html += ('<div class="div_body_left_body_xq_xx_left">房屋配置</div>');
        html += ('<div class="div_body_left_body_xq_xx_right" style="width: 600px;">');
        for (var i = 0; i < fwpzarray.length; i++) {
            html += ('<span class="span_body_left_body_xq_xx_right" style="height:60px;display:inline-block;">');
            //html += ('<img class="img_body_left_body_xq_xx_right" src="' + getRootPath() + '/Areas/Business/Css/images/xxxx/fc/xxxx_fc_' + fwpzarray[i] + '.png")" />');
            html += ('<span class="span_img_body_left_body_xq_xx_right">' + fwpzarray[i] + '</span>');
            html += ('</span>');
        }
        html += ('</div>');
        html += ('</div>');
    }
    if (obj.FWLD !== null) {
        var fwldarray = obj.FWLD.split(',');
        html += ('<div class="div_body_left_body_xq_xx">');
        html += ('<div class="div_body_left_body_xq_xx_left">房屋亮点</div>');
        html += ('<div class="div_body_left_body_xq_xx_right">');
        for (var i = 0; i < fwldarray.length; i++) {
            html += ('<span class="span_body_left_body_xq_xx_right_fwld">' + fwldarray[i] + '</span>');
        }
        html += ('</div>');
        html += ('</div>');
    }
    html += ('<div class="div_body_left_body_xq_xx">');
    html += ('<div class="div_body_left_body_xq_xx_left">房源描述</div>');
    html += ('<div id="div_body_left_body_xq_xx_bcms" class="div_body_left_body_xq_xx_right fyms div_body_left_body_xq_xx_bcms">');
    html += (BCMSString);
    html += ('</div>');
    html += ('</div>');

    html += ('<div id = "zk" class="div_body_left_body_xq_xx"></div>');

    html += ('<div id="div_body_left_body_xq_xx" class="div_body_left_body_xq_xx" style="overflow:hidden;">');
    html += ('<ul class="ul_body_left_body_xq_xx">');
    for (var i = 0; i < obj.PHOTOS.length; i++) {
        html += ('<li class="li_body_left_body_xq_xx">');
        html += ('<img class="img_body_left_body_xq_xx" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[i].PHOTONAME + "?j=" + Math.random() + '" />');
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
//加载小区信息
function LoadXQXX(obj) {
    var html = "";
    html += ('<div class="div_body_left_body_xqxx">');
    html += ('<p class="p_body_left_body_xqxx">小区信息</p>');
    html += ('<ul class="ul_body_left_body_xqxx">');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">小区名：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + obj.XQMC === null ? "" : obj.XQMC + '</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">开发商：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + (obj.KFS === null ? "" : obj.KFS) + '</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">物业公司：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + (obj.WYGS === null ? "" : obj.WYGS) + '</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">物业类型：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + (obj.WYLX === null ? "" : obj.WYLX) + '</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">总建面积：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + (obj.ZJMJ === null ? "" : obj.ZJMJ) + '</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">总户数：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + (obj.ZHS === null ? "" : obj.ZHS) + '</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">建筑年代：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + (obj.JZND === null ? "" : obj.JZND) + '</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">容积率：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + (obj.RJL === null ? "" : obj.RJL) + '</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">停车位：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + (obj.TCW === null ? "" : obj.TCW) + '</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">绿化率：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + (obj.LHL === null ? "" : obj.LHL) + '</span>');
    html += ('</li>');
    html += ('</ul>');
    html += ('<div id="div_body_left_body_xqxx_dtxx" class="div_body_left_body_xqxx_dtxx">');
    html += ('<p class="p_body_left_body_xqxx_dtxx">小区地址</p>');
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
                LoadJPTJ("FCXX_HZF");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载猜你喜欢单条信息
function LoadCNXHInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'FCXX_HZF\',\'' + obj.ID + '\')" class="li_body_left_body_cnxh">');
    html += ('<img class="img_li_body_left_body_cnxh" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_left_body_cnxh_xq">' + obj.XQMC + '</p>');
    html += ('<p class="p_li_body_left_body_cnxh_cs">' + obj.S + '室 / ' + obj.PFM + '平米 / ' + obj.ZXQK + '</p>');
    html += ('<p class="p_li_body_left_body_cnxh_jg">' + obj.ZJ + '元/月</p>');
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
    html += ('<li onclick="OpenXXXX(\'FCXX_HZF\',\'' + obj.ID + '\')" class="li_body_left_body_jptj">');
    html += ('<img class="img_li_body_left_body_jptj" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_left_body_jptj_xq">' + obj.XQMC + '</p>');
    html += ('<p class="p_li_body_left_body_jptj_cs">' + obj.S + '室 / ' + obj.PFM + '平米 / ' + obj.ZXQK + '</p>');
    html += ('<p class="p_li_body_left_body_jptj_jg">' + obj.ZJ + '元/月</p>');
    html += ('</li>');
    return html;
}
//加载该经纪人推荐
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
                html += ('<p class="p_body_right_jjrtj">该经纪人推荐</p>');
                html += ('<ul id="ul_body_right_jjrtj" class="ul_body_right_jjrtj">');
                for (var i = 0; i < 4; i++) {
                    html += LoadJJRTJFYInfo(xml.list[i]);
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
    html += ('<li onclick="OpenXXXX(\'FCXX_HZF\',\'' + obj.ID + '\')" class="li_body_right_jjrtj">');
    html += ('<img class="img_li_body_right_jjrtj" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_li_body_right_jjrtj">');
    html += ('<p class="p_li_body_right_jjrtj_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_jjrtj_cs">' + obj.S + '室 / ' + obj.PFM + '平米 / ' + obj.ZXQK + '</p>');
    html += ('<p class="p_li_body_right_jjrtj_jg">' + obj.ZJ + '元/月</p>');
    html += ('</div>');
    html += ('</li>');
    return html;
}
//加载相关类目
function LoadXGLM() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadXGLM",
        dataType: "json",
        data:
        {
            TYPE: "FC,LYJD"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                html += ('<div class="div_body_right_xglm">');
                html += ('<p class="p_body_right_xglm">相关类目</p>');
                html += ('<ul id="ul_body_right_xglm" class="ul_body_right_xglm">');
                for (var i = 0; i < xml.list.length; i++) {
                    if (xml.list[i].FBYM.indexOf("FC_") !== -1)
                        html += '<li class="li_body_right_xglm" onclick="OpenXGLM(\'' + xml.list[i].FBYM + '\',' + xml.list[i].LBID + ')">' + xml.xzq + xml.list[i].LBNAME + '</li>';
                }
                html += ('<em class="em_body_right_xglm"></em>');
                html += ('</ul>');
                html += ('<ul id="ul_body_right_xglm" class="ul_body_right_xglm">');
                for (var i = 0; i < xml.list.length; i++) {
                    if (xml.list[i].FBYM.indexOf("LYJD_") !== -1)
                        html += '<li class="li_body_right_xglm" onclick="OpenXGLM(\'' + xml.list[i].FBYM + '\',' + xml.list[i].LBID + ')">' + xml.xzq + xml.list[i].LBNAME + '</li>';
                }
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
    if (lbname.indexOf("FC_") !== -1)
        window.open(getRootPath() + "/Business" + "/FCCX/" + lbname.replace("FC_", "FCCX_") + "?LBID=" + lbid);
    if (lbname.indexOf("LYJD_") !== -1)
        window.open(getRootPath() + "/Business" + "/LYJDCX/" + lbname.replace("LYJD_", "LYJDCX_") + "?LBID=" + lbid);
}