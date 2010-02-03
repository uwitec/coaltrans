<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemandInfoList.aspx.cs" Inherits="CoalSysManage_Info_DemandInfoList" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>求购信息列表</title>
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
        <div class="HeadBarNav">后台管理中心&nbsp;<span>--&nbsp;求购信息列表</span></div>
        <div class="HeadBarOperate"><div class="Btn_Style1"><a href="javascript:void(null);">添加求购信息</a></div></div>
    </div>
    <div class="SearchBar">
        <div style=" margin-left:50px;">&nbsp;</div>
        <div><b>信息标题：</b><input type="text" id="DemandTitle" runat="server" /></div>
        <div><b>煤炭种类：</b>
            <select id="CoalType" runat="server">
                <option value="0">--请选择煤种--</option>
                <option value="动力煤">动力煤</option>
			    <option value="炼焦煤">炼焦煤</option>
			    <option value="喷吹煤">喷吹煤</option>
			    <option value="无烟煤">无烟煤</option>
			    <option value="洗精煤">洗精煤</option>
			    <option value="中粒度">中粒度</option>
            </select>
        </div>
        <div><b>交货地：</b>
            <asp:DropDownList ID="Province" runat="server" AutoPostBack="True" 
                onselectedindexchanged="Province_SelectedIndexChanged">
            </asp:DropDownList>
        ---
        <select id="city" runat="server">
            
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
                    <td>信息标题</td>
                    <td>有效期限</td>
                    <td>煤炭种类</td>
                    <td>煤炭需求量</td>
                    <td>交货地</td>
                    <td>发布时间</td>
                    <td>是否审核</td>
                    <td>信息排序</td>
                    <td>浏览数</td>
                    <td style="width:60px;">操作</td>
                  </tr>                  
            </HeaderTemplate>
            <ItemTemplate>
                 <tr class="ListTableBody"  >
                        <td>
                        <asp:CheckBox ID="DemandID" runat="server" />
                        <asp:Label ID="ID" runat="server"    Text='<%# Eval("ID") %>'></asp:Label></td>
                    <td align="center"><%# Eval("DemandTitle")%></td>    
                    <td align="center"><%# Eval("InfoIndate").ToString()%></td>
                    <td align="center"><%# Eval("CoalType")%></td>
                    <td align="center"><%# Eval("DemandQuantity")%>吨</td>
                    <td align="center"><%# GetArea(Eval("DeliveryPlace").ToString())%></td>
                    <td align="center"><%# Eval("CreateTime")%></td>
                    <td align="center"><img src='<%# GetImgUrl(Eval("IsAudit").ToString()) %>' alt="修改状态" title="修改状态" onclick="javascript:listTable.toggle(this,'edit status',<%# Eval("ID") %>)" style="" /></td>                    
                    <td align="center"><span title="点击修改排序" onclick="javascript:listTable.edit(this,'edit Sequence',<%# Eval("ID") %>)" style=""><%# Eval("Sequence").ToString()%></span></td>
                    <td align="center"><%# Eval("ViewCount")%></td>
                    <td>
                        <span><a href="javascript:void(null);" title="查看" onclick='Display("DisplayDiv","DemandInfo","UserInfo","ID","UserId",<%# Eval("ID") %>,"DemandInfoList")'><img src="../images/icon_view.gif" alt="" /></a></span>
                        <span><a href='javascript:void(null);' title="编辑"><img src="../images/icon_edit.gif" alt="" /></a></span>
                        <span><a href="javascript:void(null);" title="删除" onclick="javascript:listTable.remove(<%# Eval("ID") %>,'您确定要删除该记录么？','remove');location.reload();"><img src="../images/icon_drop.gif" alt="" /></a></span>
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
        <webdiyer:AspNetPager ID="PagerList" runat="server" AlwaysShow="True" PageSize="14"
            FirstPageText="首页" LastPageText="尾页" NextPageText="后页" 
            onpagechanging="AspNetPager1_PageChanging" PrevPageText="前页">
        </webdiyer:AspNetPager>
        </div>
    </div>
    <div class="DealList">
        <asp:Button ID="BtnDelete" CssClass="Btn_Style3" runat="server" Text="批量删除" 
            onclick="BtnDelete_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnAudit" CssClass="Btn_Style3" runat="server" Text="批量审核" 
            onclick="BtnAudit_Click" />
    </div>
    <div id="DisplayDiv"  style="display:none; border:1px solid black; width:600px; height:auto; position:absolute; background:#f8e6ef;" onmouseover='Move_obj("DisplayDiv")'>
        
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    ConverList();
</script>