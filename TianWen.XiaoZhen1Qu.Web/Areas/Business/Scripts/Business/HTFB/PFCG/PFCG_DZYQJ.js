$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadDuoX("电子元器件", "DZYQJLB");
    BindClick("QY");
    BindClick("DD");
});
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: type,
            TBName: "CODES_PFCG"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' style='width:140px' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i % 4 === 3) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#div" + id).css("height", parseInt(xml.list.length / 4) * 45 + "px");
                else
                    $("#div" + id).css("height", (parseInt(xml.list.length / 4) + 1) * 45 + "px");
                html += "</ul>";
                $("#div" + id + "Text").html(html);
                $(".img_" + id).attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                $(".liDZYQJLB").bind("click", function () { ValidateCheck("DZYQJLB", "忘记选择类别啦"); });
                LoadPFCG_DZYQJJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载批发采购_电子元器件基本信息
function LoadPFCG_DZYQJJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PFCG/LoadPFCG_DZYQJJBXX",
        dataType: "json",
        data:
        {
            PFCG_DZYQJJBXXID: getUrlParam("PFCG_DZYQJJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.PFCG_DZYQJJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#PFCG_DZYQJJBXXID").val(xml.Value.PFCG_DZYQJJBXX.PFCG_DZYQJJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                SetDuoX("DZYQJLB", xml.Value.PFCG_DZYQJJBXX.LB);
                $("#spanQY").html(xml.Value.PFCG_DZYQJJBXX.QY);
                $("#spanDD").html(xml.Value.PFCG_DZYQJJBXX.DD);
                LoadPhotos(xml.Value.Photos);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//发布
function FB() {
    if (ValidateAll() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDuoX("DZYQJLB") + "'");

    if (getUrlParam("PFCG_DZYQJJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "PFCG_DZYQJJBXXID", "'" + getUrlParam("PFCG_DZYQJJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PFCG/FBPFCG_DZYQJJBXX",
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