<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="Message" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        标题：<input runat="server" type="text" id="MessageTitle" /><p />
        内容：<textarea runat="server" id="MessageContent"></textarea><p />
        <asp:Button ID="BtnSubmit" runat="server" Text="提交" onclick="BtnSubmit_Click" />
    </div>
    </form>
</body>
</html>
