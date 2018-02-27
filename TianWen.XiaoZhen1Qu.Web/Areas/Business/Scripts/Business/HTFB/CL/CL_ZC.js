$(document).ready(function () {
    BindClick("LB");
    LoadFWFW();
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("租车类别", "LB", "CODES_CL", Bind, "OUTLB", "LB", "");
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
    if (lb === "货车" || lb === "出租车" || lb === "特殊车辆") {
        $("#divXL").css("display", "none");
    }
    else {
        LoadXL($("#spanLB").html());
        $("#divXL").css("display", "");
    }
}
//加载小类
function LoadXL(lbmc, xl) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: lbmc,
            TBName: "CODES_CL"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liXL' onclick='SelectDuoX(this)'><img class='img_XL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 6 === 5) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 183px'>";
                    }
                }
                if (parseInt(xml.list.length % 6) === 0)
                    $("#divXL").css("height", parseInt(xml.list.length / 6) * 60 + "px");
                else
                    $("#divXL").css("height", (parseInt(xml.list.length / 6) + 1) * 60 + "px");
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
//加载生活服务_租车基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/CL/LoadCL_ZCJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CL_ZCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.CL_ZCJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanLB").html(xml.Value.CL_ZCJBXX.LB);
                $("#spanQY").html(xml.Value.CL_ZCJBXX.QY);
                $("#spanDD").html(xml.Value.CL_ZCJBXX.DD);
                if (xml.Value.CL_ZCJBXX.FWFW !== null)
                    SetDuoX("FWFW", xml.Value.CL_ZCJBXX.FWFW);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.CL_ZCJBXX.LB.indexOf("大巴（30座以上）") !== -1 || xml.Value.CL_ZCJBXX.LB.indexOf("中巴（30座以下）") !== -1 || xml.Value.CL_ZCJBXX.LB.indexOf("面包车") !== -1
                    || xml.Value.CL_ZCJBXX.LB.indexOf("商务车") !== -1 || xml.Value.CL_ZCJBXX.LB.indexOf("豪华轿车") !== -1 || xml.Value.CL_ZCJBXX.LB.indexOf("普通轿车") !== -1
                    || xml.Value.CL_ZCJBXX.LB.indexOf("跑车") !== -1 || xml.Value.CL_ZCJBXX.LB.indexOf("SUV(越野车)") !== -1) {
                    LoadXL(xml.Value.CL_ZCJBXX.LB, xml.Value.CL_ZCJBXX.XL);
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
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + GetDuoX("XL") + "'");
    obj = jsonObj.AddJson(obj, "FWFW", "'" + GetDuoX("FWFW") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/CL/FBCL_ZCJBXX",
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