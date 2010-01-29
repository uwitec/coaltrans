<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="CoalSysManage_Public_main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>

    <script type="text/javascript" src="js/jquery.js"></script>

    <script type="text/javascript" src="js/ajaxfileupload.js"></script>

    <script type="text/javascript">
        $(document).ready(function(){
            $("#Btn").click(function(){
                $.ajaxFileUpload({
                    url:"../Handler/FileLoad.ashx", 
                    secureuri:false,
                    fileElementId:'img',  
                    dataType: 'json', 
                    OtherData :{'txtName': 20},
                    success: function (data, status)
                    {
                           if(typeof(data.error) != 'undefined')
                           {
                                  if(data.error != '')
                                  {
                                         alert(data.error);
                                  }else
                                  {
                                         alert(data.msg);
                                  }
                           }
                    },
                    error: function (data, status, e) //有错误时进行操作
                    {
                           alert(e);
                    }                    
                });

            });
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <input type="text" name="txtName" id="txtName" />
    <input type="file" id="img" name="img" /><p />
    <%--<asp:Button ID="BtnUpLoad" runat="server" Text="提交" OnClick="BtnUpLoad_Click" />--%>
    <input type="button" value="dsadas" id="Btn" />
    </form>
</body>
</html>
