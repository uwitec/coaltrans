<%@ Page Language="C#" AutoEventWireup="true" CodeFile="categoryList.aspx.cs" Inherits="demo_admin_category_categoryList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>分类列表</title>
    <link rel="Stylesheet" type="text/css" href="../css/Style.css" />

    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/public.js"></script>   
    <script type="text/javascript">        
        $(document).ready(function(){   
            var div_list=$("#MenuList").children("div");
            setMenu(div_list);
        });                 
    </script>
</head>
<body class="MainBody">
    <form id="form1" runat="server">
    <div class="HeadBar">
        <div class="HeadBarNav">
            后台管理中心&nbsp;<span>--&nbsp;分类列表</span></div>
        <div class="HeadBarOperate">
            <div class="Btn_Style1">
                <a href="categoryedit.aspx?ID=&act=add">添加分类</a></div>
        </div>
    </div>
    <div class="DataList" style="height:500px;">
    <div id="MenuList" style="width:600px;" runat="server">
        
    </div>
    
    </div>
    <div class="DealList">
        <%-- <asp:Button ID="BtnDelete" CssClass="Btn_Style3" runat="server" Text="批量删除" 
            onclick="BtnDelete_Click" />--%>
    </div>    
    </form>
</body>
</html>

