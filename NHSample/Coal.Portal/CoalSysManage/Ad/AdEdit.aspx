<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdEdit.aspx.cs" Inherits="CoalSysManage_Ad_AdEdit" %>

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
        <div class="HeadBarOperate"><div class="Btn_Style1"><a href="AdList.aspx">返回广告列表</a></div></div>      
    </div>    
    <div class="DealList" style="background:white; height:500px;">
        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="EditTable">
          <tr>
            <td align="right">广告位置：</td>
            <td colspan="3">
            <select id="PositionId" runat="server" style="font-size:12px;">
            </select><span>*</span></td>
          </tr>
          <tr>
            <td width="25%" align="right">广告名称：</td>
            <td width="85%" colspan="3"><input type="text" id="AdName" runat="server" /><span>*</span></td>
          </tr>
          <tr>
            <td align="right">广告链接：</td>
            <td colspan="3"><input type="text" id="AdLink" runat="server" /><span>*</span></td>
          </tr>
          <tr>
            <td align="right">广告简介：</td>
            <td colspan="3"><textarea id="AdDesc" runat="server" rows="5" cols="30" style="font-size:12px;"></textarea><span>*</span></td>
          </tr>
         
          <tr>
            <td align="right">开启时间：</td>
            <td colspan="3">
                <input type="text" id="StartTime" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" /><span>*</span>
            </td>
          </tr>
           <tr>
            <td align="right">结束时间：</td>
            <td colspan="3"><input type="text" id="EndTime" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" /><span>*</span></td>
          </tr>
          <tr>
            <td align="right">联系人：</td>
            <td colspan="3"><input type="text" id="LinkMan" runat="server" /></td>
          </tr>
          <tr>
            <td align="right">联系电话：</td>
            <td colspan="3"><input type="text" id="LinkPhone" runat="server" /></td>
          </tr>
          <tr>
            <td align="right">Email：</td>
            <td colspan="3"><input type="text" id="LinkEmail" runat="server" /></td>
          </tr>
          <tr>
            <td align="right">是否开启：</td>
            <td colspan="3">
            <select id="IsOpen" runat="server" style="font-size:12px;">
                <option value="0">关闭</option>
                <option value="1">开启</option>
            </select></td>
          </tr>
          <tr>
            <td align="right">播放顺序：</td>
            <td colspan="3"><input type="text" id="RankNum" runat="server" value="0" /></td>
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
