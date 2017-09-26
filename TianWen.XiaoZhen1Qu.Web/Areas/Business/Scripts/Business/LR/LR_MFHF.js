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
    LoadMFHFLB();
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
//加载美发护发类别
function LoadMFHFLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_LR",
        dataType: "json",
        data:
        {
            TYPENAME: "美发护发"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liFWPZ' onclick='SelectMFHFLB(this)'><img class='img_MFHFLB'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 5 || i === 11 || i === 17 || i === 23 || i === 29) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divMFHFLBText").html(html);
                $(".img_MFHFLB").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadLR_MFHFJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择美发护发
function SelectMFHFLB(obj) {
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
//加载丽人_美发护发基本信息
function LoadLR_MFHFJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LR_MFHF/LoadLR_MFHFJBXX",
        dataType: "json",
        data:
        {
            LR_MFHFJBXXID: getUrlParam("LR_MFHFJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.LR_MFHFJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#LR_MFHFJBXXID").val(xml.Value.LR_MFHFJBXX.LR_MFHFJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.LR_MFHFJBXX.BCMS);
                });
                SetMFHFLB(xml.Value.LR_MFHFJBXX.LB);
                $("#spanQY").html(xml.Value.LR_MFHFJBXX.QY);
                $("#spanDD").html(xml.Value.LR_MFHFJBXX.DD);
                LoadPhotos(xml.Value.Photos);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//获取美发护发类别
function GetMFHFLB() {
    var MFHFLB = "";
    $(".liFWPZ").each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            MFHFLB += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(MFHFLB, ',');
}
//设置美发护发类别
function SetMFHFLB(lbs) {
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
    obj = jsonObj.AddJson(obj, "LB", "'" + GetMFHFLB() + "'");

    if (getUrlParam("LR_MFHFJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "LR_MFHFJBXXID", "'" + getUrlParam("LR_MFHFJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LR_MFHF/FB",
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