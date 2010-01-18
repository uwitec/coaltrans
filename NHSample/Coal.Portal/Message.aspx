<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="Message" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" border:1px solid gray; height:200px; padding:15px;">
       <div style="width:100%; height:50px;">标题：<input runat="server" type="text" id="MessageTitle" /></div> 
        内容：<textarea runat="server" id="MessageContent" cols="30" rows="5"></textarea><p />
        <asp:Button ID="BtnSubmit" runat="server" Text="提交" onclick="BtnSubmit_Click" /><p />
        <div runat="server" id="Msg"></div>
        
    </div>
    </form>
</body>
</html>
