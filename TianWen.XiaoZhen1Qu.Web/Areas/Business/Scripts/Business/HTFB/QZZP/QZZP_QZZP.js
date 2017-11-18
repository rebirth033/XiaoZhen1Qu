$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    BindClick("MYXZ");
    BindClick("XLYQ");
    BindClick("GZNX");
    BindClick("ZWLB");
    LoadDuoX("职位福利", "ZWFL");
});
//显示职位类别
function ShowZWLBThird() {
    $(this).find(".div_zwlb_third").each(function () {
        $(this).css("display", "block");
    });
}
//隐藏职位类别
function HideZWLBThird() {
    $(this).find(".div_zwlb_third").each(function () {
        $(this).css("display", "none");
    });
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "MYXZ") {
            LoadCODESByTYPENAME("每月薪资", "MYXZ", "CODES_QZZP", Bind, "ZPMYXZ", "MYXZ", "");
        }
        if (type === "XLYQ") {
            LoadCODESByTYPENAME("学历要求", "XLYQ", "CODES_QZZP", Bind, "ZPXLYQ", "XLYQ", "");
        }
        if (type === "GZNX") {
            LoadCODESByTYPENAME("工作年限", "GZNX", "CODES_QZZP", Bind, "ZPGZNX", "GZNX", "");
        }
        if (type === "ZWLB") {
            LoadZWLB();
        }
    });
}
//加载职位类别
function LoadZWLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadZWLBXX",
        dataType: "json",
        data:
        {
            TYPENAME: "职位类别"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<div class="div_zwlb_first"><span class="span_zwlb_first">' + xml.list[i].CODENAME + '</span><em class="em_zwlb_split"></em></div><div class="div_zwlb_second">';
                    for (var j = 0; j < xml.list[i].childs.length; j++) {
                        html += '<div class="div_zwlb_second_inner"><span class="span_zwlb_second">' + xml.list[i].childs[j].CODENAME + '</span><img class="img_zwlb_second_inner"/>';
                        html += '<div class="div_zwlb_third">';
                        for (var k = 0; k < xml.list[i].childs[j].childs.length; k++) {
                            html += '<span class="span_zwlb_third">' + xml.list[i].childs[j].childs[k].CODENAME + '</span>';
                        }
                        html += '</div></div>';
                    }
                    html += '</div>';
                }
                $("#divZWLB").html(html);
                $(".div_zwlb_second:eq(0)").css("height", "60px"); $(".div_zwlb_second:eq(2)").css("height", "60px"); $(".div_zwlb_second:eq(4)").css("height", "60px");
                $("#divZWLB").css("display", "");
                $(".div_zwlb_second_inner").bind("click", ShowZWLBThird);
                $(".div_zwlb_second_inner").bind("mouseleave", HideZWLBThird);
                $(".span_zwlb_third").bind("click", SelectZWLB);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择职位类别
function SelectZWLB() {
    $("#spanZWLB").html($(this)[0].innerHTML);
    $("#divZWLB").css("display", "none");
    $("#BT").val($(this)[0].innerHTML);
    ValidateSelect("ZPZWLB", "ZWLB", "忘记选择职位类别啦");
}
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: type,
            TBName: "CODES_QZZP"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 4 || i === 9 || i === 14 || i === 19 || i === 24) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 5) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 5) * 45 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 5) + 1) * 45 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadQZZP_QZZPJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载求职招聘_全职招聘基本信息
function LoadQZZP_QZZPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/QZZP/LoadQZZP_QZZPJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.QZZP_QZZPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.QZZP_QZZPJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanZWLB").html(xml.Value.QZZP_QZZPJBXX.ZWLB);
                $("#spanMYXZ").html(xml.Value.QZZP_QZZPJBXX.MYXZ);
                $("#spanXLYQ").html(xml.Value.QZZP_QZZPJBXX.XLYQ);
                $("#spanGZNX").html(xml.Value.QZZP_QZZPJBXX.GZNX);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.QZZP_QZZPJBXX.ZWFL !== null)
                    SetDuoX("ZWFL", xml.Value.QZZP_QZZPJBXX.ZWFL);
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
    obj = jsonObj.AddJson(obj, "ZWLB", "'" + $("#spanZWLB").html() + "'");
    obj = jsonObj.AddJson(obj, "MYXZ", "'" + $("#spanMYXZ").html() + "'");
    obj = jsonObj.AddJson(obj, "XLYQ", "'" + $("#spanXLYQ").html() + "'");
    obj = jsonObj.AddJson(obj, "GZNX", "'" + $("#spanGZNX").html() + "'");
    obj = jsonObj.AddJson(obj, "ZWFL", "'" + GetDuoX("ZWFL") + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/QZZP/FBQZZP_QZZPJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            BCMS: ue.getContent(),
            FWZP: GetPhotoUrls()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.location.href = getRootPath() + "/Business/FBCG/FBCG";
            } else {

            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}