<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IntegrityDiscuss.aspx.cs" Inherits="IntegrityDiscuss" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>诚信评论</title>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript">
    $(document).ready(function(){
        var UrlStr=location.toString();
        $("#BtnSubmit").click(function(){
            if(check())
            {
                var Reaqata="({";
                $("input[type='radio']").each(function(){
                    if($(this).attr("checked"))
                    {
                        Reaqata+="'"+$(this).attr("name")+"':'"+$(this).val()+"',";
                    }
                }); 
                $("textarea").each(function(){
                    Reaqata+="'"+$(this).attr("name")+"':'"+escape($(this).val())+"',";
                });           
                Reaqata+="'action':'add'})";
                Reaqata=eval(Reaqata);
                $.ajax({
                    type: "POST",
                    url: UrlStr,
                    data: Reaqata,
                    dataType: "json",
                    success: function(data) {
                        if (data.statusCode == 1) {
                            $("#Msg").empty().html("提交成功");
                        }
                        else {
                            $("#Msg").empty().html("提交失败");
                        }
                    }
                });
            }
        });
        
        function check()
        {
            var Flag=true;
            if($("#txtContent").val()=="")
            {
                $("#Msg").empty().html("内容不能为空！");
                Flag=false;
            }
            return Flag;
        }
    });
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" background-color:#fef3df; border:1px solid #e85d32; height:auto;   padding:15px; font-size:12px;">
       <div style="width:100%; height:auto; margin-bottom:10px;">诚信分值：<br />
       <input type="radio" name="txtIntegritynumber" value="0" />0分
       <input type="radio" name="txtIntegritynumber" value="1" />1分
       <input type="radio" name="txtIntegritynumber" value="2" />2分
       <input type="radio" name="txtIntegritynumber" value="3" />3分
       <input type="radio" name="txtIntegritynumber" value="4" />4分
       <input type="radio" name="txtIntegritynumber" value="5" checked="checked" />5分
       <input type="radio" name="txtIntegritynumber" value="6" />6分
       <input type="radio" name="txtIntegritynumber" value="7" />7分
       <input type="radio" name="txtIntegritynumber" value="8" />8分
       <input type="radio" name="txtIntegritynumber" value="9" />9分
       <input type="radio" name="txtIntegritynumber" value="10" />10分
       </div> 
        <div style="width:100%;">评价内容：<textarea runat="server" name="txtContent" id="txtContent" cols="30" rows="5"></textarea></div><p />
        <div style="width:100%; height:30px;"><div style="margin-left:70%;">
        <input type="button" id="BtnSubmit" style="border:1px solid #000; width:60px; height:25px; "  value="提交"/></div></div><p />
        <div runat="server" id="Msg" style="color:Red;"></div>
        
    </div>
    </form>
</body>
</html>
