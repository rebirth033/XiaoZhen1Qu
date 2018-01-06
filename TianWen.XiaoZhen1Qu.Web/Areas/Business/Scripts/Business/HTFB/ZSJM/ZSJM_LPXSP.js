$(document).ready(function () {
    BindClick("LB");
    BindClick("PPLS");
    BindClick("TZJE");
    BindClick("QGFDS");
    BindClick("DDMJ");
    LoadDuoX("适合人群", "SHRQ");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("礼品商品类别", "LB", "CODES_ZSJM", Bind, "LPXSPLB", "LB", "");
        }
        if (type === "PPLS") {
            LoadCODESByTYPENAME("品牌历史", "PPLS", "CODES_ZSJM");
        }
        if (type === "TZJE") {
            LoadCODESByTYPENAME("投资金额", "TZJE", "CODES_ZSJM", Bind, "LPXSPTZJE", "TZJE", "");
        }
        if (type === "QGFDS") {
            LoadCODESByTYPENAME("全国分店数", "QGFDS", "CODES_ZSJM");
        }
        if (type === "DDMJ") {
            LoadCODESByTYPENAME("单店面积", "DDMJ", "CODES_ZSJM");
        }
    });
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
            TBName: "CODES_ZSJM"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 6 === 5) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 183px'>";
                    }
                }
                if (parseInt(xml.list.length % 6) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 6) * 60 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 6) + 1) * 60 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liXL").bind("click", function () { ValidateCheck("XL", "忘记选择小类啦"); });
                if (type === "适合人群")
                    LoadDuoX("经营模式", "JYMS");
                if (type === "经营模式")
                    LoadFWFW();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择类别下拉框
function SelectLB(obj, type, codeid) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    if (type === "LB")
        PDLB(obj.innerHTML, codeid);
}
//判断类别
function PDLB(name, codeid) {
    if ((name.indexOf("饰品挂件") !== -1 || name.indexOf("礼品") !== -1 || name.indexOf("工艺品") !== -1 || name.indexOf("珠宝玉器") !== -1) && name !== "礼品加工") {
        $("#divXL").css("display", "");
        LoadDuoX(name, "XL");
    }
    else {
        $("#divXL").css("display", "none");
    }
}
//加载招商加盟_礼品/小商品基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ZSJM/LoadZSJM_LPXSPJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ZSJM_LPXSPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.ZSJM_LPXSPJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanLB").html(xml.Value.ZSJM_LPXSPJBXX.LB);
                $("#spanQY").html(xml.Value.ZSJM_LPXSPJBXX.QY);
                $("#spanDD").html(xml.Value.ZSJM_LPXSPJBXX.DD);
                $("#spanPPLS").html(xml.Value.ZSJM_LPXSPJBXX.PPLS);
                $("#spanTZJE").html(xml.Value.ZSJM_LPXSPJBXX.TZJE);
                $("#spanQGFDS").html(xml.Value.ZSJM_LPXSPJBXX.QGFDS);
                $("#spanDDMJ").html(xml.Value.ZSJM_LPXSPJBXX.DDMJ);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.ZSJM_LPXSPJBXX.SHRQ !== null)
                    SetDuoX("SHRQ", xml.Value.ZSJM_LPXSPJBXX.SHRQ);
                if (xml.Value.ZSJM_LPXSPJBXX.JYMS !== null)
                    SetDuoX("JYMS", xml.Value.ZSJM_LPXSPJBXX.JYMS);
                if (xml.Value.ZSJM_LPXSPJBXX.FWFW !== null)
                    SetDuoX("FWFW", xml.Value.ZSJM_LPXSPJBXX.FWFW);
                if ((xml.Value.ZSJM_LPXSPJBXX.LB.indexOf("饰品挂件") !== -1 || xml.Value.ZSJM_LPXSPJBXX.LB.indexOf("礼品") !== -1 || xml.Value.ZSJM_LPXSPJBXX.LB.indexOf("工艺品") !== -1 || xml.Value.ZSJM_LPXSPJBXX.LB.indexOf("珠宝玉器") !== -1) && xml.Value.ZSJM_LPXSPJBXX.LB !== "礼品加工") {
                    LoadXLByName(xml.Value.ZSJM_LPXSPJBXX.LB, xml.Value.ZSJM_LPXSPJBXX.XL,"CODES_ZSJM");
                }
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
    obj = jsonObj.AddJson(obj, "PPLS", "'" + $("#spanPPLS").html() + "'");
    obj = jsonObj.AddJson(obj, "TZJE", "'" + $("#spanTZJE").html() + "'");
    obj = jsonObj.AddJson(obj, "QGFDS", "'" + $("#spanQGFDS").html() + "'");
    obj = jsonObj.AddJson(obj, "DDMJ", "'" + $("#spanDDMJ").html() + "'");
    obj = jsonObj.AddJson(obj, "SHRQ", "'" + GetDuoX("SHRQ") + "'");
    obj = jsonObj.AddJson(obj, "JYMS", "'" + GetDuoX("JYMS") + "'");
    obj = jsonObj.AddJson(obj, "FWFW", "'" + GetDuoX("FWFW") + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + GetDuoX("XL") + "'");

    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ZSJM/FBZSJM_LPXSPJBXX",
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
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}