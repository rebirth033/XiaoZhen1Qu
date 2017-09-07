<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WLPC.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript">

        function JS() {
            GetXQXX(3, "jinshana", "金山");
        }
        function GL() {
            GetXQXX(13, "guloue", "鼓楼");
        }
        function TJ() {
            GetXQXX(5, "taijiang", "台江");
        }
        function JA() {
            GetXQXX(7, "jinana", "晋安");
        }
        function CS() {
            GetXQXX(4, "cangshan", "仓山");
        }
        function MW() {
            GetXQXX(2, "mawei", "马尾");
        }
        function MH() {
            GetXQXX(2, "minhou", "闽侯");
        }
        function ZBXS() {
            GetXQXX(5, "zhoubianxianshib", "周边县市");
        }

        function GetXQXX(size, hz, area) {
            var url = "";
            for (var i = 1; i <= size; i++) {
                url = "https://www.anjuke.com/fz/cm/" + hz + "/p" + i;
                $.ajax({
                    url: "Ashx/GetXQXX.ashx",
                    type: "POST",
                    async: false,
                    dataType: "json",
                    data: {
                        lianjie: url,
                        page: i,
                        area: area
                    },
                    success: function (data) {
                        //alert(data.responseText);
                    },
                    error: function (data) {
                        //alert(data.responseText);
                    }
                });
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="button" value="金山" onclick="JS()" />
        <input type="button" value="鼓楼" onclick="GL()" />
        <input type="button" value="台江" onclick="TJ()" />
        <input type="button" value="晋安" onclick="JA()" />
        <input type="button" value="仓山" onclick="CS()" />
        <input type="button" value="马尾" onclick="MW()" />
        <input type="button" value="闽侯" onclick="MH()" />
        <input type="button" value="周边县市" onclick="ZBXS()" />
    </form>
</body>
</html>
