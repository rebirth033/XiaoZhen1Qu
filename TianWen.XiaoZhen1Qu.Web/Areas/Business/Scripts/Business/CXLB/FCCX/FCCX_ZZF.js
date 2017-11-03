$(document).ready(function() {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_nav").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_condition").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_condition_select").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);

    $("#li_condition_head_qyzf").css("background-color", "#ffffff");
    BindConditionLi();
    LoadFCCX();
});

function BindConditionLi() {
    $(".li_condition_head").bind("click", function () {
        $(".li_condition_head").each(function() {
            $(this).css("background-color", "#eeeff1");
        });
        $(this).css("background-color", "#ffffff");
    });
}

function LoadFCCX() {
    var dqs = "地区,不限,全福州,鼓楼,台江,晋安,仓山,闽侯,福清,马尾,长乐,连江,平潭,罗源,闽清,永泰,全福建,全中国".split(',');
    var zjs = "租金,不限,500-1000元,1000-1500元,1500-2000元,2000-3000元,3000-4000元,4000元以上".split(',');
    var zflx = "租房类型,不限,整套出租,单间出租,精品公寓,床位出租".split(',');
    LoadCondition(dqs);
    LoadCondition(zjs);
    LoadCondition(zflx);
}

function LoadCondition(array) {
    var html = "";
    html += '<div class="div_condigion_body">';
    html += '<ul class="ul_condigion_body">';
    for (var i = 0; i < array.length; i++) {
        if (i === 0)
            html += '<li class="li_condigion_body_first">' + array[i] + '</li>';
        else if (i === 1)
            html += '<li class="li_condigion_body active">' + array[i] + '</li>';
        else 
            html += '<li class="li_condigion_body">' + array[i] + '</li>';
    }
    html += '</ul>';
    html += '</div>';
    $("#divCondition").append(html);
}