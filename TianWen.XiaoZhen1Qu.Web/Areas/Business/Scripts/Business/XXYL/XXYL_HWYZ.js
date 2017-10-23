$(document).ready(function () {

});

//验证所有
function ValidateAll() {
    if (ValidateBT() & ValidateZP() & ValidateLXR() & ValidateLXDH())
        return true;
    else
        return false;
}
