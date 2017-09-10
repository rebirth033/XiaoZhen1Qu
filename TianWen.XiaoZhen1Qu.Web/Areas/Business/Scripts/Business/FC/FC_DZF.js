var isleave = true;
var ue = UE.getEditor('FYMS');
$(document).ready(function () {
    $(".div_top_left").css("margin-left", (document.documentElement.clientWidth - 1084) / 2);
    $(".div_top_right").css("margin-right", (document.documentElement.clientWidth - 1084) / 2);
    $(".div_head").css("margin-left", (document.documentElement.clientWidth - 1084) / 2);
    $(".div_content").css("margin-left", (document.documentElement.clientWidth - 1084) / 2);
    $("#spanCXLB").bind("click", CXLB);
    $("#imgDZF").bind("click", DZFSelect);
    $("#imgRZF").bind("click", RZFSelect);
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#span_xzdz").bind("click", OpenXZDZ);
    $("#div_dz_close").bind("click", CloseWindow);
    $("#span_content_info_qhcs").bind("click", LoadXZQByGrade);
    $("body").bind("click", CloseXZQ);

    LoadTXXX();
    BindHover();
    LoadFWLX();
    LoadZJDW();
    LoadDefault();
    LoadFC_DZFJBXX();
    //FYMSSetDefault();
});
//房屋描述框focus
function FYMSFocus() {
    $("#FYMS").css("color", "#333333");
}
//房屋描述框blur
function FYMSBlur() {
    $("#FYMS").css("color", "#999999");
}
//房屋描述框设默认文本
function FYMSSetDefault() {
    var fyms = "1.房屋特征：\r\n\r\n2.周边配套：\r\n\r\n3.房东心态：";
    $("#FYMS").html(fyms);
}
//加载默认
function LoadDefault() {
    ue.ready(function () {
        ue.setHeight(200);
    });
    $("#imgDZF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgRZF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}
//打开新增地址
function OpenXZDZ() {
    $("#shadow").css("display", "block");
    $("#editDZWindow").css("display", "block");
    var map = new BMap.Map("container");//创建地图实例
    map.centerAndZoom("福州市", 11);//创建点坐标,地图初始化
    map.enableScrollWheelZoom(true);//允许鼠标滑轮放大缩小 
    map.enableContinuousZoom(true);//允许惯性拖拽
    map.addControl(new BMap.NavigationControl({ isOpen: true, anchor: BMAP_ANCHOR_BOTTOM_LEFT }));  //添加默认缩放平移控件,右上角打开
    map.addControl(new BMap.OverviewMapControl({ isOpen: true, anchor: BMAP_ANCHOR_BOTTOM_RIGHT })); //添加默认缩略地图控件,右下角打开
    map.addControl(new BMap.MapTypeControl());//添加卫星控件

    $("#input_dtss").keydown(function (e) {
        var curKey = e.which;
        if (curKey == 13) {
            searchByStationName(map);
            return false;
        }
    });
    $("#btn_dtss").click(function () { searchByStationName(map); });
    $("#btn_savedz").click(function () { SaveDZ(); });
}

function SaveDZ() {
    CloseWindow();
}
//地址定位
function searchByStationName(map) {
    map.clearOverlays();//清空原来的标注
    var keyword = document.getElementById("input_dtss").value;
    var localSearch = new BMap.LocalSearch(map);
    localSearch.enableAutoViewport(); //允许自动调节窗体大小
    localSearch.setSearchCompleteCallback(function (searchResult) {
        var poi = searchResult.getPoi(0);
        map.centerAndZoom(poi.point, 13);
        var marker = new BMap.Marker(new BMap.Point(poi.point.lng, poi.point.lat));  // 创建标注，为要查询的地址对应的经纬度
        map.addOverlay(marker);
    });
    localSearch.search(keyword);
}

function LoadTXXX() {
    $("#spanTXXX").css("color", "#5bc0de");
    $("#emTXXX").css("background", "#5bc0de");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/LBXZ/LoadLBByID",
        dataType: "json",
        data:
        {
            LBID: getUrlParam("CLICKID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                if (xml.list.length > 0)
                    $("#spanLBXZ").html("1." + xml.list[0].LBNAME);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//重选类别
function CXLB() {
    window.location.href = getRootPath() + "/Business/LBXZ/LBXZ";
}

function DZFSelect() {
    $("#imgDZF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgRZF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}

function RZFSelect() {
    $("#imgDZF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgRZF").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}
//加载房屋类型
function LoadFWLX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC_FW/LoadCODES",
        dataType: "json",
        data:
        {
            TYPENAME: "短租房类型"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: scroll;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectFWLX(this)'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divFWLX").html(html);
                $("#divFWLX").css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载租金单位
function LoadZJDW() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC_FW/LoadCODES",
        dataType: "json",
        data:
        {
            TYPENAME: "租金单位"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var html = "<ul class='uldropdown' style='overflow-y: none;height:70px;margin-left:-1px;'>";
                for (var i = 0; i < xml.list.length; i++) {
                    html += "<li class='lidropdown' onclick='SelectZJDW(this)'>" + xml.list[i].CODENAME + "</li>";
                }
                html += "</ul>";
                $("#divZJDW").html(html);
                $("#divZJDW").css("display", "none");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function HoverStyle(name) {
    $("#div" + name + "Text").css("border-top", "1px solid #5bc0de").css("border-right", "1px solid #5bc0de").css("border-left", "1px solid #5bc0de").css("border-bottom", "1px solid #5bc0de");
    $("#div" + name).find("ul").css("border-left", "1px solid #5bc0de").css("border-right", "1px solid #5bc0de").css("border-bottom", "1px solid #5bc0de");
    $("#span" + name).css("color", "#333333");
}

function LeaveStyle(name) {
    $("#div" + name + "Text").css("border-top", "1px solid #cccccc").css("border-right", "1px solid #cccccc").css("border-left", "1px solid #cccccc").css("border-bottom", "1px solid #cccccc");
    $("#div" + name).find("ul").css("border-left", "1px solid #cccccc").css("border-right", "1px solid #cccccc").css("border-bottom", "1px solid #cccccc");
    $("#span" + name).css("color", "#999999");
}

function BindHover() {
    $("#divFWLXText").hover(function () {
        $("#divFWLX").css("display", "block");
        HoverStyle("FWLX");
    }, function () {
        $("#divFWLX").css("display", "none");
        LeaveStyle("FWLX");
    });
    $("#divFWLX").hover(function () {
        $("#divFWLX").css("display", "block");
        HoverStyle("FWLX");
    }, function () {
        $("#divFWLX").css("display", "none");
        LeaveStyle("FWLX");
    });
    $("#divZJDWText").hover(function () {
        $("#divZJDW").css("display", "block");
        HoverStyle("ZJDW");
    }, function () {
        $("#divZJDW").css("display", "none");
        LeaveStyle("ZJDW");
    });
    $("#divZJDW").hover(function () {
        $("#divZJDW").css("display", "block");
        HoverStyle("ZJDW");
    }, function () {
        $("#divZJDW").css("display", "none");
        LeaveStyle("ZJDW");
    });
}

function SelectFWLX(obj) {
    $("#spanFWLX").html(obj.innerHTML);
    $("#divFWLX").css("display", "none");
}

function SelectZJDW(obj) {
    $("#spanZJDW").html(obj.innerHTML);
    $("#divZJDW").css("display", "none");
}

function SelectFWPZ(obj) {
    if ($(obj).css("color") === "rgb(51, 51, 51)")
        $(obj).css("color", "#5bc0de");
    else
        $(obj).css("color", "#333333");
}

function GetDX(type) {
    var result = "";
    $("#div" + type + "Text").find("li").each(function (i) {
        if ($(this).css("color") !== "rgb(51, 51, 51)")
            result += i + ",";
    });
    return result.substr(0, result.length - 1);
}

function SetDX(type, value) {
    var result = "";
    var values = value.split(',');
    $("#div" + type + "Text").find("li").each(function (i) {
        if (values.contains(i))
            $(this).css("color", "#5bc0de");
    });
    return result.substr(0, result.length - 1);
}

function GetCZFS() {
    if ($("#imgZTCZ").css("background-position") === "-67px -57px")
        return "0";
    else
        return "1";
}

function SetCZFS(CZFS) {
    if (CZFS === 0) {
        $("#imgZTCZ").css("background-position", "-67px -57px");
        $("#imgDJCZ").css("background-position", "-67px 0px");
    }
    else {
        $("#imgZTCZ").css("background-position", "-67px 0px");
        $("#imgDJCZ").css("background-position", "-67px -57px");
    }
}

function LoadFC_DZFJBXX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC_DZF/LoadFC_DZFJBXX",
        dataType: "json",
        data:
        {
            FC_DZFJBXXID: getUrlParam("FC_DZFJBXXID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                var jsonObj = new JsonDB("myTabContent");
                jsonObj.DisplayFromJson("myTabContent", xml.Value.FC_DZFJBXX);
                jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
                $("#FC_DZFJBXXID").val(xml.Value.FC_DZFJBXX.FC_DZFJBXXID);
                //设置编辑器的内容
                ue.ready(function () {
                    ue.setHeight(200);
                    ue.setContent(xml.Value.FC_DZFJBXX.FYMS);
                });
                //SetCZFS(xml.Value.FWCZXX.CZFS);
                $("#spanFWLX").html(xml.Value.FC_DZFJBXX.FWLX);
                $("#spanZJDW").html(xml.Value.FC_DZFJBXX.ZJDW);
                $("#JYGZ").html(xml.Value.FC_DZFJBXX.JYGZ);
                LoadPhotos(xml.Value.Photos);
                return;
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function MouseOver() {
    isleave = false;
}

function MouseLeave() {
    isleave = true;
}

function FB() {
    if (AllValidate() === false) return;
    var jsonObj = new JsonDB("myTabContent");
    var obj = jsonObj.GetJsonObject();
    //手动添加如下字段
    obj = jsonObj.AddJson(obj, "FWLX", "'" + $("#spanFWLX").html() + "'");
    obj = jsonObj.AddJson(obj, "ZJDW", "'" + $("#spanZJDW").html() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");

    if (getUrlParam("FC_DZFJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "FC_DZFJBXXID", "'" + getUrlParam("FC_DZFJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FC_DZF/FB",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            FYMS: ue.getContent(),
            FWZP: GetPhotoUrls(),
            JYGZ: $("#JYGZ").val()
        },
        success: function (xml) {
            if (xml.Result === 1) {
                window.location.href = getRootPath() + "/Business/FBCG/FBCG";
            } else {
                if (xml.Type === 1) {
                    $("#YZM").css("border-color", "#F2272D");
                    $("#YZMInfo").css("color", "#F2272D");
                    $("#YZMInfo").html(xml.Message);
                }
                if (xml.Type === 2) {
                    $("#YHM").css("border-color", "#F2272D");
                    $("#YHMInfo").css("color", "#F2272D");
                    $("#YHMInfo").html(xml.Message);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}