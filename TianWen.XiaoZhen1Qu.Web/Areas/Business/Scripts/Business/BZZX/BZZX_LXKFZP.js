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

function BindToolBar() {
    BindMouseHover();
    BindUlImgEdit();
    BindUlImgDelete();
}

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
}

function BindUlImgEdit() {
    $(".ulImgs").find(".edit").each(function (i) {
        $(this).unbind("click");
        $(this).bind("click", function () {
            $(window.parent.document).find("#shadow").each(function () {
                $(this).css("width", window.parent.document.body.clientWidth);
                $(this).css("height", window.parent.document.body.clientHeight);
                $(this).css("display", "block");
            });
            $(window.parent.document).find("#editImgWindow").each(function () {
                $(this).css("display", "block");
            });

            var c = $(window.parent.document).find("#canvas")[0];
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
}

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
function Upload() {
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
        alert("上传图片不能大于4张");
    }
    BindToolBar();
}

function GetPhotoUrls() {
    var photourls = "";
    $(".ulImgs").find("img").each(function () {
        var src = $(this).attr("src");
        if (src.indexOf('?') !== -1)
            photourls += src.substr(0, src.indexOf('?')) + ",";
        else
            photourls += src + ",";
    });
    return RTrim(photourls);
}