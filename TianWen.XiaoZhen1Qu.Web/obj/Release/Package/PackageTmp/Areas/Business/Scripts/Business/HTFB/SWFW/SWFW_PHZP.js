$(document).ready(function () {
    BindClick("LB");
    LoadFWFW();
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("喷绘招牌类别", "LB", "CODES_SWFW", Bind, "OUTLB", "LB", "");
        }
        if (type === "CZ") {
            LoadCODESByTYPENAME("灯箱/招牌材质", "CZ", "CODES_SWFW", Bind, "PHZPCZ", "CZ", "");
        }
        if (type === "GY") {
            LoadCODESByTYPENAME("灯箱/招牌工艺", "GY", "CODES_SWFW", Bind, "PHZPGY", "GY", "");
        }
        if (type === "SFFG") {
            LoadCODESByTYPENAME("是否发光", "SFFG", "CODES_SWFW", Bind, "PHZPSFFG", "SFFG", "");
        }
        if (type === "YT") {
            LoadCODESByTYPENAME("标牌用途", "YT", "CODES_SWFW", Bind, "PHZPYT", "YT", "");
        }
        if (type === "GN") {
            LoadCODESByTYPENAME("标牌功能", "GN", "CODES_SWFW", Bind, "PHZPGN", "GN", "");
        }

    });
}
//选择类别下拉框
function SelectLB(obj, type, id) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    if (type === "LB")
        PDLB(obj.innerHTML);
}
//判断类别
function PDLB(lbmc, xl) {
    if (lbmc === "灯箱/招牌") {
        LoadXL($("#spanLB").html(), xl);
        $("#divXL").css("display", "");
        $("#divPHZPCZ").css("display", "");
        $("#divPHZPGY").css("display", "");
        $("#divPHZPSFFG").css("display", "");
        $("#divPHZPYT").css("display", "none");
        $("#divPHZPGN").css("display", "none");
        BindClick("CZ");
        BindClick("GY");
        BindClick("SFFG");
    }
    if (lbmc === "亮化工程" || lbmc === "背景/形象墙" || lbmc === "展架制作" || lbmc === "户外广告" || lbmc === "LED显示屏" || lbmc === "条幅/锦旗/奖牌") {
        LoadXL($("#spanLB").html(), xl);
        $("#divXL").css("display", "");
        $("#divPHZPCZ").css("display", "none");
        $("#divPHZPGY").css("display", "none");
        $("#divPHZPSFFG").css("display", "none");
        $("#divPHZPYT").css("display", "none");
        $("#divPHZPGN").css("display", "none");
        BindClick("XL");
    }
    if (lbmc === "标牌") {
        LoadXL($("#spanLB").html(), xl);
        $("#divXL").css("display", "");
        $("#divPHZPCZ").css("display", "");
        $("#divPHZPGY").css("display", "none");
        $("#divPHZPSFFG").css("display", "none");
        $("#divPHZPYT").css("display", "");
        $("#divPHZPGN").css("display", "");
        BindClick("CZ");
        BindClick("YT");
        BindClick("GN");
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
                    html += "<li class='liXL' style='width:140px;' onclick='SelectDuoX(this)'><img class='img_XL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 4 === 3 && i !== xml.list.length - 1) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 183px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divXL").css("height", parseInt(xml.list.length / 4) * 60 + "px");
                else
                    $("#divXL").css("height", (parseInt(xml.list.length / 4) + 1) * 60 + "px");
                html += "</ul>";
                $("#divXLText").html(html);
                $(".img_XL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liXL").bind("click", function () { ValidateCheck("XL", "忘记选择类别啦"); });
                if (xml.list.length === 0)
                    $("#divXL").css("display", "none");
                else
                    $("#divXL").css("display", "");
                if (xl !== "" && xl !== null)
                    SetDuoX("XL", xl);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载商务服务_喷绘招牌基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW/LoadSWFW_PHZPJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SWFW_PHZPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.SWFW_PHZPJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanLB").html(xml.Value.SWFW_PHZPJBXX.LB);
                $("#spanCZ").html(xml.Value.SWFW_PHZPJBXX.CZ);
                $("#spanGY").html(xml.Value.SWFW_PHZPJBXX.GY);
                $("#spanSFFG").html(xml.Value.SWFW_PHZPJBXX.SFFG);
                $("#spanYT").html(xml.Value.SWFW_PHZPJBXX.YT);
                $("#spanGN").html(xml.Value.SWFW_PHZPJBXX.GN);
                $("#spanQY").html(xml.Value.SWFW_PHZPJBXX.QY);
                $("#spanDD").html(xml.Value.SWFW_PHZPJBXX.DD);
                PDLB(xml.Value.SWFW_PHZPJBXX.LB, xml.Value.SWFW_PHZPJBXX.XL);
                if (xml.Value.SWFW_PHZPJBXX.FWFW !== null)
                    SetDuoX("FWFW", xml.Value.SWFW_PHZPJBXX.FWFW);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "CZ", "'" + $("#spanCZ").html() + "'");
    obj = jsonObj.AddJson(obj, "GY", "'" + $("#spanGY").html() + "'");
    obj = jsonObj.AddJson(obj, "SFFG", "'" + $("#spanSFFG").html() + "'");
    obj = jsonObj.AddJson(obj, "YT", "'" + $("#spanYT").html() + "'");
    obj = jsonObj.AddJson(obj, "GN", "'" + $("#spanGN").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + GetDuoX("XL") + "'");
    obj = jsonObj.AddJson(obj, "FWFW", "'" + GetDuoX("FWFW") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW/FBSWFW_PHZPJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            BCMS: ue.getContent(),
            FWZP: GetPhotoUrls()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.location.href = getRootPath() + "/Business/FBCG/FBCG?LBID=" + getUrlParam("CLICKID") + "&ID=" + xml.Value.ID + "&JCXXID=" + xml.Value.JCXXID;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}