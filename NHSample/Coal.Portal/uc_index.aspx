<%@ Page Language="C#" AutoEventWireup="true" CodeFile="uc_index.aspx.cs" Inherits="uc_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>首页</title>
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
			<div class="h_notice">
				<div id="oprate_prompt" class="h_mainTitle">
					<h3>重要操作提醒</h3>
				</div>
				<p id="valid_user" class="h_check">您的账号还未通过验证，无法收到客户的任何反馈 <input name="check" type="button" value="点此验证" class="h_buttun1" /></p>
				<p id="join_member" class="h_check">您已经是认证用户，但还无法享受到更多超值服务 <input name="check" type="button" value="点此了解成为会员" class="h_buttun1" /></p>
				<dl class="clearfix">
					<dt class="dtm"><span>商机快递</span></dt>
					<dd class="ddw">您尚未订阅任何商机快递，无法第一时间掌握最新商机 <a href="#">立即免费订阅</a> 。由于近期qq和tom邮箱接收商机快递邮件不太稳定，为保证信息及时接收，请使用订阅邮箱为tom.com和qq.com的商机快递用户到"管理商机快递"更换订阅邮箱。</dd>
				</dl>
				<dl class="clearfix">
					<dt><span>企业活跃排名</span></dt>	
					<dd>您上周既没有登录网站，也没有登录贸易通，您的活跃分值为0 <a href="#">查看详情</a></dd>
				</dl>
				<dl class="clearfix nobd">
					<dt><span>阿里贷款</span></dt>
					<dd>阿里贷款服务，针对网商群体推出无抵押低息快速贷款！（服务不需要任何费用） <a href="#">立即申请</a></dd>
				</dl>
			</div>
			<div class="h_columns clearfix">
				<div class="h_column h_colW1">
					<div class="h_mainTitle">
						<h3>最新功能</h3>
					</div>
					<ul class="h_columnList">
						<li>商机参谋：<a href="#">帮您有效提升网络营销效果</a></li>
						<li>人脉通：<a href="#">帮您查找潜在客户，方便管理客户信息</a></li>
						<li>移动版诚信通：<a href="#">让您随时随地不错过任何商机，坐商变行商</a></li>
						<li>生意经：<a href="#">阿里商友们正在修炼的生意宝典</a></li>
					</ul>
				</div>
				<div class="h_column h_colW1">
					<div class="h_mainTitle">
						<h3>最新活动</h3>
					</div>
					<ul class="h_columnList">
						<li>&middot;<a href="#">网上开店100天，我要赚100万网，上开店100天，我要赚100万 </a></li>
						<li>&middot;<a href="#">网上开店100天，我要赚100万网，上开店100天，我要赚100万 </a></li>
						<li>&middot;<a href="#">网上开店100天，我要赚100万网，上开店100天，我要赚100万 </a></li>
						<li>&middot;<a href="#">网上开店100天，我要赚100万网，上开店100天，我要赚100万 </a></li>
					</ul>
				</div>
				<div class="h_column h_colW2">
					<div class="h_mainTitle">
						<h3>您现在是普通会员，无法享受阿里巴巴特权服务，建议您升级为诚信通！</h3>
					</div>
					<p>诚信通会员是阿里巴巴的一种会员身份，拥有四大特权、多种增值服务，及享有网站各种推广、优惠的活动的优先权利！详细服务内容请 <a href="#">点此了解</a>。</p>
				</div>
			</div>
		</div>
	</div>
</div>
<p id="h_footer">Copyright &copy; 2009 国家煤炭工业网 主办：中国煤炭工业协会 技术支持：北京中煤易通科技有限公司</p>
</form>
</body>
</html>
