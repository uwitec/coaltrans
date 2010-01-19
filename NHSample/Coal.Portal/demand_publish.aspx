<%@ Page Language="C#" AutoEventWireup="true" CodeFile="demand_publish.aspx.cs" Inherits="demand_publish" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>批量发布信息</title>
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
				<dt>重要提醒：</dt>
				<dd>4月28日起，阿里助手中供应信息的发布和修改将全面升级，一口价信息即将升级为可交易信息。（什么是可交易信息？）</dd>
				<dd>随着将来陆续推出更灵活、更丰富、更适合中小企业的交易平台的发展需要，经过前期的客户调研，4月24日起将去除一口价排序优先的规则，一口价信息以及升级后的可交易信息与普通信息一样排序。建议您可以根据您的产品选择适合的信息发布类型。特此告知，感谢您的理解和支持！</dd>
			</dl>
			<div class="h_columns clearfix">
				<div class="h_column h_colW2">
					<div class="h_mainTitle">
						<h3>请选择您的信息发布类型</h3>
					</div>
					<div class="h_items clearfix">
						<div class="h_itemsList">
							<img src="images/h_pic.jpg" alt="" />
							<p>各种资金项目合作、技术专利、租赁转让。<br />如：项目、投资、招投标等。</p>
							<span><a href="coal_demand_publish.aspx">煤炭求购信息发布</a></span>
						</div>
						<div class="h_itemsList">
							<img src="images/h_pic.jpg" alt="" />
							<p>各种煤制品供应信息发布。<br />如：焦炭等。</p>
							<span><a href="coalproduct_demand_publish.aspx">煤制品供应信息发布</a></span>
						</div>
						<div class="h_itemsList">
							<img src="images/h_pic.jpg" alt="" />
							<p>各种资金项目合作、技术专利、租赁转让。<br />如：项目、投资、招投标等。</p>
							<span><a href="#">各种资金项目合作</a></span>
						</div>
						<div class="h_itemsList">
							<img src="images/h_pic.jpg" alt="" />
							<p>各种资金项目合作、技术专利、租赁转让。<br />如：项目、投资、招投标等。</p>
							<span><a href="#">各种资金项目合作</a></span>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
<input id="current_menu" type="hidden" value="menu_6" />
<input id="parent_menu" type="hidden" value="menu_4" />
<p id="h_footer">Copyright &copy; 2009 国家煤炭工业网 主办：中国煤炭工业协会 技术支持：北京中煤易通科技有限公司</p>
</form>
</body>
</html>
