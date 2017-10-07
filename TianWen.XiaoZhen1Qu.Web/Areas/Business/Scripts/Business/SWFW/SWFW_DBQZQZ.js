var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $(".div_radio").bind("click", RadioSelect);
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
    BindClick("GJ");
    BindClick("QY");
    BindClick("DD");
    LoadSWFW_DBQZQZJBXX();
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
    $(".iFWCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//加载国家标签
function LoadGJ() {
    var arrayObj = new Array('A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');
    var html = "";
    for (var i = 0; i < arrayObj.length; i++) {
        if (i === 0)
            html += '<div class="divstep_yx" id="div' + arrayObj[i] + '" style="width:62px;"><span class="spanstep_yx" id="span' + arrayObj[i] + '">' + "热门" + '</span><em class="emstep_yx" id="em' + arrayObj[i] + '"></em></div>';
        else
            html += '<div class="divstep_yx" id="div' + arrayObj[i] + '"><span class="spanstep_yx" id="span' + arrayObj[i] + '">' + arrayObj[i] + '</span><em class="emstep_yx" id="em' + arrayObj[i] + '"></em></div>';
    }
    $("#div_content_yxbq").html(html);
    $(".divstep_yx").bind("click", JCBQActive);
}
//国家标签切换
function JCBQActive() {
    LoadGJMC("国家", this.id);
}
//加载国家名称
function LoadGJMC(JCLX, JCBQ) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadGJXX",
        dataType: "json",
        data:
        {
            GJBQ: JCBQ.split("div")[1]
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "";
                for (var i = 0; i < xml.list.length; i++) {
                    html += '<span class="span_yxmc" onclick="GJXZ(\'' + xml.list[i].CODENAME + '\',\'' + xml.list[i].CODEID + '\')">' + xml.list[i].CODENAME + '</span>';
                }
                if (xml.list.length === 0)
                    html += '<span class="span_yxmc" style=\"width:200px;text-align:left;margin-left:14px;\">该字母下暂无数据</span>';
                $("#div_content_yxmc").html(html);
                $("#divGJ").css("display", "block");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择国家名称
function GJXZ(GJMC, GJID) {
    $("#spanGJ").html(GJMC);
    $("#divGJ").css("display", "none");
}
//选择单选
function RadioSelect() {
    $(this).parent().find("img").each(function () {
        $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    });
    $(this).find("img").each(function () {
        $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    });
}
//获取单选
function GetDX(type) {
    var value = "";
    $("#div" + type).find("img").each(function () {
        if ($(this).attr("src").indexOf("blue") !== -1)
            value = $(this).parent().find("label")[0].innerHTML;
    });
    return value;
}
//设置单选
function SetDX(type, value) {
    $("#div" + type).find("label").each(function () {
        if ($(this)[0].innerHTML === value)
            $(this).parent().find("img").each(function () {
                $(this).attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
            });
    });
}
//加载代办签证/签注类别
function LoadLB() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadCODES_SWFW",
        dataType: "json",
        data:
        {
            TYPENAME: "代办签证/签注"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectDropdown(this,\"LB\")'>" + xml.list[i].CODENAME + "</li>";
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
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadLB();
        }
        if (type === "GJ") {
            LoadGJ();
            LoadGJMC("国家", "divA");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载商务服务_代办签证/签注基本信息
function LoadSWFW_DBQZQZJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW_DBQZQZ/LoadSWFW_DBQZQZJBXX",
        dataType: "json",
        data:
        {
            SWFW_DBQZQZJBXXID: getUrlParam("SWFW_DBQZQZJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SWFW_DBQZQZJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SWFW_DBQZQZJBXXID").val(xml.Value.SWFW_DBQZQZJBXX.SWFW_DBQZQZJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.SWFW_DBQZQZJBXX.BCMS);
                });
                $("#spanLB").html(xml.Value.SWFW_DBQZQZJBXX.LB);
                $("#spanGJ").html(xml.Value.SWFW_DBQZQZJBXX.GJ);
                $("#spanQY").html(xml.Value.SWFW_DBQZQZJBXX.QY);
                $("#spanDD").html(xml.Value.SWFW_DBQZQZJBXX.DD);
                SetDX("GRTT", xml.Value.SWFW_DBQZQZJBXX.GRTT);
                LoadPhotos(xml.Value.Photos);
                LoadXL(xml.Value.SWFW_DBQZQZJBXX.LB, xml.Value.SWFW_DBQZQZJBXX.XL);
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
    obj = jsonObj.AddJson(obj, "GJ", "'" + $("#spanGJ").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GRTT", "'" + GetDX("GRTT") + "'");

    if (getUrlParam("SWFW_DBQZQZJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SWFW_DBQZQZJBXXID", "'" + getUrlParam("SWFW_DBQZQZJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW_DBQZQZ/FB",
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