<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="Controls_Login" %>
<script type="text/javascript">
    $(document).ready(function() {
        $("#btn_login").click(function() {
            $("#login").empty();
            $("#login").html("<img src='images/5-1.gif' />正在获取用户数据...").css("height", "50px");
        });
    });
</script>

<div id="login" class="login mar_t16">
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="15%" align="center" class="login_title"><img src="images/login_ico.jpg" width="19" height="31" /></td>
          <td width="85%" class="login_title">会员登录</td>
        </tr>
        <tr>
          <td colspan="2" valign="top">
          <form id="form1" name="form1" method="post" action="">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class=" mar_t10 f12_grey_3">
              <tr>
                <td width="31%" height="30" align="right">用户名：</td>
                <td width="69%" align="left"><input name="textfield" type="text" id="textfield" size="20" class="login_input"/></td>
              </tr>
              <tr>
                <td height="30" align="right">密 &nbsp; 码：</td>
                <td align="left"><input name="textfield2" type="text" id="textfield2" size="20" class="login_input"/></td>
              </tr>
              <tr>
                <td height="30" align="right">验证码：</td>
                <td align="left"><input name="textfield3" type="text" id="textfield3" size="20" class="login_code"/>
                  <img src="images/code.gif" width="52" height="19" align="absmiddle" /></td>
              </tr>
              <tr>
                <td height="40" colspan="2" align="center" valign="bottom"><img id="btn_login" src="images/login_btn.gif" width="154" height="29" border="0"/></td>
                </tr>
            </table>
            </form>
          </td>
        </tr>
      </table>
</div>