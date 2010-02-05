<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FriendLink.aspx.cs" Inherits="CoalSysManage_System_FriendLink" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>友情链接列表</title>
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
        <div class="HeadBarNav">后台管理中心&nbsp;<span>--&nbsp;友情链接列表</span></div>
        <div class="HeadBarOperate"><div class="Btn_Style1"><a href="LinkEdit.aspx?ID=&act=add">添加友情链接</a></div></div>
    </div>
    <div class="SearchBar">
        <div style=" margin-left:50px;">&nbsp;</div>        
        <div><b>链接位置：</b>
            <select id="CategoryId" runat="server">
                
            </select>
        </div>
        <div>
            <asp:Button ID="BtnSearch" runat="server" CssClass="Btn_Style2" Text="搜索" 
                onclick="BtnSearch_Click"/></div>
    </div>
    <div class="DataList">
        <asp:Repeater ID="List" runat="server">
            <HeaderTemplate>
                <table class="ListTable"  border="0" cellpadding="0" cellspacing="0">
                  <tr class="ListTableHead">
                    <td style="width:50px;">
                        <input type="checkbox" id="AllSel" onclick="Sel(this)" />编号</td>
                    <td>所属位置</td>
                    <td>链接名称</td>
                    <td>链接地址</td>
                    <td>图片展示</td>
                    <td>显示顺序</td>
                    <td style="width:60px;">操作</td>
                  </tr>                  
            </HeaderTemplate>
            <ItemTemplate>
                 <tr class="ListTableBody"  >
                        <td>
                        <asp:CheckBox ID="LinkId" runat="server" />
                        <asp:Label ID="ID" runat="server"    Text='<%# Eval("LinkId") %>'></asp:Label></td>
                    <td align="center"><%# GetPositinName(Eval("CategoryId").ToString())%></td>    
                    <td align="center"><span title="点击修改名称" onclick="javascript:listTable.edit(this,'edit LinkName',<%# Eval("LinkId") %>)"  style=""><%# Eval("LinkName")%></span></td>
                    <td align="center"><span title="点击修改链接" onclick="javascript:listTable.edit(this,'edit LinkUrl',<%# Eval("LinkId") %>)"  style=""><%# Eval("LinkUrl")%></span></td>
                    <td align="center"><span style="">
                    <%# Eval("LinkLogo").ToString()==""?"":"<img src=\""+Eval("LinkLogo")+"\" width=\"70px\" height=\"25px\" align=\"middle\" border=\"0\" />"%>    
                    </td>                   
                    
                    <td align="center"><span title="点击修改显示顺序" onclick="javascript:listTable.edit(this,'edit ShowOrder',<%# Eval("LinkId") %>)"  style=""><%# Eval("ShowOrder")%></span></td>
                    <td>
                        <span><a href="javascript:void(null);" title="查看" onclick='Display("DisplayDiv","FriendLink","LinkCategory","LinkId","CategoryId",<%# Eval("LinkId") %>,"FrendLinkDis")'><img src="../images/icon_view.gif" alt="" /></a></span>
                        <span><a href='LinkEdit.aspx?ID=<%# Eval("LinkId") %>&act=edit' title="编辑"><img src="../images/icon_edit.gif" alt="" /></a></span>
                        <span><a href="javascript:void(null);" title="删除" onclick="javascript:listTable.remove(<%# Eval("LinkId") %>,'您确定要删除该记录么？','remove');location.reload();"><img src="../images/icon_drop.gif" alt="" /></a></span>
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
    <div class="DealList">
        <asp:Button ID="BtnDelete" CssClass="Btn_Style3" runat="server" Text="批量删除" 
            onclick="BtnDelete_Click" />
    </div>
    <div id="DisplayDiv"  style="display:none; border:1px solid black; width:450px; height:auto; position:absolute; background:#f8e6ef;" onmouseover='Move_obj("DisplayDiv")'>
        
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    ConverList();
</script>