<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WLPC.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript">

        //北京
        function GetBJXZQ() { GetXZQXX("beijing"); }
        //天津
        function GetTJXZQ() { GetXZQXX("tianjin"); }
        //上海
        function GetSHJXZQ() { GetXZQXX("shanghai"); }
        //重庆
        function GetCQXZQ() { GetXZQXX("hainan"); }

        //吉林
        function GetJLXZQ() { GetXZQXX("jilin"); }
        //辽宁
        function GetLNXZQ() { GetXZQXX("liaoning"); }
        //黑龙江
        function GetHLJXZQ() { GetXZQXX("heilongjiang"); }

        //河北
        function GetHBXZQ() { GetXZQXX("hebei"); }
        //山西
        function GetSXXZQ() { GetXZQXX("shanxisheng"); }
        //内蒙
        function GetNMXZQ() { GetXZQXX("neimenggu"); }
        //山东
        function GetSDXZQ() { GetXZQXX("shandong"); }

        //江苏
        function GetJSXZQ() { GetXZQXX("jiangsu"); }
        //浙江
        function GetZJXZQ() { GetXZQXX("zhejiangsheng"); }
        //安徽
        function GetAHXZQ() { GetXZQXX("anhui"); }
        //福建
        function GetFJXZQ() { GetXZQXX("fujian"); }
        //江西
        function GetJXXZQ() { GetXZQXX("jiangxi"); }

        //河南
        function GetHNXZQ() { GetXZQXX("henan"); }
        //湖北
        function GetHuBXZQ() { GetXZQXX("hubei"); }
        //湖南
        function GetHUNXZQ() { GetXZQXX("hunan"); }
        //广东
        function GetGDXZQ() { GetXZQXX("guangdong"); }
        //广西
        function GetGXXZQ() { GetXZQXX("guangxi"); }
        //海南
        function GetHaiNXZQ() { GetXZQXX("hainan"); }
        //陕西
        function GetShanXXZQ() { GetXZQXX("shanxi"); }
        //甘肃
        function GetGSXZQ() { GetXZQXX("gansusheng"); }
        //青海
        function GetQHXZQ() { GetXZQXX("qinghai"); }
        //宁夏
        function GetNXXZQ() { GetXZQXX("ningxia"); }
        //新疆
        function GetXJXZQ() { GetXZQXX("xinjiang"); }
        //四川
        function GetSCXZQ() { GetXZQXX("sichuan"); }
        //贵州
        function GetGZXZQ() { GetXZQXX("guizhou"); }
        //云南
        function GetYNXZQ() { GetXZQXX("yunnan"); }
        //西藏
        function GetCQXZQ() { GetXZQXX("Tibet"); }

        function GetXZQXX(xzq) {
            var url = "";
            url = "http://www.tcmap.com.cn/" + xzq + "/";
            $.ajax({
                url: "Ashx/GetXZQXX.ashx",
                type: "POST",
                async: false,
                dataType: "json",
                data: {
                    url: url,
                    xzq: xzq
                },
                success: function (data) {
                    //alert(data.responseText);
                },
                error: function (data) {
                    //alert(data.responseText);
                }
            });
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="button" value="获取北京" onclick="GetBJXZQ()" />
        <input type="button" value="获取天津" onclick="GetTJXZQ()" />
        <input type="button" value="获取上海" onclick="GetSHJXZQ()" />
        <input type="button" value="获取重庆" onclick="GetCQXZQ()" />
        <input type="button" value="获取吉林" onclick="GetJLXZQ()" />
        <input type="button" value="获取辽宁" onclick="GetLNXZQ()" />
        <input type="button" value="获取黑龙" onclick="GetHLJXZQ()" />
        <input type="button" value="获取河北" onclick="GetHBXZQ()" />
        <input type="button" value="获取山西" onclick="GetSXXZQ()" />
        <input type="button" value="获取内蒙" onclick="GetNMXZQ()" />
        <input type="button" value="获取山东" onclick="GetSDXZQ()" />
        <input type="button" value="获取江苏" onclick="GetJSXZQ()" />
        <input type="button" value="获取浙江" onclick="GetZJXZQ()" />
        <input type="button" value="获取安徽" onclick="GetAHXZQ()" />
        <input type="button" value="获取福建" onclick="GetFJXZQ()" />
        <input type="button" value="获取江西" onclick="GetJXXZQ()" />
        <input type="button" value="获取河南" onclick="GetHNXZQ()" />
        <input type="button" value="获取湖北" onclick="GetHuBXZQ()" />
        <input type="button" value="获取湖南" onclick="GetHUNXZQ()" />
        <input type="button" value="获取广东" onclick="GetGDXZQ()" />
        <input type="button" value="获取广西" onclick="GetGXXZQ()" />
        <input type="button" value="获取海南" onclick="GetHaiNXZQ()" />
        <input type="button" value="获取陕西" onclick="GetShanXXZQ()" />
        <input type="button" value="获取甘肃" onclick="GetGSXZQ()" />
        <input type="button" value="获取青海" onclick="GetQHXZQ()" />
        <input type="button" value="获取宁夏" onclick="GetNXXZQ()" />
        <input type="button" value="获取新疆" onclick="GetXJXZQ()" />
        <input type="button" value="获取四川" onclick="GetSCXZQ()" />
        <input type="button" value="获取贵州" onclick="GetGZXZQ()" />
        <input type="button" value="获取云南" onclick="GetYNXZQ()" />
        <input type="button" value="获取西藏" onclick="GetCQXZQ()" />
    </form>
</body>
</html>
