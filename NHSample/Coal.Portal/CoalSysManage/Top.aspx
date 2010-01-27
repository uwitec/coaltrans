<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="CoalSysManage_Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link rel="Stylesheet" href="css/Style.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
        <tr>
            <td width="15%">
                <img src="images/logo.gif" alt="" />
            </td>
            <td width="85%" class="TopBar" >
                <asp:LinkButton ID="BtnLoginOut" runat="server" onclick="BtnLoginOut_Click">退出系统</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="background-color:#ea6141;">
                &nbsp;
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
