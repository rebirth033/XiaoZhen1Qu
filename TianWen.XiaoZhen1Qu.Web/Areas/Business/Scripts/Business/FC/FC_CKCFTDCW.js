var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $(".div_radio").bind("click", RadioSelect);
    $("#div_gq_cz").bind("click", CZSelect);
    $("#div_gq_cs").bind("click", CSSelect);
    
    
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qhcs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("LB"); Close("XL"); Close("XJ"); Close("QY"); Close("SQ"); });




    LoadDefault();
    LoadFC_CKCFTDCWJBXX();
    BindClick("CKCFTDCWLX");
    BindClick("QY");
    BindClick("SQ");
    BindClick("ZJDW");
});
//房屋描述框focus
function FYMSFocus() {
    $("#FYMS").css("color", "#333333");
}
//房屋描述框blur
function FYMSBlur() {
    $("#FYMS").css("color", "#999999");
}
//房屋描述框设默认文本
function FYMSSetDefault() {
    var fyms = "1.房屋特征：\r\n\r\n2.周边配套：\r\n\r\n3.房东心态：";
    $("#FYMS").html(fyms);
}
//加载默认
function LoadDefault() {
    ue.ready(function () {
        ue.setHeight(200);
    });
    $(".img_radio").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择出租
function CZSelect() {
    $("#divZJ").css("display", "block");
    $("#divSJ").css("display", "none");
}
//选择出售
function CSSelect() {
    $("#divZJ").css("display", "none");
    $("#divSJ").css("display", "block");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "CKCFTDCWLX") {
            LoadCKCFTDCWLX();
        }
        if (type === "ZJDW") {
            LoadZJDW();
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "SQ") {
            LoadSQ();
        }
    });
}
//加载类型
function LoadCKCFTDCWLX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "不动产其他类型",
            TBName: "CODES_FC"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ul_select' style='overflow-y: none;height:138px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectDropdown(this,\"CKCFTDCWLX\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divCKCFTDCWLX").html(html);
                $("#divCKCFTDCWLX").css("display", "block");
                ActiveStyle("CKCFTDCWLX");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择区域下拉框
function SelectQY(obj, type, code) {
    $("#QYCode").val(code);
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
}
//加载租金单位
function LoadZJDW() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "不动产其他类型租金单位",
            TBName: "CODES_FC"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ul_select' style='overflow-y: none;height:70px;margin-left:-1px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectDropdown(this,\"ZJDW\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divZJDW").html(html);
                $("#divZJDW").css("display", "block");
                ActiveStyle("ZJDW");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//设置供求
function SetGQ(gq) {
    if (gq === 0) {
        $("#divZJ").css("display", "block");
        $("#divSJ").css("display", "none");
    }
    else {
        $("#divZJ").css("display", "none");
        $("#divSJ").css("display", "block");
    }
}
//加载房产_写字楼基本信息
function LoadFC_CKCFTDCWJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC_CKCFTDCW/LoadFC_CKCFTDCWJBXX",
        dataType: "json",
        data:
        {
            FC_CKCFTDCWJBXXID: getUrlParam("FC_CKCFTDCWJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.FC_CKCFTDCWJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#FC_CKCFTDCWJBXXID").val(xml.Value.FC_CKCFTDCWJBXX.FC_CKCFTDCWJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                if (xml.Value.FC_CKCFTDCWJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.FC_CKCFTDCWJBXX.GQ);
                $("#spanCKCFTDCWLX").html(xml.Value.FC_CKCFTDCWJBXX.LX);
                $("#spanKZCGS").html(xml.Value.FC_CKCFTDCWJBXX.KZCGS);
                $("#spanQY").html(xml.Value.FC_CKCFTDCWJBXX.QY);
                $("#spanSQ").html(xml.Value.FC_CKCFTDCWJBXX.SQ);
                $("#spanZJDW").html(xml.Value.FC_CKCFTDCWJBXX.ZJDW);
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
    obj = jsonObj.AddJson(obj, "LX", "'" + $("#spanCKCFTDCWLX").html() + "'");
    obj = jsonObj.AddJson(obj, "KZCGS", "'" + $("#spanKZCGS").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "SQ", "'" + $("#spanSQ").html() + "'");
    obj = jsonObj.AddJson(obj, "ZJDW", "'" + $("#spanZJDW").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if (getUrlParam("FC_CKCFTDCWJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "FC_CKCFTDCWJBXXID", "'" + getUrlParam("FC_CKCFTDCWJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC_CKCFTDCW/FB",
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