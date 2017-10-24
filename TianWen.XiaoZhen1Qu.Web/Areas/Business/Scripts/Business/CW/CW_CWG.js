$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadCW_CWGJBXX();
    BindClick("PZ");
    BindClick("NLDW");
    BindClick("XB");
    BindClick("YMQK");
    BindClick("YMZL");
});
//加载宠物狗品种标签
function LoadCWG() {
    var arrayObj = new Array('RM', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    var html = "";
    for (var i = 0; i < arrayObj.length; i++) {
        if (i === 0)
            html += '<div class="div_bqss_content_bq" id="div' + arrayObj[i] + '" style="width:62px;"><span class="span_bqss_content_bq" id="span' + arrayObj[i] + '">' + "热门" + '</span><em class="em_bqss_content_bq" id="em' + arrayObj[i] + '"></em></div>';
        else
            html += '<div class="div_bqss_content_bq" id="div' + arrayObj[i] + '"><span class="span_bqss_content_bq" id="span' + arrayObj[i] + '">' + arrayObj[i] + '</span><em class="em_bqss_content_bq" id="em' + arrayObj[i] + '"></em></div>';
    }
    $("#div_content_cwgbq").html(html);
    $(".div_bqss_content_bq").bind("click", CWGBQActive);
}
//宠物狗品种标签切换
function CWGBQActive() {
    LoadCWGPZ(this.id);
}
//加载宠物狗品种名称
function LoadCWGPZ(CWG) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByCodeValueAndTypeName",
        dataType: "json",
        data:
        {
            CODEVALUE: CWG.split("div")[1],
            TYPENAME: "宠物狗",
            TBName: "CODES_CW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_mc" onclick="CWGXZ(\'' + xml.list[i].CODENAME + '\',\'' + xml.list[i].CODEID + '\')">' + xml.list[i].CODENAME + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_mc" style=\"width:200px;text-align:left;margin-left:14px;\">该字母下暂无数据</span>';
                $("#div_content_cwgmc").html(html);
                $("#divPZ").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择宠物狗品种名称
function CWGXZ(CXMC, CXID) {
    $("#spanPZ").html(CXMC);
    $("#divPZ").css("display", "none");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "PZ") {
            LoadCWG();
            LoadCWGPZ("divRM");
        }
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
//选择宠物狗品牌
function SelectPBPP(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadPBXH(code);
}
//加载车辆_宠物狗基本信息
function LoadCW_CWGJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CW_CWG/LoadCW_CWGJBXX",
        dataType: "json",
        data:
        {
            CW_CWGJBXXID: getUrlParam("CW_CWGJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CW_CWGJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#CW_CWGJBXXID").val(xml.Value.CW_CWGJBXX.CW_CWGJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanPZ").html(xml.Value.CW_CWGJBXX.PZ);
                $("#spanNLDW").html(xml.Value.CW_CWGJBXX.NLDW);
                $("#spanXB").html(xml.Value.CW_CWGJBXX.XB);
                $("#spanYMQK").html(xml.Value.CW_CWGJBXX.YMQK);
                $("#spanYMZL").html(xml.Value.CW_CWGJBXX.YMZL);
                if (xml.Value.CW_CWGJBXX.SF !== null)
                    SetDX("GQ", xml.Value.CW_CWGJBXX.SF);
                if (xml.Value.CW_CWGJBXX.QCQK !== null)
                    SetDX("QCQK", xml.Value.CW_CWGJBXX.QCQK);
                if (xml.Value.CW_CWGJBXX.SPKG !== null)
                    SetDX("SPKG", xml.Value.CW_CWGJBXX.SPKG);
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
    obj = jsonObj.AddJson(obj, "NLDW", "'" + $("#spanNLDW").html() + "'");
    obj = jsonObj.AddJson(obj, "XB", "'" + $("#spanXB").html() + "'");
    obj = jsonObj.AddJson(obj, "YMQK", "'" + $("#spanYMQK").html() + "'");
    obj = jsonObj.AddJson(obj, "YMZL", "'" + $("#spanYMZL").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "SF", "'" + GetDX("GQ") + "'");
    obj = jsonObj.AddJson(obj, "QCQK", "'" + GetDX("QCQK") + "'");
    obj = jsonObj.AddJson(obj, "SPKG", "'" + GetDX("SPKG") + "'");

    if (getUrlParam("CW_CWGJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "CW_CWGJBXXID", "'" + getUrlParam("CW_CWGJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CW_CWG/FB",
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