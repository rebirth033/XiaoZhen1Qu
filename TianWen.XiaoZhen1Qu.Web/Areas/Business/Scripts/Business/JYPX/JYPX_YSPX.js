$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
    LoadDuoX("对象", "DX");
});
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: type,
            TBName: "CODES_JYPX"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 4 === 3) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 4) * 60 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 4) + 1) * 60 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liDX").bind("click", function () { ValidateCheck("DX", "忘记选择小类啦"); });
                if (xml.list.length === 0)
                    $("#div" + id).css("display", "none");
                else
                    $("#div" + id).css("display", "");
                if (type === "对象")
                    LoadJYPX_YSPXJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择类别下拉框
function SelectLB(obj, type, id) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    PDLB(obj.innerHTML);
}
//判断类别
function PDLB(lb) {
    if (lb === "舞蹈" || lb === "乐器" || lb === "美术" || lb === "声乐") {
        LoadXL($("#spanLB").html());
        $("#divXL").css("display", "");
    }
    else {
        $("#divXL").css("display", "none");
    }
}
//加载小类
function LoadXL(lbmc, xl) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: lbmc,
            TBName: "CODES_JYPX"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liXL' onclick='SelectDuoX(this)'><img class='img_XL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 5 === 4) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 5) === 0)
                    $("#divXL").css("height", parseInt(xml.list.length / 5) * 50 + "px");
                else
                    $("#divXL").css("height", (parseInt(xml.list.length / 5) + 1) * 50 + "px");
                html += "</ul>";
                $("#divXLText").html(html);
                $(".img_XL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liXL").bind("click", function () { ValidateCheck("XL", "忘记选择小类啦"); });
                if (xml.list.length === 0)
                    $("#divXL").css("display", "none");
                else
                    $("#divXL").css("display", "");
                if (xl !== "" && xl !== null && xl !== undefined)
                    SetDuoX("XL", xl);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("艺术培训", "LB", "CODES_JYPX", Bind, "OUTLB", "LB", "");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载商务服务_艺术培训基本信息
function LoadJYPX_YSPXJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/JYPX_YSPX/LoadJYPX_YSPXJBXX",
        dataType: "json",
        data:
        {
            JYPX_YSPXJBXXID: getUrlParam("JYPX_YSPXJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JYPX_YSPXJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#JYPX_YSPXJBXXID").val(xml.Value.JYPX_YSPXJBXX.JYPX_YSPXJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.JYPX_YSPXJBXX.LB);
                $("#spanQY").html(xml.Value.JYPX_YSPXJBXX.QY);
                $("#spanDD").html(xml.Value.JYPX_YSPXJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                LoadXL(xml.Value.JYPX_YSPXJBXX.LB, xml.Value.JYPX_YSPXJBXX.XL);
                SetDuoX("DX", xml.Value.JYPX_YSPXJBXX.DX);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + GetDuoX("XL") + "'");
    obj = jsonObj.AddJson(obj, "DX", "'" + GetDuoX("DX") + "'");

    if (getUrlParam("JYPX_YSPXJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "JYPX_YSPXJBXXID", "'" + getUrlParam("JYPX_YSPXJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/JYPX_YSPX/FB",
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