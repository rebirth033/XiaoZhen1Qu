//激活上传按钮样式
function GetUploadCss() {
    $("#div_upload").css("border-color", "#5bc0de");
}
//取消上传按钮样式
function LeaveUploadCss() {
    $("#div_upload").css("border-color", "#cccccc");
}
//加载图片
function LoadPhotos(photos) {
    if (photos.length > 0) {
        $("#divFWZPValue").css("display", "block");
        if (photos.length > 4)
            $("#divLXRXX").css("margin-top", "300px");
        for (var i = 0; i < photos.length; i++) {
            if (i > 3)
                $("#ulImgs2").append("<li draggable='true' class='li_img'><img id='ulImgs2_" + (i + 1) + "' src='" + photos[i].PHOTOURL + "' class='divImg' /><div class='div_toolbar_wrap'><div class='opacity'></div><div class='toolbar'><a class='edit'></a><a class='delete'></a></div></div></li>");
            else
                $("#ulImgs1").append("<li draggable='true' class='li_img'><img id='ulImgs1_" + (i + 1) + "' src='" + photos[i].PHOTOURL + "' class='divImg' /><div class='div_toolbar_wrap'><div class='opacity'></div><div class='toolbar'><a class='edit'></a><a class='delete'></a></div></div></li>");
        }
        BindToolBar();
    }
}
//加载图片工具条
function BindToolBar() {
    BindMouseHover();
    BindUlImgEdit();
    BindUlImgDelete();
}
//绑定图片鼠标浮动事件
function BindMouseHover() {
    $("#ulImgs1").find("img").each(function (i) {
        $(this).bind("mouseover", function () {
            $(this).next().css("display", "block");
        });
        $("#ulImgs1").find(".div_toolbar_wrap").each(function () {
            $(this).bind("mouseleave", function () {
                $(this).css("display", "none");
            });
        });
    });
    $("#ulImgs2").find("img").each(function (i) {
        $(this).bind("mouseover", function () {
            $(this).next().css("display", "block");
        });
        $("#ulImgs2").find(".div_toolbar_wrap").each(function () {
            $(this).bind("mouseleave", function () {
                $(this).css("display", "none");
            });
        });
    });
}
//绑定图片点击编辑事件
function BindUlImgEdit() {
    $(".ulImgs").find(".edit").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $("#shadow").css("display", "block");
            $("#editImgWindow").css("display", "block");
            var c = $("#canvas")[0];
            var cxt = c.getContext("2d");
            var img = new Image();
            img.src = $(this).parent().parent().parent().find("img").attr("src");
            var id = $(this).parent().parent().parent().find("img").attr("id");
            img.src = img.src.substr(0, img.src.length - img.src.indexOf('?') - 1);
            img.onload = function () //确保图片已经加载完毕  
            {
                cxt.clearRect(0, 0, c.width, c.height);
                var left = (c.width - img.width) / 2;
                var top = (c.height - img.height) / 2;
                cxt.drawImage(img, left, top, img.width, img.height);
                $("#rotate").bind("click", { src: img.src }, Rotate);
                $("#btnSavePhoto").bind("click", { src: img.src, id: id }, SavePhoto);
            }
        });
    });
}
//绑定图片点击删除事件
function BindUlImgDelete() {
    $("#ulImgs1").find(".delete").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $(this).parent().parent().parent("li").remove();
            if ($("#ulImgs2").find("li").length > 0) {
                $("#ulImgs1").append($("#ulImgs2").find("li:eq(0)")[0].outerHTML);
                $("#ulImgs2").find("li:eq(0)").remove();
                BindMouseHover();
                ControlUpload();
                BindUlImg1Delete();
            }
        });
    });
    $("#ulImgs2").find(".delete").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $(this).parent().parent().parent("li").remove();
            BindMouseHover();
            ControlUpload();
            BindUlImg2Delete();
        });
    });
}
//绑定图片点击编辑事件_第一排
function BindUlImg1Delete() {
    $("#ulImgs1").find(".delete").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $(this).parent().parent().parent("li").remove();
            if ($("#ulImgs2").find("li").length > 0) {
                $("#ulImgs1").append($("#ulImgs2").find("li:eq(0)")[0].outerHTML);
                $("#ulImgs2").find("li:eq(0)").remove();
                BindMouseHover();
                ControlUpload();
            }
        });
    });
}
//绑定图片点击编辑事件_第二排
function BindUlImg2Delete() {
    $("#ulImgs2").find(".delete").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $(this).parent().parent().parent("li").remove();
            BindMouseHover();
            ControlUpload();
        });
    });
}
//翻转
function Rotate(obj) {
    var c = $("#canvas")[0];
    var cxt = c.getContext("2d");
    var x = c.width / 2; //画布宽度的一半
    var y = c.height / 2;//画布高度的一半

    var img = new Image();
    img.src = obj.data.src;
    img.onload = function () //确保图片已经加载完毕  
    {
        cxt.clearRect(0, 0, c.width, c.height);
        cxt.translate(x, y);//将绘图原点移到画布中点
        cxt.rotate((Math.PI / 180) * 90);//旋转角度
        cxt.translate(-x, -y);//将画布原点移动
        var left = (c.width - img.width) / 2;
        var top = (c.height - img.height) / 2;
        cxt.drawImage(img, left, top, img.width, img.height);
    }

}
//保存照片
function SavePhoto(obj) {
    var filepath = obj.data.src;
    var c = $("#canvas")[0];
    var data = c.toDataURL();
    var b64 = data.substring(22);
    $.ajax({
        type: "POST",
        url: getRootPath() + "/Areas/Business/Ashx/SavePhotos.Ashx",
        dataType: "json",
        data:
        {
            data: b64,
            filepath: filepath
        },
        success: function (xml) {

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $("#shadow").css("display", "none");
            $("#editImgWindow").css("display", "none");
            $("#" + obj.data.id).attr("src", obj.data.src + "?t=" + Math.random());
        }
    });
}
//上传照片
function UploadZP() {
    $("#divFWZPValue").css("display", "block");
    var f = $(this).get(0).files[0];
    var reader = new FileReader();
    reader.readAsDataURL(f);
    reader.onload = function (theFile) {
        var image = new Image();
        image.src = theFile.target.result;
        image.onload = function () {
            var form = $("#myform");
            var formData = new FormData(form);
            formData.append('Filedata', f);
            formData.append('width', this.width);
            formData.append('height', this.height);
            var xhr = new XMLHttpRequest();
            xhr.addEventListener("load", uploadComplete, false);
            xhr.open('POST', getRootPath() + "/Areas/Business/Ashx/SavePhotos.Ashx");
            xhr.send(formData);
        };
    };
}
//上传完成事件
function uploadComplete(evt) {
    var imagepath = getRootPath() + "/Areas/Business/Photos/" + evt.target.responseText;
    if ($("#ulImgs1").find("img").length < 4) {
        $("#ulImgs1").append("<li draggable='true' class='li_img'><img src='" + imagepath + "' class='divImg' /><div class='div_toolbar_wrap'><div class='opacity'></div><div class='toolbar'><a class='edit'></a><a class='delete'></a></div></div></li>");

    }
    else {
        $("#divLXRXX").css("margin-top", "300px");
        $("#ulImgs2").append("<li draggable='true' class='li_img'><img src='" + imagepath + "' class='divImg' /><div class='div_toolbar_wrap'><div class='opacity'></div><div class='toolbar'><a class='edit'></a><a class='delete'></a></div></div></li>");
    }
    ControlUpload();
    ValidateZP();
    BindToolBar();
}
//上传按钮控制
function ControlUpload() {
    if ($("#ulImgs2").find("img").length === 4) {
        $("#div_upload").css("background-color", "#ececec");
        $("#input_upload").attr("disabled", "disabled");
    } else {
        $("#div_upload").css("background-color", "#fff");
        $("#input_upload").removeAttr("disabled");
    }
}
//关闭图片编辑窗口
function CloseWindow() {
    $("#shadow").css("display", "none");
    $("#editImgWindow").css("display", "none");
    $("#editDZWindow").css("display", "none");
}