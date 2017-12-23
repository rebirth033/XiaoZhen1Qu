$(document).ready(function () {
    LoadCW_CWGJBXX();
    BindClick("NLDW");
    BindClick("XB");
    BindClick("YMQK");
    BindClick("YMZL");
    $("#divXLBQ").bind("click", function () { LoadXLBQ("CODES_CW", "宠物狗品种"); });
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "NLDW") {
            LoadCODESByTYPENAME("年龄单位", "NLDW", "CODES_CW", Bind, "CWGNL", "NLDW", "");
        }
        if (type === "XB") {
            LoadCODESByTYPENAME("性别", "XB", "CODES_CW", Bind, "CWGXB", "XB", "");
        }
        if (type === "YMQK") {
            LoadCODESByTYPENAME("疫苗情况", "YMQK", "CODES_CW", Bind, "CWGYMQK", "YMQK", "");
        }
        if (type === "YMZL") {
            LoadCODESByTYPENAME("疫苗种类", "YMZL", "CODES_CW", Bind, "CWGYMQK", "YMZL", "");
        }
    });
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
}
//加载车辆_宠物狗基本信息
function LoadCW_CWGJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CW/LoadCW_CWGJBXX",
        dataType: "json",
        data:
        {
            ID: getUrlParam("ID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CW_CWGJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#ID").val(xml.Value.CW_CWGJBXX.ID);
                //设置编辑器的内容
                ue.ready(function () {ue.setContent(xml.Value.BCMSString);});
                SetXLBQ(xml.Value.CW_CWGJBXX.PZ);
                $("#spanNLDW").html(xml.Value.CW_CWGJBXX.NLDW);
                $("#spanXB").html(xml.Value.CW_CWGJBXX.XB);
                $("#spanYMQK").html(xml.Value.CW_CWGJBXX.YMQK);
                $("#spanYMZL").html(xml.Value.CW_CWGJBXX.YMZL);
                if (xml.Value.CW_CWGJBXX.SF !== null)
                    SetDX("GQ", xml.Value.CW_CWGJBXX.SF);
                if (xml.Value.CW_CWGJBXX.QCQK !== null)
                    SetDX("QCQK", xml.Value.CW_CWGJBXX.QCQK);
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
    obj = jsonObj.AddJson(obj, "PZ", "'" + GetXLBQ() + "'");
    obj = jsonObj.AddJson(obj, "NLDW", "'" + $("#spanNLDW").html() + "'");
    obj = jsonObj.AddJson(obj, "XB", "'" + $("#spanXB").html() + "'");
    obj = jsonObj.AddJson(obj, "YMQK", "'" + $("#spanYMQK").html() + "'");
    obj = jsonObj.AddJson(obj, "YMZL", "'" + $("#spanYMZL").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("GQ") + "'");
    obj = jsonObj.AddJson(obj, "QCQK", "'" + GetDX("QCQK") + "'");

    if (getUrlParam("ID") !== null)
        obj = jsonObj.AddJson(obj, "ID", "'" + getUrlParam("ID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CW/FBCW_CWGJBXX",
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