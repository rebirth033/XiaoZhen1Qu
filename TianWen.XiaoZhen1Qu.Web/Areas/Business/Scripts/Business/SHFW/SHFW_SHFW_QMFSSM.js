var isleave = true;
var ue = UE.getEditor('BCMS');
$(document).ready(function () {
    
    
    $("#btnFB").bind("click", FB);
    $("#BCMS").bind("focus", BCMSFocus);
    $("#BCMS").bind("blur", BCMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qCWFWs").bind("click", LoadXZQByGrade);
    $("body").bind("click", function () { Close("_XZQ"); Close("CX"); Close("PP"); Close("CCNX"); Close("CCYF"); Close("QY"); Close("DD"); });



    LoadDefault();
    BindClick("LB");
    BindClick("QY");
    BindClick("DD");
    LoadSHFW_SHFW_QMFSSMJBXX();
});
//描述框focus
function BCMSFocus() {
    $("#BCMS").css("color", "#333333");
}
//描述框blur
function BCMSBlur() {
    $("#BCMS").css("color", "#999999");
}
//描述框设默认文本
function BCMSSetDefault() {
    var BCMS = "1.房屋特征：\r\n\r\n2.周边配套：\r\n\r\n3.房东心态：";
    $("#BCMS").html(BCMS);
}
//加载默认
function LoadDefault() {
    ue.ready(function () {
        ue.setHeight(200);
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
        url: getRootPath() + "/Business/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: lbmc,
            TBName: "CODES_SHFW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ulFWPZ'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='liXL' onclick='SelectDuoX(this)'><img class='img_XL'/><label style='font-weight:normal;'>" + xml.list[i].CODENAME + "</label></li>";
                    if (i === 3 || i === 7 || i === 11 || i === 15 || i === 19) {
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
                    SetDuoX("XL", xl);
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
            LoadCODESByTYPENAME("起名/风水/算命", "LB", "CODES_SHFW");
        }
        if (type === "QY") {
            LoadQY();
        }
        if (type === "DD") {
            LoadDD($("#QYCode").val());
        }
    });
}
//加载生活服务_起名/风水/算命基本信息
function LoadSHFW_SHFW_QMFSSMJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_SHFW_QMFSSM/LoadSHFW_SHFW_QMFSSMJBXX",
        dataType: "json",
        data:
        {
            SHFW_SHFW_QMFSSMJBXXID: getUrlParam("SHFW_SHFW_QMFSSMJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.SHFW_SHFW_QMFSSMJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#SHFW_SHFW_QMFSSMJBXXID").val(xml.Value.SHFW_SHFW_QMFSSMJBXX.SHFW_SHFW_QMFSSMJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.SHFW_SHFW_QMFSSMJBXX.LB);
                $("#spanQY").html(xml.Value.SHFW_SHFW_QMFSSMJBXX.QY);
                $("#spanDD").html(xml.Value.SHFW_SHFW_QMFSSMJBXX.DD);
                LoadPhotos(xml.Value.Photos);
                if (xml.Value.SHFW_SHFW_QMFSSMJBXX.LB.indexOf("空气净化") !== -1 || xml.Value.SHFW_SHFW_QMFSSMJBXX.LB.indexOf("开荒保洁") !== -1 || xml.Value.SHFW_SHFW_QMFSSMJBXX.LB.indexOf("物业保洁") !== -1 || xml.Value.SHFW_SHFW_QMFSSMJBXX.LB.indexOf("沙发清洗") !== -1 || xml.Value.SHFW_SHFW_QMFSSMJBXX.LB.indexOf("地毯清洗") !== -1
                    || xml.Value.SHFW_SHFW_QMFSSMJBXX.LB.indexOf("地板打蜡") !== -1 || xml.Value.SHFW_SHFW_QMFSSMJBXX.LB.indexOf("石材翻新/养护") !== -1 || xml.Value.SHFW_SHFW_QMFSSMJBXX.LB.indexOf("除虫除蚁") !== -1 || xml.Value.SHFW_SHFW_QMFSSMJBXX.LB.indexOf("高空清洗") !== -1) {
                    LoadXL(xml.Value.SHFW_SHFW_QMFSSMJBXX.LB, xml.Value.SHFW_SHFW_QMFSSMJBXX.XL);
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
    obj = jsonObj.AddJson(obj, "XL", "'" + GetDuoX("XL") + "'");

    if (getUrlParam("SHFW_SHFW_QMFSSMJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "SHFW_SHFW_QMFSSMJBXXID", "'" + getUrlParam("SHFW_SHFW_QMFSSMJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/SHFW_SHFW_QMFSSM/FB",
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