<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_info.aspx.cs" Inherits="user_info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>基本信息维护</title>
<link href="css/admin_style.css" type="text/css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/uc.js"></script>
<script type="text/javascript" src="js/jquery.validate.js"></script>
<script type="text/javascript">
    $(document).ready(function() {
        var validator = $("#form1").validate({
            rules: {
                // simple rule, converted to {required:true}
                tbxTrueName: {
                    required: true
                },
                tbxFixedTel: {
                    required: true
                },
                tbxFax: {
                    required: true
                },
                tbxMoblieTel: {
                    required: true
                },
                tbxEmail: {
                    required: true,
                    email: true
                }
            },
            messages: {
                tbxTrueName: {
                    required: "该项不能为空"
                },
                tbxFixedTel: {
                    required: "该项不能为空"
                },
                tbxFax: {
                    required: "该项不能为空"
                },
                tbxMoblieTel: {
                    required: "该项不能为空"
                },
                tbxEmail: {
                    required: "该项不能为空",
                    email: "请录入合法的Email"
                }
            },
            errorPlacement: function(error, element) {
                var error_container = element.next("div");
                error.appendTo(error_container.empty());
                error_container.addClass("h_alert");
            },
            success: function(label) {
                label.parent("div").empty().removeClass("h_alert");
            }
        });

        $("#btnSubmit").click(function() {
            return validator.form();
        });
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
				    <li class="active"><a href="javascript:void(0);">基本信息</a></li>
			    </ul>
		    </div>
		    <div id="tabMenu_Content0">
			<div class="h_itemsBody">
				<table>
					<tr>
						<th width="15%"><span>*</span>真实姓名：</th>
						<td width="30%">
						    <asp:TextBox ID="tbxTrueName" CssClass="h_text" runat="server"></asp:TextBox>
						    <div></div>
						</td>
						<th width="15%"> </th>
						<td> </td>
					</tr>
					<tr>
						<th><span>*</span>职　务：</th>
						<td>
						    <asp:DropDownList ID="ddlOccupation" runat="server">
						        <asp:ListItem Value="职员" Text="职员"></asp:ListItem>
						        <asp:ListItem Value="主管" Text="主管"></asp:ListItem>
						        <asp:ListItem Value="经理" Text="经理"></asp:ListItem>
						        <asp:ListItem Value="总监" Text="总监"></asp:ListItem>
						    </asp:DropDownList>
						</td>
						<th> </th>
						<td> </td>
					</tr>
					<tr>
						<th><span>*</span>固定电话：</th>
						<td>
							<asp:TextBox ID="tbxFixedTel" runat="server" CssClass="h_text2"></asp:TextBox>
							<div></div>
						</td>
						<th><span>*</span>传　真：</th>
						<td>
							<asp:TextBox ID="tbxFax" runat="server" CssClass="h_text2"></asp:TextBox>
							<div></div>
						</td>
					</tr>
					<tr>
						<th><span>*</span>手　机：</th>
						<td>
							<asp:TextBox ID="tbxMoblieTel" runat="server" CssClass="h_text2"></asp:TextBox>
							<div></div>
						</td>
						<th><span>*</span>电子邮件：</th>
						<td>
							<asp:TextBox ID="tbxEmail" runat="server" CssClass="h_text2"></asp:TextBox>
							<div></div>
						</td>
					</tr>
					<tr>
						<th> </th>
						<td>
						    <asp:Button ID="btnSubmit" runat="server" Text="提 交" CssClass="h_buttun1" 
                                onclick="btnSubmit_Click"/>
                            <input name="reset" type="button" value="重 置" class="h_buttun1" />
                            <br/>
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
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
<asp:HiddenField id="hfInfoId" runat="server"/>
<input id="current_menu" type="hidden" value="menu_2" />
<input id="parent_menu" type="hidden" value="menu_1" />
<p id="h_footer">Copyright &copy; 2009 国家煤炭工业网 主办：中国煤炭工业协会 技术支持：北京中煤易通科技有限公司</p>
</form>
</body>
</html>
