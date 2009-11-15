<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>用户登录</title>
    <link href="css/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
<div class="login_all">
<div class="logo_l"></div>
<div class="loginuser">
<h1>已经是会员<em>请输入登录名和密码，按“登录”即可。</em></h1>
        <ul>
          <table border="0" cellspacing="0" cellpadding="0" class="login_tb">
            <asp:Label runat="server" ID="errorMsg" Visible="false">账号和密码不匹配，请想想，再试一次</asp:Label>
            <tr>
              <td>会员Email：</td>
              <td><asp:TextBox ID="email" runat="server"></asp:TextBox></td>
              <td><a href="#">忘记会员登录Email？</a></td>
            </tr>
            <tr>
              <td>密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：</td>
              <td><asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox></td>
              <td><a href="#">忘了密码？</a></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td><asp:Button ID="submit" runat="server" Text="登录" onclick="submit_Click"/></td>
              <td>&nbsp;</td>
            </tr>
          </table>
		  </ul>
</div>
<div class="logo_r"></div>
<div class="clear"></div>
<div class="zc_user">
<h1>还不是会员</h1>
        <h2><a href="#"><img src="images/but.jpg" border="0" /></a></h2>
        <h3>免费注册后您即可</h3>
        <ul>
          <li>发布信息，推广产品、宣传公司</li>
          <li>订阅买卖信息，不错过任何商机</li>
          <li>查看管理留言，与客户及时交流</li>
        </ul>
</div>
<div class="d_menu">Copyright &copy; 2009 国家煤炭工业网</div>
  <div class="endpage">
    <p>主办:中国煤炭工业协会 技术支持:北京中煤易通科技有限公司  </p>
    <p>(浏览本站主页,建议将电脑显示器分辨率调整为:1024*768)</p>
  </div>
</div>
</form>
</body>
</html>
