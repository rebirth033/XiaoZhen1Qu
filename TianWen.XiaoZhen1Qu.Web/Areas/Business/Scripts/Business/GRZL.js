﻿$(document).ready(function () {
    $("#spanSYWXTX").css("color", "#5bc0de");
    $("#spanSYWXTX").css("font-weight", "700");
    $("#emSYWXTX").css("background-color", "#5bc0de");
    $("#emSYWXTX").css("height", "2px");
    $("#btnTBWXTX").css("display", "block");
    $(".divstep").bind("click", HeadActive);
    $(".li_main_photo_middle_xt").bind("click", LoadSystemPhoto);
    $("#btnXTSC").bind("click", SaveXTTX);
    $("#btnBDSC").bind("change", Upload);
    $("#img_person_info_yhm").bind("click", UpdateYHM);
    $("#span_person_info_right_yhm").bind("click", UpdateYHM);
    $("#img_person_info_sj").bind("click", UpdateSJ);
    $("#span_person_info_right_sj").bind("click", UpdateSJ);
    $("#img_person_info_yx").bind("click", UpdateYX);
    $("#span_person_info_right_yx").bind("click", UpdateYX);
    LoadGRZL();
});

function HeadActive() {
    Load(this.id.substr(3, this.id.length - this.id.indexOf('div')));
    $(".divstep").each(function () {
        $(this).find("span").each(function () {
            $(this).css("color", "#cccccc");
            $(this).css("font-weight", "normal");
        });
        $(this).find("em").each(function () {
            $(this).css("height", "1px");
            $(this).css("background-color", "#cccccc");
        });
    });
    $(this).find("span").each(function () {
        $(this).css("color", "#5bc0de");
        $(this).css("font-weight", "700");
    });
    $(this).find("em").each(function () {
        $(this).css("height", "2px");
        $(this).css("background-color", "#5bc0de");
    });
}

function Load(type) {
    if (type === "SYWXTX") {
        $("#btnTBWXTX").css("display", "block");
        $("#btnBDSC").css("display", "none");
        $("#btnXTSC").css("display", "none");
        $("#div_main_photo_middle").css("display", "none");
        $("#div_main_photo_middle_xt").css("display", "none");
        LoadGRZL();
    }
    if (type === "BDSC") {
        $("#btnTBWXTX").css("display", "none");
        $("#btnBDSC").css("display", "block");
        $("#btnXTSC").css("display", "none");
        $("#div_main_photo_middle").css("display", "block");
        $("#div_main_photo_middle_xt").css("display", "none");
        LoadGRZL();
    }
    if (type === "XTTX") {
        $("#btnTBWXTX").css("display", "none");
        $("#btnBDSC").css("display", "none");
        $("#btnXTSC").css("display", "block");
        $("#div_main_photo_middle").css("display", "none");
        $("#div_main_photo_middle_xt").css("display", "block");
        LoadGRZL();
    }
}

function LoadSystemPhoto() {
    $(this).find("img").each(function () {
        $("#img_main_photo").attr("src", (this.src));
    });
}

function SaveXTTX() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/GRZL/SaveXTTX",
        dataType: "json",
        data:
        {
            TX: $("#img_main_photo").attr("src"),
            YHID: getUrlParam("YHID")
        },
        success: function (xml) {
            if (xml.Result === 1) {
                alert("头像上传成功");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

function LoadGRZL() {
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Business/GRZL/GetGRZL",
        dataType: "json",
        data:
        {
            YHID: getUrlParam("YHID")
        },
        success: function (xml) {
            $("#img_main_photo").attr("src", getRootPath() + "/Areas/Business/Photos/" + getUrlParam("YHID") + "/GRZL/" + xml.YHJBXX.TX + "?j=" + Math.random());
            $("#img_main_photo_middle").attr("src", getRootPath() + "/Areas/Business/Photos/" + getUrlParam("YHID") + "/GRZL/" + xml.YHJBXX.TX + "?j=" + Math.random());
            $("#input_person_info_yhm").val(xml.YHJBXX.YHM);
            $("#input_person_info_sj").val(xml.YHJBXX.SJ);
            $("#input_person_info_yx").val(xml.YHJBXX.DZYX);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

        }
    });
}

//上传照片
function Upload() {
    var f = $(this).get(0).files[0];
    var reader = new FileReader();
    reader.readAsDataURL(f);
    reader.onload = function (theFile) {
        var image = new Image();
        image.src = theFile.target.result;
        image.onload = function () {
            var form = $("#form_button_main_photo");
            var formData = new FormData(form);
            formData.append('Filedata', f);
            formData.append('width', this.width);
            formData.append('height', this.height);
            formData.append('yhid', getUrlParam("YHID"));
            formData.append('type', "GRZL");
            formData.append('filename', "TX");
            var xhr = new XMLHttpRequest();
            xhr.addEventListener("load", uploadComplete, false);
            xhr.open('POST', getRootPath() + "/Areas/Business/Ashx/SaveGRZLPhotos.Ashx");
            xhr.send(formData);
        };
    };
}
//上传完成事件
function uploadComplete(evt) {
    var imagepath = getRootPath() + "/Areas/Business/Photos/" + getUrlParam("YHID") + "/GRZL/" + evt.target.responseText;
    $("#img_main_photo").attr("src", imagepath + "?j=" + Math.random());
    $("#img_main_photo_middle").attr("src", imagepath + "?j=" + Math.random());
}

function UpdateYHM() {
    if ($("#span_person_info_right_yhm").html() === "修改") {
        $("#input_person_info_yhm").css("border", "1px solid #cccccc");
        $("#input_person_info_yhm").css("cursor", "text");
        $("#input_person_info_yhm").removeAttr("readonly");
        $("#span_person_info_right_yhm").html("确认");
    } else {
        $.ajax({
            type: "POST",
            url: getRootPath() + "/Business/GRZL/UpdateYHM",
            dataType: "json",
            data:
            {
                YHM: $("#input_person_info_yhm").val(),
                YHID: getUrlParam("YHID")
            },
            success: function (xml) {
                if (xml.Result === 1) {
                    alert("修改成功");
                    $("#input_person_info_yhm").css("border", "none");
                    $("#input_person_info_yhm").css("cursor", "default");
                    $("#input_person_info_yhm").attr("readonly", "readonly");
                    $("#span_person_info_right_yhm").html("修改");
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { //有错误时的回调函数

            }
        });
       
    }
}

function UpdateSJ() {
    window.location.href = getRootPath() + "/Business/GRZL/HBSJ?SJ=" + $("#input_person_info_sj").val() + "&YHID=" + getUrlParam("YHID");
}

function UpdateYX() {
    window.location.href = getRootPath() + "/Business/GRZL/YXYZ?YX=" + $("#input_person_info_yx").val() + "&YHID=" + getUrlParam("YHID");
}