$(document).ready(function () {
    $(".div_head").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    $(".div_body").css("margin-left", (document.documentElement.clientWidth - 1200) / 2);
    LoadDefault();
});
//加载默认
function LoadDefault() {
    document.title = "信息小镇_切换城市";
    //LoadCitys();
}
//加载城市
function LoadCitys() {
    var array = "A,F,G,H,J,L,N,Q,S,X,Y,Z";
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/GetDistrictByGrade",
        dataType: "json",
        data:
        {
            Grade: "省级','市级"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var result = "";
                for (var j = 0; j < array.length; j++) {
                    for (var i = 0; i < xml.list.length; i++) {
                        if (xml.list[i].CODEVALUE === array[j] && xml.list[i].TYPENAME === "省级") {
                            result += '<div class="div_row"><span class="span_zm">' + array[j] + '</span><span class="span_sf">' + xml.list[i].CODENAME + '</span>';
                            for (var k = 0; k < xml.list.length; k++) {
                                if (xml.list[k].PARENTID === xml.list[i].CODEID)
                                    result += '<span class="span_cs" onclick="SelectCity(\'' + xml.list[k].CODEID + '\',\'' + xml.list[k].CODENAME + '\')">' + xml.list[k].CODENAME + '</span>';
                            }

                            result += '</div>';
                        }
                    }
                }
                $("#div_body_middle").html(result);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择城市
function SelectCity(codeid, codename) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/QHXZQ",
        dataType: "json",
        data:
        {
            XZQ: codename,
            XZQDM: codeid
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.location.href = getRootPath() + "/SY/SY";
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择字母
function SelectZM(zm) {
    $(".span_zm").each(function () {
        $(this).css("background-color", "#bc6ba6");
    });
    $(".span_zm").each(function () {
        if (this.innerHTML === zm)
            $(this).css("background-color", "#ad5b97");
    });
}
