<%@ Page Language="C#" AutoEventWireup="true" CodeFile="company_info.aspx.cs" Inherits="company_info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>公司信息维护</title>
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

        $.ajax({
            type: "POST",
            url: "Handler/GetCorpInfoHandler.ashx",
            dataType: "json",
            success: function(data) {
                for (var field in data) {
                    if (field.indexOf("sel") > -1) {
                        $("#" + field).children("option").each(function() {
                            if ($(this).val() == data[field]) {
                                $(this).attr("selected", "true");
                            }
                        });
                    }
                    else {
                        $("#" + field).val(data[field]);
                    }
                }

                var provinceId = data["selProvince"];
                var cityId = data["selCity"];
                $.post("Handler/RegionHandler.ashx", { parent_id: provinceId }, function(cityData, status) {
                    $("#selCity").html("<option value='-1'>请选择城市</option>");
                    for (var i = 0; i < cityData.regions.length; i++) {
                        $("#selCity").append('<option value="' + cityData.regions[i].id + '">' + cityData.regions[i].name + '</option>');
                    }
                    $("#selCity").children("option").each(function() {
                        if ($(this).val() == cityId) {
                            $(this).attr("selected", "true");
                        }
                    });
                }, "json");
            }
        });

        var validator = $("#form1").validate({
            rules: {
                txtTrueName: {
                    required: true
                },
                txtEstablishDate: {
                    required: true
                },
                txtLegalPerson: {
                    required: true
                },
                txtRegisteredCapital: {
                    required: true
                },
                txtAddress: {
                    required: true
                },
                txtIntro: {
                    required: true
                },
                txtBusinessScope: {
                    required: true
                }
            },
            messages: {
                txtTrueName: {
                    required: "该项不能为空"
                },
                txtEstablishDate: {
                    required: "该项不能为空"
                },
                txtLegalPerson: {
                    required: "该项不能为空"
                },
                txtRegisteredCapital: {
                    required: "该项不能为空"
                },
                txtAddress: {
                    required: "该项不能为空"
                },
                txtIntro: {
                    required: "该项不能为空"
                },
                txtBusinessScope: {
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
                var reqeustString = "{'action':'1','hdfCorpInfoId':'" + $("#hdfCorpInfoId").val() + "',";
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

                $.ajax({
                    type: "POST",
                    url: "company_info.aspx",
                    data: reqJson,
                    dataType: "json",
                    success: function(data) {
                        if (data.statusCode == 1) {
                            $("#msg").empty().html("提交成功");
                        }
                        else {
                            $("#msg").empty().html("提交失败");
                        }
                    }
                });
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
				    <li class="active"><a href="javascript:void(0);">公司信息</a></li>
			    </ul>
		    </div>
		    <div id="tabMenu_Content0">
			<div class="h_itemsBody">
				<table>
					<tr>
						<th width="15%"><span>*</span>公司名称：</th>
						<td width="30%">
							<input id="txtTrueName" name="txtTrueName" class="h_text4" type="text" />
							<div></div>
						</td>
						<th width="15%"><span>*</span>成立日期：</th>
						<td><input id="txtEstablishDate" name="txtEstablishDate" class="h_text2" type="text" />
							<div></div>
						</td>
					</tr>
					<tr>
						<th><span>*</span>公司所在地：</th>
						<td>
							<select id="selProvince" name="selProvince"></select> -
							<select id="selCity" name="selCity"></select>
						</td>
						<th> </th>
						<td> </td>
					</tr>
					<tr>
						<th><span>*</span>公司性质：</th>
						<td>
						    <select id="selCorpType" name="selCorpType" class="h_select3">
						        <option value="1" >国有企业</option>
                                <option value="2" >外资企业</option>
                                <option value="3" >合资企业</option>
                                <option value="4" >有限责任公司</option>
                                <option value="5" >私营企业</option>
                                <option value="6" >民营企业</option>
                                <option value="7" >股份制企业</option>
                                <option value="8" >集体企业</option>
                                <option value="9" >集体事业</option>
                                <option value="10" >乡镇企业</option>
                                <option value="11" >行政机关</option>
                                <option value="12" >社会团体</option>
                                <option value="13" >事业单位</option>
                                <option value="14(集团)" >跨国公司(集团)</option>
                                <option value="15" >其他</option>
						    </select>
						</td>
						<th><span>*</span>公司类型：</th>
						<td>
							<select id="selOperType" name="selOperType">
							    <option value="1" >生产企业</option>
							    <option value="2" >经销企业</option>
							    <option value="3" >终端用户</option>
							    <option value="4" >运输企业</option>
							    <option value="5" >其他相关行业</option>
							</select>
						</td>
					</tr>
					<tr>
						<th><span>*</span>法人代表：</th>
						<td>
							<input id="txtLegalPerson" name="txtLegalPerson" class="h_text" type="text" />
							<div></div>
						</td>
						<th><span>*</span>注册资本：</th>
						<td>
							<input id="txtRegisteredCapital" name="txtRegisteredCapital" class="h_text" type="text" /> 万元
							<div></div>
						</td>
					</tr>
					<tr>
						<th><span>*</span>公司详细地址：</th>
						<td>
							<input id="txtAddress" name="txtAddress" class="h_text4" type="text" />
							<div></div>
						</td>
						<th>公司网址：</th>
						<td>
							<input id="txtWebSite" name="txtWebSite" CssClass="h_text4" type="text" />
							<div></div>
						</td>
					</tr>
					<tr>
						<th><span>*</span>公司简介：</th>
						<td>
						    <textarea id="txtIntro" name="txtIntro"></textarea>
							<div></div>
						</td>
					</tr>
					<tr>
						<th><span>*</span>经营范围：</th>
						<td>
							<textarea id="txtBusinessScope" name="txtBusinessScope"></textarea>
							<div></div>
						</td>
					</tr>
					<tr>
						<th> </th>
						<td>
                            <input id="submit" name="submit" type="button" value="提 交" class="h_buttun1" />
							<input id="reset" name="reset" type="button" value="重 置" class="h_buttun1" />
							<br /><span id="msg"></span>
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
<input id="hdfCorpInfoId" type="hidden" />
<input id="current_menu" type="hidden" value="menu_3" />
<input id="parent_menu" type="hidden" value="menu_1" />
<p id="h_footer">Copyright &copy; 2009 国家煤炭工业网 主办：中国煤炭工业协会 技术支持：北京中煤易通科技有限公司</p>
</form>
</body>
</html>
