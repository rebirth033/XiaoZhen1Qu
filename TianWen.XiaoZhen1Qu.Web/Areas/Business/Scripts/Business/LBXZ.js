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
                    trhtml += "<td class=\"DL\" onclick=\"LoadXL('" + xml.list[i].CODEID + "','" + xml.list[i].CODENAME + "')\">" + xml.list[i].CODENAME + "</td>";
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

function LoadXL(CODEID, CODENAME) {
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
            CODEID: CODEID
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var XLhtml = "", trhtml = "";
                if (CODENAME === "二手物品" || CODENAME === "房产" || CODENAME === "车辆" || CODENAME === "生活服务") {
                    for (var i = 0; i < xml.list.length; i++) {
                        if (xml.list[i]._CODES.length > 5)
                            trhtml = "<tr><td class=\"DLFirst\">" + xml.list[i].CODENAME + "</td>";
                        else
                            trhtml = "<tr class=\"trXL\"><td class=\"DLFirst\">" + xml.list[i].CODENAME + "</td>";
                        for (var j = 0; j < xml.list[i]._CODES.length; j++) {
                            if (j === 5) {
                                trhtml = "<tr class=\"trXL\"><td class=\"DLFirst\"></td>";
                                continue;
                            }
                            trhtml += "<td class=\"DL\">" + xml.list[i]._CODES[j].CODENAME + "</td>";
                            if (j === 4 && j !== (xml.list[i]._CODES.length - 1)) {
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
                        trhtml += "<td class=\"DL\" onclick=\"LoadXL('" + xml.list[i].CODEVALUE + "')\">" + xml.list[i].CODENAME + "</td>";
                        if ((i + 1) % 6 === 0 || (i + 1) === xml.list.length) {
                            for (var j = 0; j < (6 - i - 1) ; j++)
                                trhtml += "<td class=\"DL\"></td>";
                            trhtml += "</tr>";
                            XLhtml += trhtml;
                        }
                    }
                }
                $("#tableXL").html(XLhtml);
                $("#divXL").css("display", "block");
                $("#spanXZDL").html(CODENAME);
                $("#divXLText").html("选择" + CODENAME + "小类");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            _masker.CloseMasker(false, errorThrown);
        }
    });
}