$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadES_SJSM_ESSJJBXX();
    BindClick("SJPP");
    BindClick("SJXH");
    BindClick("QY");
    BindClick("DD");
});
//房屋描述框focus
function BCMSFocus() {
    $("#BCMS").css("color", "#333333");
}
//房屋描述框blur
function BCMSBlur() {
    $("#BCMS").css("color", "#999999");
}
//房屋描述框设默认文本
function BCMSSetDefault() {
    var BCMS = "1.房屋特征：\r\n\r\n2.周边配套：\r\n\r\n3.房东心态：";
    $("#BCMS").html(BCMS);
}

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "SJPP") {
            LoadCODESByTYPENAME("手机品牌", "SJPP", "CODES_ES_SJSM");
        }
        if (type === "SJXH") {
            LoadSJXH();
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
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
    BindClick("SJXH");
}
//加载二手_手机数码_二手手机基本信息
function LoadES_SJSM_ESSJJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_SJSM_ESSJ/LoadES_SJSM_ESSJJBXX",
        dataType: "json",
        data:
        {
            ES_SJSM_ESSJJBXXID: getUrlParam("ES_SJSM_ESSJJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_SJSM_ESSJJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ES_SJSM_ESSJJBXXID").val(xml.Value.ES_SJSM_ESSJJBXX.ES_SJSM_ESSJJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.ES_SJSM_ESSJJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_SJSM_ESSJJBXX.GQ);
                if (xml.Value.ES_SJSM_ESSJJBXX.SYQK !== null)
                    SetDX("SYQK", xml.Value.ES_SJSM_ESSJJBXX.SYQK);
                $("#spanQY").html(xml.Value.ES_SJSM_ESSJJBXX.JYQY);
                $("#spanDD").html(xml.Value.ES_SJSM_ESSJJBXX.JYDD);
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
    obj = jsonObj.AddJson(obj, "JYQY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "JYDD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");
    obj = jsonObj.AddJson(obj, "SYQK", "'" + GetDX("SYQK") + "'");

    if (getUrlParam("ES_SJSM_ESSJJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "ES_SJSM_ESSJJBXXID", "'" + getUrlParam("ES_SJSM_ESSJJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/ES_SJSM_ESSJ/FB",
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
