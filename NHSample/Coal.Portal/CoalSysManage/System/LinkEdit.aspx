<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LinkEdit.aspx.cs" Inherits="CoalSysManage_System_LinkEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>广告添加</title>
    <link rel="Stylesheet" type="text/css" href="../css/Style.css" /> 
    <script type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>
</head>
<body class="MainBody">
    <form id="form1" runat="server">
    <div class="HeadBar">
        <div class="HeadBarNav">后台管理中心&nbsp;<span>--&nbsp;广告列表添加或修改</span></div>  
        <div class="HeadBarOperate"><div class="Btn_Style1"><a href="FriendLink.aspx">返回链接列表</a></div></div>      
    </div>    
    <div class="DealList" style="background:white; height:400px;">
        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="EditTable">
          <tr>
            <td align="right">链接位置：</td>
            <td colspan="3">
            <select id="CategoryId" runat="server" style="font-size:12px;">
            </select><span>*</span></td>
          </tr>
          <tr>
            <td width="25%" align="right">链接名称：</td>
            <td width="85%" colspan="3"><input type="text" id="LinkName" runat="server" /><span>*</span></td>
          </tr>
          <tr>
            <td align="right">链接地址：</td>
            <td colspan="3"><input type="text" id="LinkUrl" runat="server" /><span>*</span></td>
          </tr>
          <tr>
            <td align="right">图片Logo：</td>
            <td colspan="3"><input type="file" id="LinkLogo" runat="server" size="35" style="font-size:12px;" /></td>
          </tr>
          <tr>
            <td align="right">或外部链接：</td>
            <td colspan="3"><input type="text" id="ExternalLogo" runat="server" /></td>
          </tr>
          <tr>
            <td align="right">详细描述：</td>
            <td colspan="3"><textarea id="LinkDesc" runat="server" rows="5" cols="30" style="font-size:12px;"></textarea><span>*</span></td>
          </tr>
          <tr>
            <td align="right">显示顺序：</td>
            <td colspan="3">
                <input type="text" id="ShowOrder" runat="server" value="0"  /><span>*</span>
            </td>
          </tr>           
          <tr>
            <td align="right">&nbsp;</td>
            <td align="center" width="45%" >
               
                <asp:Button ID="BtnSubmit" CssClass="Btn_Style3" 
                    runat="server" Text="确定" onclick="BtnSubmit_Click"  />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="BtnAdd" CssClass="Btn_Style3" 
                    runat="server" Text="继续添加" onclick="BtnAdd_Click"  />
                    </td>
            <td align="right">&nbsp;</td>
            <td align="right">&nbsp;</td>
          </tr>
          <tr>
            <td align="right"><div style="color:Red;" runat="server" id="message"></div></td>
            <td colspan="3"></td>
          </tr>
        </table>
    </div>
    </form>
</body>
</html>
