<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Coal_Login.aspx.cs" Inherits="CoalSysManage_Coal_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function(){
            $("#AuthCode").focus(function(){
                $(this).val("");
                $("#validimg").attr("src","../Handler/ValidCodeGenerator.ashx?"+new Date).click(function(){
                    $(this).attr("src","../Handler/ValidCodeGenerator.ashx?"+new Date);
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="400" border="1" cellpadding="0" cellspacing="0">
      <tr>
        <td height="61" colspan="2" align="center">管理员登陆</td>
      </tr>
      <tr>
        <td width="93" align="right">用户名：</td>
        <td width="207"><input type="text" name="txtName" id="txtName" runat="server" /></td>
      </tr>
      <tr>
        <td align="right">密码：</td>
        <td><input type="password" name="txtPassWord" id="txtPassWord" runat="server" /></td>
      </tr>
      <tr>
        <td align="right">验证码：</td>
        <td><input type="text" name="AuthCode" id="AuthCode" value="获取验证码" runat="server" /><img id="validimg" src="" width="80" height="20" style="vertical-align:text-bottom" alt="" /></td>
      </tr>
      <tr>
        <td align="right">
            <asp:Button ID="BtnSubmit" runat="server" Text="Button" onclick="BtnSubmit_Click" 
                 /></td>
        <td>&nbsp;</td>
      </tr>
    </table>
    </div>
    </form>
</body>
</html>
