$(document).ready(function () {
    $("#YXQZ").datepicker({ minDate: 0 });
    LoadDuoX("配送方式", "PSFS", "CODES_ES_SJSM");
    BindClick("LB");
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("门票卡券类别", "LB", "CODES_ES_PWKQ", Bind, "MPKQLB", "LB", "");
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
    if (name.indexOf("其他卡券") !== -1 || name.indexOf("游乐园门票") !== -1 || name.indexOf("景点门票") !== -1 || name.indexOf("电影票") !== -1) {
        $("#divXL").css("display", "none");
    }
    else {
        $("#divXL").css("display", "");
        LoadDuoX(name, "XL", "CODES_ES_PWKQ");
    }
}
//加载票务卡券_电影票基本信息
function LoadJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/ES/LoadES_PWKQ_MPKQJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.ES_PWKQ_MPKQJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.ES_PWKQ_MPKQJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () { ue.setContent(xml.Value.BCMSString); });
                if (xml.Value.ES_PWKQ_MPKQJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.ES_PWKQ_MPKQJBXX.GQ);
                if (xml.Value.ES_PWKQ_MPKQJBXX.PSFS !== null)
                    SetDuoX("PSFS", xml.Value.ES_PWKQ_MPKQJBXX.PSFS);
                $("#spanLB").html(xml.Value.ES_PWKQ_MPKQJBXX.LB);
                $("#spanQY").html(xml.Value.ES_PWKQ_MPKQJBXX.QY);
                $("#spanDD").html(xml.Value.ES_PWKQ_MPKQJBXX.DD);
                if (xml.Value.ES_PWKQ_MPKQJBXX.YXQZ.ToString("yyyy-MM-dd") !== "1-1-1")
                    $("#YXQZ").val(xml.Value.ES_PWKQ_MPKQJBXX.YXQZ.ToString("yyyy-MM-dd"));
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
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");
    obj = jsonObj.AddJson(obj, "PSFS", "'" + GetDuoX("PSFS") + "'");

    if ($("#YXQZ").val() !== "")
        obj = jsonObj.AddJson(obj, "YXQZ", "'" + $("#YXQZ").val() + "'");
    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/ES/FBES_PWKQ_MPKQJBXX",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            BCMS: ue.getContent()
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
