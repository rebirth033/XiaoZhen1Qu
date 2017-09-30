var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qCWFWs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });
    $("#div_top_right_inner_yhm").bind("mouseover", ShowYHCD);
    $("#div_top_right_inner_yhm").bind("mouseleave", HideYHCD);
    LoadTXXX();
    LoadDZYQJLB();
    LoadDefault();
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
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
}
//加载电子元器件类别
function LoadDZYQJLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_PFCG",
        dataType: "json",
        data:
        {
            TYPENAME: "电子元器件"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liFWPZ' onclick='SelectDZYQJLB(this)'><img class='img_DZYQJLB'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 4 || i === 11 || i === 17 || i === 23 || i === 29) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divDZYQJLBText").html(html);
                $(".img_DZYQJLB").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadPFCG_DZYQJJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择房屋配置
function SelectDZYQJLB(obj) {
    if ($(obj).find("img").attr("src").indexOf("blue") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadLB();
        }
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
        url: getRootPath() + "/Business/PFCG_DZYQJ/LoadPFCG_DZYQJJBXX",
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
                    ue.setContent(xml.Value.PFCG_DZYQJJBXX.BCMS);
                });
                SetDZYQJLB(xml.Value.PFCG_DZYQJJBXX.LB);
                $("#spanQY").html(xml.Value.PFCG_DZYQJJBXX.QY);
                $("#spanDD").html(xml.Value.PFCG_DZYQJJBXX.DD);
                LoadPhotos(xml.Value.Photos);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//获取电子元器件类别
function GetDZYQJLB() {
    var DZYQJLB = "";
    $(".liFWPZ").each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            DZYQJLB += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(DZYQJLB, ',');
}
//设置电子元器件类别
function SetDZYQJLB(lbs) {
    var lbarray = lbs.split(',');
    for (var i = 0; i < lbarray.length; i++) {
        $(".liFWPZ").each(function () {
            if ($(this).find("label")[0].innerHTML.indexOf(lbarray[i]) !== -1)
                $(this).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
        });
    }

}
//发布
function FB() {
    if (AllValidate() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "LB", "'" + GetDZYQJLB() + "'");

    if (getUrlParam("PFCG_DZYQJJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "PFCG_DZYQJJBXXID", "'" + getUrlParam("PFCG_DZYQJJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/PFCG_DZYQJ/FB",
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