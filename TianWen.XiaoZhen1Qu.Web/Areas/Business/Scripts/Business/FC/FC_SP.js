var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#spanCXLB").bind("click", CXLB);
    $("#imgSPZS").bind("click", SPZSSelect);
    $("#imgSYZR").bind("click", SYZRSelect);
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

    LoadTXXX();
    BindHover("SPLX");
    BindHover("QY");
    BindHover("SQ");
    LoadSPLX();
    LoadQY();
    LoadZJDW();
    LoadDefault();
    LoadFC_SPJBXX();
    //FYMSSetDefault();
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
    $("#imgSPZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSYZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgCS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//加载图形信息
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
//选择商铺租售
function SPZSSelect() {
    $("#imgSPZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgSYZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择生意转让
function SYZRSelect() {
    $("#imgSPZS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgSYZR").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}
//选择出租
function CZSelect() {
    $("#imgCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgCS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择出售
function CSSelect() {
    $("#imgCS").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//加载商铺类型
function LoadSPLX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC_FW/LoadCODES",
        dataType: "json",
        data:
        {
            TYPENAME: "商铺类型"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"SPLX\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divSPLX").html(html);
                $("#divSPLX").css("display", "none");
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
        url: getRootPath() + "/Business/FC_SP/LoadQY",
        dataType: "json",
        data:
        {
            
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"QY\")'>" + RTrim(RTrim(RTrim(xml.list[i].NAME, '市'), '区'), '县') + "</li>";
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
        url: getRootPath() + "/Business/FC_SP/LoadSQ",
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
        url: getRootPath() + "/Business/FC_FW/LoadCODES",
        dataType: "json",
        data:
        {
            TYPENAME: "租金单位"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: none;height:70px;margin-left:-1px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectZJDW(this)'>" + xml.list[i].CODENAME + "</li>";
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
    if (type === "QY")
        LoadSQ(obj.innerHTML);
}

function GetDX(type) {
    var result = "";
    $("#div" + type + "Text").find("li").each(function (i) {
        if ($(this).css("color") !== "rgb(51, 51, 51)")
            result += i + ",";
    });
    return result.substr(0, result.length - 1);
}

function SetDX(type, value) {
    var result = "";
    var values = value.split(',');
    $("#div" + type + "Text").find("li").each(function (i) {
        if (values.contains(i))
            $(this).css("color", "#5bc0de");
    });
    return result.substr(0, result.length - 1);
}

function GetFL() {
    if ($("#imgSPCZ").css("background-position") === "-67px -57px")
        return "0";
    else
        return "1";
}

function SetFL(SPCZ) {
    if (SPCZ === 0) {
        $("#imgSPCZ").css("background-position", "-67px -57px");
        $("#imgSYZR").css("background-position", "-67px 0px");
    }
    else {
        $("#imgSPCZ").css("background-position", "-67px 0px");
        $("#imgSYZR").css("background-position", "-67px -57px");
    }
}
//加载房产_商铺基本信息
function LoadFC_SPJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC_DZF/LoadFC_DZFJBXX",
        dataType: "json",
        data:
        {
            FC_DZFJBXXID: getUrlParam("FC_DZFJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.FC_DZFJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#FC_DZFJBXXID").val(xml.Value.FC_DZFJBXX.FC_DZFJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.FC_DZFJBXX.FYMS);
                });
                //SetCZFS(xml.Value.FWCZXX.CZFS);
                $("#spanFWLX").html(xml.Value.FC_DZFJBXX.FWLX);
                $("#spanZJDW").html(xml.Value.FC_DZFJBXX.ZJDW);
                $("#JYGZ").html(xml.Value.FC_DZFJBXX.JYGZ);
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
    obj = jsonObj.AddJson(obj, "FWLX", "'" + $("#spanFWLX").html() + "'");
    obj = jsonObj.AddJson(obj, "ZJDW", "'" + $("#spanZJDW").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("FC_DZFJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "FC_DZFJBXXID", "'" + getUrlParam("FC_DZFJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC_DZF/FB",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            FYMS: ue.getContent(),
            FWZP: GetPhotoUrls(),
            JYGZ: $("#JYGZ").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.location.href = getRootPath() + "/Business/FBCG/FBCG";
            } else {
                if (xml.Type === 1) {
                    $("#YZM").css("border-color", "#F2272D");
                    $("#YZMInfo").css("color", "#F2272D");
                    $("#YZMInfo").html(xml.Message);
                }
                if (xml.Type === 2) {
                    $("#YHM").css("border-color", "#F2272D");
                    $("#YHMInfo").css("color", "#F2272D");
                    $("#YHMInfo").html(xml.Message);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}