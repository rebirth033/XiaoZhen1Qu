$(document).ready(function () {
    LoadJBXX();
    BindClick("NLDW");
    BindClick("XB");
    BindClick("YMQK");
    BindClick("YMZL");
    $("#divPZText").bind("click", function () { LoadCWGPZ(); });
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "NLDW") {
            LoadCODESByTYPENAME("年龄单位", "NLDW", "CODES_CW", Bind, "CWGNL", "NLDW", "");
        }
        if (type === "XB") {
            LoadCODESByTYPENAME("性别", "XB", "CODES_CW", Bind, "CWGXB", "XB", "");
        }
        if (type === "YMQK") {
            LoadCODESByTYPENAME("疫苗情况", "YMQK", "CODES_CW", Bind, "CWGYMQK", "YMQK", "");
        }
        if (type === "YMZL") {
            LoadCODESByTYPENAME("疫苗种类", "YMZL", "CODES_CW", Bind, "CWGYMQK", "YMZL", "");
        }
    });
}
//加载品牌名称
function LoadCWGPZ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "宠物狗品种",
            TBName: "CODES_CW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#div_row_right_jcpp_first").html('');
                var html = "";
                html += '<span class="p_row_right_jcpp">请选择品种<span onclick="CloseJCPP(1)" class="span_row_right_jcpp">×</span></span>';
                html += '<div class="div_row_right_jcpp_first_left">';
                html += '<ul class="ul_row_right_jcpp_first_left">';
                for (var i = 0; i < BQArray.length; i++) {
                    var count = 0;
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            count++;
                    }
                    if (count !== 0)
                        html += '<li onclick="GoToBQ(\'' + BQArray[i] + '\')" class="li_row_right_jcpp_first_left">' + BQArray[i] + '</li>';
                }
                html += '</ul>';
                html += '</div>';

                html += '<div class="div_row_right_jcpp_first_right">';
                html += '<ul class="ul_row_right_jcpp_first_right">';
                for (var i = 0; i < BQArray.length; i++) {
                    var count = 0;
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            count++;
                    }
                    if (count !== 0)
                        html += '<li id="li_row_right_jcpp_first_right_tag_' + BQArray[i] + '" class="li_row_right_jcpp_first_right_tag">' + BQArray[i] + '</li>';
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            html += '<li onclick="SelectFirst(\'' + xml.list[j].CODENAME + '\')" class="li_row_right_jcpp_first_right_value">' + xml.list[j].CODENAME + '</li>';
                    }
                }
                html += '</ul>';
                html += '</div>';

                $("#div_row_right_jcpp_first").append(html);
                $("#div_row_right_jcpp_first").css("display", "inline-block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//跳转到标签位置
function GoToBQ(tag) {
    var len = document.getElementById("li_row_right_jcpp_first_right_tag_" + tag).offsetTop - 75;//获取div层到页面顶部的高度 
    $(".ul_row_right_jcpp_first_right").stop().animate({ scrollTop: len }, 300, "swing", function () { });
}
//选择款式
function SelectFirst(pz) {
    $("#spanPZ").html(pz);
    ValidateSelect("CWGPZ", "PZ", "请选择品种");
}
//关闭选择品牌框
function CloseJCPP(count) {
    if (count === 1) {
        $("#div_row_right_jcpp_first").css("display", "none");
        $("#div_row_right_jcpp_second").css("display", "none");
    }
    if (count === 2) {
        $("#div_row_right_jcpp_second").css("display", "none");
    }
}
//加载车辆_宠物狗基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CW/LoadCW_CWGJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CW_CWGJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.CW_CWGJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () {ue.setContent(xml.Value.BCMSString);});
                $("#spanPZ").html(xml.Value.CW_CWGJBXX.PZ);
                $("#spanNLDW").html(xml.Value.CW_CWGJBXX.NLDW);
                $("#spanXB").html(xml.Value.CW_CWGJBXX.XB);
                $("#spanYMQK").html(xml.Value.CW_CWGJBXX.YMQK);
                $("#spanYMZL").html(xml.Value.CW_CWGJBXX.YMZL);
                if (xml.Value.CW_CWGJBXX.SF !== null)
                    SetDX("SF", xml.Value.CW_CWGJBXX.SF);
                if (xml.Value.CW_CWGJBXX.QCQK !== null)
                    SetDX("QCQK", xml.Value.CW_CWGJBXX.QCQK);
                LoadPhotos(xml.Value.Photos);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//发布
function FB() {
    if (ValidateAll() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "PZ", "'" + $("#spanPZ").html() + "'");
    obj = jsonObj.AddJson(obj, "NLDW", "'" + $("#spanNLDW").html() + "'");
    obj = jsonObj.AddJson(obj, "XB", "'" + $("#spanXB").html() + "'");
    obj = jsonObj.AddJson(obj, "YMQK", "'" + $("#spanYMQK").html() + "'");
    obj = jsonObj.AddJson(obj, "YMZL", "'" + $("#spanYMZL").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("SF") + "'");
    obj = jsonObj.AddJson(obj, "QCQK", "'" + GetDX("QCQK") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CW/FBCW_CWGJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            BCMS: ue.getContent(),
            FWZP: GetPhotoUrls()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.location.href = getRootPath() + "/Business/FBCG/FBCG?LBID=" + getUrlParam("CLICKID") + "&ID=" + xml.Value.ID;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}