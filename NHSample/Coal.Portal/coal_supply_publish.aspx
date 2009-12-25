<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeFile="coal_supply_publish.aspx.cs" Inherits="coal_supply_publish" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>发布煤炭供应信息</title>
<link href="css/admin_style.css" type="text/css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/uc.js"></script>
<script type="text/javascript" src="js/jquery.validate.js"></script>
<script type="text/javascript">
    $(document).ready(function() {

        //加载第一级区域列表
        $.post("Handler/RegionHandler.ashx", { parent_id: 9000 }, function(data, status) {
            $("#selProvince").append("<option value='-1'>请选择省份</option>");
            $("#selCity").append("<option value='-1'>请选择城市</option>");
            for (var i = 0; i < data.regions.length; i++) {
                $("#selProvince").append('<option value="' + data.regions[i].id + '">' + data.regions[i].name + '</option>');
            }
        }, "json");

        //绑定下拉列表
        $("#selProvince").change(function() {
            var provinceId = $(this).val();
            if (provinceId > -1) {
                $.post("Handler/RegionHandler.ashx", { parent_id: provinceId }, function(data, status) {
                    $("#selCity").html("<option value='-1'>请选择城市</option>");
                    for (var i = 0; i < data.regions.length; i++) {
                        $("#selCity").append('<option value="' + data.regions[i].id + '">' + data.regions[i].name + '</option>');
                    }
                }, "json");
            }
            else if (provinceId == -1) {
                $("#selCity").html("");
                $("#selCity").append("<option value='-1'>请选择城市</option>");
            }
        });

        //        $.ajax({
        //            type: "POST",
        //            url: "Handler/GetCorpInfoHandler.ashx",
        //            dataType: "json",
        //            success: function(data) {
        //                for (var field in data) {
        //                    if (field.indexOf("sel") > -1) {
        //                        $("#" + field).children("option").each(function() {
        //                            if ($(this).val() == data[field]) {
        //                                $(this).attr("selected", "true");
        //                            }
        //                        });
        //                    }
        //                    else {
        //                        $("#" + field).val(data[field]);
        //                    }
        //                }
        //            }
        //        });

        var validator = $("#form1").validate({
            rules: {
                txtTitle: {
                    required: true
                },
                txtValidDate: {
                    required: true
                },
                txtQuantity: {
                    required: true
                },
                txtPrice: {
                    required: true
                },
                txtShipAddr: {
                    required: true
                },
                txtContact: {
                    required: true
                },
                txtFixTel: {
                    required: true
                },
                txtMobileTel: {
                    required: true
                }
            },
            messages: {
                txtTitle: {
                    required: "该项不能为空"
                },
                txtValidDate: {
                    required: "该项不能为空"
                },
                txtQuantity: {
                    required: "该项不能为空"
                },
                txtPrice: {
                    required: "该项不能为空"
                },
                txtShipAddr: {
                    required: "该项不能为空"
                },
                txtContact: {
                    required: "该项不能为空"
                },
                txtFixTel: {
                    required: "该项不能为空"
                },
                txtMobileTel: {
                    required: "该项不能为空"
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

        $("#submit").click(function() {
            if (validator.form()) {
                var reqeustString = "{";
                $("input[type='text']").each(function() {
                    var name = $(this).attr("name");
                    var value = $(this).val();
                    reqeustString += "'" + name + "':'" + value + "',";
                });

                $("select").each(function() {
                    var name = $(this).attr("name");
                    var value = $(this).children("option:selected").val();
                    reqeustString += "'" + name + "':'" + value + "',";
                });

                $("textarea").each(function() {
                    var name = $(this).attr("name");
                    var value = $(this).val();
                    reqeustString += "'" + name + "':'" + value + "',";
                });

                reqeustString = reqeustString.substr(0, reqeustString.length - 1);
                reqeustString += "}";
                var reqJson = eval("(" + reqeustString + ")");
                alert(reqeustString);
                //                $.ajax({
                //                    type: "POST",
                //                    url: "company_info.aspx",
                //                    data: reqJson,
                //                    dataType: "json",
                //                    success: function(data) {
                //                        if (data.statusCode == 1) {
                //                            $("#msg").empty().html("提交成功");
                //                        }
                //                        else {
                //                            $("#msg").empty().html("提交失败");
                //                        }
                //                    }
                //                });
            }
            else {
                return false;
            }
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
							<li class="active"><a href="javascript:void(0);">煤炭供应</a></li>
						</ul>
					</div>
					<div id="tabMenu_Content0">
							<div class="h_itemsBody h_item_bb">
								<table>
								    <tr>
										<th width="15%"><span>*</span>标  题：</th>
										<td width="30%">
										    <input id="txtTitle" name="txtTitle" type="text" class="h_text4" style="width:300px" />
										    <div></div>
										</td>
										<th><span>*</span>信息有效期：</th>
										<td>
											<input name="txtValidDate" type="text" class="h_text" /> 
											<div></div>
										</td>
									</tr>
									<tr>
										<th width="15%"><span>*</span>煤　种：</th>
										<td width="30%">
										<select id="selCoalType" name="selCoalType">
										    <option value="动力煤">动力煤</option>
										    <option value="炼焦煤">炼焦煤</option>
										    <option value="喷吹煤">喷吹煤</option>
										    <option value="无烟煤">无烟煤</option>
										    <option value="洗精煤">洗精煤</option>
										    <option value="中粒度">中粒度</option>
										</select>
										</td>
										<th width="15%"><span>*</span>所属详细煤类：</th>
										<td>
										<select id="selCoalCategory" name="selCoalCategory">
										    <option value="动力煤">动力煤</option>
										    <option value="无烟煤1号">无烟煤1号</option>
										    <option value="无烟煤2号">无烟煤2号</option>
										    <option value="无烟煤3号">无烟煤3号</option>
										    <option value="贫煤">贫煤</option>
										    <option value="贫瘦煤">贫瘦煤</option>
										    <option value="瘦煤">瘦煤</option>
										    <option value="焦煤">焦煤</option>
										    <option value="3/1焦煤">3/1焦煤</option>
										    <option value="肥煤">肥煤</option>
										</select>
										</td>
									</tr>
									<tr>
										<th width="15%"><span>*</span>粒　度：</th>
										<td width="30%">
										<select id="selLidu" name="selLidu" class="h_select3">
										    <option value="1">0-50毫米混煤</option>
										    <option value="2">0-25毫米沫煤</option>
										    <option value="3">0-6毫米粉煤</option>
										    <option value="4">大于100毫米特大块煤</option>
										    <option value="5">50-100毫米大块煤</option>
										    <option value="6">25-50毫米中块煤</option>
										    <option value="7">13-25毫米小块煤</option>
										    <option value="8">小于13毫米和25毫米混块煤</option>
										    <option value="9">13-80毫米混中块煤</option>
										    <option value="10">6-13毫米粒煤</option>
										</select>
										</td>
										<th width="15%"></th>
										<td></td>
									</tr>
									<tr>
										<th><span></span>产　地：</th>
										<td>
										    <select id="selProvince" name="selProvince"></select> -
							                <select id="selCity" name="selCity"></select>
										</td>
										<th><span>*</span>数　量：</th>
										<td>
											<input id="txtQuantity" name="txtQuantity" type="text" class="h_text" /> 吨
											<div></div>
										</td>
									</tr>
									<tr>
										<th><span>*</span>价　格：</th>
										<td>
											<input id="txtPrice" name="txtPrice" type="text" class="h_text" /> 元/吨
											<div></div>
										</td>
										<th><span>*</span>提货地：</th>
										<td>
											<input id="txtShipAddr" name="txtShipAddr" type="text" class="h_text4" />
											<div></div>
										</td>
									</tr>
									<tr>
										<th>挥发份：</th>
										<td>
											<input id="txtHuiFa" name="txtHuiFa" type="text" value="0" class="h_text" /> %
											<div></div>
										</td>
										<th>硫　份：</th>
										<td>
											<input id="txtLiuFen" name="txtLiuFen" type="text" value="0" class="h_text" /> %
											<div></div>
										</td>
									</tr>
									<tr>
										<th>机械强度：</th>
										<td>
											<input id="txtJixieQiangdu" name="txtJixieQiangdu" type="text" value="0" class="h_text" /> %
										</td>
										<th>抗碎强度：</th>
										<td>
											<input id="txtKangSuiQiangdu" name="txtKangSuiQiangdu" type="text" value="0" class="h_text" /> %
										</td>
									</tr>
									<tr>
										<th>灰　份：</th>
										<td>
											<input id="txtAsh" name="txtAsh" type="text" value="0" class="h_text" /> %
										</td>
										<th>水　份：</th>
										<td>
											<input id="txtWater" name="txtWater" type="text" value="0" class="h_text" /> %
										</td>
									</tr>
									<tr>
										<th>耐磨强度：</th>
										<td>
											<input id="txtNaiMo" name="txtNaiMo" type="text" value="0" class="h_text" /> %
										</td>
										<th>气孔率：</th>
										<td>
											<input id="txtQiKong" name="txtQiKong" type="text" value="0" class="h_text" /> %
										</td>
									</tr>
									<tr>
										<th>反应性：</th>
										<td>
											<input id="txtReflection" name="txtReflection" type="text" value="0" class="h_text" />
										</td>
										<th>焦沫含量：</th>
										<td>
											<input id="txtJiaoMo" name="txtJiaoMo" type="text" value="0" class="h_text" /> %
										</td>
									</tr>
								</table>
							</div>
							<div id="user_info" class="h_itemsBody">
								<table>
									<tr>
										<th width="15%"><span>*</span>联系人：</th>
										<td width="30%">
											<input id="txtContact" name="txtContact" type="text" class="h_text" />
											<div></div>
										</td>
										<th width="15%"> </th>
										<td> </td>
									</tr>
									<tr>
										<th><span>*</span>职　务：</th>
										<td>
											<select id="selOccupation" name="selOccupation">
											    <option value="职员">职员</option>
											    <option value="主管">主管</option>
											    <option value="经理">经理</option>
											    <option value="总监">总监</option>
											</select>
										</td>
										<th> </th>
										<td> </td>
									</tr>
									<tr>
										<th><span>*</span>联系电话：</th>
										<td>
											<input id="txtFixTel" name="txtFixTel" type="text" class="h_text" />
											<div></div>
										</td>
										<th><span></span>传　真：</th>
										<td>
											<input id="txtFax" name="txtFax" type="text" class="h_text" />
											<div></div>
										</td>
									</tr>
									<tr>
										<th><span>*</span>手　机：</th>
										<td>
											<input id="txtMobileTel" name="txtMobileTel" type="text" class="h_text" />
											<div></div>
										</td>
										<th><span></span>电子邮件：</th>
										<td>
											<input id="txtEmail" name="txtEmail" type="text" class="h_text3" />
										</td>
									</tr>
									<tr>
										<th>公司地址：</th>
										<td>
											<input id="txtAddr" name="txtAddr" type="text" class="h_text4" />
										</td>
										<th> </th>
										<td>
										</td>
									</tr>
									<tr>
										<th> </th>
										<td>
                                            <input id="submit" name="submit" type="button" value="发 布" class="h_buttun1" />
											<input id="reset" name="reset" type="button" value="重 置" class="h_buttun1" />
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
