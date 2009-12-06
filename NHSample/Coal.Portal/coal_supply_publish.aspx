<%@ Page Language="C#" AutoEventWireup="true" CodeFile="coal_supply_publish.aspx.cs" Inherits="coal_supply_publish" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>发布煤炭供应信息</title>
<link href="css/admin_style.css" type="text/css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/menu.js"></script>
</head>
<body>
   <form id="form1" runat="server">
   <div id="h_wrapper">
	<div id="h_header">
		<h1 class="logo"><a href="/" title="国家煤炭工业网">国家煤炭工业网</a></h1>
		<div class="h_topNav">
			<div class="h_r1"></div>
			<div class="h_navList"><a href="#">网站首页</a> | <a href="#">我要采购</a> | <a href="#">我要销售</a> | <a href="#">资讯</a> | <a href="#">论坛</a></div>
			<div class="h_r1"></div>
		</div>
		<div class="h_mainMenu clearfix">
			<ul class="h_mainNav">
				<li class="current"><a href="uc_index.aspx">系统首页</a></li>
			</ul>
			<div class="h_userInfo"><span>欢迎 DONGKUO 先生 登录系统 [<a href="#">退出系统</a>]</span></div>
			<div class="h_userExplain"><a href="#">您目前是普通会员，点此升级为诚信通会员</a></div>
		</div>
	</div>
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
							<li class="active"><a href="javascript:void(0);">煤炭供应</a></li>
						</ul>
					</div>
					<div id="tabMenu_Content0">
							<div class="h_itemsBody h_item_bb">
								<table>
								    <tr>
										<th width="15%"><span>*</span>标  题：</th>
										<td width="30%">
										    <input name="text" type="text" class="h_text" style="width:300px" /> 
										    <div class="h_alert">请填写标题！</div><!-- 提示说明部分 -->
										</td>
									</tr>
									<tr>
										<th width="15%"><span>*</span>粒　度：</th>
										<td width="30%">
										<asp:DropDownList ID="lidu" runat="server">
										    <asp:ListItem Text="小粒度" Value="0"></asp:ListItem>
										    <asp:ListItem Text="中粒度" Value="1"></asp:ListItem>
										</asp:DropDownList>
										<div class="h_alert">请选择产品！</div><!-- 提示说明部分 -->
										</td>
										<th width="15%"><span>*</span>焦炭类型：</th>
										<td>
											<select>
												<option value="0">请选择</option>
											</select>
										</td>
									</tr>
									<tr>
										<th><span>*</span>产　地：</th>
										<td>
											<select>
												<option value="0">省份</option>
											</select>
											<select>
												<option value="0">城市</option>
											</select>
											<span class="h_over"></span><!-- 选择后状态 -->
										</td>
										<th><span>*</span>数　量：</th>
										<td>
											<input name="text" type="text" class="h_text" /> 吨
										</td>
									</tr>
									<tr>
										<th><span>*</span>价　格：</th>
										<td>
											<input name="text" type="text" value="0" class="h_text" /> 元/吨
										</td>
										<th><span>*</span>提货地：</th>
										<td>
											<select>
												<option value="0">省份</option>
											</select>
											<select>
												<option value="0">城市</option>
											</select>
										</td>
									</tr>
									<tr>
										<th>挥发份：</th>
										<td>
											<input name="text" type="text" value="0" class="h_text" /> %
										</td>
										<th>硫　份：</th>
										<td>
											<input name="text" type="text" value="0" class="h_text" /> %
											<span class="h_over"></span><!-- 选择后状态 -->
										</td>
									</tr>
									<tr>
										<th>机械强度：</th>
										<td>
											<input name="text" type="text" value="0" class="h_text" /> %
										</td>
										<th>抗碎强度：</th>
										<td>
											<input name="text" type="text" value="0" class="h_text" /> %
										</td>
									</tr>
									<tr>
										<th>灰　份：</th>
										<td>
											<input name="text" type="text" value="0" class="h_text" /> %
										</td>
										<th>水　份：</th>
										<td>
											<input name="text" type="text" value="0" class="h_text" /> %
										</td>
									</tr>
									<tr>
										<th>耐磨强度：</th>
										<td>
											<input name="text" type="text" value="0" class="h_text" /> %
										</td>
										<th>气孔率：</th>
										<td>
											<input name="text" type="text" value="0" class="h_text" /> %
										</td>
									</tr>
									<tr>
										<th>反应性：</th>
										<td>
											<input name="text" type="text" value="0" class="h_text" />
										</td>
										<th>焦沫含量：</th>
										<td>
											<input name="text" type="text" value="0" class="h_text" /> %
										</td>
									</tr>
									<tr>
										<th><span>*</span>信息有效期：</th>
										<td>
											<select>
												<option value="0">请选择</option>
											</select>
										</td>
										<th><span>*</span>推销方式：</th>
										<td>
											<select>
												<option value="0">请选择</option>
											</select>
										</td>
									</tr>
								</table>
							</div>
							<div class="h_itemsBody">
								<table>
									<tr>
										<th width="15%"><span>*</span>联系人：</th>
										<td width="30%">
											<input name="text" type="text" class="h_text" />
											<div class="h_alert">请输入联系人姓名！</div><!-- 提示说明部分 -->
										</td>
										<th width="15%"> </th>
										<td> </td>
									</tr>
									<tr>
										<th><span>*</span>职　务：</th>
										<td>
											<select>
												<option value="0">请选择</option>
											</select>
										</td>
										<th> </th>
										<td> </td>
									</tr>
									<tr>
										<th><span>*</span>联系电话：</th>
										<td>
											<input name="text" type="text" class="h_text" /> -
											<input name="text" type="text" class="h_text2" />
										</td>
										<th><span>*</span>传　真：</th>
										<td>
											<input name="text" type="text" class="h_text" /> -
											<input name="text" type="text" class="h_text2" />
										</td>
									</tr>
									<tr>
										<th><span>*</span>手　机：</th>
										<td>
											<input name="text" type="text" class="h_text3" />
										</td>
										<th><span>*</span>电子邮件：</th>
										<td>
											<input name="text" type="text" class="h_text3" />
										</td>
									</tr>
									<tr>
										<th>公司地址：</th>
										<td>
											<input name="text" type="text" class="h_text4" />
										</td>
										<th> </th>
										<td>
											
										</td>
									</tr>
									<tr>
										<th> </th>
										<td>
										    <asp:Button ID="submit" runat="server" Text="发 布" CssClass="h_buttun1" 
                                                onclick="submit_Click" />
											<input name="reset" type="reset" value="重 置" class="h_buttun1" />
											<br />
											<asp:Label ID="msg" runat="server"></asp:Label>
										</td>
										<th> </th>
										<td> </td>
									</tr>
								</table>
							</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
<input id="current_menu" type="hidden" value="menu_5" />
<input id="parent_menu" type="hidden" value="menu_4" />
<p id="h_footer">Copyright &copy; 2009 国家煤炭工业网 主办：中国煤炭工业协会 技术支持：北京中煤易通科技有限公司</p>
    </form>
</body>
</html>
