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
    LoadDefault();
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
    LoadSHFW_SHFW_BJQXJBXX();
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
//加载保洁清洗类别
function LoadLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_SHFW",
        dataType: "json",
        data:
        {
            TYPENAME: "保洁清洗"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll; height:341px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectLB(this,\"LB\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divLB").html(html);
                $("#divLB").css("display", "block");
                ActiveStyle("LB");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择类别下拉框
function SelectLB(obj, type, id) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadXL($("#spanLB").html());
    $("#divXL").css("display", "");
}
//加载小类
function LoadXL(lbmc, xl) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_SHFW",
        dataType: "json",
        data:
        {
            TYPENAME: lbmc
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liXL' onclick='SelectXL(this)'><img class='img_XL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 5 || i === 11 || i === 17 || i === 23 || i === 29) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 6) === 0)
                    $("#divXL").css("height", parseInt(xml.list.length / 6) * 45 + "px");
                else
                    $("#divXL").css("height", (parseInt(xml.list.length / 6) + 1) * 45 + "px");
                html += "</ul>";
                $("#divXLText").html(html);
                $(".img_XL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                if (xml.list.length === 0)
                    $("#divXL").css("display", "none");
                else 
                    $("#divXL").css("display", "");
                if (xl !== "" && xl !== null)
                    SetXL(xl);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择小类
function SelectXL(obj) {
    if ($(obj).find("img").attr("src").indexOf("blue") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
}
//获取小类
function GetXL() {
    var XL = "";
    $(".liXL").each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            XL += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(XL, ',');
}
//设置小类
function SetXL(lbs) {
    if (lbs !== "" && lbs !== null) {
        var lbarray = lbs.split(',');
        for (var i = 0; i < lbarray.length; i++) {
            $(".liXL").each(function () {
                if ($(this).find("label")[0].innerHTML.indexOf(lbarray[i]) !== -1)
                    $(this).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
            });
        }
    }
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
//加载生活服务_保洁清洗基本信息
function LoadSHFW_SHFW_BJQXJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_SHFW_BJQX/LoadSHFW_SHFW_BJQXJBXX",
        dataType: "json",
        data:
        {
            SHFW_SHFW_BJQXJBXXID: getUrlParam("SHFW_SHFW_BJQXJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SHFW_SHFW_BJQXJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SHFW_SHFW_BJQXJBXXID").val(xml.Value.SHFW_SHFW_BJQXJBXX.SHFW_SHFW_BJQXJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.SHFW_SHFW_BJQXJBXX.BCMS);
                });
                $("#spanLB").html(xml.Value.SHFW_SHFW_BJQXJBXX.LB);
                $("#spanQY").html(xml.Value.SHFW_SHFW_BJQXJBXX.QY);
                $("#spanDD").html(xml.Value.SHFW_SHFW_BJQXJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.SHFW_SHFW_BJQXJBXX.LB.indexOf("空气净化") !== -1 || xml.Value.SHFW_SHFW_BJQXJBXX.LB.indexOf("开荒保洁") !== -1 || xml.Value.SHFW_SHFW_BJQXJBXX.LB.indexOf("物业保洁") !== -1 || xml.Value.SHFW_SHFW_BJQXJBXX.LB.indexOf("沙发清洗") !== -1 || xml.Value.SHFW_SHFW_BJQXJBXX.LB.indexOf("地毯清洗") !== -1
                    || xml.Value.SHFW_SHFW_BJQXJBXX.LB.indexOf("地板打蜡") !== -1 || xml.Value.SHFW_SHFW_BJQXJBXX.LB.indexOf("石材翻新/养护") !== -1 || xml.Value.SHFW_SHFW_BJQXJBXX.LB.indexOf("除虫除蚁") !== -1 || xml.Value.SHFW_SHFW_BJQXJBXX.LB.indexOf("高空清洗") !== -1) {
                    LoadXL(xml.Value.SHFW_SHFW_BJQXJBXX.LB, xml.Value.SHFW_SHFW_BJQXJBXX.XL);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//发布
function FB() {
    if (AllValidate() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + GetXL() + "'");

    if (getUrlParam("SHFW_SHFW_BJQXJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SHFW_SHFW_BJQXJBXXID", "'" + getUrlParam("SHFW_SHFW_BJQXJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_SHFW_BJQX/FB",
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