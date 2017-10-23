$(document).ready(function () {

});
//验证标题

//验证所有
function ValidateAll() {
    if (ValidateBT() & ValidateLXR() & ValidateLXDH())
        return true;
    else
        return false;
}
