
$(document).ready(function () {$("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });LoadJXSBWXLB();
    
    BindClick("QY");
    BindClick("DD");
});

//加载机械设备维修类别
function LoadJXSBWXLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "机械设备维修",
            TBName: "CODES_SWFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liJXSBWXLB' onclick='SelectDuoX(this)'><img class='img_JXSBWXLB'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 3 || i === 7 || i === 11 || i === 15 || i === 19) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divJXSBWXLB").css("height", parseInt(xml.list.length / 4) * 45 + "px");
                else
                    $("#divJXSBWXLB").css("height", (parseInt(xml.list.length / 4) + 1) * 45 + "px");
                html += "</ul>";
                $("#divJXSBWXLBText").html(html);
                $(".img_JXSBWXLB").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadSWFW_JXSBWXJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载商务服务_机械设备维修基本信息
function LoadSWFW_JXSBWXJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW_JXSBWX/LoadSWFW_JXSBWXJBXX",
        dataType: "json",
        data:
        {
            SWFW_JXSBWXJBXXID: getUrlParam("SWFW_JXSBWXJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SWFW_JXSBWXJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SWFW_JXSBWXJBXXID").val(xml.Value.SWFW_JXSBWXJBXX.SWFW_JXSBWXJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                SetDuoX("JXSBWXLB", xml.Value.SWFW_JXSBWXJBXX.LB);
                $("#spanQY").html(xml.Value.SWFW_JXSBWXJBXX.QY);
                $("#spanDD").html(xml.Value.SWFW_JXSBWXJBXX.DD);
                LoadPhotos(xml.Value.Photos);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//发布
function FB() {
    if (AllValidate() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDuoX("JXSBWXLB") + "'");

    if (getUrlParam("SWFW_JXSBWXJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SWFW_JXSBWXJBXXID", "'" + getUrlParam("SWFW_JXSBWXJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW_JXSBWX/FB",
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