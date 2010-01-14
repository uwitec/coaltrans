<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhanneiMessage.aspx.cs" Inherits="zhanneiMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>站内信息</title>
<link href="css/admin_style.css" type="text/css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/uc.js"></script>
<script type="text/javascript">
    $(document).ready(function(){
        var RqData={ see: -1 };
        $("#SeeList").click(function(){
           RqData["see"]=1;
           Bind();
        });
        
        $("#NoSeeList").click(function(){
           RqData["see"]=0; 
           Bind();
        });
        function Bind()
        {
            $.post("Handler/MessageList.ashx",
            RqData,
            function(data,textStatus){
                if(data.rows!=null)
                {
                    var context="";
                    context+="<table style=\"width:800px;font-size:12px; \"><tr><td>发件人</td><td>标题</td><td>内容</td><td>操作</td></tr>"                                
                    for(var one in data.rows)
                    {
                        var row=data.rows[one];
                        context+="<tr>";
                        context+="<td>"+row["Sender"]+"</td><td>"+row["MessageTitle"]+"</td><td>"+row["MessageContent"]+"</td><td><a href=\"javascript:void(null);\">删除</a></td>";
                        context+="</tr>";                    
                    }
                    context+="</table>";
                    $("#MessageList").html(context);
                }
                else
                {
                    $("#MessageList").html("");
                    $("#MessageList").html("对不起，没有数据！");
                }
            },
            "json" 
            );
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
	        <div>
		        您收到的留言有&nbsp;<asp:Label ID="MessageCount" runat="server" Text=""></asp:Label>&nbsp;条<p />
		        已查看留言&nbsp;<asp:Label ID="SeeCount" runat="server" Text=""></asp:Label>&nbsp;条&nbsp;&nbsp;<a href="javascript:void(null)" id="SeeList">查看</a><p />
		        未查看留言&nbsp;<asp:Label ID="NoSeeCount" runat="server" Text=""></asp:Label>&nbsp;条&nbsp;&nbsp;<a href="javascript:void(null)" id="NoSeeList">查看</a>
	        </div>
	        <div id="MessageList">
	        
	        </div>
	    </div>
	    
    </div>
</div>
<input id="current_menu" type="hidden" value="menu_7" />
<input id="parent_menu" type="hidden" value="-1" />
<p id="h_footer">Copyright &copy; 2009 国家煤炭工业网 主办：中国煤炭工业协会 技术支持：北京中煤易通科技有限公司</p>
</form>
</body>
</html>