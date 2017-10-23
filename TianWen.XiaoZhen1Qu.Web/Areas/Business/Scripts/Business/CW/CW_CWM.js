
$(document).ready(function () {$("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });LoadCW_CWMJBXX();
    BindClick("PZ");
});
//描述框focus
function BCMSFocus() {
    $("#BCMS").css("color", "#333333");
}
//描述框blur
function BCMSBlur() {
    $("#BCMS").css("color", "#999999");
}
//描述框设默认文本
function BCMSSetDefault() {
    var BCMS = "1.房屋特征：\r\n\r\n2.周边配套：\r\n\r\n3.房东心态：";
    $("#BCMS").html(BCMS);
}

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "PZ") {
            LoadCODESByTYPENAME("宠物猫", "PZ", "CODES_CW");
        }
    });
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
}
//加载宠物_宠物猫基本信息
function LoadCW_CWMJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CW_CWM/LoadCW_CWMJBXX",
        dataType: "json",
        data:
        {
            CW_CWMJBXXID: getUrlParam("CW_CWMJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CW_CWMJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#CW_CWMJBXXID").val(xml.Value.CW_CWMJBXX.CW_CWMJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanPZ").html(xml.Value.CW_CWMJBXX.PZ);
                if (xml.Value.CW_CWMJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.CW_CWMJBXX.GQ);
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
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if (getUrlParam("CW_CWMJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "CW_CWMJBXXID", "'" + getUrlParam("CW_CWMJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CW_CWM/FB",
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