<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reg_step1.aspx.cs" Inherits="reg_step1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>用户注册</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            $("#validCode").focus(function() {
                //$(this).after("<img id='validimg' alt='点击图片刷新' src='ValidCodeGenerator.ashx' />");
                $(this).attr("value","");
                $("#validimg").attr("src", "Handler/ValidCodeGenerator.ashx?" + new Date).click(function() {
                    $(this).attr("src", "Handler/ValidCodeGenerator.ashx?" + new Date);
                });
            });

            $("#validCode").blur(function() {
                $(this).unbind("focus");
            });
        });
    </script>
</head>
<body>
<form runat="server">
<div class="userht_all">
  <div class="topban"></div>
  <div class="h_menu">服务热线:010-88888888</div>
  <div class="login_bz">
    <ul>
      <li class="bz_a">1.填写注册信息</li>
      <li class="bz_b">2.通过邮件确认</li>
      <li class="bz_b">3.注册成功</li>
    </ul>
  </div>
  <div class="clear"></div>
  <div class="login_xx">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <th width="200">Email地址：</th>
    <td width="251"><asp:TextBox ID="Email" class="intxt" type="text" name="Email" runat="server"></asp:TextBox></td>
    <td width="449">&nbsp;</td>
  </tr>
  <tr>
    <th>设置昵称：</th>
    <td><asp:TextBox ID="NickName" class="intxt" type="text" name="NickName" runat="server"></asp:TextBox></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <th>设定密码：</th>
    <td><asp:TextBox ID="Password" class="intxt" type="password" name="Password" runat="server"></asp:TextBox></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <th>再输一次密码：</th>
    <td><asp:TextBox ID="ConfirmPassword" class="intxt" type="password" name="ConfirmPassword" runat="server"></asp:TextBox></td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <th>验证码：</th>
    <td><asp:TextBox class="in_no1" id="validCode" type="text" name="textfield5" runat="server" Text="获取验证码" ></asp:TextBox>
      <img id="validimg" width="130" height="30" align="absmiddle" /></td>
  </tr>
  <tr>
    <th>&nbsp;</th>
    <td colspan="2"><input name="" type="checkbox" value="" />我已阅读并同意《交易条款》</td>
    </tr>
  <tr>
    <th>&nbsp;</th>
    <td><asp:ImageButton ID="Submit" ImageUrl="images/but0.jpg" width="184" height="35" 
            border="0" runat="server" onclick="Submit_Click" /></td>
    <td>&nbsp;</td>
  </tr>
</table>

  </div>
  <div class="clear"></div>
  <div class="d_menu">Copyright &copy; 2009 国家煤炭工业网</div>
  <div class="endpage">
    <p>主办:中国煤炭工业协会 技术支持:北京中煤易通科技有限公司 </p>
    <p>(浏览本站主页,建议将电脑显示器分辨率调整为:1024*768)</p>
  </div>
</div>
</form>
</body>
</html>

