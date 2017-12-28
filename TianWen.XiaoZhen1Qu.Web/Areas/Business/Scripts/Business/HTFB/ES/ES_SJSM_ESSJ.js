$(document).ready(function () {
    BindClick("SJPP");
    BindClick("SJXH");
    BindClick("XJ");
    LoadDuoX("特色标签", "TSBQ");
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
            TBName: "CODES_ES_SJSM"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 5 === 4) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 183px'>";
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
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "SJPP") {
            LoadCODESByTYPENAME("手机品牌", "SJPP", "CODES_ES_SJSM");
        }
        if (type === "SJXH") {
            LoadSJXH();
        }
        if (type === "XJ") {
            LoadCODESByTYPENAME("新旧程度", "XJ", "CODES_ES_SJSM", Bind, "XJCD", "XJ", "");
        }
    });
}
//加载手机型号
function LoadSJXH() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: $("#PPID").val(),
            TBName: "CODES_ES_SJSM"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ul_select' style='overflow-y: scroll;height:340px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectDropdown(this,\"SJXH\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divSJXH").html(html);
                $("#divSJXH").css("display", "block");
                ActiveStyle("SJXH");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择区域下拉框
function SelectLB(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#PPID").val(code);
}
//加载二手_手机数码_二手手机基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/LoadES_SJSM_ESSJJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_SJSM_ESSJJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.ES_SJSM_ESSJJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                if (xml.Value.ES_SJSM_ESSJJBXX.SF !== null)
                    SetDX("SF", xml.Value.ES_SJSM_ESSJJBXX.SF);
                if (xml.Value.ES_SJSM_ESSJJBXX.SYQK !== null)
                    SetDX("SYQK", xml.Value.ES_SJSM_ESSJJBXX.SYQK);
                if (xml.Value.ES_SJSM_ESSJJBXX.TSBQ !== null)
                    SetDuoX("TSBQ", xml.Value.ES_SJSM_ESSJJBXX.TSBQ);
                $("#spanQY").html(xml.Value.ES_SJSM_ESSJJBXX.QY);
                $("#spanDD").html(xml.Value.ES_SJSM_ESSJJBXX.DD);
                $("#spanSJPP").html(xml.Value.ES_SJSM_ESSJJBXX.SJPP);
                $("#spanSJXH").html(xml.Value.ES_SJSM_ESSJJBXX.SJXH);
                LoadPhotos(xml.Value.Photos);
                return;
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
    obj = jsonObj.AddJson(obj, "SJPP", "'" + $("#spanSJPP").html() + "'");
    obj = jsonObj.AddJson(obj, "SJXH", "'" + $("#spanSJXH").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("SF") + "'");
    obj = jsonObj.AddJson(obj, "SYQK", "'" + GetDX("SYQK") + "'");
    obj = jsonObj.AddJson(obj, "TSBQ", "'" + GetDuoX("TSBQ") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES/FBES_SJSM_ESSJJBXX",
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
