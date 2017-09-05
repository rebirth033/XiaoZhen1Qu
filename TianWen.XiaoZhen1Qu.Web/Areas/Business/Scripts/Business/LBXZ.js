$(document).ready(function () {
    LoadDL();
});

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
            _masker.CloseMasker(false, errorThrown);
        }
    });
}

function LoadXL(LBID, LBNAME) {
    $("#spanXZDL").css("color", "#cccccc");
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
                if (LBNAME === "二手物品" || LBNAME === "生活服务") {
                    for (var i = 0; i < xml.list.length; i++) {
                        if (xml.list[i].XXLBS.length > 5)
                            trhtml = "<tr><td class=\"LBFirst\">" + xml.list[i].LBNAME + "</td>";
                        else
                            trhtml = "<tr class=\"trXL\"><td class=\"LBFirst\">" + xml.list[i].LBNAME + "</td>";
                        for (var j = 0; j < xml.list[i].XXLBS.length; j++) {
                            if (j === 5) {
                                trhtml = "<tr class=\"trXL\"><td class=\"LBFirst\"></td>";
                                continue;
                            }
                            trhtml += "<td class=\"LB\" onclick=\"FBXX('" + xml.list[i].XXLBS[j].FBYM + "','" + xml.list[i].XXLBS[j].LBID + "')\">" + xml.list[i].XXLBS[j].LBNAME + "</td>";
                            if (j === 4 && j !== (xml.list[i].XXLBS.length - 1)) {
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
            _masker.CloseMasker(false, errorThrown);
        }
    });
}

function FBXX(FBYM, LBID) {
    window.location.href = getRootPath() + "/Business/" + FBYM + "/" + FBYM + "?CLICKID=" + LBID + "&YHID=" + getUrlParam("YHID");
}