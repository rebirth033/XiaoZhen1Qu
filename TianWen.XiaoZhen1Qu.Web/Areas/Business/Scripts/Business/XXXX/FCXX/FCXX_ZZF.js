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
                LoadJBXX(xml.list[0]);
                LoadFYXQ(xml.list[0], xml.BCMSString);
                HandlerTPXX();
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