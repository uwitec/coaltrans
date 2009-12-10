<%@ Page Language="C#" AutoEventWireup="true" CodeFile="company_info.aspx.cs" Inherits="company_info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>公司信息维护</title>
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
				    <li class="active"><a href="javascript:void(0);">公司信息</a></li>
			    </ul>
		    </div>
		    <div id="tabMenu_Content0">
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
                            <input name="submit" type="button" value="提 交" class="h_buttun1" />
							<input name="reset" type="button" value="重 置" class="h_buttun1" />
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
<input id="current_menu" type="hidden" value="menu_3" />
<input id="parent_menu" type="hidden" value="menu_1" />
<p id="h_footer">Copyright &copy; 2009 国家煤炭工业网 主办：中国煤炭工业协会 技术支持：北京中煤易通科技有限公司</p>
</form>
</body>
</html>
