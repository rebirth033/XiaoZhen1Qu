var isleave = true;
$(document).ready(function () {
    $("#XQMC").bind("keyup", LoadXQMC);
    $("#spanCXLB").bind("click", CXLB);
    $("#imgZTCZ").bind("click", ZTCZSelect);
    $("#imgDJCZ").bind("click", DJCZSelect);
    $("#divUploadOut").bind("mouseover", GetUploadCss);
    $("#divUploadOut").bind("mouseleave", LeaveUploadCss);
    $("#btnFB").bind("click", FB);
    $("#FYMS").bind("focus", FYMSFocus);
    $("#FYMS").bind("blur", FYMSBlur);
    $("#KRZSJ").datepicker({ minDate: 0 });
    $("#inputUpload").bind("change", Upload);
    $("#btnClose").bind("click", CloseWindow);
    $("#span_xzdz").bind("click", OpenXZDZ);
    $("#div_dz_close").bind("click", CloseWindow);

    BindHover();
    LoadFWLX();
    LoadZJDW();
    LoadDefault();
    FYMSSetDefault();
});

function FYMSFocus() {
    $("#FYMS").css("color", "#333333");
}

function FYMSBlur() {
    $("#FYMS").css("color", "#999999");
}

function FYMSSetDefault() {
    var fyms = "1.房屋特征：\r\n\r\n2.周边配套：\r\n\r\n3.房东心态：";
    $("#FYMS").html(fyms);
}

function LoadDefault() {
    $("#imgZTCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgDJCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}

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

function CXLB() {
    window.location.href = getRootPath() + "/Business/LBXZ/LBXZ";
}

function ZTCZSelect() {
    $("#imgZTCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
    $("#imgDJCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
}

function DJCZSelect() {
    $("#imgZTCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_gray.png");
    $("#imgDJCZ").attr("src", getRootPath() + "/Areas/Business/Css/images/radio_blue.png");
}

function LoadXQMC() {
    if (event.keyCode === 40) {//按下
        var lis = $("#divXQMClist").find("li");
        for (var i = 0; i < lis.length; i++) {
            if ($("#divXQMClist").find("li:eq(" + i + ")").css("background-color") === "rgb(236, 236, 236)") {
                $("#divXQMClist").find("li:eq(" + i + ")").css("background-color", "#FFFFFF");
                $("#divXQMClist").find("li:eq(" + i + ")").bind("mouseover", function () { $(this).css("background-color", "#ececec"); });
                $("#divXQMClist").find("li:eq(" + i + ")").bind("mouseleave", function () { $(this).css("background-color", "#FFFFFF"); });
                $("#divXQMClist").find("li:eq(" + (i + 1) + ")").css("background-color", "#ececec");
                return;
            }
        }
        $("#divXQMClist").find("li:eq(0)").css("background-color", "#ececec");
        return;
    }
    if (event.keyCode === 38) {//按上
        var lis = $("#divXQMClist").find("li");
        for (var i = 0; i < lis.length; i++) {
            if ($("#divXQMClist").find("li:eq(" + i + ")").css("background-color") === "rgb(236, 236, 236)") {
                if (i !== 0)
                    $("#divXQMClist").find("li:eq(" + (i - 1) + ")").css("background-color", "#ececec");
                $("#divXQMClist").find("li:eq(" + i + ")").css("background-color", "#FFFFFF");
                $("#divXQMClist").find("li:eq(" + i + ")").bind("mouseover", function () { $(this).css("background-color", "#ececec"); });
                $("#divXQMClist").find("li:eq(" + i + ")").bind("mouseleave", function () { $(this).css("background-color", "#FFFFFF"); });
                return;
            }
        }
        $("#divXQMClist").find("li:eq(" + (lis.length - 1) + ")").css("background-color", "#ececec");
        return;
    }
    if (event.keyCode === 13) {//回车
        var lis = $("#divXQMClist").find("li");
        for (var i = 0; i < lis.length; i++) {
            if ($("#divXQMClist").find("li:eq(" + i + ")").css("background-color") === "rgb(236, 236, 236)") {
                SelectXQMC($("#divXQMClist").find("li:eq(" + i + ")"));
                return;
            }
        }
    }
    var XQMC = $("#XQMC").val();
    if (XQMC === "") {
        $("#divXQMClist").css("display", "none");
        return;
    }
    if (ValidateChinese(XQMC)) //判断是否是汉字
        LoadXQJBXXSByHZ(XQMC);
    else
        LoadXQJBXXSByPY(XQMC);
}

function GetStartIndex(pys, sqmc) {
    var index = 0;
    for (var j = 0; j < pys.length; j++) {
        if (sqmc.length > pys[j].length) {
            if (sqmc.indexOf(pys[j]) !== -1) {
                index = j;
                break;;
            }
        }
        else {
            if (pys[j].indexOf(sqmc) !== -1 || pys[j].indexOf(sqmc) !== -1) {
                index = j;
                break;;
            }
        }
    }
    return index;
}

function GetStartIndexBySZM(pyszm, sqmc) {
    return pyszm.indexOf(sqmc);
}

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

function LoadFWCZXX() {
    //$.ajax({
    //    type: "POST",
    //    url: getRootPath() + "/Business/FC_FW/LoadFWCZXX",
    //    dataType: "json",
    //    data:
    //    {
    //        FWCZJBXXID: getUrlParam("FWCZJBXXID")
    //    },
    //    success: function (xml) {
    //        if (xml.Result === 1) {
    //            var jsonObj = new JsonDB("myTabContent");
    //            jsonObj.DisplayFromJson("myTabContent", xml.Value.FWCZXX);
    //            jsonObj.DisplayFromJson("myTabContent", xml.Value.JCXX);
    //            $("#FWCZJBXXID").val(xml.Value.FWCZXX.FWCZJBXXID);
    //            if (xml.Value.FWCZXX.ZJYBHFY !== null)
    //                SetDX("BHFY", xml.Value.FWCZXX.ZJYBHFY);
    //            if (xml.Value.FWCZXX.FWPZ !== null)
    //                SetDX("FWPZ", xml.Value.FWCZXX.FWPZ);
    //            if (xml.Value.FWCZXX.FWLD !== null)
    //                SetDX("FWLD", xml.Value.FWCZXX.FWLD);
    //            if (xml.Value.FWCZXX.CZYQ !== null)
    //                SetDX("CZYQ", xml.Value.FWCZXX.CZYQ);
    //            SetCZFS(xml.Value.FWCZXX.CZFS);
    //            $("#spanFWCX").html(xml.Value.FWCZXX.CX);
    //            $("#spanZXQK").html(xml.Value.FWCZXX.ZXQK);
    //            $("#spanZZLX").html(xml.Value.FWCZXX.ZZLX);
    //            $("#spanYFFS").html(xml.Value.FWCZXX.YFFS);
    //            $("#FYMS").html(xml.Value.FWCZXX.FYMS);
    //            if (xml.Value.FWCZXX.KRZSJ.ToString("yyyy-MM-dd") !== "1-1-1")
    //                $("#KRZSJ").val(xml.Value.FWCZXX.KRZSJ.ToString("yyyy-MM-dd"));
    //            LoadPhotos(xml.Value.Photos);
    //            return;
    //        }
    //    },
    //    error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

    //    }
    //});
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
    obj = jsonObj.AddJson(obj, "CX", "'" + $("#spanFWCX").html() + "'");
    obj = jsonObj.AddJson(obj, "ZXQK", "'" + $("#spanZXQK").html() + "'");
    obj = jsonObj.AddJson(obj, "ZZLX", "'" + $("#spanZZLX").html() + "'");
    obj = jsonObj.AddJson(obj, "YFFS", "'" + $("#spanYFFS").html() + "'");
    obj = jsonObj.AddJson(obj, "ZJYBHFY", "'" + GetDX("BHFY") + "'");
    obj = jsonObj.AddJson(obj, "FWPZ", "'" + GetDX("FWPZ") + "'");
    obj = jsonObj.AddJson(obj, "FWLD", "'" + GetDX("FWLD") + "'");
    obj = jsonObj.AddJson(obj, "CZYQ", "'" + GetDX("CZYQ") + "'");
    obj = jsonObj.AddJson(obj, "CZFS", "'" + GetCZFS() + "'");
    obj = jsonObj.AddJson(obj, "LBID", "'" + getUrlParam("CLICKID") + "'");
    if ($("#KRZSJ").val() !== "")
        obj = jsonObj.AddJson(obj, "KRZSJ", "'" + $("#KRZSJ").val() + "'");
    if (getUrlParam("FWCZJBXXID") !== null)
        obj = jsonObj.AddJson(obj, "FWCZJBXXID", "'" + getUrlParam("FWCZJBXXID") + "'");

    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/FWCZ/FB",
        dataType: "json",
        data:
        {
            Json: jsonObj.JsonToString(obj),
            FYMS: $("#FYMS").html(),
            FWZP: GetPhotoUrls()
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