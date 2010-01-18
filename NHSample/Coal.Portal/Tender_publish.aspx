<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tender_publish.aspx.cs" Inherits="InfoPublish_Tender_publish" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>发布投标信息</title>
<link href="css/admin_style.css" type="text/css" rel="stylesheet" rev="stylesheet" media="all" />
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/uc.js"></script>
<script type="text/javascript" src="js/My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="js/jquery.validate.js"></script>
<script type="text/javascript">
$(document).ready(function(){
    //加载第一级区域列表
    $.post("Handler/RegionHandler.ashx", { parent_id: 9000 }, function(data, status) {
        $("#selProvince").append("<option value='-1' >---请选择省份---</option>");
        $("#selCity").append("<option value='-1' >---请选择城市---</option>");
        for (var i = 0; i < data.regions.length; i++) {
            $("#selProvince").append('<option value="' + data.regions[i].id + '">' + data.regions[i].name + '</option>');
        }
    }, "json");
    
    $("#selProvince").change(function() {
        var provinceId = $(this).val();
        if (provinceId > -1) {
            $.post("Handler/RegionHandler.ashx", { parent_id: provinceId }, function(data, status) {
                $("#selCity").html("<option value='-1'>---请选择城市---</option>");
                for (var i = 0; i < data.regions.length; i++) {
                    $("#selCity").append('<option value="' + data.regions[i].id + '">' + data.regions[i].name + '</option>');
                }
            }, "json");
        }
        else if (provinceId == -1) {
            $("#selCity").html("");
            $("#selCity").append("<option value='-1'>---请选择城市---</option>");
        }
    });
    
    $("#selIsTransport").change(function(){
        if($(this).val()=="1")
        {
            $("#Price").show();
        }
        else
        {
            $("#Price").hide();
        }
    });
    
    function check()
    {
        var Flag=true;
        if($("#txtDemandTitle").val()=="")
        {
            $("#txtDemandTitle").next().html("标题不能为空！");
            Flag=false;
        }
        else
        {
            $("#txtDemandTitle").next().html("");
        }
        if($("#selCoalType").val()=="0")  
        {  
            $("#selCoalType").next().html("请选择煤种！");
            Flag=false;
        }
        else
        {
            $("#selCoalType").next().html("");
        }
        if($("#selGranularity").val()=="0")
        {
            $("#selGranularity").next().html("请选择煤炭粒度范围！");
            Flag=false;
        } 
        else
        {
            $("#selGranularity").next().html("");
        } 
        if($("#txtDemandQuantity").val()=="")
        {
            $("#txtDemandQuantity").next().html("需求量不能为空！");
            Flag=false;
        }
        else
        {
            $("#txtDemandQuantity").next().html("");
        }
        if(($("#selProvince").val()=="-1")&& ($("#selCity").val()=="-1"))
        {
            $("#selCity").next().html("请您选择具体的详细地址！");
            Flag=false;
        }
        else
        {
            $("#selCity").next().html("");
        }
        if($("#txtInfoIndate").val()=="")
        {
            $("#txtInfoIndate").next().html("请您填写信息的有效期限！");
            Flag=false;
        }
        else
        {
            $("#txtInfoIndate").next().html("");
        }
        if($("#selCalorificPower").val()=="0")
        {
            $("#selCalorificPower").next().html("请您选择发热量！");
            Flag=false;
        }  
        else
        {
            $("#selCalorificPower").next().html("");
        }    
        return Flag;
    }
    
    $("#BtnSubmit").click(function(){
      if(check())
      {
        var RequestStr="({";
        $("input[type='text']").each(function(){
            var name=$(this).attr("name");
            var val=$(this).val();
            RequestStr+="'"+name+"':'"+val+"',";
        });
        $("select").each(function(){
            var name=$(this).attr("name");
            var val=$(this).children("option:selected").val();
            RequestStr+="'"+name+"':'"+val+"',";
        });
        $("textarea").each(function(){
            var name=$(this).attr("name");
            var val=$(this).val();
            RequestStr+="'"+name+"':'"+val+"',";
        });
        RequestStr+="'action':'1'})";
        RequestStr=eval(RequestStr);
        $.ajax({
           type: "POST",
           url: "coal_demand_publish.aspx",
           data: RequestStr,
           dataType: "json",
           success: function(data) {
                if (data.statusCode == 1) {
                   $("#Msg").html("恭喜您，提交成功！");
                }
                else {
                   $("#Msg").html("对不起，提交失败！请您认真核对您的信息！");
                }
            }
        });
      }  
    });
});
</script>
<style type="text/css">
    .style2
    {
        width: 75px;
    }
    .style3
    {
        width: 144px;
    }
    .style4
    {
        width: 80px;
    }
    .style5
    {
        width: 86px;
    }
    .style6
    {
        width: 154px;
    }
</style>
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
							<li class="active"><a href="javascript:void(0);">煤炭投标</a></li>
						</ul>
					</div>
					<div id="tabMenu_Content0">
						<div class="h_itemsBody h_item_bb">
							<table cellpadding="0" cellspacing="0" border="0">
							   <tr>
							        <td colspan="4"><span style="color:Red;font-size:14px; font-weight:bolder;">基本信息：</span></td>
							   </tr>
							   <tr>
							        <td style="width:90px;text-align:right;"><span>*</span>标题：</td>
							        <td align="left" colspan="3"><input type="text" size="50" id="txtDemandTitle" name="txtDemandTitle" /><span style="color:Red;"></span></td>							        
							   </tr> 
							   <tr>
							        <td style="width:90px;text-align:right;"><span>*</span>煤种：</td>
							        <td align="left">
							            <select id="selCoalType" name="selCoalType">
							                <option value="0">--请选择煤种--</option>
							                <option value="动力煤">动力煤</option>
										    <option value="炼焦煤">炼焦煤</option>
										    <option value="喷吹煤">喷吹煤</option>
										    <option value="无烟煤">无烟煤</option>
										    <option value="洗精煤">洗精煤</option>
										    <option value="中粒度">中粒度</option>
							            </select>
							            <span style="color:Red;"></span>
							        </td>
							        <td style="width:90px; text-align:right;"><span>*</span>粒度：</td>
							        <td align="left">
							            <select id="selGranularity" name="selGranularity">
							                <option value="0">---请选择粒度范围---</option>
							                <option value="20~50毫米">20~50毫米</option>
							            </select>
							            <span style="color:Red;"></span>
							        </td>
							   </tr>
							   <tr>
							        <td style="width:90px;text-align:right;"><span>*</span>需求量：</td>
							        <td align="left">
							            <input type="text" id="txtDemandQuantity" name="txtDemandQuantity" />（吨）<span style="color:Red;"></span>
							        </td>
							        <td style="width:90px; text-align:right;"><span>*</span>交货地：</td>
							        <td align="left">
							            <select id="selProvince" name="selProvince"></select>-
							            <select id="selCity" name="selCity"></select><span style="color:Red;"></span>
							        </td>
							   </tr>
							   <tr>
							        <td style="width:90px;text-align:right;"><span>*</span>信息有效期：</td>
							        <td align="left" colspan="3"><input type="text" id="txtInfoIndate" name="txtInfoIndate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"  /><span style="color:Red;"></span></td>							        
							   </tr> 
							</table>
						</div>
						<div class="h_itemsBody h_item_bb">
							<table cellpadding="0" cellspacing="0" border="0">
							   <tr>
							        <td colspan="6"><span style="color:Red;font-size:14px; font-weight:bolder;">相关指标：</span></td>
							   </tr>
							    
							   <tr>
							        <td style="text-align:right;" class="style2"><span>*</span>发热量：</td>
							        <td align="left" class="style3">
							            <select id="selCalorificPower" name="selCalorificPower">
							                <option value="0">---请选择范围---</option>
							                <option value="5000大卡">5000大卡</option>
							            </select>
							            <span style="color:Red;"></span>
							        </td>
							        <td style="text-align:right;" class="style4">挥发份：</td>
							        <td align="left" class="style6">
							            <input type="text" size="5" id="txtVolatilize" name="txtVolatilize" />%
							        </td>
							        <td style="text-align:right;" class="style5">灰分：</td>
							        <td align="left">
							            <input type="text" size="5" id="txtAsh" name="txtAsh" />%
							        </td>
							   </tr>
							   <tr>
							        <td style="text-align:right;" class="style2">硫份：</td>
							        <td align="left" class="style3">
							            <input type="text" size="5" id="txtSulphur" name="txtSulphur" />%
							        </td>
							        <td style="text-align:right;" class="style4">水分：</td>
							        <td align="left" class="style6">
							             <input type="text" size="5" id="txtWater" name="txtWater"/>%
							        </td>
							        <td style="text-align:right;" class="style5">热稳定性：</td>
							        <td align="left" style="width:100px;">
							            <input type="text" size="5" id="txtHotStability" name="txtHotStability"/>
							        </td>
							   </tr>
							   <tr>
							        <td style="text-align:right;" class="style2">灰熔融性：</td>
							        <td align="left" class="style3">
							            <input type="text" size="5" id="txtAshFusing" name="txtAshFusing" />
							        </td>
							        <td style="text-align:right;" class="style4">可磨性：</td>
							        <td align="left" class="style6">
							             <input type="text" size="5" id="txtWearproof" name="txtWearproof"/>%
							        </td>
							        <td style="text-align:right;" class="style5">固定碳：</td>
							        <td align="left" style="width:100px;">
							            <select id="selCarbon" name="selCarbon">
							                <option value="0">---请选择范围---</option>
							                <option value="20%~50%">20%~50%</option>
							            </select>
							        </td>
							   </tr>
							   <tr>
							        <td style="text-align:right;" class="style2">机械强度：</td>
							        <td align="left" class="style3">
							            <input type="text" size="5" id="txtMaStrength" name="txtMaStrength" />%
							        </td>
							        <td style="text-align:right;" class="style4">粘结指数：</td>
							        <td align="left" class="style6">
							             <input type="text" size="5" id="txtBinderMark" name="txtBinderMark"/>%
							        </td>
							        <td colspan="2"></td>							        
							   </tr>							   
							</table>
						</div>
						<div class="h_itemsBody h_item_bb">
						    <table cellpadding="0" cellspacing="0" border="0">
							   <tr>
							        <td colspan="2"><span style="color:Red;font-size:14px; font-weight:bolder;">其他信息：</span></td>
							   </tr>
							    
							   <tr>
							        <td style="text-align:right; width:150px;">是否要卖家提供运输：</td>
							        <td align="left">
							            <select id="selIsTransport" name="selIsTransport">
							                <option value="0">---请选择---</option>
							                <option value="0">不需要</option>
							                <option value="1">需要</option>
							            </select>
							        </td>
							   </tr>
							   <tr id="Price" style="display:none;">
							        <td style="text-align:right; width:150px;">价格要求：</td>
							        <td align="left">
							            <input type="text" id="txtTransportPrice" name="txtTransportPrice" />
							        </td>
							   </tr>
							   <tr>
							        <td style="text-align:right; width:150px;">结算方法：</td>
							        <td align="left">
							            <textarea id="txtEstimateStyle" name="txtEstimateStyle" rows="5" cols="50"></textarea>
							        </td>
							   </tr>				   
							</table>
						</div>
						<div class="h_itemsBody h_item_bb">
						    <table cellpadding="0" cellspacing="0" border="0">
							       <tr>
							            <td style="width:300px; text-align:right;" >
							            <input type="button" class="h_buttun1"  value="发布" id="BtnSubmit" name="BtnSubmit" /></td>
							            <td style="width:50px;"></td>
							            <td align="left"><input type="reset" class="h_buttun1"  value="重置" /></td>
							       </tr>
							       <tr>
							            <td style="text-align:center;" >
							            <div id="Msg" style="color:Red; font-size:14px; font-weight:bolder;"></div>
							            </td>							            
							       </tr>
							    </table>
						    </div>
						</div>
						<div style="height:20px; width:100%;">
						    
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
