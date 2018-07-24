var ue = UE.getEditor('BCMS');
var BQArray = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z".split(',');
$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 940) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 940) / 2);
    $(".div_head").css("margin-left", (document.documentElement.clientWidth - 940) / 2);
    $(".div_content").css("margin-left", (document.documentElement.clientWidth - 940) / 2);
    $(".div_body_yhdl").css("margin-left", (document.documentElement.clientWidth - 460) / 2);
    $(".div_radio").bind("click", RadioSelect);
    $(".img_radio").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);
    $("#div_upload").bind("mouseover", GetUploadCss);
    $("#div_upload").bind("mouseleave", LeaveUploadCss);
    $("#input_upload").bind("change", UploadZP);
    $("#spanCXLB").bind("click", CXLB);
    $("#btnFB").bind("click", FB);
    $("#span_content_info_qCWFWs").bind("click", LoadXZQByGrade);
    $("#btnClose").bind("click", CloseWindow);
    $("#aWJMM").attr("href", getRootPath() + "/ZHMM/ZHMM");
    $("#aYHZC1").attr("href", getRootPath() + "/YHJBXX/YHJBXX");
    $("body").bind("click", function () { CloseByClassID("div_select_dropdown"); CloseByClassID("div_bqss"); });//所有下拉框在点击别处时应该自动收缩
    LoadDefault();
    LoadTXXX();
});
//加载默认
function LoadDefault() {
    ue.ready(function () { ue.setHeight(200); });
    if ($("#span_top_right_yhm_text").html() === "") {
        $(".div_shadow").css("display", "block");
        $(".div_body_yhdl").css("display", "block");
    }
}
//根据TYPENAME获取字典表
function LoadCODESByTYPENAME(type, id, table, callback, idout, idin, message) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: type,
            TBName: table
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var height = 341;
                if (xml.list.length < 10)
                    height = parseInt(xml.list.length * 34) + 1;
                var html = "<ul class='ul_select' style='overflow-y: scroll; height:" + height + "px'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectLB(this,\"" + id + "\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#div" + id).html(html);
                $("#div" + id).css("display", "block");
                ActiveStyle(id);
                if (callback !== undefined)
                    callback(idout, idin, message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//根据名称加载小类
function LoadXLByName(lb, xl, tbname) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: lb,
            TBName: tbname
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liXL' style='width:120px' onclick='SelectDuoX(this)'><img class='img_XL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                   if (i % 5 === 4 && i != xml.list.length - 1) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 173px'>";
                    }
                }
                if (parseInt(xml.list.length % 5) === 0)
                    $("#divXL").css("height", parseInt(xml.list.length / 5) * 60 + "px");
                else
                    $("#divXL").css("height", (parseInt(xml.list.length / 5) + 1) * 60 + "px");
                html += "</ul>";
                $("#divXLText").html(html);
                $(".img_XL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liXL").bind("click", function () { ValidateCheck("XL", "忘记选择小类啦"); });
                $("#divXL").css("display", "");
                SetDuoX("XL", xl);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择类别下拉框
function SelectLB(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LeaveStyle(type);
}
//选择下拉框
function SelectDropdown(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
}
//绑定下拉框
function Bind(idout, idin, message) {
    $("#div" + idout).find(".li_select").bind("click", function () { ValidateSelect(idout, idin, message); });
}
//加载填写信息
function LoadTXXX() {
    $("#spanTXXX").css("color", "#bc6ba6");
    $("#emTXXX").css("background", "#bc6ba6");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/LBXZ/LoadLBByID",
        dataType: "json",
        data:
        {
            LBID: getUrlParam("CLICKID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                if (xml.list.length > 0) {
                    $("#spanLBXZ").html("1." + xml.list[0].LBNAME);
                    document.title = "风铃网_发布" + $("#span_content_info_xzq").html() + xml.list[0].LBNAME + "信息";
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载服务范围
function LoadFWFW() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/GetDistrictXQJByXZQDM",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liFWFW' onclick='SelectDuoX(this)'><img class='img_FWFW'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 6 === 5 && i != xml.list.length - 1) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 173px'>";
                    }
                }
                if (parseInt(xml.list.length % 6) === 0)
                    $("#divFWFW").css("height", parseInt(xml.list.length / 6) * 45 + "px");
                else
                    $("#divFWFW").css("height", (parseInt(xml.list.length / 6) + 1) * 45 + "px");
                html += "</ul>";
                $("#divFWFWText").html(html);
                $(".img_FWFW").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liFWFW").bind("click", function () { ValidateCheck("FWFW", "忘记选择服务范围啦"); });
                LoadJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}