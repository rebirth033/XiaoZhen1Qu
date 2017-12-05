$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ");});
    BindClick("LB");
    LoadGY();
});
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("印刷包装类别", "LB", "CODES_SWFW", Bind, "OUTLB", "LB", "");
        }
        if (type === "CZ") {
            LoadCODESByTYPENAME("材质", "CZ", "CODES_SWFW");
        }
        if (type === "YT") {
            LoadCODESByTYPENAME("用途", "YT", "CODES_SWFW");
        }
        if (type === "BZRQ") {
            LoadCODESByTYPENAME("包装容器", "BZRQ", "CODES_SWFW");
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
function PDLB(lbmc, xl) {
    if (lbmc === "纸类印刷" || lbmc === "宣传资料印刷") {
        LoadXL($("#spanLB").html(), xl);
        $("#divXL").css("display", "");
        $("#divYSBZCZ").css("display", "none");
        $("#divYSBZYT").css("display", "none");
        $("#divYSBZBZRQ").css("display", "none");
    }
    else if (lbmc === "包装") {
        $("#divXL").css("display", "none");
        $("#divYSBZCZ").css("display", "");
        $("#divYSBZYT").css("display", "");
        $("#divYSBZBZRQ").css("display", "");
        BindClick("CZ");
        BindClick("YT");
        BindClick("BZRQ");
    }
    else {
        $("#divXL").css("display", "none");
        $("#divYSBZCZ").css("display", "none");
        $("#divYSBZYT").css("display", "none");
        $("#divYSBZBZRQ").css("display", "none");
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
            TBName: "CODES_SWFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liXL' style='width:120px;' onclick='SelectDuoX(this)'><img class='img_XL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 4 || i === 9) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 6) === 0)
                    $("#divXL").css("height", parseInt(xml.list.length / 5) * 60 + "px");
                else
                    $("#divXL").css("height", (parseInt(xml.list.length / 5) + 1) * 60 + "px");
                html += "</ul>";
                $("#divXLText").html(html);
                $(".img_XL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liXL").bind("click", function () { ValidateCheck("XL", "忘记选择类别啦"); });
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
//加载工艺
function LoadGY() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "工艺",
            TBName: "CODES_SWFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liGY' onclick='SelectDuoX(this)'><img class='img_GY'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 6 === 5) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 6) === 0)
                    $("#divGY").css("height", parseInt(xml.list.length / 6) * 45 + "px");
                else
                    $("#divGY").css("height", (parseInt(xml.list.length / 6) + 1) * 45 + "px");
                html += "</ul>";
                $("#divGYText").html(html);
                $(".img_GY").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadSWFW_YSBZJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载商务服务_印刷包装基本信息
function LoadSWFW_YSBZJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW/LoadSWFW_YSBZJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SWFW_YSBZJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.SWFW_YSBZJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.SWFW_YSBZJBXX.LB);
                $("#spanCZ").html(xml.Value.SWFW_YSBZJBXX.CZ);
                $("#spanYT").html(xml.Value.SWFW_YSBZJBXX.YT);
                $("#spanBZRQ").html(xml.Value.SWFW_YSBZJBXX.BZRQ);
                $("#spanQY").html(xml.Value.SWFW_YSBZJBXX.QY);
                $("#spanDD").html(xml.Value.SWFW_YSBZJBXX.DD);
                PDLB(xml.Value.SWFW_YSBZJBXX.LB, xml.Value.SWFW_YSBZJBXX.XL);
                LoadPhotos(xml.Value.Photos);
                SetDuoX("GY", xml.Value.SWFW_YSBZJBXX.GY);
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
    obj = jsonObj.AddJson(obj, "CZ", "'" + $("#spanCZ").html() + "'");
    obj = jsonObj.AddJson(obj, "YT", "'" + $("#spanYT").html() + "'");
    obj = jsonObj.AddJson(obj, "BZRQ", "'" + $("#spanBZRQ").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + GetDuoX("XL") + "'");
    obj = jsonObj.AddJson(obj, "GY", "'" + GetDuoX("GY") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW/FBSWFW_YSBZJBXX",
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