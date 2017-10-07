var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $("#imgSMFW").bind("click", SMFWSelect);
    $("#imgDDFW").bind("click", DDFWSelect);
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
    LoadSKXS();
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
    $("#imgSMFW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgDDFW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择上门服务
function SMFWSelect() {
    $("#imgSMFW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgDDFW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//选择到店服务
function DDFWSelect() {
    $("#imgSMFW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgDDFW").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}
//加载中小学辅导班类别
function LoadLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_JYPX",
        dataType: "json",
        data:
        {
            TYPENAME: "中小学辅导班"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
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
        url: getRootPath() + "/Business/Common/LoadCODES_JYPX",
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
                    if (i === 3 || i === 7 || i === 11) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divXL").css("height", parseInt(xml.list.length / 4) * 45 + "px");
                else
                    $("#divXL").css("height", (parseInt(xml.list.length / 4) + 1) * 45 + "px");
                html += "</ul>";
                $("#divXLText").html(html);
                $(".img_XL").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                if (xml.list.length === 0)
                    $("#divXL").css("display", "none");
                else
                    $("#divXL").css("display", "");
                if (xl !== "" && xl !== null && xl !== undefined)
                    SetXL(xl);
                if (lbmc === "品牌策划推广")
                    $(".liXL").css("width", "200px");
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
//加载卡型
function LoadSKXS() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_JYPX",
        dataType: "json",
        data:
        {
            TYPENAME: "授课形式"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liSKXS' onclick='SelectSKXS(this)'><img class='img_SKXS'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 3 || i === 7 || i === 11) {
                        html += "</ul><ul class='ulFWPZ' style='margin-left: 214px'>";
                    }
                }
                if (parseInt(xml.list.length % 4) === 0)
                    $("#divSKXS").css("height", parseInt(xml.list.length / 4) * 45 + "px");
                else
                    $("#divSKXS").css("height", (parseInt(xml.list.length / 4) + 1) * 45 + "px");
                html += "</ul>";
                $("#divSKXSText").html(html);
                $(".img_SKXS").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
                if (xml.list.length === 0)
                    $("#divSKXS").css("display", "none");
                else
                    $("#divSKXS").css("display", "");
                LoadJYPX_ZXXFDBJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择卡型
function SelectSKXS(obj) {
    if ($(obj).find("img").attr("src").indexOf("blue") !== -1)
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_gray.png");
    else
        $(obj).find("img").attr("src", getRootPath() + "/Areas/Business/Css/images/check_blue.png");
}
//获取卡型
function GetSKXS() {
    var SKXS = "";
    $(".liSKXS").each(function () {
        if ($(this).find("img").attr("src").indexOf("blue") !== -1)
            SKXS += $(this).find("label")[0].innerHTML + ",";
    });
    return RTrim(SKXS, ',');
}
//设置卡型
function SetSKXS(lbs) {
    if (lbs !== "" && lbs !== null) {
        var lbarray = lbs.split(',');
        for (var i = 0; i < lbarray.length; i++) {
            $(".liSKXS").each(function () {
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
//加载商务服务_中小学辅导班基本信息
function LoadJYPX_ZXXFDBJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/JYPX_ZXXFDB/LoadJYPX_ZXXFDBJBXX",
        dataType: "json",
        data:
        {
            JYPX_ZXXFDBJBXXID: getUrlParam("JYPX_ZXXFDBJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JYPX_ZXXFDBJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#JYPX_ZXXFDBJBXXID").val(xml.Value.JYPX_ZXXFDBJBXX.JYPX_ZXXFDBJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.JYPX_ZXXFDBJBXX.BCMS);
                });
                $("#spanLB").html(xml.Value.JYPX_ZXXFDBJBXX.LB);
                $("#spanQY").html(xml.Value.JYPX_ZXXFDBJBXX.QY);
                $("#spanDD").html(xml.Value.JYPX_ZXXFDBJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                LoadXL(xml.Value.JYPX_ZXXFDBJBXX.LB, xml.Value.JYPX_ZXXFDBJBXX.XL);
                SetSKXS(xml.Value.JYPX_ZXXFDBJBXX.SKXS);
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
    var obj = jsonObj.GetJsonObject(); $(document).ready(function () {
        $("#BT").bind("blur", ValidateBT);
        $("#BT").bind("focus", InfoBT);
        $("#LXR").bind("blur", ValidateLXR);
        $("#LXR").bind("focus", InfoLXR);
        $("#LXDH").bind("blur", ValidateLXDH);
        $("#LXDH").bind("focus", InfoLXDH);
    });
    //验证标题
    function ValidateBT() {
        if ($("#BT").val() === "" || $("#BT").val() === null) {
            $("#divBTTip").css("display", "block");
            $("#divBTTip").attr("class", "Warn");
            $("#divBTTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写标题啦');
            $("#BT").css("border-color", "#fd634f");
            return false;
        } else {
            $("#divBTTip").css("display", "none");
            $("#BT").css("border-color", "#cccccc");
            return true;
        }
    }
    //验证照片
    function ValidateFWZP() {
        if ($("#divImgs1").find("img").length === 0) {
            $("#divFWZPTip").css("display", "block");
            $("#divFWZPTip").attr("class", "Warn");
            $("#divFWZPTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记选择照片啦');
            return false;
        } else {
            $("#divFWZPTip").css("display", "none");
            return true;
        }
    }
    //验证联系人
    function ValidateLXR() {
        if ($("#LXR").val() === "" || $("#LXR").val() === null) {
            $("#divLXRTip").css("display", "block");
            $("#divLXRTip").attr("class", "Warn");
            $("#divLXRTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写联系人啦');
            $("#LXR").css("border-color", "#fd634f");
            return false;
        } else {
            $("#divLXRTip").css("display", "none");
            $("#LXR").css("border-color", "#cccccc");
            return true;
        }
    }
    //验证联系电话
    function ValidateLXDH() {
        if ($("#LXDH").val() === "" || $("#LXDH").val() === null) {
            $("#divLXDHTip").css("display", "block");
            $("#divLXDHTip").attr("class", "Warn");
            $("#divLXDHTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写联系电话啦');
            $("#LXDH").css("border-color", "#fd634f");
            return false;
        } else {
            if ($("#LXDH").val().length !== 11) {
                $("#divLXDHTip").css("display", "block");
                $("#divLXDHTip").attr("class", "Warn");
                $("#divLXDHTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />手机号位数不对');
                $("#LXDH").css("border-color", "#fd634f");
                return false;

            } else {
                if (!ValidateCellPhone($("#LXDH").val())) {
                    $("#divLXDHTip").css("display", "block");
                    $("#divLXDHTip").attr("class", "Warn");
                    $("#divLXDHTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />手机号格式不对');
                    $("#LXDH").css("border-color", "#fd634f");
                    return false;
                } else {
                    $("#divLXDHTip").css("display", "none");
                    $("#LXDH").css("border-color", "#cccccc");
                    return true;
                }
            }
        }
    }
    //验证所有
    function AllValidate() {
        if (ValidateBT() & ValidateFWZP() & ValidateLXR() & ValidateLXDH())
            return true;
        else
            return false;
    }
    //提示标题
    function InfoBT() {
        $("#divBTTip").css("display", "block");
        $("#divBTTip").attr("class", "Info");
        $("#divBTTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />标题不超过50字');
        $("#BT").css("border-color", "#5bc0de");
    }
    //提示联系人
    function InfoLXR() {
        $("#divLXRTip").css("display", "block");
        $("#divLXRTip").attr("class", "Info");
        $("#divLXRTip").html('');
        $("#LXR").css("border-color", "#5bc0de");
    }
    //提示联系电话
    function InfoLXDH() {
        $("#divLXDHTip").css("display", "block");
        $("#divLXDHTip").attr("class", "Info");
        $("#divLXDHTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请输入手机号');
        $("#LXDH").css("border-color", "#5bc0de");
    }
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "XL", "'" + GetXL() + "'");
    obj = jsonObj.AddJson(obj, "SKXS", "'" + GetSKXS() + "'");

    if (getUrlParam("JYPX_ZXXFDBJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "JYPX_ZXXFDBJBXXID", "'" + getUrlParam("JYPX_ZXXFDBJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/JYPX_ZXXFDB/FB",
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