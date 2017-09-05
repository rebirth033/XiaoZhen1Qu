﻿function isFocus(e) {
    alert(UE.getEditor('FYMS').isFocus());
    UE.dom.domUtils.preventDefault(e)
}
function setblur(e) {
    UE.getEditor('FYMS').blur();
    UE.dom.domUtils.preventDefault(e)
}
function insertHtml() {
    var value = prompt('插入html代码', '');
    UE.getEditor('FYMS').execCommand('insertHtml', value)
}
function createEditor() {
    enableBtn();
    UE.getEditor('FYMS');
}
function getAllHtml() {
    alert(UE.getEditor('FYMS').getAllHtml())
}
function getContent() {
    var arr = [];
    arr.push("使用editor.getContent()方法可以获得编辑器的内容");
    arr.push("内容为：");
    arr.push(UE.getEditor('FYMS').getContent());
    alert(arr.join("\n"));
}
function getPlainTxt() {
    var arr = [];
    arr.push("使用editor.getPlainTxt()方法可以获得编辑器的带格式的纯文本内容");
    arr.push("内容为：");
    arr.push(UE.getEditor('FYMS').getPlainTxt());
    alert(arr.join('\n'))
}
function setContent(isAppendTo) {
    var arr = [];
    arr.push("使用editor.setContent('欢迎使用ueditor')方法可以设置编辑器的内容");
    UE.getEditor('FYMS').setContent('欢迎使用ueditor', isAppendTo);
    alert(arr.join("\n"));
}
function setDisabled() {
    UE.getEditor('FYMS').setDisabled('fullscreen');
    disableBtn("enable");
}
function setEnabled() {
    UE.getEditor('FYMS').setEnabled();
    enableBtn();
}
function getText() {
    //当你点击按钮时编辑区域已经失去了焦点，如果直接用getText将不会得到内容，所以要在选回来，然后取得内容
    var range = UE.getEditor('FYMS').selection.getRange();
    range.select();
    var txt = UE.getEditor('FYMS').selection.getText();
    alert(txt)
}
function getContentTxt() {
    var arr = [];
    arr.push("使用editor.getContentTxt()方法可以获得编辑器的纯文本内容");
    arr.push("编辑器的纯文本内容为：");
    arr.push(UE.getEditor('FYMS').getContentTxt());
    alert(arr.join("\n"));
}
function hasContent() {
    var arr = [];
    arr.push("使用editor.hasContents()方法判断编辑器里是否有内容");
    arr.push("判断结果为：");
    arr.push(UE.getEditor('FYMS').hasContents());
    alert(arr.join("\n"));
}
function setFocus() {
    UE.getEditor('FYMS').focus();
}
function deleteEditor() {
    disableBtn();
    UE.getEditor('FYMS').destroy();
}
function disableBtn(str) {
    var div = document.getElementById('btns');
    var btns = UE.dom.domUtils.getElementsByTagName(div, "button");
    for (var i = 0, btn; btn = btns[i++];) {
        if (btn.id == str) {
            UE.dom.domUtils.removeAttributes(btn, ["disabled"]);
        } else {
            btn.setAttribute("disabled", "true");
        }
    }
}
function enableBtn() {
    var div = document.getElementById('btns');
    var btns = UE.dom.domUtils.getElementsByTagName(div, "button");
    for (var i = 0, btn; btn = btns[i++];) {
        UE.dom.domUtils.removeAttributes(btn, ["disabled"]);
    }
}
function getLocalData() {
    alert(UE.getEditor('FYMS').execCommand("getlocaldata"));
}
function clearLocalData() {
    UE.getEditor('FYMS').execCommand("clearlocaldata");
    alert("已清空草稿箱")
}