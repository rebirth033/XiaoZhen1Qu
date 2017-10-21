
$(document).ready(function () {$("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });BindClick("LB");
    BindClick("NLD");
    BindClick("PSFG");
    BindClick("LX");
    BindClick("CZ");
    BindClick("QY");
    BindClick("DD");
    LoadSWFW_SYSXJBXX();
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("摄影摄像类别", "LB", "CODES_SWFW");
        }
        if (type === "NLD") {
            LoadCODESByTYPENAME("年龄段", "NLD", "CODES_SWFW");
        }
        if (type === "PSFG") {
            LoadCODESByTYPENAME("拍摄风格", "PSFG", "CODES_SWFW");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//选择类别下拉框
function SelectLB(obj, type, lbid) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#LBID").val(lbid);
    PDLB(obj.innerHTML);
}
//判断类别
function PDLB(lbmc) {
    if (lbmc === "写真/艺术照") {
        $("#divYLGZS").css("display", "");
        $("#divXZLX").css("display", "");
        $("#divYLGZS").css("display", "");
        $("#divPSDD").css("display", "");
        $("#divSYSXPSFG").css("display", "");
        $("#divFZTS").css("display", "");
        $("#divFZPSSF").css("display", "");
        $("#divTXDPS").css("display", "");
        $("#divTXJXJRCS").css("display", "");
        $("#divJXKPZS").css("display", "");
        $("#divDPZS").css("display", "");
        $("#divJPSF").css("display", "");
        $("#divJDSF").css("display", "");
        $("#divTXXCSL").css("display", "");
        $("#divTXBJSL").css("display", "");
        $("#divSYLX").css("display", "none");
        $("#divSLLX").css("display", "none");
        $("#divSYSXNLD").css("display", "none");
    }
    if (lbmc === "儿童摄影") {
        $("#divSYSXNLD").css("display", "");
        $("#divYLGZS").css("display", "");
        $("#divYLGZS").css("display", "");
        $("#divPSDD").css("display", "");
        $("#divFZTS").css("display", "");
        $("#divFZPSSF").css("display", "");
        $("#divTXDPS").css("display", "");
        $("#divTXJXJRCS").css("display", "");
        $("#divJXKPZS").css("display", "");
        $("#divDPZS").css("display", "");
        $("#divJPSF").css("display", "");
        $("#divJDSF").css("display", "");
        $("#divTXXCSL").css("display", "");
        $("#divTXBJSL").css("display", "");
        $("#divXZLX").css("display", "none");
        $("#divSYSXPSFG").css("display", "none");
        $("#divSYLX").css("display", "none");
        $("#divSLLX").css("display", "none");
    }
    if (lbmc === "商业摄影") {
        $("#divSYLX").css("display", "");
        $("#divSYSXNLD").css("display", "none");
        $("#divYLGZS").css("display", "none");
        $("#divYLGZS").css("display", "none");
        $("#divPSDD").css("display", "none");
        $("#divFZTS").css("display", "none");
        $("#divFZPSSF").css("display", "none");
        $("#divTXDPS").css("display", "none");
        $("#divTXJXJRCS").css("display", "none");
        $("#divJXKPZS").css("display", "none");
        $("#divDPZS").css("display", "none");
        $("#divJPSF").css("display", "none");
        $("#divJDSF").css("display", "none");
        $("#divTXXCSL").css("display", "none");
        $("#divTXBJSL").css("display", "none");
        $("#divXZLX").css("display", "none");
        $("#divSYSXPSFG").css("display", "none");
        $("#divSLLX").css("display", "none");
    }
    if (lbmc === "摄像录像") {
        $("#divSLLX").css("display", "");
        $("#divSYSXNLD").css("display", "none");
        $("#divYLGZS").css("display", "none");
        $("#divYLGZS").css("display", "none");
        $("#divPSDD").css("display", "none");
        $("#divFZTS").css("display", "none");
        $("#divFZPSSF").css("display", "none");
        $("#divTXDPS").css("display", "none");
        $("#divTXJXJRCS").css("display", "none");
        $("#divJXKPZS").css("display", "none");
        $("#divDPZS").css("display", "none");
        $("#divJPSF").css("display", "none");
        $("#divJDSF").css("display", "none");
        $("#divTXXCSL").css("display", "none");
        $("#divTXBJSL").css("display", "none");
        $("#divXZLX").css("display", "none");
        $("#divSYSXPSFG").css("display", "none");
        $("#divSYLX").css("display", "none");
    }
    if (lbmc === "彩扩冲印" || lbmc === "相框相册制作" || lbmc === "证件照") {
        $("#divSLLX").css("display", "none");
        $("#divSYSXNLD").css("display", "none");
        $("#divYLGZS").css("display", "none");
        $("#divYLGZS").css("display", "none");
        $("#divPSDD").css("display", "none");
        $("#divFZTS").css("display", "none");
        $("#divFZPSSF").css("display", "none");
        $("#divTXDPS").css("display", "none");
        $("#divTXJXJRCS").css("display", "none");
        $("#divJXKPZS").css("display", "none");
        $("#divDPZS").css("display", "none");
        $("#divJPSF").css("display", "none");
        $("#divJDSF").css("display", "none");
        $("#divTXXCSL").css("display", "none");
        $("#divTXBJSL").css("display", "none");
        $("#divXZLX").css("display", "none");
        $("#divSYSXPSFG").css("display", "none");
        $("#divSYLX").css("display", "none");
    }
}
//加载多选
function LoadDuoX(type, id) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: type,
            TBName: "CODES_SWFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li" + id + "' onclick='SelectDuoX(this)'><img class='img_" + id + "'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 3 || i === 7 || i === 11) {
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
                LoadSWFW_SYSXJBXX();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载婚庆摄影_婚纱摄影基本信息
function LoadSWFW_SYSXJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW_SYSX/LoadSWFW_SYSXJBXX",
        dataType: "json",
        data:
        {
            SWFW_SYSXJBXXID: getUrlParam("SWFW_SYSXJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SWFW_SYSXJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SWFW_SYSXJBXXID").val(xml.Value.SWFW_SYSXJBXX.SWFW_SYSXJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.SWFW_SYSXJBXX.LB);
                PDLB(xml.Value.SWFW_SYSXJBXX.LB);
                $("#spanNLD").html(xml.Value.SWFW_SYSXJBXX.NLD);
                $("#spanPSFG").html(xml.Value.SWFW_SYSXJBXX.PSFG);
                $("#spanQY").html(xml.Value.SWFW_SYSXJBXX.QY);
                $("#spanDD").html(xml.Value.SWFW_SYSXJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.SWFW_SYSXJBXX.YLGZS !== null)
                    SetDX("YLGZS", xml.Value.SWFW_SYSXJBXX.YLGZS);
                if (xml.Value.SWFW_SYSXJBXX.SYLX !== null)
                    SetDX("SYLX", xml.Value.SWFW_SYSXJBXX.SYLX);
                if (xml.Value.SWFW_SYSXJBXX.SLLX !== null)
                    SetDX("SLLX", xml.Value.SWFW_SYSXJBXX.SLLX);
                if (xml.Value.SWFW_SYSXJBXX.XZLX !== null)
                    SetDX("XZLX", xml.Value.SWFW_SYSXJBXX.XZLX);
                if (xml.Value.SWFW_SYSXJBXX.PSDD !== null)
                    SetDX("PSDD", xml.Value.SWFW_SYSXJBXX.PSDD);
                if (xml.Value.SWFW_SYSXJBXX.FZPSSF !== null)
                    SetDX("FZPSSF", xml.Value.SWFW_SYSXJBXX.FZPSSF);
                if (xml.Value.SWFW_SYSXJBXX.JXKPZS !== null)
                    SetDX("JXKPZS", xml.Value.SWFW_SYSXJBXX.JXKPZS);
                if (xml.Value.SWFW_SYSXJBXX.DPZS !== null)
                    SetDX("DPZS", xml.Value.SWFW_SYSXJBXX.DPZS);
                if (xml.Value.SWFW_SYSXJBXX.JPSF !== null)
                    SetDX("JPSF", xml.Value.SWFW_SYSXJBXX.JPSF);
                if (xml.Value.SWFW_SYSXJBXX.JDSF !== null)
                    SetDX("JDSF", xml.Value.SWFW_SYSXJBXX.JDSF);
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
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "LB", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "NLD", "'" + $("#spanNLD").html() + "'");
    obj = jsonObj.AddJson(obj, "PSFG", "'" + $("#spanPSFG").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "SYLX", "'" + GetDX("SYLX") + "'");
    obj = jsonObj.AddJson(obj, "SLLX", "'" + GetDX("SLLX") + "'");
    obj = jsonObj.AddJson(obj, "YLGZS", "'" + GetDX("YLGZS") + "'");
    obj = jsonObj.AddJson(obj, "XZLX", "'" + GetDX("XZLX") + "'");
    obj = jsonObj.AddJson(obj, "PSDD", "'" + GetDX("PSDD") + "'");
    obj = jsonObj.AddJson(obj, "FZPSSF", "'" + GetDX("FZPSSF") + "'");
    obj = jsonObj.AddJson(obj, "JXKPZS", "'" + GetDX("JXKPZS") + "'");
    obj = jsonObj.AddJson(obj, "DPZS", "'" + GetDX("DPZS") + "'");
    obj = jsonObj.AddJson(obj, "JPSF", "'" + GetDX("JPSF") + "'");
    obj = jsonObj.AddJson(obj, "JDSF", "'" + GetDX("JDSF") + "'");

    if (getUrlParam("SWFW_SYSXJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SWFW_SYSXJBXXID", "'" + getUrlParam("SWFW_SYSXJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW_SYSX/FB",
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