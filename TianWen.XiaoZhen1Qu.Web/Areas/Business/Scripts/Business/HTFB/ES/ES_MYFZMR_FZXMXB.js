$(document).ready(function () {
    LoadDuoX("配送方式", "PSFS");
    BindClick("LB");
    BindClick("XJ");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("服装/鞋帽/箱包类别", "LB", "CODES_ES_MYFZMR", Bind, "FZXMXBLB", "LB", "");
        }
        if (type === "XL") {
            LoadCODESByTYPENAME($("#spanLB").html(), "XL", "CODES_ES_MYFZMR", Bind, "FZXMXBLB", "XL", "");
        }
        if (type === "FZCC") {
            LoadCODESByTYPENAME("服装尺寸", "FZCC", "CODES_ES_MYFZMR");
        }
        if (type === "XCC") {
            LoadCODESByTYPENAME("鞋尺寸", "XCC", "CODES_ES_MYFZMR");
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM", Bind, "XJCD", "XJ", "");
        }
    });
}
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: type,
            TBName: "CODES_ES_SJSM"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                   if (i % 5 === 4 && i != xml.list.length - 1) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 173px'>";
                    }
                }
                if (parseInt(xml.list.length % 5) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 5) * 45 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 5) + 1) * 45 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");

                LoadJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    if(type === "LB")
    PDLB(obj.innerHTML);
}
//判断类别
function PDLB(LB) {
    if (LB === "服装") {
        $("#divFZXXCS").css("display", "");
        $("#divXXXCS").css("display", "none");
        BindClick("FZCC");
    }
    else if (LB === "鞋") {
        $("#divFZXXCS").css("display", "none");
        $("#divXXXCS").css("display", "");
        BindClick("XCC");
    }
    else {
        $("#divFZXXCS").css("display", "none");
        $("#divXXXCS").css("display", "none");
    }
    BindClick("XL");
}
//加载二手_手机数码_母婴/服装/美容基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/ES/LoadES_MYFZMR_FZXMXBJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_MYFZMR_FZXMXBJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.ES_MYFZMR_FZXMXBJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                if (xml.Value.ES_MYFZMR_FZXMXBJBXX.SF !== null)
                    SetDX("SF", xml.Value.ES_MYFZMR_FZXMXBJBXX.SF);
                if (xml.Value.ES_MYFZMR_FZXMXBJBXX.PSFS !== null)
                    SetDuoX("PSFS", xml.Value.ES_MYFZMR_FZXMXBJBXX.PSFS);
                $("#spanLB").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.LB);
                $("#spanXJ").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.XJ);
                $("#spanQY").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.QY);
                $("#spanDD").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.DD);
                $("#spanXL").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.XL);
                $("#spanXCC").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.XCC);
                $("#spanFZCC").html(xml.Value.ES_MYFZMR_FZXMXBJBXX.FZCC);

                LoadPhotos(xml.Value.Photos);
                PDLB(xml.Value.ES_MYFZMR_FZXMXBJBXX.LB);
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
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "XJ", "'" + $("#spanXJ").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "XCC", "'" + $("#spanXCC").html() + "'");
    obj = jsonObj.AddJson(obj, "FZCC", "'" + $("#spanFZCC").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("SF") + "'");
    obj = jsonObj.AddJson(obj, "PSFS", "'" + GetDuoX("PSFS") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/ES/FBES_MYFZMR_FZXMXBJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            BCMS: ue.getContent(),
            FWZP: GetPhotoUrls()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.location.href = getRootPath() + "/FBCG/FBCG?LBID=" + getUrlParam("CLICKID") + "&ID=" + xml.Value.ID + "&JCXXID=" + xml.Value.JCXXID;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
