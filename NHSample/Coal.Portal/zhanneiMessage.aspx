<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhanneiMessage.aspx.cs" Inherits="zhanneiMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>站内信息</title>
<link href="css/admin_style.css" type="text/css" rel="stylesheet" rev="stylesheet" media="all" />
<link href="css/pager.css" type="text/css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/Pager.js"></script>
<script type="text/javascript" src="js/uc.js"></script>
<script type="text/javascript">
    $(document).ready(function(){
        var parameterList={"see":"-1"};        
        var outStr="\"<tr class='TrLis'><td>\"+row['Sender']+\"</td><td><a id='Look_\"+row['ID']+\"_\"+row['IsSee']+\"' class='LookContent' href='javascript:void(null);' title='点击查看'>";
        outStr+="\"+row['MessageTitle'].substring(0,20)+\"</a></td><td>\"+row['MessageContent'].substring(0,50)+\"</td><td>";
        outStr+="<a href='javascript:void(null);' id='Delete_\"+row['ID']+\"_\"+row['IsSee']+\"' class='DeleteInfo' title='删除该信息'>删除</a></td></tr>\"";
	    
		
        $("#SeeList").click(function(){
           parameterList["see"]="1";
           $("#Pager").html("");
           $(".HeadTable").show();
           Bind();
        });
        
        $("#NoSeeList").click(function(){
           parameterList["see"]="0"; 
           $("#Pager").html("");
           $(".HeadTable").show();
           Bind();
        });
        
        function Bind()
        {
            IntPager=new Pager("DisplayList",outStr,"Handler/MessageList.ashx","Pager",7,true,true,parameterList);
		    IntPager.innit();   
        }
        function check()
        {
            alert("dasdas");
        }
    });
</script>
</head>
<body>
<form id="form1" runat="server">
<div id="h_wrapper">
    <!--#include File="uc_top.inc"-->
    <div id="h_content" class="clearfix">
	    <div id="nav" class="h_sideBar">
		    <div id="nav_tree" class="h_tree"></div>
	    </div>
	    <div class="h_main">
	        <div class="MessageHead">
	            &nbsp;&nbsp;&nbsp;&nbsp;<b><asp:Label ID="LbGreetings" runat="server" Text=""></asp:Label></b>&nbsp;&nbsp;&nbsp;&nbsp;今天是&nbsp;
	            <b><asp:Label  ID="LbDateTime" runat="server" Text=""></asp:Label></b>&nbsp;<p /><br />
		        <b>欢迎您登陆煤炭供需平台，为了更好的了解您在平台中的动态，请您随时关注站内消息的查收。</b><p /><br />		       
		        您已收到的留言有&nbsp;<asp:Label ID="Total" runat="server" Text="Label"></asp:Label>&nbsp;条，
		        其中已查看留言&nbsp;<asp:Label ID="Issee" runat="server" Text="Label"></asp:Label>&nbsp;条(<a href="javascript:void(null)" id="SeeList">查看</a>)，
		        未查看留言&nbsp;<asp:Label ID="Nosee" runat="server" Text="Label"></asp:Label>&nbsp;条(<a href="javascript:void(null)" id="NoSeeList">查看</a>)
	        </div>	        
	        <div id="MessageList" class="MessageList">
	            <table class="HeadTable" style="display:none;">
	                <tr><td class="SenderClass">发件人</td><td class="TitleClass">标题</td><td class="ContentClass">内容</td><td>操作</td></tr>
	                <tbody id="DisplayList"></tbody>
	            </table>
	        </div>
	        <div id="Pager" class="Pager_display">
        
            </div>
	    </div>
	    
    </div>
</div>
<input id="current_menu" type="hidden" value="menu_8" />
<input id="parent_menu" type="hidden" value="-1" />
<p id="h_footer">Copyright &copy; 2009 国家煤炭工业网 主办：中国煤炭工业协会 技术支持：北京中煤易通科技有限公司</p>
</form>
</body>
</html>