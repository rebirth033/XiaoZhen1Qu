
$(document).ready(function () {$("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });BindClick("LB");
    BindClick("QY");
    BindClick("DD");
    LoadSHFW_WXFW_FWWXDKJBXX();
});

//选择类别下拉框
function SelectLB(obj, type, id) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#LBID").val(id);
    PDLB(obj.innerHTML);
}
//判断类别
function PDLB(lbmc) {
    if (lbmc === "卫浴/洁具维修" || lbmc === "水管/水龙头维修" || lbmc === "粉刷/防腐") {
        BindClick("XL");
        $("#spanXL").html("请选择小类");
        $("#divXLText").css("display", "");
        $("#divXL").css("display", "none");
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
            TBName:"CODES_SHFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ul_select' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectDropdown(this,\"XL\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divXL").html(html);
                $("#divXL").css("display", "");
                ActiveStyle("XL");
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
            LoadCODESByTYPENAME("房屋维修/打孔", "LB", "CODES_SHFW");
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
//加载生活服务_房屋维修/打孔基本信息
function LoadSHFW_WXFW_FWWXDKJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_WXFW_FWWXDK/LoadSHFW_WXFW_FWWXDKJBXX",
        dataType: "json",
        data:
        {
            SHFW_WXFW_FWWXDKJBXXID: getUrlParam("SHFW_WXFW_FWWXDKJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SHFW_WXFW_FWWXDKJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SHFW_WXFW_FWWXDKJBXXID").val(xml.Value.SHFW_WXFW_FWWXDKJBXX.SHFW_WXFW_FWWXDKJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.SHFW_WXFW_FWWXDKJBXX.LB);
                $("#spanQY").html(xml.Value.SHFW_WXFW_FWWXDKJBXX.QY);
                $("#spanDD").html(xml.Value.SHFW_WXFW_FWWXDKJBXX.DD);
                $("#spanXL").html(xml.Value.SHFW_WXFW_FWWXDKJBXX.XL);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.SHFW_WXFW_FWWXDKJBXX.LB.indexOf("跑腿服务") !== -1) {
                    LoadXL(xml.Value.SHFW_WXFW_FWWXDKJBXX.LB, xml.Value.SHFW_WXFW_FWWXDKJBXX.XL);
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
    obj = jsonObj.AddJson(obj, "XL", "'" + $("#spanXL").html() + "'");
    obj = jsonObj.AddJson(obj, "QY", "'" + $("#spanQY").html() + "'");
    obj = jsonObj.AddJson(obj, "DD", "'" + $("#spanDD").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("SHFW_WXFW_FWWXDKJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SHFW_WXFW_FWWXDKJBXXID", "'" + getUrlParam("SHFW_WXFW_FWWXDKJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_WXFW_FWWXDK/FB",
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