<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WLPC.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript">
        function GetXQJBXX() {
            var url = "https://www.anjuke.com/sy-city.html";
            $.ajax({
                url: "Ashx/GetXQJBXX.ashx",
                type: "POST",
                async: false,
                dataType: "json",
                data: {
                    url: url
                },
                success: function (data) {

                },
                error: function (data) {

                }
            });
        }
        function GetXQXXXX() {
            var url = "https://www.anjuke.com/sy-city.html";
            $.ajax({
                url: "Ashx/GetXQXXXX.ashx",
                type: "POST",
                async: false,
                dataType: "json",
                data: {
                    url: url
                },
                success: function (data) {

                },
                error: function (data) {

                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="button" value="获取全国小区基本信息" onclick="GetXQJBXX()" />
        <input type="button" value="获取全国小区详细信息" onclick="GetXQXXXX()" />
    </form>
</body>
</html>
