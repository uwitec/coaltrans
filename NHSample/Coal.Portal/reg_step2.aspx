<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reg_step2.aspx.cs" Inherits="reg_step2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>无标题文档</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form>
<div class="userht_all">
  <div class="topban"></div>
  <div class="h_menu">服务热线:010-88888888</div>
  <div class="login_bz">
    <ul>
      <li class="bz_b">1.填写注册信息</li>
      <li class="bz_a">2.通过邮件确认</li>
      <li class="bz_b">3.注册成功</li>
    </ul>
  </div>
  <div class="clear"></div>
  <div class="login_email">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <th width="200">&nbsp;</th>
        <td width="292">已向 <em><asp:Label ID="email" runat="server"></asp:Label></em> 发送验证邮件<br />
          点击邮件中的链接地址，即可激活账号，完成注册。 </td>
        <!--<td width="408"><div class="goemail"><a href="#">前往freemail.yeah.net收信</a></div></td>-->
      </tr>
    </table>
  </div>
  <div class="email_txt">
    <h1>如果2小时后，仍未收到激活邮件，请尝试：</h1>
    <ul>
      <li>检查邮箱中的垃圾邮件，激活邮件可能被误认为垃圾邮件。 </li>
      <li>咨询客服，客服电话：010-88888888</li>
      <li><asp:Label ID="ValidTest" runat="server"></asp:Label></li>
    </ul>
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

