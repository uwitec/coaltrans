<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LinkCategory.aspx.cs" Inherits="CoalSysManage_System_LinkCategory" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>友情链接</title>
    <link rel="Stylesheet" type="text/css" href="../css/Style.css" />
    <script type="text/javascript" src="../js/index.js"></script>
    <script type="text/javascript" src="../js/utils.js"></script>    
    <script type="text/javascript" src="../js/transport.js"></script>
    <script type="text/javascript" src="../js/listtable.js"></script>
    <script type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>   
</head>
<body class="MainBody">
    <form id="form1" runat="server">
    <div class="HeadBar">
        <div class="HeadBarNav">后台管理中心&nbsp;<span>--&nbsp;友情链接</span></div>
        <div class="HeadBarOperate"><div class="Btn_Style1"><a href="javascript:void(null);" onclick="LDisplay('DisplayDiv')">添加位置</a></div></div>
    </div>
    <div class="DataList">
        <asp:Repeater ID="List" runat="server">
            <HeaderTemplate>
                <table class="ListTable"  border="0" cellpadding="0" cellspacing="0">
                  <tr class="ListTableHead">
                    <td style="width:50px;">
                        编号</td>                    
                    <td>位置名称</td>
                    <td style="width:60px;">操作</td>
                  </tr>                  
            </HeaderTemplate>
            <ItemTemplate>
                 <tr class="ListTableBody"  >
                        <td align="center">
                        <%# Eval("CategoryId") %></td>
                    <td align="center"><span title="点击修改名称" onclick="javascript:listTable.edit(this,'edit CategoryName',<%# Eval("CategoryId") %>)"><%# Eval("CategoryName")%></span></td>
                    <td align="center">  
                        <span><a href="javascript:void(null);" title="删除" onclick="javascript:listTable.remove(<%# Eval("CategoryId") %>,'您确定要删除该记录么？','remove');location.reload();"><img src="../images/icon_drop.gif" alt="" /></a></span>
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
        <webdiyer:AspNetPager ID="PagerList" runat="server" FirstPageText="首页" PageSize="14" CssClass="Pager" 
            LastPageText="尾页" NextPageText="后页" onpagechanging="AspNetPager1_PageChanging" 
            PrevPageText="前页" AlwaysShow="true">
        </webdiyer:AspNetPager>
        </div>
    </div>    
    <div id="DisplayDiv"  style="display:none; border:1px solid black; width:300px; height:auto; position:absolute; background:#f8e6ef;" onmouseover='Move_obj("DisplayDiv")'>
        <span style="position:absolute;right:15px;top:5px;"><a href='javascript:void(null);' onclick='Lclose("DisplayDiv")'>关闭</a></span>
        <p />        
        <div>位置名称：<input type="text" id="CategoryName"  /></div>
        <p />
        <div style="float:right;">
            <input type="button" value="提交" Class="Btn_Style3" onclick="javascript:listTable.add(this,'Add Record','CategoryName');location.reload();" />&nbsp;&nbsp;&nbsp;</div>
        <div style="height:30px;"></div>
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    ConverList();
</script>