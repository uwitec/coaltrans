<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="Message" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" background-color:#fef3df; border:1px solid #e85d32; height:auto;  padding:15px; font-size:12px;">
       <div style="width:100%; height:auto; margin-bottom:10px;">标题：<input runat="server" type="text" id="MessageTitle" /></div> 
        <div style="width:100%;">内容：<textarea runat="server" id="MessageContent" cols="30" rows="5"></textarea></div><p />
        <div style="width:100%; height:30px;"><div style="margin-left:70%;"><input type="button" ID="BtnSubmit" style="border:1px solid #000; width:60px; height:25px; " runat="server" value="提交" onserverclick="BtnSubmit_Click" /></div></div><p />
        <div runat="server" id="Msg"></div>
        
    </div>
    </form>
</body>
</html>
