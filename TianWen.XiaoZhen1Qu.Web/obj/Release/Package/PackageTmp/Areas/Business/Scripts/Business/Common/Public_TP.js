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
    if ($("#ulImgs1").find("img").length < 4)
        $("#ulImgs1").append("<li draggable='true' class='li_img'><img src='" + imagepath + "' class='divImg' /><div class='div_toolbar_wrap'><div class='delete'>删除</div><div class='edit'>预览</div></div></li>");
    else if ($("#ulImgs2").find("img").length < 4)
        $("#ulImgs2").append("<li draggable='true' class='li_img'><img src='" + imagepath + "' class='divImg' /><div class='div_toolbar_wrap'><div class='delete'>删除</div><div class='edit'>预览</div></div></li>");
    else if ($("#ulImgs3").find("img").length < 4)
        $("#ulImgs3").append("<li draggable='true' class='li_img'><img src='" + imagepath + "' class='divImg' /><div class='div_toolbar_wrap'><div class='delete'>删除</div><div class='edit'>预览</div></div></li>");
    else
        $("#ulImgs4").append("<li draggable='true' class='li_img'><img src='" + imagepath + "' class='divImg' /><div class='div_toolbar_wrap'><div class='delete'>删除</div><div class='edit'>预览</div></div></li>");
    ControlUpload();
    ValidateZP();
    BindToolBar();
}
//上传按钮控制
function ControlUpload() {
    if ($("#ulImgs4").find("img").length === 4) {
        $("#div_upload").css("background-color", "#ececec");
        $("#input_upload").attr("disabled", "disabled");
    } else {
        $("#div_upload").css("background-color", "#fff");
        $("#input_upload").removeAttr("disabled");
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
//加载图片
function LoadPhotos(photos) {
    if (photos.length > 0) {
        $("#divFWZPValue").css("display", "block");
        for (var i = 0; i < photos.length; i++) {
            if (i > 11)
                $("#ulImgs4").append("<li draggable='true' class='li_img'><img id='ulImgs4_" + (i + 1) + "' src='" + photos[i].PHOTOURL + "' class='divImg' /><div class='div_toolbar_wrap'><div class='delete'>删除</div><div class='edit'>预览</div></div></li>");
            if (i > 7 && i <= 11)
                $("#ulImgs3").append("<li draggable='true' class='li_img'><img id='ulImgs3_" + (i + 1) + "' src='" + photos[i].PHOTOURL + "' class='divImg' /><div class='div_toolbar_wrap'><div class='delete'>删除</div><div class='edit'>预览</div></div></li>");
            if (i > 3 && i <= 7)
                $("#ulImgs2").append("<li draggable='true' class='li_img'><img id='ulImgs2_" + (i + 1) + "' src='" + photos[i].PHOTOURL + "' class='divImg' /><div class='div_toolbar_wrap'><div class='delete'>删除</div><div class='edit'>预览</div></div></li>");
            if (i <= 3)
                $("#ulImgs1").append("<li draggable='true' class='li_img'><img id='ulImgs1_" + (i + 1) + "' src='" + photos[i].PHOTOURL + "' class='divImg' /><div class='div_toolbar_wrap'><div class='delete'>删除</div><div class='edit'>预览</div></div></li>");
        }
        BindToolBar();
        ControlUpload();
    }
}
//加载图片工具条
function BindToolBar() {
    BindUlImgEdit();
    BindUlImgDelete();
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

            img.src = $(this).parent().parent().find("img").attr("src");
            var id = $(this).parent().parent().find("img").attr("id");
            img.src = img.src.substr(0, img.src.length - img.src.indexOf('?') - 1);
            img.onload = function () //确保图片已经加载完毕  
            {
                cxt.clearRect(0, 0, c.width, c.height);
                var left = (c.width - img.width * 10) / 2;
                var top = (c.height - img.height * 10) / 2;
                cxt.drawImage(img, left, top, img.width * 10, img.height * 10);
                $("#rotateleft").bind("click", { src: img.src }, RotateLeft);
                $("#rotateright").bind("click", { src: img.src }, RotateRight);
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
            $(this).parent().parent("li").remove();
            if ($("#ulImgs2").find("li").length > 0) {
                $("#ulImgs1").append($("#ulImgs2").find("li:eq(0)")[0].outerHTML);
                $("#ulImgs2").find("li:eq(0)").remove();
            }
            if ($("#ulImgs3").find("li").length > 0) {
                $("#ulImgs2").append($("#ulImgs3").find("li:eq(0)")[0].outerHTML);
                $("#ulImgs3").find("li:eq(0)").remove();
            }
            if ($("#ulImgs4").find("li").length > 0) {
                $("#ulImgs3").append($("#ulImgs4").find("li:eq(0)")[0].outerHTML);
                $("#ulImgs4").find("li:eq(0)").remove();
            }
            ControlUpload();
            BindUlImgDelete();
        });
    });
    $("#ulImgs2").find(".delete").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $(this).parent().parent("li").remove();
            if ($("#ulImgs3").find("li").length > 0) {
                $("#ulImgs2").append($("#ulImgs3").find("li:eq(0)")[0].outerHTML);
                $("#ulImgs3").find("li:eq(0)").remove();
            }
            if ($("#ulImgs4").find("li").length > 0) {
                $("#ulImgs3").append($("#ulImgs4").find("li:eq(0)")[0].outerHTML);
                $("#ulImgs4").find("li:eq(0)").remove();
            }
            ControlUpload();
            BindUlImgDelete();
        });
    });
    $("#ulImgs3").find(".delete").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $(this).parent().parent("li").remove();
            if ($("#ulImgs4").find("li").length > 0) {
                $("#ulImgs3").append($("#ulImgs4").find("li:eq(0)")[0].outerHTML);
                $("#ulImgs4").find("li:eq(0)").remove();
            }
            ControlUpload();
            BindUlImgDelete();
        });
    });
    $("#ulImgs4").find(".delete").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $(this).parent().parent("li").remove();
            ControlUpload();
            BindUlImg4Delete();
        });
    });
}
//绑定图片点击删除事件_第一排
function BindUlImg1Delete() {
    $("#ulImgs1").find(".delete").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $(this).parent().parent("li").remove();
            if ($("#ulImgs2").find("li").length > 0) {
                $("#ulImgs1").append($("#ulImgs2").find("li:eq(0)")[0].outerHTML);
                $("#ulImgs2").find("li:eq(0)").remove();
            }
            if ($("#ulImgs3").find("li").length > 0) {
                $("#ulImgs2").append($("#ulImgs3").find("li:eq(0)")[0].outerHTML);
                $("#ulImgs3").find("li:eq(0)").remove();
            }
            if ($("#ulImgs4").find("li").length > 0) {
                $("#ulImgs3").append($("#ulImgs4").find("li:eq(0)")[0].outerHTML);
                $("#ulImgs4").find("li:eq(0)").remove();
            }
            ControlUpload();
        });
    });
}
//绑定图片点击删除事件_第二排
function BindUlImg2Delete() {
    $("#ulImgs2").find(".delete").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $(this).parent().parent("li").remove();
            if ($("#ulImgs3").find("li").length > 0) {
                $("#ulImgs2").append($("#ulImgs3").find("li:eq(0)")[0].outerHTML);
                $("#ulImgs3").find("li:eq(0)").remove();
            }
            if ($("#ulImgs4").find("li").length > 0) {
                $("#ulImgs3").append($("#ulImgs4").find("li:eq(0)")[0].outerHTML);
                $("#ulImgs4").find("li:eq(0)").remove();
            }
            ControlUpload();
        });
    });
}
//绑定图片点击删除事件_第三排
function BindUlImg3Delete() {
    $("#ulImgs3").find(".delete").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $(this).parent().parent("li").remove();
            if ($("#ulImgs4").find("li").length > 0) {
                $("#ulImgs3").append($("#ulImgs4").find("li:eq(0)")[0].outerHTML);
                $("#ulImgs4").find("li:eq(0)").remove();
            }
            ControlUpload();
        });
    });
}
//绑定图片点击删除事件_第四排
function BindUlImg4Delete() {
    $("#ulImgs4").find(".delete").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $(this).parent().parent("li").remove();
            ControlUpload();
        });
    });
}
//向右翻转
function RotateRight(obj) {
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
        var left = (c.width - img.width*10) / 2;
        var top = (c.height - img.height * 10) / 2;
        cxt.drawImage(img, left, top, img.width * 10, img.height * 10);
    }
}
//向左翻转
function RotateLeft(obj) {
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
        cxt.rotate((Math.PI / 180) * -90);//旋转角度
        cxt.translate(-x, -y);//将画布原点移动
        var left = (c.width - img.width * 10) / 2;
        var top = (c.height - img.height * 10) / 2;
        cxt.drawImage(img, left, top, img.width * 10, img.height * 10);
    }
}
//关闭图片编辑窗口
function CloseWindow() {
    $("#shadow").css("display", "none");
    $("#editImgWindow").css("display", "none");
    $("#editDZWindow").css("display", "none");
}
//激活上传按钮样式
function GetUploadCss() {
    $("#div_upload").css("border", "1px solid #bc6ba6");
}
//取消上传按钮样式
function LeaveUploadCss() {
    $("#div_upload").css("border", "1px solid #cccccc");
}