$(document).ready(function () {
    $("#spanXZDL").css("color", "#5bc0de");
    $("#emXZDL").css("background", "#5bc0de");
    LoadDL();
});

function LoadDL() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LBXZ/LoadDL",
        dataType: "json",
        data:
        {

        },
        success: function (xml) {
            if (xml.Result === 1) {
                var DLhtml = "",trhtml = "";
                for (var i = 0; i < xml.list.length; i++) {
                    if(i % 6 === 0 || i === 0)
                        trhtml = "<tr>";
                    trhtml += "<td class=\"DL\" onclick=\"LoadXL('" + xml.list[i].CODEID + "')\">" + xml.list[i].CODENAME + "</td>";
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

function LoadXL(CODEID) {
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
                for (var i = 0; i < xml.list.length; i++) {
                    if (i % 6 === 0 || i === 0)
                        trhtml = "<tr>";
                    trhtml += "<td class=\"DL\" onclick=\"LoadXL('" + xml.list[i].CODEVALUE + "')\">" + xml.list[i].CODENAME + "</td>";
                    if ((i + 1) % 6 === 0 || (i+1) === xml.list.length) {
                        trhtml += "</tr>";
                        XLhtml += trhtml;
                    }
                }
                $("#tableXL").html(XLhtml);
                $("#divXL").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数
            _masker.CloseMasker(false, errorThrown);
        }
    });
}