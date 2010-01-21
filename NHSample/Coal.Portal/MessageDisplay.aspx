<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageDisplay.aspx.cs" Inherits="MessageDisplay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>信息查看</title>
</head>
<body style="background-color:#fee6ce;">
    <form id="form1" runat="server">
    <div style=" width:350px; font-size:12px;">
        <div style="width:100%; margin-bottom:15px;">标题：<asp:Label ID="lbtitle" runat="server" Text=""></asp:Label></div>
        <div style="width:100%;">内容：<asp:Label ID="lbcontent" runat="server" Text=""></asp:Label></div>
    </div>
    </form>
</body>
</html>
