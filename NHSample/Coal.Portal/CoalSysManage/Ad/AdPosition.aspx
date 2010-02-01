<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdPosition.aspx.cs" Inherits="CoalSysManage_Ad_AdPosition" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>广告位置</title>
    <link rel="Stylesheet" type="text/css" href="../css/Style.css" />
    <script type="text/javascript" src="../js/index.js"></script>
    <script type="text/javascript" src="../js/utils.js"></script>    
    <script type="text/javascript" src="../js/transport.js"></script>
    <script type="text/javascript" src="../js/listtable.js"></script>
       
</head>
<body class="MainBody">
    <form id="form1" runat="server">
    <div class="HeadBar">
        <div class="HeadBarNav">后台管理中心&nbsp;<span>--&nbsp;广告位置</span></div>
        <div class="HeadBarOperate"><div class="Btn_Style1"><a href="#">添加广告位置</a></div></div>
    </div>
    <div class="SearchBar">
        <div style=" margin-left:50px;">&nbsp;</div>
        <div><b>广告位置名称：</b><input type="text" id="PositionName" runat="server" /></div>
        <div><b>广告类型：</b>
            <select id="AdType" runat="server">
                <option value="0">--请选择类型--</option>
                <option value="1">图片</option>
                <option value="2">Flash</option>
                <option value="3">文字</option>
                <option value="4">代码</option>
            </select>
        </div>
        <div>
            <asp:Button ID="BtnSearch" runat="server" CssClass="Btn_Style2" Text="搜索" 
                onclick="BtnSearch_Click" /></div>
    </div>
    <div class="DataList">
        <asp:Repeater ID="List" runat="server">
            <HeaderTemplate>
                <table class="ListTable"  border="0" cellpadding="0" cellspacing="0">
                  <tr class="ListTableHead">
                    <td style="width:50px;">
                        <input type="checkbox" id="AllSel" onclick="Sel(this)" />编号</td>
                    <td >广告名称</td>
                    <td>广告宽度</td>
                    <td>广告高度</td>
                    <td>广告描述</td>
                    <td>广告类型</td>
                    <td style="width:60px;">操作</td>
                  </tr>                  
            </HeaderTemplate>
            <ItemTemplate>
                 <tr class="ListTableBody"  >
                    <td>
                        <asp:CheckBox ID="PositionId" runat="server" />
                        <asp:Label ID="ID" runat="server"    Text='<%# Eval("PositionId") %>'></asp:Label></td>
                    <td align="center"><span title="点击修改名称" onclick="javascript:listTable.edit(this,'edit position name',<%# Eval("PositionId") %>)" style=""><%# Eval("PositionName")%></span></td>
                    <td align="center"><span title="点击修改宽度" onclick="javascript:listTable.edit(this,'edit position width',<%# Eval("PositionId") %>)" style=""><%# Eval("AdWidth")%></span>px</td>
                    <td align="center"><span title="点击修改高度" onclick="javascript:listTable.edit(this,'edit position height',<%# Eval("PositionId") %>)" style=""><%# Eval("AdHeight")%></span>px</td>
                    <td><%# Eval("AdDetails")%></td>
                    <td><%# GetType(Eval("AdType").ToString())%></td>
                    <td>
                        <span><a href="javascript:void(null);" title="查看"><img src="../images/icon_view.gif" alt="" /></a></span>
                        <span><a href='PositionEdit.aspx?ID=<%# Eval("PositionId") %>&act=edit' title="编辑"><img src="../images/icon_edit.gif" alt="" /></a></span>
                        <span><a href="javascript:void(null);" title="删除" onclick="javascript:listTable.remove(<%# Eval("PositionId") %>,'您确定要删除该记录么？','remove');location.reload();"><img src="../images/icon_drop.gif" alt="" /></a></span>
                    </td>
                  </tr>   
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div class="MainBottom">
    <div>
        <webdiyer:AspNetPager ID="ListPager" CssClass="Pager" runat="server" PageSize="10" 
            onpagechanging="ListPager_PageChanging" FirstPageText="首页" 
            LastPageText="尾页" NextPageText="后页" PrevPageText="前页" AlwaysShow="True">
        </webdiyer:AspNetPager></div>
    </div>
    <div class="DealList">
        <asp:Button ID="BtnDelete" CssClass="Btn_Style3" runat="server" Text="删除" />
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    ConverList();
</script>
