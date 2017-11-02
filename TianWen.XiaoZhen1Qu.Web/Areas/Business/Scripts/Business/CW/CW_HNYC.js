$(document).ready(function () {
    $("body").bind("click", function () { Close("_XZQ"); });
    LoadCW_HNYCJBXX();
    BindClick("LB");
});
//加载小类
function LoadXL() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/Common/LoadByParentID",
        dataType: "json",
        data:
        {
            ParentID: $("#LBID").val(),
            TBName: "CODES_CW"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='ul_select' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='li_select' onclick='SelectDropdown(this,\"XL\",\"" + xml.list[i].CODEID + "\")'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divXL").html(html);
                $("#divXL").css("display", "block");
                Bind("HNYCLB", "XL", "");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//选择品种下拉框
function SelectLB(obj, type, id) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    $("#LBID").val(id);
    BindClick("XL");
}
//绑定下拉框鼠标点击样式
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "LB") {
            LoadCODESByTYPENAME("花鸟鱼虫", "LB", "CODES_CW", Bind, "HNYCLB", "LB", "");
        }
        if (type === "XL") {
            LoadXL();
        }
    });
}
//加载宠物_花鸟鱼虫基本信息
function LoadCW_HNYCJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CW/LoadCW_HNYCJBXX",
        dataType: "json",
        data:
        {
            CW_HNYCJBXXID: getUrlParam("CW_HNYCJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.CW_HNYCJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#CW_HNYCJBXXID").val(xml.Value.CW_HNYCJBXX.CW_HNYCJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.BCMSString);
                });
                $("#spanLB").html(xml.Value.CW_HNYCJBXX.PZ);
                if (xml.Value.CW_HNYCJBXX.GQ !== null)
                    SetDX("GQ", xml.Value.CW_HNYCJBXX.GQ);
                LoadPhotos(xml.Value.Photos);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//发布
function FB() {
    if (ValidateAll() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "PZ", "'" + $("#spanLB").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    obj = jsonObj.AddJson(obj, "GQ", "'" + GetDX("GQ") + "'");

    if (getUrlParam("CW_HNYCJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "CW_HNYCJBXXID", "'" + getUrlParam("CW_HNYCJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/CW/FBCW_HNYCJBXX",
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