$(document).ready(function () {
    LoadDuoX("化妆品类别", "LB");
});
////绑定下拉框
//function BindClick(type) {
//    $("#div" + type + "Span").click(function () {
//        if (type === "LB") {
//            LoadCODESByTYPENAME("化妆品类别", "LB", "CODES_PFCG", Bind, "OUTLB", "LB", "");
//        }
//    });
//}
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: type,
            TBName: "CODES_PFCG"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 5 === 4 && i != xml.list.length - 1) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 174px'>";
                    }
                }
                if (parseInt(xml.list.length % 5) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 5) * 40 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 5) + 1) * 40 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".li" + id).bind("click", function () { ValidateCheck("LB", "忘记选择类别啦"); });
                LoadFWFW();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
////加载小类
//function LoadXL(lbmc, xl) {
//    $.ajax({
//        type: "POST",
//        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
//        dataType: "json",
//        data:
//        {
//            TYPENAME: lbmc,
//            TBName: "CODES_PFCG"
//        },
//        success: function (xml) {
//            if (xml.Result === 1) {
//                var html = "<ul class='ulFWPZ'>";
//                for (var i = 0; i < xml.list.length; i++) {
//                    html += "<li class='liXL' onclick='SelectDuoX(this)'><img class='img_XL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
//                    if (i % 6 === 5 && i != xml.list.length - 1) {
//                        html += "</ul><ul class='ulFWPZ' style='margin-left: 174px'>";
//                    }
//                }
//                if (parseInt(xml.list.length % 6) === 0)
//                    $("#divXL").css("height", parseInt(xml.list.length / 6) * 60 + "px");
//                else
//                    $("#divXL").css("height", (parseInt(xml.list.length / 6) + 1) * 60 + "px");
//                html += "</ul>";
//                $("#divXLText").html(html);
//                $(".img_XL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
//                $(".liXL").bind("click", function () { ValidateCheck("XL", "忘记选择小类啦"); });
//                if (xml.list.length === 0)
//                    $("#divXL").css("display", "none");
//                else
//                    $("#divXL").css("display", "");
//                if (xl !== "" && xl !== null && xl !== undefined)
//                    SetDuoX("XL", xl);
//            }
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

//        }
//    });
//}
//加载批发采购_化妆品基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/PFCG/LoadPFCG_HZPJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.PFCG_HZPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.PFCG_HZPJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanLB").html(xml.Value.PFCG_HZPJBXX.LB);
                $("#spanQY").html(xml.Value.PFCG_HZPJBXX.QY);
                $("#spanDD").html(xml.Value.PFCG_HZPJBXX.DD);
                //LoadXL(xml.Value.PFCG_HZPJBXX.LB, xml.Value.PFCG_HZPJBXX.XL);
                if (xml.Value.PFCG_HZPJBXX.FWFW !== null)
                    SetDuoX("FWFW", xml.Value.PFCG_HZPJBXX.FWFW);
                LoadPhotos(xml.Value.Photos);
                //$("#divXLText").css("display", "");
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
    //obj = jsonObj.AddJson(obj, "XL", "'" + GetDuoX("XL") + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "FWFW", "'" + GetDuoX("FWFW") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/PFCG/FBPFCG_HZPJBXX",
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