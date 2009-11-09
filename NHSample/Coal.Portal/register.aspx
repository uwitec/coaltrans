<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="register.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            $("#validCode").focus(function() {
                $(this).after("<img id='validimg' alt='点击图片刷新' src='ValidCodeGenerator.ashx' />");
                $("#validimg").click(function() {
                    $(this).attr("src", "ValidCodeGenerator.ashx?" + new Date);
                });
            });

            $("#validCode").blur(function() {
                $(this).unbind("focus");
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    用户名:<asp:TextBox ID="login_name" runat="server"></asp:TextBox><br/>
    Email:<asp:TextBox ID="email" runat="server"></asp:TextBox><br/>
    昵称:<asp:TextBox ID="nick_name" runat="server"></asp:TextBox><br/>
    密码:<asp:TextBox ID="password" runat="server"></asp:TextBox><br/>
    验证码:<asp:TextBox ID="validCode" runat="server"></asp:TextBox>
    <asp:Button ID="submit" runat="server" Text="提交" onclick="submit_Click"/>
    <asp:HyperLink ID="valid" runat="server"></asp:HyperLink>
    </div>
    </form>
</body>
</html>
