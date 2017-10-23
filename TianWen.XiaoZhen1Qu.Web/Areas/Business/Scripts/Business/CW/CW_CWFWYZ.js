$(document).ready(function () {
    $("#JG").bind("blur", ValidateJG);
    $("#JG").bind("focus", InfoJG);
});


//验证所有
function ValidateAll() {
    if (ValidateJG() & ValidateBT() & ValidateZP() & ValidateLXR() & ValidateLXDH())
        return true;
    else
        return false;
}

