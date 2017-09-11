var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 900) / 2);
    $(".div_head").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $(".div_content").css("margin-left", (document.documentElement.clientWidth - 900) / 2);
    $("#spanCXLB").bind("click", CXLB);
    $("#imgCZ").bind("click", CZSelect);
    $("#imgCS").bind("click", CSSelect);
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qhcs").bind("click", LoadXZQByGrade);
    $("body").bind("click", CloseXZQ);
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);

    LoadTXXX();
    LoadCKCFTDCWLX();
    LoadQY();
    LoadZJDW();
    LoadDefault();
    LoadFC_CKCFTDCWJBXX();
    BindHover("CKCFTDCWLX");
    BindHover("QY");
    BindHover("SQ");
    BindHover("ZJDW");
    //FYMSSetDefault();
});
//显示用户菜单
function ShowYHCD() {
    $("#div_top_right_dropdown_yhm").css("display", "block");
    $("#span_top_right_yhm_img").css("background-image", 'url(' + getRootPath() + "/Areas/Business/Css/images/arrow_up.png" + ')');
}
//隐藏用户菜单
function HideYHCD() {
    $("#div_top_right_dropdown_yhm").css("display", "none");
    $("#span_top_right_yhm_img").css("background-image", 'url(' + getRootPath() + "/Areas/Business/Css/images/arrow_down.png" + ')');
}
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
    $("#imgSPZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSYZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgCS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//加载类别信息
function LoadTXXX() {
    $("#spanTXXX").css("color", "#5bc0de");
    $("#emTXXX").css("background", "#5bc0de");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LBXZ/LoadLBByID",
        dataType: "json",
        data:
        {
            LBID: getUrlParam("CLICKID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                if (xml.list.length > 0)
                    $("#spanLBXZ").html("1." + xml.list[0].LBNAME);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//重选类别
function CXLB() {
    window.location.href = getRootPath() + "/Business/LBXZ/LBXZ";
}
//选择出租
function CZSelect() {
    $("#imgCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgCS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#divZJ").css("display", "block");
    $("#divSJ").css("display", "none");
}
//选择出售
function CSSelect() {
    $("#imgCS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#divZJ").css("display", "none");
    $("#divSJ").css("display", "block");
}
//加载类型
function LoadCKCFTDCWLX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES",
        dataType: "json",
        data:
        {
            TYPENAME: "不动产其它类型"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: none;height:138px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"CKCFTDCWLX\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divCKCFTDCWLX").html(html);
                $("#divCKCFTDCWLX").css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载区域
function LoadQY() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadQY",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectQY(this,\"QY\",\"" + xml.list[i].CODE + "\")'>" + RTrim(RTrim(RTrim(xml.list[i].NAME, '市'), '区'), '县') + "</li>";
                }
                html += "</ul>";
                $("#divQY").html(html);
                $("#divQY").css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载商圈
function LoadSQ(QY) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadSQ",
        dataType: "json",
        data:
        {
            QY: QY
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"SQ\")'>" + RTrimStr(xml.list[i].NAME, '街道,镇,林场,管理处') + "</li>";
                }
                html += "</ul>";
                $("#divSQ").html(html);
                $("#divSQ").css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载租金单位
function LoadZJDW() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES",
        dataType: "json",
        data:
        {
            TYPENAME: "不动产其它类型租金单位"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: none;height:70px;margin-left:-1px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"ZJDW\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divZJDW").html(html);
                $("#divZJDW").css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//鼠标盘旋样式
function HoverStyle(name) {
    $("#div" + name + "Text").css("border-top", "1px solid #5bc0de").css("border-right", "1px solid #5bc0de").css("border-left", "1px solid #5bc0de").css("border-bottom", "1px solid #5bc0de");
    $("#div" + name).find("ul").css("border-left", "1px solid #5bc0de").css("border-right", "1px solid #5bc0de").css("border-bottom", "1px solid #5bc0de");
    $("#span" + name).css("color", "#333333");
}
//鼠标离开样式
function LeaveStyle(name) {
    $("#div" + name + "Text").css("border-top", "1px solid #cccccc").css("border-right", "1px solid #cccccc").css("border-left", "1px solid #cccccc").css("border-bottom", "1px solid #cccccc");
    $("#div" + name).find("ul").css("border-left", "1px solid #cccccc").css("border-right", "1px solid #cccccc").css("border-bottom", "1px solid #cccccc");
    $("#span" + name).css("color", "#999999");
}
//绑定下拉框鼠标盘旋样式
function BindHover(type) {
    $("#div" + type + "Text").hover(function () {
        $("#div" + type).css("display", "block");
        HoverStyle(type);
    }, function () {
        $("#div" + type).css("display", "none");
        LeaveStyle(type);
    });
    $("#div" + type).hover(function () {
        $("#div" + type).css("display", "block");
        HoverStyle(type);
    }, function () {
        $("#div" + type).css("display", "none");
        LeaveStyle(type);
    });
}
//选择下拉框
function SelectDropdown(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
}
//选择区域下拉框
function SelectQY(obj, type, code) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadSQ(code);
}
//获取供求
function GetGQ() {
    if ($("#imgCZ").attr("src").indexOf("blue") !== -1)
        return "0";
    else
        return "1";
}
//设置供求
function SetGQ(gq) {
    if (gq === 0) {
        $("#imgCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
        $("#imgCS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#divZJ").css("display", "block");
        $("#divSJ").css("display", "none");
    }
    else {
        $("#imgCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
        $("#imgCS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
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
                    ue.setContent(xml.Value.FC_CKCFTDCWJBXX.BCMS);
                });
                SetGQ(xml.Value.FC_CKCFTDCWJBXX.GQ);
                $("#spanCKCFTDCWLX").html(xml.Value.FC_CKCFTDCWJBXX.CKCFTDCWLX);
                $("#spanKZCGS").html(xml.Value.FC_CKCFTDCWJBXX.KZCGS);
                $("#spanQY").html(xml.Value.FC_CKCFTDCWJBXX.QY);
                $("#spanSQ").html(xml.Value.FC_CKCFTDCWJBXX.SQ);
                $("#spanZJDW").html(xml.Value.FC_CKCFTDCWJBXX.ZJDW);
                LoadPhotos(xml.Value.Photos);
                return;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//鼠标经过
function MouseOver() {
    isleave = false;
}
//鼠标离开
function MouseLeave() {
    isleave = true;
}
//发布
function FB() {
    if (AllValidate() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "CKCFTDCWLX", "'" + $("#spanCKCFTDCWLX").html() + "'");
    obj = jsonObj.AddJson(obj, "KZCGS", "'" + $("#spanKZCGS").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "SQ", "'" + $("#spanSQ").html() + "'");
    obj = jsonObj.AddJson(obj, "ZJDW", "'" + $("#spanZJDW").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetGQ() + "'");

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