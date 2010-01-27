<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="CoalSysManage_Public_Menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="css/Style.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/public.js"></script>
    <script type="text/javascript">
        $(document).ready(function(){
            $("#Menu").click(function(){
                $(this).attr("class","link");
                $("#Help").attr("class","nolink");
            });   
            $("#Help").click(function(){
                $(this).attr("class","link");
                $("#Menu").attr("class","nolink");
            });
            
        });
        t=setInterval(Menu,1000);       
    </script>
</head>
<body style="margin:0px;">
    <form id="form1" runat="server">
    <div class="Menu">
        <div><a href="javascript:void(null);" class="link" id="Menu">菜单</a></div>
        <div><a href="javascript:void(null);" class="nolink" id="Help">帮助</a></div>
    </div>
    <div style="clear:both;"></div>
    <div style="width:90%; height:auto; border:1px solid red; margin-left:2px; padding:2px;" id="MenuList" runat="server">
        
    </div>
    <div style="width:90%; height:auto; border:1px solid red; margin-left:2px; display:none;padding:2px;"></div>
    <div class="MenuBottom">版权所有：国科安信</div>
    </form>
</body>
</html>