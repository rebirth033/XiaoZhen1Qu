$(document).ready(function () {
    BindClick("LB");
    $("#divXLBQ").bind("click", function () { LoadXLBQ("CODES_SWFW", "国家"); });
    LoadJBXX();
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("代办签证/签注类别", "LB", "CODES_SWFW", Bind, "OUTLB", "LB", "");
        }
    });
}
//选择小类标签
function SelectXLBQ(obj, codename) {
    if ($(obj).find("img").attr("src").indexOf("purple") !== -1) {
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
        $("#" + codename).remove();
    }
    else {
        if ($("#spanXLBQ").find(".div_XLBQ").length !== 2) {
            if ($("#spanXLBQ").html().indexOf("请选择") !== -1) $("#spanXLBQ").html('');
            $("#spanXLBQ").append('<div id="' + codename + '" class="div_XLBQ">' + codename + '</div>');
            $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_purple.png");
        }
        else
            alert("最多只选择2项");
    }
}
//加载商务服务_代办签证/签注基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/SWFW/LoadSWFW_DBQZQZJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SWFW_DBQZQZJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.SWFW_DBQZQZJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                $("#spanLB").html(xml.Value.SWFW_DBQZQZJBXX.LB);
                SetXLBQ(xml.Value.SWFW_DBQZQZJBXX.GJ);
                $("#spanQY").html(xml.Value.SWFW_DBQZQZJBXX.QY);
                $("#spanDD").html(xml.Value.SWFW_DBQZQZJBXX.DD);
                SetDX("GRTT", xml.Value.SWFW_DBQZQZJBXX.GRTT);
                LoadPhotos(xml.Value.Photos);
                LoadXL(xml.Value.SWFW_DBQZQZJBXX.LB, xml.Value.SWFW_DBQZQZJBXX.XL);
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
    obj = jsonObj.AddJson(obj, "GJ", "'" + GetXLBQ() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GRTT", "'" + GetDX("GRTT") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/SWFW/FBSWFW_DBQZQZJBXX",
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