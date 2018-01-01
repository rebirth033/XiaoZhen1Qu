$(document).ready(function () {
    $("#divYLGZS").find(".div_radio").bind("click", function () { ValidateRadio("YLGZS", ""); });
    $("#divPSDD").find(".div_radio").bind("click", function () { ValidateRadio("PSDD", ""); });
    $("#divFWBZ").find(".div_radio").bind("click", function () { ValidateRadio("FWBZ", ""); });
    $("#divFZSFFQ").find(".div_radio").bind("click", function () { ValidateRadio("FZSFFQ", ""); });
    $("#divFZPSSF").find(".div_radio").bind("click", function () { ValidateRadio("FZPSSF", ""); });
    $("#divTXNHZZX").find(".div_radio").bind("click", function () { ValidateRadio("TXNHZZX", ""); });
    $("#divJXKPZS").find(".div_radio").bind("click", function () { ValidateRadio("JXKPZS", ""); });
    $("#divDPZS").find(".div_radio").bind("click", function () { ValidateRadio("DPZS", ""); });
    $("#divJPSF").find(".div_radio").bind("click", function () { ValidateRadio("JPSF", ""); });
    $("#divJDSF").find(".div_radio").bind("click", function () { ValidateRadio("JDSF", ""); });
    $("#divBHCY").find(".div_radio").bind("click", function () { ValidateRadio("BHCY", ""); });

    $("#FZTS").bind("blur", function () { ValidateSpanInput("FZTS", "服装套数"); });
    $("#FZTS").bind("focus", function () { InfoSpanInput("FZTS", "忘记填写服装套数啦"); });
    $("#TXDPS").bind("blur", function () { ValidateSpanInput("TXDPS", "套系底片数"); });
    $("#TXDPS").bind("focus", function () { InfoSpanInput("TXDPS", "忘记填写套系底片数啦"); });
    $("#TXJXJRCS").bind("blur", function () { ValidateSpanInput("TXJXJRCS", "套系精修及入册数"); });
    $("#TXJXJRCS").bind("focus", function () { InfoSpanInput("TXJXJRCS", "套系精修及入册数"); });
    $("#TXXCSL").bind("blur", function () { ValidateSpanInput("TXXCSL", "套系相册数量"); });
    $("#TXXCSL").bind("focus", function () { InfoSpanInput("TXXCSL", "套系相册数量"); });
    $("#TXBJSL").bind("blur", function () { ValidateSpanInput("TXBJSL", "套系摆件数量"); });
    $("#TXBJSL").bind("focus", function () { InfoSpanInput("TXBJSL", "套系摆件数量"); });
    $("#PSSJ").bind("blur", function () { ValidateSpanInput("PSSJ", "拍摄时间"); });
    $("#PSSJ").bind("focus", function () { InfoInput("PSSJ", "拍摄时间"); });
});
//验证所有
function ValidateAll() {
    if (ValidateRadio("YLGZS", "忘记选择影楼/工作室啦")
        & ValidateRadio("PSDD", "拍摄地点")
        & ValidateSelect("HSSYPSFG", "PSFG", "拍摄风格")
        & ValidateRadio("FWBZ", "服务保证")
        & ValidateSpanInput("FZTS", "服装套数")
        & ValidateRadio("FZSFFQ", "服装是否分区")
        & ValidateRadio("FZPSSF", "服装配饰收费")
        & ValidateRadio("TXNHZZX", "套系内化妆造型")
        & ValidateSpanInput("TXDPS", "套系底片数")
        & ValidateSpanInput("TXJXJRCS", "套系精修及入册数")
         & ValidateRadio("JXKPZS", "精修刻盘赠送")
         & ValidateRadio("DPZS", "底片赠送")
         & ValidateRadio("JPSF", "加片收费")
         & ValidateRadio("JDSF", "加底收费")
        & ValidateSpanInput("TXXCSL", "套系相册数量")
        & ValidateSpanInput("TXBJSL", "套系摆件数量")
        & ValidateSpanInput("PSSJ", "拍摄时间")
         & ValidateRadio("BHCY", "包含餐饮")
        & ValidateJG()
        & ValidateBCMS("BCMS", "忘记填写详情描述啦")

        & ValidateXXDZ()
        & ValidateCommon())
        return true;
    else
        return false;
}