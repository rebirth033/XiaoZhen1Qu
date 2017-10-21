
$(document).ready(function () {$("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });LoadSWFW_BGSBWXJBXX();
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
});

//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("办公设备维修", "LB", "CODES_SWFW");
        }
        if (type === "XL") {
            LoadXL();
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
    if (lbmc === "打印机" || lbmc === "复印机" || lbmc === "传真机" || lbmc === "一体机") {
        $("#spanXL").html("请选择小类");
        $("#divXLText").css("display", "");
        BindClick("XL");
    }
    else {
        $("#divXLText").css("display", "none");
    }
}
//加载小类
function LoadXL() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: $("#LBID").val(),
            TBName: "CODES_SWFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ul_select' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectDropdown(this,\"XL\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divXL").html(html);
                $("#divXL").css("display", "block");
                ActiveStyle("XL");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载商务服务_办公设备维修基本信息
function LoadSWFW_BGSBWXJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW_BGSBWX/LoadSWFW_BGSBWXJBXX",
        dataType: "json",
        data:
        {
            SWFW_BGSBWXJBXXID: getUrlParam("SWFW_BGSBWXJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SWFW_BGSBWXJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SWFW_BGSBWXJBXXID").val(xml.Value.SWFW_BGSBWXJBXX.SWFW_BGSBWXJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                PDLB(xml.Value.SWFW_BGSBWXJBXX.LB);
                $("#spanLB").html(xml.Value.SWFW_BGSBWXJBXX.LB);
                $("#spanXL").html(xml.Value.SWFW_BGSBWXJBXX.XL);
                $("#spanQY").html(xml.Value.SWFW_BGSBWXJBXX.QY);
                $("#spanDD").html(xml.Value.SWFW_BGSBWXJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                SetDX("SFSM", xml.Value.SWFW_BGSBWXJBXX.SFSM);
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
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "SFSM", "'" + GetDX("SFSM") + "'");

    if (getUrlParam("SWFW_BGSBWXJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SWFW_BGSBWXJBXXID", "'" + getUrlParam("SWFW_BGSBWXJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SWFW_BGSBWX/FB",
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