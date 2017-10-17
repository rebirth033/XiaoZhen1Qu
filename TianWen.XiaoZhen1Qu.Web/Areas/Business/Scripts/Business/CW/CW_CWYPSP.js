var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#imgZR").bind("click", ZRSelect);
    $("#imgQG").bind("click", QGSelect);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qCWYPSPs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);
    LoadTXXX();
    LoadDefault();
    LoadCW_CWYPSPJBXX();
    BindClick("LB");
    BindClick("XJ");
});
//描述框focus
function FYMSFocus() {
    $("#FYMS").css("color", "#333333");
}
//描述框blur
function FYMSBlur() {
    $("#FYMS").css("color", "#999999");
}
//描述框设默认文本
function FYMSSetDefault() {
    var fyms = "1.房屋特征：\r\n\r\n2.周边配套：\r\n\r\n3.房东心态：";
    $("#FYMS").html(fyms);
}
//加载默认
function LoadDefault() {
    ue.ready(function () {
        ue.setHeight(200);
    });
    $("#imgZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgQG").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择转让
function ZRSelect() {
    $("#imgZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgQG").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择求购
function QGSelect() {
    $("#imgZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgQG").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}
//获取供求
function GetGQ() {
    if ($("#imgZR").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置供求
function SetGQ(GQ) {
    if (GQ === 0) {
        $("#imgZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgQG").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    }
    else {
        $("#imgZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgQG").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    }
}
//加载类别
function LoadLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_CW",
        dataType: "json",
        data:
        {
            TYPENAME: "宠物用品/食品"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"LB\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divLB").html(html);
                $("#divLB").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载小类
function LoadXL() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: $("#LBID").val(),
            TBName: "CODES_CW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"XL\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divXL").html(html);
                $("#divXL").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载新旧
function LoadXJ() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_CW",
        dataType: "json",
        data:
        {
            TYPENAME: "新旧"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"XJ\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divXJ").html(html);
                $("#divXJ").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择类别下拉框
function SelectLB(obj, type, id) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#LBID").val(id);
    PDLB(obj.innerHTML);
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadLB();
        }
        if (type === "XL") {
            LoadXL();
        }
        if (type === "XJ") {
            LoadXJ();
        }
    });
}
//判断类别
function PDLB(LB) {
    if (LB === "狗用品" || LB === "猫用品") {
        $("#divXLText").css("display", "");
        BindClick("XL");
    }
    else {
        $("#divXLText").css("display", "none");
    }
}
//加载宠物_宠物用品/食品基本信息
function LoadCW_CWYPSPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CW_CWYPSP/LoadCW_CWYPSPJBXX",
        dataType: "json",
        data:
        {
            CW_CWYPSPJBXXID: getUrlParam("CW_CWYPSPJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CW_CWYPSPJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#CW_CWYPSPJBXXID").val(xml.Value.CW_CWYPSPJBXX.CW_CWYPSPJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.CW_CWYPSPJBXX.BCMS);
                });
                $("#spanLB").html(xml.Value.CW_CWYPSPJBXX.LB);
                $("#spanXJ").html(xml.Value.CW_CWYPSPJBXX.XJ);
                SetGQ(xml.Value.CW_CWYPSPJBXX.GQ);
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
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "XJ", "'" + $("#spanXJ").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetGQ() + "'");

    if (getUrlParam("CW_CWYPSPJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "CW_CWYPSPJBXXID", "'" + getUrlParam("CW_CWYPSPJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CW_CWYPSP/FB",
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