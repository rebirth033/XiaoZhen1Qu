$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    LoadDefault();
});
//加载默认
function LoadDefault() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FCXX/LoadFCXX",
        dataType: "json",
        data:
        {
            TYPE: "FC",
            FCXXID: getUrlParam("FCXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                HandlerTPXX();
                LoadJBXX(xml.list[0]);
                LoadFYXQ(xml.list[0], xml.BCMSString);
                LoadXQXX(xml.list[0]);
                LoadDTXX();
                LoadCNXH("FC");
                LoadGRXX(xml.grxxlist[0]);
                LoadJJRTJFY("FC");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//处理图片信息
function HandlerTPXX() {
    $(".div_img_body_left_body_left_list_tp:eq(0)").each(function () { $(this).css("background-color", "rgba(0,0,0,0)") });
    $(".li_body_left_body_left_list_tp").bind("click", function () {
        $("#img_body_left_body_left_show").attr("src", $(this).find("img")[0].src);

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
    html += ('<span class="div_body_left_body_left_list_an" style="margin-right: 10px;"><</span>');
    html += ('<ul class="ul_body_left_body_left_list">');
    for (var i = 0; i < obj.PHOTOS.length; i++) {
        html += ('<li class="li_body_left_body_left_list_tp">');
        html += ('<img class="img_body_left_body_left_list_tp" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[i].PHOTONAME + "?j=" + Math.random() + '" />');
        html += ('<div class="div_img_body_left_body_left_list_tp"></div>');
        html += ('</li>');
    }
    html += ('</ul>');
    html += ('<span class="div_body_left_body_left_list_an">></span>');
    html += ('</div>');
    html += ('<div class="div_body_left_body_right">');
    html += ('<p class="p_body_left_body_right_first">');
    html += ('<span class="span_body_left_body_right_zj">' + obj.ZJ + '</span><span class="span_body_left_body_right_zjdw">元/月</span>');
    html += ('<span class="span_body_left_body_right_yffs">' + obj.YFFS + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">出租方式：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.CZFS + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">房屋类型：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.S + '室' + obj.T + '厅' + obj.W + '卫 ' + obj.PFM + '平 ' + obj.ZXQK + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">朝向楼层：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.CX + ' ' + obj.C + '层/共' + obj.GJC + '层</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">所在小区：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.XQMC + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">所属区域：</span>');
    html += ('<span class="span_body_left_body_right_right">滨湖新区 滨湖世纪城</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right">');
    html += ('<span class="span_body_left_body_right_left">详细地址：</span>');
    html += ('<span class="span_body_left_body_right_right">' + obj.XQDZ + '</span>');
    html += ('</p>');
    html += ('<p class="p_body_left_body_right_lxdh">');
    html += ('<img class="img_body_left_body_right_lxdh" src="' + getRootPath() + '/Areas/Business/Css/images/lxdh.png" />' + obj.LXDH);
    html += ('</p>');
    html += ('</div>');
    html += ('</div>');
    $("#div_body_left").append(html);
}
//加载房源详情
function LoadFYXQ(obj, BCMSString) {
    var html = "";
    html += ('<div class="div_body_left_body_fyxq">');
    html += ('<p class="p_body_left_body_fyxq">房源详情</p>');
    html += ('<div class="div_body_left_body_fyxq_xx" style="height: 150px;">');
    html += ('<div class="div_body_left_body_fyxq_xx_left">房屋配置</div>');
    html += ('<div class="div_body_left_body_fyxq_xx_right" style="width: 600px;">');
    var fwpzarray = obj.FWPZ.split(',');
    for (var i = 0; i < fwpzarray.length; i++) {
        html += ('<span class="span_body_left_body_fyxq_xx_right">');
        html += ('<img class="img_body_left_body_fyxq_xx_right" src="' + getRootPath() + '/Areas/Business/Css/images/xxxx/fc/xxxx_fc_' + fwpzarray[i] + '.png")" />');
        html += ('<span class="span_img_body_left_body_fyxq_xx_right">' + fwpzarray[i] + '</span>');
        html += ('</span>');
    }
    html += ('</div>');
    html += ('</div>');
    var fwldarray = obj.FWLD.split(',');
    html += ('<div class="div_body_left_body_fyxq_xx">');
    html += ('<div class="div_body_left_body_fyxq_xx_left">房屋亮点</div>');
    html += ('<div class="div_body_left_body_fyxq_xx_right">');
    for (var i = 0; i < fwldarray.length; i++) {
        html += ('<span class="span_body_left_body_fyxq_xx_right_fwld">' + fwldarray[i] + '</span>');
    }

    html += ('</div>');
    html += ('</div>');

    html += ('<div class="div_body_left_body_fyxq_xx" style="height: 280px;">');
    html += ('<div class="div_body_left_body_fyxq_xx_left">房源描述</div>');
    html += ('<div class="div_body_left_body_fyxq_xx_right fyms">');
    html += (BCMSString);
    html += ('</div>');
    html += ('</div>');
    html += ('<div class="div_body_left_body_fyxq_xx">');
    html += ('<ul class="ul_body_left_body_fyxq_xx">');
    for (var i = 0; i < obj.PHOTOS.length; i++) {
        html += ('<li class="li_body_left_body_fyxq_xx">');
        html += ('<img class="img_body_left_body_fyxq_xx" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[i].PHOTONAME + "?j=" + Math.random() + '" />');
        html += ('</li>');
    }
    html += ('</div>');
    html += ('</div>');
    $("#div_body_left").append(html);
}
//加载小区信息
function LoadXQXX(obj) {
    var html = "";
    html += ('<div class="div_body_left_body_xqxx">');
    html += ('<p class="p_body_left_body_xqxx">小区信息</p>');
    html += ('<ul class="ul_body_left_body_xqxx">');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">小区名：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + obj.XQMC + '</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">开发商：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + obj.KFS + '</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">物业公司：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + obj.WYGS + '</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">物业类型：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + obj.WYLX + '</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">总建面积：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + obj.ZJMJ + '（大型小区）</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">总户数：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + obj.ZHS + '</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">建筑年代：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + obj.JZND + '</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">容积率：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + obj.RJL + '</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">停车位：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + obj.TCW + '</span>');
    html += ('</li>');
    html += ('<li class="li_body_left_body_xqxx">');
    html += ('<span class="span_body_left_body_xqxx_left">绿化率：</span>');
    html += ('<span class="span_body_left_body_xqxx_right">' + obj.LHL + '（绿化率适中）</span>');
    html += ('</li>');
    html += ('</ul>');
    html += ('<div id="div_body_left_body_xqxx_dtxx" class="div_body_left_body_xqxx_dtxx">');
    html += ('<p class="p_body_left_body_xqxx_dtxx">小区地图</p>');
    html += ('<div style="width: 780px; height: 300px; border: 1px solid gray" id="container"></div>');
    html += ('</div>');
    html += ('</div>');
    $("#div_body_left").append(html);
}
//加载地图信息
function LoadDTXX() {
    var map = new BMap.Map("container");//创建地图实例
    map.centerAndZoom("福州市", 11);//创建点坐标,地图初始化
    map.enableScrollWheelZoom(true);//允许鼠标滑轮放大缩小 
    map.enableContinuousZoom(true);//允许惯性拖拽
    map.addControl(new BMap.NavigationControl({ isOpen: true, anchor: BMAP_ANCHOR_BOTTOM_LEFT }));  //添加默认缩放平移控件,右上角打开
    map.addControl(new BMap.OverviewMapControl({ isOpen: true, anchor: BMAP_ANCHOR_BOTTOM_RIGHT })); //添加默认缩略地图控件,右下角打开
    map.addControl(new BMap.MapTypeControl());//添加卫星控件
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
                LoadJPTJ("FC");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载猜你喜欢单条信息
function LoadCNXHInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left_body_cnxh">');
    html += ('<img class="img_li_body_left_body_cnxh" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_left_body_cnxh_xq">' + obj.XQDZ.split('-')[0] + ' / ' + obj.XQDZ.split('-')[1] + ' / ' + obj.XQMC + '</p>');
    html += ('<p class="p_li_body_left_body_cnxh_cs">' + obj.S + '室 ' + obj.PFM + '平</p>');
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
    html += ('<li class="li_body_left_body_jptj">');
    html += ('<img class="img_li_body_left_body_jptj" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_left_body_jptj_xq">' + obj.XQDZ.split('-')[0] + ' / ' + obj.XQDZ.split('-')[1] + ' / ' + obj.XQMC + '</p>');
    html += ('<p class="p_li_body_left_body_jptj_cs">' + obj.S + '室 ' + obj.PFM + '平</p>');
    html += ('<p class="p_li_body_left_body_jptj_jg">' + obj.ZJ + '元/月</p>');
    html += ('</li>');
    return html;
}
//加载个人信息
function LoadGRXX(grxx) {
    var html = "";
    html += ('<div class="div_body_right_grxx">');
    html += ('<img class="img_div_body_right_grxx" src="http://localhost/infotownlet/Areas/Business/Photos/2718ced3-996d-427d-925d-a08e127cc0b8/GRZL/TX.jpg?j=0.3236891655295969" />');
    html += ('<p class="p_div_body_right_yhm">' + grxx.YHM+ '</p>');
    html += ('<p class="p_div_body_right_zcsj">注册时间：'+grxx.SQRQ.ToString("yyyy年MM月dd日")+'</p>');
    html += ('<div class="div_div_body_right_yyzz">');
    html += ('<div class="div_div_div_body_right_yyzz"><i class="i_div_div_body_right_yyzz_sfz"></i><span>身份证</span></div>');
    html += ('<div class="div_div_div_body_right_yyzz"><i class="i_div_div_body_right_yyzz_yyzz"></i><span>营业执照</span></div>');
    html += ('<div class="div_div_div_body_right_yyzz"><i class="i_div_div_body_right_yyzz_zmxy"></i><span>芝麻信用</span></div>');
    html += ('</div>');
    html += ('<div class="div_div_body_right_ckxy">查看TA的信用记录</div>');
    html += ('</div>');
    $("#div_body_right").append(html);
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
    html += ('<li class="li_body_right_jjrtj">');
    html += ('<img class="img_li_body_right_jjrtj" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_li_body_right_jjrtj">');
    html += ('<p class="p_li_body_right_jjrtj_xq">' + obj.XQDZ.split('-')[0] + ' / ' + obj.XQDZ.split('-')[1] + ' / ' + obj.XQMC + '</p>');
    html += ('<p class="p_li_body_right_jjrtj_cs">' + obj.S + '室 ' + obj.PFM + '平</p>');
    html += ('<p class="p_li_body_right_jjrtj_jg">' + obj.ZJ + '元/月</p>');
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