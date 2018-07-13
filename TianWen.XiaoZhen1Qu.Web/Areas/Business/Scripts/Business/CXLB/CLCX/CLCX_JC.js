var currentIndex = 1;
$(document).ready(function () {
    BindBodyNav();
    LoadCLCondition();
    LoadHot("CLXX_JC");
    BindClick("CL");
    BindClick("PL");
    BindClick("LC");
    BindClick("BSX");
    BindClick("CLYS");
    LoadJCPP();
});
//绑定下拉框
function BindClick(type) {
    $("#div" + type + "Span").click(function () {
        if (type === "CL") {
            LoadCODESByTYPENAME("轿车车龄", "CL", "CODES_CL", Bind, "CL", "CL", "");
        }
        if (type === "PL") {
            LoadCODESByTYPENAME("轿车排量", "PL", "CODES_CL", Bind, "PL", "PL", "");
        }
        if (type === "LC") {
            LoadCODESByTYPENAME("轿车里程", "LC", "CODES_CL", Bind, "LC", "LC", "");
        }
        if (type === "BSX") {
            LoadCODESByTYPENAME("轿车变速箱", "BSX", "CODES_CL", Bind, "BSX", "BSX", "");
        }
        if (type === "CLYS") {
            LoadCODESByTYPENAME("轿车颜色", "CLYS", "CODES_CL", Bind, "CLYS", "CLYS", "");
        }
    });
}
//加载条件
function LoadCLCondition() {
    LoadConditionByTypeNames("'轿车品牌','轿车价格'", "CODES_CL", "品牌,价格", "PP,JG", "20,100");
}
//根据TYPENAME获取字典表
function LoadConditionByTypeNames(typenames, table, names, ids, lengths) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAMES",
        dataType: "json",
        data:
        {
            TYPENAMES: typenames,
            TBName: table
        },
        success: function (xml) {
            if (xml.Result === 1) {
                LoadDistrictCondition(xml.districts, "QY");
                var typelist = typenames.split(',');
                var namelist = names.split(',');
                for (var i = 0; i < typelist.length; i++) {
                    for (var j = 0; j < namelist.length; j++) {
                        if (typelist[i].indexOf(namelist[j]) !== -1) {
                            LoadCondition(_.filter(xml.list, function (value) { return typelist[i].indexOf(value.TYPENAME) !== -1; }), namelist[j], ids.split(',')[j], lengths.split(',')[j]);
                        }
                    }
                }
                if (typenames.indexOf("轿车品牌") !== -1)
                    LoadCondition(xml.jclist, "品牌", "PP", 20);
                LoadURLCondition();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载URL查询条件
function LoadURLCondition() {
    if (getUrlParam("JG") !== null)
        SelectURLCondition(getUrlParam("JG"));
    else if (getUrlParam("PP") !== null) {
        SelectURLCondition(getUrlParam("PP"));
        LoadConditionByParentID(getUrlParam("PP"), "CODES_CL_JC", "车系", "CX");
    }
    else if (getUrlParam("QY") !== null)
        SelectURLCondition(getUrlParam("QY"));
    else
        LoadBody("CLXX_JC", currentIndex);
}
//选择条件
function SelectCondition(obj, name) {
    if (name === "品牌") {
        LoadConditionByParentID(obj.id, "CODES_CL_JC", "车系", "CX", 100);
    }
    $(obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(obj).addClass("li_condition_body_active");
    LoadBody("CLXX_JC", currentIndex);
    ShowSelectCondition("CLXX_JC");
}
//选择品牌条件
function SelectPPCondition(obj) {

    LoadConditionByParentID(obj.id, "CODES_CL_JC", "车系", "CX", 100);
    return;
    $("#ul_condition_body_PP").find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $(".li_condition_body_more").remove();
    $("#li_condition_body_more").remove();
    
    var hasPP = 0;
    $("#ul_condition_body_PP").find(".li_condition_body").each(function(){
        if(this.id == obj.id){
	    hasPP = 1;
        }
    });
    if(hasPP === 0)
        $("#ul_condition_body_PP").append('<li class="li_condition_body li_condition_body_more" id="' + obj.id + '" onclick="SelectCondition(this,\'品牌\')">'+obj.innerHTML+'</li>');
    $("#ul_condition_body_PP").append('<li id="li_condition_body_more" class="li_condition_body" onclick="MorePP()" style="color:#2274e0;">更多<img id="span_select_arrow_blue" class="span_select_arrow_blue" /></li>');
    
    $("#"+obj.id).addClass("li_condition_body_active");

    LoadBody("CLXX_JC", currentIndex);
    ShowSelectCondition("CLXX_JC");
}
//选择URL条件
function SelectURLCondition(obj) {
    $("#" + obj).parent().find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    $("#" + obj).addClass("li_condition_body_active");
    LoadBody("CLXX_JC", currentIndex);
    ShowSelectCondition("CLXX_JC");
}
//选择下拉框
function SelectDropdown(obj, type) {
    $("#span" + type).html(obj.innerHTML);
    $("#div" + type).css("display", "none");
    LoadBody("CLXX_JC", currentIndex);
    ShowSelectCondition("CLXX_JC");
}
//加载查询条件
function LoadCondition(array, name, id, length) {
    $("#ul_condition_body_" + id).remove();
    var html = "";
    html += '<ul id="ul_condition_body_' + id + '" class="ul_condition_body" style="height:auto;">';
    if (name === "类别" || name === "小类" || name === "品牌" || name === "车系")
        html += '<li id="li_condition_body_first_' + id + '" class="li_condition_body_first">' + name + '</li>';
    else
        html += '<li class="li_condition_body_first">' + name + '</li>';
    html += '<li id="0" class="li_condition_body li_condition_body_active" onclick="SelectCondition(this,\'' + name + '\')">全部</li>';
    for (var i = 0; i < (array.length > length ? length : array.length) ; i++) {
            html += '<li id="' + array[i].CODEID + '" class="li_condition_body" onclick="SelectCondition(this,\'' + name + '\')">' + array[i].CODENAME + '</li>';
    }
    if(name === "品牌")
        html += '<li id="li_condition_body_more" class="li_condition_body" onclick="MorePP()" style="color:#2274e0;">更多<img id="span_select_arrow_blue" class="span_select_arrow_blue" /></li>';
    html += '</ul>';
    $("#div_condition_body_" + id).append(html);
    $("#span_select_arrow_blue").attr("src", getRootPath() + "/Areas/Business/Css/images/arrow_down_blue.png");
    if(name === "车系")
        $("#li_condition_body_first_" + id).css("height", (parseInt($("#div_condition_body_" + id).css("height")) - 0));
    else
        $("#li_condition_body_first_" + id).css("height", (parseInt($("#div_condition_body_" + id).css("height")) - 20));
}
//更多品牌
function MorePP(){
    if($("#span_select_arrow_blue").attr("src").indexOf('down') !== -1){
        $("#span_select_arrow_blue").attr("src", getRootPath() + "/Areas/Business/Css/images/arrow_up_blue.png" + "?j=" + Math.random());
	$(".div_row_right_jcpp_item").css("display","block");
    }
    else{
        $("#span_select_arrow_blue").attr("src", getRootPath() + "/Areas/Business/Css/images/arrow_down_blue.png" + "?j=" + Math.random());
        $(".div_row_right_jcpp_item").css("display","none");
    }
    GoToBQ('A');
}
//加载品牌名称
function LoadJCPP() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Common/LoadCODESByTYPENAME",
        dataType: "json",
        data:
        {
            TYPENAME: "轿车品牌",
            TBName: "CODES_CL_JC"
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#div_row_right_jcpp_first").html('');
                var html = "";
                html += '<div class="div_row_right_jcpp_first_left">';
                html += '<ul class="ul_row_right_jcpp_first_left">';
                for (var i = 0; i < BQArray.length; i++) {
                    var count = 0;
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            count++;
                    }
                    if (count !== 0)
                        html += '<li onmouseover="GoToBQ(\'' + BQArray[i] + '\')" class="li_row_right_jcpp_first_left">' + BQArray[i] + '</li>';
                }
                html += '</ul>';
                html += '</div>';

                html += '<div class="div_row_right_jcpp_first_right">';
                
                for (var i = 0; i < BQArray.length; i++) {
		    html += '<ul id="ul_row_right_jcpp_first_right_' + BQArray[i] + '" class="ul_row_right_jcpp_first_right">';
                    var count = 0;
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            count++;
                    }
                    for (var j = 0; j < xml.list.length; j++) {
                        if (BQArray[i] === xml.list[j].CODEVALUE)
                            html += '<li id="'+xml.list[j].CODEID+'" onclick="SelectPPCondition(this)" class="li_row_right_jcpp_first_right_value">' + xml.list[j].CODENAME + '</li>';
                    }
                    html += '</ul>';
                }

                html += '</div>';

                $("#div_row_right_jcpp_first").append(html);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//跳转到标签页
function GoToBQ(BQ){
    $(".ul_row_right_jcpp_first_right").css("display","none");
    $("#ul_row_right_jcpp_first_right_"+BQ).css("display","block");
}
//加载主体部分
function LoadBody(TYPE, PageIndex) {
    currentIndex = parseInt(PageIndex);
    var condition = GetAllCondition("PP,CX,JG,PL,LC,BSX,CLYS,SF,CL");
    $.ajax({
        type: "POST",
        url: getRootPath() + "/CLCX/LoadCLXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: condition,
            PageSize: 100,
            PageIndex: PageIndex
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#ul_body_left").html('');
                LoadPage(TYPE, xml.PageCount);
                for (var i = 0; i < xml.list.length; i++) {
                    LoadCL_JCInfo(xml.list[i]);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}
//加载车辆_轿车单条信息
function LoadCL_JCInfo(obj) {
    var html = "";
    html += ('<li class="li_body_left" onclick="OpenXXXX(\'CLXX_JC\',\'' + obj.ID + '\')">');
    html += ('<div class="div_li_body_left_left">');
    html += ('<img class="img_li_body_left" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<div class="div_img_li_body_left_count"><span>' + obj.PHOTOS.length + '图</span></div>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_center">');
    html += ('<p class="p_li_body_left_center_bt">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_left_center_cs">' + obj.SPNF + ' / ' + obj.XSLC + '万公里' + ' / ' + '2.0升' + ' / ' + (obj.BT.indexOf('手动') !== -1 ? "手动" : "自动") + '</p>');
    html += ('<p class="p_li_body_left_center_dz">' + obj.ZXGXSJ.ToString("MM月dd日") + '</p>');
    html += ('</div>');
    html += ('<div class="div_li_body_left_right">');
    html += ('<p class="p_li_body_left_right"><span class="span_zj">' + obj.JG + '</span>万元</p>');
    html += ('</div>');
    html += ('</li>');
    $("#ul_body_left").append(html);
}
//加载热门推荐
function LoadHot(TYPE) {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/CLCX/LoadCLXX",
        dataType: "json",
        data:
        {
            TYPE: TYPE,
            Condition: "STATUS:1",
            PageSize: 10,
            PageIndex: 1
        },
        success: function (xml) {
            if (xml.Result === 1) {
                $("#ul_body_right").html('');
                for (var i = 0; i < xml.list.length; i++) {
                    LoadHotInfo(xml.list[i]);
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}
//加载热门单条信息
function LoadHotInfo(obj) {
    var html = "";
    html += ('<li onclick="OpenXXXX(\'CLXX_JC\',\'' + obj.ID + '\')" class="li_body_right">');
    html += ('<img class="img_li_body_right" src="' + getRootPath() + "/Areas/Business/Photos/" + obj.YHID + "/" + obj.PHOTOS[0].PHOTONAME + "?j=" + Math.random() + '" />');
    html += ('<p class="p_li_body_right_xq">' + obj.BT + '</p>');
    html += ('<p class="p_li_body_right_cs">' + obj.SPNF + ' / ' + '2.0升' + ' / ' + '自动' + '</p>');
    html += ('<p class="p_li_body_right_jg">' + obj.JG + '万元</p>');
    html += ('</li>');
    $("#ul_body_right").append(html);
}
//根据条件查询
function SearchByCondition(type) {
    $("#ul_condition_body_SF").find(".li_condition_body").each(function () {
        $(this).removeClass("li_condition_body_active");
    });
    if (type === "GR")
        $("#ul_condition_body_SF").find(".li_condition_body:eq(1)").addClass("li_condition_body_active");
    if (type === "SJ")
        $("#ul_condition_body_SF").find(".li_condition_body:eq(2)").addClass("li_condition_body_active");
    LoadBody("CLXX_JC", 1);
}
function insertHtmlAtCaret(html) {
    var sel, range;
    if (window.getSelection) {
        sel = window.getSelection();
        if (sel.getRangeAt && sel.rangeCount) {
                range = sel.getRangeAt(0);
                range.deleteContents();
                var el = document.createElement("div");
                el.innerHTML = html;
                var frag = document.createDocumentFragment(), node, lastNode;
                while ( (node = el.firstChild) ) {
                lastNode = frag.appendChild(node);
            }
            range.insertNode(frag);
            if (lastNode) {
                range = range.cloneRange();
                range.setStartAfter(lastNode);
                range.collapse(true);
                sel.removeAllRanges();
                sel.addRange(range);
            }
        }
    } else if (document.selection && document.selection.type != "Control") {
        // IE < 9
        document.selection.createRange().pasteHTML(html);
    }
}