$(document).ready(function () {

});

//验证所有
function AllValidate() {
    if (ValidateBT() & ValidateFWZP() & ValidateLXR() & ValidateLXDH())
        return true;
    else
        return false;
}
