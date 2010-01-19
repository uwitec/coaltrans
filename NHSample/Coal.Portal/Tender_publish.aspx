<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tender_publish.aspx.cs" Inherits="InfoPublish_Tender_publish" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

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
        $("input[type='text']").each(function(){   
            $(this).next().html("");         
            var val=$.trim($(this).val());
            if(val=="")
            {                                
                $(this).next().html("该项不能为空！");
                Flag=false;
            }
        }); 
        var oEditor = FCKeditorAPI.GetInstance('txtDetails');//content是fck实例的名称,也是表单文本框的名称 
        oEditor.UpdateLinkedField();//获得内容更新，不做这步操作的话，可能要点第二次才能得到内容结果         
        var content=$.trim(oEditor.GetXHTML(true));
        if(content=="")
        {     
            $("#yztxtDetails").html("简介不能为空！");
            Flag=false;
        }
        else
        {
            $("#yztxtDetails").html("");
        }
        return Flag;
    }
    
    $("#BtnSubmit").click(function(){
      if(check())
      {
        var oEditor = FCKeditorAPI.GetInstance('txtDetails');//content是fck实例的名称,也是表单文本框的名称 
        oEditor.UpdateLinkedField();//获得内容更新，不做这步操作的话，可能要点第二次才能得到内容结果 
        
        var content=$.trim(oEditor.GetXHTML(true));        
        var RequestStr="({'txtDetails':'"+escape(content)+"',";
        $("input[type='text']").each(function(){
            var name=$(this).attr("name");
            var val=$(this).val();
            RequestStr+="'"+name+"':'"+val+"',";
        });
        $("input[type='file']").each(function(){
            var name=$(this).attr("name");
            var val=$(this).val();
            RequestStr+="'"+name+"':'"+escape(val)+"',";
        });
        RequestStr+="'action':'TenderInfo'})";
       RequestStr=eval(RequestStr);        
        $.ajax({
           type: "POST",
           url: "Handler/InfoManage.ashx",
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
							        <td style="width:90px;text-align:right;"><span>*</span>标题：</td>
							        <td align="left" colspan="3"><input type="text" size="50" id="txtTenderTitle" name="txtTenderTitle" /><span style="color:Red;"></span></td>							        
							   </tr> 
							   <tr>
							        <td style="width:90px;text-align:right;"><span>*</span>起始时间：</td>
							        <td align="left" style="width:300px;">
							            <input type="text" id="txtStartTime" name="txtStartTime" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"  />
							            <span style="color:Red;"></span>
							        </td>
							        <td style="width:90px; text-align:right;"><span>*</span>结束时间：</td>
							        <td align="left">
							            <input type="text" id="txtEndTime" name="txtEndTime" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"  />
							            <span style="color:Red;"></span>
							        </td>
							   </tr>
							   <tr>
							        <td style="width:90px;text-align:right;"><span>*</span>投标简介：</td>
							        <td align="left" colspan="3">	
                                        <FCKeditorV2:FCKeditor ID="txtDetails" runat="server" Height="400">
                                        </FCKeditorV2:FCKeditor>					            
                                        <span style="color:Red;" id="yztxtDetails"></span>							            
							        </td>
							        </tr>
							   <tr>
							        <td style="width:90px;text-align:right;">附件上传：</td>
							        <td align="left" colspan="3">
							        <input type="file" id="txtAdjunctUrl" name="txtAdjunctUrl" /></td>							        
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
