<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CoalTransList.aspx.cs" Inherits="CoalSysManage_Info_CoalTransList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>供应信息列表</title>
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
        <div class="HeadBarNav">后台管理中心&nbsp;<span>--&nbsp;供应信息列表</span></div>
        <div class="HeadBarOperate"><div class="Btn_Style1"><a href="AdEdit.aspx?ID=&act=add">添加供应信息</a></div></div>
    </div>
    <div class="SearchBar">
        <div style=" margin-left:50px;">&nbsp;</div>
        <div><b>广告名称：</b><input type="text" id="AdName" runat="server" /></div>
        <div><b>广告位置：</b>
            <select id="PositionId" runat="server">
                
            </select>
        </div>
        <div><b>开始时间：</b><input type="text" id="StartTime" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate" /></div>
        <div><b>结束时间：</b><input type="text" id="EndTime" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" class="Wdate"/></div>        
        <div>
            <%--<asp:Button ID="BtnSearch" runat="server" CssClass="Btn_Style2" Text="搜索" 
                onclick="BtnSearch_Click"/>--%></div>
    </div>
    <div class="DataList">
        <%--<asp:Repeater ID="List" runat="server">
            <HeaderTemplate>
                <table class="ListTable"  border="0" cellpadding="0" cellspacing="0">
                  <tr class="ListTableHead">
                    <td style="width:50px;">
                        <input type="checkbox" id="AllSel" onclick="Sel(this)" />编号</td>
                    <td>所属位置</td>
                    <td>广告名称</td>
                    <td>广告链接</td>
                    <td>开始时间</td>
                    <td>结束时间</td>
                    <td>是否开启</td>
                    <td>广告排序</td>
                    <td>点击次数</td>
                    
                    <td style="width:60px;">操作</td>
                  </tr>                  
            </HeaderTemplate>
            <ItemTemplate>
                 <tr class="ListTableBody"  >
                        <td>
                        <asp:CheckBox ID="AdId" runat="server" />
                        <asp:Label ID="ID" runat="server"    Text='<%# Eval("AdId") %>'></asp:Label></td>
                    <td align="center"><%# GetPositinName(Eval("PositionId").ToString())%></td>    
                    <td align="center"><span title="点击修改名称" onclick="javascript:listTable.edit(this,'edit AdName',<%# Eval("AdId") %>)"  style=""><%# Eval("AdName")%></span></td>
                    <td align="center"><span title="点击修改链接" onclick="javascript:listTable.edit(this,'edit AdLink',<%# Eval("AdId") %>)"  style=""><%# Eval("AdLink")%></span></td>
                    <td align="center"><span style=""><%# Eval("StartTime").ToString()%></span></td>
                    <td align="center"><span style=""><%# Eval("EndTime").ToString()%></span></td>
                    <td align="center"><img src='<%# GetImgUrl(Eval("IsOpen").ToString()) %>' alt="修改状态" title="修改状态" onclick="javascript:listTable.toggle(this,'edit open status',<%# Eval("AdId") %>)" style="" /></td>
                    <td align="center"><span title="点击修改播放顺序" onclick="javascript:listTable.edit(this,'edit RankNum',<%# Eval("AdId") %>)"><%# Eval("RankNum").ToString()%></span></td>
                    <td align="center"><%# Eval("ClickNum").ToString()%></td>
                    
                    <td>
                        <span><a href="javascript:void(null);" title="查看" onclick='Display("DisplayDiv","AdList","AdPosition","AdId","PositionId",<%# Eval("AdId") %>,"AdListDis")'><img src="../images/icon_view.gif" alt="" /></a></span>
                        <span><a href='AdEdit.aspx?ID=<%# Eval("AdId") %>&act=edit' title="编辑"><img src="../images/icon_edit.gif" alt="" /></a></span>
                        <span><a href="javascript:void(null);" title="删除" onclick="javascript:listTable.remove(<%# Eval("AdId") %>,'您确定要删除该记录么？','remove');location.reload();"><img src="../images/icon_drop.gif" alt="" /></a></span>
                    </td>
                  </tr>   
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
            
        </asp:Repeater>--%>
    </div>
    <div class="MainBottom">
    <div>
        <%--<webdiyer:AspNetPager ID="PagerList" runat="server" FirstPageText="首页" PageSize="15" CssClass="Pager" 
            LastPageText="尾页" NextPageText="后页" onpagechanging="AspNetPager1_PageChanging" 
            PrevPageText="前页" AlwaysShow="true">
        </webdiyer:AspNetPager>--%>
        </div>
    </div>
    <div class="DealList">
        <%--<asp:Button ID="BtnDelete" CssClass="Btn_Style3" runat="server" Text="批量删除" 
            onclick="BtnDelete_Click" />--%>
    </div>
    <div id="DisplayDiv"  style="display:none; border:1px solid black; width:300px; height:auto; position:absolute; background:#f8e6ef;">
        
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
    ConverList();
</script>