$(document).ready(function () {
    $("#XQMC").bind("blur", ValidateXQMC);
    $("#XQMC").bind("blur", HideXQMCList);
    $("#XQMC").bind("focus", InfoXQMC);
    $("#S").bind("blur", ValidateFWLX_S);
    $("#S").bind("focus", InfoFWLX_S);
    $("#T").bind("blur", ValidateFWLX_T);
    $("#T").bind("focus", InfoFWLX_T);
    $("#W").bind("blur", ValidateFWLX_W);
    $("#W").bind("focus", InfoFWLX_W);
    $("#PFM").bind("blur", ValidateFWLX_PFM);
    $("#PFM").bind("focus", InfoFWLX_PFM);
    $("#C").bind("blur", ValidateLCFB_C);
    $("#C").bind("focus", InfoLCFB_C);
    $("#GJC").bind("blur", ValidateLCFB_GJC);
    $("#GJC").bind("focus", InfoLCFB_GJC);
    $("#ZJ").bind("blur", ValidateZJ);
    $("#ZJ").bind("focus", InfoZJ);
    $("#BT").bind("blur", ValidateBT);
    $("#BT").bind("focus", InfoBT);
    $("#LXR").bind("blur", ValidateLXR);
    $("#LXR").bind("focus", InfoLXR);
    $("#LXDH").bind("blur", ValidateLXDH);
    $("#LXDH").bind("focus", InfoLXDH);
});

function ValidateXQMC() {
    if ($("#XQMC").val() === "" || $("#XQMC").val() === null) {
        $("#divXQMCTip").css("display", "block");
        $("#divXQMCTip").attr("class", "Warn");
        $("#divXQMCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写小区名称啦');
        $("#XQMC").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divXQMCTip").css("display", "none");
        $("#XQMC").css("border-color", "#cccccc");
        return true;
    }
}

function InfoXQMC() {
    $("#divXQMCTip").attr("class", "Info");
    $("#divXQMCTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />不超过30字');
}

function HideXQMCList() {
    if (isleave)
        $("#divXQMClist").css("display", "none");
}

function ValidateFWLX_S() {
    if ($("#S").val() === "" || $("#S").val() === null) {
        $("#divFWLXTip").css("display", "block");
        $("#divFWLXTip").attr("class", "Warn");
        $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写室啦');
        $("#spanS").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divFWLXTip").css("display", "none");
        $("#S").css("border-color", "#cccccc");
        return true;
    }
}

function InfoFWLX_S() {
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写1、2、3等数字，不能是0');
}

function ValidateFWLX_T() {
    if ($("#T").val() === "" || $("#T").val() === null) {
        $("#divFWLXTip").css("display", "block");
        $("#divFWLXTip").attr("class", "Warn");
        $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写厅啦');
        $("#spanT").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divFWLXTip").css("display", "none");
        $("#T").css("border-color", "#cccccc");
        return true;
    }
}

function InfoFWLX_T() {
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写1、2、3等数字，没有请填0');
}

function ValidateFWLX_W() {
    if ($("#W").val() === "" || $("#W").val() === null) {
        $("#divFWLXTip").css("display", "block");
        $("#divFWLXTip").attr("class", "Warn");
        $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写卫啦');
        $("#spanW").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divFWLXTip").css("display", "none");
        $("#W").css("border-color", "#cccccc");
        return true;
    }
}

function InfoFWLX_W() {
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写1、2、3等数字，没有请填0');
}

function ValidateFWLX_PFM() {
    if ($("#PFM").val() === "" || $("#PFM").val() === null) {
        $("#divFWLXTip").css("display", "block");
        $("#divFWLXTip").attr("class", "Warn");
        $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写面积啦');
        $("#spanPFM").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divFWLXTip").css("display", "none");
        $("#PFM").css("border-color", "#cccccc");
        return true;
    }
}

function InfoFWLX_PFM() {
    $("#divFWLXTip").attr("class", "Info");
    $("#divFWLXTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写1、2、3等数字，不能是0');
}

function ValidateLCFB_C() {
    if ($("#C").val() === "" || $("#C").val() === null) {
        $("#divLCFBTip").css("display", "block");
        $("#divLCFBTip").attr("class", "Warn");
        $("#divLCFBTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写楼层啦');
        $("#spanC").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divLCFBTip").css("display", "none");
        $("#C").css("border-color", "#cccccc");
        return true;
    }
}

function InfoLCFB_C() {
    $("#divLCFBTip").attr("class", "Info");
    $("#divLCFBTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写数字，地下室用负数填写，最多可填写两位数喔');
}

function ValidateLCFB_GJC() {
    if ($("#GJC").val() === "" || $("#GJC").val() === null) {
        $("#divLCFBTip").css("display", "block");
        $("#divLCFBTip").attr("class", "Warn");
        $("#divLCFBTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写总层数啦');
        $("#spanGJC").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divLCFBTip").css("display", "none");
        $("#GJC").css("border-color", "#cccccc");
        return true;
    }
}

function InfoLCFB_GJC() {
    $("#divLCFBTip").attr("class", "Info");
    $("#divLCFBTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />填写数字，最多可填写两位数喔');
}

function ValidateZJ() {
    if ($("#ZJ").val() === "" || $("#ZJ").val() === null) {
        $("#divZJTip").css("display", "block");
        $("#divZJTip").attr("class", "Warn");
        $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写租金啦');
        $("#spanZJ").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divZJTip").css("display", "none");
        $("#ZJ").css("border-color", "#cccccc");
        return true;
    }
}

function InfoZJ() {
    $("#divZJTip").attr("class", "Info");
    $("#divZJTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />请填写整数，面议则填0');
}

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
        return trye;
    }
}

function InfoBT() {
    $("#divBTTip").attr("class", "Info");
    $("#divBTTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/info.png" class="imgTip" />标题6-50字');
}

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

function InfoLXR() {
    $("#divLXRTip").attr("class", "Info");
    $("#divLXRTip").html('');
}

function ValidateLXDH() {
    if ($("#LXDH").val() === "" || $("#LXDH").val() === null) {
        $("#divLXDHTip").css("display", "block");
        $("#divLXDHTip").attr("class", "Warn");
        $("#divLXDHTip").html('<img src="' + getRootPath() + '/Areas/Business/Css/images/warn.png" class="imgTip" />忘记填写联系电话啦');
        $("#LXDH").css("border-color", "#fd634f");
        return false;
    } else {
        $("#divLXDHTip").css("display", "none");
        $("#LXDH").css("border-color", "#cccccc");
        return true;
    }
}

function InfoLXDH() {
    $("#divLXDHTip").attr("class", "Info");
    $("#divLXDHTip").html('');
}

function FWLXValidate() {
    if (!ValidateFWLX_S()) return false;
    if (!ValidateFWLX_T()) return false;
    if (!ValidateFWLX_W()) return false;
    if (!ValidateFWLX_PFM()) return false;
    return true;
}

function LCFBValidate() {
    if (!ValidateLCFB_C()) return false;
    if (!ValidateLCFB_GJC()) return false;
    return true;
}

function AllValidate() {
    if (ValidateXQMC() & FWLXValidate() & LCFBValidate() & ValidateZJ() & ValidateBT & ValidateFWZP() & ValidateLXR() & ValidateLXDH())
        return true;
    else
        return false;
}