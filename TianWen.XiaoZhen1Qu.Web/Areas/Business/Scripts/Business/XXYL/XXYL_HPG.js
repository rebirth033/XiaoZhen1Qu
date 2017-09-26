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
    LoadSNSBLB();
    LoadDefault();
    BindClick("LB");
    BindClick("KRNRS");
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
//加载轰趴馆类别
function LoadSNSBLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_XXYL",
        dataType: "json",
        data:
        {
            TYPENAME: "室内设备"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liFWPZ' onclick='SelectSNSBLB(this)'><img class='img_SNSBLB'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 5 || i === 11 || i === 17 || i === 23 || i === 29) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                html += "</ul>";
                $("#divSNSBLBText").html(html);
                $(".img_SNSBLB").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                LoadXXYL_HPGJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载可容纳人数
function LoadKRNRS() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_XXYL",
        dataType: "json",
        data:
        {
            TYPENAME: "可容纳人数"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"KRNRS\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divKRNRS").html(html);
                $("#divKRNRS").css("display", "block");
                ActiveStyle("KRNRS");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择房屋配置
function SelectSNSBLB(obj) {
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
        if (type === "KRNRS") {
            LoadKRNRS();
        } 
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载休闲娱乐_轰趴馆基本信息
function LoadXXYL_HPGJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/XXYL_HPG/LoadXXYL_HPGJBXX",
        dataType: "json",
        data:
        {
            XXYL_HPGJBXXID: getUrlParam("XXYL_HPGJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.XXYL_HPGJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#XXYL_HPGJBXXID").val(xml.Value.XXYL_HPGJBXX.XXYL_HPGJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.XXYL_HPGJBXX.BCMS);
                });
                SetSNSBLB(xml.Value.XXYL_HPGJBXX.SNSB);
                $("#spanKRNRS").html(xml.Value.XXYL_HPGJBXX.KRNRS);
                $("#spanQY").html(xml.Value.XXYL_HPGJBXX.QY);
                $("#spanDD").html(xml.Value.XXYL_HPGJBXX.DD);
                LoadPhotos(xml.Value.Photos);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//获取轰趴馆类别
function GetSNSBLB() {
    var SNSBLB = "";
    $(".liFWPZ").each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            SNSBLB += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(SNSBLB, ',');
}
//设置轰趴馆类别
function SetSNSBLB(lbs) {
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
    obj = jsonObj.AddJson(obj, "KRNRS", "'" + $("#spanKRNRS").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "SNSB", "'" + GetSNSBLB() + "'");

    if (getUrlParam("XXYL_HPGJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "XXYL_HPGJBXXID", "'" + getUrlParam("XXYL_HPGJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/XXYL_HPG/FB",
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