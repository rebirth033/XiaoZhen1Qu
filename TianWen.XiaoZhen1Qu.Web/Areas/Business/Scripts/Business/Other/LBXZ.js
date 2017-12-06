$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 940) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 940) / 2);
    $(".div_head").css("margin-left", (document.documentElement.clientWidth - 940) / 2);
    $(".div_content").css("margin-left", (document.documentElement.clientWidth - 940) / 2);
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);
    $("#title").html("信息小镇_发布信息");
    LoadDL();
});
//加载大类
function LoadDL() {
    $("#spanXZDL").css("color", "#5bc0de");
    $("#emXZDL").css("background", "#5bc0de");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LBXZ/LoadDL",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                var DLhtml = "", trhtml = "";
                for (var i = 0; i < xml.list.length; i++) {
                    if (i % 6 === 0 || i === 0)
                        trhtml = "<tr>";
                    trhtml += "<td class=\"LB\" onclick=\"LoadXL('" + xml.list[i].LBID + "','" + xml.list[i].LBNAME + "')\">" + xml.list[i].LBNAME + "</td>";
                    if ((i + 1) % 6 === 0 || (i + 1) === xml.list.length) {
                        trhtml += "</tr>";
                        DLhtml += trhtml;
                    }
                }
                $("#tableDL").html(DLhtml);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            
        }
    });
}
//加载小类
function LoadXL(LBID, LBNAME) {
    $("#spanXZDL").css("color", "#333333");
    $("#emXZDL").css("background", "#cccccc");
    $("#spanXZXL").css("color", "#5bc0de");
    $("#emXZXL").css("background", "#5bc0de");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LBXZ/LoadXL",
        dataType: "json",
        data:
        {
            LBID: LBID
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var XLhtml = "", trhtml = "";
                if (LBNAME === "二手" || LBNAME === "生活服务" || LBNAME === "商务服务" || LBNAME === "车辆") {
                    for (var i = 0; i < xml.list.length; i++) {
                        if (xml.list[i].CODES_XXLBS.length > 5)
                            trhtml = "<tr><td class=\"LBFirst\">" + xml.list[i].LBNAME + "</td>";
                        else
                            trhtml = "<tr class=\"trXL\"><td class=\"LBFirst\">" + xml.list[i].LBNAME + "</td>";
                        for (var j = 0; j < xml.list[i].CODES_XXLBS.length; j++) {
                            if (j === 5) {
                                trhtml = "<tr class=\"trXL\"><td class=\"LBFirst\"></td>";
                            }
                            trhtml += "<td class=\"LB\" onclick=\"FBXX('" + xml.list[i].CODES_XXLBS[j].FBYM + "','" + xml.list[i].CODES_XXLBS[j].LBID + "')\">" + xml.list[i].CODES_XXLBS[j].LBNAME + "</td>";
                            if (j === 4 && j !== (xml.list[i].CODES_XXLBS.length - 1)) {
                                trhtml += "</tr>";
                                XLhtml += trhtml;
                            }
                        }
                        trhtml += "</tr>";
                        XLhtml += trhtml;
                    }
                } else {
                    for (var i = 0; i < xml.list.length; i++) {
                        if (i % 6 === 0 || i === 0)
                            trhtml = "<tr>";
                        trhtml += "<td class=\"LB\" onclick=\"FBXX('" + xml.list[i].FBYM + "','" + xml.list[i].LBID + "')\">" + xml.list[i].LBNAME + "</td>";
                        if ((i + 1) % 6 === 0 || (i + 1) === xml.list.length) {
                            for (var j = 0; j < (6 - i - 1) ; j++)
                                trhtml += "<td class=\"LB\"></td>";
                            trhtml += "</tr>";
                            XLhtml += trhtml;
                        }
                    }
                }
                $("#tableXL").html(XLhtml);
                $("#divXL").css("display", "block");
                $("#spanXZDL").html("1." + LBNAME);
                $("#divXLText").html("2.选择" + LBNAME + "小类");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            
        }
    });
}
//发布信息
function FBXX(FBYM, LBID) {
    window.location.href = getRootPath() + "/Business/" + FBYM.split('_')[0] + "/" + FBYM + "?CLICKID=" + LBID;
}
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
//显示我的信息
function ShowWDXX() {
    $("#liWDXX").css("font-size", "18px").css("font-weight", "700");
    $("#liWDZH").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZJ").css("font-size", "16px").css("font-weight", "normal");
    $("#liSHGJ").css("font-size", "16px").css("font-weight", "normal");
    $("#ulWDXX").css("display", "block");
    $("#ulWDZH").css("display", "block");
    $("#ulWDZJ").css("display", "block");
    $("#ulSHGJ").css("display", "block");
    ToWDFB();
}
//显示我的账户
function ShowWDZH() {
    $("#liWDXX").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZH").css("font-size", "18px").css("font-weight", "700");
    $("#liWDZJ").css("font-size", "16px").css("font-weight", "normal");
    $("#liSHGJ").css("font-size", "16px").css("font-weight", "normal");
    $("#ulWDXX").css("display", "none");
    $("#ulWDZH").css("display", "block");
    $("#ulWDZJ").css("display", "block");
    $("#ulSHGJ").css("display", "block");
    ToGRZL();
}
//显示我的资金
function ShowWDZJ() {
    $("#liWDXX").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZH").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZJ").css("font-size", "18px").css("font-weight", "700");
    $("#liSHGJ").css("font-size", "16px").css("font-weight", "normal");
    $("#ulWDXX").css("display", "none");
    $("#ulWDZH").css("display", "none");
    $("#ulWDZJ").css("display", "block");
    $("#ulSHGJ").css("display", "block");
    ToXJMXCX();
}
//显示生活工具
function ShowSHGJ() {
    $("#liWDXX").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZH").css("font-size", "16px").css("font-weight", "normal");
    $("#liWDZJ").css("font-size", "16px").css("font-weight", "normal");
    $("#liSHGJ").css("font-size", "18px").css("font-weight", "700");
    $("#ulWDXX").css("display", "none");
    $("#ulWDZH").css("display", "none");
    $("#ulWDZJ").css("display", "none");
    $("#ulSHGJ").css("display", "block");
    ToHFCZ();
}
//退出
function Exit() {
    window.location.href = getRootPath() + "/Business/YHDL/YHDL";
}
//我的发布
function ToWDFB() {
    window.location.href = getRootPath() + "/Business/HTGL/HTGL";
}
//个人资料
function ToGRZL() {
    window.location.href = getRootPath() + "/Business/HTGL/HTGL";
}
//话费充值
function ToHFCZ() {
    window.location.href = getRootPath() + "/Business/HTGL/HTGL";
}