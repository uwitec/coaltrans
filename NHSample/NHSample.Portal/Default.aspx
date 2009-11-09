<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>无标题文档</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/ui.core.js"></script>
<script type="text/javascript" src="js/ui.accordion.js"></script>
<script type="text/javascript" src="js/top.js"></script>
<script type="text/javascript">
    $(function() {
        $("#accordion").accordion();
    });
</script>
</head>
<body>
<form id="form1" runat="server">
<div class="userht_all">
  <script type="text/javascript">
      render_top();
  </script>
  <div id="accordion" class="left_all">
    <h3 class="menu_b"><a href="#">信息首页1</a></h3>
    <ul>
    <li class="menu_c"><a href="#">信息首页</a></li>
    <li class="menu_c"><a href="#">信息首页</a></li>
    <li class="menu_c"><a href="#">信息首页</a></li>
    </ul>
	<h3 class="menu_b"><a href="#">信息首页2</a></h3>
	<ul>
    <li class="menu_c"><a href="#">信息首页2-1</a></li>
    <li class="menu_c"><a href="#">信息首页2-2</a></li>
    <li class="menu_c"><a href="#">信息首页2-3</a></li>
    </ul>
    <h3 class="menu_b"><a href="#">信息首页3</a></h3>
	<ul>
    <li class="menu_c"><a href="#">信息首页3-1</a></li>
    <li class="menu_c"><a href="#">信息首页3-2</a></li>
    <li class="menu_c"><a href="#">信息首页3-3</a></li>
    </ul>
  </div>
  <div class="right_all">
    <h1>信息首页</h1>
    <div class="tishi"><img src="images/ico01.jpg" align="absmiddle" />您现在还没有登录，登录后即可使用阿里助手！</div>
    <div class="loginuser">
      <div class="l_login">
        <h1>已经是会员<em>请输入登录名和密码，按“登录”即可。</em></h1>
        <ul>
          <table border="0" cellspacing="0" cellpadding="0" class="login_tb">
            <tr>
              <td>会员登录名：</td>
              <td><input type="text" name="textfield" /></td>
              <td><a href="#">忘了登录名？</a></td>
            </tr>
            <tr>
              <td>密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：</td>
              <td><input type="text" name="textfield2" /></td>
              <td><a href="#">忘了密码？</a></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td><input type="submit" name="Submit" value="登&nbsp;&nbsp;录" /></td>
              <td>&nbsp;</td>
            </tr>
          </table>
        </ul>
      </div>
      <div class="r_login">
        <h1>还不是会员</h1>
        <h2><a href="#"><img src="images/but.jpg" border="0" /></a></h2>
        <h3>免费注册后您即可</h3>
        <ul>
          <li>发布信息，推广产品、宣传公司</li>
          <li>订阅买卖信息，不错过任何商机</li>
          <li>查看管理留言，与客户及时交流</li>
        </ul>
      </div>
    </div>
  </div>
  <script type="text/javascript">
      render_bottom();
  </script>
</div>
</form>
</body>
</html>

