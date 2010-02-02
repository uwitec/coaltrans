<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PositionEdit.aspx.cs" Inherits="CoalSysManage_Ad_PositionEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>广告位置</title>
    <link rel="Stylesheet" type="text/css" href="../css/Style.css" /> 
</head>
<body class="MainBody">
    <form id="form1" runat="server">
    <div class="HeadBar">
        <div class="HeadBarNav">后台管理中心&nbsp;<span>--&nbsp;广告位置添加或修改</span></div>  
        <div class="HeadBarOperate"><div class="Btn_Style1"><a href="AdPosition.aspx">返回广告位置列表</a></div></div>      
    </div>    
    <div class="DealList" style="background:white; height:350px;">
        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="EditTable">
          <tr>
            <td width="25%" align="right">广告名称：</td>
            <td width="85%" colspan="3"><input type="text" id="PositionName" runat="server" /><span>*</span></td>
          </tr>
          <tr>
            <td align="right">广告宽度：</td>
            <td colspan="3"><input type="text" id="AdWidth" runat="server" />像素<span>*</span></td>
          </tr>
          <tr>
            <td align="right">广告高度：</td>
            <td colspan="3"><input type="text" id="AdHeight" runat="server" />像素<span>*</span></td>
          </tr>
         
          <tr>
            <td align="right">广告类型：</td>
            <td colspan="3">
                <select id="AdType" runat="server">
                    <option value="0">--请选择广告类型--</option>
                    <option value="1">图片</option>
                    <option value="2">Flash</option>
                    <option value="3">文字</option>
                    <option value="4">JavaSript代码</option>
                </select><span>*</span>
            </td>
          </tr>
           <tr>
            <td align="right">广告描述：</td>
            <td colspan="3"><textarea id="AdDetails" runat="server" rows="3" cols="50"></textarea></td>
          </tr>
          <tr>
            <td align="right">&nbsp;</td>
            <td align="center" width="45%" >
               
                <asp:Button ID="BtnSubmit" CssClass="Btn_Style3" 
                    runat="server" Text="确定" onclick="BtnSubmit_Click" />
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