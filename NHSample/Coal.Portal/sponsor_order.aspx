<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sponsor_order.aspx.cs" Inherits="sponsor_order" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>发起订单</title>
<link href="css/admin_style.css" type="text/css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/uc.js"></script>
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
		    <dl class="h_tips">
			    <dt>为了让买家能更精确找到您的产品，您可以做以下几步提高您的信息精度，获得更好的排名：</dt>
			    <dd>1、一条信息只发布一个产品；</dd>
			    <dd>2、您的产品名称务必出现在标题中；</dd>
			    <dd>3、尽量完整填写供应信息</dd>
		    </dl>
		    <div class="h_columns clearfix">
			    <div class="h_column h_colW2">
				    <div class="h_mainTitle">
					    <ul class="h_itemsMenu" id="tabMenu">
						    <li class="active"><a href="javascript:void(0);">发起订单</a></li>
					    </ul>
				    </div>
				    <div id="tabMenu_Content0">		
				    </div>
			    </div>
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
